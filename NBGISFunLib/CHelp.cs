using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NBGIS.FunLib
{
    public class CHelp:NBGIS.PluginEngine.ICommand
    {
        private System.Drawing.Bitmap m_hBitmap;
        public CHelp()
        {
            string str = @"..\Data\Image\MainTools\zoomout.ico";
            if (System.IO.File.Exists(str))
                m_hBitmap = new Bitmap(str);
            else
                m_hBitmap = null;
        }
        #region ICommand 成员
        public System.Drawing.Bitmap Bitmap
        {
            get { return m_hBitmap; }
        }

        public string Caption
        {
            get { return "帮助"; }
        }

        public string Category
        {
            get { return "HelpMenu"; }
        }

        public bool Checked
        {
            get { return false ; }
        }

        public bool Enabled
        {
            get { return true; }
        }

        public int HelpContextId
        {
            get { return 0; }
        }

        public string HelpFile
        {
            get { return ""; }
        }

        public string Message
        {
            get { return "帮助"; }
        }

        public string Name
        {
            get { return "Help"; }
        }

        public void OnClick()
        {
            System.Windows.Forms.MessageBox.Show("Test");
        }

        public void OnCreate(NBGIS.PluginEngine.IApplication hook)
        {
        }

        public string Tooltip
        {
            get { return "帮助"; }
        }

        #endregion
    }
}
