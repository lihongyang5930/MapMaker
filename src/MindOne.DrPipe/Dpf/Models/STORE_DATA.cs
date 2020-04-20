using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class STORE_DATA
    {
		
        [Key]
        [Column(Order = 0)]			
		public string				MODULENAME			{ get; set; }	
        [Key]
        [Column(Order = 1)]			
		public string				NAME				{ get; set; }	
		public string				ETC1				{ get; set; }	
		public string				ETC2				{ get; set; }	
		public byte[]				DATA				{ get; set; }	

    }
}
