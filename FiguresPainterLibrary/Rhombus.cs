using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FiguresPainterLibrary
{
    public class Rhombus : Figure
    {
        private static int _width = 50;
        private static int _height = 50;

        public Rhombus(int x, int y, Graphics graph, Color penColor, int penWidth) : base(x, y, graph, penColor, penWidth) { }

        public override void Draw()
        {
            this.Graph.DrawLine(this.Pen, this.X, this.Y, (this.X + Rhombus._width), (this.Y - Rhombus._height));
            this.Graph.DrawLine(this.Pen, (this.X + Rhombus._width), (this.Y - Rhombus._height), (this.X + (Rhombus._width * 2)), this.Y);
            this.Graph.DrawLine(this.Pen, this.X, this.Y, (this.X + Rhombus._width), (this.Y + Rhombus._height));
            this.Graph.DrawLine(this.Pen, (this.X + Rhombus._width), (this.Y + Rhombus._height), (this.X + (Rhombus._width * 2)), this.Y);
        }
    }
}
