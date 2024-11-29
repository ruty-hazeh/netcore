using Pool.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pool.Core
{
    public interface IDataContext
    {
        List<Guide> guides { get; set; }
        List<Swimmer> swimmers { get; set; }

        List<Activity> activities { get; set; }


    }
}
