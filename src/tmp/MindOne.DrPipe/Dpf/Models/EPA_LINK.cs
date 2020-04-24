using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class EPA_LINK
    {

        [Key]
		public int					ID							{ get; set; }	
		public double?				AVG_FLOW					{ get; set; }	
		public double?				MIN_FLOW					{ get; set; }	
		public double?				MAX_FLOW					{ get; set; }	
		public double?				STDDEV_FLOW					{ get; set; }	
		public double?				AVG_VELOCITY				{ get; set; }	
		public double?				MIN_VELOCITY				{ get; set; }	
		public double?				MAX_VELOCITY				{ get; set; }	
		public double?				STDDEV_VELOCITY				{ get; set; }	
		public double?				AVG_HEADLOSS				{ get; set; }	
		public double?				MIN_HEADLOSS				{ get; set; }	
		public double?				MAX_HEADLOSS				{ get; set; }	
		public double?				STDDEV_HEADLOSS				{ get; set; }	
		public double?				AVG_FRICTION				{ get; set; }	
		public double?				MIN_FRICTION				{ get; set; }	
		public double?				MAX_FRICTION				{ get; set; }	
		public double?				STDDEV_FRICTION				{ get; set; }	
		public double?				AVG_REACTION				{ get; set; }	
		public double?				MIN_REACTION				{ get; set; }	
		public double?				MAX_REACTION				{ get; set; }	
		public double?				STDDEV_REACTION				{ get; set; }	
		public double?				AVG_QUALITY					{ get; set; }	
		public double?				MIN_QUALITY					{ get; set; }	
		public double?				MAX_QUALITY					{ get; set; }	
		public double?				STDDEV_QUALITY				{ get; set; }	

    }
}
