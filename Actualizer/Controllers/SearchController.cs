using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Actualizer.BusinessLogic.Parsers;
using Actualizer.BusinessLogic.Services;

namespace Actualizer.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            SearchService service = new SearchService();
            var categoriesWithProducts = service.GetSearchProduct("барабан расписной");
            return View();
        }
    }
}