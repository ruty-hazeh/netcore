using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System;
using library.classes_enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace poolProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IDataContext _context;
        public ActivityController(IDataContext context)
        {
            _context = context;
        }

        public static int ActivityCount { get; set; }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_context.activities);
        }

        [HttpGet("{id:int}")]
        public ActionResult Get(int id)
        {
            Activity activity = _context.activities.FirstOrDefault(a => a.Id == id);
            if (activity == null)
                return NotFound("Activity not found");
            return Ok(activity);
        }

        [HttpGet("guide/{guideName}")]
        public ActionResult Get(string guideName)
        {
            Guide gui = _context.guides.FirstOrDefault(g => g.Name.Equals(guideName));
            if (gui == null)
            {
                return NotFound("not found this guide");
            }
            return Ok(_context.activities.Where(a => a.GuideId == gui.Id).ToList());
        }

        [HttpPost]
        public void Post([FromBody] Activity a)
        {
            a.Id = ++ActivityCount;
            _context.activities.Add(a);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Activity a)
        {
            Activity activity = _context.activities.SingleOrDefault(act => act.Id == id);
            activity.Name = a.Name;
            activity.BeginHour = new TimeSpan(a.BeginHour.Hours,a.BeginHour.Minutes,a.BeginHour.Seconds);
            activity.EndHour = new TimeSpan(a.EndHour.Hours, a.EndHour.Minutes, a.EndHour.Seconds);
            activity.ActivityDay = a.ActivityDay;
            activity.GuideId = a.GuideId;
        }

        [HttpPut("{id}/status")]
        public void Put(int id, bool status)
        {
            _context.activities.SingleOrDefault(a => a.Id == id).Status = status;
        }

    }
}
