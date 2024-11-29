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
    public class ActivityController : ControllerBase
    {

        private readonly IActivityService _context;
        public ActivityController(IActivityService context)
        {
            _context = context;
        }

        public static int ActivityCount { get; set; }

        [HttpGet]
        public IEnumerable<Activity> Get()
        {
            return _context.GetALL();
        }

        [HttpGet("{id:int}")]
        public ActionResult Get(int id)
        {
            Activity activity = _context.GetALL().FirstOrDefault(a => a.Id == id);
            if (activity == null)
                return NotFound("Activity not found");
            return Ok(activity);
        }

        //[HttpGet("guide/{guideName}")]
        //public ActionResult Get(string guideName)
        //{
        //    Guide gui = _context.guides.FirstOrDefault(g => g.Name.Equals(guideName));
        //    if (gui == null)
        //    {
        //        return NotFound("not found this guide");
        //    }
        //    return Ok(_context.GetALL().Where(a => a.GuideId == gui.Id).ToList());
        //}

        [HttpPost]
        public void Post([FromBody] Activity a)
        {
            a.Id = ++ActivityCount;
            _context.GetALL().Add(a);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Activity a)
        {
            Activity activity = _context.GetALL().SingleOrDefault(act => act.Id == id);
            activity.Name = a.Name;
            activity.BeginHour = new TimeSpan(a.BeginHour.Hours, a.BeginHour.Minutes, a.BeginHour.Seconds);
            activity.EndHour = new TimeSpan(a.EndHour.Hours, a.EndHour.Minutes, a.EndHour.Seconds);
            activity.ActivityDay = a.ActivityDay;
            activity.GuideId = a.GuideId;
        }

        [HttpPut("{id}/status")]
        public void Put(int id, bool status)
        {
            _context.GetALL().SingleOrDefault(a => a.Id == id).Status = status;
        }

    }
}
