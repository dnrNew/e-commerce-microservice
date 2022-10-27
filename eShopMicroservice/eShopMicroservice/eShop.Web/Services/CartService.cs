using eShop.Web.Models;
using eShop.Web.Services.IServices;
using eShop.Web.Utils;
using System.Net.Http.Headers;

namespace eShop.Web.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/cart";

        public CartService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<CartViewModel> GetCartByUserId(string userId, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/find-cart/{userId}");
            var cartModel = await response.ReadContentAs<CartViewModel>();

            return cartModel;
        }

        public async Task<CartViewModel> AddItemToCart(CartViewModel cart, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PostAsJson($"{BasePath}/add-cart", cart);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Something went wrong calling the API");

            var cartModel = await response.ReadContentAs<CartViewModel>();

            return cartModel;
        }

        public async Task<CartViewModel> UpdateCart(CartViewModel cart, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PutAsJson($"{BasePath}/update-cart", cart);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Something went wrong calling the API");

            var cartModel = await response.ReadContentAs<CartViewModel>();

            return cartModel;
        }

        public async Task<bool> RemoveFromCart(long cartId, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.DeleteAsync($"{BasePath}/remove-cart/{cartId}");

            if (!response.IsSuccessStatusCode)
                throw new Exception("Something went wrong calling the API");

            var status = await response.ReadContentAs<bool>();

            return status;
        }

        public async Task<bool> ApplyCoupon(CartViewModel cart, string couponCode, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveCoupon(string userId, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ClearCart(string userId, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<CartViewModel> Checkout(CartHeaderViewModel cartHeader, string token)
        {
            throw new NotImplementedException();
        }
    }
}
