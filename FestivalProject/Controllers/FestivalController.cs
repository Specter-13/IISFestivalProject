using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FestivalProject.BL.Facade;
using FestivalProject.BL.Models.FestivalDto;
using FestivalProject.BL.Models.InterpretDto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FestivalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    public class FestivalController : Controller
    {
        private readonly FestivalFacade _facade;

        public FestivalController(FestivalFacade facade)
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
            return Ok(_facade.GetById(id));
            


        }


        [HttpPost]
        public IActionResult Create([FromBody] FestivalDetailDto item)
        {
            var returnedItem = _facade.Create(item);
            if (returnedItem == null)
                return BadRequest();

            return Ok(returnedItem);


        }

        [HttpPut]
        public IActionResult Update([FromBody] FestivalDetailDto item)
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
    }
}
