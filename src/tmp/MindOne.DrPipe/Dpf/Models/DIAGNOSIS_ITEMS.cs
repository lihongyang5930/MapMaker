using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DIAGNOSIS_ITEMS
    {

        [Key]
        [Column(Order = 0)]
		public string				MODELE_NAME				{ get; set; }	
        [Column(Order = 1)]		
        public string				GROUP_NAME				{ get; set; }	
        [Key]
        [Column(Order = 2)]		
		public string				NAME					{ get; set; }	
		public string				SAMEWORD				{ get; set; }	
		public string				GOOD_RANGE				{ get; set; }	
		public string				UNIT					{ get; set; }	
		public string				STAND					{ get; set; }	
		public string				DESCRIPTION				{ get; set; }	

    }
}
