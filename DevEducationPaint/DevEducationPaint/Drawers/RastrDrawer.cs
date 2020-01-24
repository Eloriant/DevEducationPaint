using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Media.Imaging;
using DevEducationPaint.Strategies;
using Point = System.Windows.Point;

namespace DevEducationPaint.Drawers
{
  class RastrDrawer
  {
    private static RastrDrawer drawer;

    public Color pencilColor { get; set; }

    public IFigureStrategy FigureStrategy {private get; set; }

    public static RastrDrawer GetDrawer()
    {
      return drawer ??= new RastrDrawer();
    }
        public WriteableBitmap SetPixel(WriteableBitmap bmp, Point pixelPoint)
        {
            byte[] colorData = { pencilColor.B, pencilColor.G, pencilColor.R, pencilColor.A };
            var rect = new Int32Rect((int)pixelPoint.X, (int)pixelPoint.Y, 1, 1);
            bmp?.WritePixels(rect, colorData, 4, 0); //если битмап не нулевой, записываем пиксель
            return bmp;
        }

    public WriteableBitmap DrawLine(Point prev, Point position, WriteableBitmap bmp)
    {

      int wth = Convert.ToInt32(Math.Abs(position.X - prev.X));
      int hght = Convert.ToInt32(Math.Abs(position.Y - prev.Y));
      int x0 = Convert.ToInt32(prev.X);
      int y0 = Convert.ToInt32(prev.Y);
      int x = 0;
      int y = 0;
      int[] xArr = new int[] { };
      int[] yArr = new int[] { };
      double k;
      int quarter = FindQuarter(prev, position);

      if (hght >= wth)
      {
        xArr = new int[hght];
        yArr = new int[hght];
        k = wth * 1.0 / hght;

        if (quarter == 4)
        {
          for (int i = 0; i < hght; i++)
          {
            x = Convert.ToInt32(k * i + x0);
            xArr[i] = x;
            yArr[i] = y0 + i;
          }
        }
        if (quarter == 3)
        {
          for (int i = 0; i < hght; i++)
          {
            x = Convert.ToInt32(k * i - x0);
            xArr[i] = -x >= 0 ? -x : 0;
            yArr[i] = y0 + i;
          }
        }

        if (quarter == 1)
        {
          for (int i = 0; i < hght; i++)
          {
            x = Convert.ToInt32(k * i + x0);
            xArr[i] = x;
            yArr[i] = y0 - i;
          }
        }

        if (quarter == 2)
        {
          for (int i = 0; i < hght; i++)
          {
            x = Convert.ToInt32(k * i - x0);
            xArr[i] = -x;
            yArr[i] = y0 - i;
          }
        }

        for (int i = 0; i < hght; i++)
        {
          prev.Y = yArr[i];
          prev.X = xArr[i];
          if (prev.X <= 0 || prev.Y <= 0 || prev.X >= bmp.PixelWidth || prev.Y >= bmp.PixelHeight)
          {
              continue;
          }
          else
              bmp = SetPixel(bmp, prev);
        }
      }
      else if (hght < wth)
      {
        xArr = new int[wth];
        yArr = new int[wth];
        k = hght * 1.0 / wth;

        if (quarter == 1)
        {
          for (int i = 0; i < wth; i++)
          {
            y = Convert.ToInt32(k * i - y0);
            yArr[i] = -y;
            xArr[i] = x0 + i;
          }
        }

        if (quarter == 2)
        {
          for (int i = 0; i < wth; i++)
          {
            y = Convert.ToInt32(k * i - y0);
            yArr[i] = -y;
            xArr[i] = x0 - i;
          }
        }

        if (quarter == 4)
        {
          for (int i = 0; i < wth; i++)
          {
            y = Convert.ToInt32(k * i + y0);
            yArr[i] = y;
            xArr[i] = x0 + i;
          }
        }

        if (quarter == 3)
        {
          for (int i = 0; i < wth; i++)
          {
            y = Convert.ToInt32(k * i + y0);
            yArr[i] = y;
            xArr[i] = x0 - i;
          }
        }

        for (int i = 0; i < wth; i++)
        {
          prev.Y = yArr[i];
          prev.X = xArr[i];
          if (prev.X <= 0 || prev.Y <= 0 || prev.X >= bmp.PixelWidth || prev.Y >= bmp.PixelHeight)
          {
              continue;
          }
          else
              bmp = SetPixel(bmp, prev);
        }
      }

      return bmp;
    }

    private int FindQuarter(Point prev, Point position)
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

    public WriteableBitmap DrawFigure(WriteableBitmap bitmap, Point startPoint, Point endPoint, int angleNumber = -1)
    {
      bitmap = FigureStrategy.DrawAlgorithm(bitmap, startPoint, endPoint, angleNumber);
      return bitmap;
    }
  }
}
