using Pool.Core.Dtos;
using Pool.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pool.Core.Services
{
    public interface IActivityService
    {
       public List<Activity> GetAll();
       public Activity GetById(int id);
       public List<Activity> GetActivitiesByDay(Day activityDay);
        public Activity Post(ActivityPostDTO activity);
       public Activity Put(int id, ActivityPutDTO activity);
       public Activity PutStatus(int id, bool status);
       public void Delete(int id);


    }
}
