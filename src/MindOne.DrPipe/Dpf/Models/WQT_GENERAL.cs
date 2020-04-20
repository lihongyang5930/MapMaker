using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class WQT_GENERAL
    {

        [Key]
		public DateTime				WDATE				{ get; set; }	
		public string				WNAME				{ get; set; }	

    }
}
