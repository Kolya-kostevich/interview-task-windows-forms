using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FiguresPainterLibrary
{
    public class Triangle : Figure
    {
        private static int _width = 60;
        private static int _height = 60;

        public Triangle(int x, int y, Graphics graph, Color penColor, int penWidth) : base(x, y, graph, penColor, penWidth) { }

        public override void Draw()
        {
            this.Graph.DrawLine(this.Pen, this.X, this.Y, (this.X + Triangle._width), (this.Y - Triangle._height));
            this.Graph.DrawLine(this.Pen, (this.X + Triangle._width), (this.Y - Triangle._height), (this.X + (Triangle._width * 2)), this.Y);
            this.Graph.DrawLine(this.Pen, this.X, this.Y, (this.X + (Triangle._width * 2)), this.Y);
        }
    }
}
