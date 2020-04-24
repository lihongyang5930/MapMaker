using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DBM_LAYER_EX
    {

        [Key]
        [Column(Order = 0)]
		public string				NAME				{ get; set; }	
        [Key]
        [Column(Order = 1)]		
		public string				NTYPE				{ get; set; }	
		public byte[]				BIN					{ get; set; }	

    }
}
