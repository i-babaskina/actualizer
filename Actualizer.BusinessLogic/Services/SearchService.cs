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
        public List<Product> GetSearchProduct(String searchTerm)
        {
            List<Purpose> purposes = ProductParser.GetProductsFromProm(searchTerm);
            purposes = purposes.Count >= 24 ? purposes.Take(24).ToList() : purposes;
            List<Product> products = purposes.Select(p => MapPurposeToProduct(p)).ToList();
            return products;
        }

        private Product MapPurposeToProduct(Purpose purpose)
        {
            Shop shop = GetShopFromId(purpose.ShopId);
            Product product = new Product()
            {
                Title = purpose.Title,
                Price = purpose.Price,
                ImageLink = purpose.ImageLink,
                Link = purpose.Link,
                ShopName = shop.Title,
            };

            return product;
        }
        
       

        private Shop GetShopFromId(string shopId)
        {
            return ShopParser.GetShopById(shopId);
        }
    }
}
