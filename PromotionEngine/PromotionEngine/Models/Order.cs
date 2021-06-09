using System;
using System.Collections.Generic;

namespace PromotionEngine.Models
{
  public class Order
  {
    public IEnumerable<Product> Products { get; set; }
    public decimal Total { get; set; }
  }
}
