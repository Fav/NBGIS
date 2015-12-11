using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geometry;

namespace NBGIS.MainGIS
{
    /// <summary>
    /// ͬ����
    /// </summary>
    public class ControlsSynchronizer
    {
        private IMapControlDefault m_mapControl = null;
        private IPageLayoutControlDefault m_pageLayoutControl = null;

        private bool m_IsMapCtrlactive = true;

        private ArrayList m_frameworkControls = null;

        public ControlsSynchronizer()
        {
            m_frameworkControls = new ArrayList();
        }

        public ControlsSynchronizer(IMapControlDefault mapControl, IPageLayoutControlDefault pageLayoutControl)
            : this()
        {
            m_mapControl = mapControl;
            m_pageLayoutControl = pageLayoutControl;
        }

        public IMapControlDefault MapControl
        {
            get { return m_mapControl; }
            set { m_mapControl = value; }
        }

        public IPageLayoutControlDefault PageLayoutControl
        {
            get { return m_pageLayoutControl; }
            set { m_pageLayoutControl = value; }
        }

        /// <summary>
        /// ��MapControl��PageLayoutControlͨ��ͬһ������Map���а�
        /// </summary>
        /// <param name="activateMapFirst">���MapControl��ΪĬ�ϻ�ؼ�����ΪTrue</param>
        public void BindControls(bool activateMapFirst)
        {
            if (m_pageLayoutControl == null || m_mapControl == null)
                throw new Exception("ControlsSynchronizer::BindControls:\r\nMapControl��PageLayoutControlû�г�ʼ��!");

            //����һ��Map����
            IMap newMap = new MapClass();
            newMap.Name = "��ͼ";

            //����һ����ͼ����IMaps����
            IMaps maps = new Maps();
            maps.Add(newMap);

            m_pageLayoutControl.PageLayout.ReplaceMaps(maps);
            m_mapControl.Map = newMap;

            if (activateMapFirst)
                this.ActivateMap();
            else
                this.ActivatePageLayout();
        }

        /// <summary>
        /// Buddy�ؼ��Ĵ�ż���
        /// </summary>
        /// <param name="control"></param>
        public void AddFrameWorkControl(object control)
        {
            if (control == null)
                throw new Exception("ControlsSynchronizer::AddFrameWorkControl\r\n��ӵ��ؼ�û�г�ʼ��!");
            m_frameworkControls.Add(control);
        }

        /// <summary>
        /// ����ؼ��ı�ʱ,��TOCControl��Buddy�ؼ�����Ϊ��ǰ��ؼ�
        /// </summary>
        /// <param name="buddy">��ǰ��ؼ�</param>
        public void SetBuddies(object buddy)
        {
            if (buddy == null)
                throw new Exception("ControlsSynchronizer::SetBuddies\r\nĿ��buddy�ؼ�û�г�ʼ��!");
            try
            {
                foreach (object obj in m_frameworkControls)
                {
                    if (obj is ITOCControl)
                    {
                        ((ITOCControl)obj).SetBuddyControl(buddy);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ControlsSynchronizer::SetBuddies:\r\n{0}", ex.Message));
            }
        }

        /// <summary>
        /// ����MapControl��ʹPageLayoutControl���ڷǼ���״̬
        /// </summary>
        public void ActivateMap()
        {
            try
            {
                if (m_pageLayoutControl == null || m_mapControl == null)
                    throw new Exception("ControlsSynchronizer::ActivateMap:\r\nMapControl��PageLayoutControlû�г�ʼ��!");
                //ʹPageLayout����ͼ���ڷǻ״̬
                m_pageLayoutControl.ActiveView.Deactivate();
                //ʹMapControl��ͼ���ڻ״̬
                m_mapControl.ActiveView.Activate(m_mapControl.hWnd);

                m_IsMapCtrlactive = true;
                //��MapControl�ؼ�����ΪTOCControl��Buddy�ؼ�
                SetBuddies(m_mapControl.Object);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ControlsSynchronizer::ActivateMap:\r\n{0}", ex.Message));
            }
        }

        /// <summary>
        ///  ����PageLayoutControl��ʹMapControl���ڷǼ���״̬
        /// </summary>
        public void ActivatePageLayout()
        {
            try
            {
                if (m_pageLayoutControl == null || m_mapControl == null)
                    throw new Exception("ControlsSynchronizer::ActivatePageLayout:\r\nMapControl��PageLayoutControlû�г�ʼ��!");
                //ʹm_mapControl����ͼ���ڷǻ״̬
                m_mapControl.ActiveView.Deactivate();
                //ʹm_pageLayoutControl��ͼ���ڻ״̬
                m_pageLayoutControl.ActiveView.Activate(m_pageLayoutControl.hWnd);

                m_IsMapCtrlactive = false;
                //��MapControl�ؼ�����ΪTOCControl��Buddy�ؼ�
                SetBuddies(m_pageLayoutControl.Object);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ControlsSynchronizer::ActivatePageLayout:\r\n{0}", ex.Message));
            }
        }

        public void ReplaceMap(IMap newMap)
        {
            if (newMap == null)
                throw new Exception("ControlsSynchronizer::ReplaceMap\r\n��Mapû�г�ʼ��!");
            if (m_pageLayoutControl == null || m_mapControl == null)
                throw new Exception("ControlsSynchronizer::ReplaceMap:\r\nMapControl��PageLayoutControlû�г�ʼ��!");

            //����һ����ͼ����IMaps����
            IMaps maps = new Maps();
            //����Map��ӵ�Maps����
            maps.Add(newMap);

            bool bIsMapActive = m_IsMapCtrlactive;

            //ʹPageLayoutControl���ڼ���״̬���ܵ���ReplaceMaps����
            this.ActivatePageLayout();
            m_pageLayoutControl.PageLayout.ReplaceMaps(maps);

            //��Map���ݸ�MapControl
            m_mapControl.Map = newMap;

            //��֤һ����ؼ����ڼ���״̬
            if (bIsMapActive)
            {
                this.ActivateMap();
                m_mapControl.ActiveView.Refresh();
            }
            else
            {
                this.ActivatePageLayout();
                m_pageLayoutControl.ActiveView.Refresh();
            }
        }
    }
}

