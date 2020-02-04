using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace DevEducationPaint.Share
{
  public class SuperCanvas
  {
    private static List<Canvas> copies;
    private static Canvas instance;
    private static Canvas instanceCopy;

    public static Canvas Instance
    {
      get => instance;
      set
      {
        instance = value;
        instanceCopy = instance;
      }
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
  }
}
