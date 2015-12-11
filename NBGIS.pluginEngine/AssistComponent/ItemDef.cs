using System;
using System.Collections.Generic;
using System.Text;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// ����˵����͹������е�������(Item)ʵ��
    /// </summary>
    public class ItemDef : IItemDef
    {
        private bool _Group;
        private string _ID;
        private long _Subtype;
        
        #region IItemDef ��Ա
        /// <summary>
        /// �ð�ť�Ƿ�����һ������
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
        /// Item��ID
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
        /// Item������Command��Tool
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
