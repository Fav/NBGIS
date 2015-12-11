using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// IApplication�ӿڵ�ʵ��
    /// </summary>
    public class Application : IApplication
    {
        private string _Caption;
        private string _CurrentTool;
        private DataSet _MainDataSet;
        private INBMapDocument _Document;
        private INBMapControl _MapControl;
        private INBPageLayoutControl _PageLayoutControl;
        private string _Name;
        private Form _MainPlatfrom;
        private System.Windows.Forms.StatusStrip _StatusBar;
        private bool _Visible;
        #region IApplication ��Ա

        /// <summary>
        /// ��������� ֵ���ͺ��������Ͳ���Ҫ
        /// </summary>
        public string Caption
        {
            get
            {
                _Caption = this.MainPlatfrom.Text;
                return _Caption;
            }
            set
            {
                _Caption = value;
                _MainPlatfrom.Text = this._Caption;
            }
        }

        /// <summary>
        /// ������ǰʹ�õĹ���Tool����
        /// </summary>
        public string CurrentTool
        {
            get
            {
                return _CurrentTool;
            }
            set
            {
                _CurrentTool = value;
            }
        }

        /// <summary>
        /// ������洢GIS���ݵ����ݼ�
        /// </summary>
        public DataSet MainDataSet
        {
            get
            {
                return _MainDataSet;
            }
            set
            {
                _MainDataSet = value;
            }
        }

        /// <summary>
        /// ������������ĵ�����
        /// </summary>
        public INBMapDocument Document
        {
            get
            {
                return _Document;
            }
            set
            {
                _Document = value;
            }
        }

        /// <summary>
        /// �������е�MapControl�ؼ�
        /// </summary>
        public INBMapControl MapControl
        {
            get
            {
                return _MapControl;
            }
            set
            {
                _MapControl = value;
            }
        }

        /// <summary>
        /// �������е�PageLayoutControl�ؼ�
        /// </summary>
        public INBPageLayoutControl PageLayoutControl
        {
            get
            {
                return _PageLayoutControl;
            }
            set
            {
                _PageLayoutControl = value;
            }
        }

        /// <summary>
        /// �����������
        /// </summary>
        public string Name
        {
            get
            {
                this._Name = _MainPlatfrom.Text;
                return _Name;
            }
        }

        /// <summary>
        /// ������Ĵ������
        /// </summary>
        public Form MainPlatfrom
        {
            get
            {
                return _MainPlatfrom;
            }
            set
            {
                _MainPlatfrom = value;
            }
        }

        /// <summary>
        /// ���������е�״̬��
        /// </summary>
        public System.Windows.Forms.StatusStrip StatusBar
        {
            get
            {
                return _StatusBar;
            }
            set
            {
                _StatusBar = value;
            }
        }

        /// <summary>
        /// ������UI�����Visible����
        /// </summary>
        public bool Visible
        {
            get
            {
                _Visible = _MainPlatfrom.Visible;
                return _Visible;
            }
            set
            {
                _Visible = value;
                this._MainPlatfrom.Visible = _Visible;
            }
        }

        #endregion
    }
}
