using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FiguresPainterLibrary
{
    public abstract class Figure : IDraw
    {
        protected static float PenWidthDefault = 8.0f;

        protected int X;
        protected int Y;
        protected Graphics Graph;
        protected Pen Pen;

        public Figure(int x, int y, Graphics graph, Color penColor, float? penWidth)
        {
            float penWidthCalculated = penWidth.HasValue && penWidth > 0 ? penWidth.Value : PenWidthDefault;

            Brush brushForPen = new SolidBrush(penColor);

            this.X = x;
            this.Y = y;
            this.Graph = graph;
            this.Pen = new Pen(brushForPen, penWidthCalculated);
        }

        public abstract void Draw();
    }
}
