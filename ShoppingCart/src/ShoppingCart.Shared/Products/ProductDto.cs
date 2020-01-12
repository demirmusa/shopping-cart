using ShoppingCart.Shared.Categories;

namespace ShoppingCart.Shared.Products
{
    public class ProductDto : EntityDto
    {
        public string Title { get; set; }

        public double Price { get; set; }

        public int CategoryId { get; set; }

        public ProductDto(string title, double price, int categoryId)
        {
            Title = title;
            Price = price;
            CategoryId = categoryId;
        }

        public ProductDto(string title, double price, CategoryDto category)
        {
            Title = title;
            Price = price;
            CategoryId = category.Id;
        }
    }
}
