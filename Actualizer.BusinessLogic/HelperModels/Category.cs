using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actualizer.BusinessLogic.HelperModels
{
    public class Category
    {
        public String Name { get; set; }
        public String Link { get; set; }
        public List<Purpose> Purposes { get; set; }
    }
}
