using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileStoreManager.Entities;
using MobileStoreManager.Services.Interfaces;

namespace MobileStoreManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }


        [HttpPost]
        [Route("AddBrand")]
        
        public IActionResult AddBrand([FromBody] Brands brands)
        {
            try
            {
                int result = _brandService.AddBrand(brands);

                if(result >= 1)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }

        [HttpPut]
        [Route("UpdateBrand")]
        public IActionResult UpdateBrand([FromBody] Brands brands)
        {
            try
            {
                int result = _brandService.UpdateBrand(brands);

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

        [Authorize(Roles = "1,2")]
        [HttpGet]
        [Route("GetAllBrands")]
        public IActionResult GetAllBrands()
        {
            try
            {
                return new ObjectResult(_brandService.GetAllBrands());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }

        [HttpDelete]
        [Route("DeleteBrand/{brandId}")]
        public IActionResult DeleteBrand(int brandId)
        {
            try
            {
                int result = _brandService.DeleteBrand(brandId);

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
