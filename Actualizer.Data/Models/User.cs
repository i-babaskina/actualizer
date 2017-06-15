using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actualizer.Data.Models
{
    public class User
    {
        public Int64 ID { get; set; }
        public String Login { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }

        public virtual List<Review> Reviews { get; set; }

        public virtual List<Bookmark> Bookmarks { get; set; }
    }
}
