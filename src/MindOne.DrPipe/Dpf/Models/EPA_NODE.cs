using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class EPA_NODE
    {

        [Key]
		public int					ID						{ get; set; }	
		public string				EPA_ID					{ get; set; }	
		public double?				AVG_DEMAND				{ get; set; }	
		public double?				MIN_DEMAND				{ get; set; }	
		public double?				MAX_DEMAND				{ get; set; }	
		public double?				STDDEV_DEMAND			{ get; set; }	
		public double?				AVG_HEAD				{ get; set; }	
		public double?				MIN_HEAD				{ get; set; }	
		public double?				MAX_HEAD				{ get; set; }	
		public double?				STDDEV_HEAD				{ get; set; }	
		public double?				AVG_PRESSURE			{ get; set; }	
		public double?				MIN_PRESSURE			{ get; set; }	
		public double?				MAX_PRESSURE			{ get; set; }	
		public double?				STDDEV_PRESSURE			{ get; set; }	
		public double?				AVG_QUALITY				{ get; set; }	
		public double?				MIN_QUALITY				{ get; set; }	
		public double?				MAX_QUALITY				{ get; set; }	
		public double?				STDDEV_QUALITY			{ get; set; }	

    }
}
