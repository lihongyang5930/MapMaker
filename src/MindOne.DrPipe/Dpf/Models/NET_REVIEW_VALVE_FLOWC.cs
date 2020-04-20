using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class NET_REVIEW_VALVE_FLOWC
    {

        [Key]
        [Column(Order = 0)]
		public string				NAME				{ get; set; }	
        [Key]
        [Column(Order = 1)]		
		public int					DIAM				{ get; set; }	
		public double?				VALUEX				{ get; set; }	

    }
}
