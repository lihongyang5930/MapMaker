using System;

namespace DrPipe.Diagnosis.Models
{
    public class PatternValue
    {
        public PatternValue()
        {
        }
        public PatternValue(int no, double value)
        {
            No    = no;
            Value = value;
        }
        public int    No    { get; set; }
        public double Value { get; set; }
    }
}
