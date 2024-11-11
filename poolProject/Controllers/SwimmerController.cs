using library.classes_enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace poolProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwimmerController : ControllerBase
    {
        public static int SwimmerCount { get; set; }
        private readonly IDataContext _context;
        public SwimmerController(IDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_context.swimmers);
        }
        [HttpGet("{id:int}")]
        public ActionResult Get(int id)
        {
            Swimmer swimmer= _context.swimmers.SingleOrDefault(s => s.Id == id);
            if(swimmer==null)
                return NotFound("Swimmer not found");
            return Ok(swimmer);
        }

        [HttpGet("activity/{activityName}")]
        public ActionResult Get(string activityName)
        {
            Activity act = _context.activities.FirstOrDefault(a => a.Name.Equals(activityName));
            if (act == null)
            {
                return NotFound("not fount this activity");
            }
            return Ok(_context.swimmers.Where(a => a.ActivityId == act.Id).ToList());
        }

        [HttpPost]
        public void Post([FromBody] Swimmer s)
        {
            s.Id = ++SwimmerCount;
            _context.swimmers.Add(s);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Swimmer s)
        {
            Swimmer swimmer = _context.swimmers.SingleOrDefault(sw => sw.Id == id);
            swimmer.Name = s.Name;
            swimmer.Age = s.Age;
            swimmer.GenderSwimmer = s.GenderSwimmer;
            swimmer.ActivityId = s.ActivityId;
        }

        [HttpPut("{id}/status")]
        public void Put( int id,bool status)
        {
            _context.swimmers.SingleOrDefault(s => s.Id == id).Status = status;
        }

    }
}
