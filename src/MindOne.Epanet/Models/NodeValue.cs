using System;
using System.Collections.Generic;

namespace MindOne.Epanet.Models
{
    public class NodeValue : IEapnetValue
    {
        Dictionary<NodeProperty, float> _values;

        public NodeValue(TimeSpan timeStep)
        {
            TimeStep = timeStep;
            _values  = new Dictionary<NodeProperty, float>();
        }

        public float this[NodeProperty index]
        {
            get => _values[index];
            set
            {
                _values[index] = value;
            }
        }

        public TimeSpan TimeStep    { get; private set; }
        public float    Elevation   { get => _values[NodeProperty.EN_ELEVATION  ]; }
        public float    BaseDemand  { get => _values[NodeProperty.EN_BASEDEMAND ]; }
        public float    Pattern     { get => _values[NodeProperty.EN_PATTERN    ]; }
        public float    Emitter     { get => _values[NodeProperty.EN_EMITTER    ]; }
        public float    InitQual    { get => _values[NodeProperty.EN_INITQUAL   ]; }
        public float    SourceQual  { get => _values[NodeProperty.EN_SOURCEQUAL ]; }
        public float    SourcePat   { get => _values[NodeProperty.EN_SOURCEPAT  ]; }
        public float    SourceType  { get => _values[NodeProperty.EN_SOURCETYPE ]; }
        public float    TankLevel   { get => _values[NodeProperty.EN_TANKLEVEL  ]; }
        public float    Demand      { get => _values[NodeProperty.EN_DEMAND     ]; }
        public float    Head        { get => _values[NodeProperty.EN_HEAD       ]; }
        public float    Pressure    { get => _values[NodeProperty.EN_PRESSURE   ]; }
        public float    Quality     { get => _values[NodeProperty.EN_QUALITY    ]; }
        public float    SourceMass  { get => _values[NodeProperty.EN_SOURCEMASS ]; }
        public float    InitVolume  { get => _values[NodeProperty.EN_INITVOLUME ]; }
        public float    MixModel    { get => _values[NodeProperty.EN_MIXMODEL   ]; }
        public float    MixzoneVol  { get => _values[NodeProperty.EN_MIXZONEVOL ]; }
        public float    TankDiam    { get => _values[NodeProperty.EN_TANKDIAM   ]; }
        public float    MinVolume   { get => _values[NodeProperty.EN_MINVOLUME  ]; }
        public float    VolCurve    { get => _values[NodeProperty.EN_VOLCURVE   ]; }
        public float    MinLevel    { get => _values[NodeProperty.EN_MINLEVEL   ]; }
        public float    MaxLevel    { get => _values[NodeProperty.EN_MAXLEVEL   ]; }
        public float    Mixfraction { get => _values[NodeProperty.EN_MIXFRACTION]; }
        public float    Tankkbulk   { get => _values[NodeProperty.EN_TANK_KBULK ]; }
    }
}
