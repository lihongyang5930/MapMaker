using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class CVA_PRESS
    {

        [Key]
        [Column(Order = 0)]
		public string				CVL_ID				{ get; set; }	
        [Key]
        [Column(Order = 1)]		
		public int					NODE_ID				{ get; set; }	
		public int?					PIPE_ID				{ get; set; }	
		public double?				X					{ get; set; }	
		public double?				Y					{ get; set; }	
		public DateTime?			CVL_DATE			{ get; set; }	
		public string				LOCATION			{ get; set; }	
		public string				CAUSE				{ get; set; }	
		public string				CVL_USER			{ get; set; }	
		public string				PRC_USER			{ get; set; }	
		public string				ETC					{ get; set; }	

    }
}
