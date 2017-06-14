using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Threading.Tasks;
using Actualizer.BusinessLogic.HelperModels;
using Actualizer.BusinessLogic.HelperClasses;

namespace Actualizer.BusinessLogic.Parsers
{
    public class ProductParser
    {
        public static List<Purpose> GetProductsFromPromAndFillCategories(String product, List<Category> categories, String categoryLink = null)
        {
            Boolean isCategorySelected = !String.IsNullOrEmpty(categoryLink);
            String html = isCategorySelected ? categoryLink : Constants.PRODUCT_SEARCH_IN_PROM + product;
            var purposes = GetPurposesFromLinkAndFillCategories(html, !isCategorySelected, categories);
            return purposes;

        }

        private static void FillCategories(List<Category> categories, HtmlDocument HD)
        {

            HtmlNodeCollection cats = HD.DocumentNode.SelectNodes("//div[@class='x-filters-tree__item']");

            if (cats != null)
            {
                Int32 counter = 0;
                foreach (var item in cats)
                {
                    if (counter > 4) break;
                    Category category = new Category();
                    category.Name = item?.ChildNodes["a"]?.InnerText;
                    category.Link = "http://prom.ua" + item?.ChildNodes["a"]?.Attributes["href"]?.Value;
                    //category.Purposes = GetMostRelevancePurposes(category.Link);
                    counter++;
                    categories.Add(category);
                }

            }

        }

        public static bool GetProductInfoFromProductLink(String productLink, out String sku, out String description, out String descriptionHtml)
        {
            HtmlDocument HD = new HtmlDocument();
            var web = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8,
            };
            HD = web.Load(productLink);

            HtmlNode skuNode = HD.DocumentNode.SelectNodes("//span[@data-qaid='product-sku']").FirstOrDefault();
            HtmlNode descriptionNode = HD.DocumentNode.SelectNodes("//div[@data-qaid='product_description']").FirstOrDefault();
            sku = skuNode?.InnerText ?? String.Empty;
            description = descriptionNode?.InnerText.Trim() ?? String.Empty;
            descriptionHtml = descriptionNode?.InnerHtml.Trim() ?? String.Empty;
            return String.IsNullOrEmpty(sku) || String.IsNullOrEmpty(description);
        }

        public void Test()
        {

        }

        private static List<Purpose> GetPurposesFromLinkAndFillCategories(String html, Boolean isNeedFillCategories, List<Category> categories)
        {
            HtmlDocument HD = new HtmlDocument();
            var web = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8,
            };
            HD = web.Load(html);

            HtmlNodeCollection NoAltElements = HD.DocumentNode.SelectNodes("//a[@class=' js-product-buy-button js-product-ad-conv-action x-button x-button_width_full x-button_theme_purple js-rtb-partner']");
            HtmlNodeCollection NoAltElements1 = HD.DocumentNode.SelectNodes("//span[@itemprop='price']");
            HtmlNodeCollection ItemsAgain = HD.DocumentNode.SelectNodes("//div[@class=' x-gallery-tile js-gallery-tile']");
            HtmlNodeCollection Items = HD.DocumentNode.SelectNodes("//div[@class=' x-gallery-tile js-gallery-tile js-productad']");
            // x-gallery-tile js-gallery-tile js-productad

            List<Purpose> purposes = new List<Purpose>();

            if (NoAltElements != null)
            {
                foreach (var item in NoAltElements)
                {
                    Purpose purpose = new Purpose();
                    purpose.ImageLink = item?.Attributes["data-product-big-picture"]?.Value;
                    purpose.Link = item?.Attributes["data-product-url"]?.Value;
                    purpose.Title = item?.Attributes["data-product-name"]?.Value;
                    String priceText = item?.Attributes["data-product-price"]?.Value;
                    purpose.Price = priceText?.Replace(" ", String.Empty).Substring(0, priceText.IndexOf("г") - 1);
                    purpose.ShopId = item?.Attributes["data-company-id"]?.Value;
                    purposes.Add(purpose);
                }
            }

            if (isNeedFillCategories)
            {
                FillCategories(categories, HD);
            }
            
            return purposes;
        }

        private static KeyValuePair<String, String> GetReviews(HtmlNode node)
        {
            var temp = node.ChildNodes["div"].ChildNodes.Where(x => x.Attributes["class"] != null &&
                            x.Attributes["class"].Value.Equals("b-text-hider h-nowrap")).FirstOrDefault()
                            .ChildNodes["span"].ChildNodes[1];
            //.FirstOrDefault();//.ChildNodes["a"];
            return new KeyValuePair<String, String>(temp.ChildNodes["a"].Attributes["href"].Value, temp.InnerText);
        }

    }
}
