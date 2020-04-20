using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class WQT_GENERAL_NODE
    {

		[Key]
		public string				EPA_ID				{ get; set; }	
		public double?				X					{ get; set; }	
		public double?				Y					{ get; set; }	
		public string				LOC_DESC			{ get; set; }	
		public int?					LEVEL				{ get; set; }	
		public string				PARENT_EPA_ID		{ get; set; }	
		public int?					NORDER				{ get; set; }	
		public string				BLOCKS				{ get; set; }	
		public string				ZONE				{ get; set; }	
		public string				DSSPE_GRADE			{ get; set; }	

    }
}
