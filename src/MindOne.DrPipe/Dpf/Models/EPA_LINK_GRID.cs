using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class EPA_LINK_GRID
    {

        [Key]
		public int					NTIME				{ get; set; }	
		public byte[]				FLOW				{ get; set; }	
		public byte[]				VELOCITY			{ get; set; }	

    }
}
