using DemoAPI.Models;
using DemoAPI.Services.Product;
using Microsoft.AspNetCore.Mvc;
using Products;

namespace DemoAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductRequest request)
        {
            var product = new ProductClass(
                Guid.NewGuid(),
                request.product_name,
                request.product_description,
                request.product_image,
                request.product_price,
                request.product_quantity,
                DateTime.Today
                );

            _productService.CreateProduct(product );

            var response =new ProductResponse(
                product.Id,
                product.product_name,
                product.product_description,
                product.product_image,
                product.product_price,
                product.product_quantity,
                product.added_date
                );
            return CreatedAtAction(
                actionName: nameof(GetProduct), 
                routeValues: new {id=product.Id}, 
                value: response
                );
        }

        [HttpGet("{id:Guid}")]
        public IActionResult GetProduct(Guid id)
        {
            ProductClass product = _productService.GetProduct(id);
            if(product==null)
            {
                return NotFound();
            }
            var response = new ProductResponse(
                product.Id,
                product.product_name,
                product.product_description,
                product.product_image,
                product.product_price,
                product.product_quantity,
                product.added_date
                );
            return Ok(response);
        }
        [HttpPut("{id:Guid}")]
        public IActionResult UpsertProduct(Guid id,UpsertProduct request)
        {
            var product = new ProductClass(
                id,
                request.product_name,
                request.product_description,
                request.product_image,
                request.product_price,
                request.product_quantity,
                DateTime.Today
                );

            var upsertedResult = _productService.Upsert(product);
            if (upsertedResult.IsNewlyCreated)
            {
                var response = new ProductResponse(
                product.Id,
                product.product_name,
                product.product_description,
                product.product_image,
                product.product_price,
                product.product_quantity,
                product.added_date
                );
                return Ok(response);
            }

            return NoContent();
        }
        [HttpDelete("{id:Guid}")]
        public IActionResult DeleteProduct(Guid id)
        {
            _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
