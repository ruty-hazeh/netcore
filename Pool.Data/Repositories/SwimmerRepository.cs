using Pool.Core.models;
using Pool.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pool.Data.Repositories
{
    public class SwimmerRepository: ISwimmerRepository
    {
        private readonly DataContext _context;

        public SwimmerRepository(DataContext context)
        {
            _context = context;
        }
        public List<Swimmer> GetList()
        {
            return _context.swimmers;
        }

    }
}
