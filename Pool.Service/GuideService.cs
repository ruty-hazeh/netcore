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
    public class GuideService : IGuideService
    {

        //private readonly IGuideRepository _guideRepository;
        private readonly IRepositoryManager _repositoryManager;

        public GuideService(IGuideRepository guideRepository, IRepositoryManager repositoryManager)
        {
            //_guideRepository = guideRepository;
            _repositoryManager = repositoryManager;
        }

        public List<Guide> GetAll()
        {
            return _repositoryManager.Guides.GetAll();
        }

        public Guide GetById(int id)
        {
            return _repositoryManager.Guides.GetById(id);
        }
        public List<Activity> GetGuideActivities(string name)
        {
            return _repositoryManager.Guides.GetGuideActivities(name);
        }
        public void Post(Guide guide)
        {
            //guide.Id = ++GuideCount;
            _repositoryManager.Guides.Post(guide);
            _repositoryManager.Save();
        }
        public void Put(int id, Guide guide)
        {
            _repositoryManager.Guides.Put(id, guide);
            _repositoryManager.Save();

        }
        public void PutStatus(int id, bool status)
        {
            _repositoryManager.Guides.PutStatus(id, status);
            _repositoryManager.Save();

        }

    }
}
