using System;
using CoordinateSharp;

namespace MMaker.Geographics.CoordinateSystems
{
    public class GeoAngle
    {
        CoordinatePart _part;
        string _toString;

        static GeoAngle()
        {
            EmptyLatitude  = new GeoAngle(GeoAnglePosition.N, 0, 0, 0d);
            EmptyLongitude = new GeoAngle(GeoAnglePosition.E, 0, 0, 0d);
        }
        private GeoAngle(double value, CoordinateType type)
        {
            DecimalDegree = value;

            _part    = new CoordinatePart(value, type);
            Degrees  = _part.Degrees;
            Minutes  = _part.Minutes;
            Seconds  = _part.Seconds;
            Position = (GeoAnglePosition)_part.Position;
            Dms      = $"{Degrees}°{Minutes}'{Math.Round(Seconds, 2)}\"";
        }
        private GeoAngle(GeoAnglePosition position, int degrees, int minutes, double seconds)
        {
            _part = new CoordinatePart(degrees, minutes, seconds, (CoordinatesPosition)position);
            Position = position;
            Degrees  = degrees;
            Minutes  = minutes;
            Seconds  = seconds;
            Dms      = $"{Degrees}°{Minutes}'{Math.Round(Seconds, 2)}\"";
            DecimalDegree = _part.DecimalDegree;
        }

        #region Create
        public static GeoAngle CreateLatitude(double latitude)
        {
            return new GeoAngle(latitude, CoordinateType.Lat);
        }
        public static GeoAngle CreateLongitude(double longitude)
        {
            return new GeoAngle(longitude, CoordinateType.Long);
        }

        public static GeoAngle CreateLatitude(int degrees, int minutes, double seconds)
        {
            return new GeoAngle(GeoAnglePosition.N, degrees, minutes, seconds);
        }
        public static GeoAngle CreateLongitude(int degrees, int minutes, double seconds)
        {
            return new GeoAngle(GeoAnglePosition.E, degrees, minutes, seconds);
        }
        #endregion

        public GeoAnglePosition Position { get; private set; }
        public int    Degrees       { get; private set; }
        public int    Minutes       { get; private set; }
        public double Seconds       { get; private set; }
        public double DecimalDegree { get; private set; }

        public string Dms           { get; private set; }

        public static GeoAngle EmptyLatitude  { get; private set; }
        public static GeoAngle EmptyLongitude { get; private set; }

        public override string ToString()
        {
            if (_toString == null)
            {
                _toString = $"{Position} {Dms}";
            }
            return _toString;
        }
        public override bool Equals(object obj)
        {
            var other = obj as GeoAngle;
            if (other == null)
                return false;
            return DecimalDegree == other.DecimalDegree;
        }
        public override int GetHashCode()
        {
            return DecimalDegree.GetHashCode();
        }
    }
}
