using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// ITool�ӿڻ����AO��ICommand�ӿں�ITool�ӿ�
    /// </summary>
    public interface ITool : IPlugin
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
        /// <summary>
        /// ����ڵ�ͼ�ϵ���ʽ
        /// </summary>
        int Cursor { get;}
        /// <summary>
        /// Tool�ļ���״̬����
        /// </summary>
        /// <returns></returns>
        bool Deactivate();
        /// <summary>
        /// ���˫����ͼʱ�������¼�
        /// </summary>
        void OnDblClick();
        /// <summary>
        /// ������Ҽ�������ݲ˵�ʱ�������¼�
        /// </summary>
        /// <param name="x">�˵���x����</param>
        /// <param name="y">�˵���y����</param>
        /// <returns></returns>
        bool OnContextMenu(int x, int y);
        /// <summary>
        /// ����ڵ�ͼ���ƶ�ʱ�������¼�
        /// </summary>
        /// <param name="button"></param>
        /// <param name="shift"></param>
        /// <param name="x">x������</param>
        /// <param name="y">y������</param>
        void OnMouseMove(int button, int shift, int x, int y);
        /// <summary>
        /// �������ͼʱ�������¼�
        /// </summary>
        /// <param name="button"></param>
        /// <param name="shift"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void OnMouseDown(int button, int shift, int x, int y);
        /// <summary>
        /// ����ڵ�ͼ�ϵ���ʱ�������¼�
        /// </summary>
        /// <param name="button"></param>
        /// <param name="shift"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void OnMouseUp(int button, int shift, int x, int y);
        /// <summary>
        /// ��ͼˢ��ʱ�������¼�
        /// </summary>
        /// <param name="hDC"></param>
        void Refresh(int hDC);
        /// <summary>
        /// ����ĳ���������ʱ�������¼�
        /// </summary>
        /// <param name="keyCode"></param>
        /// <param name="shift"></param>
        void OnKeyDown(int keyCode,int shift);
        /// <summary>
        /// ����ĳ������������𴥷����¼�
        /// </summary>
        /// <param name="keyCode"></param>
        /// <param name="shift"></param>
        void OnKeyUp(int keyCode, int shift);
    }
}
