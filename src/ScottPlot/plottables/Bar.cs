using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ScottPlot
{
    public class Bar
    {
        public double value;
        public double error;
        public double position;
        public double barWidth = .8;//TODO: customize
        public double valueBase;

        public double edge1 { get { return position - barWidth / 2; } }
        public double edge2 { get { return position + barWidth / 2; } }
        public double error1 { get { return value - error; } }
        public double error2 { get { return value + error; } }
        public double value1 { get { return Math.Min(value, valueBase); } }
        public double value2 { get { return Math.Max(value, valueBase); } }
        public double valueSpan { get { return Math.Abs(value - valueBase); } }

        public Bar(double position, double value, double error = 0, double valueBase = 0, double barWidth = .8)
        {
            this.value = value;
            this.valueBase = valueBase;
            this.error = Math.Abs(error);
            this.position = position;
            this.barWidth = barWidth;
        }

        public override string ToString()
        {
            return $"Bar at {position} from {valueBase} to {value} +/- {error}";
        }

        public void RenderVertical(Settings settings, Brush fillBrush, bool outline, Pen outlinePen, double errorCapWidth, Pen errorPen)
        {
            var rect = new RectangleF(
                x: (float)settings.GetPixelX(edge1),
                y: (float)settings.GetPixelY(value2),
                width: (float)(barWidth * settings.xAxisScale),
                height: (float)(valueSpan * settings.yAxisScale));

            settings.gfxData.FillRectangle(fillBrush, rect.X, rect.Y, rect.Width, rect.Height);

            if (outline)
                settings.gfxData.DrawRectangle(outlinePen, rect.X, rect.Y, rect.Width, rect.Height);

            if (error > 0)
            {
                float centerPx = (float)settings.GetPixelX(position);
                float capPx1 = (float)settings.GetPixelX(position - errorCapWidth * barWidth / 2);
                float capPx2 = (float)settings.GetPixelX(position + errorCapWidth * barWidth / 2);
                float errorPx2 = (float)settings.GetPixelY(error2);
                float errorPx1 = (float)settings.GetPixelY(error1);

                settings.gfxData.DrawLine(errorPen, centerPx, errorPx1, centerPx, errorPx2);
                settings.gfxData.DrawLine(errorPen, capPx1, errorPx1, capPx2, errorPx1);
                settings.gfxData.DrawLine(errorPen, capPx1, errorPx2, capPx2, errorPx2);
            }
        }
    }
}