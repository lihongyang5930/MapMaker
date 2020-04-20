using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DrPipe.Core.Models;
using MindOne.Epanet;
using MindOne.Epanet.Models;
using MindOne.Geographics.Controls;
using MindOne.Geographics.Layers;

namespace DrPipe.Diagnosis.Views.Local.Analysis.PipeNetwork
{
    public partial class PipeNetworkView : UserControl
    {
        NetworkMap   _networkMap;
        TimeSpan     _timeStep;
        EpanetLegend _nodeLegend;
        EpanetLegend _linkLegend;
        Func<NodeValue, double> _nodeValueselector;
        Func<LinkValue, double> _linkValueselector;

        public PipeNetworkView(BackgroundLayerSet backgroundLayerSet)
        {
            InitializeComponent();
            _networkMap = new NetworkMap(backgroundLayerSet);
            elementHost.Child = _networkMap;
        }

        public void Clear()
        {
            _networkMap.Clear();
        }
        public void LoadInp(EpanetService service)
        {
            Clear();
            _networkMap.LoadInp(service);
        }

        public void SetDefaultColor(Color color)
        {
            _networkMap.SetDefaultColor(ToWpfColor(color));
        }
        public void SetNodeLegend(EpanetLegend legend, Func<NodeValue, double> nodeValueselector)
        {
            _nodeLegend        = legend;
            _nodeValueselector = nodeValueselector;
            if (legend == null)
            {
                _networkMap.CollapseNodeLegend();
            }
            else
            {
                _networkMap
                    .SetNodeLegend(
                        legend.Title, 
                        legend.Unit, 
                        legend.Colors.Select(ToWpfColor).ToArray(), 
                        legend.BoundaryValues.Select(x => x.ToString()).ToArray());
            }
        }
        public void SetLinkLegend(EpanetLegend legend, Func<LinkValue, double> linkValueselector)
        {
            _linkLegend        = legend;
            _linkValueselector = linkValueselector;
            if (legend == null)
            {
                _networkMap.CollapseLinkLegend();
            }
            else
            {
                _networkMap
                    .SetLinkLegend(
                        legend.Title, 
                        legend.Unit, 
                        legend.Colors.Select(ToWpfColor).ToArray(), 
                        legend.BoundaryValues.Select(x => x.ToString()).ToArray());
            }
        }
        public void SetTimeStep(TimeSpan timeStep)
        {
            _timeStep = timeStep;
        }
        public void Browse(EpanetService service)
        {
            if (_nodeLegend != null)
            {
                _networkMap
                    .BrowseNode(
                        _nodeLegend.Colors.Select(ToWpfColor).ToArray(), 
                        _nodeLegend.BoundaryValues, 
                        (nodeId) => GetNodeValue(service, nodeId));
            }
            if (_linkLegend != null)
            {
                _networkMap
                    .BrowseLink(
                        _linkLegend.Colors.Select(ToWpfColor).ToArray(), 
                        _linkLegend.BoundaryValues, 
                        (linkId) => GetLinkValue(service, linkId));
            }
            _networkMap.RefreshGraphics();
        }
        
        public override void Refresh()
        {
            _networkMap.Refresh();
            base.Refresh();
        }

        private System.Windows.Media.Color[] ToWpfColors(System.Drawing.Color[] colors)
        {
            return colors.Select(ToWpfColor).ToArray();
        }
        private System.Windows.Media.Color ToWpfColor(System.Drawing.Color color)
        {
            return new System.Windows.Media.Color() { 
                A = color.A,
                R = color.R,
                G = color.G,
                B = color.B,
            };
        }

        private double GetNodeValue(EpanetService service, string nodeId)
        {
            var node  = service.Native.GetNodeById(nodeId);
            var value = node.GetValue(_timeStep);
            return _nodeValueselector.Invoke(value);
        }
        private double GetLinkValue(EpanetService service, string nodeId)
        {
            var link  = service.Native.GetLinkById(nodeId);
            var value = link.GetValue(_timeStep);
            return _linkValueselector.Invoke(value);
        }
    }
}
