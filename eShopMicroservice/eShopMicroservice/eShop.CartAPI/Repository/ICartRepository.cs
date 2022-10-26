using eShop.CartAPI.Data.ValueObjects;

namespace eShop.CartAPI.Repository
{
    public interface ICartRepository
    {
        Task<CartVO> GetCartByUserId(string userId);
        Task<CartVO> SaveOrUpdateCart(CartVO cart);
        Task<bool> RemoveFromCart(long cartDetailsId);
        Task<bool> ApplyCoupon(string userID, string couponCode);
        Task<bool> RemoveCoupon(string userID);
        Task<bool> ClearCart(string userID);

    }
}
