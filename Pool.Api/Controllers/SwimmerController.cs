using Microsoft.AspNetCore.Mvc;
using System;
using Pool.Core;
using Pool.Core.models;
using Pool.Service;
using Pool.Core.Services;
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

        [HttpGet("{gender}")]
        public ActionResult Get(Gender genderSwimmer)
        {
            return Ok(_swimmerService.GetSwimmersByGender(genderSwimmer));
        }
        [HttpPost]
        public void Post([FromBody] Swimmer swimmer)
        {
            _swimmerService.Post(swimmer);
        }



        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Swimmer swimmer)
        {
            _swimmerService.Put(id, swimmer);
        }

        [HttpPut("{id}/status")]
        public void Put(int id, bool status)
        {
            _swimmerService.PutStatus(id, status);
        }

    }
}
