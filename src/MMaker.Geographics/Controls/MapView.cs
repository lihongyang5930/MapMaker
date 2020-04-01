using DotSpatial.Controls;
using DotSpatial.Symbology;

using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MMaker.Geographics.Controls
{
    public partial class MapView : UserControl
    {
        public MapView()
        {
            InitializeComponent();

            //this._map.MouseMove += (s, e) =>
            //{
            //    var args = new GeoMouseArgs(e, this._map);
            //    lblCoord.Text = $"X:{Math.Round(args.GeographicLocation.X, 2)} Y:{Math.Round(args.GeographicLocation.Y, 2)}";
            //};

            //this._map.Projection = DotSpatial.Projections.ProjectionInfo.FromEpsgCode(4326); //EPSG:4326 - WGS84
        }

        public ILayer GetLayer(string name)
        {
            return this._map?.GetLayers().Where(x => x.DataSet != null).FirstOrDefault(x => x.DataSet.Name == name);
        }

        public Map Map { get => _map; set => _map = value; }
    }
}
