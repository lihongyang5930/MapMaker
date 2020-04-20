using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DBMG_MEASURE_RAWDATA
    {

        [Key]
        [Column(Order = 0)]
		public string				KIND				{ get; set; }	
		[Key]
        [Column(Order = 1)]
		public DateTime				DATE_TIME			{ get; set; }	
        [Key]
        [Column(Order = 2)]		
		public string				STA_FID				{ get; set; }	
		public double?				DATA				{ get; set; }	

    }
}
