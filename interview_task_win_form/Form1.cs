using System.Drawing;
using System.Windows.Forms;

namespace interview_task_win_form
{
    abstract class Figure
    {
        public abstract void DrawFigure(int x, int y, Graphics gObject, Pen pen);
        public static void DrawLine(int x1, int y1, int x2, int y2, Graphics gObject, Pen pen)
        {
            gObject.DrawLine(pen, x1, y1, x2, y2);
        }

    }

    class Rhombus : Figure
    {
        private static int width = 50;
        private static int height = 50;

        public override void DrawFigure(int x, int y, Graphics gObject, Pen pen)
        {
            gObject.DrawLine(pen, x, y, (x + Rhombus.width), (y - Rhombus.height));
            gObject.DrawLine(pen, (x + Rhombus.width), (y - Rhombus.height), (x + (Rhombus.width * 2)), y);
            gObject.DrawLine(pen, x, y, (x + Rhombus.width), (y + Rhombus.height));
            gObject.DrawLine(pen, (x + Rhombus.width), (y + Rhombus.height), (x + (Rhombus.width * 2)), y);
        }
    }

    class Square : Figure
    {
        private static int widthHeight = 60;

        public override void DrawFigure(int x, int y, Graphics gObject, Pen pen)
        {
            gObject.DrawLine(pen, x, y, (x + Square.widthHeight), y);
            gObject.DrawLine(pen, (x + Square.widthHeight), y, (x + Square.widthHeight), (y + Square.widthHeight));
            gObject.DrawLine(pen, (x + Square.widthHeight), (y + Square.widthHeight), x, (y + Square.widthHeight));
            gObject.DrawLine(pen, x, (y + Square.widthHeight), x, y);
        }
    }

    class Triangle : Figure
    {
        private static int width = 60;
        private static int height = 60;

        public override void DrawFigure(int x, int y, Graphics gObject, Pen pen)
        {

            gObject.DrawLine(pen, x, y, (x + Triangle.width), (y - Triangle.height));
            gObject.DrawLine(pen, (x + Triangle.width), (y - Triangle.height), (x + (Triangle.width * 2)), y);
            gObject.DrawLine(pen, x, y, (x + (Triangle.width * 2)), y);
        }
    }

    class Circle : Figure
    {
        private static int width = 45;
        private static int height = 45;

        public override void DrawFigure(int x, int y, Graphics gObject, Pen pen)
        {
            gObject.DrawEllipse(pen, x, y, Circle.width, Circle.height);
        }
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics gObject = canvas.CreateGraphics();

            Brush redBrush = new SolidBrush(Color.Red);

            /* For Drawing Figures */

            Pen redPen = new Pen(redBrush, 8);

            /* End For Drawing Figures */

            /* For Drawing Lines */

            Pen redLineDoubleArrowsPen = new Pen(redBrush, 8);
            Pen redLineDottedsStartArrowPen = new Pen(redBrush, 8);
            Pen redLineDashStartArrowPen = new Pen(redBrush, 8);
            Pen redLineStartArrowPen = new Pen(redBrush, 8);

            redLineDoubleArrowsPen.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            redLineDoubleArrowsPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

            redLineDottedsStartArrowPen.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            redLineDottedsStartArrowPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            redLineDashStartArrowPen.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            redLineDashStartArrowPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            redLineDashStartArrowPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            redLineStartArrowPen.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

            /* End For Drawing Lines */

            Triangle triangle1 = new Triangle();
            Triangle triangle2 = new Triangle();
            Circle circle1 = new Circle();
            Square square1 = new Square();
            Rhombus rhombus1 = new Rhombus();
            Circle circle2 = new Circle();

            triangle1.DrawFigure(500, 95, gObject, redPen);
            triangle2.DrawFigure(100, 350, gObject, redPen);
            circle1.DrawFigure(450, 225, gObject, redPen);
            square1.DrawFigure(50, 50, gObject, redPen);
            rhombus1.DrawFigure(630, 250, gObject, redPen);
            circle2.DrawFigure(630, 380, gObject, redPen);

            Figure.DrawLine(110, 75, 445, 235, gObject, redLineDoubleArrowsPen);
            Figure.DrawLine(550, 105, 480, 215, gObject, redLineDottedsStartArrowPen);
            Figure.DrawLine(80, 110, 120, 320, gObject, redLineDashStartArrowPen);
            Figure.DrawLine(500, 245, 600, 250, gObject, redLineDottedsStartArrowPen);
            Figure.DrawLine(210, 320, 615, 260, gObject, redLineStartArrowPen);

        }
    }
}
