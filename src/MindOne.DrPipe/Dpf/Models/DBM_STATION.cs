using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DBM_STATION
    {

        [Key]
		public string				STA_FID				{ get; set; }	
		public string				FCD					{ get; set; }	
		public string				ROHQCD				{ get; set; }	
		public string				MGDPCD				{ get; set; }	
		public string				BZSPCD				{ get; set; }	
		public string				CNNCD				{ get; set; }	
		public string				SCNCD				{ get; set; }	
		public string				SSCN				{ get; set; }	
		public string				DATRG_DVCD			{ get; set; }	
		public string				DATRG_CFYN			{ get; set; }	
		public string				PPL_BLKID			{ get; set; }	
		public int?					ADDDN				{ get; set; }	
		public int?					STA_DVCD			{ get; set; }	
		public int?					STANO				{ get; set; }	
		public double?				LNDHIT				{ get; set; }	
		public double?				SIE					{ get; set; }	
		public string				STAEPNT				{ get; set; }	
		public string				RMK					{ get; set; }	
		public string				WPIP_FID			{ get; set; }	
		public string				RGUID				{ get; set; }	
		public string				CSRNO				{ get; set; }	
		public string				AT_FLNO				{ get; set; }	
		public DateTime?			RGDTM				{ get; set; }	
		public string				RGU_IPAD			{ get; set; }	
		public double?				X					{ get; set; }	
		public double?				Y					{ get; set; }	
		public string				IS_BEING			{ get; set; }	

    }
}
