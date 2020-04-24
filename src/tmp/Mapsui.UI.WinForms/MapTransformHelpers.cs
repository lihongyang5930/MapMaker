using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapsui.Geometries;

namespace Mapsui.UI.WinForms
{
    public static class MapTransformHelpers
    {
        public static void Pan(IViewport transform, Point currentMap, Point previousMap)
        {
            var current = transform.ScreenToWorld(currentMap.X, currentMap.Y);
            var previous = transform.ScreenToWorld(previousMap.X, previousMap.Y);
            var diffX = previous.X - current.X;
            var diffY = previous.Y - current.Y;
            transform.SetCenter(transform.Center.X + diffX, transform.Center.Y + diffY);
        }
    }
}
