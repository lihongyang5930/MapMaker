namespace MindOne.Epanet.Models
{
    public class Control
    {
        public int         ControlIndex { get; set; }
        public ControlType ControlType  { get; set; }
        public int         LinkIndex    { get; set; }
        public float       Setting      { get; set; }
        public int         NodeIndex    { get; set; }
        public float       Level        { get; set; }
    }
}
