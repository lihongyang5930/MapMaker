using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class NET_KPRESSURE
    {

        [Key]
		public string				PRJNAME				{ get; set; }	
		public DateTime?			PDATE				{ get; set; }	
		public byte[]				BIN					{ get; set; }	

    }
}
