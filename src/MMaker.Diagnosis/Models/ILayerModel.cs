using DotSpatial.Controls;
using DotSpatial.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMaker.Diagnosis.Models
{
    public interface ILayerModel
    {
        IMapLayer Layer { get; set; }

        IDataSet OrgLayer { get; set; }

        string Name { get; }

        FeatureType Featuretype { get; }

        List<string> EngName { get; set; }

        List<string> Columns { get; }

        bool IsValidation { get; }
    }
}
