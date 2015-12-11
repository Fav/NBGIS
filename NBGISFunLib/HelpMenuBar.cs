﻿using System;
using System.Collections.Generic;
using System.Text;
using NBGIS.PluginEngine;

namespace NBGIS.FunLib
{
    public class HelpMenuBar : NBGIS.PluginEngine.IMenuDef
    {
        #region IMenuDef 成员

        public string Caption
        {
            get { return "帮助"; }
        }

        public void GetItemInfo(int pos, ItemDef itemDef)
        {
            switch (pos)
            {
                case 0:
                    itemDef.ID = "NBGIS.FunLib.CHelp";
                    itemDef.Group = false;
                    break;
                //case 1:
                //    itemDef.ID = "NBGIS.MainTools.CZoomIn";
                //    itemDef.Group = true;
                //    break;
                //case 2:
                //    itemDef.ID = "NBGIS.MainTools.CZoomOut";
                //    itemDef.Group = false;
                //    break;
                //case 3:
                //    itemDef.ID = "NBGIS.MainTools.CPan";
                //    itemDef.Group = false;
                //    break;
                //case 4:
                //    itemDef.ID = "NBGIS.MainTools.CIdentify";
                //    itemDef.Group = false;
                //    break;
                //case 5:
                //    itemDef.ID = "NBGIS.MainTools.CFullExtent";
                //    itemDef.Group = true;
                //    break;
                //case 6:
                //    itemDef.ID = "NBGIS.MainTools.CRefreshView";
                //    itemDef.Group = false;
                //    break;
                //case 7:
                //    //itemDef.ID = "NBGIS.MainTools.CIdentify";
                //    //itemDef.Group = true;
                //    break;
                default:
                    break;

            }
        }

        public long ItemCount
        {
            get { return 1; }
        }

        public string Name
        {
            get { return "HelpMenu"; }
        }

        #endregion
    }
}
