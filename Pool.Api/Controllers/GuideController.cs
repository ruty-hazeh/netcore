using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System;
using Pool.Core.Services;
using Pool.Core.models;
using Pool.Service;
using System.Diagnostics;
using System.Xml.Linq;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuideController : ControllerBase
    {

        private readonly IGuideService _guideService;
        public GuideController(IGuideService guideService)
        {
           _guideService = guideService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_guideService.GetAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult Get(int id)
        {
            return Ok(_guideService.GetById(id));
        }

        [HttpGet("guide/{name}/activities")]
        public ActionResult Get(string name)
        {
            return Ok(_guideService.GetGuideActivities(name));
        }

        [HttpPost]
        public void Post([FromBody] Guide guide)
        {
            _guideService.Post(guide);
        }

        [HttpPut("{id}")]
       
        public void Put(int id, [FromBody] Guide guide)
        {
            _guideService.Put(id, guide);
        }

        [HttpPut("{id}/status")]
        public void Put(int id, bool status)
        {
            _guideService.PutStatus(id, status);
        }

    }
}

