using System.Data.Entity;
using MindOne.DrPipe.Dpf.Models;

namespace MindOne.DrPipe.Dpf
{
    [DbConfigurationType(typeof(FirebirdConfiguration))]
    public class DpfContext : DbContext
    {
        public DpfContext(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer(new NullDatabaseInitializer<DpfContext>());

        }

        public virtual DbSet<CODE_TABLE> CODE_TABLE { get; set; }
        public virtual DbSet<CVA_LEAKAGE> CVA_LEAKAGE { get; set; }
        public virtual DbSet<CVA_PRESS> CVA_PRESS { get; set; }
        public virtual DbSet<CVA_WQTY> CVA_WQTY { get; set; }
        public virtual DbSet<DBINFO> DBINFO { get; set; }
        public virtual DbSet<DBMG_C_PATH> DBMG_C_PATH { get; set; }
        public virtual DbSet<DBMG_C_PATH2> DBMG_C_PATH2 { get; set; }
        public virtual DbSet<DBMG_C_VALUE> DBMG_C_VALUE { get; set; }
        public virtual DbSet<DBMG_C_VALUE2> DBMG_C_VALUE2 { get; set; }
        public virtual DbSet<DBMG_MEASURE> DBMG_MEASURE { get; set; }
        public virtual DbSet<DBMG_MEASURE_AS> DBMG_MEASURE_AS { get; set; }
        public virtual DbSet<DBMG_MEASURE_PS> DBMG_MEASURE_PS { get; set; }
        public virtual DbSet<DBMG_MEASURE_RAWDATA> DBMG_MEASURE_RAWDATA { get; set; }
        public virtual DbSet<DBM_BIZ_SITE_AS> DBM_BIZ_SITE_AS { get; set; }
        public virtual DbSet<DBM_BLOCKB> DBM_BLOCKB { get; set; }
        public virtual DbSet<DBM_BLOCKM> DBM_BLOCKM { get; set; }
        public virtual DbSet<DBM_BLOCKS> DBM_BLOCKS { get; set; }
        public virtual DbSet<DBM_CVRI> DBM_CVRI { get; set; }
        public virtual DbSet<DBM_CVRO> DBM_CVRO { get; set; }
        public virtual DbSet<DBM_CVRU> DBM_CVRU { get; set; }
        public virtual DbSet<DBM_FIREPLUG> DBM_FIREPLUG { get; set; }
        public virtual DbSet<DBM_FLOWGAUGE> DBM_FLOWGAUGE { get; set; }
        public virtual DbSet<DBM_FLOWGAUGE_EX> DBM_FLOWGAUGE_EX { get; set; }
        public virtual DbSet<DBM_FLOWGAUGE_FLOW_HIST> DBM_FLOWGAUGE_FLOW_HIST { get; set; }
        public virtual DbSet<DBM_GROUP_INFO> DBM_GROUP_INFO { get; set; }
        public virtual DbSet<DBM_JOINT_TYPE> DBM_JOINT_TYPE { get; set; }
        public virtual DbSet<DBM_LAYER_EX> DBM_LAYER_EX { get; set; }
        public virtual DbSet<DBM_NODE> DBM_NODE { get; set; }
        public virtual DbSet<DBM_PIPE> DBM_PIPE { get; set; }
        public virtual DbSet<DBM_PIPE_EX> DBM_PIPE_EX { get; set; }
        public virtual DbSet<DBM_PRESSGAUGE> DBM_PRESSGAUGE { get; set; }
        public virtual DbSet<DBM_PRESSGAUGE_EX> DBM_PRESSGAUGE_EX { get; set; }
        public virtual DbSet<DBM_PUMP> DBM_PUMP { get; set; }
        public virtual DbSet<DBM_RESV> DBM_RESV { get; set; }
        public virtual DbSet<DBM_STATION> DBM_STATION { get; set; }
        public virtual DbSet<DBM_VALVE> DBM_VALVE { get; set; }
        public virtual DbSet<DBM_VALVEROOM> DBM_VALVEROOM { get; set; }
        public virtual DbSet<DBM_WATERGAUGE> DBM_WATERGAUGE { get; set; }
        public virtual DbSet<DBM_WATERGAUGE_DEMAND_HIST> DBM_WATERGAUGE_DEMAND_HIST { get; set; }
        public virtual DbSet<DBM_ZONE> DBM_ZONE { get; set; }
        public virtual DbSet<DEFAULT_VALUE> DEFAULT_VALUE { get; set; }
        public virtual DbSet<DIAGNOSIS_ITEMS> DIAGNOSIS_ITEMS { get; set; }
        public virtual DbSet<DSS_ENVI> DSS_ENVI { get; set; }
        public virtual DbSet<EPAG_NODE> EPAG_NODE { get; set; }
        public virtual DbSet<EPA_LINK> EPA_LINK { get; set; }
        public virtual DbSet<EPA_LINK_GRID> EPA_LINK_GRID { get; set; }
        public virtual DbSet<EPA_LINK_TIME_SERIES> EPA_LINK_TIME_SERIES { get; set; }
        public virtual DbSet<EPA_NODE> EPA_NODE { get; set; }
        public virtual DbSet<EPA_NODE_GRID> EPA_NODE_GRID { get; set; }
        public virtual DbSet<EPA_NODE_TIME_SERIES> EPA_NODE_TIME_SERIES { get; set; }
        public virtual DbSet<JOIN_TABLE> JOIN_TABLE { get; set; }
        public virtual DbSet<JOIN_TABLE2> JOIN_TABLE2 { get; set; }
        public virtual DbSet<NET_KPRESSURE> NET_KPRESSURE { get; set; }
        public virtual DbSet<NET_QUANTITY> NET_QUANTITY { get; set; }
        public virtual DbSet<NET_REVIEW_VALVE> NET_REVIEW_VALVE { get; set; }
        public virtual DbSet<NET_REVIEW_VALVE_CV> NET_REVIEW_VALVE_CV { get; set; }
        public virtual DbSet<NET_REVIEW_VALVE_FLOWC> NET_REVIEW_VALVE_FLOWC { get; set; }
        public virtual DbSet<PCA_DETAIL_DIAGNOSIS> PCA_DETAIL_DIAGNOSIS { get; set; }
        public virtual DbSet<PCA_LIFE_SIMUL> PCA_LIFE_SIMUL { get; set; }
        public virtual DbSet<PCA_MEDIA> PCA_MEDIA { get; set; }
        public virtual DbSet<PCA_REFORM> PCA_REFORM { get; set; }
        public virtual DbSet<STORE_DATA> STORE_DATA { get; set; }
        public virtual DbSet<WQT_BASE_PIPE> WQT_BASE_PIPE { get; set; }
        public virtual DbSet<WQT_BASE_SITE> WQT_BASE_SITE { get; set; }
        public virtual DbSet<WQT_GENERAL> WQT_GENERAL { get; set; }
        public virtual DbSet<WQT_GENERAL_ITEM> WQT_GENERAL_ITEM { get; set; }
        public virtual DbSet<WQT_GENERAL_NODE> WQT_GENERAL_NODE { get; set; }
        public virtual DbSet<WQT_WATER_STAND> WQT_WATER_STAND { get; set; }
    }
}
