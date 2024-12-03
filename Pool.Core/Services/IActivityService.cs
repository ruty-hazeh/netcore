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
        public void Post(Activity activity);
       public void Put(int id, Activity activity);
       public void PutStatus(int id, bool status);

    }
}
