using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DBM_PRESSGAUGE_EX
    {

        [Key]
		public int					ID					{ get; set; }	
		public string				PGUE_FID			{ get; set; }	
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
		public string				DATRG_DVCD			{ get; set; }	
		public string				DATRG_CFYN			{ get; set; }	
		public string				CSGN_DVCD			{ get; set; }	
		public string				WPGUESVE			{ get; set; }	
		public string				WPGUE_FRCD			{ get; set; }	
		public decimal?				CB					{ get; set; }	
		public string				DTAPC_FRCD			{ get; set; }	
		public string				NLDT				{ get; set; }	
		public string				MF_CYNM				{ get; set; }	
		public string				VRM_FID				{ get; set; }	
		public string				WPIP_FID			{ get; set; }	
		public string				CSRNO				{ get; set; }	
		public string				AT_FLNO				{ get; set; }	
		public string				RMK					{ get; set; }	
		public string				RGUID				{ get; set; }	
		public DateTime?			RGDTM				{ get; set; }	
		public string				RGU_IPAD			{ get; set; }	

    }
}
