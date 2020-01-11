using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Shared.Categories;
using ShoppingCart.Shared.Products;
using Shouldly;
using Xunit;

namespace ShoppingCart.Tests.Products
{
    public class ProductRepository_Tests : ShoppingCartTestBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductRepository_Tests()
        {
            _productRepository = ServiceProvider.GetRequiredService<IProductRepository>();
            _categoryRepository = ServiceProvider.GetRequiredService<ICategoryRepository>();
        }

        private async Task<ProductDto> CreateProduct(string title, double price, int categoryId)
        {
            var productDto = new ProductDto(title, price, categoryId);

            await _productRepository.InsertAsync(productDto);

            var entityDto = await _productRepository.GetAsync(productDto.Id);
            entityDto.ShouldNotBeNull();
            entityDto.Id.ShouldNotBe(0);
            entityDto.Title.ShouldBe(productDto.Title);
            entityDto.Price.ShouldBe(productDto.Price);
            entityDto.CategoryId.ShouldBe(productDto.CategoryId);

            return entityDto;
        }

        private async Task<CategoryDto> InsertAndGetCategory()
        {
            CategoryDto dto = new CategoryDto("Category 1");
            await _categoryRepository.InsertAsync(dto);
            return dto;
        }

        [Theory]
        [InlineData("Product 1", int.MinValue, typeof(ArgumentOutOfRangeException))]
        [InlineData("Product 1", -1, typeof(ArgumentOutOfRangeException))]
        [InlineData("Product 1", 0, typeof(ArgumentOutOfRangeException))]
        [InlineData(null, 10, typeof(ArgumentNullException))]
        [InlineData("", 10, typeof(ArgumentNullException))]
        [InlineData(" ", 10, typeof(ArgumentNullException))]
        [InlineData(null, 0, typeof(ArgumentNullException))]
        [InlineData(null, -1, typeof(ArgumentNullException))]
        [InlineData("Product 1", 10)]
        [InlineData("Product 1", int.MaxValue)]
        public async Task Can_Insert_Theory(string title, double price, Type exceptionType = null)
        {
            var category = await InsertAndGetCategory();

            if (exceptionType != null)
            {
                await Assert.ThrowsAsync(exceptionType,
                    async () =>
                    {
                        await _productRepository.InsertAsync(new ProductDto(title, price, category.Id));
                    });
            }
            else
            {
                await CreateProduct(title, price, category.Id);
            }
        }

        [Fact]
        public async Task Should_Not_Insert_If_Category_Not_Exists()
        {
            await ShouldThrowException(
                async () =>
                {
                    await _productRepository.InsertAsync(new ProductDto("Product 1", 10, 0));
                }, "FOREIGN KEY constraint failed");
        }

        [Theory]
        [InlineData("Product 1", int.MinValue, typeof(ArgumentOutOfRangeException))]
        [InlineData("Product 1", -1, typeof(ArgumentOutOfRangeException))]
        [InlineData("Product 1", 0, typeof(ArgumentOutOfRangeException))]
        [InlineData(null, 10, typeof(ArgumentNullException))]
        [InlineData("", 10, typeof(ArgumentNullException))]
        [InlineData(" ", 10, typeof(ArgumentNullException))]
        [InlineData(null, 0, typeof(ArgumentNullException))]
        [InlineData(null, -1, typeof(ArgumentNullException))]
        [InlineData("Product 1", 10)]
        [InlineData("Product 1", int.MaxValue)]
        public async Task Can_Update_Theory(string title, double price, Type exceptionType = null)
        {
            var category = await InsertAndGetCategory();

            var product = await CreateProduct("Test Product", 10, category.Id);
            product.Title = title;
            product.Price = price;

            if (exceptionType != null)
            {
                await Assert.ThrowsAsync(exceptionType,
                    async () =>
                    {
                        await _productRepository.UpdateAsync(product);
                    });
            }
            else
            {
                await _productRepository.UpdateAsync(product);
            }
        }

        [Fact]
        public async Task Should_Not_Update_If_Category_Not_Exists()
        {
            var category = await InsertAndGetCategory();

            var product = await CreateProduct("Test Product", 10, category.Id);

            product.CategoryId = 0;
            await ShouldThrowException(
                async () =>
                {
                    await _productRepository.UpdateAsync(product);
                }, "FOREIGN KEY constraint failed");


            product.CategoryId = int.MinValue;
            await ShouldThrowException(
                async () =>
                {
                    await _productRepository.UpdateAsync(product);
                }, "FOREIGN KEY constraint failed");

            product.CategoryId = int.MaxValue;
            await ShouldThrowException(
                async () =>
                {
                    await _productRepository.UpdateAsync(product);
                }, "FOREIGN KEY constraint failed");
        }

        [Fact]
        public async Task Test_Delete_Product()
        {
            var category = await InsertAndGetCategory();
            var product = await CreateProduct("Test Product", 10, category.Id);

            await ShouldThrowException(async () =>
            {
                await _productRepository.DeleteAsync(0);
            }, "Value cannot be null. (Parameter 'entity')");

            (await _productRepository.GetAsync(product.Id)).ShouldNotBeNull();

            await ShouldThrowException(async () =>
            {
                await _productRepository.DeleteAsync(-1);
            }, "Value cannot be null. (Parameter 'entity')");

            (await _productRepository.GetAsync(product.Id)).ShouldNotBeNull();

            await _productRepository.DeleteAsync(product.Id);

            (await _productRepository.GetAsync(product.Id)).ShouldBeNull();
        }

    }
}
