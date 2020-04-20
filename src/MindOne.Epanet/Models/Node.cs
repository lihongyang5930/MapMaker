namespace MindOne.Epanet.Models
{
    public class Node : EpanetItem<NodeValue>
    {
        public float  X     { get; set; }
        public float  Y     { get; set; }
    }
}
