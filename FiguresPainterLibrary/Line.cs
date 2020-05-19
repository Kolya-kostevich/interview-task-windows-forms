using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FiguresPainterLibrary
{
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

        private void DrawArrows(int x, int y, LineCap arrowType)
        {
            switch(arrowType)
            {
               
            }
        }

        public void Draw()
        {
            this._graph.DrawLine(this._pen, this._x1, this._y1, this._x2, this._y2);
        }
    }
}
