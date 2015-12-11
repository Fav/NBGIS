using System;
using System.Collections.Generic;
using System.Text;
using NBGIS.PluginEngine;

namespace NBGIS.DockOverMap
{
    public class dockableOverMapWin : NBGIS.PluginEngine.IDockableWindowDef
    {
        #region IDockableWindowDef ³ÉÔ±

        private DockFrom frm = null;

        public string Caption
        {
            get { return "Äñî«µØÍ¼"; }
        }

        public System.Windows.Forms.Control ChildHWND
        {
            get { return frm.axMapControl; }
        }

        public string Name
        {
            get { return "OverMapWin"; }
        }

        public void OnCreate(IApplication hook)
        {
            frm = new DockFrom();
            if (hook != null)
            {
                frm.Hook = hook;
            }
        }

        public void OnDestory()
        {
            frm = null;
        }

        public object UserData
        {
            get { return null; }
        }

        #endregion
    }
}
