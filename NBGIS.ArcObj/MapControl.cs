using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NBGIS.PluginEngine;
using ESRI.ArcGIS.Controls;

namespace NBGIS.ArcObj
{
    public partial class MapControl : UserControl, INBMapControl
    {
        public MapControl()
        {
            InitializeComponent();
        }

        public ITool CurrentTool
        {
            get
            {
                return null;
            }
            set
            {
                ;
            }
        }

        public INBActiveView ActiveView
        {
            get
            {
                return null;
            }
            set
            {
                ;
            }
        }

        public void Pan()
        {
        }


        public int MousePointer
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }
    }
}
