using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// IApplication�ӿڶ������������������
    /// </summary>
    public interface IApplication
    {
        /// <summary>
        /// ���������
        /// </summary>
        string Caption { get;set;}
        /// <summary>
        /// ������ǰʹ�õĹ���Tool����
        /// </summary>
        string CurrentTool { get;set;}
        /// <summary>
        /// ������洢GIS���ݵ����ݼ�
        /// </summary>
        DataSet MainDataSet { get;set;}
        /// <summary>
        /// ������������ĵ�����
        /// </summary>
        IMapDocument Document { get;set;}
        /// <summary>
        /// �������е�MapControl�ؼ�
        /// </summary>
        IMapControlDefault MapControl { get;set;}
        /// <summary>
        /// �������е�PageLayoutControl�ؼ�
        /// </summary>
        IPageLayoutControlDefault PageLayoutControl { get;set;}
        /// <summary>
        /// �����������
        /// </summary>
        string Name { get;}
        /// <summary>
        /// ������Ĵ������
        /// </summary>
        Form MainPlatfrom { get;set;}
        /// <summary>
        /// ���������е�״̬��
        /// </summary>
        StatusStrip StatusBar { get; set; }
        /// <summary>
        /// ������UI�����Visible����
        /// </summary>
        bool Visible { get;set;}
    }
}
