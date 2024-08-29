using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileStoreManager.Entities;
using MobileStoreManager.Services;
using MobileStoreManager.Services.Interfaces;

namespace MobileStoreManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("AddOrder")]
        public IActionResult AddOrder([FromBody] Order order)
        {
            try
            {
                int result = _orderService.AddOrder(order);

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
        [Route("UpdateOrder")]
        public IActionResult UpdateOrder([FromBody] Order order)
        {
            try
            {
                int result = _orderService.UpdateOrder(order);

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
        [Route("BulkAddOrdersAsync")]
        public async Task<IActionResult> BulkAddOrdersAsync([FromBody] List<Order> orderList)
        {
            try
            {
                await _orderService.BulkAddOrdersAsync(orderList);

                return StatusCode(StatusCodes.Status200OK);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


        [HttpPut]
        [Route("BulkUpdateOrdersAsync")]
        public async Task<IActionResult> BulkUpdateOrdersAsync([FromBody] List<Order> orderList)
        {
            try
            {
                await _orderService.BulkUpdateOrdersAsync(orderList);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("GetAllOrders")]
        public IActionResult GetAllOrders()
        {
            try
            {
                var order = _orderService.GetAllOrders();
                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("GetOrderById/{orderId}")]
        public IActionResult GetOrderById(int orderId)
        {
            try
            {
                return new ObjectResult(_orderService.GetOrderById(orderId));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex);
            }
        }

        [HttpDelete]
        [Route("DeleteOrder/{orderId}")]
        public IActionResult DeleteOrder(int orderId)
        {
            try
            {
                int result = _orderService.DeleteOrder(orderId);

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
