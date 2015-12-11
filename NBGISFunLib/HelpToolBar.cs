using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NBGIS.FunLib
{
    public class HelpToolBar:NBGIS.PluginEngine.IToolBarDef
    {
        public string Caption
        {
            get { return  "帮助"; }
        }

        public string Name
        {
            get { return "help"; }
        }

        public long ItemCount
        {
            get { return 1; }
        }

        public void GetItemInfo(int pos, NBGIS.PluginEngine.ItemDef itemDef)
        {
            switch (pos)
            {
                case 0:
                    itemDef.ID = "NBGIS.FunLib.CHelp";
                    itemDef.Group = false;
                    break;
                default:
                    break;
            }
        }
    }
}
