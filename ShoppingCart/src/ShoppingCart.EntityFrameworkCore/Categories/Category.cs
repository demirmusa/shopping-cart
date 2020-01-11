using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.EntityFrameworkCore.Categories
{
    public class Category : Entity
    {
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [ForeignKey("ParentCategoryId")]
        public int? ParentCategoryId { get; set; }

        public virtual Category ParentCategory { get; set; }

        public Category(string title)
        {
            Title = title;
        }

        public Category(string title, int? parentCategoryId)
        {
            Title = title;
            ParentCategoryId = parentCategoryId;
        }
    }
}
