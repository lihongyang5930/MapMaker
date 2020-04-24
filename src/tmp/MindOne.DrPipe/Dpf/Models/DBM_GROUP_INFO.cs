using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DBM_GROUP_INFO
    {

        [Key]
        [Column(Order = 0)]
		public string				SECTION				{ get; set; }
		[Key]
        [Column(Order = 1)]
		public string				FIELD_NAME			{ get; set; }	
		public byte[]				BIN					{ get; set; }	

    }
}
