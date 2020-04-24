using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DBM_VALVE
    {

        [Key]
		public int					ID					{ get; set; }	
		public int?					NODE_ID				{ get; set; }	
		public string				MGR_ID				{ get; set; }	
		public string				KIND				{ get; set; }	
		public string				VV_FID				{ get; set; }	
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
		public string				STA_FID				{ get; set; }	
		public decimal?				VV_SQNO				{ get; set; }	
		public string				VV_QMCD				{ get; set; }	
		public string				VV_FRCD				{ get; set; }	
		public string				VVDRV_FRCD			{ get; set; }	
		public string				NLDT				{ get; set; }	
		public int?					DGNPRS				{ get; set; }	
		public string				MF_CYNM				{ get; set; }	
		public string				VV_MODLNM			{ get; set; }	
		public int?					TRVCNT				{ get; set; }	
		public string				VVON_DICD			{ get; set; }	
		public string				FBOLTSTD			{ get; set; }	
		public int?					FBOLTQU				{ get; set; }	
		public string				BSTND				{ get; set; }	
		public decimal?				CB					{ get; set; }	
		public string				ELTY_MHCD			{ get; set; }	
		public int?					RANG				{ get; set; }	
		public string				PPL_FID				{ get; set; }	
		public string				PPL_FCD				{ get; set; }	
		public string				VRM_FID				{ get; set; }	
		public string				CSRNO				{ get; set; }	
		public string				AT_FLNO				{ get; set; }	
		public string				RMK					{ get; set; }	
		public string				RGUID				{ get; set; }	
		public DateTime?			RGDTM				{ get; set; }	
		public string				RGU_IPAD			{ get; set; }	
		public double?				X					{ get; set; }	
		public double?				Y					{ get; set; }	
		public string				A1					{ get; set; }	
		public string				A2					{ get; set; }	
		public string				A3					{ get; set; }	
		public string				A4					{ get; set; }	
		public string				A5					{ get; set; }	
		public string				A6					{ get; set; }	
		public string				A7					{ get; set; }	
		public string				A8					{ get; set; }	
		public string				A9					{ get; set; }	
		public string				A10					{ get; set; }	
		public string				A11					{ get; set; }	
		public string				A12					{ get; set; }	
		public string				A13					{ get; set; }	
		public string				A14					{ get; set; }	
		public string				A15					{ get; set; }	
		public string				A16					{ get; set; }	
		public string				A17					{ get; set; }	
		public string				A18					{ get; set; }	
		public string				A19					{ get; set; }	
		public string				A20					{ get; set; }	
		public string				A21					{ get; set; }	

    }
}
