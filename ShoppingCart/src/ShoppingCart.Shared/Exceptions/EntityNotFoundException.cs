using System;

namespace ShoppingCart.Shared.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException():base("Entity Not Found")
        {
            
        }
    }
}
