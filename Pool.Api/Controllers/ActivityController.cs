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

        private readonly IActivityService _activityService;
        public ActivityController(IActivityService activityService)
        {
           _activityService = activityService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_activityService.GetAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult Get(int id)
        {
            return Ok(_activityService.GetById(id));
        }

        [HttpGet("{byDay}")]
        public ActionResult Get(Day activityDay)
        {
            return Ok(_activityService.GetActivitiesByDay(activityDay));
        }
        [HttpPost]
        public void Post([FromBody] Activity activity)
        {
            _activityService.Post(activity);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Activity activity)
        {
            _activityService.Put(id, activity);
        }

        [HttpPut("{id}/status")]
        public void Put(int id, bool status)
        {
            _activityService.PutStatus(id, status); 
        }

    }
}
