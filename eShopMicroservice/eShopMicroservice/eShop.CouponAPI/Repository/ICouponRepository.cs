using eShop.CouponAPI.Data.ValueObjects;

namespace eShop.CouponAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponVO> GetCouponByCuponCode(string couponCode);
    }
}
