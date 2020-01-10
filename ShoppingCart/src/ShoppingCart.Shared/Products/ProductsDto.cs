namespace ShoppingCart.Shared.Products
{
    public class ProductsDto : EntityDto
    {
        public string Title { get; set; }

        public string Price { get; set; }

        public int CategoryId { get; set; }
    }
}
