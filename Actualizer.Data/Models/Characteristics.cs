using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actualizer.Data.Models
{
    public class Characteristics
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 ID { get; set; }
        public Int64 ShopId { get; set; }
        public Double  AverageRating { get; set; }
        public Double Availability  { get; set; }
        public Double Actuality  { get; set; }
        public Double Description  { get; set; }
        public Double  ShippingTime { get; set; }
        public Double PositiveReviews  { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
