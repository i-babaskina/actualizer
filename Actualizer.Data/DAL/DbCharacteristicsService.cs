using Actualizer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actualizer.Data.DAL
{
    public class DbCharacteristicsService
    {
        public void Add(Characteristics characteristics)
        {
            using (ActualizerContext context = new ActualizerContext())
            {
                context.Characteristics.Add(characteristics);
                context.SaveChanges();
            }
        }

        public Characteristics GetByShopId(Int64 shopId)
        {
            using (ActualizerContext context = new ActualizerContext())
            {
                return context.Characteristics.Where(c => c.ShopId == shopId).FirstOrDefault();
            }
        }
    }
}
