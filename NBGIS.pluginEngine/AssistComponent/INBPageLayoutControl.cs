using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NBGIS.PluginEngine
{
    public interface INBPageLayoutControl
    {
        ITool CurrentTool { get; set; }
        INBActiveView ActiveView { get; set; }
        int MousePointer { get; set; }
        void Pan();
    }
}
