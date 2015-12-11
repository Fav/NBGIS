using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using NBGIS.PluginEngine;

namespace NBGIS.MainTools
{
    class CRefreshView : NBGIS.PluginEngine.ICommand
    {
        private NBGIS.PluginEngine.IApplication hk;
        private System.Drawing.Bitmap m_hBitmap;

        private ESRI.ArcGIS.SystemUI.ICommand cmd = null;

        public CRefreshView()
        {
            string str = @"..\Data\Image\MainTools\refurbish.ico";
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
            get { return "刷新"; }
        }

        public string Category
        {
            get { return "MainTool"; }
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
            get { return ""; }
        }

        public string Message
        {
            get { return "刷新"; }
        }

        public string Name
        {
            get { return "RefreshView"; }
        }

        public void OnClick()
        {
            cmd.OnClick();
        }

        public void OnCreate(NBGIS.PluginEngine.IApplication hook)
        {
            if (hook != null)
            {
                this.hk = hook;
                cmd = new ControlsMapRefreshViewCommandClass();
                cmd.OnCreate(this.hk.MapControl);
            }
        }

        public string Tooltip
        {
            get { return "刷新"; }
        }

        #endregion
    }
}
