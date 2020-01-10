using System.Threading.Tasks;

namespace ShoppingCart.Shared
{
    public interface IAsyncCRUDRepository<TEntityDto> : IAsyncCRUDRepository<TEntityDto, int> where TEntityDto : EntityDto<int>
    {
    }

    public interface IAsyncCRUDRepository<TEntityDto, TPrimaryKey> where TEntityDto : EntityDto<TPrimaryKey>
    {
        Task<TEntityDto> GetAsync(TPrimaryKey id);

        Task InsertAsync(TEntityDto entityDto);

        Task Update(TEntityDto entityDto);

        Task Delete(TPrimaryKey id);
    }
}
