using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresPainterLibrary
{
    public interface IDraw
    {
        void Draw();
    }

    public class Line : IDraw
    {
        private int _x1;
        private int _y1;
        private int _x2;
        private int _y2;
        private LineCap _startArrow = LineCap.Flat;
        private LineCap _endArrow = LineCap.Flat;
        private DashStyle _lineStyle = DashStyle.Solid;
        private Graphics _graph;
        private Pen _pen;

        public Line(int x1, int y1, int x2, int y2, Graphics graph, Color penColor, int penWidth, LineCap? startArrow = null, LineCap? endArrow = null, DashStyle? lineStyle = null)
        {
            Brush brushForPen = new SolidBrush(penColor);

            this._x1 = x1;
            this._y1 = y1;
            this._x2 = x2;
            this._y2 = y2;

            this._startArrow = startArrow ?? this._startArrow;
            this._endArrow = endArrow ?? this._endArrow;
            this._lineStyle = lineStyle ?? this._lineStyle;
            this._graph = graph;

            this._pen = new Pen(brushForPen, penWidth);
            this._pen.StartCap = this._startArrow;
            this._pen.EndCap = this._endArrow;
            this._pen.DashStyle = this._lineStyle;
        }

        public void Draw()
        {
            this._graph.DrawLine(this._pen, this._x1, this._y1, this._x2, this._y2);
        }
    }

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

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
