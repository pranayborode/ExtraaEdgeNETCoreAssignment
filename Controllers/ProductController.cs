using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileStoreManager.Entities;
using MobileStoreManager.Services.Interfaces;

namespace MobileStoreManager.Controllers
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


        [HttpPost]
        [Route("AddProduct")]
        public IActionResult AddProduct([FromBody] Product product)
        {
            try
            {
                int result = _productService.AddProduct(product);

                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }


        [HttpPut]
        [Route("UpdateProduct")]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            try
            {
                int result = _productService.UpdateProduct(product);

                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("BulkAddProductsAsync")]
        public async Task<IActionResult> BulkAddProductsAsync([FromBody] List<Product> productsList)
        {
            try
            {
                await _productService.BulkAddProductsAsync(productsList);

                return StatusCode(StatusCodes.Status200OK);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


        [HttpPut]
        [Route("BulkUpdateProductsAsync")]
        public async Task<IActionResult> BulkUpdateProductsAsync([FromBody] List<Product> productsList)
        {
            try
            {
                await _productService.BulkUpdateProductsAsync(productsList);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            try
            {
                return new ObjectResult(_productService.GetAllProducts());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("GetProductById/{productId}")]
        public IActionResult GetProductById(int productId)
        {
            try
            {
                return new ObjectResult(_productService.GetProductById(productId));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex);
            }
        }

        [HttpDelete]
        [Route("DeleteProduct/{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            try
            {
                int result = _productService.DeleteProduct(productId);

                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }
    }
}
