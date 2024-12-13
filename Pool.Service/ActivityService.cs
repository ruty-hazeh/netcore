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

        //private readonly IActivityRepository _activityRepository;
        private readonly IRepositoryManager _repositoryManager;

        public ActivityService(IActivityRepository activityRepository, IRepositoryManager repositoryManager)
        {
            //_activityRepository = activityRepository;   
            _repositoryManager = repositoryManager;
        }

        public List<Activity> GetAll()
        {
            return _repositoryManager.Activities.GetAll();
        }
        public Activity GetById(int id)
        {
            return _repositoryManager.Activities.GetById(id);
            
        }
        public List<Activity> GetActivitiesByDay(Day activityDay)
        {
            return _repositoryManager.Activities.GetActivitiesByDay(activityDay);
        }
        public void Post(Activity activity)
        { 
            //activity.Id = ++ActivityCount;
            _repositoryManager.Activities.Post(activity);
            _repositoryManager.Save();
        }
        public void Put(int id, Activity activity)
        {
            _repositoryManager.Activities.Put(id, activity);
            _repositoryManager.Save(); 
        }
        public void PutStatus(int id, bool status)
        {
            _repositoryManager.Activities.PutStatus(id, status);
            _repositoryManager.Save();

        }
        public void Delete(int id)
        {
            _repositoryManager.Activities.Delete(id);
            _repositoryManager.Save();

        }




    }
}
