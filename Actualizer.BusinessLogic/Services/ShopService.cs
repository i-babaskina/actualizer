using Actualizer.BusinessLogic.Parsers;
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
            return ShopParser.GetShopById(shopId);
        }
    }
}
