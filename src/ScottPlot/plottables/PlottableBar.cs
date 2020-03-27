using ScottPlot.Config;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ScottPlot
{
    public class PlottableBar : Plottable
    {
        public bool vertical = true;
        public string label;
        BarSeries[] barSeries;

        public PlottableBar(BarSeries barSeries, string label = null)
        {
            this.barSeries = new BarSeries[] { barSeries };
            this.label = label;
        }

        public PlottableBar(BarSeries[] barSeries, string label = null)
        {
            this.barSeries = barSeries;
            this.label = label;
        }

        public override LegendItem[] GetLegendItems()
        {
            var items = new List<LegendItem>();
            for (int i = 0; i < barSeries.Length; i++)
                items.Add(new LegendItem(barSeries[i].label, barSeries[i].fillColor, lineWidth: 10, markerShape: MarkerShape.none));
            return items.ToArray();
        }

        public override AxisLimits2D GetLimits()
        {
            double valueMax = double.NegativeInfinity;
            double valueMin = double.PositiveInfinity;
            double positionMax = double.NegativeInfinity;
            double positionMin = double.PositiveInfinity;

            double maxBarWidth = 0;
            foreach (var bs in barSeries)
            {
                maxBarWidth = Math.Max(maxBarWidth, bs.bars[0].barWidth);
                for (int i = 0; i < bs.bars.Length; i++)
                {
                    valueMax = Math.Max(valueMax, bs.bars[i].value + bs.bars[i].error);
                    valueMin = Math.Min(valueMin, bs.bars[i].value - bs.bars[i].error);
                    valueMax = Math.Max(valueMax, bs.bars[i].valueBase);
                    valueMin = Math.Min(valueMin, bs.bars[i].valueBase);
                    positionMax = Math.Max(positionMax, bs.bars[i].position);
                    positionMin = Math.Min(positionMin, bs.bars[i].position);
                }
            }
            positionMin -= maxBarWidth / 2;
            positionMax += maxBarWidth / 2;

            // TODO: add bar width padding

            if (vertical)
                return new AxisLimits2D(positionMin, positionMax, valueMin, valueMax);
            else
                return new AxisLimits2D(valueMin, valueMax, positionMin, positionMax);
        }

        public override int GetPointCount()
        {
            int pointCount = 0;
            foreach (var bs in barSeries)
                pointCount += bs.bars.Length;
            return pointCount;
        }

        public override void Render(Settings settings)
        {
            for (int seriesIndex = 0; seriesIndex < barSeries.Length; seriesIndex++)
            {
                var series = barSeries[seriesIndex];
                series.Render(settings);
            }
        }

        public override string ToString()
        {
            return $"PlottableBar with {GetPointCount()} points";
        }
    }
}
