using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NBGIS.PluginEngine;

namespace NBGIS.FunLib
{
    public class CTest : NBGIS.PluginEngine.ICommand
    {
        public System.Drawing.Bitmap Bitmap
        {
            get { return null; }
        }

        public string Caption
        {
            get {return "ct"; }
        }

        public string Category
        {
            get { return "ct"; }
        }

        public bool Checked
        {
            get { return false; }
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
            get { return "ct"; }
        }

        public string Message
        {
            get { return "ct"; }
        }

        public string Name
        {
            get { return "ct"; }
        }

        public void OnClick()
        {
            System.Windows.Forms.MessageBox.Show("Test");
        }

        public void OnCreate(IApplication hook)
        {
        }

        public string Tooltip
        {
            get { return "ct"; }
        }
    }
}
