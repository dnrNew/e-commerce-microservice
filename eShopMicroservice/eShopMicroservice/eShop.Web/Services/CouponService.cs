using eShop.Web.Models;
using eShop.Web.Services.IServices;
using eShop.Web.Utils;
using System.Net;
using System.Net.Http.Headers;

namespace eShop.Web.Services
{
    public class CouponService : ICouponService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/coupon";

        public CouponService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<CouponViewModel> GetCoupon(string code, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/{code}");

            if (response.StatusCode != HttpStatusCode.OK)
                return new CouponViewModel();

            var couponViewModel = await response.ReadContentAs<CouponViewModel>();

            return couponViewModel;
        }
    }
}
