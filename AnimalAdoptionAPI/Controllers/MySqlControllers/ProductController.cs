using Microsoft.AspNetCore.Mvc;
using AnimalAdoptionAPI.Models;
using AnimalAdoptionAPI.Interfaces;


namespace AnimalAdoptionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MySQLaController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public MySQLaController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet("Products")]
        public IActionResult GetAllProducts()
        {
            var product = _productsService.GetAllProducts();
            return Ok(product);
        }

        [HttpPost("Products")]
        public IActionResult AddProduct([FromBody] AddProductsDto productDto)
        {
            var newProduct = _productsService.AddProduct(productDto);
            return CreatedAtAction(nameof(GetProductById), new { id = newProduct.id }, newProduct);
        }

        [HttpGet("Products/{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productsService.GetProductById(id);
            if (product == null)
            {
                return NotFound("No Product with id " + id);
            }
            return Ok(product);
        }

        [HttpPut("Products/{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] UpdateProductsDto updateProduct)
        {
            var updatedProduct = _productsService.UpdateProductById(id, updateProduct);

            if (updatedProduct == null)
            {
                return NotFound();
            }

            return Ok(updatedProduct);
        }


        [HttpDelete("Product/{id}")]
        public IActionResult DeleteProduct(int id)
        {

            var isDeleted = _productsService.DeleteProductById(id);

            if (isDeleted)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
