using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System;
using Pool.Core.Services;
using Pool.Core.models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuideController : ControllerBase
    {

        private readonly IGuideService _context;
        public GuideController(IGuideService context)
        {
            _context = context;
        }
        public static int GuideCount { get; set; }


        [HttpGet]
        public IEnumerable<Guide> Get()
        {
            return _context.GetALL();
        }

        [HttpGet("{id:int}")]
        public ActionResult Get(int id)
        {
            Guide guide = _context.GetALL().SingleOrDefault(g => g.Id == id);
            if (guide == null)
                return NotFound("Guide not found");
            return Ok(guide);
        }

        [HttpGet("activity/{activityName}")]
        public ActionResult<List<Guide>> Get(string activityName)
        {
            return _context.GetALL().Where(g => g.ActivityName.Equals(activityName)).ToList();
        }
        [HttpPost]
        public void Post([FromBody] Guide g)
        {
            g.Id = ++GuideCount;
            _context.GetALL().Add(g);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Guide g)
        {
            Guide guide = _context.GetALL().SingleOrDefault(gu => gu.Id == id);
            guide.Name = g.Name;
            guide.Age = g.Age;
            guide.GenderGuide = g.GenderGuide;
            guide.ActivityName = g.ActivityName;
        }

        [HttpPut("{id}/status")]
        public void Put(int id, bool status)
        {
            _context.GetALL().SingleOrDefault(g => g.Id == id).Status = status;
        }
    }
}

