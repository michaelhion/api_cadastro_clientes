using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using api_cadastro.Models;
using Microsoft.Extensions.Logging;

namespace api_cadastro.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        ILogger _logger;
        private AppDbContext _context;
        public UsersController(AppDbContext context, ILogger<UsersController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet]
        [Route("/[controller]")]
        public IActionResult GetUsers()
        {
            _logger.LogInformation("GET /Users");
            return Ok(_context.Users);
        }
        [HttpGet]
        [Route("/[controller]/{id}")]
        public IActionResult GetUser(string id)
        {
            _logger.LogInformation($"GET /Users/{id}");
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                return Ok(user);
            }
            _logger.LogInformation($"User with id '{id}' not found");
            return NotFound("User not found");
        }
        [HttpPost]
        [Route("/[controller]")]
        public IActionResult AddUser(PostData dados)
        {
            _logger.LogInformation("POST /Users");
            _context.Users.Add(new User(dados.Name, dados.Age, dados.Surname));
            _context.SaveChanges();
            _logger.LogInformation("User added");
            return Ok("User added");
        }
        [HttpDelete]
        [Route("/[controller]/{id}")]
        public IActionResult DelUser(string id)
        {
            _logger.LogInformation($"DELETE /Users/{id}");
            User usertodelete = _context.Users.FirstOrDefault(x => x.Id == id);
            if (usertodelete != null)
            {
                _context.Users.Remove(usertodelete);
                _context.SaveChanges();
                _logger.LogInformation("User deleted");
                return Ok("User deleted");
            }
            return NotFound("User not found");
        }
        [HttpPut]
        [Route("/[controller]/{id}")]
        public IActionResult EditUser(PostData dados, string id)
        {
            _logger.LogInformation($"PUT /Users/{id}");
            User usertoedit = _context.Users.FirstOrDefault(x => x.Id == id);
            User edited = new User(dados.Name, dados.Age, dados.Surname)
            {
                Id = usertoedit.Id,
                CreationDate = usertoedit.CreationDate
            };
            if (usertoedit != null)
            {
                _context.Users.Remove(usertoedit);
                _context.Users.Add(edited);
                _context.SaveChanges();
                _logger.LogInformation("Changes saved");
                return Ok("User edited");
            }
            return NotFound("User not found.");
        }
    }
}