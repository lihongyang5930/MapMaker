using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class NET_REVIEW_VALVE_CV
    {

        [Key]
        [Column(Order = 0)]
		public string				NAME			{ get; set; }	
		public string				CV				{ get; set; }	
		public double?				VALUEX			{ get; set; }	

    }
}
