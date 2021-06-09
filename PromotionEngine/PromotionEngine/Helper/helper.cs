using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine.Helper
{
  public static class Helper
  {

    public static bool IsNotNullOrEmpty<T>(this System.Collections.Generic.IEnumerable<T> source)
    {
      return source != null && source.Any();
    }

    public static bool IsNullOrEmpty<T>(this System.Collections.Generic.IEnumerable<T> source)
    {
      return !source.IsNotNullOrEmpty();
    }
  }
}
