using GeoAPI.Geometries;

namespace MMaker.Geographics.CoordinateSystems
{
    public class LatLon
    {
        static LatLon()
        {
            Empty = new LatLon(GeoAngle.EmptyLatitude, GeoAngle.EmptyLongitude);
        }

        public LatLon(Coordinate coordinate)
            : this(coordinate.Y, coordinate.X)
        {
        }
        public LatLon(double latitude, double longitude)
        {
            Latitude  = GeoAngle.CreateLatitude(latitude);
            Longitude = GeoAngle.CreateLongitude(longitude);
        }
        public LatLon(GeoAngle latitude, GeoAngle longitude)
        {
            Latitude  = latitude;
            Longitude = longitude;
        }

        public static LatLon Empty { get; private set; }

        public GeoAngle Latitude  { get; private set; }
        public GeoAngle Longitude { get; private set; }

        public override string ToString()
        {
            return $"{Longitude.ToString()} {Latitude.ToString()}";
        }

        public Coordinate ToCoordinate()
        {
            return new GeoAPI.Geometries.Coordinate(Longitude.DecimalDegree, Latitude.DecimalDegree);
        }
    }
}
