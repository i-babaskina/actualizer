using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actualizer.BusinessLogic.HelperModels
{
    public class SearchModel
    {
        public String SearchTerm { get; set; }
        public String Url { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> Product { get; set; }
    }
}
