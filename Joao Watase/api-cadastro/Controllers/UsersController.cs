using api_cadastro.UserData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
namespace api_cadastro.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserData _userData;
        public UsersController(IUserData userData)
        {
            _userData = userData;
        }


        [HttpGet]
        [Route("/[controller]")]
        public IActionResult GetUsers()
        {
            return Ok(_userData.GetUsers());
        }

        [HttpGet]
        [Route("/[controller]/{id}")]
        public IActionResult GetUser(string id)
        {
            var user = _userData.GetUser(id);
            if(user != null)
            {
                return Ok(_userData.GetUser(id));
            }
            return NotFound("User not found");
        }
    }
}
