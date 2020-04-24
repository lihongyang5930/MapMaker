using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class EPA_NODE_TIME_SERIES
    {

        [Key]
        [Column(Order = 0)]
		public int					ID					{ get; set; }	
        [Key]
        [Column(Order = 1)]		
		public int					NTIME				{ get; set; }	
		public double?				DEMAND				{ get; set; }	
		public double?				HEAD				{ get; set; }	
		public double?				PRESSURE			{ get; set; }	
		public double?				QUALITY				{ get; set; }	

    }
}
