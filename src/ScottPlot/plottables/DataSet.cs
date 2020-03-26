using System;
using System.Collections.Generic;
using System.Text;

namespace ScottPlot
{
    /// <summary>
    /// Represents a series of data values with a common name. Values from several DataSets can be grouped (by value index).
    /// </summary>
    public class DataSet
    {
        public string label;
        public double[] values;
        public double[] errors;
        public double[] positions;

        public DataSet(string label, double[] values, double[] errors = null, double[] positions = null)
        {
            if (errors != null && errors.Length != values.Length)
                throw new ArgumentException("positions must have identical length to values");

            if (positions != null && positions.Length != values.Length)
                throw new ArgumentException("positions must have identical length to values");

            this.values = values;
            this.label = label;
            this.errors = errors;
            this.positions = (positions is null) ? DataGen.Consecutive(values.Length) : positions;
        }
    }
}
