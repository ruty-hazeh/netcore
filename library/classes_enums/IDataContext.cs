using poolProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.classes_enums
{
    public interface IDataContext
    {
         List<Guide> guides { get; set; }
         List<Swimmer> swimmers { get; set; }

         List<Activity> activities { get; set; }


    }
}
