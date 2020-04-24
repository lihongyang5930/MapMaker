using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class EPA_LINK_TIME_SERIES
    {

        [Key]
        [Column(Order = 0)]	
		public int					ID					{ get; set; }	
        [Key]
        [Column(Order = 1)]			
		public int					NTIME				{ get; set; }	
		public double?				FLOW				{ get; set; }	
		public double?				VELOCITY			{ get; set; }	
		public double?				HEADLOSS			{ get; set; }	
		public double?				FRICTION			{ get; set; }	
		public double?				REACTION			{ get; set; }	
		public double?				QUALITY				{ get; set; }	
		public string				STATUS				{ get; set; }	

    }
}
