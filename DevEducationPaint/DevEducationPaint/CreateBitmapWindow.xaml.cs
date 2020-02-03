using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DevEducationPaint
{
    /// <summary>
    /// Interaction logic for CreateBitmapWindow.xaml
    /// </summary>
    public partial class CreateBitmapWindow : Window
    {
        public CreateBitmapWindow()
        {
            InitializeComponent();
        }

        private void Default_Checked(object sender, RoutedEventArgs e)
        {
            Height.Text = "580";
            Width.Text = "800";
            Height.IsEnabled = false;
            Width.IsEnabled = false;

        }
        private void Default_Click(object sender, RoutedEventArgs e)
        {
            if (Default.IsChecked == false)
            {
                Height.IsEnabled = true;
                Width.IsEnabled = true;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            //this.Owner.DrawWindow.Height = Convert.ToInt32(Height.Text);
            //this.Owner.DrawWindow1.Height = Convert.ToInt32(Height.Text);
            //this.Owner.DrawWindow.Width = Convert.ToInt32(Width.Text);
            //this.Owner.DrawWindow1.Width = Convert.ToInt32(Width.Text);
        }

    }
}
