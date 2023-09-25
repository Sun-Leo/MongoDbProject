using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Api.DTOS.Product;
using MongoDbProject.Api.Services.Product;

namespace MongoDbProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
       private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetListProduct()
        {
            var value= await _productService.GetAllProducts();
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProduct(createProductDto);
            return Ok("Ürün Eklendi");
                
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProduct(id);
            return Ok("Ürün Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProduct(updateProductDto);
            return Ok("Güncelleme Yapıldı");
        }
    }
}
