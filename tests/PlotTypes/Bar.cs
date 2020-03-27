using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ScottPlotTests.PlotTypes
{
    public class Bar
    {
        private ScottPlot.Bar RandomBar(Random rand, double maxPosition, double maxY, double maxYbase, double maxErr)
        {
            double valueBase = rand.NextDouble() * maxYbase;
            double value = rand.NextDouble() * maxY + valueBase;
            double error = rand.NextDouble() * maxErr;
            double position = rand.NextDouble() * maxPosition;

            return new ScottPlot.Bar(position, value, error, valueBase);
        }

        private ScottPlot.Bar[] RandomBars(Random rand, int barCount = 5, double maxPosition = 50, double maxY = 200, double maxYbase = 50, double maxErr = 25)
        {
            ScottPlot.Bar[] bars = new ScottPlot.Bar[barCount];
            for (int i = 0; i < barCount; i++)
                bars[i] = RandomBar(rand, maxPosition, maxY, maxYbase, maxErr);
            return bars;
        }

        private ScottPlot.Bar[] RandomConsecutiveBars(Random rand, int barCount = 10)
        {
            ScottPlot.Bar[] bars = new ScottPlot.Bar[barCount];
            for (int i = 0; i < barCount; i++)
            {
                var bar = RandomBar(rand, 0, 100, 0, 20);
                bar.position = i;
                bars[i] = bar;
            }
            return bars;
        }

        [Test]
        public void Test_Bar_HoldsData()
        {
            double x = 31;
            double y = 123;
            double yErr = 12;
            double yOffset = 10;

            var bar = new ScottPlot.Bar(x, y, yErr, yOffset);

            Assert.AreEqual("Bar at 31 from 10 to 123 +/- 12", bar.ToString());
            Assert.AreEqual(x, bar.position);
            Assert.AreEqual(y, bar.value);
            Assert.AreEqual(yErr, bar.error);
            Assert.AreEqual(yOffset, bar.valueBase);
        }

        [Test]
        public void Test_BarSeries_SingleSeries()
        {
            Random rand = new Random(0);

            ScottPlot.Bar[] bars = RandomBars(rand);

            ScottPlot.BarSeries series1 = new ScottPlot.BarSeries(bars, "series1") { fillColor = Color.Green };

            var plottableBar = new ScottPlot.PlottableBar(series1);

            var plt = new ScottPlot.Plot();
            plt.Add(plottableBar);
            plt.Legend();
            TestTools.SaveFig(plt);
        }

        [Test]
        public void Test_BarSeries_MultiSeries()
        {
            Random rand = new Random(0);

            var series1 = new ScottPlot.BarSeries(RandomBars(rand)) { label = "series1", fillColor = Color.Red };
            var series2 = new ScottPlot.BarSeries(RandomBars(rand)) { label = "series2", fillColor = Color.Green };
            var series3 = new ScottPlot.BarSeries(RandomBars(rand)) { label = "series3", fillColor = Color.Blue };

            var multiSeries = new ScottPlot.BarSeries[] { series1, series2, series3 };

            var plottableBar = new ScottPlot.PlottableBar(multiSeries);

            var plt = new ScottPlot.Plot();
            plt.Add(plottableBar);
            plt.Legend();

            TestTools.SaveFig(plt);
        }

        [Test]
        public void Test_PlotBar_DefinePositionAndValue()
        {
            Random rand = new Random(0);
            ScottPlot.BarSeries barSeries = new ScottPlot.BarSeries(RandomConsecutiveBars(rand));

            var plottableBar = new ScottPlot.PlottableBar(barSeries);

            var plt = new ScottPlot.Plot();
            plt.Add(plottableBar);
            plt.Legend();

            TestTools.SaveFig(plt);
        }
    }
}
