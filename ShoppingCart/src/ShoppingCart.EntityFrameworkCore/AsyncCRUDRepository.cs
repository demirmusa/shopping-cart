using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Shared;

namespace ShoppingCart.EntityFrameworkCore
{
    public class AsyncCRUDRepository<TEntity, TEntityDto> : AsyncCRUDRepository<TEntity, TEntityDto, int>
        where TEntity : Entity<int>
        where TEntityDto : EntityDto<int>
    {
        public AsyncCRUDRepository(ShoppingCartDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }

    public class AsyncCRUDRepository<TEntity, TEntityDto, TPrimaryKey> : IAsyncCRUDRepository<TEntityDto, TPrimaryKey>
        where TEntity : Entity<TPrimaryKey>
        where TEntityDto : EntityDto<TPrimaryKey>
    {
        protected readonly IMapper Mapper;

        private readonly ShoppingCartDbContext _shoppingCartDbContext;
        private readonly DbSet<TEntity> _dbSet;

        public AsyncCRUDRepository(ShoppingCartDbContext shoppingCartDbContext, IMapper mapper)
        {
            _shoppingCartDbContext = shoppingCartDbContext;
            Mapper = mapper;
            _dbSet = shoppingCartDbContext.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> AsQueryable()
        {
            return _dbSet;
        }

        public async Task<TEntityDto> GetAsync(TPrimaryKey id)
        {
            var entity = await _dbSet.FindAsync(id);
            return Mapper.Map<TEntityDto>(entity);
        }

        public virtual async Task InsertAsync(TEntityDto entityDto)
        {
            if (entityDto == null)
            {
                throw new ArgumentNullException($"{nameof(entityDto)} can not be null");
            }

            var entity = Mapper.Map<TEntity>(entityDto);

            await _dbSet.AddAsync(entity);
            await _shoppingCartDbContext.SaveChangesAsync();
        }

        public virtual async Task Update(TEntityDto entityDto)
        {
            if (entityDto == null)
            {
                throw new ArgumentNullException($"{nameof(entityDto)} can not be null");
            }

            var entity = await _dbSet.FindAsync(entityDto.Id);

            Mapper.Map(entityDto, entity);

            await _shoppingCartDbContext.SaveChangesAsync();
        }

        public virtual async Task Delete(TPrimaryKey id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);

            await _shoppingCartDbContext.SaveChangesAsync();
        }

        public virtual void Dispose()
        {
            _shoppingCartDbContext.Dispose();
        }
    }
}
