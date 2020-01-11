using AutoMapper;
using ShoppingCart.Shared.Coupons;

namespace ShoppingCart.EntityFrameworkCore.Coupons
{
    public class CouponRepository : AsyncCRUDRepository<Coupon, CouponDto>, ICouponRepository
    {
        public CouponRepository(ShoppingCartDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
