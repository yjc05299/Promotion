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
    public IEnumerable<Order> Orders;

    public EngineController(IEnumerable<ProductPrice> prices, IEnumerable<Order> orders)
    {
      this.Prices = prices;
      this.Orders = orders;
    }

    /// <summary>
    /// TODO Promotion
    /// </summary>
    /// <param name="order"></param>
    public void CheckOut(Order order)
    {
      var orderProducts = new List<Product>();
      foreach (var product in order.Products)
      {
        // TODO promotion
        var amount = product.Amount;
        order.Total += Prices.FirstOrDefault(o => o.ID == product.ID).Price * amount;
      }
    }
  }


}
