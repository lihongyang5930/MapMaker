using DotSpatial.Data;
using GeoAPI.Geometries;
using MindOne.Core.Extensions;
using MindOne.Core.Helper;
using MMaker.Core;
using MMaker.Diagnosis.Helper;
using NetTopologySuite.Index.Strtree;
using NetTopologySuite.Operation;
using NetTopologySuite.Operation.Distance;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMaker.Diagnosis.Views
{
    public partial class ValidationForm : MMaker.Core.Views.BaseView
    {
        public ValidationForm()
        {
            InitializeComponent();

            sfDataGrid1.Columns.Add(new GridTextColumn() { HeaderText = "No.", MappingName = "NO" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { HeaderText = "레이어명", MappingName = "NAME" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { HeaderText = "UID", MappingName = "UID" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { HeaderText = "관리번호", MappingName = "IDN" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { HeaderText = "설명", MappingName = "DESC" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { HeaderText = "Geometry", MappingName = "OBJECT" });

            sfDataGrid1.DataSource = source;


            this.rbtype_A.CheckChanged += rbtype_CheckChanged;
            this.rbtype_B.CheckChanged += rbtype_CheckChanged;
            this.rbtype_C.CheckChanged += rbtype_CheckChanged;
            this.rbtype_D.CheckChanged += rbtype_CheckChanged;
            this.rbtype_E.CheckChanged += rbtype_CheckChanged;
            this.rbtype_F.CheckChanged += rbtype_CheckChanged;
            this.rbtype_G.CheckChanged += rbtype_CheckChanged;
            this.rbtype_H.CheckChanged += rbtype_CheckChanged;
        }

        private void rbtype_CheckChanged(object sender, EventArgs e)
        {
            if (!((RadioButtonAdv)sender).Checked) return;
            //this.sfDataGrid1.DataSource = null;

            switch (((RadioButtonAdv)sender).Name)
            {
                case "rbtype_A":
                    break;
                case "rbtype_B":
                    break;
                case "rbtype_C":
                    break;
                case "rbtype_D":
                    break;
                case "rbtype_E":
                    break;
                case "rbtype_F":
                    break;
                case "rbtype_G":
                    break;
                case "rbtype_H":
                    break;

            }
        }

        private BindingSource source = new System.Windows.Forms.BindingSource();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            source.BindingComplete += Source_BindingComplete;

            source.DataSource = new List<Models.ValidateModel>();

            btnSearch.Click += BtnSearch_Click;
        }

        private void Source_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate && e.Exception == null)
                e.Binding.BindingManagerBase.EndCurrentEdit();
        }

        void ReBinding()
        {
            sfDataGrid1.DataBindings.Clear();


        }

        KeyValuePair<Core.Models2.IWTL_Layer, IFeatureSet> GetLayer(string name)
        {
            return MMaker.Core.AppStatic.d_Layers.FirstOrDefault(kvp => kvp.Key.KorName() == name);
        }

        /// <summary>
        /// 관로길이 오차범위
        /// </summary>
        void TypeSearch_A()
        {
            this.richTextBox1.Clear();

            var layers = MMaker.Core.AppStatic.d_Layers
                   .Where(x => (new List<string>() { "상수관로", "급수관로" })
                   .Contains(x.Key.KorName())).Select(x => x.Value);
            foreach (var layer in layers)
            {
                var ls = layer.Features.Where(x => x.Geometry.Length < 1.0).Select(x => x);
                foreach (var f in ls)
                {
                    var str = string.Format("{0} : {1} : {2}\n", layer.Name, f.DataRow["OFID"], f.Geometry.Length);
                    richTextBox1.AppendText(str);
                }
            }    
        }
        void TypeSearch_B()
        {
            this.richTextBox1.Clear();
            var layers = MMaker.Core.AppStatic.d_Layers
                  .Where(x => (new List<string>() { "상수관로", "급수관로" })
                  .Contains(x.Key.KorName())).Select(x => x.Value);
            foreach (var layer in layers)
            {
                var ls = layer.Features
                    .Where(x => x.DataRow["연장"].toDouble() == 0).Select(x => x);
                foreach (var f in ls)
                {
                    var str = string.Format("{0} : {1} : {2}\n", layer.Name, f.DataRow["OFID"], 0);
                    richTextBox1.AppendText(str);
                }
            }
        }
        void TypeSearch_C()
        {
            this.richTextBox1.Clear();
            var layers = MMaker.Core.AppStatic.d_Layers
                 .Where(x => (new List<string>() { "상수관로", "급수관로" })
                 .Contains(x.Key.KorName())).Select(x => x.Value);

            var tree = LayerHelper.spatialIndex(layers.ToArray());

            foreach (var layer in layers)
            {
                foreach (var f in layer.Features)
                {
                    var fl = tree.Query(f.Geometry.EnvelopeInternal);
                    foreach (var f1 in fl)
                    {
                        var flag = f.Geometry.Overlaps(f1.Geometry);

                        var str = string.Format("{0} : {1} : {2} : {3} : {4}\n", layer.Name, f.DataRow["OFID"], f1.ParentFeatureSet.Name, f1.DataRow["OFID"], flag);
                        richTextBox1.AppendText(str);
                    }
                }
            }
        }
        void TypeSearch_D()
        {
            this.richTextBox1.Clear();
            var layers = MMaker.Core.AppStatic.d_Layers
               .Where(x => (new List<string>() { "상수관로", "급수관로" })
               .Contains(x.Key.KorName())).Select(x => x.Value);

            foreach (var layer in layers)
            {
                foreach (var f in layer.Features)
                {
                    if (f.Geometry.NumGeometries > 1)
                    {
                        var str = string.Format("{0} : {1} : {2} : {3} : {4}\n", layer.Name, f.DataRow["OFID"], f.DataRow["관리번호"], "", "");
                        richTextBox1.AppendText(str);
                    }
                }
            }
        }
        void TypeSearch_E()
        {
            this.richTextBox1.Clear();
            var layers = MMaker.Core.AppStatic.d_Layers
                        .Where(x => (new List<string>() { "상수관로", "급수관로" })
                        .Contains(x.Key.KorName())).Select(x => x.Value);

            var tree = LayerHelper.spatialIndex(layers.ToArray());

            foreach (var layer in layers)
            {
                foreach (var feature in layer.Features)
                {
                    var features = tree.Query(feature.Geometry.EnvelopeInternal);
                    var line = feature.Geometry as ILineString;
                    
                    foreach (var item in features)
                    {
                        if (feature.Equals(item)) continue;
                        //if (!feature.Geometry.Crosses(item.Geometry)) continue;
                        //var g = feature.Geometry.Difference(item.Geometry);
                        //var p = g?.InteriorPoint;

                        var line2 = item.Geometry as ILineString;

                        //교차점 확인
                        var p = Helper.GeometryHelper.CrossedPoint(feature.Geometry, item.Geometry);
                        if (p == null) continue;
                        //정상적인 작도
                        if (Helper.GeometryHelper.IsEqualLocation(line.StartPoint, p)) continue;
                        if (Helper.GeometryHelper.IsEqualLocation(line.EndPoint, p)) continue;


                        //최소범위 정의

                        //상월 , 하월 검토

                        //선 분할 검토
                        //var p1 = NetTopologySuite.Operation.Distance.DistanceOp.Distance(item.Geometry, p); ;
                        //if (true)
                        //{

                        //}
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

        //IPoint ShpMinPos(IGeometry geom1, IGeometry geom2)
        //{
        //    var line = geom2 as ILineString;

        //}

        void TypeSearch_F()
        {
            this.richTextBox1.Clear();
            var pointlayers = MMaker.Core.AppStatic.d_Layers
                       .Where(x => x.Value.FeatureType == FeatureType.Point)
                       .Select(x => x.Value);

            var Linelayers = MMaker.Core.AppStatic.d_Layers
                      .Where(x => (new List<string>() { "상수관로", "급수관로" })
                      .Contains(x.Key.KorName())).Select(x => x.Value);

            var tree = LayerHelper.spatialIndex(Linelayers.ToArray());
            foreach (var layer in pointlayers)
            {
                foreach (var feature in layer.Features)
                {
                    var point = feature.Geometry as IPoint;

                    var features = tree.Query(feature.Geometry.EnvelopeInternal);
                    foreach (var item in features)
                    {
                        if (item.Geometry.Touches(point)) continue;

                        var str = string.Format("{0} : {1} : {2} : {3} : {4}\n", layer.Name, feature.DataRow["OFID"], item.ParentFeatureSet.Name, item.DataRow["OFID"], "");
                        richTextBox1.AppendText(str);
                    }
                }

            }
        }
        void TypeSearch_G()
        {
            this.richTextBox1.Clear();
            var meta = GetLayer("수도계량기");
            var sply = GetLayer("급수관로");
            if (sply.IsDefault())
            {
                MessageHelper.Info("급수관로 레이어가 없습니다.");
                return;
            }
            var tree = LayerHelper.spatialIndex(sply.Value);

            foreach (var feature in meta.Value.Features)
            {
                var geom = feature.Buffer(1.0).Geometry.EnvelopeInternal;
                var features = tree.Query(feature.Geometry.EnvelopeInternal);
                if (features.Count == 0) continue;

                foreach (var item in features)
                {
                    var flag = feature.Geometry.Touches(item.Geometry);
                    var str = string.Format("{0} : {1} : {2} : {3} : {4}\n", meta.Value.Name, feature.DataRow["OFID"], item.ParentFeatureSet.Name, item.DataRow["OFID"], flag);
                    richTextBox1.AppendText(str);
                }
            }
        }
        void TypeSearch_H()
        {
            this.richTextBox1.Clear();
            var layers = MMaker.Core.AppStatic.d_Layers
                       .Where(x => x.Value.FeatureType == FeatureType.Line)
                       .Select(x => x.Value);

            var tree = LayerHelper.spatialIndex(layers.ToArray());
            foreach (var layer in layers)
            {
                foreach (var feature in layer.Features)
                {
                    var line = feature.Geometry as ILineString;

                    var features = tree.Query(line.EnvelopeInternal);
                    foreach (var item in features)
                    {

                    }
                }
            }
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var RadioButtons = groupBox1.GetAllControls(typeof(RadioButtonAdv));
            var CurrentControl = RadioButtons.Cast<RadioButtonAdv>().FirstOrDefault(x => x.Checked);

            switch (CurrentControl.Name)
            {
                case "rbtype_A":    //관로길이 오차범위
                    this.TypeSearch_A();
                    break;
                case "rbtype_B":    //관로길이 없거나 0으로 입력
                    this.TypeSearch_B();
                    break;
                case "rbtype_C":    //도형 중복 입력
                    this.TypeSearch_C();
                    break;
                case "rbtype_D":    //멀티파트 도형
                    this.TypeSearch_D();
                    break;
                case "rbtype_E":    //관로연결부위 분할오류\
                    this.TypeSearch_E();
                    break;
                case "rbtype_F":    //관로상에 없는 시설
                    this.TypeSearch_F();
                    break;
                case "rbtype_G":    //급수관로에 연결안됨 수도계량기
                    this.TypeSearch_G();
                    break;
                case "rbtype_H":    //오차범위 조정
                    this.TypeSearch_H();
                    break;

            }

            //if (CurrentControl.Name == "rbtype1") //관로길이 오차범위
            //{
            //    var layers = MMaker.Core.AppStatic.d_Layers
            //        .Where(x => (new List<string>() { "상수관로", "급수관로" })
            //        .Contains(x.Key.KorName())).Select(x => x.Value);
            //    foreach (var layer in layers)
            //    {   
            //        var ls = layer.Features.Where(x => x.Geometry.Length < 1.0).Select(x => x);
                    

            //        //sfDataGrid1.DataSource = ls.Select(x => x.DataRow).ToList().CopyToDataTable();

            //        foreach (var f in ls)
            //        {
            //            var obj = new Models.ValidateModel()
            //            {
            //                NO = "1",
            //                IDN = f.Fid.ToString(),
            //                NAME = layer.Name,
            //                UID = f.Fid.ToString(),
            //                DESC = CurrentControl.Text
            //            };
                        
            //            Console.WriteLine(string.Format("{0} - {1}", f.Fid, f.Geometry.Length));
            //        }
            //    }
            //}
            //else if (CurrentControl.Name == "rbtype2") //중복도형
            //{
            //    MessageHelper.Info("개발중..." + CurrentControl.Text);

            //}
            //else if (CurrentControl.Name == "rbtype3") //MultiPart
            //{
            //    MessageHelper.Info("개발중..." + CurrentControl.Text);
            //}
            //else if (CurrentControl.Name == "rbtype4") //관로연결부위 분할
            //{
            //    MessageHelper.Info("개발중..." + CurrentControl.Text);
            //}
            //else if (CurrentControl.Name == "rbtype5") //관로에 없는 시설
            //{
            //    MessageHelper.Info("개발중..." + CurrentControl.Text);
            //}
            //else if (CurrentControl.Name == "rbtype6") //수도계량기 -> 급수관로
            //{
            //    var meta = GetLayer("수도계량기");
            //    var sply = GetLayer("급수관로");

            //    if (meta.IsDefault() || sply.IsDefault())
            //    {
            //        return;
            //    }

            //    var sdx = LayerHelper.spatialIndex(sply.Value);

            //    foreach (var m in meta.Value.Features)
            //    {
            //        var ss = sdx.Query(m.Geometry.EnvelopeInternal);

            //    }
            //    ;
               
            //}
            //else if (CurrentControl.Name == "rbtype7") //관로길이가 없거나 0으로 입력된 경우
            //{
            //    MessageHelper.Info("개발중..." + CurrentControl.Text);

            //    var pipe = GetLayer("상수관로");
            //    var sply = GetLayer("급수관로");

                
            //}
        }

        public void Init()
        {
            
        }
    }
}
