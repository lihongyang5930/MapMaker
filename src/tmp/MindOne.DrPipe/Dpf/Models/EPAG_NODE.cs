using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class EPAG_NODE
    {

        [Key]
		public string				EPA_ID				{ get; set; }	
		public string				FID					{ get; set; }	
		public string				KIND				{ get; set; }	
		public string				STA_FID				{ get; set; }	
		public string				BLACD				{ get; set; }	
		public double?				PRESSURE_MIN		{ get; set; }	
		public double?				PRESSURE_AVG		{ get; set; }	
		public double?				PRESSURE_MAX		{ get; set; }	

    }
}
