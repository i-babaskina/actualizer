using Actualizer.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actualizer.Data.DAL
{
    public class ActualizerInitializer : DropCreateDatabaseIfModelChanges<ActualizerContext>
    {
        protected override void Seed(ActualizerContext context)
        {
            Shop shop = new Shop() { Address = "test", Id = 1, PhoneNumber = "0999379992", ShopLink = "test", Title = "" };

            Characteristics characteristisc = new Characteristics() { ShopId = 1, Shop = shop, Actuality = 25, Availability = 25, AverageRating = 25, Description = 25, PositiveReviews = 25, ShippingTime = 25, UpdateDate = DateTime.Now };

            User user = new User() { ID = 1, Email = "test@test.com", Login = "test", Password = "password" };

            Bookmark bookmark = new Bookmark() { UserID = 1, User = user, ShopID = 1, Shop = shop};

            Review review = new Review() { UserID = 1, User= user, ShopID = 1, Shop = shop, Mark = 5, ReviewText = "test review" };


            context.Shops.Add(shop);
            context.Characteristics.Add(characteristisc);
            context.Users.Add(user);
            context.Bookmarks.Add(bookmark);
            context.Reviews.Add(review);

            context.SaveChanges();
        }
    }
}
