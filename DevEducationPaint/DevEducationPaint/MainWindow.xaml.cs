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
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private WriteableBitmap writeableBitmap;

    List<Color> pencilColor = new List<Color>{Colors.Black, Colors.Black, Colors.Black};
    public MainWindow()
    {
      InitializeComponent();
      writeableBitmap = new WriteableBitmap(770,
        400, 300, 300, PixelFormats.Bgra32, null);
      FillWhite();
    }

    private void FillWhite()
    {
      int width = 760;
      int height = 400;
      int stride = width / 8;
      byte[] pixels = new byte[height * stride];

      var colors = new List<Color> { Colors.White, Colors.White, Colors.White };
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

      byte blue = 0;
      byte green = 0;
      byte red = 0;
      byte alpha = 255;
      byte[] colorData = { Colors.Black.R, Colors.Black.G, Colors.Black.B, alpha };

      if (e.LeftButton != MouseButtonState.Pressed) return;
      var position = e.GetPosition(sender as IInputElement);
      var rect = new Int32Rect((int)position.X, (int)position.Y, 1, 1);
      writeableBitmap.WritePixels(rect, colorData, 4, 0);
      DrawWindow.Source = writeableBitmap;
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
  }

}
