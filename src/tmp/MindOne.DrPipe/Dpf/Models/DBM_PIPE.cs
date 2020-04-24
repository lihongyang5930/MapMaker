using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DBM_PIPE
    {

        [Key]
		public int					ID							{ get; set; }	
		public string				MGR_ID						{ get; set; }	
		public string				PP_CLASS					{ get; set; }	
		public string				SANGSU_MGRID				{ get; set; }	
		public string				WTWK						{ get; set; }	
		public string				GOV_ZONE					{ get; set; }	
		public string				UNDER_POS					{ get; set; }	
		public string				LAY_YM						{ get; set; }	
		public decimal?				NYEAR						{ get; set; }	
		public string				PP_TYPE						{ get; set; }	
		public double?				PP_CIR						{ get; set; }	
		public double?				PP_LEN						{ get; set; }	
		public double?				EX_DIAM						{ get; set; }	
		public double?				PP_THICK					{ get; set; }	
		public string				BASE_CON					{ get; set; }	
		public string				JOINT_TYPE					{ get; set; }	
		public double?				DEPTH_LOW					{ get; set; }	
		public double?				DEPTH_HIGH					{ get; set; }	
		public double?				DEPTH_AVG					{ get; set; }	
		public double?				PRESSURE1					{ get; set; }	
		public double?				PRESSURE2					{ get; set; }	
		public double?				PRESSURE_MIN				{ get; set; }	
		public double?				PRESSURE_AVG				{ get; set; }	
		public double?				PRESSURE_MAX				{ get; set; }	
		public double?				PRESSURE_STDDEV				{ get; set; }	
		public double?				VELOCITY_MIN				{ get; set; }	
		public double?				VELOCITY_AVG				{ get; set; }	
		public double?				VELOCITY_MAX				{ get; set; }	
		public double?				VELOCITY_STDDEV				{ get; set; }	
		public double?				FREEZE_DEPTH				{ get; set; }	
		public int?					CVA_LEAK_CNT				{ get; set; }	
		public int?					CVA_PRESS_CNT				{ get; set; }	
		public int?					CVA_QTY_CNT					{ get; set; }	
		public string				SOIL_TYPE					{ get; set; }	
		public string				PRTCOR						{ get; set; }	
		public int?					VALVE_CNT					{ get; set; }	
		public int?					JOINT_CNT					{ get; set; }	
		public int?					GUPSU_CNT					{ get; set; }	
		public string				ISD_CVR						{ get; set; }	
		public string				OSD_CVR						{ get; set; }	
		public string				USD_CVR						{ get; set; }	
		public string				USD_CVR_YMD					{ get; set; }	
		public double?				IPIT_DEP					{ get; set; }	
		public double?				OPIT_DEP					{ get; set; }	
		public string				PIT_DEP_YMD					{ get; set; }	
		public double?				LI							{ get; set; }	
		public double?				SOIL_CORROSIVE				{ get; set; }	
		public double?				LEAK_BASE					{ get; set; }	
		public double?				LEAK_BREAK					{ get; set; }	
		public double?				LEAK_SUM					{ get; set; }	
		public double?				LEAK2						{ get; set; }	
		public double?				FLOW						{ get; set; }	
		public double?				PH_STRESS1					{ get; set; }	
		public double?				PH_STRESS2					{ get; set; }	
		public double?				PH_STRESS3					{ get; set; }	
		public int?					NODE1_ID					{ get; set; }	
		public int?					NODE2_ID					{ get; set; }	
		public byte[]				GEOMETRY					{ get; set; }	
		public double?				MINX						{ get; set; }	
		public double?				MINY						{ get; set; }	
		public double?				MAXX						{ get; set; }	
		public double?				MAXY						{ get; set; }	
		public string				ZONE						{ get; set; }	
		public string				BLOCKS						{ get; set; }	
		public string				BLOCKM						{ get; set; }	
		public string				BLOCKB						{ get; set; }	
		public string				GROUP1						{ get; set; }	
		public double?				GROUP1_LEN					{ get; set; }	
		public string				GROUP2						{ get; set; }	
		public double?				GROUP2_LEN					{ get; set; }	
		public string				GROUP3						{ get; set; }	
		public double?				GROUP3_LEN					{ get; set; }	
		public string				GROUP4						{ get; set; }	
		public double?				GROUP4_LEN					{ get; set; }	
		public double?				PSCORE						{ get; set; }	
		public string				PSCORE_GRADE				{ get; set; }	
		public double?				PSCORE11					{ get; set; }	
		public string				PSCORE11_GRADE				{ get; set; }	
		public double?				PSCORE12					{ get; set; }	
		public string				PSCORE12_GRADE				{ get; set; }	
		public double?				PSCORE2						{ get; set; }	
		public double?				BF_BEST_TIME				{ get; set; }	
		public string				BF_GRADE					{ get; set; }	
		public double?				SF_EE						{ get; set; }	
		public string				SF_GRADE					{ get; set; }	
		public double?				ZONE_SF_EE					{ get; set; }	
		public string				ZONE_SF_GRADE				{ get; set; }	
		public string				PH_NAME						{ get; set; }	
		public double?				PH_AGE_PREDICTION			{ get; set; }	

    }
}
