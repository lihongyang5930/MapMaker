using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class WQT_WATER_STAND
    {

        [Key]
		public string				NAME				{ get; set; }	
		public string				STAND				{ get; set; }	
		public string				UNIT				{ get; set; }	
		public string				DESCRIPTION			{ get; set; }	
		public string				SAMEWORD			{ get; set; }	

    }
}
