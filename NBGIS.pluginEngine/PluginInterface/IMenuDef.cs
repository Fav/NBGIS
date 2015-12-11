using System;
using System.Collections.Generic;
using System.Text;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// 定义一个菜单栏
    /// </summary>
    public interface IMenuDef : IPlugin
    {
        /// <summary>
        /// 菜单栏标题
        /// </summary>
        string Caption { get;}
        /// <summary>
        /// 菜单栏名称
        /// </summary>
        string Name { get;}
        /// <summary>
        /// 菜单栏携带的Item数量
        /// </summary>
        long ItemCount { get;}
        /// <summary>
        /// 访问菜单栏中每个Item的方法
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="itemDef"></param>
        void GetItemInfo(int pos, ItemDef itemDef);
    }
}
