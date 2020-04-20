using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DotSpatial.Controls;
using DotSpatial.Data;
using GeoAPI.Geometries;
using MMaker.Diagnosis.Helper;

using Syncfusion.Windows.Forms.Tools;

namespace MMaker.Diagnosis.Views
{
    public partial class LayerLoader : MMaker.Core.Views.BaseForm
    {
        int             _mappingCnts;
        int             _stdColumnCnts;
        string          _cbxPreviousvVal;
        Label           _mappingMsg;
        RadioButtonAdv  _currentLayerBtn;

        //작업 레이어
        Core.Models2.IWTL_Layer _WTLLayer;
        public IDataSet _orgData { get; private set; }

        DataColumn[]    _orgCols;
        DataColumn[]    _stdCols;

        private Control[] _allWTLayerBtns;
        private bool _bShowAllColumns = false;

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="dataSet"></param>
        public LayerLoader(IDataSet dataSet)
        {
            InitializeComponent();
            _orgData = dataSet;
            this._allWTLayerBtns = gbLayerType.GetAllControls(typeof(RadioButtonAdv));
            foreach (var v in this._allWTLayerBtns)
            {
                var obj = MMaker.Core.AppStatic.d_Layers.Where(x => x.Key.KorName() == v.Text).Select(x => x.Key).FirstOrDefault();
                v.Tag = obj;
            }
            InitEvent();
            InitRadioButton();
            Init();
        }

        /// <summary>
        /// 레이어 선택 및 취소 이벤트 설정
        /// </summary>
        private void InitEvent()
        {
            this.btnClose.Click += (s, e) => { DialogResult = DialogResult.Cancel; this.Close(); };
            this.btnConform.Click += BtnConform_Click;

            this.chkShowAllMapping.CheckedChanged += (s, e) =>
            {
                CheckBoxAdv cbx = s as CheckBoxAdv;
                _bShowAllColumns = cbx.Checked;
                if(_currentLayerBtn != null)
                    OnRadioButtonClick(_currentLayerBtn, new EventArgs());
            };
        }

        private void BtnConform_Click(object sender, EventArgs e)
        {
            ///로드 시작
            IMapLayer layer = null;

            if (_allWTLayerBtns.Cast<RadioButtonAdv>().FirstOrDefault(x => x.Checked).Text != "기타")
            {
                ///매핑 완료 체크
                if (_stdColumnCnts != _mappingCnts)
                {
                    MessageBox.Show("모든 표준 속성이 매핑 완료된 후"
                        + "\n진행할 수 있습니다."
                        , base.MmakerShell.AppTitle);
                    return;
                }

                ///선택 레이어를 표준 WTL레이어로 변환한다.
                IFeatureSet cfs = CurrentFeatureSet();
                if (cfs == null)
                {
                    MessageBox.Show("표준 레이어에 등록되지 않은 레이어입니다."
                        , base.MmakerShell.AppTitle);
                    return;
                }

                ///[20200323] fdragons - 표준 레이어가 이미 로드되어 있으면 합칠 것인지 확인한다.
                var v = MmakerShell.AppManager.Map.Layers.FirstOrDefault(x => x.DataSet?.Name == cfs.Name);
                if (v != null)
                {
                    layer = v;
                    if (DialogResult.Yes != MessageBox.Show($"[{cfs.Name}]"
                        + "\n표준 레이어는 이미 로드되어 있습니다."
                        + "\n기존 레이어에 추가 하시겠습니까?"
                        , base.MmakerShell.AppTitle
                        , MessageBoxButtons.YesNo))
                    {
                        MessageBox.Show($"[{cfs.Name}]"
                            + "\n선택한 레이어는 중복하여 등록할 수 없습니다."
                            , base.MmakerShell.AppTitle, MessageBoxButtons.YesNo);
                        return;
                    }
                }

                ///1. 컬럼 매핑정보 읽기
                DataTable dataTable = ((IFeatureSet)_orgData).DataTable;

                try
                {
                    for (int i = 0; i < lstMappedCols.Items.Count; i++)
                    {
                        ///2. 매핑정보를 이용하여 _orgData의 컬럼명을 표준 컬럼명으로 이름변경
                        bool a = GetFieldNameInlstMappedColsUsingIndex(i, out string szOrg, out string szStd);
                        if (szOrg.Equals("*None*"))
                            continue;

                        /// 표준 명칭이 기 존재하면 스킵
                        if (IsFieldUsedInlstMappedCols(2, szStd))
                            continue;

                        dataTable.Columns[szOrg].ColumnName = szStd;
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                    throw;
                }

                ///3. 선택된 레이어 데이터를 표준레이어로 복제한다.
                try
                {
                    foreach (IFeature f in ((IFeatureSet)_orgData).Features)
                    {
                        IFeature nf = cfs.AddFeature(f.Geometry);
                        nf.CopyAttributes(f);
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                    throw;
                }

                ///4. 복제된 레이어를 등록한다.
                if (layer == null)
                {
                    layer = MmakerShell.AppManager.Map.Layers.Add(cfs);
                }
            }
            else
            {
                ///[20200323] fdragons - 동일 이름의 레이어가 이미 로드되어 있으면 합칠 것인지 확인한다.
                var v = MmakerShell.AppManager.Map.Layers.FirstOrDefault(x => x.DataSet?.Name == _orgData.Name);
                if (v != null)
                {
                    layer = v;
                    if (DialogResult.Yes != MessageBox.Show($"[{_orgData.Name}]"
                        + "\n동일 레이어가 존재합니다."
                        + "\n기존 레이어에 추가 하시겠습니까?"
                        , base.MmakerShell.AppTitle
                        , MessageBoxButtons.YesNo))
                    {
                        MessageBox.Show($"[{_orgData.Name}]"
                            + "\n선택한 레이어는 등록할 수 없습니다."
                            , base.MmakerShell.AppTitle, MessageBoxButtons.YesNo);
                        return;
                    }

                    ///[20200323] fdragons 선택된 레이어 데이터를 표준레이어로 복제한다.
                    try
                    {
                        var fcs = (IFeatureSet)layer.DataSet;
                        foreach (IFeature f in ((IFeatureSet)_orgData).Features)
                        {
                            IFeature nf = fcs.AddFeature(f.Geometry);
                            nf.CopyAttributes(f);
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine(ex.ToString());
                        throw;
                    }
                }
                else
                {
                    ///참조용 레이어로 추가한다.
                    layer = MmakerShell.AppManager.Map.Layers.Add((IFeatureSet)_orgData);
                }
            }

            ///[20200320] fdragons - 레이어 영역 업데이트
            if (layer != null)
            {
                layer.Extent.ExpandToInclude(((IFeatureSet)_orgData).Extent);
                ZoomToLayer(layer);
            }

            MmakerShell.AppManager.Map.Refresh();

            DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// WTL레이어 버튼 이벤트 핸들러 설정
        /// </summary>
        private void InitRadioButton()
        {
            this.rbPipeLs.Click += new System.EventHandler(this.OnRadioButtonClick);
            this.rbSplyLs.Click += new System.EventHandler(this.OnRadioButtonClick);
            this.rbHeadAs.Click += new System.EventHandler(this.OnRadioButtonClick);
            this.rbValvPs.Click += new System.EventHandler(this.OnRadioButtonClick);
            this.rbMetaPs.Click += new System.EventHandler(this.OnRadioButtonClick);
            this.rbFirePs.Click += new System.EventHandler(this.OnRadioButtonClick);
            this.rbPrgaPs.Click += new System.EventHandler(this.OnRadioButtonClick);
            this.rbFlowPs.Click += new System.EventHandler(this.OnRadioButtonClick);
            this.rbServAs.Click += new System.EventHandler(this.OnRadioButtonClick);
            this.rbGainAs.Click += new System.EventHandler(this.OnRadioButtonClick);
            this.rbPuriAs.Click += new System.EventHandler(this.OnRadioButtonClick);
            this.rbPresAs.Click += new System.EventHandler(this.OnRadioButtonClick);
            this.rbBlbgAs.Click += new System.EventHandler(this.OnRadioButtonClick);
            this.rbBlbmAs.Click += new System.EventHandler(this.OnRadioButtonClick);
            this.rbBlsmAs.Click += new System.EventHandler(this.OnRadioButtonClick);
            this.rbCntrLs.Click += new System.EventHandler(this.OnRadioButtonClick);
            this.rbElevPs.Click += new System.EventHandler(this.OnRadioButtonClick);
            this.rbValbAs.Click += new System.EventHandler(this.OnRadioButtonClick);
            this.rbExtr_a.Click += new System.EventHandler(this.OnRadioButtonClick);
        }

        /// <summary>
        /// WTL레이어 중 선택가능한 레이어를 초기화한다.
        /// </summary>
        private void Init()
        {
            var set = _orgData as IFeatureSet;
            this.gridLayer.DataSource = set.GetAttributes(0, 30);
            lblLayer.Text = $"파일명 : {set.Filename}";

            foreach (var v in this._allWTLayerBtns)
            {
                if (v.Tag == null)
                {
                    v.Enabled = true;
                    continue;
                }
                else
                {
                    var model = MMaker.Core.AppStatic.d_Layers[(v.Tag as Core.Models2.IWTL_Layer)];
                    v.Enabled = model.FeatureType == FeatureType.Unspecified || model.FeatureType == set.FeatureType;
                }
            }
        }

        /// <summary>
        /// 현재 작업 표준레이어를 돌려준다.
        /// </summary>
        /// <returns></returns>
        private IFeatureSet CurrentFeatureSet()
        {
            RadioButtonAdv v = _allWTLayerBtns.Cast<RadioButtonAdv>().FirstOrDefault(x => x.Checked);
            if (v.Tag == null)
                return null;

            IFeatureSet fc = MMaker.Core.AppStatic.d_Layers[(v.Tag as Core.Models2.IWTL_Layer)];
            fc.Name = v.Text;
            return fc;
        }

        /// <summary>
        /// 20200308 fdragons
        /// 표준레이어 매핑(RadioButton) 선택시 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnRadioButtonClick(object sender, EventArgs e)
        {
            ///상수정의
            const int BaseIx = 50;
            const int BaseIy = 0;
            const int LblWidth = 100;
            const int CbxWidth = 120;
            const int ColumnHeight = 25;
            const int IncrementIy = 30;
            const int MsgWidth = 256;

            ///시작위치 지정
            int ix = BaseIx;
            int iy = BaseIy;

            ///이전 컨트롤 삭제
            this.gbOutputFields.Controls.Clear();
            this.panelFieldMapping.Controls.Clear();
            this.lstMappedCols.Items.Clear();

            ///매핑 패널 컨트롤 추가
            this.gbOutputFields.Controls.Add(this.panelFieldMapping);
            this.gbOutputFields.Controls.Add(this.lstMappedCols);

            ///선택한 표준레이어 정보 설정
            _currentLayerBtn = (RadioButtonAdv)sender;

            ///선택 레이어명 생성
            _mappingMsg = new Label();
            _mappingMsg.Name = "_mappingMsg";
            _mappingMsg.Location = new System.Drawing.Point(20, 20);
            _mappingMsg.Text = (_currentLayerBtn.Text == "기타") 
                ? $"*** [ {_currentLayerBtn.Text} ] 레이어는 속성 매핑을 수행하지 않습니다." 
                : $"*** [ {_currentLayerBtn.Text} ] ***";
            _mappingMsg.ForeColor = Color.Black;
            _mappingMsg.Size = new System.Drawing.Size(512, 25);
            this.gbOutputFields.Controls.Add(_mappingMsg);

            if(_currentLayerBtn.Text == "기타")
                return;

            ///WTL 레이어 선택
            _WTLLayer = _currentLayerBtn.Tag as Core.Models2.IWTL_Layer;
            IFeatureSet stdSet = MMaker.Core.AppStatic.d_Layers[_WTLLayer];

            ///WTL 레이어가 아니면 리턴
            if(stdSet == null)
                return;

            ///선택된 레이어의 컬럼 리스트를 조회(콤보박스의 아이템으로 사용)
            IFeatureSet orgSet = _orgData as IFeatureSet;
            _orgCols = orgSet.GetColumns();

            ///매핑용 필드 컨트롤 생성
            Label lbl1, lbl2, lbl3;
            ComboBoxAdv cbx;

            _stdCols = stdSet.GetColumns();
            IEnumerable<string> stdColsDesc = _WTLLayer.ColumnsDesc();

            ///매핑 카운트를 초기화
            _mappingCnts = 0;
            _stdColumnCnts = _stdCols.Length;

            for(int i = 0; i < _stdColumnCnts; i++)
            {
                ///컬럼명 생성
                lbl1 = new Label
                {
                    Name = "lbl" + _stdCols[i].Caption,
                    Location = new System.Drawing.Point(ix, iy),
                    Text = _stdCols[i].Caption + " * ",
                    Size = new System.Drawing.Size(LblWidth, ColumnHeight),
                    TextAlign = ContentAlignment.MiddleRight,
                };

                ///매핑아이템 생성
                cbx = new ComboBoxAdv
                {
                    Name = "cbx" + _stdCols[i].Caption,
                    Location = new System.Drawing.Point(ix + LblWidth, iy),
                    Text = "",
                    Size = new System.Drawing.Size(CbxWidth, ColumnHeight),
                    DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList,
                    AllowDrop = true,
                    Tag = $"{_stdCols[i].Caption}"
                };
                cbx.Items.Add("*None*");
                cbx.Items.AddRange(_orgCols);
                cbx.Click += (s, args) =>
                {
                    ComboBoxAdv c = s as ComboBoxAdv;
                    c.SelectedItem = c.SelectedItem ?? "*None*";
                    _cbxPreviousvVal = c.SelectedItem.ToString();
                };
                cbx.SelectedIndexChanged += (s, args) =>
                {
                    ComboBoxAdv c = s as ComboBoxAdv;
                    string selectedItem = c.SelectedItem.ToString();

                    ///선택 속성이 이전과 동일한 경우 스킵한다.
                    if(selectedItem == _cbxPreviousvVal && !selectedItem.Equals("*None*"))
                        return;

                    ///기 선택(사용)된 속성이면 취소한다.
                    if(IsFieldUsedInlstMappedCols(2, selectedItem))
                    {
                        MessageBox.Show("이미 매핑된 속성 필드입니다.", base.MmakerShell.AppTitle);
                        c.SelectedItem = _cbxPreviousvVal;
                        return;
                    }

                    ///기 존재하면 삭제후 삽입
                    int j = 0;
                    for(; j < lstMappedCols.Items.Count; j++)
                    {
                        if(lstMappedCols.Items[j].ToString().Contains(c.Tag.ToString()))
                        {
                            lstMappedCols.Items.RemoveAt(j);
                            lstMappedCols.Items.Add($"{j + 1:D3}:(*)\t^{c.Tag.ToString()}^{selectedItem}^");
                            break;
                        }
                    }
                    if(j == lstMappedCols.Items.Count)
                    {
                        if(!IsFieldUsedInlstMappedCols(1, c.Tag.ToString()))
                            _mappingCnts++;

                        lstMappedCols.Items.Add($"{_mappingCnts:D3}:(*)\t^{c.Tag.ToString()}^{selectedItem}^");
                        DisplayMappingResults();
                    }

                    ///변경사항 유효성 검토
                    bool b = true;
                    string sz = "Skip";
                    bool ret = false;
                    try
                    {
                        if(!c.SelectedItem.Equals("*None*"))
                        {
                            ret = CheckValidation(c, j, out b, out sz);
                            sz = $"return :{ret}, validate :{b.ToString()}, description :{sz}";
                        }
                    }
                    catch(Exception)
                    {
                        throw;
                    }

                    ///유효성 검증 결과 표시
                    string lblName = "vdt" + c.Tag.ToString();
                    Control[] _allLabelControls = panelFieldMapping.GetAllControls(typeof(Label));
                    Label lbl = _allLabelControls.Where(x => x.Name == lblName).First() as Label;
                    lbl.ForeColor = (b) ? Color.Blue : Color.Red;
                    lbl.Text = sz;

                    ///재정렬
                    SortMappedCols();
                };

                ///한글 컬럼명 라벨 생성
                lbl2 = new Label
                {
                    Name = "dsc" + _stdCols[i].Caption,
                    Location = new System.Drawing.Point(ix + LblWidth + CbxWidth, iy),
                    Text = $" * {_WTLLayer.ColumnsDesc().ElementAt(i)}",
                    Size = new System.Drawing.Size(LblWidth, ColumnHeight)
                };

                ///유효성 결과 표시 라벨 생성
                lbl3 = new Label
                {
                    Name = "vdt" + _stdCols[i].Caption,
                    Location = new System.Drawing.Point(ix + LblWidth + CbxWidth + LblWidth, iy),
                    Size = new System.Drawing.Size(MsgWidth, ColumnHeight),
                    AutoSize = true,
                };

                if(!CheckValidation(cbx, i, out bool bValidate, out string szValidation))
                    continue;

                lbl3.ForeColor = (bValidate) ? Color.Blue : Color.Red;
                lbl3.Text = szValidation;

                this.panelFieldMapping.Controls.Add(lbl1);  ///컬럼명 추가
                this.panelFieldMapping.Controls.Add(cbx);   ///매핑아이템 추가
                this.panelFieldMapping.Controls.Add(lbl2);  ///컬럼설명 추가
                this.panelFieldMapping.Controls.Add(lbl3);  ///유효성 검토결과

                ///표시위치 설정
                iy += IncrementIy;
            }

            ///매핑 결과 표시
            DisplayMappingResults();
        }

        /// <summary>
        /// 주어진 필드명이 사용중인지 체크
        /// </summary>
        /// <param name="side"></param>
        /// <param name="szValue"></param>
        /// <returns></returns>
        private bool IsFieldUsedInlstMappedCols(int side, string szValue)
        {
            if(side != 1 && side != 2)
                return false;

            if(side == 2 && szValue.Equals("*None*"))
                return false;

            foreach(var item in lstMappedCols.Items)
            {
                string[] words = item.ToString().Split('^');
                if(words[side].Equals(szValue))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 표준 또는 선택 레이어의 필드명을 구한다.
        /// </summary>
        /// <param name="side">1:표준레이어, 2:선택레이어</param>
        /// <param name="szValue">검색 필드명</param>
        /// <returns>필드명</returns>
        private string GetFieldNameInlstMappedCols(int side, string szValue)
        {
            if(side != 1 || side != 2)
                return null;

            foreach(var item in lstMappedCols.Items)
            {
                string[] words = item.ToString().Split('^');
                if(szValue.Equals("*None*"))
                    continue;
                if(words[side].Equals(szValue))
                {
                    return (side == 1) ? words[2] : words[1];
                }
            }

            return null;
        }

        /// <summary>
        /// 20200317 fdragons
        /// 주어진 인덱스의 선택 속성명과 표준 속성명을 구한다.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="szOrg"></param>
        /// <param name="szStd"></param>
        /// <returns></returns>
        private bool GetFieldNameInlstMappedColsUsingIndex(int index, out string szOrg, out string szStd)
        {
            if(index < 0 || index >= lstMappedCols.Items.Count)
            {
                szOrg = szStd = null;
                return false;
            }

            string[] words = lstMappedCols.Items[index].ToString().Split('^');
            szStd = words[1];
            szOrg = words[2];

            return true;
        }

        /// <summary>
        /// [20200313]fdragons
        /// 자동매핑 및 유효성검증 처리
        /// </summary>
        /// <param name="_orgCols"></param>
        /// <param name="cbx"></param>
        /// <param name="_stdCols"></param>
        /// <param name="wtlLayer"></param>
        /// <param name="i"></param>
        /// <param name="bValidate"></param>
        /// <param name="szValidation"></param>
        /// <returns></returns>
        private bool CheckValidation(ComboBoxAdv cbx, int idx, out bool bValidate, out string szValidation)
        {
            IEnumerable<string> stdColsDesc = _WTLLayer.ColumnsDesc();

            bValidate = true;
            szValidation = "Valid";

            DataColumn orgDc = _orgCols.FirstOrDefault(name => name.ToString() == _stdCols[idx].Caption);
            if(orgDc != null)
            {
                ///1. 자동매핑 표준 속성명(english)
                if(!IsFieldUsedInlstMappedCols(1, cbx.Tag.ToString()))
                    _mappingCnts++;

                lstMappedCols.Items.Add($"{_mappingCnts:D3}:\t^{_stdCols[idx].Caption}^{_stdCols[idx].Caption}^");

                ///2. 유효성검증 컬럼 타입체크
                if(orgDc.DataType != _stdCols[idx].DataType)
                {
                    bValidate = CheckFieldType(orgDc.DataType, _stdCols[idx].DataType);
                    szValidation = $"Type mismatched : std:({_stdCols[idx].DataType}) vs org:({orgDc.DataType})";
                }

                if(_bShowAllColumns) cbx.SelectedText = _stdCols[idx].Caption;
                else return false;
            }
            else
            {   
                orgDc = _orgCols.FirstOrDefault(name => name.ToString() == stdColsDesc.ElementAt(idx));
                if(orgDc != null)
                {
                    ///1. 자동매핑 표준 속성설명(korean)
                    if(!IsFieldUsedInlstMappedCols(1, cbx.Tag.ToString()))
                        _mappingCnts++;

                    lstMappedCols.Items.Add($"{_mappingCnts:D3}:\t^{_stdCols[idx].Caption}^{stdColsDesc.ElementAt(idx)}^");

                    ///2. 유효성검증 컬럼 타입체크
                    if(orgDc.DataType != _stdCols[idx].DataType)
                    {
                        bValidate = CheckFieldType(orgDc.DataType, _stdCols[idx].DataType);
                        szValidation = $"Type mismatched : std:({_stdCols[idx].DataType}) vs org:({orgDc.DataType})";
                    }

                    if(_bShowAllColumns) cbx.SelectedText = stdColsDesc.ElementAt(idx);
                    else return false;
                }
                else
                {
                    ///매핑 실패
                    bValidate = false;
                    szValidation = "UnMapping";
                }
            }

            return true;
        }

        /// <summary>
        /// 선택 타입과 표준 속성 타입을 비교
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private bool CheckFieldType(Type a, Type b)
        {
            bool bValidate = true;

            if(b == typeof(Double))
            {
                if(a != typeof(Double) && a != typeof(Int16) && a != typeof(Int32) && a != typeof(Int64))
                    bValidate = false;
            }
            else if(b == typeof(String))
            {
                if(a != typeof(String) && a != typeof(DateTime))
                    bValidate = false;
            }
            else if(b == typeof(DateTime))
            {
                if(a != typeof(DateTime))
                    bValidate = false;
            }
            else
            {
                bValidate = false;
            }

            return bValidate;
        }

        /// <summary>
        /// 매핑 결과를 설명한다.
        /// </summary>
        private void DisplayMappingResults()
        {
            if(_mappingCnts != _stdColumnCnts)
            {
                _mappingMsg.ForeColor = Color.Red;
                _mappingMsg.Text = $"*** [ {_currentLayerBtn.Text} ] : [{_stdColumnCnts - _mappingCnts} / {_stdColumnCnts} ]개의 속성에 대한 추가 매핑이 필요합니다.";
            }
            else
            {
                _mappingMsg.ForeColor = Color.Blue;
                _mappingMsg.Text = $"*** [ {_currentLayerBtn.Text} ] : [ {_stdColumnCnts} ]개의 속성이 매핑 되었습니다. ***";
            }
        }

        /// <summary>
        /// 리스트박스 재정렬 함수
        /// </summary>
        private void SortMappedCols()
        {
            ArrayList q = new ArrayList();
            foreach(object o in lstMappedCols.Items) q.Add(o);
            q.Sort();
            lstMappedCols.Items.Clear();
            foreach(object o in q) lstMappedCols.Items.Add(o);
        }

        /// <summary>
        /// 선택된 레이어의 범위로 확대
        /// </summary>
        /// <param name="layerToZoom"></param>
        private void ZoomToLayer(IMapLayer layerToZoom)
        {
            const double eps = 1e-7;
            Envelope layerEnvelope = layerToZoom.Extent.ToEnvelope();

            if(layerEnvelope.IsNull)
            {
                MessageBox.Show("(내용없음)위치를 확인할 수 없습니다.", base.MmakerShell.AppTitle);
                return;
            }
            if(layerEnvelope.Width > eps && layerEnvelope.Height > eps)
            {
                layerEnvelope.ExpandBy(layerEnvelope.Width / 10, layerEnvelope.Height / 10); // work item #84
            }
            else
            {
                double zoomInFactor = 0.05; //fixed zoom-in by 10% - 5% on each side
                double newExtentWidth = MmakerShell.AppManager.Map.ViewExtents.Width * zoomInFactor;
                double newExtentHeight = MmakerShell.AppManager.Map.ViewExtents.Height * zoomInFactor;
                layerEnvelope.ExpandBy(newExtentWidth, newExtentHeight);
            }

            MmakerShell.AppManager.Map.ViewExtents = layerEnvelope.ToExtent();
        }
    }
}

