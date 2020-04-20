using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BruTile;
using BruTile.Web;
using BruTile.Wmts;

namespace MindOne.Wpf.Geographics.Layers
{
    public class BackgroundLayerFactory
    {
        public async Task<BackgroundLayerSet> GetVWorld(string capabilitiesUri)
        {
            var sources    = await GetTileSourcesFromCapabilities(new Uri(capabilitiesUri));
            var layerNames = new [] { "VworldBase", "VworldSatellite", "VworldHybrid" };
            var selector   = new Func<ITileSource, bool>(src => layerNames.Contains(src.Name));
            var orderer    = new Func<ITileSource, int >(src => Array.IndexOf(layerNames, src.Name));
            var layers     = GetTileLayers(sources, selector, orderer);
            var set        = new BackgroundLayerSet(layers);
            set.Add("없음");
            set.Add("일반"      , "VworldBase");
            set.Add("위성"      , "VworldSatellite");
            set.Add("위성(중첩)", "VworldSatellite", "VworldHybrid");
            return set;
        }

        public Task<BackgroundLayerSet> GetKakaoMap()
        {
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
            */
            var urls = new[] {
                     new { Name = "일반지도1807"              , Url = "http://map{s}.daumcdn.net/map_2d/1807hsm/L{z}/{y}/{x}.png" }
                    ,new { Name = "일반지도1906"              , Url = "http://map{s}.daumcdn.net/map_2d/1906plw/L{z}/{y}/{x}.png" }
                    ,new { Name = "지적편집도(Cadastral)"     , Url = "http://map{s}.daumcdn.net/map_usedistrict/1807hsm/L{z}/{y}/{x}.png" }
                    ,new { Name = "법정동경계지도(BBoundary)" , Url = "http://boundary.map.daum.net/mapserver/db/BBOUN_L/L{z}/{y}/{x}.png" }
                    ,new { Name = "행정동경계지도 HBoundary"  , Url = "http://boundary.map.daum.net/mapserver/db/HBOUN_L/L{z}/{y}/{x}.png" }
                    ,new { Name = "지형도(Terrain Map)"       , Url = "http://map{s}.daumcdn.net/map_shaded_relief/3.00/L{z}/{y}/{x}.png" }
                    ,new { Name = "위성지도+라벨 중첩지도)"   , Url = "http://map{s}.daumcdn.net/map_hybrid/1807hsm/L{z}/{y}/{x}.png" }
                    ,new { Name = "위성지도(Satellite Only)"  , Url = "http://map{s}.daumcdn.net/map_skyview/L{z}/{y}/{x}.jpg?v=160114" }
                    ,new { Name = "자전거도로지도(Bicycle)"   , Url = "http://map{s}.daumcdn.net/map_bicycle/2d/6.00/L{z}/{y}/{x}.png" }
                    ,new { Name = "교통상황지도(Traffic)"     , Url = "http://r{s}.maps.daum-img.net/mapserver/file/realtimeroad/L{z}/{y}/{x}.png" }
                    ,new { Name = "로드뷰"                    , Url = "http://map{s}.daumcdn.net/map_roadviewline/7.00/L{z}/{y}/{x}.png" }
                    ,new { Name = "미세먼지지도"              , Url = "http://airinfo.map.kakao.com/mapserver/file/airinfo_pm10/T/L{z}/{y}/{x}.png" }
                    ,new { Name = "황사지도"                  , Url = "http://airinfo.map.kakao.com/mapserver/file/airinfo_ysnd/T/L{z}/{y}/{x}.png" }
                    ,new { Name = "이산화질소지도"            , Url = "http://airinfo.map.kakao.com/mapserver/file/airinfo_no2/T/L{z}/{y}/{x}.png" }
                    ,new { Name = "아황산가스지도"            , Url = "http://airinfo.map.kakao.com/mapserver/file/airinfo_so2/T/L{z}/{y}/{x}.png" }
                    ,new { Name = "통합대기지수지도"          , Url = "http://airinfo.map.kakao.com/mapserver/file/airinfo_khai/T/L{z}/{y}/{x}.png" }
                    ,new { Name = "초미세먼지지도"            , Url = "http://airinfo.map.kakao.com/mapserver/file/airinfo_pm25/T/L{z}/{y}/{x}.png" }
                    ,new { Name = "오존지도"                  , Url = "http://airinfo.map.kakao.com/mapserver/file/airinfo_o3/T/L{z}/{y}/{x}.png" }
                    ,new { Name = "일산화탄소지도"            , Url = "http://airinfo.map.kakao.com/mapserver/file/airinfo_co/T/L{z}/{y}/{x}.png" }
                };
        
            var schema         = GetKakaomapSchema();
            var serverNodes    = new[] { "0", "1", "2", "3" };
            var sourceFactory  = new Func<string, ITileSource>((name) => {
                return new HttpTileSource(
                    schema, 
                    serverNodes: serverNodes, 
                    urlFormatter: urls.Where(x => x.Name == name ).Single().Url) { 
                    Name = name
                };
            });
            var sources        = new[] { 
                sourceFactory.Invoke("일반지도1906"),
                sourceFactory.Invoke("위성지도(Satellite Only)"),
                sourceFactory.Invoke("위성지도+라벨 중첩지도)"),
                sourceFactory.Invoke("교통상황지도(Traffic)"),
            };

            var layerNames = new [] { "일반지도1906", "위성지도(Satellite Only)", "위성지도+라벨 중첩지도)", "교통상황지도(Traffic)" };
            var selector   = new Func<ITileSource, bool>(src => layerNames.Contains(src.Name));
            var orderer    = new Func<ITileSource, int >(src => Array.IndexOf(layerNames, src.Name));
            var layers     = GetTileLayers(sources, selector, orderer);
            var set        = new BackgroundLayerSet(layers);
            set.Add("없음");
            set.Add("일반"      , "일반지도1906");
            set.Add("위성"      , "위성지도(Satellite Only)");
            set.Add("위성(중첩)", "위성지도(Satellite Only)", "위성지도+라벨 중첩지도)");
            set.Add("일반(교통)", "일반지도1906", "교통상황지도(Traffic)");

            return Task.FromResult(set);
        }

        private TileSchema GetKakaomapSchema()
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

        public Task<BackgroundLayerSet> GetKWaterMapLayers()
        {
            var baseUrl         = "http://kommap.kwater.or.kr/arcgis/rest/services/public/BaseMap_2018/MapServer";
            //var capabilitiesUrl = "http://kommap.kwater.or.kr/arcgis/rest/services/public/BaseMap_2018/MapServer/WMTS/1.0.0/WMTSCapabilities.xml";
            //var svrSource       = await GetTileSourcesFromCapabilities(new Uri(capabilitiesUrl));
            //var svrSchema       = svrSource.FirstOrDefault().Schema;

            var schema = new TileSchema();
            schema.OriginX  = -5423200;
            schema.OriginY  =  6294600;
            schema.Format   = "image/jpgpng";
            schema.YAxis    = YAxis.OSM;
            schema.Srs      = "EPSG:5181";
            schema.Extent   = new Extent(-956717.4541277827, -341633.6944546023, 1690051.884713592, 1587544.6432406649);
            //foreach (var r in svrSchema.Resolutions)
            //    schema.Resolutions[r.Key] = r.Value;
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

            var set        = new BackgroundLayerSet(new [] { new BackgroundLayer(tileSource, "일반", order: 0) });
            set.Add("없음");
            set.Add("일반"      , "일반");
            return Task.FromResult(set);
        }


        private async Task<TileSource[]> GetTileSourcesFromCapabilities(Uri capabilitiesUri)
        {
            var stream  = await GetStream(capabilitiesUri);
            var sources = WmtsParser.Parse(stream).Cast<TileSource>();
            return sources.ToArray();
        }
        private BackgroundLayer[] GetTileLayers(IEnumerable<ITileSource> sources, Func<ITileSource, bool> selector, Func<ITileSource, int> orderer)
        {
            return sources
                        .Where(selector)
                        .Select(x => new BackgroundLayer(x, x.Name, order: orderer.Invoke(x)))
                        .ToArray();
        }
        private async Task<Stream> GetStream(Uri uri)
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
        private void SetResolution(TileSchema schema, int firstLevel, bool isReversed, IEnumerable<double> resolutions)
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
