using System;
using System.Collections.Generic;
using System.Text;
using NBGIS.PluginEngine;

namespace NBGIS.MainTools
{
    public class MainMenuBar:NBGIS.PluginEngine.IMenuDef
    {
        #region IMenuDef 成员

        public string Caption
        {
            get { return "文件"; }
        }

        public void GetItemInfo(int pos, ItemDef itemDef)
        {
            switch (pos)
            {
                case 0:
                    itemDef.ID = "NBGIS.MainTools.CAddData";
                    itemDef.Group = false;
                    break;
                case 1:
                    itemDef.ID = "NBGIS.MainTools.CZoomIn";
                    itemDef.Group = true;
                    break;
                case 2:
                    itemDef.ID = "NBGIS.MainTools.CZoomOut";
                    itemDef.Group = false;
                    break;
                case 3:
                    itemDef.ID = "NBGIS.MainTools.CPan";
                    itemDef.Group = false;
                    break;
                case 4:
                    itemDef.ID = "NBGIS.MainTools.CIdentify";
                    itemDef.Group = false;
                    break;
                case 5:
                    itemDef.ID = "NBGIS.MainTools.CFullExtent";
                    itemDef.Group = true;
                    break;
                case 6:
                    itemDef.ID = "NBGIS.MainTools.CRefreshView";
                    itemDef.Group = false;
                    break;
                case 7:
                    //itemDef.ID = "NBGIS.MainTools.CIdentify";
                    //itemDef.Group = true;
                    break;
                default:
                    break;

            }
        }

        public long ItemCount
        {
            get { return 7; }
        }

        public string Name
        {
            get { return "MainMenu"; }
        }

        #endregion
    }
}
