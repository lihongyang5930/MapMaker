using System;
using System.Runtime.InteropServices;
using System.Text;
using MindOne.Epanet.Models;

namespace MindOne.Epanet
{
    //
    // http://wateranalytics.org/EPANET
    //
    public class EpanetNative
    {
        //public static void Epanet(string inpfile, string reportfile = null, string binaryresultfile = null)
        //{
        //    ENepanet(
        //        inpfile, 
        //        reportfile ?? string.Empty, 
        //        binaryresultfile ?? string.Empty);
        //}

        public static void Open(string inpfile, string rptFile = null, string binOutFile = null)
        {
            ENopen(
                inpfile, 
                rptFile ?? string.Empty, 
                binOutFile ?? string.Empty);
        }
        public static void SaveInpFile(string inpfile)
        {
            ENsaveinpfile(inpfile);
        }
        public static void Close()
        {
            ENclose();
        }
        public static void SolveH()
        {
            ENsolveH();
        }
        public static void SaveH()
        {
            ENsaveH();
        }
        public static void OpenH()
        {
            ENopenH();
        }
        public static void InitH(SaveOption initFlag = SaveOption.EN_NOSAVE)
        {
            ENinitH((int)initFlag);
        }
        public static long RunH()
        {
            long currentTime = 0;
            ENrunH(ref currentTime);
            return currentTime;
        }
        public static long NextH()
        {
            int timestep = 0;
            ENnextH(ref timestep);
            return timestep;
        }
        public static void CloseH()
        {
            ENcloseH();
        }
        public static void SaveHydfile(string fileName)
        {
            ENsavehydfile(fileName);
        }
        public static void UseHydfile(string fileName)
        {
            ENusehydfile(fileName);
        }
        public static void SolveQ()
        {
            ENsolveQ();
        }
        public static void OpenQ()
        {
            ENopenQ();
        }
        public static void InitQ(SaveOption saveFlag)
        {
            ENinitQ((int)saveFlag);
        }
        public static long RunQ()
        {
            long currentTime = 0;
            ENrunQ(ref currentTime);
            return currentTime;
        }
        public static long NextQ()
        {
            long timeStep = 0;
            ENnextQ(ref timeStep);
            return timeStep;
        }
        public static long StepQ()
        {
            long timeLeft = 0;
            ENstepQ(ref timeLeft);
            return timeLeft;
        }
        public static void CloseQ()
        {
            ENcloseQ();
        }
        public static void WriteLine(string line)
        {
            ENwriteline(line);
        }
        public static void Report()
        {
            ENreport();
        }
        public static void ResetReport()
        {
            ENresetreport();
        }
        public static void SetReport(string reportFormat)
        {
            ENsetreport(reportFormat);
        }
        public static Control GetControl(int controlIndex)
        {
            CheckEpanetIndex(controlIndex);

            int   controlType = 0;
            int   linkIndex   = 0;
            float setting     = 0;
            int   nodeIndex   = 0;
            float level       = 0;
            ENgetcontrol(controlIndex, ref controlType, ref linkIndex, ref setting, ref nodeIndex, ref level);
            return new Control { 
                ControlIndex = controlIndex,
                ControlType  = (ControlType)controlType,
                LinkIndex    = linkIndex,
                Setting      = setting,
                NodeIndex    = nodeIndex,
                Level        = level,
            };
        }
        public static int GetCount(CountType type)
        {
            int count = 0;
            ENgetcount((int)type, ref count);
            return count;
        }
        public static SimulationOptions GetOption(int code)
        {
            float value = 0;
            ENgetoption(code, ref value);
            return (SimulationOptions)code;
        }
        public static float GetTimeParam(TimeProperty code)
        {
            long value = 0;
            ENgettimeparam((int)code, ref value);
            return value;
        }
        public static FlowUnits GetFlowUnits()
        {
            var code = 0;
            ENgetflowunits(ref code);
            return (FlowUnits)code;
        }
        public static int GetPatternIndex(string id)
        {
            int index = 0;
            ENgetpatternindex(id, ref index);
            return index;
        }
        public static string GetPatternId(int index)
        {
            var id = new StringBuilder();
            ENgetpatternid(index, id);
            return id.ToString();
        }
        public static int GetPatternLen(int index)
        {
            int len = 0;
            ENgetpatternlen(index, ref len);
            return len;
        }
        public static float GetPatternValue(int index, int period)
        {
            float value = 0;
            ENgetpatternvalue(index, period, ref value);
            return value;
        }
        public float GetAveragePatternValue (int index)
        {
            float value = 0;
            ENgetaveragepatternvalue(index, ref value);
            return value;
        }
        public static QualType GetQualType()
        {
            int qualcode = 0;
            int tracenode = 0;
            ENgetqualtype(ref qualcode, ref tracenode);
            return new QualType { 
                QualCode = qualcode,
                TraceNode = tracenode,
            };
        }
        public static string GetError(int errCode, int maxLen)
        {
            var errMsg = new StringBuilder();
            ENgeterror(errCode, errMsg, maxLen);
            return errMsg.ToString();
        }
        public static float GetStatistic(StatisticTypes code)
        {
            float value = 0;
            ENgetstatistic((int)code, ref value);
            return value;
        }
        public static int GetNodeIndex(string id)
        {
            int nodeIndex = 0;
            ENgetnodeindex(id, ref nodeIndex);
            return nodeIndex;
        }
        public static string GetNodeId(int index)
        {
            CheckEpanetIndex(index);

            var nodeId = new StringBuilder();
            ENgetnodeid(index, nodeId);
            return nodeId.ToString();
        }
        public static NodeType GetNodeType(int index)
        {
            CheckEpanetIndex(index);

            int code = 0;
            ENgetnodetype(index, ref code);
            return (NodeType)code;
        }
        public static float GetNodeValue(int index, NodeProperty code)
        {
            CheckEpanetIndex(index);

            float value = 0;
            ENgetnodevalue(index, (int)code, ref value);
            return value;
        }
        public static Point GetCoord(int index)
        {
            CheckEpanetIndex(index);

            float x = 0;
            float y = 0;
            ENgetcoord(index, ref x, ref y);
            return new Point { X = x, Y = y };
        }
        public static void SetCoord(int index, float x, float y)
        {
            CheckEpanetIndex(index);
            ENsetcoord(index, x, y);
        }
        public static int GetNumDemands(int nodeIndex)
        {
            CheckEpanetIndex(nodeIndex);

            int numDemands = 0;
            ENgetnumdemands(nodeIndex, ref numDemands);
            return numDemands;
        }
        public static float GetBaseDemand(int nodeIndex, int demandIndex)
        {
            CheckEpanetIndex(nodeIndex);
            CheckEpanetIndex(demandIndex);

            float baseDemand = 0;
            ENgetbasedemand(nodeIndex, demandIndex, ref baseDemand);
            return baseDemand;
        }
        public static int GetDemandPattern (int nodeIndex, int demandIndex)
        {
            int pattIndex = 0;
            ENgetdemandpattern(nodeIndex, demandIndex, ref pattIndex);
            return pattIndex;
        }
        public static int GetLinkIndex(string id)
        {
            int index = 0;
            ENgetlinkindex(id, ref index);
            return index;
        }
        public static string GetLinkId(int index)
        {
            CheckEpanetIndex(index);

            var id = new StringBuilder();
            ENgetlinkid(index, id);
            return id.ToString();
        }
        public static int GetLinkType(int index)
        {
            CheckEpanetIndex(index);

            int code = 0;
            ENgetlinktype(index, ref code);
            return code;
        }
        public static LinkNodes GetLinkNodes(int linkIndex)
        {
            CheckEpanetIndex(linkIndex);

            int index1 = 0;
            int index2 = 0;
            ENgetlinknodes(linkIndex, ref index1, ref index2);
            return new LinkNodes {
                Node1Index = index1,
                Node2Index = index2
            };
        }
        public static float GetLinkValue(int index, LinkProperty code)
        {
            CheckEpanetIndex(index);

            float res = 0;
            ENgetlinkvalue(index, (int)code, ref res);
            return res;
        }
        public static Curve GetCurve(int curveIndex)
        {
            CheckEpanetIndex(curveIndex);

            var   id      = new StringBuilder();
            int   nValues = 0;
            float xValues = 0;
            float yValues = 0;
            ENgetcurve(curveIndex, id, ref nValues, ref xValues, ref yValues);
            return new Curve { 
                CurveIndex = curveIndex,
                Id         = id.ToString(),
                NValues    = nValues,
                XValues    = xValues,
                YValues    = yValues,
            };
        }
        public static int GetHeadCurveIndex(int pumpIndex)
        {
            int curveIndex = 0;
            ENgetheadcurveindex(pumpIndex, ref curveIndex);
            return curveIndex;
        }
        public static CurveType GetPumpType(int linkIndex)
        {
            int outType = 0;
            ENgetpumptype(linkIndex, ref outType);
            return (CurveType)outType;
        }
        public static int GetVersion()
        {
            int res = 0;
            ENgetversion(ref res);
            return res;
        }
        public static void SetControl(Control control)
        {
            SetControl(
                control.ControlIndex,
                control.ControlType,
                control.LinkIndex,
                control.Setting,
                control.NodeIndex,
                control.Level
            );
        }
        public static void SetControl(int controlIndex, ControlType controlType, int linkIndex, float setting, int nodeIndex, float level)
        {
            CheckEpanetIndex(controlIndex);
            ENsetcontrol(controlIndex, (int)controlType, linkIndex, setting, nodeIndex, level);
        }
        public static void SetNodeValue(int index, NodeProperty code, float value)
        {
            CheckEpanetIndex(index);
            ENsetnodevalue(index, (int)code, value);
        }
        public static void SetLinkValue(int index, LinkProperty code, float value)
        {
            CheckEpanetIndex(index);
            ENsetlinkvalue(index, (int)code, value);
        }
        public static void AddPattern (string id)
        {
            ENaddpattern(id);
        }
        public static void SetPattern (int index, float f, int len)
        {
            CheckEpanetIndex(index);
            ENsetpattern(index, f, len);
        }
        public static void SetPatternValue (int index, int period, float value)
        {
            CheckEpanetIndex(index);
            ENsetpatternvalue(index, period, value);
        }
        public static void SetTimeParam(TimeProperty code, float value)
        {
            ENsettimeparam((int)code, value);
        }
        public static void SetOption(SimulationOptions code, float value)
        {
            ENsetoption((int)code, value);
        }
        public static void SetStatusReport(int code)
        {
            ENsetstatusreport(code);
        }
        public static void SetQualType(QualityType code, string chemName, string chemUnits, string traceNode)
        {
            ENsetqualtype((int)code, chemName, chemUnits, traceNode);
        }
        public static QualInfo GetQualInfo()
        {
            int qualCode  = 0;
            var chemName  = new StringBuilder();
            var chemUnits = new StringBuilder();
            int traceNode = 0;
            ENgetqualinfo(ref qualCode, chemName, chemUnits, ref traceNode);

            return new QualInfo { 
                QualCode  = qualCode,
                ChemName  = chemName .ToString(),
                ChemUnits = chemUnits.ToString(),
                TraceNode = traceNode
            };
        }
        public static void SetBaseDemand(int nodeIndex, int demandIndex, float baseDemand)
        {
            ENsetbasedemand(nodeIndex, demandIndex, baseDemand);
        }
        public static int GetCurveIndex(string id)
        {
            int index = 0;
            ENgetcurveindex(id, ref index);
            return index;
        }
        public static string GetCurveId(int index)
        {
            var id = new StringBuilder();
            ENgetcurveid(index, id);
            return id.ToString();
        }
        public static int GetCurveLen(int index)
        {
            int len = 0;
            ENgetcurvelen(index, ref len);
            return len;
        }
        public static Point GetCurveValue(int curveIndex, int pointIndex)
        {
            float x = 0;
            float y = 0;
            ENgetcurvevalue(curveIndex, pointIndex, ref x, ref y);
            return new Point { X = x, Y = y };
        }
        public static void SetCurveValue(int curveIndex, int pointIndex, float x, float y)
        {
            ENsetcurvevalue(curveIndex, pointIndex, x, y);
        }
        public static void SetCurve(int index, float x, float y, int len)
        {
            ENsetcurve(index, x, y, len);
        }
        public static void AddCurve(string id)
        {
            ENaddcurve(id);
        }

        #region Helper
        /// <summary>
        /// 1부터 시작하는 인덱스 체크
        /// </summary>
        public static void CheckEpanetIndex(int index)
        {
            if (index < 1)
                throw new Exception("Index 값은 1부터 시작해야 합니다.");
        }
        #endregion

        #region DllImport
        //[DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        //private static extern int ENepanet(string inpFile, string rptFile, string binOutFile);

        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENopen(string inpFile, string rptFile, string binOutFile);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENsaveinpfile(string inpfile);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENclose();
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENsolveH();
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENsaveH();
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENopenH();
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENinitH(int initFlag);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENrunH(ref long currentTime);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENnextH(ref int timestep);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENcloseH();
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENsavehydfile(string filename);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENusehydfile(string filename);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENsolveQ();
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENopenQ();
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENinitQ(int saveFlag);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENrunQ(ref long currentTime);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENnextQ(ref long timeStep);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENstepQ(ref long timeLeft);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENcloseQ();
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENwriteline(string line);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENreport();
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENresetreport();
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENsetreport();
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENsetreport(string reportFormat);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetcontrol(int controlIndex, ref int controlType, ref int linkIndex, ref float setting, ref int nodeIndex, ref float level);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetcount(int code, ref int count);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetoption(int code, ref float value);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgettimeparam(int code, ref long value);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetflowunits(ref int code);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetpatternindex(string id, ref int index);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetpatternid(int index, StringBuilder id);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetpatternlen(int index, ref int len);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetpatternvalue(int index, int period, ref float value);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetaveragepatternvalue (int index, ref float value);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetqualtype(ref int qualcode, ref int tracenode);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgeterror(int errcode, StringBuilder errmsg, int maxLen);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetstatistic(int code, ref float value);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetnodeindex(string id, ref int index);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetnodeid(int index, StringBuilder id);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetnodetype(int index, ref int code);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetnodevalue(int index, int code, ref float value);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetcoord(int index, ref float x, ref float y);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENsetcoord(int index, float x, float y);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetnumdemands(int nodeIndex, ref int numDemands);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetbasedemand(int nodeIndex, int demandIndex, ref float baseDemand);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetdemandpattern (int nodeIndex, int demandIndex, ref int pattIndex);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetlinkindex(string id, ref int index);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetlinkid(int index, StringBuilder id);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetlinktype(int index, ref int code);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetlinknodes(int index, ref int node1, ref int node2);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetlinkvalue(int index, int code, ref float value);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetcurve(int curveIndex, StringBuilder id, ref int nValues, ref float xValues, ref float yValues);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetheadcurveindex(int pumpIndex, ref int curveIndex);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetpumptype(int linkIndex, ref int outType);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetversion(ref int version);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENsetcontrol(int controlIndex, int controlType, int linkIndex, float setting, int nodeIndex, float level);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENsetnodevalue(int index, int code, float v);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENsetlinkvalue(int index, int code, float v);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENaddpattern (string id);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENsetpattern (int index, float f, int len);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENsetpatternvalue (int index, int period, float value);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENsettimeparam(int code, float value);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENsetoption(int code, float v);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENsetstatusreport(int code);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENsetqualtype(int qualcode, string chemname, string chemunits, string tracenode);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetqualinfo (ref int qualcode, StringBuilder chemname, StringBuilder chemunits, ref int tracenode);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENsetbasedemand (int nodeIndex, int demandIdx, float baseDemand);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetcurveindex(string id, ref int index);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetcurveid(int index, StringBuilder id);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetcurvelen(int index, ref int len);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENgetcurvevalue(int curveIndex, int pointIndex, ref float x, ref float y);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENsetcurvevalue(int curveIndex, int pointIndex, float x, float y);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENsetcurve(int index, float x, float y, int len);
        [DllImport(@"epanet\epanet_2_1\epanet2.dll")]
        private static extern int ENaddcurve(string id);
        #endregion
    }
}
