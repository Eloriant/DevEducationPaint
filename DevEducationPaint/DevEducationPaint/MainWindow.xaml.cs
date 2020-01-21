using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevEducationPaint.Drawers;
using DevEducationPaint.Figures;

namespace DevEducationPaint
{
    public partial class MainWindow : Window
    {
        private WriteableBitmap writeableBitmap;
        private WriteableBitmap copy;

        private RastrDrawer drawer;


        private int pencilSize;
        private Color pencilColor = Brushes.Black.Color;
        private Point prev = new Point(0, 0);
        private Point position = new Point(0, 0);
        private bool isDrawing = false; //флаг сигнализирующий
        private bool isDrawingTriangle = false; // флаг сигнализирующий о рисовании треугольника
        private bool isDrawingCircle = false; // флаг сигнализирующий о рисовании круга

        public MainWindow()
        {
            InitializeComponent();
            writeableBitmap = new WriteableBitmap(726,
              396, 96, 96, PixelFormats.Bgra32, null);
            Int32.TryParse(tbxPencilSize.Text as string, out int value);
            pencilSize = value;

            //Тут получаем синглтон рисовальщика
            drawer = RastrDrawer.GetDrawer();
            //таким видмом ему можно задать цвет, который он будет использовать для рисования всего, что нам нужно
            drawer.pencilColor = System.Drawing.Color.Blue;

            DrawWindow.Source = writeableBitmap;

            drawer.FigureStrategy = new SquareFigure();
            DrawWindow.Source = drawer.DrawFigure(writeableBitmap, new Point(10, 50), new Point(15, 40));
        }
        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (isDrawingTriangle == true)
            {
                writeableBitmap = copy;
                isDrawingTriangle = false;
            }

            if (isDrawingCircle == true)
            {
                writeableBitmap = copy;
                isDrawingCircle = false;
            }
            //position = e.GetPosition(sender as IInputElement);
            //DrawLine(prev, position);
            prev.X = 0;
            prev.Y = 0;
            position.X = 0;
            position.Y = 0;
            isDrawing = false;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

            //isDrawing = true;
            //prev = e.GetPosition(sender as IInputElement);
            //ddd.Content = $"{prev.X} {prev.Y}";
            ////SetPixel(prev);
        }
        private void FillWhite()
        {
            int width = 728;
            int height = 428;
            int stride = width / 8;
            byte[] pixels = new byte[height * stride];

            var colors = new List<Color> { Colors.White };
            BitmapPalette myPalette = new BitmapPalette(colors);


            BitmapSource image = BitmapSource.Create(
              width,
              height,
              96,
              96,
              PixelFormats.Indexed1,
              myPalette,
              pixels,
              stride);

            DrawWindow.Source = image;
        }
        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed) return;
            var position = e.GetPosition(sender as IInputElement);
            ddd.Content = $"{position.X} {position.Y}";

            if (isDrawingTriangle == true && prev.X != 0 && prev.Y != 0)
            {
                copy = new WriteableBitmap(writeableBitmap);
                DrawWindow.Source = writeableBitmap;
                position = e.GetPosition(sender as IInputElement);
                Draw_Triangle(prev, position, copy);
                DrawWindow.Source = copy;
            }

            if (isDrawingCircle == true && prev.X != 0 && prev.Y != 0)
            {
                copy = new WriteableBitmap(writeableBitmap);
                DrawWindow.Source = writeableBitmap;
                position = e.GetPosition(sender as IInputElement);
                DrawCircle(prev, position, copy);
                DrawWindow.Source = copy;
            }
            else if (isDrawing == false && prev.X != 0 && prev.Y != 0)
            {
                position = e.GetPosition(sender as IInputElement);
                DrawLine(prev, position);
                prev = position;
            }
            else
            {
                prev = e.GetPosition(sender as IInputElement);
            }
            if (isDrawing)
            {
                copy = new WriteableBitmap(writeableBitmap);
                DrawWindow.Source = writeableBitmap;
                position = e.GetPosition(sender as IInputElement);
                DrawWindow.Source = drawer.DrawFigure(copy, prev, position);
            }
        }
        private void Image_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Point p = e.MouseDevice.GetPosition(DrawWindow);

            Matrix m = DrawWindow.RenderTransform.Value;
            if (e.Delta > 0)
                m.ScaleAtPrepend(1.1, 1.1, p.X, p.Y);
            else
                m.ScaleAtPrepend(1 / 1.1, 1 / 1.1, p.X, p.Y);

            DrawWindow.RenderTransform = new MatrixTransform(m);
        }
        private void cp_SelectedColorChanged_1(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (cp.SelectedColor.HasValue)
            {
                pencilColor = cp.SelectedColor.Value;
            }
        }
        private void tbxPencilSize_Changed(object sender, TextChangedEventArgs e)
        {
            Int32.TryParse(tbxPencilSize.Text as string, out int value);
            pencilSize = value;
        }
        private void Pencil_Print(int pencilSize)
        {
            //написать разные отпечатки от кисти(точка, квадрат 2х2, крестик 3х3 и так далее.)
        }
        private void DrawLine(Point prev, Point position, WriteableBitmap bmp = null)
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
                    SetPixel(prev, bmp);
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
                    SetPixel(prev, bmp);
                }
            }

        }

        public int FindQuarter(Point prev, Point position)
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

        public object[] FindRelativeValue(Point prev, Point position)
        {
            object[] arr = new object[2];
            int k;
            int withdraw = Convert.ToInt32(position.X - prev.X);
            int height = Convert.ToInt32(position.Y - position.X);
            string relativeValue = "";
            if (Math.Abs(withdraw) > Math.Abs(height))
            {
                if (withdraw == 0) { k = height; }
                else k = height / withdraw;
                relativeValue = "x";
            }
            else
            {
                if (height == 0) { k = withdraw; }
                else k = withdraw / height;
                relativeValue = "y";
            }
            arr[0] = k;
            arr[1] = relativeValue;
            return arr;
        }

        private void SetPixel(Point prev, WriteableBitmap bmp = null)
        {
            byte[] colorData = { pencilColor.B, pencilColor.G, pencilColor.R, pencilColor.A };
            var rect = new Int32Rect((int)prev.X, (int)prev.Y, 1, 1);
            if (bmp != null)
                bmp.WritePixels(rect, colorData, 4, 0);
            else
                writeableBitmap.WritePixels(rect, colorData, 4, 0);
            DrawWindow.Source = writeableBitmap;
        }

        private void buttonLine_Click(object sender, RoutedEventArgs e)
        {
            DrawLine(new Point(200, 200), new Point(100, 100));
            //это не нужно
        }

        private void triangle_Click(object sender, RoutedEventArgs e)
        {
            isDrawingTriangle = true;
        }

        private void Draw_Triangle(Point prev, Point position, WriteableBitmap bmp)
        {
            Double weigth = position.X - prev.X + (prev.X / 2);
            Point high = new Point(weigth / 2, (weigth * Math.Sqrt(3) / 2));
            DrawLine(prev, position, bmp);
            DrawLine(prev, high, bmp);
            DrawLine(high, position, bmp);
        }

        public static int Sqr(double x)
        {
            return Convert.ToInt32(Math.Pow(x, 2));
        }

        private void Circle_Click(object sender, RoutedEventArgs e)
        {
            isDrawingCircle = true;
        }
        private void DrawCircle(Point prev, Point position, WriteableBitmap bmp)
        {
            int rd, rrd, rr;
            int cx = (int)prev.X;
            int cy = (int)prev.Y;
            int r = Math.Abs((int)(position.X - prev.X));
            int x = (int)position.X;
            int y = (int)position.Y;

            List<Point> points = new List<Point>();
            for (int i = 0; i <= r; i++)
            {
                points.Add(new Point(i, Math.Sqrt(r * r - i * i)));
            }

            //Point middle = points[points.Count - 1];

            //List<Point> points1 = new List<Point>();
            //int counter = 0;
            //for (int i = r/2 + 1; i <= r; i++)
            //{
            //    points1.Add(new Point(i, middle.Y + (middle.Y - points[points.Count - 1 - counter].Y)));
            //    counter++;
            //}

            //points.AddRange(points1);

            for (int i = 1; i < points.Count; i++)
            {
                //SetPixel(new Point(points[i].X + cx, points[i].Y + cy));
                DrawLine(new Point(points[i-1].X + cx, points[i-1].Y + cy), new Point(points[i].X + cx, points[i].Y + cy), bmp);
                DrawLine(new Point(points[i-1].X + cx, Math.Abs(points[i-1].Y - cy)), new Point(points[i].X + cx, Math.Abs(points[i].Y - cy)), bmp);
                DrawLine(new Point(Math.Abs(points[i - 1].X - cx), points[i - 1].Y + cy), new Point(Math.Abs(points[i].X - cx), points[i].Y + cy), bmp);
                DrawLine(new Point(Math.Abs(points[i - 1].X - cx), Math.Abs(points[i - 1].Y - cy)), new Point(Math.Abs(points[i].X - cx), Math.Abs(points[i].Y - cy)), bmp);

            }

            //while ((y >= 0) || (x < r))
            //{
            //    SetPixel(new Point((cx + x), (cy + y)));
            //    SetPixel(new Point((cx + x), (cy - y)));
            //    SetPixel(new Point((cx - x), (cy + y)));
            //    SetPixel(new Point((cx - x), (cy - y)));
            //    rd = Math.Abs(Sqr(r) - Sqr(x) - Sqr(y - 1));
            //    rr = Math.Abs(Sqr(r) - Sqr(x + 1) - Sqr(y));
            //    rrd = Math.Abs(Sqr(r) - Sqr(x + 1) - Sqr(y - 1));
            //    if (rd < rr)
            //    {
            //        y -= 1;
            //        if (rrd < rd) { x += 1; }
            //    }
            //    else
            //    {
            //        x += 1;
            //        if (rrd < rr) { y -= 1; }
            //    }
            //}
        }

        private void Square_Click(object sender, RoutedEventArgs e)
        {
            //Тут я подсовываю рисовальщику стратегию прямоугольника, т.е пока у него лежит объект прямоугольника, он будет рисовать их, менять можно прямо по ходу рантайма
            isDrawing = true;
            drawer.FigureStrategy = new SquareFigure();
        }

    }

}