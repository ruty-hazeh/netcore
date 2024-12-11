using Pool.Core.models;
using Pool.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pool.Data.Repositories
{
    public class GuideRepository : IGuideRepository
    {

        private readonly DataContext _context;

        public GuideRepository(DataContext context)
        {
            _context = context;
        }
        public List<Guide> GetAll()
        {
            return _context.guides.ToList();
        }
        public Guide GetById(int id)
        {
            Guide g = _context.guides.SingleOrDefault(gui => gui.Id == id);
            if (g != null)
                return g;
            return null;
        }
        public List<Guide> GetGuidesByActivity(string activityName)
        {
            return _context.guides.Where(g => g.ActivityName == activityName).ToList();
        }
        public void Post(Guide guide)
        {
            _context.guides.Add(guide);
        }
        public void Put(int id, Guide guide)
        {
            Guide g = _context.guides.SingleOrDefault(gui => gui.Id == id);
            if (g == null) return;
            else
            {
                g.Name = guide.Name;
                g.Age = guide.Age;
                g.GenderGuide = guide.GenderGuide;
                g.ActivityName = guide.ActivityName;
            }
        }
        public void PutStatus(int id, bool status)
        {
            Guide g = _context.guides.SingleOrDefault(gui => gui.Id == id);
            if (g != null)
                g.Status = status;
        }

    }
}
