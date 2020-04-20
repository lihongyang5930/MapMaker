using System.Collections.Generic;

namespace MindOne.Epanet.Models
{
    public class Link : EpanetItem<LinkValue>
    {
        public Node   Node1 { get; set; }
        public Node   Node2 { get; set; }
        public IEnumerable<Point> Vertices { get; set; }
    }
}
