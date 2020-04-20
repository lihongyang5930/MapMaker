using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class CVA_LEAKAGE
    {

        [Key]
		public string				LEAKAGE_NUM				{ get; set; }	
		public int?					PIPE_ID					{ get; set; }	
		public DateTime?			CVA_DATE				{ get; set; }	
		public DateTime?			REPAIRDATE				{ get; set; }	
		public string				MGR_ID					{ get; set; }	
		public string				LOCATION				{ get; set; }	
		public string				CAUSE					{ get; set; }	
		public string				XPOS					{ get; set; }	
		public string				CONTENTS				{ get; set; }	
		public string				ETC						{ get; set; }	
		public decimal?				NYEAR					{ get; set; }	

    }
}
