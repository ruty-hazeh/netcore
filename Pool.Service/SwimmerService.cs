using Pool.Core.models;
using Pool.Core.Repositories;
using Pool.Core.Services;
using Pool.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pool.Service
{
    public class SwimmerService: ISwimmerService
    {
        //private static int SwimmerCount = 0;

        private readonly ISwimmerRepository _swimmerRepository;
        public SwimmerService(ISwimmerRepository swimmerRepository)
        {
            _swimmerRepository = swimmerRepository;
        }

        public List<Swimmer> GetAll()
        {
            return _swimmerRepository.GetAll();
        }
        public Swimmer GetById(int id)
        {
            return _swimmerRepository.GetById(id);
        }
        public List<Swimmer> GetSwimmersByGender(Gender genderSwimmer)
        {
            return _swimmerRepository.GetSwimmersByGender(genderSwimmer);
        }
        public void Post(Swimmer swimmer)
        {
            //swimmer.Id = ++SwimmerCount;
            _swimmerRepository.Post(swimmer);
        }
        public void Put(int id, Swimmer swimmer)
        {
            _swimmerRepository.Put(id, swimmer);
        }
        public void PutStatus(int id, bool status)
        {
            _swimmerRepository.PutStatus(id, status);
        }

    }
}
