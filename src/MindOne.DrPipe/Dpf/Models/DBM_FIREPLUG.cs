using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DBM_FIREPLUG
    {

        [Key]
        [Column(Order = 0)]
		public int					NODE_ID				{ get; set; }	
        [Key]
        [Column(Order = 1)]		
		public int					ID					{ get; set; }	
		public string				MGR_ID				{ get; set; }	
		public double?				TANK_HIGH			{ get; set; }	
		public int?					DRAIN_DIAM			{ get; set; }	
		public string				INSTALL_DATE		{ get; set; }	
		public int?					DIAM				{ get; set; }	
		public string				FORM				{ get; set; }	
		public string				DEMAND_NUM			{ get; set; }	

    }
}
