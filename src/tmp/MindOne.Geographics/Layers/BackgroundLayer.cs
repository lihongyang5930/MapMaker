using BruTile;
using Mapsui.Layers;

namespace MindOne.Geographics.Layers
{
    public class BackgroundLayer : TileLayer
    {
        public BackgroundLayer(ITileSource tileSource, string name, int order)
            : base(tileSource)
        {
            Name  = name;
            Order = order;
            CRS   = tileSource.Schema.Srs;
        }
        public int Order { get; set; }
    }
}
