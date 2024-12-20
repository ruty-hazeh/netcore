using Pool.Core.Dtos;
using Pool.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pool.Core.Services
{
    public interface ISwimmerService
    {
        public List<Swimmer> GetAll();
        public Swimmer GetById(int id);
        public List<Swimmer> GetSwimmersByGender(Gender genderSwimmer);
        public Swimmer Post(SwimmerPostDTO swimmer);
        public Swimmer Put(int id, SwimmerPutDTO swimmer);
        public Swimmer PutStatus(int id, bool status);
    }
}
