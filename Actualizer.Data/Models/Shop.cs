using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actualizer.Data.Models
{
    public class Shop
    {
        public Int64 Id { get; set; }
        public Int64 PromId { get; set; }
        public String Title { get; set; }
        public String ShopLink { get; set; }
        public String Address { get; set; }
        public String PhoneNumber { get; set; }
        public Characteristics Characteristics { get; set; }

        public virtual List<Review> Reviews { get; set; }
        public virtual List<Bookmark> Bookmarks { get; set; }
    }
}
