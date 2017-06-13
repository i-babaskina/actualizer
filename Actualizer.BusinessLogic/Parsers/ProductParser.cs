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
        public static List<Category> GetProductCategories(String productName)
        {
            List<Category> categories = new List<Category>();
            FillCategoriesByProductName(categories, productName);
            return categories;
        }

        public static List<Purpose> GetProductsFromProm(String product)
        {
            String html = Constants.PRODUCT_SEARCH_IN_PROM + product;
            var purposes = GetPurposesFromLink(html);
            return purposes;

        }

        private static void FillCategoriesByProductName(List<Category> categories, String productName)
        {
            String html = String.Concat(Constants.PRODUCT_SEARCH_IN_PROM, productName);
            HtmlDocument HD = new HtmlDocument();
            var web = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8,
            };
            HD = web.Load(html);

            HtmlNodeCollection cats = HD.DocumentNode.SelectNodes("//div[@class='x-filters-tree__item']");

            if (cats != null)
            {
                Int32 counter = 0;
                foreach (var item in cats)
                {
                    if (counter > 5) break;
                    Category category = new Category();
                    category.Name = item.ChildNodes["a"].InnerText;
                    category.Link = "http://prom.ua" + item.ChildNodes["a"].Attributes["href"].Value;
                    //category.Purposes = GetMostRelevancePurposes(category.Link);
                    counter++;
                    categories.Add(category);
                }

            }

        }

        private static List<Purpose> GetMostRelevancePurposes(String html)
        {
            return GetPurposesFromLink(html).ToList();
        }

        public void Test()
        {

        }

        private static List<Purpose> GetPurposesFromLink(String html)
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
                    purpose.ImageLink = item.Attributes["data-product-big-picture"].Value;
                    purpose.Link = item.Attributes["data-product-url"].Value;
                    purpose.Title = item.Attributes["data-product-name"].Value;
                    String priceText = item.Attributes["data-product-price"].Value;
                    purpose.Price = priceText.Replace(" ", String.Empty).Substring(0, priceText.IndexOf("г") - 1);
                    purpose.ShopId = item.Attributes["data-company-id"].Value;
                    purposes.Add(purpose);
                }
            }

            //if (Items != null && Items[0] != null)
            //{
            //    foreach (var item in Items.Concat(ItemsAgain))
            //    {
            //        HtmlNode imagePart = null, contentPart = null, pricePart = null, shopPart = null;
            //        imagePart = item.ChildNodes[0].ChildNodes.Where(x => x.Attributes["class"] != null
            //                            && x.Attributes["class"].Value.Equals("x-gallery-tile__img x-image-holder")).FirstOrDefault();
            //        contentPart = item.ChildNodes.Where(x => x.Attributes["class"] != null
            //                            && x.Attributes["class"].Value.Equals("b-product-gallery__content-spacer")).FirstOrDefault();
            //        pricePart = item.ChildNodes[0].ChildNodes.Where(x => x.Attributes["itemprop"] != null
            //                                    && x.Attributes["itemprop"].Value.Equals("offers")).FirstOrDefault()
            //                                    .ChildNodes.Where(x => x.Attributes["itemprop"] != null
            //                                    && x.Attributes["itemprop"].Value.Equals("price")).FirstOrDefault();
            //        shopPart = item.ChildNodes.Where(x => x.Attributes["class"] != null
            //                        && x.Attributes["class"].Value.Equals("b-product-gallery__content-hidden")).FirstOrDefault()
            //                        ?.ChildNodes["div"]?.ChildNodes.Where(x => x.Attributes["class"] != null
            //                       && x.Attributes["class"].Value.Equals("h-mb-5 b-text-hider h-nowrap")).FirstOrDefault();
            //        Purpose p = new Purpose();
            //        p.Title = contentPart?.ChildNodes["h3"].ChildNodes["a"].InnerText.Trim();//,
            //        p.Link = contentPart?.ChildNodes["h3"].ChildNodes["a"].Attributes["href"].Value.Trim();//,
            //        p.ImageLink = imagePart?.ChildNodes["a"].ChildNodes["img"].Attributes["src"].Value;
            //        p.Price = pricePart?.InnerText.Trim().Substring(0, pricePart.InnerText.Trim().IndexOf('\n'));//,
            //        p.ShopName = shopPart?.InnerText.Trim().Replace("&#34;", "");
            //        var rws = item.ChildNodes.Where(x => x.Attributes["class"] != null
            //                                        && x.Attributes["class"].Value.Equals("b-product-gallery__content-hidden"))
            //                                        .FirstOrDefault();
            //        if (rws != null)
            //        {
            //            var reviews = GetReviews(rws);
            //            p.Rating = reviews.Value.Replace("\n", "").Replace("                        ", " ");
            //            p.ReviewsLink = reviews.Key;
            //        }
            //        purposes.Add(p);
            //    }
            //}
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
