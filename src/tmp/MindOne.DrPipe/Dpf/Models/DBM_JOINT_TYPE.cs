using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DBM_JOINT_TYPE
    {

		[Key]
		public string				NAME				{ get; set; }	
		public double?				SCORE_EVEL			{ get; set; }	

    }
}
