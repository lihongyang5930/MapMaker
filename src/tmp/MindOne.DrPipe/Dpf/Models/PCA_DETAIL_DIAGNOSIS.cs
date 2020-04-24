using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class PCA_DETAIL_DIAGNOSIS
    {

		[Key]
		public int					ID					{ get; set; }	
		public DateTime?			IVDATE				{ get; set; }	
		public string				IVUSER				{ get; set; }	
		public string				PH_NAME_EX			{ get; set; }	
		public double?				DF_A				{ get; set; }	
		public double?				DF_B				{ get; set; }	
		public double?				M1_A				{ get; set; }	
		public double?				M1_A1				{ get; set; }	
		public double?				M1_A2				{ get; set; }	
		public double?				M1_A3				{ get; set; }	
		public double?				M1_A4				{ get; set; }	
		public double?				M1_B				{ get; set; }	
		public double?				M1_B1				{ get; set; }	
		public double?				M1_B2				{ get; set; }	
		public double?				M1_B3				{ get; set; }	
		public double?				M1_B4				{ get; set; }	
		public double?				M1_C				{ get; set; }	
		public double?				M1_C1				{ get; set; }	
		public double?				M1_C2				{ get; set; }	
		public double?				M1_C3				{ get; set; }	
		public double?				M1_C4				{ get; set; }	
		public double?				M1_C5				{ get; set; }	
		public double?				M1_C6				{ get; set; }	
		public double?				M1_D				{ get; set; }	
		public double?				M1_D1				{ get; set; }	
		public double?				M1_D2				{ get; set; }	
		public double?				M1_D3				{ get; set; }	
		public double?				M1_E				{ get; set; }	
		public double?				M2_A				{ get; set; }	
		public double?				M2_A1				{ get; set; }	
		public double?				M2_A2				{ get; set; }	
		public double?				M2_A3				{ get; set; }	
		public double?				M2_A4				{ get; set; }	
		public double?				M2_A5				{ get; set; }	
		public double?				M2_B				{ get; set; }	
		public double?				M2_B1				{ get; set; }	
		public double?				M2_B2				{ get; set; }	
		public double?				M2_B3				{ get; set; }	
		public double?				M2_B4				{ get; set; }	
		public double?				M2_B5				{ get; set; }	
		public double?				M2_C				{ get; set; }	
		public double?				M2_C1				{ get; set; }	
		public double?				M2_C2				{ get; set; }	
		public double?				M2_C3				{ get; set; }	
		public double?				M2_C4				{ get; set; }	
		public double?				M2_C5				{ get; set; }	
		public double?				M2_C6				{ get; set; }	
		public double?				M2_D				{ get; set; }	
		public double?				M2_D1				{ get; set; }	
		public double?				M2_D2				{ get; set; }	
		public double?				M2_D3				{ get; set; }	
		public double?				M2_D4				{ get; set; }	
		public double?				M2_D5				{ get; set; }	
		public double?				M2_D6				{ get; set; }	
		public double?				CO_O				{ get; set; }	
		public string				CO_P				{ get; set; }	
		public double?				CO_A				{ get; set; }	
		public double?				CO_B				{ get; set; }	
		public double?				CO_C				{ get; set; }	
		public double?				CO_D				{ get; set; }	
		public double?				CO_F				{ get; set; }	
		public string				CO_G				{ get; set; }	
		public double?				CO_E				{ get; set; }	
		public double?				CO_I				{ get; set; }	
		public double?				CO_H				{ get; set; }	
		public double?				CO_Q				{ get; set; }	
		public double?				CO_J				{ get; set; }	
		public double?				CO_K				{ get; set; }	
		public double?				CO_L				{ get; set; }	
		public double?				CO_M				{ get; set; }	
		public double?				CO_M1				{ get; set; }	
		public double?				CO_N				{ get; set; }	
		public double?				CO_N1				{ get; set; }	
		public double?				CO_N2				{ get; set; }	
		public double?				CO_N3				{ get; set; }	
		public double?				CO_N4				{ get; set; }	
		public double?				CO_R				{ get; set; }	
		public double?				PH_A				{ get; set; }	
		public double?				PH_B				{ get; set; }	
		public double?				PH_C				{ get; set; }	
		public double?				PH_D				{ get; set; }	
		public double?				PH_E				{ get; set; }	
		public double?				PH_F				{ get; set; }	
		public double?				PH_G				{ get; set; }	
		public double?				PH_H				{ get; set; }	
		public double?				PH_I				{ get; set; }	
		public double?				PH_J				{ get; set; }	
		public double?				PH_K				{ get; set; }	
		public double?				PH_L				{ get; set; }	
		public double?				PH_M				{ get; set; }	
		public double?				PH_N				{ get; set; }	
		public double?				PH_O				{ get; set; }	
		public double?				PH_P				{ get; set; }	
		public double?				PH_Q				{ get; set; }	
		public double?				PH_R				{ get; set; }	
		public double?				PH_S				{ get; set; }	
		public double?				PH_T				{ get; set; }	
		public double?				PH_U				{ get; set; }	
		public double?				PH_V				{ get; set; }	
		public string				ET_A				{ get; set; }	
		public string				ET_B				{ get; set; }	
		public string				ET_C				{ get; set; }	
		public string				ET_D				{ get; set; }	
		public double?				ET_E				{ get; set; }	
		public double?				ET_F				{ get; set; }	
		public double?				SCORE1				{ get; set; }	
		public double?				SCORE2				{ get; set; }	
		public double?				SCORE3				{ get; set; }	
		public double?				SCORE4				{ get; set; }	
		public double?				SCORE5				{ get; set; }	
		public byte[]				REPORT				{ get; set; }	
		public string				MEMO				{ get; set; }	
		public double?				SF_MIN				{ get; set; }	
		public string				SF_GRADE			{ get; set; }	
		public string				PIT_GRADE			{ get; set; }	
		public string				GRADE				{ get; set; }	

    }
}
