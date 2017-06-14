using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Actualizer.BusinessLogic.Parsers;
using Actualizer.BusinessLogic.Services;
using Actualizer.Models;
using Actualizer.Repository;

namespace Actualizer.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(String searchTerm)
        {
            SearchModel model = new SearchModel();
            model = SearchRepository.GetSearchModel(searchTerm);
            return View(model);
        }
    }
}