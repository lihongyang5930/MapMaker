using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DBM_PUMP
    {

        [Key]		
		public int					ID					{ get; set; }	
		public double?				X					{ get; set; }	
		public double?				Y					{ get; set; }	
		public string				PUMO_FID			{ get; set; }	
		public string				FCD					{ get; set; }	
		public string				SBLK_FID			{ get; set; }	
		public string				BZSPCD				{ get; set; }	
		public string				CNNCD				{ get; set; }	
		public string				SCNCD				{ get; set; }	
		public string				ADMDCD				{ get; set; }	
		public string				DATRG_CFYN			{ get; set; }	
		public string				DATRG_DVCD			{ get; set; }	
		public string				MG_DVCD				{ get; set; }	
		public string				BZS_FID				{ get; set; }	
		public string				MCHN_SQNO			{ get; set; }	
		public string				USE_CFNCD			{ get; set; }	
		public string				CSRNO				{ get; set; }	
		public string				RG_LCCD				{ get; set; }	
		public string				MGDPCD				{ get; set; }	
		public string				MG_OGCD				{ get; set; }	
		public string				ROHQCD				{ get; set; }	
		public string				PUMO_MGNO			{ get; set; }	
		public string				CNR_FCLNM			{ get; set; }	
		public string				PUMO_SVECD			{ get; set; }	
		public string				INHAL_FRCD			{ get; set; }	
		public string				FCQN				{ get; set; }	
		public string				QN_CFNCD			{ get; set; }	
		public string				ST_CFNCD			{ get; set; }	
		public string				RPLYN				{ get; set; }	
		public string				CHGSPDYN			{ get; set; }	
		public string				TM_NLYN				{ get; set; }	
		public string				TC_NLYN				{ get; set; }	
		public string				NLDT				{ get; set; }	
		public string				SVE_CFNCD			{ get; set; }	
		public string				AT_FLNO				{ get; set; }	
		public string				RMK					{ get; set; }	
		public string				RGUID				{ get; set; }	
		public DateTime?			RGDTM				{ get; set; }	
		public string				RGU_IPAD			{ get; set; }	

    }
}
