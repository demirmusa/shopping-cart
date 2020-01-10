namespace ShoppingCart.EntityFrameworkCore
{
    public class Entity : Entity<int>
    {
    }

    public class Entity<TPrimaryKey>
    {
        /// <summary>
        /// Unique identifier for this entity.
        /// </summary>
        public virtual TPrimaryKey Id { get; set; }
    }
}
