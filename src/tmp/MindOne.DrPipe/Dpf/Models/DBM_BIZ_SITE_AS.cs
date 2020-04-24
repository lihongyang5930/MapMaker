using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DBM_BIZ_SITE_AS
    {

        [Key]
		public string				BZS_FID					{ get; set; }	
		public string				FCD						{ get; set; }	
		public string				MG_DVCD					{ get; set; }	
		public string				ROHQCD					{ get; set; }	
		public string				MGDPCD					{ get; set; }	
		public string				MG_OGCD					{ get; set; }	
		public string				ADMDCD					{ get; set; }	
		public string				SBLK_FID				{ get; set; }	
		public string				BZSNM					{ get; set; }	
		public string				BZSABB					{ get; set; }	
		//public string				CMPTDP					{ get; set; }	
		public byte[]				DLAD					{ get; set; }	
		public string				DATRG_DVCD				{ get; set; }	
		public string				DATRG_CFYN				{ get; set; }	
		public string				CSGN_DVCD				{ get; set; }	
		public string				ORN_STCD				{ get; set; }	
		public string				ORNST_CHDT				{ get; set; }	
		public decimal?				LNDAR					{ get; set; }	
		public string				ITSCV_MTCD				{ get; set; }	
		public string				ITSIT_MTCD				{ get; set; }	
		public decimal?				FCQN					{ get; set; }	
		public string				FRN_OPRNFR				{ get; set; }	
		public string				FRNCW_PCCD				{ get; set; }	
		public string				FRNDW_PCCD				{ get; set; }	
		public string				CWQN					{ get; set; }	
		public string				PWQN					{ get; set; }	
		public string				BPSPZ_FRCD				{ get; set; }	
		public string				BPSDR_MGCD				{ get; set; }	
		public decimal?				BPSEV					{ get; set; }	
		public string				BPS_WHCSCD				{ get; set; }	
		public string				BPS_WHCSSH				{ get; set; }	
		public string				BPS_WHCSQN				{ get; set; }	
		public decimal?				BPS_PZFM				{ get; set; }	
		public string				BPS_PZZN				{ get; set; }	
		public decimal?				DR_MAXIWL				{ get; set; }	
		public decimal?				DR_MINIWL				{ get; set; }	
		public decimal?				DR_IFWQ					{ get; set; }	
		public string				DR_CL_MTCD				{ get; set; }	
		public decimal?				DR_WPPP					{ get; set; }	
		public string				RNCA_FID1				{ get; set; }	
		public decimal?				RNCA_FCQN1				{ get; set; }	
		public string				RNCA_FID2				{ get; set; }	
		public decimal?				RNCA_FCQN2				{ get; set; }	
		public string				RNBZS_FID1				{ get; set; }	
		public decimal?				RNBZS_QN1				{ get; set; }	
		public string				RNBZS_FID2				{ get; set; }	
		public decimal?				RNBZS_QN2				{ get; set; }	
		public string				RNBZS_FID3				{ get; set; }	
		public decimal?				RNBZS_QN3				{ get; set; }	
		public string				CSRNO					{ get; set; }	
		public string				AT_FLNO					{ get; set; }	
		public string				MUM_CHYR				{ get; set; }	
		public string				RMK						{ get; set; }	
		public string				RGUID					{ get; set; }	
		public DateTime?			RGDTM					{ get; set; }	
		public string				RGU_IPAD				{ get; set; }	
		public byte[]				GEOMETRY				{ get; set; }	

    }
}
