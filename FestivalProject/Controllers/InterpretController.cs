using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FestivalProject.BL.Facade;
using FestivalProject.BL.Models;
using FestivalProject.BL.Models.InterpretDto;
using FestivalProject.BL.Models.StageDto;
using FestivalProject.BL.Models.StageInterpretDto;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FestivalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InterpretController : Controller
    {
        private readonly InterpretFacade _facade;

        public InterpretController(InterpretFacade facade)
        {
            _facade = facade;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_facade.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
           
                return Ok(_facade.GetById(id));
           
                //return NotFound();
            
        }


        [HttpPost]
        public IActionResult Create([FromBody]InterpretDetailDto item)
        {
            var returnedItem = _facade.Create(item);
            if(returnedItem == null)
                return BadRequest();

            return Ok(returnedItem);

            

        }
    }
}
