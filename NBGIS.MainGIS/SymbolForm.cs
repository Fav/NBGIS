using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.ADF;

namespace NBGIS.MainGIS
{
    public partial class SymbolForm : Form
    {
        public IStyleGalleryItem m_styleGalleryItem;
        public SymbolForm()
        {
            InitializeComponent();
        }

        private void SymbolForm_Load(object sender, EventArgs e)
        {
            //���ArcGIS�İ�װ·��
            string sInstall =ReadRegistry("SOFTWARE\\ESRI\\CoreRuntime");
            //��ESRI.ServerStyle�ļ�����ؼ���
            axSymbologyControl.LoadStyleFile(sInstall + "\\Styles\\ESRI.ServerStyle");
        }

        private string ReadRegistry(string sKey)
        {
            //��ע����
            RegistryKey rk = Registry.LocalMachine.OpenSubKey(sKey, true);
            //���ArcGIS��װĿ¼��Ϣ
            return (string)rk.GetValue("InstallDir");
        }

        private void PreviewImage()
        {
            ISymbologyStyleClass symbologyStyleClass = axSymbologyControl.GetStyleClass(axSymbologyControl.StyleClass);
            stdole.IPictureDisp picture = symbologyStyleClass.PreviewItem(m_styleGalleryItem, SymbolPictureBox.Width, SymbolPictureBox.Height);
            System.Drawing.Image image = Image.FromHbitmap(new IntPtr(picture.Handle));
            SymbolPictureBox.Image = image;
        }

        public IStyleGalleryItem GetItem(esriSymbologyStyleClass styleClass)
        {
            m_styleGalleryItem = null;
            axSymbologyControl.StyleClass = styleClass;
            axSymbologyControl.GetStyleClass(styleClass).UnselectItem();
            this.ShowDialog();
            return m_styleGalleryItem;
        }

        private void axSymbologyControl_OnItemSelected(object sender, ISymbologyControlEvents_OnItemSelectedEvent e)
        {
            m_styleGalleryItem = (IStyleGalleryItem)e.styleGalleryItem;
            PreviewImage();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCencel_Click(object sender, EventArgs e)
        {
            m_styleGalleryItem = null;
            this.Hide();
        }
    }
}