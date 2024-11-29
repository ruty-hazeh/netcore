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

        private readonly ISwimmerService _context;
        public SwimmerController(ISwimmerService context)
        {
            _context = context;
        }

        public static int SwimmerCount { get; set; }
        [HttpGet]
        public IEnumerable<Swimmer> Get()
        {
            return _context.GetALL();
        }
        [HttpGet("{id:int}")]
        public ActionResult Get(int id)
        {
            Swimmer swimmer = _context.GetALL().SingleOrDefault(s => s.Id == id);
            if (swimmer == null)
                return NotFound("Swimmer not found");
            return Ok(swimmer);
        }

        //[HttpGet("activity/{activityName}")]
        //public ActionResult Get(string activityName)
        //{
        //    Activity act = _context.activities.FirstOrDefault(a => a.Name.Equals(activityName));
        //    if (act == null)
        //    {
        //        return NotFound("not fount this activity");
        //    }
        //    return Ok(_context.GetALL().Where(a => a.ActivityId == act.Id).ToList());
        //}

        [HttpPost]
        public void Post([FromBody] Swimmer s)
        {
            s.Id = ++SwimmerCount;
            _context.GetALL().Add(s);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Swimmer s)
        {
            Swimmer swimmer = _context.GetALL().SingleOrDefault(sw => sw.Id == id);
            swimmer.Name = s.Name;
            swimmer.Age = s.Age;
            swimmer.GenderSwimmer = s.GenderSwimmer;
            swimmer.ActivityId = s.ActivityId;
        }

        [HttpPut("{id}/status")]
        public void Put(int id, bool status)
        {
            _context.GetALL().SingleOrDefault(s => s.Id == id).Status = status;
        }

    }
}
