using System;
using System.Collections.Generic;
using System.Text;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// 定义菜单栏和工具条中的命令项(Item)
    /// </summary>
    public interface IItemDef
    {
        /// <summary>
        /// 该按钮是否属于一个新组
        /// </summary>
        bool Group { get;set;}
        /// <summary>
        /// Item的ID
        /// </summary>
        string ID { get;set;}
        /// <summary>
        /// Item的子类Command或Tool
        /// </summary>
        long Subtype { get;set;}
    }
}
