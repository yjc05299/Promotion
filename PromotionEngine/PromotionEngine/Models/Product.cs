using System;

namespace PromotionEngine.Models
{
  public class Product
  {
    public string ID { get; set; }
    public decimal Amount { get; set; }
    public Product()
    {
    }

  }

  public class ProductPrice
  {
    public string ID { get; set; }
    public decimal Price { get; set; }

  }

}
