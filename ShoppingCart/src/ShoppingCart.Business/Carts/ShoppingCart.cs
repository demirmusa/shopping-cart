using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Shared.Campaigns;
using ShoppingCart.Shared.Products;

namespace ShoppingCart.Business.Carts
{
    public class ShoppingCart
    {
        public List<CartItem> Products { get; set; }

        public void AddItem(ProductDto product, int quantity)
        {
            if (Products.Any(p => p.Product.Id == product.Id))
            {
                Products.Single(p => p.Product.Id == product.Id).Quantity += quantity;
            }
            else
            {
                Products.Add(new CartItem()
                {
                    Product = product,
                    Quantity = quantity
                });
            }
        }

        public void ApplyDiscounts(params CampaignDto[] campaigns)
        {

        }
    }

    public class CartItem
    {
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
    }
}
