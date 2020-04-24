using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class EPA_NODE_GRID
    {

        [Key]
		public int					NTIME				{ get; set; }	
		public byte[]				DEMAND				{ get; set; }	
		public byte[]				PRESSURE			{ get; set; }	

    }
}
