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
using DevEducationPaint.Share;
using DevEducationPaint.Strategies;
using DevEducationPaint.Thicknesses;
using Xceed.Wpf.Toolkit;
//using Color = System.Drawing.Color;
using Figure = DevEducationPaint.Figures.Figure;
using Point = System.Drawing.Point;


namespace DevEducationPaint
{
    public partial class MainWindow : Window
    {
        private DrawStrategy currentDrawStrategy;
        Figure resultFigure;
        FigureCreator currentCreator = null;
        private bool isFirstClicked = true;
        private bool isDoubleClicked = false;
        private Point pStaticStart = new Point();
        private int countClick = 0;
        private int angleNumber = 5;
        private Point prev = new Point(0, 0);
        private Point position = new Point(0, 0);
        Point point = new Point(0, 0);
        private bool isDrawingFigure = false; //флаг сигнализирующий
        private bool picker = false;
        private bool filler = false;
        private FigureEnum currentFigure;
        public MainWindow()
        {
            currentDrawStrategy = new DrawByLine
            {
                CurrentColor = new DrawColor(255, 0, 0, 255),
                ConcreteThickness = new BoldThickness()
            };
            InitializeComponent();
            var colors = new List<System.Windows.Media.Color> { Colors.Black, Colors.Black, Colors.Black };
            BitmapPalette myPalette = new BitmapPalette(colors);
            SuperBitmap.Instance = new WriteableBitmap((int)DrawWindow.Width,
              (int)DrawWindow.Height, 96, 96, PixelFormats.Bgra32, null);

            Int32.TryParse(tbxAngleNumber.Text as string, out int nValue);
            angleNumber = nValue;

            FillWhite();
            DrawWindow.Source = SuperBitmap.Instance;
            point = prev;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //if ((countClick < 2) && currentFigure == FigureEnum.BrokenLine)
            //{
            //    countClick++;
            //}
            // if (countClick == 1 && currentFigure == FigureEnum.BrokenLine)
            //{
            //    currentCreator = new BrokenLineCreator();
            //}

            if (isDoubleClicked && currentFigure == FigureEnum.BrokenLine)
            {
                // position = e.GetPosition()
                SuperBitmap.Instance = SuperBitmap.GetInstanceCopy();
                FigureCreator creator = new LineCreator();
                Figure figure = creator.CreateFigure(prev, pStaticStart);
                currentDrawStrategy.ConcreteThickness = new DefaultThickness();
                // SuperBitmap.CopyInstance();
                figure.Draw();
                DrawWindow.Source = SuperBitmap.Instance;
                isDoubleClicked = false;
                isDrawingFigure = false;
                isFirstClicked = true;
            }

            //isDrawingFigure = true;
            // prev = e.GetPosition(sender as IInputElement);
            ////SetPixel(prev);
            //if (e.LeftButton != MouseButtonState.Pressed) return;

            //***
            isDoubleClicked = false;
            var temp = e.GetPosition(this.DrawWindow);
            prev = new Point((int)temp.X, (int)temp.Y);
            ddd.Content = $"{prev.X} {prev.Y}";
            //***

            if (picker)
            {
                byte[] color = GetPixelColorData(SuperBitmap.Instance, prev);
                //cp.AvailableColors.Add(new ColorItem(System.Windows.Media.Color.FromArgb(color[0], color[1], color[2], color[3]), "fromPicker"));
                cp.SelectedColor = System.Windows.Media.Color.FromArgb(color[3], color[2], color[1], color[0]);
                currentDrawStrategy.CurrentColor = new DrawColor(color[3], color[2], color[1], color[0]);
                picker = false;
                SetState(FigureEnum.Picker);

            }

            if (filler)
            {
                Filling(prev);
                filler = false;
                Fill.IsChecked = false;
            }

        }

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
        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            //Figure resultFigure;
            //FigureCreator currentCreator = null;
            SuperBitmap.CopyInstance();
            //var pos = e.GetPosition(this.DrawWindow);
            //ddd.Content = $"{(int)pos.X}:{(int)pos.Y}";

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

            if (currentCreator == null) return;
            //if (e.LeftButton != MouseButtonState.Pressed) return;
            
            //prev = new Point((int)temp.X, (int)temp.Y);

            if (isDrawingFigure && prev.X != 0 && prev.Y != 0)
            {
                var temp = e.GetPosition(this.DrawWindow);
                temp = e.GetPosition(this.DrawWindow);
                position = new Point((int)temp.X, (int)temp.Y);
                ddd.Content = $"{position.X} {position.Y}";
                resultFigure = currentCreator.CreateFigure(prev, position);
                resultFigure.ConcreteDraw = currentDrawStrategy;
                resultFigure.Draw();
                DrawWindow.Source = SuperBitmap.GetInstanceCopy();
                //isDrawingFigure = false;
            }
            if (!isDrawingFigure)
            {
                if (e.LeftButton != MouseButtonState.Pressed) return;
                var temp1 = e.GetPosition(this.DrawWindow);
                ddd.Content = $"{(int)temp1.X}:{(int)temp1.Y}";
                position = new Point((int)temp1.X, (int)temp1.Y);
                resultFigure = currentCreator.CreateFigure(prev, position);
                resultFigure.ConcreteDraw = currentDrawStrategy;
                resultFigure.Draw();
                SuperBitmap.Instance = SuperBitmap.GetInstanceCopy();
                DrawWindow.Source = SuperBitmap.Instance;
                prev = position;
                
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
            //else if (countClick > 1 && currentFigure == FigureEnum.BrokenLine)
            //{
            //    SuperBitmap.Instance = SuperBitmap.GetInstanceCopy();
            //    FigureCreator creator = new LineCreator();
            //    Figure figure = creator.CreateFigure(position, pStaticStart);
            //    currentDrawStrategy.ConcreteThickness = new DefaultThickness();
            //    // SuperBitmap.CopyInstance();
            //    figure.Draw();
            //    DrawWindow.Source = SuperBitmap.Instance;
            //    isDoubleClicked = false;
            //    isDrawingFigure = false;
            //    isFirstClicked = true;

            else if (isDoubleClicked && currentFigure ==  FigureEnum.BrokenLine)
            {
                SuperBitmap.Instance = SuperBitmap.GetInstanceCopy();
                FigureCreator creator = new LineCreator();
                Figure figure = creator.CreateFigure(position, pStaticStart);
                currentDrawStrategy.ConcreteThickness = new DefaultThickness();
               // SuperBitmap.CopyInstance();
                figure.Draw();
                DrawWindow.Source = SuperBitmap.Instance;
                isDoubleClicked = false;
                isDrawingFigure = false;
                isFirstClicked = true;
            }
            else if (isDrawingFigure && prev.X != 0 && prev.Y != 0)
            {
                //var temp = e.GetPosition(sender as IInputElement);
                //temp = e.GetPosition(sender as IInputElement);
                //position = new Point((int)temp.X, (int)temp.Y);
                //isDrawingFigure = false;
                SuperBitmap.Instance = SuperBitmap.GetInstanceCopy();
                prev.X = 0;
                prev.Y = 0;
                position.X = 0;
                position.Y = 0;
            }
            else if (isDrawingFigure!=true)
            {
                prev.X = 0;
                prev.Y = 0;
                position.X = 0;
                position.Y = 0;
            }

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
        private void cp_SelectedColorChanged_1(object sender, RoutedPropertyChangedEventArgs<System.Drawing.Color?> e)
        {
            if (cp.SelectedColor.HasValue)
            {
                currentDrawStrategy.CurrentColor = new DrawColor(cp.SelectedColor.Value.A,
                                                                    cp.SelectedColor.Value.R,
                                                                    cp.SelectedColor.Value.G,
                                                                    cp.SelectedColor.Value.B);
            }
        }
        private void buttonLine_Click(object sender, RoutedEventArgs e)
        {
            SetState(FigureEnum.Line);
            isDrawingFigure = true;
            currentFigure = FigureEnum.Line;
        }

        private void Pencil_Click(object sender, RoutedEventArgs e)
        {
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

        private void Polygon_Click(object sender, RoutedEventArgs e)
        {
            SetState(FigureEnum.Polygon);
            isDrawingFigure = true;
            currentFigure = FigureEnum.Polygon;
        }

        private void tbxAngleNumber_Changed(object sender, TextChangedEventArgs e)
        {
            Int32.TryParse(tbxAngleNumber.Text as string, out int value);
            angleNumber = value;
        }

        private void Fill_Checked(object sender, RoutedEventArgs e)
        {
            filler = true;
            isDrawingFigure = false;
        }

        private void Clear_Checked(object sender, RoutedEventArgs e)
        {
            SuperBitmap.Instance = new WriteableBitmap((int)DrawWindow.Width,
              (int)DrawWindow.Height, 96, 96, PixelFormats.Bgra32, null);
            DrawWindow.Source = SuperBitmap.Instance;
            Clear.IsChecked = false;


        }


        // private void Circle_Clicked(object sender, RoutedEventArgs e)
        // {
        //     SetState(FigureEnum.Circle);
        // }
        //
        // private void Triangle_Clicked(object sender, RoutedEventArgs e)
        // {
        //     SetState(FigureEnum.Triangle);
        // }

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

            }
        }

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

        private void sliderToPencilSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;


            switch (sliderToPencilSize.Value)
            {
                case 1:
                    currentDrawStrategy.ConcreteThickness = new DefaultThickness();
                    break;
                case 2:
                    currentDrawStrategy.ConcreteThickness = new MediumThickness();
                    break;
                case 3:
                    currentDrawStrategy.ConcreteThickness = new BoldThickness();
                    break;
                case 4:
                    currentDrawStrategy.ConcreteThickness = new ExtraThickness();
                    break;
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
                SetPixel(tmp);
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
        private void SetPixel(Point pixelPoint)
        {
            var rect = new System.Windows.Int32Rect(pixelPoint.X, pixelPoint.Y, 1, 1);
            SuperBitmap.GetInstanceCopy().WritePixels(rect, currentDrawStrategy.CurrentColor.Instance, 4, 0);
        }
        private void Eraser_Checked(object sender, RoutedEventArgs e)
        {
            picker = true;
            isDrawingFigure = false;

            //IsChecked = false;
            //byte[] color = GetPixelColorData(SuperBitmap.Instance, prev);
            //cp.AvailableColors.Add(new ColorItem(System.Windows.Media.Color.FromArgb(color[0], color[1], color[2], color[3]), "kuhhiuh"));
            //currentDrawStrategy.CurrentColor = new DrawColor(color[0], color[1], color[2], color[3]);
        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            isDoubleClicked = true;
            if (currentFigure == FigureEnum.BrokenLine)
            {
                // position = e.GetPosition()
                //SuperBitmap.Instance = SuperBitmap.GetInstanceCopy();
                //FigureCreator creator = new LineCreator();
                var resultCreator = currentCreator.CreateFigure(prev, pStaticStart);
                resultCreator.ConcreteDraw = currentDrawStrategy;
                resultCreator.Draw();
                //currentDrawStrategy.ConcreteThickness = new DefaultThickness();
                // SuperBitmap.CopyInstance();
                //currentCreator.Draw();
                DrawWindow.Source = SuperBitmap.GetInstanceCopy();
                isFirstClicked = true;
                prev.X = 0;
                prev.Y = 0;
                currentFigure = FigureEnum.Pencil;
                isDrawingFigure = true;
            }
            // DrawByLine.DrawLine(position, prev);
            //isDrawingFigure = false;
        }

        private void BrokenLine_Click(object sender, RoutedEventArgs e)
        {
            SetState(FigureEnum.BrokenLine);
            isDrawingFigure = true;
            isFirstClicked = true;
            currentFigure = FigureEnum.BrokenLine;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}