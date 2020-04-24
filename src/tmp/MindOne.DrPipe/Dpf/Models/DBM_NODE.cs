using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DBM_NODE
    {

        [Key]
		public int					ID					{ get; set; }	
		public string				MGR_ID				{ get; set; }	
		public string				NAME				{ get; set; }	
		public string				LOC_DESC			{ get; set; }	
		public double?				X					{ get; set; }	
		public double?				Y					{ get; set; }	
		public double?				Z					{ get; set; }	
		public double?				LEAK				{ get; set; }	
		public string				ZONE				{ get; set; }	
		public string				BLOCKS				{ get; set; }	
		public string				BLOCKM				{ get; set; }	
		public string				BLOCKB				{ get; set; }	

    }
}
