using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BruTile;
using BruTile.Cache;
using BruTile.Web;
using BruTile.Wmts;

namespace MMaker.Geographics.Layers
{
    public class BackgroundLayerFactory
    {
        public async Task<BackgroundLayerSet> GetVWorld(string apiKey)
        {
            var uri        = "http://api.vworld.kr/req/wmts/1.0.0/{key}/WMTSCapabilities.xml".Replace("{key}", apiKey);
            var sources    = await GetTileSourcesFromCapabilities(new Uri(uri));
            var layerNames = new [] { "VworldBase", "VworldSatellite", "VworldHybrid" };
            var layers     = GetTileLayers(
                                sources, 
                                selector: src => layerNames.Contains(src.Name), 
                                orderer : src => Array.IndexOf(layerNames, src.Name));
            var set        = new BackgroundLayerSet(layers);
            //set.Add("없음");
            set.Add("일반"      , false, "VworldBase");
            set.Add("위성"      , true,  "VworldSatellite");
            set.Add("위성(중첩)", true,  "VworldSatellite", "VworldHybrid");
            return set;
        }
        public Task<BackgroundLayerSet> GetKakaoMap()
        {
            var root = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var tile = System.IO.Path.Combine(root, "Daum");
            var schema      = GetKakaomapSchema();
            var serverNodes = new[] { "0", "1", "2", "3" };
            var sources = new[] {
                new HttpTileSource(schema, name: "map_2d"     , serverNodes: serverNodes, urlFormatter: "http://map{s}.daumcdn.net/map_2d/1906plw/L{z}/{y}/{x}.png", persistentCache: new FileCache(System.IO.Path.Combine(tile, "map"), "png")),
                new HttpTileSource(schema, name: "map_skyview", serverNodes: serverNodes, urlFormatter: "http://map{s}.daumcdn.net/map_skyview/L{z}/{y}/{x}.jpg?v=160114", persistentCache: new FileCache(System.IO.Path.Combine(tile, "sky"), "png")),
                new HttpTileSource(schema, name: "map_hybrid" , serverNodes: serverNodes, urlFormatter: "http://map{s}.daumcdn.net/map_hybrid/1807hsm/L{z}/{y}/{x}.png", persistentCache: new FileCache(System.IO.Path.Combine(tile, "hybrid"), "png"))
            };
            var layers      = GetTileLayers(sources);
            var set         = new BackgroundLayerSet(layers);
            //set.Add("없음");
            set.Add("일반"      , false, "map_2d");
            set.Add("위성"      , true , "map_skyview");
            set.Add("위성(중첩)", true , "map_skyview", "map_hybrid");
            return Task.FromResult(set);

            // https://bbong95.github.io/leaflet/2018/08/06/Leaflet-%EB%A7%9B%EB%B3%B4%EA%B8%B0-4%ED%83%84/
            // https://devtalk.kakao.com/t/topic/69986
            /*  Q:
                웹 서핑을 하다보면 leaflet이나 openlayers에서
                http://map{s}.daumcdn.net/map_2d/1807hsm/L{z}/{y}/{x}.png
                이런식으로 타일맵 로딩을 하는 방식을 이용하는 예시를 볼 수 있습니다.
                위 방법이 사용해도 무방한 정상적인 방법인건가요?
                A:
                정상적이지 않습니다.
                타일주소의 직접 호출은 당사가 허용하는 방법이 아닙니다.
                따라서 일시적으로 가능하다 하더라도 지속적인 정상 서비스를 보장하지 않습니다.

            "일반지도1807"                    "http://map{s}.daumcdn.net/map_2d/1807hsm/L{z}/{y}/{x}.png"                   
            "일반지도1906"                    "http://map{s}.daumcdn.net/map_2d/1906plw/L{z}/{y}/{x}.png"                   
            "지적편집도(Cadastral)"           "http://map{s}.daumcdn.net/map_usedistrict/1807hsm/L{z}/{y}/{x}.png"          
            "법정동경계지도(BBoundary)"       "http://boundary.map.daum.net/mapserver/db/BBOUN_L/L{z}/{y}/{x}.png"          
            "행정동경계지도 HBoundary"        "http://boundary.map.daum.net/mapserver/db/HBOUN_L/L{z}/{y}/{x}.png"          
            "지형도(Terrain Map)"             "http://map{s}.daumcdn.net/map_shaded_relief/3.00/L{z}/{y}/{x}.png"           
            "위성지도+라벨 중첩지도)"         "http://map{s}.daumcdn.net/map_hybrid/1807hsm/L{z}/{y}/{x}.png"               
            "위성지도(Satellite Only)"        "http://map{s}.daumcdn.net/map_skyview/L{z}/{y}/{x}.jpg?v=160114"             
            "자전거도로지도(Bicycle)"         "http://map{s}.daumcdn.net/map_bicycle/2d/6.00/L{z}/{y}/{x}.png"              
            "교통상황지도(Traffic)"           "http://r{s}.maps.daum-img.net/mapserver/file/realtimeroad/L{z}/{y}/{x}.png"  
            "로드뷰"                          "http://map{s}.daumcdn.net/map_roadviewline/7.00/L{z}/{y}/{x}.png"            
            "미세먼지지도"                    "http://airinfo.map.kakao.com/mapserver/file/airinfo_pm10/T/L{z}/{y}/{x}.png" 
            "황사지도"                        "http://airinfo.map.kakao.com/mapserver/file/airinfo_ysnd/T/L{z}/{y}/{x}.png" 
            "이산화질소지도"                  "http://airinfo.map.kakao.com/mapserver/file/airinfo_no2/T/L{z}/{y}/{x}.png"  
            "아황산가스지도"                  "http://airinfo.map.kakao.com/mapserver/file/airinfo_so2/T/L{z}/{y}/{x}.png"  
            "통합대기지수지도"                "http://airinfo.map.kakao.com/mapserver/file/airinfo_khai/T/L{z}/{y}/{x}.png" 
            "초미세먼지지도"                  "http://airinfo.map.kakao.com/mapserver/file/airinfo_pm25/T/L{z}/{y}/{x}.png" 
            "오존지도"                        "http://airinfo.map.kakao.com/mapserver/file/airinfo_o3/T/L{z}/{y}/{x}.png"   
            "일산화탄소지도"                  "http://airinfo.map.kakao.com/mapserver/file/airinfo_co/T/L{z}/{y}/{x}.png"   
            */
        }
        public Task<BackgroundLayerSet> GetKWater()
        {
            var baseUrl = "http://kommap.kwater.or.kr/arcgis/rest/services/public/BaseMap_2018/MapServer";
            var schema  = new TileSchema();
            schema.OriginX  = -5423200;
            schema.OriginY  =  6294600;
            schema.Format   = "image/jpgpng";
            schema.YAxis    = YAxis.OSM;
            schema.Srs      = "EPSG:5181";
            schema.Extent   = new Extent(-956717.4541277827, -341633.6944546023, 1690051.884713592, 1587544.6432406649);
            schema.Resolutions[ "0"] =  new Resolution(id:  "0", unitsPerPixel:   926.0435187537042       , scaledenominator: 3500000);
            schema.Resolutions[ "1"] =  new Resolution(id:  "1", unitsPerPixel:   529.1677250021168       , scaledenominator: 2000000);
            schema.Resolutions[ "2"] =  new Resolution(id:  "2", unitsPerPixel:   264.5838625010584       , scaledenominator: 1000000);
            schema.Resolutions[ "3"] =  new Resolution(id:  "3", unitsPerPixel:   132.2919312505292       , scaledenominator:  500000);
            schema.Resolutions[ "4"] =  new Resolution(id:  "4", unitsPerPixel:    66.1459656252646       , scaledenominator:  250000);
            schema.Resolutions[ "5"] =  new Resolution(id:  "5", unitsPerPixel:    33.0729828126323       , scaledenominator:  125000);
            schema.Resolutions[ "6"] =  new Resolution(id:  "6", unitsPerPixel:    16.933367200067735     , scaledenominator:   64000);
            schema.Resolutions[ "7"] =  new Resolution(id:  "7", unitsPerPixel:     8.466683600033868     , scaledenominator:   32000);
            schema.Resolutions[ "8"] =  new Resolution(id:  "8", unitsPerPixel:     4.233341800016934     , scaledenominator:   16000);
            schema.Resolutions[ "9"] =  new Resolution(id:  "9", unitsPerPixel:     2.116670900008467     , scaledenominator:    8000);
            schema.Resolutions["10"] =  new Resolution(id: "10", unitsPerPixel:     1.0583354500042335    , scaledenominator:    4000);
            schema.Resolutions["11"] =  new Resolution(id: "11", unitsPerPixel:     0.5291677250021167    , scaledenominator:    2000);
            schema.Resolutions["12"] =  new Resolution(id: "12", unitsPerPixel:     0.26458386250105836   , scaledenominator:    1000);
            schema.Resolutions["13"] =  new Resolution(id: "13", unitsPerPixel:     0.13229193125052918   , scaledenominator:     500);
            schema.Resolutions["14"] =  new Resolution(id: "14", unitsPerPixel:     0.06614596562526459   , scaledenominator:     250);
            schema.Resolutions["15"] =  new Resolution(id: "15", unitsPerPixel:     0.033072982812632296  , scaledenominator:     125);
            schema.Resolutions["16"] =  new Resolution(id: "16", unitsPerPixel:     0.016668783337566676  , scaledenominator:      63);
            schema.Resolutions["17"] =  new Resolution(id: "17", unitsPerPixel:     0.008466683600033867  , scaledenominator:      32);
            schema.Resolutions["18"] =  new Resolution(id: "18", unitsPerPixel:     0.004233341800016934  , scaledenominator:      16);
            schema.Resolutions["19"] =  new Resolution(id: "19", unitsPerPixel:     0.002116670900008467  , scaledenominator:       8);
            schema.Resolutions["20"] =  new Resolution(id: "20", unitsPerPixel:     0.0010583354500042334 , scaledenominator:       4);
            schema.Resolutions["21"] =  new Resolution(id: "21", unitsPerPixel:     0.000529167725002116  , scaledenominator:       2);

            var request       = new BasicRequest($"{baseUrl}/tile/{"{0}/{2}/{1}"}");
            var provider      = new HttpTileProvider(request, null, null);
            var tileSource    = new TileSource(provider, schema);

            //var set        = new BackgroundLayerSet(new [] { new BackgroundLayer(tileSource, "일반", order: 0) });
            var set = new BackgroundLayerSet(new[] { new BackgroundLayer(tileSource, null) { LegendText = "일반"} });
            set.Add("없음");
            set.Add("일반"      , "일반");
            return Task.FromResult(set);
        }

        private static TileSchema GetKakaomapSchema()
        {
            var schema      = new TileSchema();
            schema.OriginX  = -30000;
            schema.OriginY  = -60000;
            schema.Name     = "KakaoMap";
            schema.Format   = "png";
            schema.YAxis    = YAxis.TMS;
            schema.Srs      = "EPSG:5181";

            var minX = -219825.99;
            var minY = -535028.96;
            var maxX =  819486.07;
            var maxY =  777525.22;
            schema.Extent   = new Extent(minX, minY, maxX, maxY);
            var resolutions = new[] { 2048, 1024, 512, 256, 128, 64, 32, 16, 8, 4, 2, 1, 0.5, 0.25 };
            SetResolution(schema, firstLevel: 1, isReversed: true, resolutions: resolutions);
            return schema;
        }
        private async Task<TileSource[]> GetTileSourcesFromCapabilities(Uri capabilitiesUri)
        {
            var stream  = await GetStream(capabilitiesUri);
            var sources = WmtsParser.Parse(stream).Cast<TileSource>();
            return sources.ToArray();
        }
        private static BackgroundLayer[] GetTileLayers(IEnumerable<ITileSource> sources, Func<ITileSource, bool> selector, Func<ITileSource, int> orderer)
        {
            return sources
                        .Where(selector)
                        //.Select(x => new BackgroundLayer(x, x.Name, order: orderer.Invoke(x)))
                        .Select(x => new BackgroundLayer(x, null) {LegendText = x.Name })
                        .ToArray();
        }
        private static BackgroundLayer[] GetTileLayers(ITileSource[] sources)
        {
            return sources
                        //.Select(x => new BackgroundLayer(x, x.Name, order: Array.IndexOf(sources, x)))
                        .Select(x => new BackgroundLayer(x, null) { LegendText = x.Name })
                        .ToArray();
        }
        private static async Task<Stream> GetStream(Uri uri)
        {
            Stream stream = null;
            switch (uri.Scheme)
            {
                case "http":
                case "https":
                    {
                        using (var httpClient = new HttpClient())
                        {
                            stream = await httpClient.GetStreamAsync(uri);
                        }
                        break;
                    }
                case "file":
                    {
                        stream = new FileStream(uri.LocalPath, FileMode.Open, FileAccess.Read);
                        break;
                    }
                default:
                    throw new ArgumentException();
            }
            return stream;
        }
        private static void SetResolution(TileSchema schema, int firstLevel, bool isReversed, IEnumerable<double> resolutions)
        {
            var level = firstLevel;
            var rs    = isReversed 
                            ? resolutions.Reverse().ToArray() 
                            : resolutions.ToArray();
            foreach (var resolution in rs)
            {
                var key = level.ToString();
                schema.Resolutions[key] = new Resolution(id: key, unitsPerPixel: resolution);
                level++;
            }
        }
    }
}
