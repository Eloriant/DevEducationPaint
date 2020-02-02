using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;

namespace DevEducationPaint.Bitmap
{
    public class SuperBitmap
    {

        private static List<WriteableBitmap> copies;
        private static WriteableBitmap instance;
        private static WriteableBitmap instanceCopy;

        public static WriteableBitmap Instance
        {
            get => instance; 
            set

            {
                instance = value;
                instanceCopy = new WriteableBitmap(value);
            }
        }
        public static List<WriteableBitmap> Copies
        {
            get
            {
                if (copies == null)
                {
                    copies = new List<WriteableBitmap>();
                }
                return copies;
            }
            set

            {
                copies = value;
            }
        }

        public static void CopyInstance()
        {
            if (instance != null)
                instanceCopy = new WriteableBitmap(Instance);
        }

        public static WriteableBitmap GetInstanceCopy()
        {
            if (instanceCopy == null && instance != null)
                instanceCopy = new WriteableBitmap(Instance);
            return instanceCopy;
        }

        private static string FilePath { get; set; }

        //BitmapImage bitmap = new BitmapImage(new Uri("YourImage.jpg", UriKind.Relative));
        //WriteableBitmap writeableBitmap = new WriteableBitmap(bitmap);
        public static void OpenFileDialog()
        {
            // Save the bitmap into a file.
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image(*.jpg)| *.jpg";
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                BitmapImage bitmap = new BitmapImage(new Uri(FilePath, UriKind.Relative));
                instance = new WriteableBitmap(bitmap);
            }
        }

        public static void SaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image(*.jpg)| *.jpg";
            if (saveFileDialog.ShowDialog() == true)
            {
                FilePath = saveFileDialog.FileName;
                using (FileStream stream =
                new FileStream(FilePath, FileMode.Create))
                {
                    PngBitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(instance));
                    encoder.Save(stream);
                }
            }
        }
    }
}
