using Pool.Core.Repositories;
using Pool.Core.models;
using Pool.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pool.Core.Services;

namespace Pool.Service
{
    public class ActivityService:IActivityService
    {
        //private static int ActivityCount = 0;

        private readonly IActivityRepository _activityRepository;
        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;   
        }

        public List<Activity> GetAll()
        {
            return _activityRepository.GetAll();
        }
        public Activity GetById(int id)
        {
            return _activityRepository.GetById(id);
        }
        public List<Activity> GetActivitiesByDay(Day activityDay)
        {
            return _activityRepository.GetActivitiesByDay(activityDay);
        }
        public void Post(Activity activity)
        { 
            //activity.Id = ++ActivityCount;
            _activityRepository.Post(activity);
        }
        public void Put(int id, Activity activity)
        {
            _activityRepository.Put(id, activity);
        }
        public void PutStatus(int id, bool status)
        {
            _activityRepository.PutStatus(id, status);
        }




    }
}
