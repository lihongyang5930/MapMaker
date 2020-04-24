using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DBM_CVRU
    {

        [Key]
		public string			NAME				{ get; set; }	
		public int?				LIFE				{ get; set; }	

    }
}
