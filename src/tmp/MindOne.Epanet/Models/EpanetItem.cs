using System;
using System.Collections.Generic;

namespace MindOne.Epanet.Models
{
    public class EpanetItem<TValue> 
        where TValue : IEapnetValue
    {
        Dictionary<int, TValue> _values = new Dictionary<int, TValue>();

        public int    Index { get; set; }
        public string Id    { get; set; }

        public void AddValue(TValue value)
        {
            _values.Add((int)value.TimeStep.TotalSeconds, value);
        }
        public TValue GetValue(int timeStep)
        {
            return _values[timeStep];
        }
        public TValue GetValue(double timeStep)
        {
            return GetValue((int)timeStep);
        }
        public TValue GetValue(TimeSpan timeStep)
        {
            return GetValue((int)timeStep.TotalSeconds);
        }
    }
}
