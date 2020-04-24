using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrPipe.Core.Forms
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            AddLayer(@"C:\Users\dkkim\OneDrive\MIND-ONE\drpipe\Dr_pipe-거제-0914_작업파일\표고점.shp");
        }

        private void AddLayer(string filePath)
        {
            int layerHandle = axMap1.AddLayerFromFilename(filePath, MapWinGIS.tkFileOpenStrategy.fosAutoDetect, true);
            if (layerHandle == -1)
            {
                //Debug.WriteLine("Failed to open datasource: " + axMap1.FileManager.get_ErrorMsg(axMap1.FileManager.LastErrorCode));
            }
        }
    }
}
