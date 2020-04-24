namespace DrPipe.Diagnosis.Models
{
    public class Pattern
    {
        public string         Category { get; set; }
        public string         Name     { get; set; }
        public PatternValue[] Values   { get; set; }
    }
}
