using System.Windows.Media.Imaging;

namespace DevEducationPaint.Bitmap
{
    public class SuperBitmap
    {
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
    }
}
