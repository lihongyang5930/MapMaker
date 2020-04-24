using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DBM_VALVEROOM
    {

        [Key]
		public string				VRM_FID				{ get; set; }	
		public string				FCD					{ get; set; }	
		public string				ROHQCD				{ get; set; }	
		public string				MGDPCD				{ get; set; }	
		public string				MG_OGCD				{ get; set; }	
		public string				ADMDCD				{ get; set; }	
		public string				SBLK_FID			{ get; set; }	
		public string				BZSPCD				{ get; set; }	
		public string				CNNCD				{ get; set; }	
		public string				SCNCD				{ get; set; }	
		public string				SSCN				{ get; set; }	
		public string				DATRG_DVCD			{ get; set; }	
		public string				DATRG_CFYN			{ get; set; }	
		public string				CSGN_DVCD			{ get; set; }	
		public decimal?				VRM_SQNO			{ get; set; }	
		public int?					STANO				{ get; set; }	
		public int?					STA_ADDDN			{ get; set; }	
		public string				VRM_SHCD			{ get; set; }	
		public string				VRMLC_DVCD			{ get; set; }	
		public string				VRMSTD				{ get; set; }	
		public string				DLAD				{ get; set; }	
		public string				NLDT				{ get; set; }	
		public decimal?				OHIT				{ get; set; }	
		public string				TGPY_CDNCD			{ get; set; }	
		public decimal?				CVR_LNDHIT			{ get; set; }	
		public decimal?				SIE					{ get; set; }	
		public string				FLM_LAFCL			{ get; set; }	
		public string				FLM_FOFCL			{ get; set; }	
		public string				PXVRM_MGNO			{ get; set; }	
		public string				CSRNO				{ get; set; }	
		public string				AT_FLNO				{ get; set; }	
		public string				VRM_DVCD			{ get; set; }	
		public string				MG_DVCD				{ get; set; }	
		public string				RMK					{ get; set; }	
		public string				RGUID				{ get; set; }	
		public DateTime?			RGDTM				{ get; set; }	
		public string				RGU_IPAD			{ get; set; }	

    }
}
