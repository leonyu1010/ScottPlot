using NUnit.Framework;
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

            // TODO
        }

        [Test]
        public void Test_barSingleSet_valuesAndErrors()
        {
            var votes = new double[] { 33706, 36813, 12496 };
            var errors = new double[] { 2660, 3580, 1950 };
            var groups = new string[] { "Debian", "SuSE", "Red Hat" };

            // TODO
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

            // TODO
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

            // TODO
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

            // TODO
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

            // TODO
        }

        [Test]
        public void Test_barSingleSet_GivenPositions()
        {
            var plt = new ScottPlot.Plot(400, 300);

            var population = new double[] { 2556, 3039, 3706, 4453, 5278, 6082, 6848, 7584, 8246, 8850, 9346 };
            var year = new double[] { 1950, 1960, 1970, 1980, 1990, 2000, 2010, 2020, 2030, 2040, 2050 };

            // TODO
        }
    }
}
