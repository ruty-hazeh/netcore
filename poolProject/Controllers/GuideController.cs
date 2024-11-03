using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace poolProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuideController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Guide>> Get()
        {
            return Ok(Data.guides);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Guide> Get(int id)
        {
            Guide guide= Data.guides.SingleOrDefault(g => g.Id == id);
            if(guide == null)
                return NotFound("Guide not found");
            return Ok(guide);
        }

        [HttpGet("activity/{activityName}")]
        public ActionResult<List<Guide>> Get(string activityName)
        {
            return Data.guides.Where(g => g.ActivityName.Equals(activityName)).ToList();
        }
        [HttpPost]
        public void Post([FromBody] Guide g)
        {
            g.Id = ++Data.GuideCount;
            Data.guides.Add(g);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Guide g)
        {
            Guide guide = Data.guides.SingleOrDefault(gu => gu.Id == id);
            guide.Name = g.Name;
            guide.Age = g.Age;
            guide.GenderGuide = g.GenderGuide;
            guide.ActivityName = g.ActivityName;
        }

        [HttpPut("{id}/status")]
        public void Put(int id, bool status)
        {
            Data.guides.SingleOrDefault(g => g.Id == id).Status = status;
        }
    }
}

