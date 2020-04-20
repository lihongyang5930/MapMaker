using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class WQT_BASE_PIPE
    {

        [Key]
        [Column(Order = 0)]
		public string				NAME			{ get; set; }	
        [Key]
        [Column(Order = 1)]		
		public DateTime				YYMM			{ get; set; }	
		public string				EPA_ID			{ get; set; }	
		public double?				X				{ get; set; }	
		public double?				Y				{ get; set; }	
		public string				BLOCKS			{ get; set; }	
		public double?				R1				{ get; set; }	
		public double?				R2				{ get; set; }	
		public double?				R3				{ get; set; }	
		public double?				R4				{ get; set; }	
		public double?				R5				{ get; set; }	
		public double?				R6				{ get; set; }	
		public double?				R7				{ get; set; }	
		public double?				R8				{ get; set; }	
		public double?				R9				{ get; set; }	
		public double?				R10				{ get; set; }	
		public double?				R11				{ get; set; }	
		public double?				R12				{ get; set; }	
		public double?				R13				{ get; set; }	
		public double?				R14				{ get; set; }	

    }
}
