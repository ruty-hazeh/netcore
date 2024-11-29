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
        private readonly IGuideRepository _guideRepository;
        public GuideService(IGuideRepository guideRepository)
        {
            _guideRepository = guideRepository;
        }


        public List<Guide> GetALL()
        {
            return _guideRepository.GetList();
        }
    }
}
