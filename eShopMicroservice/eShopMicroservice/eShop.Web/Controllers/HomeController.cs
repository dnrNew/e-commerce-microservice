using eShop.Web.Models;
using eShop.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public HomeController(ILogger<HomeController> logger, IProductService productService, ICartService cartService)
        {
            _logger = logger;
            _productService = productService;
            _cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            var productsModel = await _productService.GetAllProducts("");

            return View(productsModel);
        }

        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var productModel = await _productService.GetProductById(id, token);

            return View(productModel);
        }

        [HttpPost]
        [ActionName("Details")]
        [Authorize]
        public async Task<IActionResult> DetailsPost(ProductViewModel productModel)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
         
            CartViewModel cart = new()
            {
                CartHeader = new CartHeaderViewModel()
                {
                    UserId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value
                }
            };

            CartDetailViewModel cartDetail = new CartDetailViewModel()
            {
                Count = productModel.Count,
                ProductId = productModel.Id,
                Product = await _productService.GetProductById(productModel.Id, token)
            };

            List<CartDetailViewModel> cartDetails = new List<CartDetailViewModel>();
            cartDetails.Add(cartDetail);
            cart.CartDetails = cartDetails;

            var response = await _cartService.AddItemToCart(cart, token);

            if (response != null)
                return RedirectToAction(nameof(Index));

            return View(productModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public async Task<IActionResult> Login()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var login = RedirectToAction(nameof(Index));

            return login;
        }

        public IActionResult Logout()
        {
            var logout = SignOut("Cookies", "oidc");

            return logout;
        }
    }
}