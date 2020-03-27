using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ScottPlot
{
    public class BarSeries
    {
        public Bar[] bars;
        public string label;

        public bool fill = true;
        public bool outline = true;
        public double errorCapWidth = .38;

        public Brush fillBrush;
        public Pen outlinePen;
        public Pen errorPen;

        private Color _fillColor;
        public Color fillColor
        {
            get { return _fillColor; }
            set { _fillColor = value; fillBrush = new SolidBrush(value); }
        }

        public BarSeries(Bar[] bars, string label = null)
        {
            if (bars is null)
                throw new ArgumentException("bars array cannot be null");

            this.bars = bars;
            this.label = label;
            InitializeDrawingTools();
        }

        [Obsolete("pass in a Bar[] instead")]
        public BarSeries(double[] positions, double[] values, double[] errors, string label = null)
        {
            if (positions == null)
                throw new ArgumentException("positions array cannot be null");

            if (values == null || values.Length != positions.Length)
                throw new ArgumentException("values array must be same length as positions array");

            if (errors == null || errors.Length != positions.Length)
                throw new ArgumentException("errors array must be same length as positions array");

            bars = new Bar[positions.Length];
            for (int i = 0; i < positions.Length; i++)
                bars[i] = new Bar(positions[i], values[i], errors[i]);

            this.label = label;
            InitializeDrawingTools();
        }

        private void InitializeDrawingTools()
        {
            outlinePen = new Pen(color: Color.Black, width: 2);
            errorPen = new Pen(color: Color.Black, width: 2);
            fillColor = Color.Gray;
        }

        public override string ToString()
        {
            return $"BarSeries with {bars.Length} bars";
        }

        public void Render(Settings settings)
        {
            foreach (Bar bar in bars)
                bar.RenderVertical(settings, fillBrush, outline, outlinePen, errorCapWidth, errorPen);
        }
    }
}
