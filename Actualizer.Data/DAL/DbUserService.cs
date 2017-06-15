using Actualizer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actualizer.Data.DAL
{
    public class DbUserService
    {
        public void Add(User user)
        {
            using(ActualizerContext context = new ActualizerContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public void Update(User user)
        {
            using (ActualizerContext context = new ActualizerContext())
            {
                context.Entry(user).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public User Get(String login, String password)
        {
            using (ActualizerContext context = new ActualizerContext())
            {
               return context.Users.FirstOrDefault(u => u.Login.Equals(login) && u.Password.Equals(password));
            }
        }
        
        
    }
}
