using System;
using System.Threading.Tasks;
using AutoMapper;
using ShoppingCart.Shared.Coupons;
using ShoppingCart.Shared.Products;

namespace ShoppingCart.EntityFrameworkCore.Coupons
{
    public class CouponRepository : AsyncCRUDRepository<Coupon, CouponDto>, ICouponRepository
    {
        public CouponRepository(ShoppingCartDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override Task InsertAsync(CouponDto entityDto)
        {
            if (entityDto.Discount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(entityDto.Discount), $"{nameof(entityDto.Discount)} must be more than 0(zero)");
            }

            if (entityDto.MinimumAmount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(entityDto.MinimumAmount), $"{nameof(entityDto.MinimumAmount)} must be more than 0(zero)");
            }

            return base.InsertAsync(entityDto);
        }

        public override Task UpdateAsync(CouponDto entityDto)
        {
            if (entityDto.Discount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(entityDto.Discount), $"{nameof(entityDto.Discount)} must be more than 0(zero)");
            }

            if (entityDto.MinimumAmount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(entityDto.MinimumAmount), $"{nameof(entityDto.MinimumAmount)} must be more than 0(zero)");
            }

            return base.UpdateAsync(entityDto);
        }
    }
}
