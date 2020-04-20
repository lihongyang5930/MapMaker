using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class NET_QUANTITY
    {

        [Key]
        [Column(Order = 0)]
		public DateTime				YYMM			{ get; set; }	
        [Key]
        [Column(Order = 1)]		
		public string				ZONE			{ get; set; }	
		public double?				IN_WATER		{ get; set; }	
		public double?				USED_WATER		{ get; set; }	
		public double?				AVG_PRESS		{ get; set; }	
		public int?					PERSON_CNT		{ get; set; }	
		public double?				SANGSU_LEN		{ get; set; }	
		public int?					GUBSU_CNT		{ get; set; }	
		public double?				R1				{ get; set; }	
		public double?				R2				{ get; set; }	
		public double?				R3				{ get; set; }	
		public double?				R4				{ get; set; }	
		public double?				R5				{ get; set; }	
		public double?				R6				{ get; set; }	
		public double?				R7				{ get; set; }	
		public double?				R8				{ get; set; }	

    }
}
