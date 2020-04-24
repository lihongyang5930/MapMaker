using System;

namespace DrPipe.Core.Models
{
    public class NameValueItem<TValue>
    {
        public NameValueItem()
        {
        }
        public NameValueItem(string name, TValue value)
        {
            Name  = name;
            Value = value;
        }
        public string Name  { get; set; }
        public TValue Value { get; set; }
    }

    public class TimeSpanNameValueItem : NameValueItem<TimeSpan>
    {
        public TimeSpanNameValueItem()
        {
        }
        public TimeSpanNameValueItem(string name, TimeSpan value) 
            : base(name, value)
        {
        }
    }
}
