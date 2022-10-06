using eShop.Web.Models;
using eShop.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task<IActionResult> ProductIndex()
        {
            var productsModel = await _productService.GetAllProducts();

            return View(productsModel);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var productModel = await _productService.CreateProduct(model);

                if (productModel != null)
                    return RedirectToAction(nameof(ProductIndex));
            }

            return View(model);
        }

        public async Task<IActionResult> ProductUpdate(long id)
        {
            var productModel = await _productService.GetProductById(id);

            if (productModel != null)
                return View(productModel);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var productModel = await _productService.UpdateProduct(model);

                if (productModel != null)
                    return RedirectToAction(nameof(ProductIndex));
            }

            return View(model);
        }

        public async Task<IActionResult> ProductDelete(long id)
        {
            var productModel = await _productService.GetProductById(id);

            if (productModel != null)
                return View(productModel);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductModel model)
        {
            var statusModel = await _productService.DeleteProductById(model.Id);

            if (statusModel)
                return RedirectToAction(nameof(ProductIndex));

            return View(model);
        }
    }
}
