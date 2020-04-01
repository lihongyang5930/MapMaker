using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotSpatial.Controls;
using DotSpatial.Data;

namespace MMaker.Diagnosis.Models
{
    public abstract class LayerModel2 : ILayerModel
    {
        public IMapLayer Layer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IDataSet OrgLayer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Name => throw new NotImplementedException();

        public FeatureType Featuretype
        {
            get
            {
                var f = (IFeatureSet)Layer?.DataSet;
                return f.FeatureType;
            }
        }

        public List<string> EngName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public List<string> Columns => throw new NotImplementedException();

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
    }
}
