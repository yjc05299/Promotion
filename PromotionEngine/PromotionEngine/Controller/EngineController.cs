using PromotionEngine.Helper;
using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine.Controller
{
  public class EngineController
  {
    public IEnumerable<ProductPrice> Prices;
    public IEnumerable<Promotion> Promotions;

    public EngineController(IEnumerable<ProductPrice> prices, IEnumerable<Promotion> promotion)
    {
      this.Prices = prices;
      this.Promotions = promotion;
    }

    /// <summary>
    /// TODO Promotion
    /// </summary>
    /// <param name="order"></param>
    public void CheckOut(Order order)
    {

      var orderProducts = new List<Product>();
      // do promotion
      if (Promotions != null && Promotions.Count() > 0)
        foreach (var promotion in Promotions)
        {
          var orderProductsList = promotion.DoPromotion(order, orderProducts);
          if (orderProductsList.IsNotNullOrEmpty())
          {
            foreach (var p in orderProductsList)
            {
              if (!orderProducts.Any(_ => _.ID == p.ID)) orderProducts.Add(p);
            }
          }
        }
      // do the normal price
      foreach (var product in order.Products)
      {
        var amount = (orderProducts.FirstOrDefault(x => x.ID == product.ID) ?? product).Amount;
        order.TotalPrice += Prices.FirstOrDefault(o => o.ID == product.ID).Price * amount;
      }
    }

    

  }


}
