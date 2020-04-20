using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DBM_ZONE
    {

        [Key]
		public string				NAME				{ get; set; }	
		public string				AREACD				{ get; set; }	
		public int?					COLOR				{ get; set; }	
		public byte[]				GEOMETRY			{ get; set; }	
		public double?				MINX				{ get; set; }	
		public double?				MINY				{ get; set; }	
		public double?				MAXX				{ get; set; }	
		public double?				MAXY				{ get; set; }	
		public double?				MINZ				{ get; set; }	
		public double?				MAXZ				{ get; set; }	
		public double?				AVGZ				{ get; set; }	
		public double?				AVG_PRESS			{ get; set; }	
		public double?				INFLOW				{ get; set; }	
		public double?				DEMAND				{ get; set; }	
		public double?				LEAK_BASE			{ get; set; }	
		public double?				LEAK_BREAK			{ get; set; }	
		public double?				LEAKAGE				{ get; set; }	
		public double?				WQT_STAND_VIOLATE	{ get; set; }	
		public double?				PCAM_ROUGH_SCORE	{ get; set; }	
		public double?				DSS_ENVI			{ get; set; }	
		public int?					POPULATION_CNT		{ get; set; }	
		public int?					AREA_ORDER			{ get; set; }	

    }
}
