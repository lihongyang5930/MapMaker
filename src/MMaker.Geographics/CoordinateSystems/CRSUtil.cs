using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DotSpatial.Projections;
using GeoAPI.Geometries;

namespace MMaker.Geographics.CoordinateSystems
{
    public class CRSUtil
    {
        const string _regexPattern  = @"(?<=[Ee][Pp][Ss][Gg][:\.\d]+)\d{4}"; // ex) urn:ogc:def:crs:EPSG:6.18.3:3857 => 3857
        static Dictionary<int, ProjectionInfo> _cache;

        //public static void Load(string directoryName)
        //{
        //    var coords = Web.EpsgWebService.LoadLocal(directoryName);
        //    _cache = coords.ToDictionary(x => x.Code, x => x);
        //}

        static CRSUtil()
        {
            _cache = new Dictionary<int, ProjectionInfo>();
            _cache.Add(2096, ProjectionInfo.FromProj4String(_2096));
            _cache.Add(4326, ProjectionInfo.FromProj4String(_4326));
            _cache.Add(3857, ProjectionInfo.FromProj4String(_3857));
            _cache.Add(5181, ProjectionInfo.FromProj4String(_5181));
        }

        public static ProjectionInfo EPSG4326 => Get("EPSG:4326");
        public static ProjectionInfo EPSG5181 => Get("EPSG:5181");
        public static ProjectionInfo EPSG3857 => Get("EPSG:3857");

        public static int ParseEpsgCode(string crs)
        {
            if (crs == null)
                throw new ArgumentNullException();
            var match = Regex.Match(crs, _regexPattern);
            if (match.Success)
            {
                return int.Parse(match.Value);
            }
            throw new FormatException();
        }
        public static bool TryParseEpsgCode(string crs, out int epsgcode)
        {
            if (crs != null)
            {
                var match = Regex.Match(crs, _regexPattern);
                if (match.Success)
                {
                    var value = match.Value;
                    if (int.TryParse(value, out epsgcode))
                    {
                        return true;
                    }
                }
            }
            epsgcode = 0;
            return false;
        }
        public static string Simplify(string crs)
        {
            // urn:ogc:def:crs:EPSG:6.18.3:3857 => EPSG:3857
            if (TryParseEpsgCode(crs, out int code))
            {
                return "EPSG:" + code;
            }
            return crs;
        }
        public static bool IsSupported(string crs)
        {
            if (TryParseEpsgCode(crs, out int code) && _cache.ContainsKey(code))
            {
                return true;
            }
            return false;
        }

        public static ProjectionInfo Get(string crs)
        {
            if (TryParseEpsgCode(crs, out int code))
            {
                return _cache[code];
            }
            return null;
        }

        //public static LatLon ToLatLon(string crs, double x, double y)
        //{
        //    return ToLatLon(crs, new Coordinate(x, y));
        //}
        //public static LatLon ToLatLon(string crs, Coordinate coordinate)
        //{
        //    var from        = Get(crs);
        //    var to          = EPSG4326;
        //    var transformed = Transform(from, to, coordinate);
        //    return new LatLon(transformed);
        //}
        ////public static Coordinate FromLatLon(string crs, GeoAngle latitude, GeoAngle longitude)
        ////{
        ////   return FromLatLon(crs, new LatLon(latitude, longitude));
        ////}
        //public static Coordinate FromLatLon(string crs, LatLon latLon)
        //{
        //    var from        = EPSG4326;
        //    var to          = Get(crs);
        //    var transformed = Transform(from, to, latLon.ToCoordinate());
        //    return transformed;
        //}

        public static Coordinate Transform(ProjectionInfo from, ProjectionInfo to, Coordinate coordinate)
        {
            return Transform(from, to, coordinate.X, coordinate.Y);
        }
        public static Coordinate Transform(ProjectionInfo from, ProjectionInfo to, double x, double y)
        {
            var xy   = new double[] { x, y };
            var z    = new double[] { 0 };
            Reproject.ReprojectPoints(xy, z, from, to, 0, 1);
            return new Coordinate(xy[0], xy[1]);
        }

        #region EPSG
        const string _2096 = "{  \"code\": \"2096\",  \"kind\": \"CRS-PROJCRS\",  \"bbox\": [    38.64,    128.0,    34.49,    129.65  ],  \"wkt\": \"PROJCS[\\\"Korean 1985 / East Belt\\\",GEOGCS[\\\"Korean 1985\\\",DATUM[\\\"Korean_Datum_1985\\\",SPHEROID[\\\"Bessel 1841\\\",6377397.155,299.1528128,AUTHORITY[\\\"EPSG\\\",\\\"7004\\\"]],AUTHORITY[\\\"EPSG\\\",\\\"6162\\\"]],PRIMEM[\\\"Greenwich\\\",0,AUTHORITY[\\\"EPSG\\\",\\\"8901\\\"]],UNIT[\\\"degree\\\",0.0174532925199433,AUTHORITY[\\\"EPSG\\\",\\\"9122\\\"]],AUTHORITY[\\\"EPSG\\\",\\\"4162\\\"]],PROJECTION[\\\"Transverse_Mercator\\\"],PARAMETER[\\\"latitude_of_origin\\\",38],PARAMETER[\\\"central_meridian\\\",129],PARAMETER[\\\"scale_factor\\\",1],PARAMETER[\\\"false_easting\\\",200000],PARAMETER[\\\"false_northing\\\",500000],UNIT[\\\"metre\\\",1,AUTHORITY[\\\"EPSG\\\",\\\"9001\\\"]],AUTHORITY[\\\"EPSG\\\",\\\"2096\\\"]]\",  \"unit\": \"metre\",  \"proj4\": \"+proj=tmerc +lat_0=38 +lon_0=129 +k=1 +x_0=200000 +y_0=500000 +ellps=bessel +units=m +no_defs\",  \"name\": \"Korean 1985 / East Belt\",  \"area\": \"Republic of Korea (South Korea) - onshore east of 128°E.\"}";
        const string _4326 = "{  \"code\": \"4326\",  \"kind\": \"CRS-GEOGCRS\",  \"bbox\": [    90.0,    -180.0,    -90.0,    180.0  ],  \"wkt\": \"GEOGCS[\\\"WGS 84\\\",DATUM[\\\"WGS_1984\\\",SPHEROID[\\\"WGS 84\\\",6378137,298.257223563,AUTHORITY[\\\"EPSG\\\",\\\"7030\\\"]],AUTHORITY[\\\"EPSG\\\",\\\"6326\\\"]],PRIMEM[\\\"Greenwich\\\",0,AUTHORITY[\\\"EPSG\\\",\\\"8901\\\"]],UNIT[\\\"degree\\\",0.0174532925199433,AUTHORITY[\\\"EPSG\\\",\\\"9122\\\"]],AUTHORITY[\\\"EPSG\\\",\\\"4326\\\"]]\",  \"unit\": \"degree (supplier to define representation)\",  \"proj4\": \"+proj=longlat +datum=WGS84 +no_defs\",  \"name\": \"WGS 84\",  \"area\": \"World.\"}";
        const string _3857 = "{  \"code\": \"3857\",  \"kind\": \"CRS-PROJCRS\",  \"bbox\": [    85.06,    -180.0,    -85.06,    180.0  ],  \"wkt\": \"PROJCS[\\\"WGS 84 / Pseudo-Mercator\\\",GEOGCS[\\\"WGS 84\\\",DATUM[\\\"WGS_1984\\\",SPHEROID[\\\"WGS 84\\\",6378137,298.257223563,AUTHORITY[\\\"EPSG\\\",\\\"7030\\\"]],AUTHORITY[\\\"EPSG\\\",\\\"6326\\\"]],PRIMEM[\\\"Greenwich\\\",0,AUTHORITY[\\\"EPSG\\\",\\\"8901\\\"]],UNIT[\\\"degree\\\",0.0174532925199433,AUTHORITY[\\\"EPSG\\\",\\\"9122\\\"]],AUTHORITY[\\\"EPSG\\\",\\\"4326\\\"]],PROJECTION[\\\"Mercator_1SP\\\"],PARAMETER[\\\"central_meridian\\\",0],PARAMETER[\\\"scale_factor\\\",1],PARAMETER[\\\"false_easting\\\",0],PARAMETER[\\\"false_northing\\\",0],UNIT[\\\"metre\\\",1,AUTHORITY[\\\"EPSG\\\",\\\"9001\\\"]],AXIS[\\\"X\\\",EAST],AXIS[\\\"Y\\\",NORTH],EXTENSION[\\\"PROJ4\\\",\\\"+proj=merc +a=6378137 +b=6378137 +lat_ts=0.0 +lon_0=0.0 +x_0=0.0 +y_0=0 +k=1.0 +units=m +nadgrids=@null +wktext  +no_defs\\\"],AUTHORITY[\\\"EPSG\\\",\\\"3857\\\"]]\",  \"unit\": \"metre\",  \"proj4\": \"+proj=merc +a=6378137 +b=6378137 +lat_ts=0.0 +lon_0=0.0 +x_0=0.0 +y_0=0 +k=1.0 +units=m +nadgrids=@null +wktext  +no_defs\",  \"name\": \"WGS 84 / Pseudo-Mercator\",  \"area\": \"World between 85.06°S and 85.06°N.\"}";
        const string _5181 = "{  \"code\": \"5181\",  \"kind\": \"CRS-PROJCRS\",  \"bbox\": [    38.33,    126.0,    33.96,    128.0  ],  \"wkt\": \"PROJCS[\\\"Korea 2000 / Central Belt\\\",GEOGCS[\\\"Korea 2000\\\",DATUM[\\\"Geocentric_datum_of_Korea\\\",SPHEROID[\\\"GRS 1980\\\",6378137,298.257222101,AUTHORITY[\\\"EPSG\\\",\\\"7019\\\"]],TOWGS84[0,0,0,0,0,0,0],AUTHORITY[\\\"EPSG\\\",\\\"6737\\\"]],PRIMEM[\\\"Greenwich\\\",0,AUTHORITY[\\\"EPSG\\\",\\\"8901\\\"]],UNIT[\\\"degree\\\",0.0174532925199433,AUTHORITY[\\\"EPSG\\\",\\\"9122\\\"]],AUTHORITY[\\\"EPSG\\\",\\\"4737\\\"]],PROJECTION[\\\"Transverse_Mercator\\\"],PARAMETER[\\\"latitude_of_origin\\\",38],PARAMETER[\\\"central_meridian\\\",127],PARAMETER[\\\"scale_factor\\\",1],PARAMETER[\\\"false_easting\\\",200000],PARAMETER[\\\"false_northing\\\",500000],UNIT[\\\"metre\\\",1,AUTHORITY[\\\"EPSG\\\",\\\"9001\\\"]],AUTHORITY[\\\"EPSG\\\",\\\"5181\\\"]]\",  \"unit\": \"metre\",  \"proj4\": \"+proj=tmerc +lat_0=38 +lon_0=127 +k=1 +x_0=200000 +y_0=500000 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs\",  \"name\": \"Korea 2000 / Central Belt\",  \"area\": \"Republic of Korea (South Korea) - between 126°E and 128°E - mainland and nearshore.\"}";
        #endregion
    }
}
