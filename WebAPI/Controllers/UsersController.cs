using Business.Abstract;
using Core.DataAccess.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
               return Ok(result); 
            }
            return BadRequest();
        }
        [HttpGet("getbyid")]
        public IActionResult GetbyId(int userId) 
        {
            var result = _userService.GetById(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        
        
        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        


       


    }
}
