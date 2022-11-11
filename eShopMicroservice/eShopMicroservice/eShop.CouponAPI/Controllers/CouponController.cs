using eShop.CouponAPI.Data.ValueObjects;
using eShop.CouponAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace eShop.CouponAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CouponController : ControllerBase
    {
        private ICouponRepository _couponRepository;

        public CouponController(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository ?? throw new ArgumentNullException(nameof(couponRepository));
        }

        [HttpGet("{couponCode}")]
        public async Task<ActionResult<CouponVO>> GetCouponByCuponCode(string couponCode)
        {
            var coupon = await _couponRepository.GetCouponByCuponCode(couponCode);

            if (coupon == null)
                return NotFound();

            return Ok(coupon);
        }
    }
}