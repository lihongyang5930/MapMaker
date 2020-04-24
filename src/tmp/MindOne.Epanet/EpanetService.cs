using System;
using System.Collections.Generic;
using System.Linq;
using Epanet.Network;
using Epanet.Network.IO.Input;
using MindOne.Epanet.Models;

namespace MindOne.Epanet
{
    public class EpanetService
    {
        public EpanetService()
        {
            Native = new EpanetNativeService();
        }

        public string InpPath { get; set; }
        public string ReportFilePath { get; set; }
        public string BinaryResultFilePath { get; set; }
        public EpanetNativeService Native { get; private set; }
        public Network Network { get; private set; }

        public void Clear()
        {
            InpPath = null;
            ReportFilePath = null;
            BinaryResultFilePath = null;
            Reset();
        }
        public void Reset()
        {
            Network = null;
            Native.Reset();
        }
        public void Open()
        {
            Native.Open(InpPath, ReportFilePath, BinaryResultFilePath);
            LoadNetwork();
        }
        public void Run()
        {
            Reset();
            LoadNetwork();
            Native.Run(InpPath, ReportFilePath, BinaryResultFilePath);
        }

        private void LoadNetwork()
        {
            var parser  = new InpParser();
            Network = parser.Parse(new Network(), InpPath);
        }
    }

    public class EpanetNativeService
    {
        Dictionary<int, Node> _nodes;
        Dictionary<int, Link> _links;

        public int NodesCount { get; private set; }
        public int LinksCount { get; private set; }
        public List<TimeSpan> TimeSteps { get; private set; }

        private void InitializeNodes()
        {
            _nodes = new Dictionary<int, Node>();
            NodesCount = EpanetNative.GetCount(CountType.EN_NODECOUNT);
            for (int index = 1; index <= NodesCount; index++)
            {
                var coord = EpanetNative.GetCoord(index);
                var node  = new Node { 
                    Index = index,
                    Id    = EpanetNative.GetNodeId(index),
                    X     = coord.X,
                    Y     = coord.Y
                };
                _nodes.Add(index, node);
            }
        }
        private void InitializeLinks()
        {
            _links = new Dictionary<int, Link>();
            LinksCount = EpanetNative.GetCount(CountType.EN_LINKCOUNT);
            for (int index = 1; index <= LinksCount; index++)
            {
                var nodes = EpanetNative.GetLinkNodes(index);
                var link  = new Link { 
                    Index = index,
                    Id    = EpanetNative.GetLinkId(index),
                    Node1 = GetNodeByIndex(nodes.Node1Index),
                    Node2 = GetNodeByIndex(nodes.Node2Index)
                };
                _links.Add(index, link);
            }
        }
        public Node GetNodeByIndex(int index)
        {
            if (_nodes.ContainsKey(index))
                return _nodes[index];
            return null;
        }
        public Node GetNodeById(string id)
        {
            foreach (var item in _nodes)
            {
                if (item.Value.Id == id)
                    return item.Value;
            }
            return null;
        }
        public Link GetLinkByIndex(int index)
        {
            if (_links.ContainsKey(index))
                return _links[index];
            return null;
        }
        public Link GetLinkById(string id)
        {
            foreach (var item in _links)
            {
                if (item.Value.Id == id)
                    return item.Value;
            }
            return null;
        }

        public void Reset()
        {
            NodesCount = 0;
            LinksCount = 0;
            _nodes?.Clear();
            _links?.Clear();
            TimeSteps?.Clear();
        }
        public void Open(string inpPath, string reportFilePath, string binaryResultFilePath)
        {
            EpanetNative.Open(inpPath, reportFilePath, binaryResultFilePath);
            InitializeNodes();
            InitializeLinks();
            EpanetNative.Close();
        }
        public void Run(string inpPath, string reportFilePath, string binaryResultFilePath)
        {
            Reset();
            EpanetNative.Open(inpPath, reportFilePath, binaryResultFilePath);
            InitializeNodes();
            InitializeLinks();

            EpanetNative.OpenQ();
            EpanetNative.OpenH();
            EpanetNative.InitH(SaveOption.EN_NOSAVE);
            EpanetNative.InitQ(SaveOption.EN_NOSAVE);

            RunH();
            RunQ();

            EpanetNative.CloseH();
            EpanetNative.CloseQ();
            EpanetNative.Close();
        }

        private void RunH()
        {
            TimeSteps = new List<TimeSpan>();

            while (true)
            {
                var timeStep = EpanetNative.RunH();
                TimeSteps.Add(TimeSpan.FromSeconds(timeStep));
                for (int index = 1; index <= NodesCount; index++)
                {
                    var value = new NodeValue(TimeSpan.FromSeconds(timeStep));
                    value[NodeProperty.EN_ELEVATION  ] = EpanetNative.GetNodeValue(index, NodeProperty.EN_ELEVATION  );
                    value[NodeProperty.EN_BASEDEMAND ] = EpanetNative.GetNodeValue(index, NodeProperty.EN_BASEDEMAND );
                    value[NodeProperty.EN_PATTERN    ] = EpanetNative.GetNodeValue(index, NodeProperty.EN_PATTERN    );
                    value[NodeProperty.EN_EMITTER    ] = EpanetNative.GetNodeValue(index, NodeProperty.EN_EMITTER    );
                    value[NodeProperty.EN_INITQUAL   ] = EpanetNative.GetNodeValue(index, NodeProperty.EN_INITQUAL   );
                    value[NodeProperty.EN_SOURCEQUAL ] = EpanetNative.GetNodeValue(index, NodeProperty.EN_SOURCEQUAL );
                    value[NodeProperty.EN_SOURCEPAT  ] = EpanetNative.GetNodeValue(index, NodeProperty.EN_SOURCEPAT  );
                    value[NodeProperty.EN_SOURCETYPE ] = EpanetNative.GetNodeValue(index, NodeProperty.EN_SOURCETYPE );
                    value[NodeProperty.EN_TANKLEVEL  ] = EpanetNative.GetNodeValue(index, NodeProperty.EN_TANKLEVEL  );
                    value[NodeProperty.EN_DEMAND     ] = EpanetNative.GetNodeValue(index, NodeProperty.EN_DEMAND     );
                    value[NodeProperty.EN_HEAD       ] = EpanetNative.GetNodeValue(index, NodeProperty.EN_HEAD       );
                    value[NodeProperty.EN_PRESSURE   ] = EpanetNative.GetNodeValue(index, NodeProperty.EN_PRESSURE   );
                    value[NodeProperty.EN_QUALITY    ] = EpanetNative.GetNodeValue(index, NodeProperty.EN_QUALITY    );
                    value[NodeProperty.EN_SOURCEMASS ] = EpanetNative.GetNodeValue(index, NodeProperty.EN_SOURCEMASS );
                    value[NodeProperty.EN_INITVOLUME ] = EpanetNative.GetNodeValue(index, NodeProperty.EN_INITVOLUME );
                    value[NodeProperty.EN_MIXMODEL   ] = EpanetNative.GetNodeValue(index, NodeProperty.EN_MIXMODEL   );
                    value[NodeProperty.EN_MIXZONEVOL ] = EpanetNative.GetNodeValue(index, NodeProperty.EN_MIXZONEVOL );
                    value[NodeProperty.EN_TANKDIAM   ] = EpanetNative.GetNodeValue(index, NodeProperty.EN_TANKDIAM   );
                    value[NodeProperty.EN_MINVOLUME  ] = EpanetNative.GetNodeValue(index, NodeProperty.EN_MINVOLUME  );
                    value[NodeProperty.EN_VOLCURVE   ] = EpanetNative.GetNodeValue(index, NodeProperty.EN_VOLCURVE   );
                    value[NodeProperty.EN_MINLEVEL   ] = EpanetNative.GetNodeValue(index, NodeProperty.EN_MINLEVEL   );
                    value[NodeProperty.EN_MAXLEVEL   ] = EpanetNative.GetNodeValue(index, NodeProperty.EN_MAXLEVEL   );
                    value[NodeProperty.EN_MIXFRACTION] = EpanetNative.GetNodeValue(index, NodeProperty.EN_MIXFRACTION);
                    value[NodeProperty.EN_TANK_KBULK ] = EpanetNative.GetNodeValue(index, NodeProperty.EN_TANK_KBULK );

                    var node = GetNodeByIndex(index);
                    node.AddValue(value);
                }
                for (int index = 1; index <= LinksCount; index++)
                {
                    var value = new LinkValue(TimeSpan.FromSeconds(timeStep));
                    value[LinkProperty.EN_DIAMETER   ] = EpanetNative.GetLinkValue(index, LinkProperty.EN_DIAMETER   );
                    value[LinkProperty.EN_LENGTH     ] = EpanetNative.GetLinkValue(index, LinkProperty.EN_LENGTH     );
                    value[LinkProperty.EN_ROUGHNESS  ] = EpanetNative.GetLinkValue(index, LinkProperty.EN_ROUGHNESS  );
                    value[LinkProperty.EN_MINORLOSS  ] = EpanetNative.GetLinkValue(index, LinkProperty.EN_MINORLOSS  );
                    value[LinkProperty.EN_INITSTATUS ] = EpanetNative.GetLinkValue(index, LinkProperty.EN_INITSTATUS );
                    value[LinkProperty.EN_INITSETTING] = EpanetNative.GetLinkValue(index, LinkProperty.EN_INITSETTING);
                    value[LinkProperty.EN_KBULK      ] = EpanetNative.GetLinkValue(index, LinkProperty.EN_KBULK      );
                    value[LinkProperty.EN_KWALL      ] = EpanetNative.GetLinkValue(index, LinkProperty.EN_KWALL      );
                    value[LinkProperty.EN_FLOW       ] = EpanetNative.GetLinkValue(index, LinkProperty.EN_FLOW       );
                    value[LinkProperty.EN_VELOCITY   ] = EpanetNative.GetLinkValue(index, LinkProperty.EN_VELOCITY   );
                    value[LinkProperty.EN_HEADLOSS   ] = EpanetNative.GetLinkValue(index, LinkProperty.EN_HEADLOSS   );
                    value[LinkProperty.EN_STATUS     ] = EpanetNative.GetLinkValue(index, LinkProperty.EN_STATUS     );
                    value[LinkProperty.EN_SETTING    ] = EpanetNative.GetLinkValue(index, LinkProperty.EN_SETTING    );
                    value[LinkProperty.EN_ENERGY     ] = EpanetNative.GetLinkValue(index, LinkProperty.EN_ENERGY     );

                    var link = GetLinkByIndex(index);
                    link.AddValue(value);
                }
                if (EpanetNative.NextH() == 0) 
                    break;
            }
        }
        private void RunQ()
        {
            while (true)
            {
                var timeStep = EpanetNative.RunQ();
                if (EpanetNative.NextQ() == 0)
                    break;
            }
        }
    }
}