using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace poolProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(Data.activities);
        }

        [HttpGet("{id:int}")]
        public ActionResult Get(int id)
        {
            Activity activity = Data.activities.FirstOrDefault(a => a.Id == id);
            if (activity == null)
                return NotFound("Activity not found");
            return Ok(activity);
        }

        [HttpGet("guide/{guideName}")]
        public ActionResult Get(string guideName)
        {
            Guide gui = Data.guides.FirstOrDefault(g => g.Name.Equals(guideName));
            if (gui == null)
            {
                return NotFound("not found this guide");
            }
            return Ok(Data.activities.Where(a => a.GuideId == gui.Id).ToList());
        }

        [HttpPost]
        public void Post([FromBody] Activity a)
        {
            a.Id = ++Data.ActivityCount;
            Data.activities.Add(a);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Activity a)
        {
            Activity activity = Data.activities.SingleOrDefault(act => act.Id == id);
            activity.Name = a.Name;
            activity.BeginHour = new TimeSpan(a.BeginHour.Hours,a.BeginHour.Minutes,a.BeginHour.Seconds);
            activity.EndHour = new TimeSpan(a.EndHour.Hours, a.EndHour.Minutes, a.EndHour.Seconds);
            activity.ActivityDay = a.ActivityDay;
            activity.GuideId = a.GuideId;
        }

        [HttpPut("{id}/status")]
        public void Put(int id, bool status)
        {
            Data.activities.SingleOrDefault(a => a.Id == id).Status = status;
        }

    }
}
