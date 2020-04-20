using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class PCA_MEDIA
    {

		[Key]
		public int					PIPE_ID				{ get; set; }	
		public string				FILENAME			{ get; set; }	
		public byte[]				STREAM				{ get; set; }	
		public string				FTYPE				{ get; set; }	
		public string				FEXT				{ get; set; }	

    }
}
