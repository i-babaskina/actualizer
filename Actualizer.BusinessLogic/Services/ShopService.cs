using Actualizer.BusinessLogic.Parsers;
using Actualizer.Data.DAL;
using Actualizer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actualizer.BusinessLogic.Services
{
    class ShopService
    {
        public static Shop GetShopFromId(string shopId)
        {
            DbShopService dbService = new DbShopService();
            DbCharacteristicsService dbCharService = new DbCharacteristicsService();
           Int64 ID;
            Shop shop = null;
            if (Int64.TryParse(shopId, out ID))
            {
                shop = dbService.Get(ID);
            }
            if (shop == null)
            {
                shop = ShopParser.GetShopById(shopId);
                dbService.AddOrUpdate(shop);
            }
            Characteristics characteristisc = dbCharService.GetByShopId(shop.PromId);
            if (characteristisc == null || characteristisc.UpdateDate < DateTime.Now.AddDays(-1))
            {
                dbCharService.Add(characteristisc);
            }
            return shop;
        }
    }
}
