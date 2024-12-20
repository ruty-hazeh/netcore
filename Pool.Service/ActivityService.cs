using Pool.Core.Repositories;
using Pool.Core.models;
using Pool.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pool.Core.Services;
using AutoMapper;
using Pool.Core.Dtos;

namespace Pool.Service
{
    public class ActivityService : IActivityService
    {

        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;


        public ActivityService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
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
        public Activity Post(ActivityPostDTO activity)
        {
            var activityMap = _mapper.Map<Activity>(activity);
            var res = _repositoryManager.Activities.Post(activityMap);
            _repositoryManager.Save();
            return res;
        }
        public Activity Put(int id, ActivityPutDTO activity)
        {
            var activityMap = _mapper.Map<Activity>(activity);
            var res = _repositoryManager.Activities.Put(id, activityMap);
            _repositoryManager.Save();
            return res;
        }
        public Activity PutStatus(int id, bool status)
        {
            var res = _repositoryManager.Activities.PutStatus(id, status);
            _repositoryManager.Save();
            return res;
        }
        public void Delete(int id)
        {
            _repositoryManager.Activities.Delete(id);
            _repositoryManager.Save();

        }




    }
}
