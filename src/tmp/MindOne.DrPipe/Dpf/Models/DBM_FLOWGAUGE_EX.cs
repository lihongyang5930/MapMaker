using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DBM_FLOWGAUGE_EX
    {

        [Key]
		public int					ID					{ get; set; }	
		public string				FLM_FID				{ get; set; }	
		public string				FCD					{ get; set; }	
		public string				SBLK_FID			{ get; set; }	
		public string				VRM_FID				{ get; set; }	
		public string				PPL_FID				{ get; set; }	
		public string				BZSPCD				{ get; set; }	
		public string				CNNCD				{ get; set; }	
		public string				SCNCD				{ get; set; }	
		public string				ADMDCD				{ get; set; }	
		public string				DATRG_DVCD			{ get; set; }	
		public string				DATRG_CFYN			{ get; set; }	
		public string				BZS_FID				{ get; set; }	
		public string				FLMID				{ get; set; }	
		public string				RG_LCCD				{ get; set; }	
		public string				MG_OGCD				{ get; set; }	
		public string				MGST				{ get; set; }	
		public string				RMK					{ get; set; }	
		public string				RGUID				{ get; set; }	
		public DateTime?			RGDTM				{ get; set; }	
		public string				RGU_IPAD			{ get; set; }	

    }
}
