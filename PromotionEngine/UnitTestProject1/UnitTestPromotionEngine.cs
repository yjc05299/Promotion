using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine;
using PromotionEngine.Controller;
using PromotionEngine.Models;
using System.Collections.Generic;

namespace UnitTestProject1
{
  [TestClass]
  public class UnitTestPromotionEngine
  {
    static List<ProductPrice> prices = new List<ProductPrice>()
    {
      new ProductPrice {ID="A", Price = 50 },
      new ProductPrice {ID="B", Price = 30 },
      new ProductPrice {ID="C", Price = 20 },
      new ProductPrice {ID="D", Price = 15 },

    };

    static EngineController engine = new EngineController(prices, new List<Promotion>());

    [TestMethod]
    public void Test_Scenario_A()
    {
      var products = new List<Product>()
      {
        new Product{ ID ="A",Amount = 1},
        new Product{ ID ="B",Amount = 1},
        new Product{ ID ="C",Amount = 1},

      };
      var order = new Order()
      {
        Products = products
      };
      engine.CheckOut(order);
    }

    [TestMethod]
    public void Test_Scenario_B()
    {
      var products = new List<Product>()
      {
        new Product{ ID ="A",Amount = 5},
        new Product{ ID ="B",Amount = 5},
        new Product{ ID ="C",Amount = 1},

      };
      var order = new Order()
      {
        Products = products
      };
      engine.CheckOut(order);
      Assert.IsTrue(order.Total == 370);
    }

    [TestMethod]
    public void Test_Scenario_C()
    {
      var products = new List<Product>()
      {
        new Product{ ID ="A",Amount = 3},
        new Product{ ID ="B",Amount = 5},
        new Product{ ID ="C",Amount = 1},
        new Product{ ID ="D",Amount = 1},

      };
      var order = new Order()
      {
        Products = products
      };
      engine.CheckOut(order);
      Assert.IsTrue(order.Total == 280);
    }
  }
}
