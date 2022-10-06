using eShop.Web.Models;
using eShop.Web.Services.IServices;
using eShop.Web.Utils;

namespace eShop.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/product";

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ProductModel>> GetAllProducts()
        {
            var response = await _client.GetAsync(BasePath);
            var productsModel = await response.ReadContentAs<List<ProductModel>>();

            return productsModel;
        }

        public async Task<ProductModel> GetProductById(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            var productModel = await response.ReadContentAs<ProductModel>();

            return productModel;
        }

        public async Task<ProductModel> CreateProduct(ProductModel model)
        {
            var response = await _client.PostAsJson(BasePath, model);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Something went wrong calling the API");
            
            var productModel = await response.ReadContentAs<ProductModel>();

            return productModel;
        }

        public async Task<ProductModel> UpdateProduct(ProductModel model)
        {
            var response = await _client.PutAsJson(BasePath, model);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Something went wrong calling the API");

            var productModel = await response.ReadContentAs<ProductModel>();

            return productModel;
        }

        public async Task<bool> DeleteProductById(long id)
        {
            var response = await _client.DeleteAsync($"{BasePath}/{id}");

            if (!response.IsSuccessStatusCode)
                throw new Exception("Something went wrong calling the API");

            var status = await response.ReadContentAs<bool>();

            return status;
        }
    }
}
