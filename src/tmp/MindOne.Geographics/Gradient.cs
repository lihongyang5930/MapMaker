using System;
using System.Linq;
using System.Windows.Media;

namespace MindOne.Geographics
{
    public class Gradient
    {
        bool                _canFreeze;
        LinearGradientBrush _brush;
        GradientStop[]      _stops;

        public Gradient(double maximum, int roundDigits)
        {
            _brush      = new LinearGradientBrush();
            _canFreeze  = true;
            Maximum     = maximum;
            RoundDigits = roundDigits;
        }

        public double Maximum  { get; set; }
        public int RoundDigits { get; set; }

        public void AddGradientStop(Color color, double offset)
        {
            _brush.GradientStops.Add(new GradientStop(color, offset));
        }

        public void Freeze()
        {
            _brush.Freeze();
            _canFreeze = false;
            _stops     = _brush.GradientStops.OrderBy(x => x.Offset).ToArray();
        }

        public Color GetColor(double value)
        {
            if (_canFreeze)
                Freeze();
            return GetColorByOffset(value);

            if (value >= 0)
            {
                var offset = Math.Round(value / Maximum, RoundDigits);
                return GetColorByOffset(offset);
            }
            else
            if (value < 0)
            {
                return Colors.Gray;
            }
            else
            {
                return Colors.Black;
            }
        }

        private Color GetColorByOffset(double offset)
        {
            // https://stackoverflow.com/questions/9650049/get-color-in-specific-location-on-gradient
            //if (offset <= 0) return _stops[0].Color;
            //if (offset >= 1) return _stops[_stops.Length - 1].Color;



            var left  = _stops[0];
            var right = default(GradientStop);
            foreach (var stop in _stops)
            {
                if (stop.Offset >= offset)
                {
                    right = stop;
                    break;
                }
                left = stop;
            }
            offset = (offset - left.Offset) / (right.Offset - left.Offset);
            byte a = (byte)((right.Color.A - left.Color.A) * offset + left.Color.A);
            byte r = (byte)((right.Color.R - left.Color.R) * offset + left.Color.R);
            byte g = (byte)((right.Color.G - left.Color.G) * offset + left.Color.G);
            byte b = (byte)((right.Color.B - left.Color.B) * offset + left.Color.B);
            return Color.FromArgb(a, r, g, b);
        }
    }
}
