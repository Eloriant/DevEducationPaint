using System;
using System.Collections.Generic;
using System.Drawing;
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
using DevEducationPaint.Drawers;
using DevEducationPaint.FigureCreators;
using DevEducationPaint.Figures;
using DevEducationPaint.Share;
using DevEducationPaint.Strategies;
using DevEducationPaint.Thicknesses;
using Color = System.Drawing.Color;
using Figure = DevEducationPaint.Figures.Figure;
using Point = System.Drawing.Point;

namespace DevEducationPaint
{
    public partial class MainWindow : Window
    {
        private WriteableBitmap writeableBitmap;
        private WriteableBitmap copy;

        private RastrDrawer drawer;
        private DrawStrategy currentDrawStrategy;

        private int angleNumber = 5;
        private Point prev = new Point(0, 0);
        private Point position = new Point(0, 0);
        Point point = new Point(0, 0);
        private bool isDrawingFigure = false; //флаг сигнализирующий
        private FigureEnum currentFigure;
        public MainWindow()
        {
            InitializeComponent();
            SuperBitmap.Instance = new WriteableBitmap(730,
              800, 96, 96, PixelFormats.Bgra32, null);
            WriteableBitmap instance = SuperBitmap.Instance;
            writeableBitmap = new WriteableBitmap(730,
              800, 96, 96, PixelFormats.Bgra32, null);

            Int32.TryParse(tbxAngleNumber.Text as string, out int nValue);
            angleNumber = nValue;

            ////Тут получаем синглтон рисовальщика
            //drawer = RastrDrawer.GetDrawer();
            ////таким видмом ему можно задать цвет, который он будет использовать для рисования всего, что нам нужно
            //drawer.pencilColor = System.Drawing.Color.Black;

            DrawWindow.Source = writeableBitmap;
            point = prev;
            //currentDrawStrategy = new DrawByLine
            //{
            //  CurrentColor = new DrawColor(255, 0, 0, 255),
            //  ConcreteThickness = new DefaultThickness()
            //};

            //      currentDrawStrategy.DrawLineWithThickness(new Point(0,0), new Point(100,100));
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isDrawingFigure = true;
            // prev = e.GetPosition(sender as IInputElement);
            ////SetPixel(prev);
            if (e.LeftButton != MouseButtonState.Pressed) return;
            var temp = e.GetPosition(sender as IInputElement);
            prev = new Point((int)temp.X, (int)temp.Y);
            ddd.Content = $"{prev.X} {prev.Y}";
            //===============================
            currentDrawStrategy = new DrawByLine
            {
                CurrentColor = new DrawColor(255, 0, 0, 255),
                ConcreteThickness = new BoldThickness()

            };

        currentDrawStrategy.DrawLineWithThickness(new Point(), new Point());
        }

    private void Image_MouseMove(object sender, MouseEventArgs e)
    {
        Figure resultFigure;
        FigureCreator currentCreator = null;

        SuperBitmap.CopyInstance();

        switch (currentFigure)
        {
            case FigureEnum.Circle:
                currentCreator = new CircleCreator();
                break;
            case FigureEnum.Triangle:
                currentCreator = new TriangleCreator();
                break;
            case FigureEnum.Line:
                currentCreator = new LineCreator();
                break;
            case FigureEnum.Square:
                currentCreator = new SquareCreator();
                break;
            case FigureEnum.Polygon:
                //currentCreator = new PolygonCreator();
                break;
        }

        if (currentCreator == null) return;
        //if (e.LeftButton != MouseButtonState.Pressed) return;
        var temp = e.GetPosition(sender as IInputElement);
        //prev = new Point((int)temp.X, (int)temp.Y);

        if (prev.X != 0 && prev.Y != 0)
        {
            temp = e.GetPosition(sender as IInputElement);
            position = new Point((int)temp.X, (int)temp.Y);
            ddd.Content = $"{position.X} {position.Y}";
            resultFigure = currentCreator.CreateFigure(prev, position);
            resultFigure.ConcreteDraw = currentDrawStrategy;
            resultFigure.Draw();
            DrawWindow.Source = SuperBitmap.GetInstanceCopy();
            //isDrawingFigure = false;
        }
    }
    private void Window_MouseUp(object sender, MouseButtonEventArgs e)
    {
        //if (isDrawingFigure)
        //{
            //writeableBitmap = copy;
            //isDrawingFigure = false;
            //prev.X = 0;
            //prev.Y = 0;
            //position.X = 0;
            //position.Y = 0;
            if (prev.X != 0 && prev.Y != 0)
            {
                //var temp = e.GetPosition(sender as IInputElement);
                //temp = e.GetPosition(sender as IInputElement);
                //position = new Point((int)temp.X, (int)temp.Y);
                isDrawingFigure = false;
                SuperBitmap.Instance = SuperBitmap.GetInstanceCopy();
                prev.X = 0;
                prev.Y = 0;
                position.X = 0;
                position.Y = 0;
            }
        //}
    }
      
      //
      //var temp = e.GetPosition(sender as IInputElement);
      //Point position = new Point((int)temp.X, (int)temp.Y);
      
      //if (isDrawingFigure == false && prev.X != 0 && prev.Y != 0)
      //{
      //  temp = e.GetPosition(sender as IInputElement);
      //  position = new Point((int)temp.X, (int)temp.Y);
      //  drawer.DrawLine(prev, position, writeableBitmap);
      //}

      //if (isDrawingFigure && prev.X != 0 && prev.Y != 0)
      //{

      //  copy = new WriteableBitmap(writeableBitmap);
      //  DrawWindow.Source = writeableBitmap;
      //  temp = e.GetPosition(sender as IInputElement);
      //  position = new Point((int)temp.X, (int)temp.Y);
      //  drawer.DrawFigure(copy, prev, position, Convert.ToInt32(tbxAngleNumber.Text));
      //  DrawWindow.Source = copy;
      //}
      //else
      //{
      //  temp = e.GetPosition(sender as IInputElement);
      //  prev = new Point((int)temp.X, (int)temp.Y);
      //}
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
    private void cp_SelectedColorChanged_1(object sender, RoutedPropertyChangedEventArgs<Color?> e)
    {
      if (cp.SelectedColor.HasValue)
      {
        currentDrawStrategy.CurrentColor = new DrawColor(cp.SelectedColor.Value.A,
                                                            cp.SelectedColor.Value.R,
                                                            cp.SelectedColor.Value.G,
                                                            cp.SelectedColor.Value.B);
      }
    }
    private void tbxPencilSize_Changed(object sender, TextChangedEventArgs e)
    {
    //if (tbxPencilSize.Text != null)
    //    {
    //        int.TryParse(tbxPencilSize.Text as string, out int pencilSize);
    //        int penciLSize = Convert.ToInt32(tbxPencilSize.Text);
    //        point = prev;
    //        if (penciLSize == 1)
    //        {
    //            currentDrawStrategy.ConcreteThickness = new DefaultThickness(point);
    //        }
    //        else if (penciLSize == 2)
    //        {
    //            currentDrawStrategy.ConcreteThickness = new MediumThickness(point);
    //        }
    //        else if (penciLSize == 2)
    //        {
    //            currentDrawStrategy.ConcreteThickness = new BoldThickness(point);
    //        }
    //    }
    //switch (pencilSize)
    //{
    //    case 1:
    //        currentDrawStrategy.ConcreteThickness = new DefaultThickness();
    //        break;
    //    case 2:
    //        currentDrawStrategy.ConcreteThickness = new MediumThickness();
    //        break;
    //    case 3:
    //        currentDrawStrategy.ConcreteThickness = new BoldThickness();
    //        break;
    //}
    }

     private void buttonLine_Click(object sender, RoutedEventArgs e)
     {
         isDrawingFigure = true;
         currentFigure = FigureEnum.Line;

     }

    private void Pencil_Click(object sender, RoutedEventArgs e)
    {
      isDrawingFigure = false;
    }

    private void Triangle_Click(object sender, RoutedEventArgs e)
    {

      isDrawingFigure = true;
      currentFigure = FigureEnum.Triangle;
    }

    private void Circle_Click(object sender, RoutedEventArgs e)
    {
      //tbCircle.IsChecked = true;

      isDrawingFigure = true;
      currentFigure = FigureEnum.Circle;
    }

    private void Square_Click(object sender, RoutedEventArgs e)
    {
      isDrawingFigure = true;
      currentFigure = FigureEnum.Square;
    }

    private void Polygon_Click(object sender, RoutedEventArgs e)
    {
      isDrawingFigure = true;
      currentFigure = FigureEnum.Polygon;
    }

    private void tbxAngleNumber_Changed(object sender, TextChangedEventArgs e)
    {
      Int32.TryParse(tbxAngleNumber.Text as string, out int value);
      angleNumber = value;
    }

    private void Eraser_Checked(object sender, RoutedEventArgs e)
    {

    }

    private void Fill_Checked(object sender, RoutedEventArgs e)
    {

    }

    private void Clear_Checked(object sender, RoutedEventArgs e)
    {

    }


    //private void tbCircle_Clicked(object sender, RoutedEventArgs e)
    //{
    //    SetState(FigureEnum.Circle);
    //}

    //private void tbTriangle_Clicked(object sender, RoutedEventArgs e)
    //{
    //    SetState(FigureEnum.Triangle);
    //}

    //private void SetState(FigureEnum pressedButton)
    //{
    //    tbTriangle.IsChecked = false;
    //    tbCircle.IsChecked = false;

    //    switch (pressedButton)
    //    {
    //        case FigureEnum.Circle:
    //            tbCircle.IsChecked = true;
    //            break;
    //        case FigureEnum.Triangle:
    //            tbTriangle.IsChecked = true;
    //            break;
    //    }
    //}

    private void Cp_OnSelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<System.Windows.Media.Color?> e)
    {
      if (cp.SelectedColor.HasValue)
      {
        currentDrawStrategy.CurrentColor = new DrawColor(cp.SelectedColor.Value.A,
          cp.SelectedColor.Value.R,
          cp.SelectedColor.Value.G,
          cp.SelectedColor.Value.B);
      }
    }
    }
}