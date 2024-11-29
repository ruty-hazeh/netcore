using Pool.Core.models;
using Pool.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pool.Data.Repositories
{
    public class GuideRepository: IGuideRepository
    {

        private readonly DataContext _context;

        public GuideRepository(DataContext context)
        {
            _context = context;
        }
        public List<Guide> GetList()
        {
            return _context.guides;
        }

    }
}
