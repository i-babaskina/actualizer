using Actualizer.BusinessLogic.Services;
using Actualizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Actualizer.BusinessLogic;

namespace Actualizer.Repository
{
    public class SearchRepository
    {
        public static SearchModel GetSearchModel(String searchTerm)
        {
            if (String.IsNullOrEmpty(searchTerm)) return new SearchModel();
            BusinessLogic.HelperModels.SearchModel serviceModel = SearchService.GetSearchModel(searchTerm);
            SearchModel model = new SearchModel()
            {
                SearchTerm = serviceModel.SearchTerm,
                Product = serviceModel.Product,
                Categories = serviceModel.Categories,
                Url = serviceModel.Url
            };
            return model;
        }
    }
}