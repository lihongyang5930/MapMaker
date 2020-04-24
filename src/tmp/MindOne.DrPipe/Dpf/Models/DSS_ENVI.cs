using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DSS_ENVI
    {

        [Key]	
		public string			ZONE					{ get; set; }	
		public int?				ITEM1IDX				{ get; set; }	
		public int?				ITEM2IDX				{ get; set; }	
		public int?				ITEM3IDX				{ get; set; }	
		public int?				ITEM4IDX				{ get; set; }	
		public int?				ITEM5IDX				{ get; set; }	
		public int?				ITEM6IDX				{ get; set; }	
		public int?				ITEM7IDX				{ get; set; }	
		public int?				ITEM8IDX				{ get; set; }	
		public int?				ITEM9IDX				{ get; set; }	
		public int?				ITEM10IDX				{ get; set; }	

    }
}
