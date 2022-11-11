using AutoMapper;
using eShop.CouponAPI.Data.ValueObjects;
using eShop.CouponAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace eShop.CouponAPI.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly MySqlContext _context;
        private IMapper _mapper;

        public CouponRepository(MySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CouponVO> GetCouponByCuponCode(string couponCode)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.CouponCode == couponCode);

            return _mapper.Map<CouponVO>(coupon);
        }

    }
}
