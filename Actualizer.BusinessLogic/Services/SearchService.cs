using Actualizer.BusinessLogic.HelperModels;
using Actualizer.BusinessLogic.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Actualizer.Data.Models;

namespace Actualizer.BusinessLogic.Services
{
    public class SearchService
    {
        public static SearchModel GetSearchModel(String searchTerm)
        {
            SearchModel model = new SearchModel();
            model.SearchTerm = searchTerm;
            List<Category> categories = new List<Category>();
            model.Product = ProductService.GetSearchProduct(searchTerm, ref categories);
            model.Categories = categories;

            return model;
        }

        public static SearchModel GetSearchModel(String searchTerm, String categoryLink)
        {
            SearchModel model = new SearchModel();
            model.SearchTerm = searchTerm;
            List<Category> categories = new List<Category>();
            model.Product = ProductService.GetSearchProduct(searchTerm, ref categories);

            return model;
        }
        
       


    }
}
