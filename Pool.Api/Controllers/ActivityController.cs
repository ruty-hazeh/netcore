using Microsoft.AspNetCore.Mvc;
using System;
using Pool.Core;
using Pool.Core.models;
using Pool.Service;
using Pool.Core.Services;
using AutoMapper;
using Pool.Core.Dtos;

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

        [HttpGet("{activityDay}")]
        public ActionResult Get(Day activityDay)
        {
            return Ok(_activityService.GetActivitiesByDay(activityDay));
        }
        [HttpPost]
        public ActionResult Post([FromBody] ActivityPostDTO activity)
        {
            Activity newActivity=_activityService.Post(activity);
           return Ok(newActivity);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ActivityPutDTO activity)
        {

            Activity updateActivity = _activityService.Put(id, activity);
            if (updateActivity == null)
            {
                return NotFound(); 
            }
            return Ok(updateActivity);

        }

        [HttpPut("{id}/status")]
        public ActionResult Put(int id, bool status)
        {
           Activity updateActivity= _activityService.PutStatus(id, status);
            if (updateActivity == null)
            {
                return NotFound();  
            }
            return Ok(updateActivity);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            _activityService.Delete(id);
        }
    }
}
