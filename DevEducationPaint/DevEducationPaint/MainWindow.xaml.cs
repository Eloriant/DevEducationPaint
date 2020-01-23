using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevEducationPaint.Drawers;
using DevEducationPaint.FigureCreators;
using DevEducationPaint.Figures;
using Figure = DevEducationPaint.Figures.Figure;

namespace DevEducationPaint
{
    public partial class MainWindow : Window
    {
        private WriteableBitmap writeableBitmap;
        private WriteableBitmap copy;

        private RastrDrawer drawer;

        private int angleNumber = 5;
        private Point prev = new Point(0, 0);
        private Point position = new Point(0, 0);
        private bool isDrawingFigure = false; //флаг сигнализирующий
        private FigureEnum currentFigure;
        public MainWindow()
        {
            InitializeComponent();
            writeableBitmap = new WriteableBitmap(730,
              800, 96, 96, PixelFormats.Bgra32, null);

            Int32.TryParse(tbxAngleNumber.Text as string, out int nValue);
            angleNumber = nValue;

            //Тут получаем синглтон рисовальщика
            drawer = RastrDrawer.GetDrawer();
            //таким видмом ему можно задать цвет, который он будет использовать для рисования всего, что нам нужно
            drawer.pencilColor = System.Drawing.Color.Black;

            DrawWindow.Source = writeableBitmap;
        }
        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (isDrawingFigure)
            {
                writeableBitmap = copy;
                //isDrawingFigure = false;
            }
            prev.X = 0;
            prev.Y = 0;
            position.X = 0;
            position.Y = 0;
            //isDrawingFigure = false;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

            //isDrawingFigure = true;
            // prev = e.GetPosition(sender as IInputElement);
            //ddd.Content = $"{prev.X} {prev.Y}";
            ////SetPixel(prev);
        }
        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            Figure resultFigure;
            FigureCreator currentCreator = null;
            int thickness = Convert.ToInt32(tbxPencilSize.Text);
            switch (currentFigure)
            {
                case FigureEnum.Circle:
                    currentCreator = new CircleCreator();
                    break;
                case FigureEnum.Triangle:
                    currentCreator = new TriangleCreator();
                    break;
            }
            if (currentCreator == null) return;
            resultFigure = currentCreator.CreateFigure(new Point(), new Point(), thickness);
            resultFigure.Draw();

            /////
            if (e.LeftButton != MouseButtonState.Pressed) return;
            var position = e.GetPosition(sender as IInputElement);
            ddd.Content = $"{position.X} {position.Y}";
            if (isDrawingFigure == false && prev.X != 0 && prev.Y != 0)
            {
                position = e.GetPosition(sender as IInputElement);
                drawer.DrawLine(prev, position, writeableBitmap);
            }

            if (isDrawingFigure && prev.X != 0 && prev.Y != 0)
            {

                copy = new WriteableBitmap(writeableBitmap);
                DrawWindow.Source = writeableBitmap;
                position = e.GetPosition(sender as IInputElement);
                drawer.DrawFigure(copy, prev, position, Convert.ToInt32(tbxAngleNumber.Text));
                DrawWindow.Source = copy;
            }
            else
            {
                prev = e.GetPosition(sender as IInputElement);
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
                drawer.pencilColor = System.Drawing.Color.FromArgb(cp.SelectedColor.Value.A,
                                                                    cp.SelectedColor.Value.R,
                                                                    cp.SelectedColor.Value.G,
                                                                    cp.SelectedColor.Value.B);
            }
        }
        private void tbxPencilSize_Changed(object sender, TextChangedEventArgs e)
        {
            //Int32.TryParse(tbxPencilSize.Text as string, out int value);
            //pencilSize = value;
        }

        private void buttonLine_Click(object sender, RoutedEventArgs e)
        {
            isDrawingFigure = true;
            drawer.FigureStrategy = new BrokenLineFigure();
        }

        private void Pencil_Click(object sender, RoutedEventArgs e)
        {
            isDrawingFigure = false;
        }

        private void Triangle_Click(object sender, RoutedEventArgs e)
        {

            isDrawingFigure = true;
            drawer.FigureStrategy = new TriangleFigure();
            currentFigure = FigureEnum.Triangle;
        }

        private void Circle_Click(object sender, RoutedEventArgs e)
        {
            //tbCircle.IsChecked = true;

            isDrawingFigure = true;
            drawer.FigureStrategy = new CircleFigure();
            currentFigure = FigureEnum.Circle;
        }

        private void Square_Click(object sender, RoutedEventArgs e)
        {
            isDrawingFigure = true;
            drawer.FigureStrategy = new SquareFigure();
        }

        private void Polygon_Click(object sender, RoutedEventArgs e)
        {
            isDrawingFigure = true;
            drawer.FigureStrategy = new PolygonFigure();
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

    }
}