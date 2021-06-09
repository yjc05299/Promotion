using System;

namespace PromotionEngine.Models
{
  /// <summary>
  /// Product
  /// </summary>
  public class Product
  {
    public string ID { get; set; }
    public decimal Amount { get; set; }
    public Product()
    {
    }

  }

  /// <summary>
  /// Product Price
  /// </summary>
  public class ProductPrice
  {
    public string ID { get; set; }
    public decimal Price { get; set; }

  }

}
