namespace MindOne.Epanet
{
    // http://wateranalytics.org/EPANET/epanet2_8h.html
    public enum NodeProperty
    {
        EN_ELEVATION   =  0,
        EN_BASEDEMAND  =  1,
        EN_PATTERN     =  2,
        EN_EMITTER     =  3,
        EN_INITQUAL    =  4,
        EN_SOURCEQUAL  =  5,
        EN_SOURCEPAT   =  6,
        EN_SOURCETYPE  =  7,
        EN_TANKLEVEL   =  8,
        EN_DEMAND      =  9,
        EN_HEAD        = 10,
        EN_PRESSURE    = 11,
        EN_QUALITY     = 12,
        EN_SOURCEMASS  = 13,
        EN_INITVOLUME  = 14,
        EN_MIXMODEL    = 15,
        EN_MIXZONEVOL  = 16,
        EN_TANKDIAM    = 17,
        EN_MINVOLUME   = 18,
        EN_VOLCURVE    = 19,
        EN_MINLEVEL    = 20,
        EN_MAXLEVEL    = 21,
        EN_MIXFRACTION = 22,
        EN_TANK_KBULK  = 23
    }

    public enum LinkProperty
    {
        EN_DIAMETER    =  0,
        EN_LENGTH      =  1,
        EN_ROUGHNESS   =  2,
        EN_MINORLOSS   =  3,
        EN_INITSTATUS  =  4,
        EN_INITSETTING =  5,
        EN_KBULK       =  6,
        EN_KWALL       =  7,
        EN_FLOW        =  8,
        EN_VELOCITY    =  9,
        EN_HEADLOSS    = 10,
        EN_STATUS      = 11,
        EN_SETTING     = 12,
        EN_ENERGY      = 13
    }

    public enum TimeProperty
    {
        EN_DURATION     = 0,
        EN_HYDSTEP      = 1,
        EN_QUALSTEP     = 2,
        EN_PATTERNSTEP  = 3,
        EN_PATTERNSTART = 4,
        EN_REPORTSTEP   = 5,
        EN_REPORTSTART  = 6,
        EN_RULESTEP     = 7,
        EN_STATISTIC    = 8,
        EN_PERIODS      = 9
    }

    public enum AnalysisStatistic
    { 
        EN_ITERATIONS    = 0,
        EN_RELATIVEERROR = 1 
    }

    public enum CountType
    {
        EN_NODECOUNT    = 0,
        EN_TANKCOUNT    = 1,
        EN_LINKCOUNT    = 2,
        EN_PATCOUNT     = 3,
        EN_CURVECOUNT   = 4,
        EN_CONTROLCOUNT = 5
    }

    public enum NodeType
    {
        EN_JUNCTION  = 0,
        EN_RESERVOIR = 1,
        EN_TANK      = 2
    }

    public enum LinkType
    {
        EN_CVPIPE = 0,
        EN_PIPE   = 1,
        EN_PUMP   = 2,
        EN_PRV    = 3,
        EN_PSV    = 4,
        EN_PBV    = 5,
        EN_FCV    = 6,
        EN_TCV    = 7,
        EN_GPV    = 8
    }

    public enum QualityType
    {
        EN_NONE  = 0,
        EN_CHEM  = 1,
        EN_AGE   = 2,
        EN_TRACE = 3
    }

    public enum SourceType
    {
        EN_CONCEN    = 0,
        EN_MASS      = 1,
        EN_SETPOINT  = 2,
        EN_FLOWPACED = 3
    }

    public enum FlowUnits
    {
        EN_CFS  = 0,
        EN_GPM  = 1,
        EN_MGD  = 2,
        EN_IMGD = 3,
        EN_AFD  = 4,
        EN_LPS  = 5,
        EN_LPM  = 6,
        EN_MLD  = 7,
        EN_CMH  = 8,
        EN_CMD  = 9
    }

    public enum SimulationOptions
    {
        EN_TRIALS     = 0,
        EN_ACCURACY   = 1,
        EN_TOLERANCE  = 2,
        EN_EMITEXPON  = 3,
        EN_DEMANDMULT = 4
    }

    public enum ControlType
    {
        EN_LOWLEVEL  = 0,
        EN_HILEVEL   = 1,
        EN_TIMER     = 2,
        EN_TIMEOFDAY = 3
    }

    public enum StatisticTypes
    {
        EN_AVERAGE = 1,
        EN_MINIMUM = 2,
        EN_MAXIMUM = 3,
        EN_RANGE   = 4
    }

    public enum MixingModel
    {
        EN_MIX1 = 0,
        EN_MIX2 = 1,
        EN_FIFO = 2,
        EN_LIFO = 3
    }

    public enum SaveOption
    { 
        EN_NOSAVE        =  0,
        EN_SAVE          =  1,
        EN_INITFLOW      = 10,
        EN_SAVE_AND_INIT = 11
    }

    public enum CurveType
    { 
        EN_CONST_HP   = 0,
        EN_POWER_FUNC = 1,
        EN_CUSTOM     = 2 
    }
}
