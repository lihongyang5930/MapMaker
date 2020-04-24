using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class CODE_TABLE
    {

        [Key]
        [Column(Order = 0)]
		public string				TBNAME				{ get; set; }	
        [Key]
        [Column(Order = 1)]		
		public string				FDNAME				{ get; set; }	
		public string				CODE				{ get; set; }	

    }
}
