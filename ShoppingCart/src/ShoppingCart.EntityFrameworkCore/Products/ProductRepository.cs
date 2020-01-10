using AutoMapper;
using ShoppingCart.Shared.Products;

namespace ShoppingCart.EntityFrameworkCore.Products
{
    public class ProductRepository : AsyncCRUDRepository<Product,ProductsDto>, IProductRepository
    {
        public ProductRepository(ShoppingCartDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
