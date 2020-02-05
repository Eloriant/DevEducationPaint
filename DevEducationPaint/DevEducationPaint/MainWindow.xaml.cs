using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using DevEducationPaint.Bitmap;
using DevEducationPaint.FigureCreators;
using DevEducationPaint.Figures;
using DevEducationPaint.Services;
using DevEducationPaint.Share;
using DevEducationPaint.Strategies;
using DevEducationPaint.Surface_Strategy;
using DevEducationPaint.Thicknesses;
using Xceed.Wpf.Toolkit;
//using Color = System.Drawing.Color;
using Figure = DevEducationPaint.Figures.Figure;
using Point = System.Drawing.Point;

namespace DevEducationPaint
{
  public partial class MainWindow : Window
  {
    #region Variabls On The Class Level
    //private Figure drawStrategy;
    private IDrawStrategy drawStrategy;
    //private DrawStrategy currentDrawStrategy;
    Figure resultFigure;
    FigureCreator currentCreator = null;
    private bool isFirstClicked = true;
    private bool isDoubleClicked = false;
    private Point pStaticStart = new Point();
    private int angleNumber = 5;
    private Point prev = new Point(0, 0);
    private Point position = new Point(0, 0);
    Point point = new Point(0, 0);
    private bool isDrawingFigure = false; //флаг сигнализирующий
    private bool picker = false;
    private bool filler = false;
    private FigureEnum currentFigure;
    private bool vector = false;
    private static int counterToTabControl = 0;
    private int countClick = 0;
    #endregion

    public MainWindow()
    {
      drawStrategy = new DrawByLine
      {
        SurfaceStrategy = new DrawOnBitmap
        {
          CurrentColor = new DrawColor(255, 0, 0, 255),
          ConcreteThickness = new DefaultThickness()
        }
      };
      InitializeComponent();
      var colors = new List<System.Windows.Media.Color> { Colors.Black, Colors.Black, Colors.Black };
      BitmapPalette myPalette = new BitmapPalette(colors);
      SuperBitmap.Instance = new WriteableBitmap((int)DrawWindow.Width,
      (int)DrawWindow.Height, 96, 96, PixelFormats.Bgra32, null);

      SuperCanvas.Instance = DrawWindow1;
      //new Canvas
      //{
      //  Height = DrawWindow1.Height,
      //  Width = DrawWindow1.Width
      //};
      Int32.TryParse(tbxAngleNumber.Text as string, out int nValue);
      angleNumber = nValue;
      FillWhite();
      DrawWindow.Source = SuperBitmap.Instance;
      point = prev;
      SuperCanvas.Instance = SuperCanvas.GetInstanceCopy();
      DrawWindow1 = SuperCanvas.Instance;
      SuperBitmap.Instance = SuperBitmap.GetInstanceCopy(); // делаем копию пустого холста, чтобы можно было к нему откатиться через кнопку back
      SuperBitmap.Copies.Add(SuperBitmap.Instance);
      countClick = SuperBitmap.Copies.Count;
    }//инициализация окна для режима растрового рисования

    private void FillWhite()
    {
      int width = (int)DrawWindow.Width;
      int height = (int)DrawWindow.Height;
      int stride = width / 8;
      byte[] pixels = new byte[height * stride];

      var color = new DrawColor(255, 255, 255, 255);
      for (int i = 0; i < width; i++)
      {
        for (int k = 0; k < height; k++)
        {
          var rect = new Int32Rect(i, k, 1, 1);
          SuperBitmap.Instance.WritePixels(rect, color.Instance, 4, 0);
        }
      }
    }

    #region Clicks
    private void Line_Click(object sender, RoutedEventArgs e)//тестовая кнопка при написании вектора
    {
      Line myLine = new Line();
      myLine.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
      myLine.X1 = 1;
      myLine.X2 = 50;
      myLine.Y1 = 1;
      myLine.Y2 = 50;
      myLine.HorizontalAlignment = HorizontalAlignment.Left;
      myLine.VerticalAlignment = VerticalAlignment.Center;
      myLine.StrokeThickness = 2;
      SuperCanvas.Instance.Children.Add(myLine);

      DrawWindow1 = SuperCanvas.Instance;
    }
    private void BtnOpen_Click(object sender, RoutedEventArgs e)
    {
      SuperBitmap.OpenFileDialog();
      DrawWindow.Source = SuperBitmap.Instance;
    }
    private void BtnSave_Click(object sender, RoutedEventArgs e)
    {
      //IDialogService fileDialog = new DefaultDialogService();
      //fileDialog.OpenFileDialog();
      SuperBitmap.SaveFileDialog();
    }
    private void Eraser_Click(object sender, RoutedEventArgs e)
    {
      // cp.SelectedColor = System.Windows.Media.Color.FromArgb(255, 255, 255, 255);
      drawStrategy.SurfaceStrategy.CurrentColor = new DrawColor(255, 255, 255, 255);
      SetState(FigureEnum.Eraser);
      isDrawingFigure = false;
      currentFigure = FigureEnum.Pencil;
    }
    private void BrokenLine_Click(object sender, RoutedEventArgs e)
    {
      SetState(FigureEnum.BrokenLine);
      isDrawingFigure = true;
      isFirstClicked = true;
      currentFigure = FigureEnum.BrokenLine;
    }
    private void Polygon_Click(object sender, RoutedEventArgs e)
    {
      SetState(FigureEnum.Polygon);
      isDrawingFigure = true;
      currentFigure = FigureEnum.Polygon;
    }
    private void buttonLine_Click(object sender, RoutedEventArgs e)
    {
      SetState(FigureEnum.Line);
      isDrawingFigure = true;
      currentFigure = FigureEnum.Line;
    }
    private void Pencil_Click(object sender, RoutedEventArgs e)
    {
      PickColor();
      SetState(FigureEnum.Pencil);
      isDrawingFigure = false;
      currentFigure = FigureEnum.Pencil;
    }
    private void Triangle_Click(object sender, RoutedEventArgs e)
    {
      SetState(FigureEnum.Triangle);
      isDrawingFigure = true;
      currentFigure = FigureEnum.Triangle;
    }
    private void Circle_Click(object sender, RoutedEventArgs e)
    {
      //tbCircle.IsChecked = true;
      SetState(FigureEnum.Circle);
      isDrawingFigure = true;
      currentFigure = FigureEnum.Circle;
    }
    private void Square_Click(object sender, RoutedEventArgs e)
    {
      SetState(FigureEnum.Square);
      isDrawingFigure = true;
      currentFigure = FigureEnum.Square;
    }
    private void Back_Click(object sender, RoutedEventArgs e)
    {
      if (countClick == SuperBitmap.Copies.Count)
        SuperBitmap.Copies.Add(SuperBitmap.Instance);

      if (countClick > 0)
      {
        --countClick;
        SuperBitmap.Instance = SuperBitmap.Copies[countClick];
        DrawWindow.Source = SuperBitmap.Instance;

      }
    }

    private void Next_Click(object sender, RoutedEventArgs e)
    {
      if (countClick < SuperBitmap.Copies.Count - 1)
      {
        ++countClick;
        SuperBitmap.Instance = SuperBitmap.Copies[countClick];
        DrawWindow.Source = SuperBitmap.Instance;
      }
    }
        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateBitmapWindow bitmapWindow = new CreateBitmapWindow();
            bitmapWindow.Owner = this;
            bitmapWindow.Show();
        }




    #endregion

    #region Mouse Methods
    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {

      if (isDoubleClicked && currentFigure == FigureEnum.BrokenLine)
      {
        SuperBitmap.Instance = SuperBitmap.GetInstanceCopy();
        FigureCreator creator = new LineCreator();
        Figure figure = creator.CreateFigure(prev, pStaticStart);
        figure.ConcreteDraw.SurfaceStrategy.ConcreteThickness = new DefaultThickness();
        figure.Draw();
        DrawWindow.Source = SuperBitmap.Instance;
        isDoubleClicked = false;
        isDrawingFigure = false;
        isFirstClicked = true;
      }
      isDoubleClicked = false;
      var temp = e.GetPosition(this.DrawWindow);
      prev = new Point((int)temp.X, (int)temp.Y);
      ddd.Content = $"{prev.X} {prev.Y}";
      if (picker)
      {
        byte[] color = GetPixelColorData(SuperBitmap.Instance, prev);
        cp.SelectedColor = System.Windows.Media.Color.FromArgb(color[3], color[2], color[1], color[0]);
        drawStrategy.SurfaceStrategy.CurrentColor = new DrawColor(color[3], color[2], color[1], color[0]);
        picker = false;
        SetState(FigureEnum.Picker);
      }
      while (filler)
      {
        if (prev.X <= 0 || prev.Y <= 0 || prev.X >= SuperBitmap.Instance.PixelWidth || prev.Y >= SuperBitmap.Instance.PixelHeight)
        {
          filler = false;
          Fill.IsChecked = false;
          break;
        }
        Filling(prev);
        SuperBitmap.Instance = SuperBitmap.GetInstanceCopy();
        filler = false;
        Fill.IsChecked = false;
      }


    }

    private void TakeFigure()
    {
      bool isShiftPressed = Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift);
      bool isCtrlPressed = Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl);
      switch (currentFigure)
      {
        case FigureEnum.Pencil:
          currentCreator = new PencilCreator();
          break;
        case FigureEnum.Circle:
          currentCreator = new CircleCreator();
          break;
        case FigureEnum.Triangle:
          currentCreator = new TriangleCreator(isShiftPressed, isCtrlPressed);
          break;
        case FigureEnum.Line:
          currentCreator = new LineCreator();
          break;
        case FigureEnum.Square:
          currentCreator = new SquareCreator(isShiftPressed);
          break;
        case FigureEnum.Polygon:
          currentCreator = new PolygonCreator(Convert.ToInt32(tbxAngleNumber.Text));
          break;
        case FigureEnum.BrokenLine:
          currentCreator = new BrokenLineCreator();
          break;
      }
    }
    private void Image_MouseMove(object sender, MouseEventArgs e)
    {
      SuperBitmap.CopyInstance();
      
      TakeFigure();

      if (currentCreator == null) return;
      if (isDrawingFigure && prev.X != 0 && prev.Y != 0)//алгоритм рисования в растровом режиме для всех фигур, кроме карандаша
      {
        var temp = e.GetPosition(this.DrawWindow);
        temp = e.GetPosition(this.DrawWindow);
        position = new Point((int)temp.X, (int)temp.Y);
        ddd.Content = $"{position.X} {position.Y}";
        resultFigure = currentCreator.CreateFigure(prev, position);
        resultFigure.ConcreteDraw = drawStrategy;
        resultFigure.Draw();
        DrawWindow.Source = SuperBitmap.GetInstanceCopy();
      }
      if (!isDrawingFigure)//алгоритм рисования в растровом режиме для карандаша
      {
        if (e.LeftButton != MouseButtonState.Pressed) return;
        var temp1 = e.GetPosition(this.DrawWindow);
        ddd.Content = $"{(int)temp1.X}:{(int)temp1.Y}";
        position = new Point((int)temp1.X, (int)temp1.Y);
        resultFigure = currentCreator.CreateFigure(prev, position);
        resultFigure.ConcreteDraw = drawStrategy;
        resultFigure.Draw();
        SuperBitmap.Instance = SuperBitmap.GetInstanceCopy();
        DrawWindow.Source = SuperBitmap.Instance;
        prev = position;
      }
    }
    private void Window_MouseUp(object sender, MouseButtonEventArgs e)
    {
      SuperBitmap.Copies.Add(SuperBitmap.Instance);
      countClick = SuperBitmap.Copies.Count;

      if (isFirstClicked && currentFigure == FigureEnum.BrokenLine)
      {
        pStaticStart = prev;
        isFirstClicked = false;
      }
      if (!isDoubleClicked && currentFigure == FigureEnum.BrokenLine)
      {
        SuperBitmap.Instance = SuperBitmap.GetInstanceCopy();
        isDrawingFigure = true;
        prev = position;
      }
      else if (isDoubleClicked && currentFigure == FigureEnum.BrokenLine)
      {
        SuperBitmap.Instance = SuperBitmap.GetInstanceCopy();
        FigureCreator creator = new LineCreator();
        Figure figure = creator.CreateFigure(position, pStaticStart);
        resultFigure.ConcreteDraw.SurfaceStrategy.ConcreteThickness = new DefaultThickness();
        figure.Draw();
        DrawWindow.Source = SuperBitmap.Instance;
        isDoubleClicked = false;
        isDrawingFigure = false;
        isFirstClicked = true;
      }
      else if (isDrawingFigure && prev.X != 0 && prev.Y != 0)
      {
        SuperBitmap.Instance = SuperBitmap.GetInstanceCopy();
        prev.X = 0;
        prev.Y = 0;
        position.X = 0;
        position.Y = 0;
      }
      else if (isDrawingFigure != true)
      {
        prev.X = 0;
        prev.Y = 0;
        position.X = 0;
        position.Y = 0;
      }
    }
    private void Image_MouseWheel(object sender, MouseWheelEventArgs e)
    {
      var temp = e.MouseDevice.GetPosition(DrawWindow);
      Point p = new Point((int)temp.X, (int)temp.Y);

      Matrix m = DrawWindow.RenderTransform.Value;
      if (e.Delta > 0)
        m.ScaleAtPrepend(1.1, 1.1, p.X, p.Y);
      else
        m.ScaleAtPrepend(1 / 1.1, 1 / 1.1, p.X, p.Y);

      DrawWindow.RenderTransform = new MatrixTransform(m);
    }
    private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
      isDoubleClicked = true;
      if (currentFigure == FigureEnum.BrokenLine)
      {
        var resultCreator = currentCreator.CreateFigure(prev, pStaticStart);
        resultCreator.ConcreteDraw = drawStrategy;
        resultCreator.Draw();
        DrawWindow.Source = SuperBitmap.GetInstanceCopy();
        isFirstClicked = true;
        prev.X = 0;
        prev.Y = 0;
        currentFigure = FigureEnum.Pencil;
        isDrawingFigure = true;
      }
    }


    private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
    {
      

      var tmp = e.GetPosition(this.DrawWindow1);
      position = new Point((int)tmp.X, (int)tmp.Y);
      prev = position;
    }

    private void Canvas_MouseMove(object sender, MouseEventArgs e)
    {
      TakeFigure();
      SuperCanvas.CopyInstance();

      
      if (isDrawingFigure && prev.X != 0 && prev.Y != 0)//алгоритм рисования в растровом режиме для всех фигур, кроме карандаша
      {
        var temp = e.GetPosition(this.DrawWindow1);
        position = new Point((int)temp.X, (int)temp.Y);
        resultFigure = currentCreator.CreateFigure(prev, position);
        resultFigure.ConcreteDraw = drawStrategy;
        resultFigure.Draw();
        DrawWindow1 = SuperCanvas.GetInstanceCopy();
      }

      if (isDrawingFigure) return;
      ddd.Content = e.GetPosition(this.DrawWindow1);
      if (e.LeftButton != MouseButtonState.Pressed) return;
      var tmp = e.GetPosition(this.DrawWindow1);
      prev = position;
      position = new Point((int)tmp.X, (int)tmp.Y);

      drawStrategy.SurfaceStrategy.DrawLine(prev, position);
      DrawWindow1 = SuperCanvas.GetInstanceCopy();

      
    }


    private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
    {
      
    }
    #endregion

    #region Checks
    private void Eraser_Checked(object sender, RoutedEventArgs e)
    {
      picker = true;
      isDrawingFigure = false;
    }
    private void SetState(FigureEnum pressedButton)
    {
      Triangle.IsChecked = false;
      Circle.IsChecked = false;
      Line.IsChecked = false;
      Square.IsChecked = false;
      Polygon.IsChecked = false;
      Pencil.IsChecked = false;
      Picker.IsChecked = false;
      Brokenline.IsChecked = false;
      Eraser.IsChecked = false;
      switch (pressedButton)
      {
        case FigureEnum.Circle:
          Circle.IsChecked = true;
          break;
        case FigureEnum.Triangle:
          Triangle.IsChecked = true;
          break;
        case FigureEnum.Line:
          Line.IsChecked = true;
          break;
        case FigureEnum.Square:
          Square.IsChecked = true;
          break;
        case FigureEnum.Polygon:
          Polygon.IsChecked = true;
          break;
        case FigureEnum.Pencil:
          Pencil.IsChecked = true;
          break;
        case FigureEnum.BrokenLine:
          Brokenline.IsChecked = true;
          break;
        case FigureEnum.Eraser:
          Eraser.IsChecked = true;
          break;
        case FigureEnum.Fill:
          break;

      }
    }
    private void Fill_Checked(object sender, RoutedEventArgs e)
    {
      filler = true;
      isDrawingFigure = false;
      SetState(FigureEnum.Fill);
    }
    private void Clear_Checked(object sender, RoutedEventArgs e)
    {
      SuperBitmap.Instance = new WriteableBitmap((int)DrawWindow.Width,
          (int)DrawWindow.Height, 96, 96, PixelFormats.Bgra32, null);
      DrawWindow.Source = SuperBitmap.Instance;
    }
    #endregion

    #region Changes From UI
    private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      counterToTabControl++;
      if (counterToTabControl % 2 == 0)
      {
        vector = true;
      }
      else
      {
        vector = false;
      }
      if (vector)
      {
        DrawWindow1.Visibility = Visibility.Visible;
        //DrawWindow.Visibility = Visibility.Collapsed;
      }
      else if (vector == false)
      {
        DrawWindow.Visibility = Visibility.Visible;
        //DrawWindow1.Visibility = Visibility.Collapsed;
      }

    }
    private void sliderToPencilSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
      ((Slider)sender).SelectionEnd = e.NewValue;
      switch (sliderToPencilSize.Value)
      {
        case 1:
          drawStrategy.SurfaceStrategy.ConcreteThickness = new DefaultThickness();
          break;
        case 2:
          drawStrategy.SurfaceStrategy.ConcreteThickness = new MediumThickness();
          break;
        case 3:
          drawStrategy.SurfaceStrategy.ConcreteThickness = new BoldThickness();
          break;
        case 4:
          drawStrategy.SurfaceStrategy.ConcreteThickness = new ExtraThickness();
          break;
      }
    }
    private void Cp_OnSelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<System.Windows.Media.Color?> e)
    {
      PickColor();
    }
    private void cp_SelectedColorChanged_1(object sender, RoutedPropertyChangedEventArgs<System.Drawing.Color?> e)
    {
      if (cp.SelectedColor.HasValue)
      {
        drawStrategy.SurfaceStrategy.CurrentColor = new DrawColor(cp.SelectedColor.Value.A,
                                                            cp.SelectedColor.Value.R,
                                                            cp.SelectedColor.Value.G,
                                                            cp.SelectedColor.Value.B);
      }
    }
    private void tbxAngleNumber_Changed(object sender, TextChangedEventArgs e)
    {
      Int32.TryParse(tbxAngleNumber.Text as string, out int value);
      angleNumber = value;
    }
    #endregion

    #region Filling //надо отсюда унести!
    private void PickColor()
    {
      if (cp.SelectedColor.HasValue)
      {
        drawStrategy.SurfaceStrategy.CurrentColor = new DrawColor(cp.SelectedColor.Value.A,
            cp.SelectedColor.Value.R,
            cp.SelectedColor.Value.G,
            cp.SelectedColor.Value.B);
      }
    }
    private byte[] GetPixelColorData(WriteableBitmap bmp, Point prev)
    {
      int bytePerPixel = 4;
      //System.Windows.Media.Color returnColor = new System.Windows.Media.Color();

      int stride = 4 * Convert.ToInt32(bmp.Width);
      byte[] bitmapBytes = new byte[bmp.PixelWidth * bmp.PixelHeight * 4];
      bmp.CopyPixels(bitmapBytes, stride, 0);
      int currentByte = (int)prev.X * bytePerPixel + (stride * (int)prev.Y);
      byte[] color = new byte[] { bitmapBytes[currentByte], bitmapBytes[currentByte + 1], bitmapBytes[currentByte + 2], 255 };
      return color;
    }
    private string GetPixelColor(WriteableBitmap bmp, Point prev)
    {
      int bytePerPixel = 4;
      int stride = 4 * Convert.ToInt32(bmp.Width);
      byte[] bitmapBytes = new byte[bmp.PixelWidth * bmp.PixelHeight * 4];
      bmp.CopyPixels(bitmapBytes, stride, 0);
      int currentByte = (int)prev.X * bytePerPixel + (stride * (int)prev.Y);
      byte[] color = new byte[] { bitmapBytes[currentByte], bitmapBytes[currentByte + 1], bitmapBytes[currentByte + 2], 255 };
      string colorString = "";
      for (int i = 0; i < 4; i++)
      {
        colorString += color[i];
      }
      return colorString;
    }
    private void Filling(Point prev)
    {
      WriteableBitmap bmp = SuperBitmap.GetInstanceCopy();
      string startPixelColor = GetPixelColor(bmp, prev);
      Point tmp = prev;
      //tmp.X = prev.X + 1;

      //  Находим границу слева
      while (tmp.X >= 1 && (GetPixelColor(bmp, tmp) == startPixelColor))
      {
        tmp.X = tmp.X - 1;
      }

      tmp.X = tmp.X + 1;
      Point currentLeft = tmp;

      //  Топаем по строке от левой границы вправо
      while (tmp.X < bmp.PixelWidth && (GetPixelColor(bmp, tmp) == startPixelColor))
      {
        Pixel.SetPixel(tmp, drawStrategy.SurfaceStrategy.CurrentColor);
        tmp.X = tmp.X + 1;
      }
      Point currentRight = tmp;
      int row = currentLeft.Y;

      DrawWindow.Source = SuperBitmap.GetInstanceCopy();


      for (int i = currentLeft.X; i < currentRight.X; i++)
      {

        if (row < bmp.PixelHeight && GetPixelColor(bmp, new Point(i, row + 1)) == startPixelColor)
        {
          Filling(new Point(i, row + 1));

        }
        if (row > 1 && GetPixelColor(bmp, new Point(i, row - 1)) == startPixelColor)
        {
          Filling(new Point(i, row - 1));
        }
      }

    }
    #endregion


    private void Vector_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
      //drawStrategy = new DrawByLine
      //{
      //  SurfaceStrategy = new DrawOnCanvas
      //  {
          
      //  }
      //};
      drawStrategy.SurfaceStrategy = new DrawOnCanvas
      {
        CurrentColor = new DrawColor(255, 0, 0, 255)
        //ConcreteThickness = new DefaultThickness()
      };
    }
  }
}