using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System;
using library.classes_enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace poolProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuideController : ControllerBase
    {
        public static int GuideCount { get; set; }
        private readonly IDataContext _context;
        public GuideController(IDataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_context.guides);
        }

        [HttpGet("{id:int}")]
        public ActionResult Get(int id)
        {
            Guide guide= _context.guides.SingleOrDefault(g => g.Id == id);
            if(guide == null)
                return NotFound("Guide not found");
            return Ok(guide);
        }

        [HttpGet("activity/{activityName}")]
        public ActionResult<List<Guide>> Get(string activityName)
        {
            return _context.guides.Where(g => g.ActivityName.Equals(activityName)).ToList();
        }
        [HttpPost]
        public void Post([FromBody] Guide g)
        {
            g.Id = ++GuideCount;
            _context.guides.Add(g);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Guide g)
        {
            Guide guide = _context.guides.SingleOrDefault(gu => gu.Id == id);
            guide.Name = g.Name;
            guide.Age = g.Age;
            guide.GenderGuide = g.GenderGuide;
            guide.ActivityName = g.ActivityName;
        }

        [HttpPut("{id}/status")]
        public void Put(int id, bool status)
        {
            _context.guides.SingleOrDefault(g => g.Id == id).Status = status;
        }
    }
}

