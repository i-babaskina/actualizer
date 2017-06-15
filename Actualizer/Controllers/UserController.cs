using Actualizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Actualizer.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login1(RegisterViewModel model)
        {
            return View();
        }

        public async Task<ActionResult> Login(RegisterViewModel model, string returnUrl)
        {
            return View();
        }
    }
}