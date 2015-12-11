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
    public class CPan : NBGIS.PluginEngine.ITool
    {
        private NBGIS.PluginEngine.IApplication hk;
        private System.Drawing.Bitmap m_hBitmap;
        private IActiveView pActiveView;

        public CPan()
        {
            string str = @"..\Data\Image\MainTools\pan.ico";
            if (System.IO.File.Exists(str))
                m_hBitmap = new Bitmap(str);
            else
                m_hBitmap = null;
        }


        #region ITool 成员

        public Bitmap Bitmap
        {
            get { return m_hBitmap; }
        }

        public string Caption
        {
            get { return "平移"; }
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
            get { return (int)ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerPan; }
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
            get { return "平移"; }
        }

        public string Name
        {
            get { return "Pan"; }
        }

        public void OnClick()
        {
            
        }

        public bool OnContextMenu(int x, int y)
        {
            return false;
        }

        public void OnCreate(IApplication hook)
        {
            if (hook != null)
            {
                this.hk = hook;
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
            pActiveView = hk.MapControl.ActiveView;
            hk.MapControl.Pan();

            ITrackCancel pTrackCancel = new CancelTrackerClass();
            pActiveView.Draw(0, pTrackCancel);
            if (pTrackCancel.Continue())
            {
                //hk.StatusBar.Panels[0].Text = "地图正在绘制";
            }
            else
            {
                //hk.StatusBar.Panels[0].Text = "地图绘制已经停止";
            }
            pActiveView.Refresh();
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
            get { return "平移"; }
        }

        #endregion
    }
}
