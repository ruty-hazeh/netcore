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
        //private static int GuideCount = 0;

        private readonly IGuideRepository _guideRepository;
        public GuideService(IGuideRepository guideRepository)
        {
            _guideRepository = guideRepository;
        }

        public List<Guide> GetAll()
        {
            return _guideRepository.GetAll();
        }

        public Guide GetById(int id)
        {
            return _guideRepository.GetById(id);
        }
        public List<Guide> GetGuidesByActivity(string activityName)
        {
            return _guideRepository.GetGuidesByActivity(activityName);
        }
        public void Post(Guide guide)
        {
            //guide.Id = ++GuideCount;
            _guideRepository.Post(guide);
        }
        public void Put(int id, Guide guide)
        {
            _guideRepository.Put(id, guide);
        }
        public void PutStatus(int id, bool status)
        {
            _guideRepository.PutStatus(id, status);
        }

    }
}
