using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DBMG_C_PATH2
    {

        [Key]
        [Column(Order = 0)]			
		public string			STA_FID				{ get; set; }	  
        [Key]
        [Column(Order = 1)]			
		public string			KIND				{ get; set; }	  
		public string			MEASURE_NAME		{ get; set; }	
		public string			AREACD				{ get; set; }	
		public int?				STANO				{ get; set; }	
		public int?				ADDDN				{ get; set; }	
		
    }
}
