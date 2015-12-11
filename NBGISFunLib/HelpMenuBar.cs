using System;
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
                case 1:
                    itemDef.ID = "NBGIS.FunLib.CTest";
                    itemDef.Group = false;
                    break;
                default:
                    break;

            }
        }

        public long ItemCount
        {
            get { return 2; }
        }

        public string Name
        {
            get { return "HelpMenu"; }
        }

        #endregion
    }
}
