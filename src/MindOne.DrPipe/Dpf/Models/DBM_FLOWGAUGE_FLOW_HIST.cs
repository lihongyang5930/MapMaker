using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DBM_FLOWGAUGE_FLOW_HIST
    {

        [Key]
        [Column(Order = 0)]
		public string				MGR_ID				{ get; set; }	
        [Key]
        [Column(Order = 1)]		
		public DateTime				YYMM				{ get; set; }	
		public double?				FLOW				{ get; set; }	

    }
}
