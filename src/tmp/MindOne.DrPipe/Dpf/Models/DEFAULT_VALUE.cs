using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DEFAULT_VALUE
    {
        [Key]
		public string				NAME					{ get; set; }	
		public string				GROUPNAME				{ get; set; }	
		public string				GROUPNAME2				{ get; set; }	
		public string				GROUPNAME3				{ get; set; }	
		public string				GROUPNAME4				{ get; set; }	
		public string				VALUEX					{ get; set; }	
		public string				VALUEX2					{ get; set; }	
		public string				DESCRIPTION				{ get; set; }	
    }
}
