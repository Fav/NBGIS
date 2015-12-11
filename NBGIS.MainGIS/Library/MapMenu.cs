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
using ESRI.ArcGIS.ADF;

namespace NBGIS.MainGIS
{
    public class MapMenu : ESRI.ArcGIS.ADF.BaseClasses.BaseCommand, ICommandSubType
    {

        private IHookHelper m_hookHelper = new HookHelperClass();
        private long m_subType;

        public MapMenu()
        {
        }

        public override void OnClick()
        {
            switch (m_subType)
            {
                case 1:
                case 2:
                    for (int i = 0; i <= m_hookHelper.FocusMap.LayerCount - 1; i++)
                    {
                        if (m_subType == 1)
                            m_hookHelper.FocusMap.get_Layer(i).Visible = true;
                        if (m_subType == 2)
                            m_hookHelper.FocusMap.get_Layer(i).Visible = false;
                    }
                    m_hookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                    break;
                default:
                    break;
            }
        }

        public override void OnCreate(object hook)
        {
            m_hookHelper.Hook = hook;
        }

        #region ICommandSubType 成员

        public int GetCount()
        {
            return 2;
        }

        public void SetSubType(int SubType)
        {
            m_subType = SubType;
        }

        #endregion

        public override string Caption
        {
            get
            {
                switch (m_subType)
                {
                    case 1:
                        return "显示所有图层";
                    case 2:
                        return "关闭所有图层"; 
                    default:
                        return "";
                }
            }
        }

        public override bool Enabled
        {
            get
            {
                bool enabled = false;
                int i;
                switch (m_subType)
                {
                    case 1:
                        for (i = 0; i <= m_hookHelper.FocusMap.LayerCount - 1; i++)
                        {
                            if (m_hookHelper.ActiveView.FocusMap.get_Layer(i).Visible == false)
                            {
                                enabled = true;
                                break;
                            }
                        }                     
                        break;
                    case 2:
                        for (i = 0; i <= m_hookHelper.FocusMap.LayerCount - 1; i++)
                        {
                            if (m_hookHelper.ActiveView.FocusMap.get_Layer(i).Visible == true)
                            {
                                enabled = true;
                                break;
                            }
                        }
                        break;
                    default:
                        break;
                }  
                return enabled;
            }
        }
    }
}
