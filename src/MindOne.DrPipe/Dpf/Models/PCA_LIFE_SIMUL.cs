using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class PCA_LIFE_SIMUL
    {

        [Key]
		public string				NAME			{ get; set; }	
		public byte[]				BIN				{ get; set; }	

    }
}
