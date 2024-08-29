using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileStoreManager.Services.Interfaces;

namespace MobileStoreManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesReportController : ControllerBase
    {
        private readonly ISalesReportService _salesReportService;
        public SalesReportController(ISalesReportService salesReportService)
        {
            _salesReportService = salesReportService;
        }

        [HttpGet]
        [Route("GetMonthlySalesReport")]
        public async Task<IActionResult> GetMonthlySalesReport([FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
        {
            try
            {
                
                var report = await _salesReportService.GetMonthlySalesReport(fromDate, toDate);
                return Ok(report);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }


        [HttpGet]
        [Route("GetBrandWiseSalesData")]
        public async Task<IActionResult> GetBrandWiseSalesData([FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
        {
            try
            {

                var report = await _salesReportService.GetBrandWiseSalesData(fromDate, toDate);
                return Ok(report);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("GetProfitLossReport")] 
        public async Task<IActionResult> GetProfitLossReport(
            [FromQuery] DateTime fromDate, [FromQuery] DateTime toDate,
            [FromQuery] DateTime previousFromDate, [FromQuery] DateTime previousToDate)
        {
            try
            {
                var report = await _salesReportService.GetProfitLossReportAsync(fromDate, toDate, previousFromDate, previousToDate);
                return Ok(report);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }
    }
}
