using System;
using System.Collections.Generic;
using System.Text;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// ����һ��������
    /// </summary>
    public interface IToolBarDef : IPlugin
    {
        /// <summary>
        /// ������������
        /// </summary>
        string Caption { get;}
        /// <summary>
        /// ������������
        /// </summary>
        string Name { get;}
        /// <summary>
        /// ������Я����Item����
        /// </summary>
        long ItemCount { get;}
        /// <summary>
        /// ���ʹ�������ÿ��Item�ķ���
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="itemDef"></param>
        void GetItemInfo(int pos, ItemDef itemDef);
    }
}
