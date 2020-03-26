﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScottPlotTests.PlotTypes
{
    public class Bar
    {
        [Test]
        public void Test_barSingleSet_valuesOnly()
        {
            var votes = new double[] { 33706, 36813, 12496 };
            var groups = new string[] { "Debian", "SuSE", "Red Hat" };

            var plt = new ScottPlot.Plot(400, 300);
            plt.PlotBar(votes, groups);

            plt.Title("Favorite Linux Distribution");
            plt.YLabel("Respondants");
            plt.Grid(enableVertical: false);
            plt.Axis(y1: 0);
            plt.Ticks(useMultiplierNotation: false);
            plt.XTicks(labels: groups);
            plt.Legend();

            TestTools.SaveFig(plt);
        }

        [Test]
        public void Test_barSingleSet_valuesAndErrors()
        {
            var votes = new double[] { 33706, 36813, 12496 };
            var errors = new double[] { 2660, 3580, 1950 };
            var groups = new string[] { "Debian", "SuSE", "Red Hat" };

            var plt = new ScottPlot.Plot(400, 300);
            plt.PlotBar(votes, groups, errors);

            plt.Title("Favorite Linux Distribution");
            plt.YLabel("Respondants");
            plt.Grid(enableVertical: false);
            plt.Axis(y1: 0);
            plt.Ticks(useMultiplierNotation: false);
            plt.XTicks(labels: groups);
            plt.Legend();

            TestTools.SaveFig(plt);
        }

        [Test]
        public void Test_barMultipleSets_valuesOnly()
        {
            // series-level variables
            var votesWork = new ScottPlot.DataSet("Work", new double[] { 33706, 36813, 12496 });
            var votesHobby = new ScottPlot.DataSet("Hobby", new double[] { 34930, 33400, 12843 });

            // group-level variables
            var groups = new string[] { "Debian", "SuSE", "Red Hat" };
            ScottPlot.DataSet[] dataSets = new ScottPlot.DataSet[] { votesWork, votesHobby };

            // make the plot
            var plt = new ScottPlot.Plot(400, 300);
            plt.PlotBar(dataSets, groups);

            plt.Title("Favorite Linux Distribution");
            plt.YLabel("Respondants");
            plt.Grid(enableVertical: false);
            plt.Axis(y1: 0);
            plt.Ticks(useMultiplierNotation: false);
            plt.XTicks(labels: groups);
            plt.Legend(location: ScottPlot.legendLocation.upperRight);

            TestTools.SaveFig(plt);
        }

        [Test]
        public void Test_barMultipleSets_Horizontal_Stacked()
        {
            // series-level variables
            var votesWork = new ScottPlot.DataSet("Work", new double[] { 33706, 36813, 12496 });
            var votesHobby = new ScottPlot.DataSet("Hobby", new double[] { 34930, 33400, 12843 });

            // group-level variables
            var groups = new string[] { "Debian", "SuSE", "Red Hat" };
            ScottPlot.DataSet[] dataSets = new ScottPlot.DataSet[] { votesWork, votesHobby };

            // make the plot
            var plt = new ScottPlot.Plot(400, 300);
            plt.PlotBar(dataSets, groups, stacked: true, horizontal: true, outlineWidth: 1);

            plt.Title("Favorite Linux Distribution");
            plt.XLabel("Respondants");
            plt.Grid(enableHorizontal: false);
            plt.Ticks(useMultiplierNotation: false);
            plt.YTicks(labels: groups);
            plt.Legend(location: ScottPlot.legendLocation.upperRight);

            TestTools.SaveFig(plt);
        }

        [Test]
        public void Test_barMultipleSets_Horizontal_Grouped()
        {
            // series-level variables
            var votesWork = new ScottPlot.DataSet("Work", new double[] { 33706, 36813, 12496 }, new double[] { 3000, 2000, 1000 });
            var votesHobby = new ScottPlot.DataSet("Hobby", new double[] { 34930, 33400, 12843 }, new double[] { 3000, 2000, 1000 });

            // group-level variables
            var groups = new string[] { "Debian", "SuSE", "Red Hat" };
            ScottPlot.DataSet[] dataSets = new ScottPlot.DataSet[] { votesWork, votesHobby };

            // make the plot
            var plt = new ScottPlot.Plot(400, 300);
            plt.PlotBar(dataSets, groups, horizontal: true, outlineWidth: 1);

            plt.Title("Favorite Linux Distribution");
            plt.XLabel("Respondants");
            plt.Grid(enableHorizontal: false);
            plt.Ticks(useMultiplierNotation: false);
            plt.YTicks(labels: groups);
            plt.Legend(location: ScottPlot.legendLocation.upperRight);

            TestTools.SaveFig(plt);
        }

        [Test]
        public void Test_barMultipleSets_valuesWithError()
        {
            // series-level variables
            var votesWork = new ScottPlot.DataSet(label: "Work",
                values: new double[] { 33706, 36813, 12496 },
                errors: new double[] { 2456, 3456, 2345 });

            var votesHobby = new ScottPlot.DataSet(label: "Hobby",
                new double[] { 34930, 33400, 12843 },
                new double[] { 2456, 3456, 2345 }
                );

            // group-level variables
            var groups = new string[] { "Debian", "SuSE", "Red Hat" };
            ScottPlot.DataSet[] dataSets = new ScottPlot.DataSet[] { votesWork, votesHobby };

            // make the plot
            var plt = new ScottPlot.Plot(400, 300);
            plt.PlotBar(dataSets, groups);

            plt.Title("Favorite Linux Distribution");
            plt.YLabel("Respondants");
            plt.Grid(enableVertical: false);
            plt.Axis(y1: 0);
            plt.Ticks(useMultiplierNotation: false);
            plt.XTicks(labels: groups);
            plt.Legend(location: ScottPlot.legendLocation.upperRight);

            TestTools.SaveFig(plt);
        }

        [Test]
        public void Test_barSingleSet_GivenPositions()
        {
            var plt = new ScottPlot.Plot(400, 300);

            var population = new double[] { 2556, 3039, 3706, 4453, 5278, 6082, 6848, 7584, 8246, 8850, 9346 };
            var year = new double[] { 1950, 1960, 1970, 1980, 1990, 2000, 2010, 2020, 2030, 2040, 2050 };

            // create the bar graph
            plt.PlotBar(population, xs: year);

            // further improve the style of the plot
            plt.Title("World Population");
            plt.YLabel("Millions of People");
            plt.XLabel("Year");
            plt.Axis(y1: 0);
            plt.Ticks(useMultiplierNotation: false, useOffsetNotation: false);

            TestTools.SaveFig(plt);
        }
    }
}
