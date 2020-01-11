using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ShoppingCart.EntityFrameworkCore.Categories
{
    public class Category : Entity
    {
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [ForeignKey("ParentCategoryId")]
        public int? ParentCategoryId { get; set; }

        public virtual Category ParentCategory { get; set; }
    }
}
