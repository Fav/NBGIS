using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using NBGIS.PluginEngine;

namespace NBGIS.MainTools
{
    public class CIdentify : NBGIS.PluginEngine.ITool
    {
        private NBGIS.PluginEngine.IApplication hk;
        private System.Drawing.Bitmap m_hBitmap;

        private ESRI.ArcGIS.SystemUI.ITool tool = null;
        private ESRI.ArcGIS.SystemUI.ICommand cmd = null;

        public CIdentify()
        {
            string str = @"..\Data\Image\MainTools\info.ico";
            if (System.IO.File.Exists(str))
                m_hBitmap = new Bitmap(str);
            else
                m_hBitmap = null;
        }

        #region ITool 成员

        public System.Drawing.Bitmap Bitmap
        {
            get { return m_hBitmap; }
        }

        public string Caption
        {
            get { return "要素属性"; }
        }

        public string Category
        {
            get { return "MainTool"; }
        }

        public bool Checked
        {
            get { return false; }
        }

        public int Cursor
        {
            get { return (int)ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerIdentify; }
        }

        public bool Deactivate()
        {
            return false;
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
            get { return "要素属性"; }
        }

        public string Name
        {
            get { return "Identify"; }
        }

        public void OnClick()
        {
            cmd.OnClick();
            hk.MapControl.CurrentTool = tool;
        }

        public bool OnContextMenu(int x, int y)
        {
            return false;
        }

        public void OnCreate(NBGIS.PluginEngine.IApplication hook)
        {
            if (hook != null)
            {
                hk = hook;
                tool = new ControlsMapIdentifyToolClass();
                cmd = tool as ESRI.ArcGIS.SystemUI.ICommand;
                cmd.OnCreate(this.hk.MapControl);
            }
        }

        public void OnDblClick()
        {

        }

        public void OnKeyDown(int keyCode, int shift)
        {

        }

        public void OnKeyUp(int keyCode, int shift)
        {

        }

        public void OnMouseDown(int button, int shift, int x, int y)
        {

        }

        public void OnMouseMove(int button, int shift, int x, int y)
        {

        }

        public void OnMouseUp(int button, int shift, int x, int y)
        {

        }

        public void Refresh(int hDC)
        {

        }

        public string Tooltip
        {
            get { return "要素属性"; }
        }

        #endregion
    }
}
