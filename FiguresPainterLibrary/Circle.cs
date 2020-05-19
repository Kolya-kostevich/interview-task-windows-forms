using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FiguresPainterLibrary
{
    public class Circle : Figure
    {
        private static int _width = 45;
        private static int _height = 45;

        public Circle(int x, int y, Graphics graph, Color penColor, int penWidth) : base(x, y, graph, penColor, penWidth) { }

        public override void Draw()
        {
            this.Graph.DrawEllipse(this.Pen, this.X, this.Y, Circle._width, Circle._height);
        }
    }
}
