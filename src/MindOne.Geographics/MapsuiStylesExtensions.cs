using System;
using Mapsui.Styles;
using Brush = Mapsui.Styles.Brush;
using Color = Mapsui.Styles.Color;
using Pen   = Mapsui.Styles.Pen;
using Style = Mapsui.Styles.Style;

namespace MindOne.Geographics
{
    public static class MapsuiStylesExtensions
    {
        public static IStyle Copy(this IStyle source)
        {
            if (source is SymbolStyle symbolStyle)
            {
                var result = new SymbolStyle();
                return Copy(symbolStyle, result);
            }
            if (source is VectorStyle vectorStyle)
            {
                var result = new VectorStyle();
                return Copy(vectorStyle, result);
            }
            if (source is Style style)
            {
                var result = new Style();
                return Copy(style, result);
            }
            throw new NotImplementedException();
        }
        private static SymbolStyle Copy(SymbolStyle source, SymbolStyle dest)
        {
            dest.BitmapId       = source.BitmapId;
            dest.SymbolScale    = source.SymbolScale;
            dest.SymbolOffset   = source.SymbolOffset.Copy();
            dest.SymbolRotation = source.SymbolRotation;
            dest.RotateWithMap  = source.RotateWithMap;
            dest.UnitType       = source.UnitType;
            dest.SymbolType     = source.SymbolType;
            Copy((VectorStyle)source, dest);
            return dest;
        }
        private static VectorStyle Copy(this VectorStyle source, VectorStyle dest)
        {
            dest.Line    = source.Line.Copy();
            dest.Outline = source.Line.Copy();
            dest.Fill    = source.Fill.Copy();
            Copy((Style)source, dest);
            return dest;
        }
        private static Style Copy(Style source, Style dest)
        {
            dest.MinVisible = source.MinVisible;
            dest.MaxVisible = source.MaxVisible;
            dest.Enabled    = source.Enabled;
            dest.Opacity    = source.Opacity;
            return dest;
        }

        public static Pen Copy(this Pen pen)
        {
            if (pen == null)
                return null;
            return new Pen { 
                Width            = pen.Width,
                Color            = pen.Color.Copy(),
                PenStyle         = pen.PenStyle,
                DashArray        = pen.DashArray,
                PenStrokeCap     = pen.PenStrokeCap,
                StrokeJoin       = pen.StrokeJoin,
                StrokeMiterLimit = pen.StrokeMiterLimit
            };
        }
        public static Brush Copy(this Brush brush)
        {
            if (brush == null)
                return null;
            return new Brush { 
                Color       = brush.Color.Copy(),
                Background  = brush.Background.Copy(),
                BitmapId    = brush.BitmapId,
                FillStyle   = brush.FillStyle
            };
        }
        public static Color Copy(this Color color)
        {
            if (color == null)
                return null;
            return new Color(color.R, color.G, color.B, color.A);
        }
        public static Offset Copy(this Offset offset)
        {
            return new Offset(offset.X, offset.Y, offset.IsRelative);
        }

        public static Color ToMapsui(this System.Windows.Media.Color color)
        {
            return new Color(color.R, color.G,color.B, color.A);
        }
        public static Brush ToMapsui(this System.Windows.Media.SolidColorBrush brush)
        {
            var c = brush.Color.ToMapsui();
            var b = new Brush(c);
            return b;
        }
    }
}
