using Actualizer.BusinessLogic.HelperModels;
using Actualizer.BusinessLogic.Parsers;
using Actualizer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actualizer.BusinessLogic.Services
{
    class ProductService
    {
        public static List<Product> GetSearchProduct(String searchTerm, ref List<Category> categories)
        {
            List<Purpose> purposes = ProductParser.GetProductsFromPromAndFillCategories(searchTerm, categories);
            purposes = purposes.Count >= 24 ? purposes.Take(24).ToList() : purposes;
            List<Product> products = purposes.Select(p => MapPurposeToProduct(p)).ToList();
            return products;
        }

        public static List<Product> GetSearchProduct(String searchTerm, ref List<Category> categories, String categoryLink)
        {
            List<Purpose> purposes = ProductParser.GetProductsFromPromAndFillCategories(searchTerm, categories, categoryLink);
            purposes = purposes.Count >= 24 ? purposes.Take(24).ToList() : purposes;
            List<Product> products = purposes.Select(p => MapPurposeToProduct(p)).ToList();
            return products;
        }

        private static Product MapPurposeToProduct(Purpose purpose)
        {
            Shop shop = ShopService.GetShopFromId(purpose.ShopId);
            Product product = new Product()
            {
                Title = purpose.Title,
                Price = purpose.Price,
                ImageLink = purpose.ImageLink,
                Link = purpose.Link,
                ShopName = shop.Title,
                ShopId = purpose.ShopId,
            };
            String sku, description, descriptionHtml;
            GetProductSKUAndDescription(product.Link, out sku, out description, out descriptionHtml);
            product.SKU = sku;
            product.Description = description;
            product.DescriptionHtml = descriptionHtml;

            return product;
        }

        private static Boolean GetProductSKUAndDescription(String productLink, out String sku, out String description, out String descriptionHtml)
        {
            Boolean isFound = ProductParser.GetProductInfoFromProductLink(productLink, out sku, out description, out descriptionHtml);
            return isFound;
        }
    }
}
