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
    public class SwimmerRepository : ISwimmerRepository
    {
        private readonly DataContext _context;

        public SwimmerRepository(DataContext context)
        {
            _context = context;
        }

        public List<Swimmer> GetAll()
        {
            return _context.swimmers.Include(s=>s.SwimmerActivities).ToList();
        }
        public Swimmer GetById(int id)
        {
            Swimmer s = _context.swimmers.SingleOrDefault(swi => swi.Id == id);
            if (s != null)
                return s;
            return null;
        }
        public List<Swimmer> GetSwimmersByGender(Gender genderSwimmer)
        {
            return _context.swimmers.Where(s => s.GenderSwimmer == genderSwimmer).ToList();
        }
        public void Post(Swimmer swimmer)
        {
            _context.swimmers.Add(swimmer);

        }
        public void Put(int id, Swimmer swimmer)
        {
            Swimmer s = _context.swimmers.SingleOrDefault(swi => swi.Id == id);
            if (s == null) return;
            else
            {
                s.Name = swimmer.Name;
                s.Age = swimmer.Age;
                s.GenderSwimmer = swimmer.GenderSwimmer;
                s.SwimmerActivities = swimmer.SwimmerActivities;
            }

        }
        public void PutStatus(int id, bool status)
        {
            Swimmer s = _context.swimmers.SingleOrDefault(swi => swi.Id == id);
            if (s != null)
                s.Status = status;

        }
    }
}
