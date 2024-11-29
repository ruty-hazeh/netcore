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
        private readonly IActivityRepository _activityRepository;
        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;   
        }


        public List<Activity> GetALL()
        {
            return _activityRepository.GetList();
        }
    }
}
