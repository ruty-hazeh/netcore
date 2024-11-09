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

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(Data.swimmers);
        }
        [HttpGet("{id:int}")]
        public ActionResult Get(int id)
        {
            Swimmer swimmer= Data.swimmers.SingleOrDefault(s => s.Id == id);
            if(swimmer==null)
                return NotFound("Swimmer not found");
            return Ok(swimmer);
        }

        [HttpGet("activity/{activityName}")]
        public ActionResult Get(string activityName)
        {
            Activity act = Data.activities.FirstOrDefault(a => a.Name.Equals(activityName));
            if (act == null)
            {
                return NotFound("not fount this activity");
            }
            return Ok(Data.swimmers.Where(a => a.ActivityId == act.Id).ToList());
        }

        [HttpPost]
        public void Post([FromBody] Swimmer s)
        {
            s.Id = ++Data.SwimmerCount;
            Data.swimmers.Add(s);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Swimmer s)
        {
            Swimmer swimmer = Data.swimmers.SingleOrDefault(sw => sw.Id == id);
            swimmer.Name = s.Name;
            swimmer.Age = s.Age;
            swimmer.GenderSwimmer = s.GenderSwimmer;
            swimmer.ActivityId = s.ActivityId;
        }

        [HttpPut("{id}/status")]
        public void Put( int id,bool status)
        {
            Data.swimmers.SingleOrDefault(s => s.Id == id).Status = status;
        }

    }
}
