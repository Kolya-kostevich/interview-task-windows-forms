using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace FiguresPainter
{
    interface IDraw
    {
        void Draw();
    }

    class Line : IDraw
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

        public Line (int x1, int y1, int x2, int y2, Graphics graph, Color penColor, int penWidth, LineCap? startArrow = null, LineCap? endArrow = null, DashStyle? lineStyle = null)
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

    class Rhombus : Figure
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

    class Square : Figure
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

    class Triangle : Figure
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

    class Circle : Figure
    {
        private static int _width = 45;
        private static int _height = 45;

        public Circle(int x, int y, Graphics graph, Color penColor, int penWidth) : base(x, y, graph, penColor, penWidth) { }

        public override void Draw()
        {
            this.Graph.DrawEllipse(this.Pen, this.X, this.Y, Circle._width, Circle._height);
        }
    }

    public partial class FiguresPainter : Form
    {
        public FiguresPainter()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics gObject = canvas.CreateGraphics();

            Triangle triangle1 = new Triangle(500, 95, gObject, Color.Red, 8);
            Triangle triangle2 = new Triangle(100, 350, gObject, Color.Red, 8);
            Circle circle1 = new Circle(450, 225, gObject, Color.Red, 8);
            Square square1 = new Square(50, 50, gObject, Color.Red, 8);
            Rhombus rhombus1 = new Rhombus(630, 250, gObject, Color.Red, 8);
            Circle circle2 = new Circle(630, 380, gObject, Color.Red, 8);

            Line line1 = new Line(110, 75, 445, 235, gObject, Color.Red, 8, LineCap.ArrowAnchor, LineCap.ArrowAnchor);
            Line line2 = new Line(550, 105, 480, 215, gObject, Color.Red, 8, LineCap.ArrowAnchor, null , DashStyle.Dot);
            Line line3 = new Line(80, 110, 120, 320, gObject, Color.Red, 8, LineCap.ArrowAnchor, LineCap.ArrowAnchor, DashStyle.Dash);
            Line line4 = new Line(500, 245, 600, 250, gObject, Color.Red, 8, LineCap.ArrowAnchor, null, DashStyle.Dot);
            Line line5 = new Line(210, 320, 615, 260, gObject, Color.Red, 8, LineCap.ArrowAnchor, null, DashStyle.DashDotDot);


            IDraw[] figuresAndLines = new IDraw[] { triangle1, triangle2, circle1, square1, rhombus1, circle2, line1, line2, line3, line4, line5 };

            foreach(var element in figuresAndLines)
            {
                element.Draw();
            }
        }
    }
}
