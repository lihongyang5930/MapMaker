using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DBM_BLOCKS
    {

        [Key]
        [Column(Order = 0)]
		public string				NAME				{ get; set; }	
        [Key]
        [Column(Order = 1)]		
		public string				MGR_ID				{ get; set; }	
		public string				BLOCKM_NAME			{ get; set; }	
		public string				BLOCKB_NAME			{ get; set; }	
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
		public double?				DEMAND				{ get; set; }	
		public double?				LEAKAGE				{ get; set; }	
		public int?					POPULATION_CNT		{ get; set; }	

    }
}
