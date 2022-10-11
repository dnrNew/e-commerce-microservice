using eShop.ProductAPI.Data.ValueObjects;
using eShop.ProductAPI.Repository;
using eShop.ProductAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eShop.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ProductVO>>> GetAll()
        {
            var products = await _productRepository.GetAll();

            return Ok(products);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ProductVO>> GetById(long id)
        {
            var product = await _productRepository.GetById(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ProductVO>> Create([FromBody] ProductVO vo)
        {
            if (vo == null)
                return BadRequest();

            var product = await _productRepository.Create(vo);

            return Ok(product);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<ProductVO>> Update([FromBody] ProductVO vo)
        {
            if (vo == null)
                return BadRequest();

            var product = await _productRepository.Update(vo);

            return Ok(product);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _productRepository.Delete(id);

            if (!status)
                return BadRequest();

            return Ok(status);
        }
    }
}
