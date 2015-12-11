using System;
using System.Collections.Generic;
using System.Text;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// 定义菜单栏和工具条中的命令项(Item)实现
    /// </summary>
    public class ItemDef : IItemDef
    {
        private bool _Group;
        private string _ID;
        private long _Subtype;
        
        #region IItemDef 成员
        /// <summary>
        /// 该按钮是否属于一个新组
        /// </summary>
        public bool Group
        {
            get
            {
                return _Group;
            }
            set
            {
                _Group = value;
            }
        }
        /// <summary>
        /// Item的ID
        /// </summary>
        public string ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
        /// <summary>
        /// Item的子类Command或Tool
        /// </summary>
        public long Subtype
        {
            get
            {
                return _Subtype;
            }
            set
            {
                _Subtype = value;
            }
        }

        #endregion
    }
}
