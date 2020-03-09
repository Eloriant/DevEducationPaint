using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using DevEducationPaint.Bitmap;
using DevEducationPaint.Share;
using DevEducationPaint.Thicknesses;

namespace DevEducationPaint.Surface_Strategy.AbstractFactory
{
    class BitmapSurface : ISurface
    {
        public DrawColor CurrentColor { get; set; }
        public ThicknessStrategy ConcreteThickness { get; set; }
        public void DrawLine(Point p1, Point p2)
        {

            List<Point> points1 = ConcreteThickness.GetPoints(p1);
            List<Point> points2 = ConcreteThickness.GetPoints(p2);

            for (int i = 0; i < points1.Count; i++)
            {
                Draw(points1[i], points2[i]);
            }
        }

        private void Draw(Point prev, Point position)
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
            int quarter = Quarter.FindQuarter(prev, position);

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
                    if (prev.X <= 0 || prev.Y <= 0 || prev.X >= SuperBitmap.Instance.PixelWidth || prev.Y >= SuperBitmap.Instance.PixelHeight)
                    {
                        continue;
                    }
                    else
                        Pixel.SetPixel(prev, CurrentColor);
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
                    if (prev.X <= 0 || prev.Y <= 0 || prev.X >= SuperBitmap.Instance.PixelWidth || prev.Y >= SuperBitmap.Instance.PixelHeight)
                    {
                        continue;
                    }
                    else
                        Pixel.SetPixel(prev, CurrentColor);
                }
            }
        }
    }
}
