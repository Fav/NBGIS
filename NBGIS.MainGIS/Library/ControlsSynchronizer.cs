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
    /// 同步类
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
        /// 将MapControl和PageLayoutControl通过同一个焦点Map进行绑定
        /// </summary>
        /// <param name="activateMapFirst">如果MapControl作为默认活动控件设置为True</param>
        public void BindControls(bool activateMapFirst)
        {
            if (m_pageLayoutControl == null || m_mapControl == null)
                throw new Exception("ControlsSynchronizer::BindControls:\r\nMapControl或PageLayoutControl没有初始化!");

            //产生一个Map对象
            IMap newMap = new MapClass();
            newMap.Name = "地图";

            //产生一个地图容器IMaps对象
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
        /// Buddy控件的存放集合
        /// </summary>
        /// <param name="control"></param>
        public void AddFrameWorkControl(object control)
        {
            if (control == null)
                throw new Exception("ControlsSynchronizer::AddFrameWorkControl\r\n添加到控件没有初始化!");
            m_frameworkControls.Add(control);
        }

        /// <summary>
        /// 当活动控件改变时,将TOCControl的Buddy控件设置为当前活动控件
        /// </summary>
        /// <param name="buddy">当前活动控件</param>
        public void SetBuddies(object buddy)
        {
            if (buddy == null)
                throw new Exception("ControlsSynchronizer::SetBuddies\r\n目标buddy控件没有初始化!");
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
        /// 激活MapControl并使PageLayoutControl处于非激活状态
        /// </summary>
        public void ActivateMap()
        {
            try
            {
                if (m_pageLayoutControl == null || m_mapControl == null)
                    throw new Exception("ControlsSynchronizer::ActivateMap:\r\nMapControl或PageLayoutControl没有初始化!");
                //使PageLayout的视图处于非活动状态
                m_pageLayoutControl.ActiveView.Deactivate();
                //使MapControl视图处于活动状态
                m_mapControl.ActiveView.Activate(m_mapControl.hWnd);

                m_IsMapCtrlactive = true;
                //将MapControl控件设置为TOCControl的Buddy控件
                SetBuddies(m_mapControl.Object);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ControlsSynchronizer::ActivateMap:\r\n{0}", ex.Message));
            }
        }

        /// <summary>
        ///  激活PageLayoutControl并使MapControl处于非激活状态
        /// </summary>
        public void ActivatePageLayout()
        {
            try
            {
                if (m_pageLayoutControl == null || m_mapControl == null)
                    throw new Exception("ControlsSynchronizer::ActivatePageLayout:\r\nMapControl或PageLayoutControl没有初始化!");
                //使m_mapControl的视图处于非活动状态
                m_mapControl.ActiveView.Deactivate();
                //使m_pageLayoutControl视图处于活动状态
                m_pageLayoutControl.ActiveView.Activate(m_pageLayoutControl.hWnd);

                m_IsMapCtrlactive = false;
                //将MapControl控件设置为TOCControl的Buddy控件
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
                throw new Exception("ControlsSynchronizer::ReplaceMap\r\n新Map没有初始化!");
            if (m_pageLayoutControl == null || m_mapControl == null)
                throw new Exception("ControlsSynchronizer::ReplaceMap:\r\nMapControl或PageLayoutControl没有初始化!");

            //产生一个地图容器IMaps对象
            IMaps maps = new Maps();
            //将新Map添加到Maps集合
            maps.Add(newMap);

            bool bIsMapActive = m_IsMapCtrlactive;

            //使PageLayoutControl处于激活状态才能调用ReplaceMaps名列
            this.ActivatePageLayout();
            m_pageLayoutControl.PageLayout.ReplaceMaps(maps);

            //将Map传递给MapControl
            m_mapControl.Map = newMap;

            //保证一个活动控件处于激活状态
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

