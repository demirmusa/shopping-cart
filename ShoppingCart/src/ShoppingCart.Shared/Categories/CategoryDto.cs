namespace ShoppingCart.Shared.Categories
{
    public class CategoryDto : EntityDto
    {
        public string Title { get; set; }

        public int? ParentCategoryId { get; set; }
    }
}
