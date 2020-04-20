using System;using System;
using System.Collections.Generic;

namespace MindOne.Epanet.Models
{
    public class LinkValue : IEapnetValue
    {
        Dictionary<LinkProperty, float> _values;

        public LinkValue(TimeSpan timeStep)
        {
            TimeStep = timeStep;
            _values  = new Dictionary<LinkProperty, float>();
        }

        public float this[LinkProperty index]
        {
            get => _values[index];
            set
            {
                _values[index] = value;
            }
        }

        public TimeSpan TimeStep    { get; private set; }
        public float    Diameter    { get => _values[LinkProperty.EN_DIAMETER    ]; }
        public float    Length      { get => _values[LinkProperty.EN_LENGTH      ]; }
        public float    Roughness   { get => _values[LinkProperty.EN_ROUGHNESS   ]; }
        public float    Minorloss   { get => _values[LinkProperty.EN_MINORLOSS   ]; }
        public float    InitStatus  { get => _values[LinkProperty.EN_INITSTATUS  ]; }
        public float    InitSetting { get => _values[LinkProperty.EN_INITSETTING ]; }
        public float    Kbulk       { get => _values[LinkProperty.EN_KBULK       ]; }
        public float    Kwall       { get => _values[LinkProperty.EN_KWALL       ]; }
        public float    Flow        { get => _values[LinkProperty.EN_FLOW        ]; }
        public float    Velocity    { get => _values[LinkProperty.EN_VELOCITY    ]; }
        public float    Headloss    { get => _values[LinkProperty.EN_HEADLOSS    ]; }
        public float    Status      { get => _values[LinkProperty.EN_STATUS      ]; }
        public float    Setting     { get => _values[LinkProperty.EN_SETTING     ]; }
        public float    Energy      { get => _values[LinkProperty.EN_ENERGY      ]; }
    }
}
