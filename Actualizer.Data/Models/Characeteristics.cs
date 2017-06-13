using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actualizer.Data.Models
{
    public class Characeteristics
    {
        public Int64 ShopId { get; set; }
        public Double  AverageRating { get; set; }
        public Double Availability  { get; set; }
        public Double Actuality  { get; set; }
        public Double Description  { get; set; }
        public Double  ShippingTime { get; set; }
        public Double PositiveReviews  { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
