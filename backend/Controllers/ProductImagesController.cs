using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController(IProductImageService productImageService) : ControllerBase
    {
        private readonly IProductImageService _productImageService = productImageService;

        [HttpGet]
        public async Task<IList<ProductImageDTO>> GetProductImagesAsync()
        {
            return (IList<ProductImageDTO>)await _productImageService.GetProductImagesAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImagesByProductIdAsync(int id)
        {
        var productImages = await _productImageService.GetProductImagesByProductIdAsync(id);
        return Ok(productImages);
        }

        [HttpPost]
        public async Task AddProductImageAsync([FromBody] ProductImageCreationDTO productImageDto)
        {
            await _productImageService.AddProductImageAsync(productImageDto);
        }

        [HttpDelete("{id}")]
        public async Task DeleteProductImageAsync(int id)
        {
            await _productImageService.DeleteProductImageAsync(id);
        }
    }
}
