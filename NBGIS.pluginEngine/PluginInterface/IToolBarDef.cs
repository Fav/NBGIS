using System;
using System.Collections.Generic;
using System.Text;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// 定义一个工具条
    /// </summary>
    public interface IToolBarDef : IPlugin
    {
        /// <summary>
        /// 工具条栏标题
        /// </summary>
        string Caption { get;}
        /// <summary>
        /// 工具条栏名称
        /// </summary>
        string Name { get;}
        /// <summary>
        /// 工具条携带的Item数量
        /// </summary>
        long ItemCount { get;}
        /// <summary>
        /// 访问工具条中每个Item的方法
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="itemDef"></param>
        void GetItemInfo(int pos, ItemDef itemDef);
    }
}
