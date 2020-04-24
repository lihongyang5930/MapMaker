using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DBM_RESV
    {

        [Key]
		public int					ID					{ get; set; }	
		public int?					NODE_ID				{ get; set; }	
		public string				MGR_ID				{ get; set; }	
		public string				NAME				{ get; set; }	
		public double?				ELEV				{ get; set; }	
		public double?				CAPACITY			{ get; set; }	
		public string				CTL_TYPE			{ get; set; }	
		public string				INSTALL_DATE		{ get; set; }	
		public double?				HIGH_LEVEL			{ get; set; }	
		public double?				LOW_LEVEL			{ get; set; }	

    }
}
