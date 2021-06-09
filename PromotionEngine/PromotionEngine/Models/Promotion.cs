using PromotionEngine.Helper;
using System;
using System.Collections.Generic;
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

      var mateched = new List<Product>();
      if (Products.IsNullOrEmpty()) return mateched;
      return mateched;
    }
  }
}
