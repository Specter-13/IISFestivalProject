using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FestivalProject.BL.Facade;
using FestivalProject.BL.Models.InterpretDto;
using FestivalProject.BL.Models.UserDto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FestivalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    public class UserController : Controller
    {
        private readonly UserFacade _facade;

        public UserController(UserFacade facade)
        {
            _facade = facade;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(_facade.GetAll());

        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {

            var returnedItem = _facade.GetById(id);
            if (returnedItem == null) return NotFound();
            return Ok(returnedItem);

        }


        [HttpPost]
        public IActionResult Create([FromBody] UserCreateEditDto item)
        {
            var returnedItem = _facade.Create(item);
            if (returnedItem == null)
                return BadRequest();

            return Ok(returnedItem);


        }

        [HttpPut]
        public IActionResult Update([FromBody] UserCreateEditDto item)
        {
            try
            {
                return Ok(_facade.Update(item));
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            try
            {
                _facade.Delete(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpGet("authenticate/{username}/{password}")]
        public IActionResult GetLoginByUsername(string username, string password)
        {

            var returnedItem = _facade.GetByUsername(username);
            if (returnedItem == null) return NotFound("Login Not Found!");

            if (returnedItem.Password == password)
            {
                return Ok(_facade.GetById(returnedItem.Id));
            }
            
            return BadRequest("Wrong password!");
            
        }
    }
}
