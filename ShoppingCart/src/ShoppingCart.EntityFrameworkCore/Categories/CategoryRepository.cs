using System;
using System.Threading.Tasks;
using AutoMapper;
using ShoppingCart.Shared.Categories;

namespace ShoppingCart.EntityFrameworkCore.Categories
{
    public class CategoryRepository : AsyncCRUDRepository<Category, CategoryDto>, ICategoryRepository
    {
        public CategoryRepository(ShoppingCartDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override Task InsertAsync(CategoryDto entityDto)
        {
            if (string.IsNullOrWhiteSpace(entityDto.Title))
            {
                throw new ArgumentNullException($"{nameof(entityDto.Title)} can not be null or empty");
            }

            return base.InsertAsync(entityDto);
        }

        public override Task UpdateAsync(CategoryDto entityDto)
        {
            if (string.IsNullOrWhiteSpace(entityDto.Title))
            {
                throw new ArgumentNullException($"{nameof(entityDto.Title)} can not be null or empty");
            }

            return base.UpdateAsync(entityDto);
        }
    }
}
