using Pool.Core.models;
using Pool.Core.Repositories;
using Pool.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pool.Service
{
    public class SwimmerService: ISwimmerService
    {
        private readonly ISwimmerRepository _swimmerRepository;
        public SwimmerService(ISwimmerRepository swimmerRepository)
        {
            _swimmerRepository = swimmerRepository;
        }

        public List<Swimmer> GetALL()
        {
            return _swimmerRepository.GetList();
        }

    }
}
