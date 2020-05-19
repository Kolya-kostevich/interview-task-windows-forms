using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FiguresPainterLibrary
{
    public class Square : Figure
    {
        private static int _widthHeight = 60;

        public Square(int x, int y, Graphics graph, Color penColor, int penWidth) : base(x, y, graph, penColor, penWidth) { }

        public override void Draw()
        {
            this.Graph.DrawLine(this.Pen, this.X, this.Y, (this.X + Square._widthHeight), this.Y);
            this.Graph.DrawLine(this.Pen, (this.X + Square._widthHeight), this.Y, (this.X + Square._widthHeight), (this.Y + Square._widthHeight));
            this.Graph.DrawLine(this.Pen, (this.X + Square._widthHeight), (this.Y + Square._widthHeight), this.X, (this.Y + Square._widthHeight));
            this.Graph.DrawLine(this.Pen, this.X, (this.Y + Square._widthHeight), this.X, this.Y);
        }
    }
}
