using DotSpatial.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMaker.Core
{
    public static class AppStatic
    {
        
        /// <summary>
        /// 작업에 포함된 레이어 목록
        /// 레이어 불러오기 에서 사용됨
        /// </summary>
        public static Dictionary<string, IDataSet> WorkingLayer = new Dictionary<string, IDataSet>();

        public static Dictionary<string, List<string>> Layers = new Dictionary<string, List<string>>();

        public static Dictionary<Models2.IWTL_Layer, IFeatureSet> d_Layers = new Dictionary<Models2.IWTL_Layer, IFeatureSet>();

        public static void ReSetLayers()
        {
            d_Layers.Clear();
            CreateWorkLayers();
        }
        
        /// <summary>
        /// 20200307 - fdragons
        /// 표준47130 18개 Blank레이어를 생성한다.
        /// </summary>
        private static void CreateWorkLayers()
        {
            var objs = new Dictionary<Models2.IWTL_Layer, FeatureType>()
            {
                { new Models2.WTL_BLBG_AS(),    FeatureType.Polygon },  //대블럭
                { new Models2.WTL_BLBM_AS(),    FeatureType.Polygon },  //중불럭
                { new Models2.WTL_BLSM_AS(),    FeatureType.Polygon },  //소블럭
                { new Models2.WTL_FIRE_PS(),    FeatureType.Point },    //소화전
                { new Models2.WTL_FLOW_PS(),    FeatureType.Point },    //유량계
                { new Models2.WTL_GAIN_AS(),    FeatureType.Polygon },  //수원지
                { new Models2.WTL_HEAD_AS(),    FeatureType.Polygon },  //취수장
                { new Models2.WTL_META_PS(),    FeatureType.Point },    //수도계량기
                { new Models2.WTL_PIPE_LS(),    FeatureType.Line },     //상수관로
                { new Models2.WTL_PRES_AS(),    FeatureType.Polygon },  //가압장
                { new Models2.WTL_PRGA_PS(),    FeatureType.Point },    //수압계
                { new Models2.WTL_PURI_AS(),    FeatureType.Polygon },  //정수장
                { new Models2.WTL_SERV_AS(),    FeatureType.Polygon },  //배수지
                { new Models2.WTL_SPLY_LS(),    FeatureType.Line },     //급수관로
                { new Models2.WTL_VALB_AS(),    FeatureType.Polygon },  //밸브실
                { new Models2.WTL_VALV_PS(),    FeatureType.Point },    //밸브
                { new Models2.WTL_CNTR_LS(),    FeatureType.Line },     //등고선
                { new Models2.WTL_ELEV_PS(),    FeatureType.Point },    //표고점
            };
            foreach (var obj in objs)
            {
                d_Layers.Add(obj.Key, CreateFeatureSetSchema(obj.Key, obj.Value));
            }
        }

        private static IFeatureSet CreateFeatureSetSchema(Models2.IWTL_Layer T, FeatureType featureType)
        {
            var fc = new FeatureSet(featureType);
            
            var props = T?.GetType().GetProperties();

            foreach (var prop in props)
            {
                var col = fc.DataTable.Columns.Add();
                col.ColumnName = prop.Name;
                col.DataType = prop.PropertyType;
            }

            return fc;
        }
    }
}
