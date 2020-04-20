namespace MindOne.Epanet.Models
{
    public class Curve
    {
        public int    CurveIndex { get; set; }
        public string Id         { get; set; } 
        public int    NValues    { get; set; } 
        public float  XValues    { get; set; } 
        public float  YValues    { get; set; }
    }
}
