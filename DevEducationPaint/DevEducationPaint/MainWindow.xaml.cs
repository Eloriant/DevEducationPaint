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

namespace DevEducationPaint
{
    public partial class MainWindow : Window
    {
        private WriteableBitmap writeableBitmap;

        private int pencilSize;
        private Color pencilColor = Brushes.Black.Color;
        private Point prev = new Point(0, 0);
        private Point position = new Point(0, 0);
        private bool isDrawing = false; //флаг сигнализирующий
        
        public MainWindow()
        {
            InitializeComponent();
            writeableBitmap = new WriteableBitmap(726,
              396, 96, 96, PixelFormats.Bgra32, null);
            Int32.TryParse(tbxPencilSize.Text as string, out int value);
            pencilSize = value;
            FillWhite();
            SetPixel(new Point(1, 100));
            SetPixel(new Point(1, 200));
            SetPixel(new Point(1, 300));

        }
        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            position = e.GetPosition(sender as IInputElement);
            //DrawLine(prev, position);
            prev.X = 0;
            prev.Y = 0;
            position.X = 0;
            position.Y = 0;
            isDrawing = false;

            
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            isDrawing = true;
            prev = e.GetPosition(sender as IInputElement);
            ddd.Content = $"{prev.X} {prev.Y}";
            //SetPixel(prev);
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
            var position = e.GetPosition(sender as IInputElement);
            ddd.Content = $"{position.X} {position.Y}";
            if (isDrawing == true && prev.X != 0 && prev.Y != 0)
            {
                position = e.GetPosition(sender as IInputElement);
                DrawLine(prev, position);
                prev = position;
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
        private void DrawLine(Point prev, Point position)
        {

            int wth = Convert.ToInt32(Math.Abs(position.X - prev.X) + 1);
            int hght = Convert.ToInt32(Math.Abs(position.Y - prev.Y) + 1);
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
                    SetPixel(prev);
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
                    SetPixel(prev);
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

        private void SetPixel(Point prev)
        {
            byte[] colorData = { pencilColor.B, pencilColor.G, pencilColor.R, pencilColor.A };
            var rect = new Int32Rect((int)prev.X, (int)prev.Y, 1, 1);
            writeableBitmap.WritePixels(rect, colorData, 4, 0);
            DrawWindow.Source = writeableBitmap;
        }
        
        private void buttonLine_Click(object sender, RoutedEventArgs e)
        {
            DrawLine(new Point(200, 200), new Point(100, 100));
            //это не нужно
        }
    }

}
