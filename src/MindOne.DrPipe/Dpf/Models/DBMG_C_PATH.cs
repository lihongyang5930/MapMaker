using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DBMG_C_PATH
    {
        [Key]
        [Column(Order = 0)]		
		public string		MEASURE_NAME		{ get; set; }	
        [Key]
        [Column(Order = 1)]		
		public string		AREACD				{ get; set; }	
        [Key]
        [Column(Order = 2)]		
		public string		STA_FID				{ get; set; }	
		public double?		OFFSET_LEN			{ get; set; }	
		public int?			STANO				{ get; set; }	
		public int?			ADDDN				{ get; set; }	
    }
}
