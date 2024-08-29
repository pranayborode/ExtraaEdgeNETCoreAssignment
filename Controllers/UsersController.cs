using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileStoreManager.Entities;
using MobileStoreManager.Entities.DTO;
using MobileStoreManager.Services;
using MobileStoreManager.Services.Interfaces;

namespace MobileStoreManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }


        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] Users user)
        {
            try
            {
                LoginOutputDTO result = _usersService.Login(user);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser([FromBody] Users users)
        {
            try
            {
                int result = _usersService.AddUser(users);
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

        [HttpDelete]
        [Route("DeleteUser/{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            try
            {
                int result = _usersService.DeleteUser(userId);
                if (result == 1)
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
