using System;
using System.Collections.Generic;
using System.Text;

namespace DevEducationPaint.FigureCreators.AbstractFactory.Interfaces
{
    interface IFigure
    {
        public void Draw(bool isVector);
    }
}
