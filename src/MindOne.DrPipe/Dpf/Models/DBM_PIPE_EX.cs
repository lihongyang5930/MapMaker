using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DBM_PIPE_EX
    {

        [Key]
		public int					ID					{ get; set; }	
		public string				WPIP_FID			{ get; set; }	
		public string				FCD					{ get; set; }	
		public string				MG_DVCD				{ get; set; }	
		public string				ROHQCD				{ get; set; }	
		public string				MGDPCD				{ get; set; }	
		public string				MG_OGCD				{ get; set; }	
		public string				ADMDCD				{ get; set; }	
		public string				SBLK_FID			{ get; set; }	
		public string				BZSPCD				{ get; set; }	
		public string				CNNCD				{ get; set; }	
		public string				SCNCD				{ get; set; }	
		public string				SSCN				{ get; set; }	
		public string				RN_BZSNM			{ get; set; }	
		public string				USE_YNCD			{ get; set; }	
		public string				DATRG_DVCD			{ get; set; }	
		public string				DATRG_CFYN			{ get; set; }	
		public string				CSGN_DVCD			{ get; set; }	
		public string				PPL_BLKID			{ get; set; }	
		public string				WP_SVECD			{ get; set; }	
		public string				PPL_SVECD			{ get; set; }	
		public string				WTR_DVCD			{ get; set; }	
		public string				PKNDCD				{ get; set; }	
		public int?					PDM					{ get; set; }	
		public string				WKDCD				{ get; set; }	
		public int?					LH					{ get; set; }	
		public double?				CALCLH				{ get; set; }	
		public string				TGPY_CDNCD			{ get; set; }	
		public string				PWLDG_KNCD			{ get; set; }	
		public string				CSNDT				{ get; set; }	
		public byte[]				LCEXP				{ get; set; }	
		public string				PLBL				{ get; set; }	
		public int?					SPT_STANO			{ get; set; }	
		public int?					SPTS_ADDDN			{ get; set; }	
		public string				SPTB_DVCD			{ get; set; }	
		public double?				SPTDEP				{ get; set; }	
		public int?					EPT_STANO			{ get; set; }	
		public int?					EPTS_ADDDN			{ get; set; }	
		public string				EPTB_DVCD			{ get; set; }	
		public double?				EPTDEP				{ get; set; }	
		public double?				MAXIDEP				{ get; set; }	
		public double?				MINIDEP				{ get; set; }	
		public double?				SIE					{ get; set; }	
		public string				MH_SCNID			{ get; set; }	
		public string				CBPIP_BRNM			{ get; set; }	
		public string				TNL_FID				{ get; set; }	
		public string				CSRNO				{ get; set; }	
		public string				AT_FLNO				{ get; set; }	
		public string				AWTR_DICD			{ get; set; }	
		public byte[]				RMK					{ get; set; }	
		public string				RGUID				{ get; set; }	
		public DateTime?			RGDTM				{ get; set; }	
		public string				RGU_IPAD			{ get; set; }	

    }
}
