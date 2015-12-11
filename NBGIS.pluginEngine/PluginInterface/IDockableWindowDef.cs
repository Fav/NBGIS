using System;
using System.Collections.Generic;
using System.Text;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// �������ڽӿڶ���
    /// </summary>
    public interface IDockableWindowDef : NBGIS.PluginEngine.IPlugin
    {
        /// <summary>
        /// �����������
        /// </summary>
        string Caption { get;}
        /// <summary>
        /// ����������ͣ�����ӿؼ�
        /// </summary>
        System.Windows.Forms.Control ChildHWND { get;}
        /// <summary>
        /// ������������
        /// </summary>
        string Name { get;}
        /// <summary>
        /// �����������ʱ�����ķ���
        /// </summary>
        /// <param name="hook"></param>
        void OnCreate(NBGIS.PluginEngine.IApplication hook);
        /// <summary>
        /// ��������ر�ʱ�����ķ���
        /// </summary>
        void OnDestory();
        /// <summary>
        /// ������������������ڽ����Ķ��⸨�����ݶ���
        /// </summary>
        /// <returns></returns>
        object UserData { get;}
    }
}
