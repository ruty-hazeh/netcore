using Microsoft.AspNetCore.Mvc;
using System;
using Pool.Core;
using Pool.Core.models;
using Pool.Service;
using Pool.Core.Services;
using Pool.Core.Dtos;
using System.Diagnostics;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwimmerController : ControllerBase
    {

        private readonly ISwimmerService _swimmerService;
        public SwimmerController(ISwimmerService swimmerService)
        {
           _swimmerService = swimmerService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_swimmerService.GetAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult Get(int id)
        {
            return Ok(_swimmerService.GetById(id));
        }

        [HttpGet("{genderSwimmer}")]
        public ActionResult Get(Gender genderSwimmer)
        {
            return Ok(_swimmerService.GetSwimmersByGender(genderSwimmer));
        }
        [HttpPost]
        public ActionResult Post([FromBody] SwimmerPostDTO swimmer)
        {
           Swimmer newSwimmer= _swimmerService.Post(swimmer);
            return Ok(newSwimmer);
        }
       
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] SwimmerPutDTO swimmer)
        {
            Swimmer updateSwimmer=_swimmerService.Put(id, swimmer);
            if (updateSwimmer == null)
            {
                return NotFound();
            }
            return Ok(updateSwimmer);
        }
            
    [HttpPut("{id}/status")]
        public ActionResult Put(int id, bool status)
        {
            Swimmer updateSwimmer = _swimmerService.PutStatus(id, status);
            if (updateSwimmer == null)
            {
                return NotFound();
            }
            return Ok(updateSwimmer);
        }

    }
}
