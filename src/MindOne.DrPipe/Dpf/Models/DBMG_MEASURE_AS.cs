using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DBMG_MEASURE_AS
    {

        [Key]
        [Column(Order = 0)]	
		public string				AREA_CD				{ get; set; }
		[Key]
        [Column(Order = 1)]	
		public string				MEASURE_NAME		{ get; set; }	

    }
}
