using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DBMG_C_VALUE
    {

        [Key]
        [Column(Order = 0)]	
		public DateTime				WDATE				{ get; set; }	  
        [Key]
        [Column(Order = 1)]			
		public string				MEASURE_NAME		{ get; set; }	  
        [Key]
        [Column(Order = 2)]			
		public string				AREACD				{ get; set; }	  
		public string				STA_FID1			{ get; set; }	
		public string				STA_FID2			{ get; set; }	
		public double?				CVALUE				{ get; set; }	
		public byte[]				MEMO				{ get; set; }	

    }
}
