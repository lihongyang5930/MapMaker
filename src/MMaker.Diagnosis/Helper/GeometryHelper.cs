using GeoAPI.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMaker.Diagnosis.Helper
{
    public static class GeometryHelper
    {
        /// <summary>
        /// Line Type의 두 객체의 교차점 반환
        /// </summary>
        /// <returns></returns>
        public static IPoint CrossedPoint(IGeometry g1, IGeometry g2)
        {
            if (!g1.Crosses(g2))
                return null;

            var g = g1.Difference(g2);
            if (g == null || g.IsEmpty)
                return null;

            return g?.InteriorPoint;
        }

        public static bool IsEqualLocation(IPoint g1, IPoint g2)
        {
            return IsEqualLocation(g1.Coordinate, g2.Coordinate);
        }

        public static bool IsEqualLocation(Coordinate g1, Coordinate g2)
        {
            return g1.Equals(g2);
        }
    }
}
