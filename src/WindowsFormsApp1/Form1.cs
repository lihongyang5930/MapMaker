using DotSpatial.Data;
using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using NetTopologySuite.Index;
using NetTopologySuite.Index.Strtree;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Dictionary<string, IFeatureSet> Layers = new Dictionary<string, IFeatureSet>();

        private void buttonAdv1_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog() { Multiselect = true, Filter = "ESRI Shape File | *.shp"})
            {
                if (dialog.ShowDialog() != DialogResult.OK) return;

                var dm = new DotSpatial.Data.DataManager() { LoadInRam = true };
                foreach (var filename in dialog.FileNames)
                {
                    var ds = dm.OpenVector(filename, true, null);
                    switch (ds.Name)
                    {
                        case "WTL_PIPE_LS":
                            ds.Name = "상수관로";
                            Layers.Add("상수관로", (IFeatureSet)ds);
                            break;
                        case "WTL_SPLY_LS":
                            ds.Name = "급수관로";
                            Layers.Add("급수관로", (IFeatureSet)ds);
                            break;
                        case "WTL_META_PS":
                            ds.Name = "수도계량기";
                            Layers.Add("수도계량기", (IFeatureSet)ds);
                            break;
                    }

                }
            }
        }

        void SplitAtPoint(IGeometry line, IGeometry point)
        {
            if (line.OgcGeometryType != GeoAPI.Geometries.OgcGeometryType.LineString) return;
            if (point.OgcGeometryType != GeoAPI.Geometries.OgcGeometryType.Point) return;
        }
        void SplitByPolyLine(IGeometry g1, IGeometry g2)
        {
            var ok = g1.Intersects(g2);
            if (ok)
            {
                var line = g1 as ILineString;
                var geom = line.Intersection(g2);
                
            }
        }

        private void buttonAdv2_Click(object sender, EventArgs e)
        {
            var tree = spatialIndex(Layers.Values.ToArray());

            foreach (var layer in Layers.Values)
            {
                foreach (var feature in layer.Features)
                {
                    var features = tree.Query(feature.Geometry.EnvelopeInternal);
                    var line = feature.Geometry as ILineString;

                    foreach (var item in features)
                    {
                        if (item.Equals(feature)) continue;

                        var line2 = item.Geometry as ILineString;

                        //교차점 확인
                        var p = CrossedPoint(feature.Geometry, item.Geometry);
                        if (p == null) continue;

                        //정상적인 작도
                        if (IsEqualLocation(line.StartPoint, p)) continue;
                        if (IsEqualLocation(line.EndPoint, p)) continue;

                        SplitByPolyLine(line, p);

                        //최소범위 정의

                        //상월 , 하월 검토

                        //선 분할 검토

                        //Point를 기준으로 선 분할
                        //분할된 선들의 길이 측정

                        
                        var v = new NetTopologySuite.Algorithm.Distance.PointPairDistance();
                        
                        NetTopologySuite.Algorithm.Distance.DistanceToPoint.ComputeDistance(line2, p.Coordinate, v);

                        //var pp = item.Geometry.Intersection(p);

                        ;
                        //객체 속성 
                        //관리번호 중복 검토
                        //연장 속성 업데이트

                        //if (item.Geometry.Touches(line.StartPoint)) continue;
                        //if (item.Geometry.Touches(line.EndPoint)) continue;



                        //var f1 = DistanceOp.IsWithinDistance(item.Geometry, line.StartPoint, 0);
                        //var f2 = DistanceOp.IsWithinDistance(item.Geometry, line.EndPoint, 0);

                        //var p1 = DistanceOp.NearestPoints(item.Geometry, line.StartPoint);
                        //var n1_1 = new NetTopologySuite.Geometries.Point(p1.Min());
                        //var n1_2 = new NetTopologySuite.Geometries.Point(p1.Max());
                        //var d1_1 = DistanceOp.Distance(n1_1, line.StartPoint);
                        //var d1_2 = DistanceOp.Distance(n1_2, line.StartPoint);

                        //var p2 = DistanceOp.NearestPoints(item.Geometry, line.EndPoint);
                        //var n2_1 = new NetTopologySuite.Geometries.Point(p2.Min());
                        //var n2_2 = new NetTopologySuite.Geometries.Point(p2.Max());
                        //var d2_1 = DistanceOp.Distance(n2_1, line.EndPoint);
                        //var d2_2 = DistanceOp.Distance(n2_2, line.EndPoint);

                        //var f1 = DistanceOp.IsWithinDistance(line.StartPoint, item.Geometry,  0);
                        //var f2 = DistanceOp.IsWithinDistance(line.EndPoint, item.Geometry,  0);

                        //var p1 = DistanceOp.NearestPoints(line.StartPoint, item.Geometry );
                        //var n1_1 = new NetTopologySuite.Geometries.Point(p1.Min());
                        //var n1_2 = new NetTopologySuite.Geometries.Point(p1.Max());
                        //var d1_1 = DistanceOp.Distance(line.StartPoint, n1_1 );
                        //var d1_2 = DistanceOp.Distance(line.StartPoint, n1_2 );

                        //var p2 = DistanceOp.NearestPoints(line.EndPoint, item.Geometry);
                        //var n2_1 = new NetTopologySuite.Geometries.Point(p2.Min());
                        //var n2_2 = new NetTopologySuite.Geometries.Point(p2.Max());
                        //var d2_1 = DistanceOp.Distance(line.EndPoint, n2_1);
                        //var d2_2 = DistanceOp.Distance(line.EndPoint, n2_2);

                        ////var c = Math.Min(d1, d2);

                        //var flag = feature.Geometry.Overlaps(item.Geometry);
                        var str = string.Format("{0} : {1} : {2} : {3} : {4} : {5}\n", layer.Name, feature.DataRow["OFID"], item.ParentFeatureSet.Name, item.DataRow["OFID"], p.X, p.Y);
                        //var str = string.Format("{0} : {1} : {2} : {3} : {4} : {5} : {6} : {7} : {8} : {9}\n", layer.Name, feature.DataRow["OFID"], item.ParentFeatureSet.Name, item.DataRow["OFID"], d1, d2, c, f1, f2, flag);
                        richTextBox1.AppendText(str);
                    }
                }
            }
        }

        private ISpatialIndex<IFeature> spatialIndex(params IFeatureSet[] set)
        {
            var tree = new STRtree<IFeature>();

            foreach (var fs in set)
            {
                foreach (var m in fs.Features)
                {
                    tree.Insert(m.Geometry.EnvelopeInternal, m);
                }
            }

            tree.Build();
            return tree;
        }

        public IPoint CrossedPoint(IGeometry g1, IGeometry g2)
        {
            if (!g1.Crosses(g2))
                return null;

            var g = g1.Difference(g2);
            if (g == null || g.IsEmpty)
                return null;

            return g?.InteriorPoint;
        }

        public bool IsEqualLocation(IPoint g1, IPoint g2)
        {
            return IsEqualLocation(g1.Coordinate, g2.Coordinate);
        }

        public bool IsEqualLocation(Coordinate g1, Coordinate g2)
        {
            return g1.Equals(g2);
        }
    }
}
