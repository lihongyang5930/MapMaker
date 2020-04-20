using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DBM_PRESSGAUGE
    {

        [Key]
		public int					ID					{ get; set; }	
		public int?					NODE_ID				{ get; set; }	
		public string				MGR_ID				{ get; set; }	
		public string				DATA_PROCESS		{ get; set; }	
		public int?					DRAIN_DIAM			{ get; set; }	
		public string				VALVE_ROOM_NUM		{ get; set; }	
		public string				INSTALL_DATE		{ get; set; }	
		public string				USAGE				{ get; set; }	
		public string				KIND				{ get; set; }	
		public string				COMPANY				{ get; set; }	
		public string				MEASURE_SCOPE		{ get; set; }	
		public double?				X					{ get; set; }	
		public double?				Y					{ get; set; }	

    }
}
