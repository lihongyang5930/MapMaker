/*
 * Copyright (C) 2016 Vyacheslav Shevelyov (slavash at aha dot ru)
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see http://www.gnu.org/licenses/.
 */

using System;
using System.IO;

using Epanet.Enums;
using Epanet.Hydraulic.Structures;
using Epanet.Network;
using Epanet.Network.Structures;
using Epanet.Quality;
using Epanet.Quality.Structures;

namespace Epanet.Hydraulic.IO {



    ///<summary>Aware compatible hydraulic step snapshot</summary>
    public class AwareStep {
        private readonly double[] _qn;
        private readonly double[] _ql;
        private readonly double[] _d;
        private readonly double[] _h;
        private readonly double[] _q;
        private readonly double[] _dh;
        private readonly long _hydTime;
        private readonly long _hydStep;

        private const int FORMAT_VERSION = 1;

        public class HeaderInfo {
            public int version;
            public int nodes;
            public int links;
            public long rstart;
            public long rstep;
            public long duration;
        }

        // ReSharper disable RedundantCast

        public static void WriteHeader(
            BinaryWriter outStream,
            HydraulicSim hydraulicSim,
            long rstart,
            long rstep,
            long duration) {
            outStream.Write((int)FORMAT_VERSION);
            outStream.Write((int)hydraulicSim.Nodes.Count);
            outStream.Write((int)hydraulicSim.Links.Count);
            outStream.Write((long)rstart);
            outStream.Write((long)rstep);
            outStream.Write((long)duration);
        }



        public static HeaderInfo ReadHeader(BinaryReader @in) {
            var headerInfo = new HeaderInfo {
                version = @in.ReadInt32(),
                nodes = @in.ReadInt32(),
                links = @in.ReadInt32(),
                rstart = @in.ReadInt64(),
                rstep = @in.ReadInt64(),
                duration = @in.ReadInt64()
            };

            return headerInfo;
        }


        public static void Write(BinaryWriter bw, HydraulicSim hydraulicSim, long hydStep) {
            long hydTime = hydraulicSim.Htime;

            foreach(SimulationNode node in hydraulicSim.Nodes) {
                bw.Write((double)node.SimDemand);
                bw.Write((double)node.SimHead);
                bw.Write((double)0);
            }

            foreach(SimulationLink link in hydraulicSim.Links) {
                bw.Write((double)(link.SimStatus <= StatType.CLOSED ? 0d : link.SimFlow));
                bw.Write((double)(link.First.SimHead - link.Second.SimHead));
                bw.Write((double)0.0);
            }

            bw.Write((long)hydStep);
            bw.Write((long)hydTime);
        }

        public static void WriteHydAndQual(
            BinaryWriter outStream,
            HydraulicSim hydraulicSim,
            QualitySim qualitySim,
            long step,
            long time) {
            QualityNode[] qNodes = qualitySim != null ? qualitySim.NNodes : null;
            QualityLink[] qLinks = qualitySim != null ? qualitySim.NLinks : null;
            var nodes = hydraulicSim.Nodes;
            var links = hydraulicSim.Links;

            // int nNodes = nodes.Count;
            // int nLinks = links.Count;
            // int baSize = (nNodes * 3 + nLinks * 3) * sizeof(double) + sizeof(long) * 2;

            int count = 0;
            foreach (SimulationNode node  in  nodes) {
                outStream.Write((double)node.SimDemand);
                outStream.Write((double)node.SimHead);
                outStream.Write((double)(qualitySim != null ? qNodes[count++].Quality : 0.0));
            }

            count = 0;
            foreach (SimulationLink link  in  links) {
                outStream.Write((double)(link.SimStatus <= StatType.CLOSED ? 0d : link.SimFlow));
                outStream.Write((double)(link.First.SimHead - link.Second.SimHead));
                outStream.Write((double)(qualitySim != null ? qLinks[count++].GetAverageQuality(null) : 0));
            }

            outStream.Write((long)step);
            outStream.Write((long)time);

        }

#if COMMENTED
        public static void WriteHybrid(
            BinaryWriter outStream,
            HydraulicSim hydraulicSim,
            double[] qN,
            double[] qL,
            long step,
            long time) {

            var nodes = hydraulicSim.Nodes;
            var links = hydraulicSim.Links;

            // int nNodes = nodes.Count;
            // int nLinks = links.Count;
            // int baSize = (nNodes * 3 + nLinks * 3) * sizeof(double) + sizeof(long) * 2;

            int count = 0;
            foreach (SimulationNode node  in  nodes) {
                outStream.Write((double)node.SimDemand);
                outStream.Write((double)node.SimHead);
                outStream.Write((double)qN[count++]);
            }

            count = 0;
            foreach (SimulationLink link  in  links) {
                outStream.Write((double)(link.SimStatus <= StatType.CLOSED ? 0d : link.SimFlow));
                outStream.Write((double)(link.First.SimHead - link.Second.SimHead));
                outStream.Write((double)qL[count++]);
            }

            outStream.Write((long)step);
            outStream.Write((long)time);

        }

#endif

        // ReSharper restore RedundantCast

        public AwareStep(BinaryReader br, HeaderInfo headerInfo) {
            int nNodes = headerInfo.nodes;
            int nLinks = headerInfo.links;

            _d = new double[nNodes];
            _h = new double[nNodes];
            _q = new double[nLinks];
            _dh = new double[nLinks];

            _qn = new double[nNodes];
            _ql = new double[nLinks];

            //int baSize = (nNodes * 3 + nLinks * 3) * sizeof(double) + sizeof(long) * 2;
            //byte[] ba = new byte[baSize];
            //inStream.readFully(ba);
            //ByteBuffer buf = ByteBuffer.wrap(ba);

            for (int i = 0; i < nNodes; i++) {
                _d[i] = br.ReadDouble();
                _h[i] = br.ReadDouble();
                _qn[i] = br.ReadDouble();
            }

            for (int i = 0; i < nLinks; i++) {
                _q[i] = br.ReadDouble();
                _dh[i] = br.ReadDouble();
                _ql[i] = br.ReadDouble();
            }

            _hydStep = br.ReadInt64();
            _hydTime = br.ReadInt64();
        }


        public double GetNodeDemand(int id, Node node, FieldsMap fMap) {
            try {
                return fMap != null ? fMap.RevertUnit(FieldType.DEMAND, _d[id]) : _d[id];
            }
            catch (ENException) {
                return 0;
            }
        }

        public double GetNodeHead(int id, Node node, FieldsMap fMap) {
            try {
                return fMap != null ? fMap.RevertUnit(FieldType.HEAD, _h[id]) : _h[id];
            }
            catch (ENException) {
                return 0;
            }
        }

        public double GetNodePressure(int id, Node node, FieldsMap fMap) {
            try {
                double p = (GetNodeHead(id, node, null) - node.Elevation);

                return fMap != null ? fMap.RevertUnit(FieldType.PRESSURE, p) : p;
            }
            catch (ENException) {
                return 0;
            }
        }

        public double GetLinkFlow(int id, Link link, FieldsMap fMap) {
            try {
                return fMap != null ? fMap.RevertUnit(FieldType.FLOW, _q[id]) : _q[id];
            }
            catch (ENException) {
                return 0;
            }
        }


        public double GetLinkVelocity(int id, Link link, FieldsMap fMap) {
            try {
                double v;
                double flow = GetLinkFlow(id, link, null);
                if (link is Pump)
                    v = 0;
                else
                    v = (Math.Abs(flow) / (Math.PI * Math.Pow(link.Diameter, 2) / 4.0));

                return fMap != null ? fMap.RevertUnit(FieldType.VELOCITY, v) : v;
            }
            catch (ENException) {
                return 0;
            }
        }

        public double GetLinkHeadLoss(int id, Link link, FieldsMap fMap) {
            try {
                if (GetLinkFlow(id, link, null) == 0) {
                    return 0.0;
                }
                else {
                    double hh = _dh[id];
                    if (!(link is Pump))
                        hh = Math.Abs(hh);

                    if (link.Type <= LinkType.PIPE)
                        return (1000 * hh / link.Lenght);
                    else
                        return fMap != null ? fMap.RevertUnit(FieldType.HEADLOSS, hh) : hh;
                }
            }
            catch (ENException) {
                return 0;
            }
        }


        public double GetLinkFriction(int id, Link link, FieldsMap fMap) {
            try {
                double f;

                double flow = GetLinkFlow(id, link, null);
                if (link.Type <= LinkType.PIPE && Math.Abs(flow) > Constants.TINY) {


                    double hh = Math.Abs(_dh[id]);
                    f = 39.725 * hh * Math.Pow(link.Diameter, 5) / link.Lenght /
                        (flow * flow);
                }
                else
                    f = 0;

                return fMap != null ? fMap.RevertUnit(FieldType.FRICTION, f) : f;
            }
            catch (ENException) {
                return 0;
            }
        }

        public double GetLinkAvrQuality(int id) { return _ql[id]; }

        public double GetNodeQuality(int id) { return _qn[id]; }

        public long Step { get { return _hydStep; } }

        public long Time { get { return _hydTime; } }
    }

}