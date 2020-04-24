using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DBM_BLOCKB
    {

        [Key]
		public string				MGR_ID				{ get; set; }	
		public string				NAME				{ get; set; }	

    }
}
