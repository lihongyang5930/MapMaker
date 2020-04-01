using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotSpatial.Controls;
using DotSpatial.Data;

namespace MMaker.Diagnosis.Models
{
    /// <summary>
    /// 대블록 레이어
    /// </summary>
    public class LayerBlbg : ILayerModel
    {
        public LayerBlbg()
        {
            EngName = new List<string>()
            {
                "WTL_BLBG_AS"
            };
            Columns = new List<string>()
            {
                "SGCCD ",
                "FTR_CDE",
                "FTR_IDN",
                "BLK_NAM",
                "WSP_NAM",
                "WSP_BIG",
                "MNG_CDE",
                "PPL_NUM",
                "GNR_NUM",
                "UPD_DTM",
            };
        }

        public IMapLayer Layer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name
        {
            get { return "대블록"; }
        }

        public FeatureType Featuretype
        {
            get
            {
                var f = (IFeatureSet)Layer?.DataSet;
                return f.FeatureType;
            }
        }

        public List<string> EngName { get; set; }

        public List<string> Columns { get; private set; }

        public bool IsValidation
        {
            get
            {
                var f = System.IO.Path.GetFileNameWithoutExtension(OrgLayer?.Filename);
                if (EngName.Contains(f))
                {
                    return true;
                }
                return false;
            }
        }

        public IDataSet OrgLayer
        {
            get;
            set;
        }
    }
    
    /// <summary>
    /// 중블록 레이어
    /// </summary>
    public class LayerBlbm : ILayerModel
    {
        public LayerBlbm()
        {
            EngName = new List<string>()
            {
                "WTL_BLBM_AS"
            };
            Columns = new List<string>()
            {
                "SGCCD ",
                "FTR_CDE",
                "FTR_IDN",
                "BLK_NAM",
                "WSP_NAM",
                "WSP_BIG",
                "MNG_CDE",
                "PPL_NUM",
                "GNR_NUM",
                "UBL_CDE",
                "UBL_IDN",
                "UPD_DTM",
            };
        }

        public FeatureType Featuretype
        {
            get
            {
                var f = (IFeatureSet)Layer?.DataSet;
                return f.FeatureType;
            }
        }

        public List<string> EngName { get; set; }

        public List<string> Columns { get; private set; }

        public bool IsValidation
        {
            get
            {
                return true;
            }
        }

        public IDataSet OrgLayer
        {
            get => throw new NotImplementedException(); set => throw new NotImplementedException();
        }

        public IMapLayer Layer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name
        {
            get { return "중블록"; }
        }
    }
    
    /// <summary>
    /// 소블록 레이어
    /// </summary>
    public class LayerBlsm : ILayerModel
    {
        public LayerBlsm()
        {
            EngName = new List<string>()
            {
                "WTL_BLSM_AS"
            };
            Columns = new List<string>()
            {
                "SGCCD ",
                "FTR_CDE",
                "FTR_IDN",
                "BLK_NAM",
                "WSP_NAM",
                "WSP_BIG",
                "MNG_CDE",
                "PPL_NUM",
                "GNR_NUM",
                "UBL_CDE",
                "UBL_IDN",
                "UPD_DTM",
            };
        }

        public IMapLayer Layer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name
        {
            get { return "소블록"; }
        }
        public FeatureType Featuretype
        {
            get
            {
                var f = (IFeatureSet)Layer?.DataSet;
                return f.FeatureType;
            }
        }

        public List<string> EngName { get; set; }

        public List<string> Columns { get; private set; }

        public bool IsValidation
        {
            get
            {
                return true;
            }
        }

        public IDataSet OrgLayer
        {
            get => throw new NotImplementedException(); set => throw new NotImplementedException();
        }
    }
    /*
    /// <summary>
    /// 상수관로 레이어
    /// </summary>
    public class LayerPipe : IMMLayer
    {
        public LayerPipe()
        { }

        public IMapLayer Layer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name
        {
            get { return "상수관로"; }
        }
    }
    /// <summary>
    /// 상수관로 레이어
    /// </summary>
    public class LayerSply : IMMLayer
    {
        public LayerSply()
        { }

        public IMapLayer Layer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name
        {
            get { return "급수관로"; }
        }
    }
    /// <summary>
    /// 소화전 레이어
    /// </summary>
    public class LayerFire : IMMLayer
    {
        public LayerFire()
        { }

        public IMapLayer Layer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name
        {
            get { return "소화전"; }
        }
    }
    /// <summary>
    /// 소화전 레이어
    /// </summary>
    public class LayerFlow : IMMLayer
    {
        public LayerFlow()
        { }

        public IMapLayer Layer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name
        {
            get { return "유량계"; }
        }
    }
    /// <summary>
    /// 소화전 레이어
    /// </summary>
    public class LayerMeta : IMMLayer
    {
        public LayerMeta()
        { }

        public IMapLayer Layer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name
        {
            get { return "수도계량기"; }
        }
    }
    /// <summary>
    /// 상수관로 레이어
    /// </summary>
    public class LayerPres : IMMLayer
    {
        public LayerPres()
        { }

        public IMapLayer Layer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name
        {
            get { return "가압장"; }
        }
    }
    /// <summary>
    /// 상수관로 레이어
    /// </summary>
    public class LayerPrga : IMMLayer
    {
        public LayerPrga()
        { }

        public IMapLayer Layer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name
        {
            get => Layer?.LegendText;
            set => Layer.LegendText = value;
        }
    }
    /// <summary>
    /// 상수관로 레이어
    /// </summary>
    public class LayerPuri : IMMLayer
    {
        public LayerPuri()
        { }

        public IMapLayer Layer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name
        {
            get => Layer?.LegendText;
            set => Layer.LegendText = value;
        }
    }
    /// <summary>
    /// 상수관로 레이어
    /// </summary>
    public class LayerServ : IMMLayer
    {
        public LayerServ()
        { }

        public IMapLayer Layer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name
        {
            get => Layer?.LegendText;
            set => Layer.LegendText = value;
        }
    }
    /// <summary>
    /// 상수관로 레이어
    /// </summary>
    public class LayerValb : IMMLayer
    {
        public LayerValb()
        { }

        public IMapLayer Layer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name
        {
            get => Layer?.LegendText;
            set => Layer.LegendText = value;
        }
    }
    /// <summary>
    /// 상수관로 레이어
    /// </summary>
    public class LayerValv : IMMLayer
    {
        public LayerValv()
        { }

        public IMapLayer Layer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name
        {
            get => Layer?.LegendText;
            set => Layer.LegendText = value;
        }
    }
    */
}
