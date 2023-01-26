using eShop.CartAPI.Data.ValueObjects;

namespace eShop.CartAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponVO> GetCoupon(string couponCode, string token);
    }
}
