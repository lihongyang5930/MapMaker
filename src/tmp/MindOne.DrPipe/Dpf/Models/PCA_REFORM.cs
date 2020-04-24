using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class PCA_REFORM
    {

        [Key]
        [Column(Order = 0)]
		public int					ID						{ get; set; }	
        [Key]
        [Column(Order = 1)]		
		public DateTime				RF_DATE					{ get; set; }	
		public double?				IN_DIAM					{ get; set; }	
		public double?				PP_THICK				{ get; set; }	
		public double?				IPIT_DEP				{ get; set; }	
		public double?				OPIT_DEP				{ get; set; }	
		public double?				SF						{ get; set; }	
		public string				SF_GRADE				{ get; set; }	
		public string				PCAM_GRADE				{ get; set; }	
		public double?				VELOCITY				{ get; set; }	
		public string				HYD_GRADE				{ get; set; }	
		public double?				FREE_CHLORINE			{ get; set; }	
		public double?				HETEROTROPHIC_PLATE		{ get; set; }	
		public string				COLON_BACILLUS			{ get; set; }	
		public double?				FE						{ get; set; }	
		public double?				TURBIDITY				{ get; set; }	
		public double?				PH						{ get; set; }	
		public double?				WQS_SCORE				{ get; set; }	
		public string				WQS_GRADE				{ get; set; }	
		public string				EPA_ID					{ get; set; }	
		public string				WQTY_GRADE				{ get; set; }	
		public string				QUANTITY				{ get; set; }	
		public string				PIPE_DESC				{ get; set; }	

    }
}
