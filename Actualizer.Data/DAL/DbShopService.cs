using Actualizer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actualizer.Data.DAL
{
    public class DbShopService
    {
        public void Add(Shop shop)
        {
            using (ActualizerContext context = new ActualizerContext())
            {
                context.Shops.Add(shop);
                context.SaveChanges();
            }
        }

        public void AddOrUpdate(Shop shop)
        {
            using (ActualizerContext context = new ActualizerContext())
            {
                if (context.Shops.Where(s => s.PromId == shop.PromId).FirstOrDefault() != null)
                {
                    context.Entry(shop).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    context.Shops.Add(shop);
                }

                context.SaveChanges();
            }
        }

        public void Update(Shop shop)
        {
            using (ActualizerContext context = new ActualizerContext())
            {
                context.Entry(shop).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public Shop Get(Int64 id)
        {
            using (ActualizerContext context = new ActualizerContext())
            {
                return context.Shops.Where(s => s.PromId == id).FirstOrDefault();
            }
        }
    }
}
