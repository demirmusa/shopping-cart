namespace ShoppingCart.Shared.Categories
{
    public class CategoryDto : EntityDto
    {
        public string Title { get; set; }

        public int? ParentCategoryId { get; set; }

        public CategoryDto(string title)
        {
            Title = title;
        }

        public CategoryDto(string title, int? parentCategoryId)
        {
            Title = title;
            ParentCategoryId = parentCategoryId;
        }
    }
}
