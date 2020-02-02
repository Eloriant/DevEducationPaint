using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DevEducationPaint.Share
{
  public static class Quarter
  {
    public static int FindQuarter(Point prev, Point position)
    {
      int quarter = 0;
      if (position.X >= prev.X && position.Y >= prev.Y)
      {
        quarter = 4;
      }
      if (position.X <= prev.X && position.Y <= prev.Y)
      {
        quarter = 2;
      }
      if (position.X >= prev.X && position.Y <= prev.Y)
      {
        quarter = 1;
      }
      if (position.X <= prev.X && position.Y >= prev.Y)
      {
        quarter = 3;
      }
      return quarter;
    }
  }
}
