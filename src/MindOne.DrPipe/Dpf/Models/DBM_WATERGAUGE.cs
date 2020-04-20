using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DBM_WATERGAUGE
    {

        [Key]
		public int					ID					{ get; set; }	
		public int?					NODE_ID				{ get; set; }	
		public string				MGR_ID				{ get; set; }	
		public int?					HOUSE_CNT			{ get; set; }	
		public double?				DIAM				{ get; set; }	
		public string				SERIAL				{ get; set; }	
		public string				WSTATUS				{ get; set; }	
		public string				FORM				{ get; set; }	
		public string				GUPSU_NUM			{ get; set; }	
		public string				SAFEBOX_STATUS		{ get; set; }	
		public string				IS_USE				{ get; set; }	
		public string				INSTALL_DATE		{ get; set; }	
		public string				CUSTOMER_NAME		{ get; set; }	
		public string				CUSTOMER_TYPE		{ get; set; }	
		public string				BISS_TYPE			{ get; set; }	
		public int?					POPULATION_CNT		{ get; set; }	
		public string				ADDRESS				{ get; set; }	
		public double?				DEMAND_MIN			{ get; set; }	
		public double?				DEMAND_AVG			{ get; set; }	
		public double?				DEMAND_MAX			{ get; set; }	

    }
}
