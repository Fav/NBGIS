using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// ICommand�ӿ�����AO���е�ICommand�ӿ�
    /// </summary>
    public interface ICommand : IPlugin
    {
        /// <summary>
        /// ���ť��ͼ��
        /// </summary>
        Bitmap Bitmap { get;}
        /// <summary>
        /// ���ť������
        /// </summary>
        string Caption { get;}
        /// <summary>
        /// ���ť���������
        /// </summary>
        string Category { get;}
        /// <summary>
        /// ���ť�Ƿ�ѡ��
        /// </summary>
        bool Checked { get;}
        /// <summary>
        /// ���ť�Ƿ����
        /// </summary>
        bool Enabled { get;}
        /// <summary>
        /// ���ٰ���ID
        /// </summary>
        int HelpContextId { get;}
        /// <summary>
        /// �����ļ�·��
        /// </summary>
        string HelpFile { get;}
        /// <summary>
        /// ����Ƶ���ť��ʱ״̬�����ֵ�����
        /// </summary>
        string Message { get;}
        /// <summary>
        /// ��ť����
        /// </summary>
        string Name { get;}
        /// <summary>
        /// ��ť���ʱ�����ķ���
        /// </summary>
        void OnClick();
        /// <summary>
        /// ��ť�����Ǵ����ķ���
        /// </summary>
        /// <param name="hook">��ܵ���������</param>
        void OnCreate(IApplication hook);
        /// <summary>
        /// ����Ƶ���ť�ϵ���������
        /// </summary>
        string Tooltip { get;}
    }
}
