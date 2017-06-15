using Actualizer.BusinessLogic.HelperClasses;
using Actualizer.Data.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actualizer.BusinessLogic.Parsers
{
    public class ShopParser
    {
        public static Shop GetShopById(String shopId)
        {
            String html = Constants.SHOP_REVIEW_PAGE + shopId;
            HtmlDocument HD = new HtmlDocument();
            var web = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8,
            };
            HD = web.Load(html);

            if (HD.DocumentNode.InnerText.Contains("от роботов")) throw new Exception("Please wait for capcha");

            HtmlNode contactDataNode = HD.DocumentNode.SelectNodes("//span[@class='x-pseudo-link js-product-ad-conv-action']").FirstOrDefault();
            HtmlNode titleDataNode = HD.DocumentNode.SelectNodes("//div[@class='x-title x-title_mb_20']").FirstOrDefault();
            HtmlNode addressDataNode = HD.DocumentNode.SelectNodes("//div[@class='x-company-info__address']").FirstOrDefault(); 
            HtmlNode persentNode = HD.DocumentNode.SelectNodes("//tr[@data-qaid='price']").FirstOrDefault()
                .ChildNodes.Where(c => c.Attributes["data-qaid"] != null && c.Attributes["data-qaid"].Value.Equals("percent"))
                .FirstOrDefault();
            HtmlNode priceNode = HD.DocumentNode.SelectNodes("//tr[@data-qaid='price']").FirstOrDefault()
                .ChildNodes.Where(c => c.Attributes["data-qaid"] != null && c.Attributes["data-qaid"].Value.Equals("percent"))
                .FirstOrDefault();
            HtmlNode deliveryNode = HD.DocumentNode.SelectNodes("//tr[@data-qaid='delivery']").FirstOrDefault()
                .ChildNodes.Where(c => c.Attributes["data-qaid"] != null && c.Attributes["data-qaid"].Value.Equals("percent"))
                .FirstOrDefault();
            HtmlNode descriptionNode = HD.DocumentNode.SelectNodes("//tr[@data-qaid='description']").FirstOrDefault()
                .ChildNodes.Where(c => c.Attributes["data-qaid"] != null && c.Attributes["data-qaid"].Value.Equals("percent"))
                .FirstOrDefault();
            HtmlNode availabilityNode = HD.DocumentNode.SelectNodes("//tr[@data-qaid='availability']").FirstOrDefault()
                .ChildNodes.Where(c => c.Attributes["data-qaid"] != null && c.Attributes["data-qaid"].Value.Equals("percent"))
                .FirstOrDefault();
            HtmlNode reviewsPercentNode = HD.DocumentNode.SelectNodes("//span[@class='x-quality-index__percent']").FirstOrDefault();
            HtmlNode reviewsCountNode = HD.DocumentNode.SelectNodes("//span[@class='x-sorter__counter']").FirstOrDefault();
            

            Shop shop = new Shop();
            shop.PromId = Int64.Parse(shopId);
            shop.Title = titleDataNode.InnerText.Trim();
            shop.PhoneNumber = contactDataNode.Attributes["data-pl-main-phone"].Value;
            shop.ShopLink = contactDataNode.Attributes["data-pl-contacts-url"].Value;
            shop.Address = addressDataNode.InnerText.Trim();
                Characteristics characteristics =  new Characteristics();
            //{
            characteristics.Availability = Double.Parse(availabilityNode.InnerText.Trim().Replace("%", ""));
            characteristics.Description = Double.Parse(descriptionNode.InnerText.Trim().Replace("%", ""));
            characteristics.PositiveReviews = Double.Parse(reviewsCountNode.InnerText.Trim());
            characteristics.Actuality = Double.Parse(priceNode.InnerText.Trim().Replace("%", ""));
            characteristics.ShippingTime = Double.Parse(deliveryNode.InnerText.Trim().Replace("%", ""));
            characteristics.UpdateDate = DateTime.Now;
            characteristics.ShopId = Int64.Parse(shopId);
            characteristics.AverageRating = Double.Parse(reviewsPercentNode.InnerText.Trim().Replace("%", ""));
            //};
            shop.Characteristics = characteristics;

            return shop;
        }
    }
}
