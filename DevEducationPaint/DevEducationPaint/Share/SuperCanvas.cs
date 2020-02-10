using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using DevEducationPaint.Figures;

namespace DevEducationPaint.Share
{
    public class SuperCanvas
    {
        private static List<Canvas> copies;
        private static Canvas instance;
        private static Canvas instanceCopy;
        private static List<VectorFigure> listVectorFigures;
        public static VectorFigure CurrentFigure;
        public static Canvas Instance
        {
            get => instance;
            set
            {
                instance = value;
                instanceCopy = instance;
            }
        }

        public static List<VectorFigure> ListVectorFigures
        {
            get
            {
                if (listVectorFigures == null)
                {
                    listVectorFigures = new List<VectorFigure>();
                }

                return listVectorFigures;
            }
            set => listVectorFigures = value;
        }

        public static List<Canvas> Copies
        {
            get
            {
                if (copies == null)
                {
                    copies = new List<Canvas>();
                }
                return copies;
            }
            set => copies = value;
        }

        public static void CopyInstance()
        {
            if (instance != null)
                instanceCopy = instance;
        }

        public static Canvas GetInstanceCopy()
        {
            if (instanceCopy == null && instance != null)
                instanceCopy = instance;
            return instanceCopy;
        }

        public static void RemoveChildrenByTag()
        {
            //List<int> indexes = new List<int>();
            for (int i = instance.Children.Count - 1; i > 0; i--)
            {
                FrameworkElement child = (FrameworkElement)GetInstanceCopy().Children[i];
                if (child.Tag == CurrentFigure)
                  GetInstanceCopy().Children.Remove(child);
            }

            int еьз = 2;
        }
    }
}
