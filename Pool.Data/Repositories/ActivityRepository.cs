using Pool.Core.models;
using Pool.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pool.Data.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly DataContext _context;

        public ActivityRepository(DataContext context)
        {
            _context = context;
        }
        public List<Activity> GetList()
        {
            return _context.activities;
        }


    }
}
