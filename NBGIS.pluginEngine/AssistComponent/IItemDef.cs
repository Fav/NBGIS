using System;
using System.Collections.Generic;
using System.Text;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// ����˵����͹������е�������(Item)
    /// </summary>
    public interface IItemDef
    {
        /// <summary>
        /// �ð�ť�Ƿ�����һ������
        /// </summary>
        bool Group { get;set;}
        /// <summary>
        /// Item��ID
        /// </summary>
        string ID { get;set;}
        /// <summary>
        /// Item������Command��Tool
        /// </summary>
        long Subtype { get;set;}
    }
}
