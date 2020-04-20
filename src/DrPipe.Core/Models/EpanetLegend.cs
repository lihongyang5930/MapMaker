using System;
using System.Drawing;

namespace DrPipe.Core.Models
{
    public class EpanetLegend
    {
        public EpanetLegend(string title, string unit, Color[] colors, double[] boundaryValues)
        {
            if (colors.Length != boundaryValues.Length + 1)
            {
                throw new ArgumentOutOfRangeException(nameof(boundaryValues));
            }
            Title          = title;
            Unit           = unit;
            Colors         = colors;
            BoundaryValues = boundaryValues;
        }
        public string   Title          { get; private set; }
        public string   Unit           { get; private set; }
        public Color[]  Colors         { get; private set; }
        public double[] BoundaryValues { get; private set; }
    }
}
