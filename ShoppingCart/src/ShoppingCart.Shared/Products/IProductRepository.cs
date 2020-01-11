using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Shared.Products
{
    public interface IProductRepository : IAsyncCRUDRepository<ProductDto>
    {
    }
}
