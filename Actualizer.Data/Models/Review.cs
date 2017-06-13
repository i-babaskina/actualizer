using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actualizer.Data.Models
{
    public class Review
    {
        public Int64 UserID { get; set; }
        public Int64 ShopID { get; set; }
        public Int32 Mark { get; set; }
        public String ReviewText { get; set; }
    }
}
