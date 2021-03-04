
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using api_cadastro.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace api_cadastro.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private AppDbContext _context;
        public UsersController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("/[controller]")]
        public IActionResult GetUsers()
        {
            return Ok(_context.Users);
        }

        [HttpGet]
        [Route("/[controller]/{id}")]
        public IActionResult GetUser(string id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound("User not found");
        }
        [HttpPost]
        [Route("/[controller]")]
        public string AddUser(PostData dados)
        {
            _context.Users.Add(new User(dados.name, dados.age, dados.surname));
            _context.SaveChanges();
            return "user added";
        }
        [HttpDelete]
        [Route("/[controller]/{id}")]
        public void DelUser(string id)
        {
            User usertodelete = _context.Users.FirstOrDefault(x => x.Id == id);
            if (User != null)
            {
                _context.Users.Remove(usertodelete);
                _context.SaveChanges();
            }
        }
        [HttpPut]
        [Route("/[controller]/{id}")]
        public void EditUser(PostData dados, string id)
        {
            User usertoedit = _context.Users.FirstOrDefault(x => x.Id == id);
            User edited = new User(dados.name, dados.age, dados.surname)
            {
                Id = usertoedit.Id,
                CreationDate = usertoedit.CreationDate
            };
            if (usertoedit != null)
            {
                _context.Users.Remove(usertoedit);
                _context.Users.Add(edited);
                _context.SaveChanges();
            }
        }
    }
}