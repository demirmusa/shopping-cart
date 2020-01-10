namespace ShoppingCart.Shared
{
    public class EntityDto : EntityDto<int>
    {
    }

    public class EntityDto<TPrimaryKey>
    {
        /// <summary>
        /// Unique identifier for this entity.
        /// </summary>
        public virtual TPrimaryKey Id { get; set; }
    }
}
