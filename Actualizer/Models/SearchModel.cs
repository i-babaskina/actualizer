using Actualizer.BusinessLogic.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Actualizer.Models
{
    public class SearchModel 
    {
        public String SearchTerm { get; set; }
        public String Url { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> Product { get; set; }

        public SearchModel()
        {
            Categories = new List<Category>();
            Product = new List<Product>();
        }
    }
}