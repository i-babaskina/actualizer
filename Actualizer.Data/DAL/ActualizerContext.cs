using Actualizer.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actualizer.Data.DAL
{
    public class ActualizerContext : DbContext
    {
        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<Characteristics> Characteristics { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Shop>().HasOptional(s => s.Characteristics).WithRequired(s => s.Shop);
            modelBuilder.Entity<User>().HasMany(x => x.Bookmarks).WithRequired(s => s.User);
            modelBuilder.Entity<User>().HasMany(x => x.Reviews).WithRequired(s => s.User);
            modelBuilder.Entity<Shop>().HasMany(x => x.Bookmarks).WithRequired(s => s.Shop);
            modelBuilder.Entity<Shop>().HasMany(x => x.Reviews).WithRequired(s => s.Shop); 
        }
    }
}
