using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DBINFO
    {
        [Key]
		public int					VER					{ get; set; }	
		public string				UPDATE_DATE			{ get; set; }	

    }
}
