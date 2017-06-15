using Actualizer.Data.DAL;
using Actualizer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actualizer.BusinessLogic.Services
{
    public class UserService
    {
        DbUserService dbService;

        public UserService()
        {
            DbUserService dbService = new DbUserService();
        }
        public Int64? Login(String login, String pass)
        {
            User user = dbService.Get(login, pass);
            return user?.ID;
        }

        public Int64? Registration(String login, String email, String pass)
        {
            User user = new User() { Login = login, Email = email, Password = pass };
            dbService.Add(user);
            return user.ID;

        }
    }
}
