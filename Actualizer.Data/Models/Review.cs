using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actualizer.Data.Models
{
    public class Review
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 ID { get; set; }
        public Int64 UserID { get; set; }
        public Int64 ShopID { get; set; }
        public Int32 Mark { get; set; }
        public String ReviewText { get; set; }
        public virtual User User { get; set; }
        public virtual Shop Shop { get; set; }
    }
}
