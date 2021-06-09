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
        var matchedProduct = products.FirstOrDefault(_ => _.ID == p.ID) ??  order.Products.FirstOrDefault(_ => _.ID == p.ID);
        // if product in the order not in the list  or amount is less exit
        if (matchedProduct == null || ( matchedProduct.Amount < p.Amount) )
          return null;
        // otherwise add it  to the list
        if (!matchedProducts.Any(_ => _.ID == matchedProduct.ID))
          matchedProducts.Add(new Product() { ID = matchedProduct.ID , Amount = matchedProduct.Amount});
      }

      // loop again to do promotion and take out from the total amount

      decimal leftover = 0;
      calPromotionRecursive(leftover, matchedProducts,order);

      return matchedProducts;
    }

    public void calPromotionRecursive(decimal leftover, IEnumerable<Product> matchedProducts, Order order)
    {

      order.TotalPrice += TotalPrice;
      foreach (var p in Products)
      {
        var matchedProduct = matchedProducts.FirstOrDefault(_ => _.ID == p.ID);
        if (matchedProduct != null && matchedProduct.Amount >= p.Amount)
        {
          matchedProduct.Amount -= p.Amount;
          leftover = matchedProduct.Amount;
        }
        if(leftover >= p.Amount)
        {
          calPromotionRecursive(leftover, matchedProducts, order);
        }

      }
    }
  }
}
