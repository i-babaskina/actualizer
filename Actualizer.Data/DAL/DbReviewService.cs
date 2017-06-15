using Actualizer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actualizer.Data.DAL
{
    public class DbReviewService
    {
        public void Add(Review review)
        {
            using (ActualizerContext context = new ActualizerContext())
            {
                context.Reviews.Add(review);
                context.SaveChanges();
            }
        }

        public List<Review> GetReviewsByUserId(Int64 userId)
        {
            using (ActualizerContext context = new ActualizerContext())
            {
                return context.Reviews.Where(r => r.UserID == userId).ToList();
            }
        }
        public List<Review> GetReviewsByShopId(Int64 shopId)
        {
            using (ActualizerContext context = new ActualizerContext())
            {
                return context.Reviews.Where(r => r.ShopID == shopId).ToList();
            }
        }
    }
}
