using AutoMapper;
using ShoppingCart.Shared.Categories;

namespace ShoppingCart.EntityFrameworkCore.Categories
{
    public class CategoryRepository : AsyncCRUDRepository<Category, CategoryDto>, ICategoryRepository
    {
        public CategoryRepository(ShoppingCartDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
