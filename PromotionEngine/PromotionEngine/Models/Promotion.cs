using PromotionEngine.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine.Models
{ 
  /// <summary>
  /// Consider as special order (suborder)
  /// </summary>
  public class Promotion : Order
  {
    public IEnumerable<Product> DoPromotion (Order order, IEnumerable<Product> products)
    {

      var matchedProducts = new List<Product>();
      if (Products.IsNullOrEmpty()) return matchedProducts;

      // find all products in the promotion order
      foreach (var p in Products)
      {
        var matchedProduct = products.FirstOrDefault(_ => _.ID == p.ID) ??
          order.Products.FirstOrDefault(_ => _.ID == p.ID);
        // if product in the order not in the list exit or amount is less
        if (matchedProduct == null || matchedProduct.Amount < p.Amount)
          return null;
        // otherwise add it  to the list
        if (!matchedProducts.Any(x => x.ID == matchedProduct.ID))
          matchedProducts.Add(new Product() { ID = matchedProduct.ID , Amount = matchedProduct.Amount});
      }

      // loop again to do promotion and take out from the total amount
          foreach (var p in Products)
          {
            var matchedProduct = matchedProducts.FirstOrDefault(_ => _.ID == p.ID);
            if (matchedProduct != null && matchedProduct.Amount >= p.Amount)
            {
              matchedProduct.Amount -= p.Amount;
              order.TotalPrice += TotalPrice;
            }
          }


      return matchedProducts;
    }
  }
}
