using Actualizer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actualizer.Data.DAL
{
    public class DbBookmarkService
    {
        public void Add(Bookmark bookmark)
        {
            using (ActualizerContext context = new ActualizerContext())
            {
                context.Bookmarks.Add(bookmark);
                context.SaveChanges();
            }
        }

        public List<Bookmark> GetBookmarksByUserId(Int64 userId)
        {
            using (ActualizerContext context = new ActualizerContext())
            {
                return context.Bookmarks.Where(r => r.UserID == userId).ToList();
            }
        }
    }
}
