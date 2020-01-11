using System;
using System.Threading.Tasks;
using AutoMapper;
using ShoppingCart.Shared.Products;

namespace ShoppingCart.EntityFrameworkCore.Products
{
    public class ProductRepository : AsyncCRUDRepository<Product, ProductDto>, IProductRepository
    {
        public ProductRepository(ShoppingCartDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override Task InsertAsync(ProductDto entityDto)
        {
            if (string.IsNullOrWhiteSpace(entityDto.Title))
            {
                throw new ArgumentNullException($"{nameof(entityDto.Title)} can not be null or empty");
            }

            if (entityDto.Price <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(entityDto.Price), $"{nameof(entityDto.Price)} must be more than 0(zero)");
            }

            return base.InsertAsync(entityDto);
        }

        public override Task UpdateAsync(ProductDto entityDto)
        {
            if (string.IsNullOrWhiteSpace(entityDto.Title))
            {
                throw new ArgumentNullException($"{nameof(entityDto.Title)} can not be null or empty");
            }

            if (entityDto.Price <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(entityDto.Price), $"{nameof(entityDto.Price)} must be more than 0(zero)");
            }

            return base.UpdateAsync(entityDto);
        }
    }
}
