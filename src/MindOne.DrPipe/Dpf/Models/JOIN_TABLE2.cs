using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class JOIN_TABLE2
    {

        [Key]
		public int					ID				{ get; set; }	
		public string				SUBTYPE			{ get; set; }	
		public double?				ETC_FLOAT		{ get; set; }	

    }
}
