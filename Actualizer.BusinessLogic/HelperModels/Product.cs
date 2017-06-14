using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actualizer.BusinessLogic.HelperModels
{
    public class Product
    {
        public String Title { get; set; }
        public String Link { get; set; }
        public String ImageLink { get; set; }
        public String Price { get; set; }
        public String ShopId { get; set; }
        public String ShopName { get; set; }
        public String Rating { get; set; }
        public String SKU { get; set; }
        public String Description { get; set; }
        public String DescriptionHtml { get; set; }
    }
}
