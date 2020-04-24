using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class WTL_PIPE_LM
    {   
        public string FTR_CDE { get; set; }
        [Key]
        public string FTR_IDN { get; set; }
        public string IST_YMD { get; set; }
        public string BJD_CDE { get; set; }
        public string SAA_CDE { get; set; }
        public string SHT_NUM { get; set; }
        public string MOP_CDE { get; set; }
        public string MNG_CDE { get; set; }
        public string PIP_LEN { get; set; }
        public string RMK_DES { get; set; }
        public string JHT_CDE { get; set; }
        public string LOW_DEP { get; set; }
        public string HGH_DEP { get; set; }
        public string AVE_DEP { get; set; }
        public string HJD_CDE { get; set; }
        public string PIP_LBL { get; set; }
        public string LOD_YMD { get; set; }
        public string SAA_CHK { get; set; }
        public byte[] GEOMETRY { get; set; }

    }
}
