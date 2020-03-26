using System;
using System.Collections.Generic;
using System.Text;

namespace ScottPlot.Demo.PlotTypes
{
    class Bar
    {
        public class Quickstart : PlotDemo, IPlotDemo
        {
            public string name { get; } = "Simple Bar Graph";
            public string description { get; } = "To plot a single series of data as a bar graph, send the data directly to the PlotBar() function.";

            public void Render(Plot plt)
            {
                var votes = new double[] { 33706, 36813, 12496 };
                var groups = new string[] { "Debian", "SuSE", "Red Hat" };

                // TODO: plot these data
            }
        }

        public class DefineXs : PlotDemo, IPlotDemo
        {
            public string name { get; } = "Bar Graph with Defined Xs";
            public string description { get; } = "This example demonstrates how to make a bar chart at specific X coordinates.";

            public void Render(Plot plt)
            {
                var population = new double[] { 2556, 3039, 3706, 4453, 5278, 6082, 6848, 7584, 8246, 8850, 9346 };
                var year = new double[] { 1950, 1960, 1970, 1980, 1990, 2000, 2010, 2020, 2030, 2040, 2050 };

                // TODO: plot these data
            }
        }

        public class BarAngled : PlotDemo, IPlotDemo
        {
            public string name { get; } = "Bar Graph with Angled Labels";
            public string description { get; } = "When using a large number of groups, labels can be rotated improve space utilization.";

            public void Render(Plot plt)
            {
                var values = new double[] { 7, 12, 40, 40,
                    100, 125, 172, 550, 560, 600, 2496, 2789 };

                var errors = new double[] { 4, 5, 15, 17,
                    43, 62, 86, 258, 297, 312, 345, 543 };

                var groups = new string[] { "ant", "bird", "mouse",
                    "human", "cat", "dog", "frog", "lion", "elephant",
                    "horse", "shark", "hippo" };

                // TODO: plot these data
            }
        }

        public class BarMulti : PlotDemo, IPlotDemo
        {
            public string name { get; } = "Multi-Series Bar Graphs";
            public string description { get; } = "Bar graphs with multiple bar series can be displayed, organized into groups. Building a DataSet array and send it to the PlotBar() method.";

            public void Render(Plot plt)
            {
                // define series-level data
                var barSetMen = new DataSet(label: "Men",
                    values: new double[] { 15, 22, 45, 17 },
                    errors: new double[] { 6, 3, 8, 4 });

                var barSetWomen = new DataSet(label: "Women",
                    values: new double[] { 37, 21, 29, 13 },
                    errors: new double[] { 7, 5, 6, 3 });

                // define group-level data
                var dataSets = new DataSet[] { barSetMen, barSetWomen };
                var groupLabels = new string[] {
                    "Always", "Regularly", "Sometimes", "Never" };

                // TODO: plot these data
            }
        }

        public class BarStacked : PlotDemo, IPlotDemo
        {
            public string name { get; } = "Stacked Bar Graphs";
            public string description { get; } = "Use the 'stacked' argument to display stacked bar graphs.";

            public void Render(Plot plt)
            {
                // define series-level data
                var barSetMen = new DataSet(label: "Men",
                    values: new double[] { 15, 22, 45, 17 },
                    errors: new double[] { 6, 3, 8, 4 });

                var barSetWomen = new DataSet(label: "Women",
                    values: new double[] { 37, 21, 29, 13 },
                    errors: new double[] { 7, 5, 6, 3 });

                // define group-level data
                var dataSets = new DataSet[] { barSetMen, barSetWomen };
                var groupLabels = new string[] {
                    "Always", "Regularly", "Sometimes", "Never" };

                // TODO: plot these data
            }
        }

        public class BarHorizontal : PlotDemo, IPlotDemo
        {
            public string name { get; } = "Horizontal Bar Graph";
            public string description { get; } = "Use the 'horizontal' argumen to display bar graphs horizontally.";

            public void Render(Plot plt)
            {
                // define series-level data
                var barSetMen = new DataSet(label: "Men",
                    values: new double[] { 15, 22, 45, 17 },
                    errors: new double[] { 6, 3, 8, 4 });

                var barSetWomen = new DataSet(label: "Women",
                    values: new double[] { 37, 21, 29, 13 },
                    errors: new double[] { 7, 5, 6, 3 });

                // define group-level data
                var dataSets = new DataSet[] { barSetMen, barSetWomen };
                var groupLabels = new string[] {
                    "Always", "Regularly", "Sometimes", "Never" };

                // TODO: plot these data
            }
        }
    }
}
