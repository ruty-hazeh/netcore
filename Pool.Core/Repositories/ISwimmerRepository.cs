using Pool.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pool.Core.Repositories
{
    public interface ISwimmerRepository
    {
        public List<Swimmer> GetAll();
        public Swimmer GetById(int id);
        public List<Swimmer> GetSwimmersByGender(Gender genderSwimmer);
        public void Post(Swimmer swimmer);
        public void Put(int id, Swimmer swimmer);
        public void PutStatus(int id, bool status);

    }
}
