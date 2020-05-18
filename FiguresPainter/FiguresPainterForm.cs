using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using FiguresPainterLibrary;

namespace FiguresPainter
{

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
