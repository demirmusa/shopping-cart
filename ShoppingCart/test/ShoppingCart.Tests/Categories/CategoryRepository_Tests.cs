using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Shared.Categories;
using Shouldly;
using Xunit;

namespace ShoppingCart.Tests.Categories
{
    public class CategoryRepository_Tests : ShoppingCartTestBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryRepository_Tests()
        {
            _categoryRepository = ServiceProvider.GetRequiredService<ICategoryRepository>();
        }

        private async Task<CategoryDto> CreateCategory(string title, int? parentId)
        {
            var dto = new CategoryDto()
            {
                Title = title,
                ParentCategoryId = parentId
            };
            await _categoryRepository.InsertAsync(dto);

            var entityDto = await _categoryRepository.GetAsync(dto.Id);
            entityDto.Id.ShouldNotBeNull();
            entityDto.ShouldNotBeNull();
            entityDto.Title.ShouldBe(dto.Title);
            entityDto.ParentCategoryId.ShouldBe(dto.ParentCategoryId);

            return entityDto;
        }

        [Theory]
        [InlineData(null, null, true, typeof(ArgumentNullException))]//title is required, should throw exception
        [InlineData("", null, true, typeof(ArgumentNullException))]//title can not be null or empty
        [InlineData(null, int.MaxValue, true, typeof(ArgumentNullException))]//there is category with given parent id, should throw exception
        [InlineData("Cars", int.MaxValue, true, null)]//there is no category with given parent id, should throw exception
        [InlineData("Cars", 0, true, null)]//there is no category with given parent id, should throw exception
        [InlineData("Cars", null, false, null)]
        public async Task Should_Insert_Category(string title, int? parentId, bool shouldThrowException, Type exceptionType)
        {
            if (shouldThrowException)
            {
                if (exceptionType != null)
                {
                    await Assert.ThrowsAsync(exceptionType,
                        async () =>
                        {
                            await _categoryRepository.InsertAsync(new CategoryDto()
                            {
                                Title = title,
                                ParentCategoryId = parentId
                            });
                        });
                }
                else
                {
                    await ShouldThrowException(async () =>
                    {
                        await _categoryRepository.InsertAsync(new CategoryDto()
                        {
                            Title = title,
                            ParentCategoryId = parentId
                        });
                    });
                }
            }
            else
            {
                await CreateCategory(title, parentId);
            }
        }

        [Fact]
        public async Task Should_Insert_Category_If_Parent_Exists()
        {
            var category1 = await CreateCategory("Category1", null);
            await CreateCategory("Category1-1", category1.Id);
        }

        [Theory]
        [InlineData(null, null, true, typeof(ArgumentNullException))]//title is required, should throw exception
        [InlineData("", null, true, typeof(ArgumentNullException))]//title can not be null or empty
        [InlineData(null, int.MaxValue, true, typeof(ArgumentNullException))]//there is category with given parent id, should throw exception
        [InlineData("Cars", int.MaxValue, true, null)]//there is no category with given parent id, should throw exception
        [InlineData("Cars", 0, true, null)]//there is no category with given parent id, should throw exception
        [InlineData("Cars", null, false, null)]
        public async Task Should_Update_Category(string title, int? parentId, bool shouldThrowException, Type exceptionType)
        {
            var category = await CreateCategory("Category1", null);
            category.Title = title;
            category.ParentCategoryId = parentId;

            if (shouldThrowException)
            {
                if (exceptionType != null)
                {
                    await Assert.ThrowsAsync(exceptionType,
                        async () =>
                        {
                            await _categoryRepository.UpdateAsync(category);
                        });
                }
                else
                {
                    await ShouldThrowException(async () =>
                    {
                        await _categoryRepository.UpdateAsync(category);
                    });
                }
            }
            else
            {
                await _categoryRepository.UpdateAsync(category);

                var entity = await _categoryRepository.GetAsync(category.Id);
                entity.ShouldNotBeNull();
                entity.Title.ShouldBe(category.Title);
                entity.ParentCategoryId.ShouldBe(category.ParentCategoryId);
            }
        }

        [Fact]
        public async Task Should_Update_Category_If_Parent_Exists()
        {
            var category1 = await CreateCategory("Category1", null);
            var category1_1 = await CreateCategory("Category1-1", null);

            category1_1.ParentCategoryId = category1.Id;
            await _categoryRepository.UpdateAsync(category1_1);
        }

        [Fact]
        public async Task Should_Delete_Category()
        {
            var category = await CreateCategory("Category1", null);

            await ShouldThrowException(async () =>
            {
                await _categoryRepository.DeleteAsync(0);
            });

            (await _categoryRepository.GetAsync(category.Id)).ShouldNotBeNull();

            await ShouldThrowException(async () =>
            {
                await _categoryRepository.DeleteAsync(-1);
            });

            (await _categoryRepository.GetAsync(category.Id)).ShouldNotBeNull();

            await _categoryRepository.DeleteAsync(category.Id);

            (await _categoryRepository.GetAsync(category.Id)).ShouldBeNull();
        }

    }
}
