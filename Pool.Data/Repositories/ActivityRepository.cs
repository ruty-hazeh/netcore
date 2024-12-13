using Microsoft.EntityFrameworkCore;
using Pool.Core.models;
using Pool.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pool.Data.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly DataContext _context;

        public ActivityRepository(DataContext context)
        {
            _context = context;
        }
        public List<Activity> GetAll()
        {
            return _context.activities.Include(a=>a.Guide).Include(ac=>ac.ActivitySwimmers).ToList();
        }
        public Activity GetById(int id)
        {
            Activity a = _context.activities.SingleOrDefault(act => act.Id == id);
            if (a != null)
                return a;
            return null;
        }
        public List<Activity> GetActivitiesByDay(Day activityDay)
        {
            return _context.activities.Where(a => a.ActivityDay == activityDay).ToList();
        }
        public void Post(Activity activity)
        {
            _context.activities.Add(activity);

        }
        public void Put(int id, Activity activity)
        {
            Activity a = _context.activities.SingleOrDefault(act=> act.Id==id);
            if (a == null) return;
            else
            {
                a.Name = activity.Name;
                a.BeginHour = new TimeSpan(activity.BeginHour.Hours, activity.BeginHour.Minutes, activity.BeginHour.Seconds);
                a.EndHour = new TimeSpan(activity.EndHour.Hours, activity.EndHour.Minutes, activity.EndHour.Seconds);
                a.ActivityDay = activity.ActivityDay;
                a.Guide = activity.Guide;
                a.ActivitySwimmers=activity.ActivitySwimmers;
            }

        }
        public void PutStatus(int id, bool status)
        {
            Activity a = _context.activities.SingleOrDefault(act => act.Id == id);
            if (a!=null)
                a.Status=status;
        }
        public void Delete(int id)
        {
            Activity a = _context.activities.SingleOrDefault(act => act.Id == id);
            if(a!=null)
                _context.activities.Remove(a);
        }

    }
}
