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
        private bool isDrawing = false; //флаг сигнализирующий
        public MainWindow()
        {
            InitializeComponent();
            writeableBitmap = new WriteableBitmap(726,
              396, 96, 96, PixelFormats.Bgra32, null);
            Int32.TryParse(tbxPencilSize.Text as string, out int value);
            pencilSize = value;
            FillWhite();
        }
        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            prev.X = 0;
            prev.Y = 0;
            isDrawing = false;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            prev = e.GetPosition(sender as IInputElement);
            isDrawing = true;
            //SetPixel(prev); - Ставит точку при клике без движения. 
            //Выключил, потому что ставит точку отдельно от той,
            // которая поставится во время начала движения мыши 
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
            if (isDrawing == true && prev.X != 0 && prev.Y != 0)
            {
                var position = e.GetPosition(sender as IInputElement);
                SetPixel(position);
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
        private void DrawLine(int x1, int y1, int x2, int y2)
        {
            //Соединение точек линиями
        }
        private void SetPixel(Point prev)
        {
            byte[] colorData = { pencilColor.R, pencilColor.G, pencilColor.B, pencilColor.A };
            var rect = new Int32Rect((int)prev.X, (int)prev.Y, pencilSize, pencilSize);
            // Где-то здесь должен вызываться метод Pencil_Print
            int stride = (rect.Width * writeableBitmap.Format.BitsPerPixel + 7) / 8;
            int bufferSize = rect.Height * stride;

            byte[] newColorData = new byte[bufferSize];

            for (int i = 0; i < newColorData.Length; i += 4)
            {
                newColorData[i] = pencilColor.B;
                newColorData[i + 1] = pencilColor.G;
                newColorData[i + 2] = pencilColor.R;
                newColorData[i + 3] = pencilColor.A;
            }
            writeableBitmap.WritePixels(rect, newColorData, stride, 0);
            DrawWindow.Source = writeableBitmap;
        }

    }

}
