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
    /// ͼ����Ϣ
    /// </summary>
    public class MapLayerInfo
    {
        private IFeatureLayer _FeatureLayer = null;
        private IMap _Map = null;
        //ͼ�������
        private string _FeatLyrName = null;
        private bool _Cached = false;
        private string _DataSourceType = null;
        private string _DisplayField = null;
        private double _MaximumScale = 0;
        private double _MinimunScale = 0;
        private bool _ScaleSymbols = false;
        private bool _Selectable = false;
        private bool _Visible = false;
        private bool _ShowTips = false;

        public MapLayerInfo(IFeatureLayer pFeatLyr, IMap pMap)
        {
            this._FeatureLayer = pFeatLyr;
            this._Map = pMap;

            this._FeatLyrName = pFeatLyr.Name;
            this._DataSourceType = pFeatLyr.DataSourceType;
            this._DisplayField = pFeatLyr.DisplayField;
            this._MaximumScale = pFeatLyr.MaximumScale;
            this._MinimunScale = pFeatLyr.MinimumScale;
            this._Cached = pFeatLyr.Cached;
            this._ScaleSymbols = pFeatLyr.ScaleSymbols;
            this._Selectable = pFeatLyr.Selectable;
            this._Visible = pFeatLyr.Visible;
            this._ShowTips = pFeatLyr.ShowTips;
        }

        //ʹ��[CategoryAttribute("ͼ�������Ϣ"),DefaultValueAttribute(true)]����ʹ�ø�������
        //PropertyGrid����ʾʱ�����ڡ�ͼ�������Ϣ������
        [CategoryAttribute("ͼ�������Ϣ"), DefaultValueAttribute(true)]
        public string Name
        {
            get { return this._FeatLyrName; }
            set
            {
                this._FeatLyrName = value;
                this._FeatureLayer.Name = this._FeatLyrName;
            }
        }
        [CategoryAttribute("ͼ�������Ϣ"), DefaultValueAttribute(true)]
        public string DataSourceType
        {
            get { return this._DataSourceType; }
            set
            {
                this._DataSourceType = value;
                this._FeatureLayer.DataSourceType = this._DataSourceType;
            }
        }
        [CategoryAttribute("��ʾ��Ϣ"), DefaultValueAttribute(true)]
        public string DisplayField
        {
            get
            {
                return this._DisplayField;
            }
            set
            {
                this._DisplayField = value;
                this._FeatureLayer.DisplayField = this._DisplayField;
            }
        }
        [CategoryAttribute("��ʾ��Ϣ"), DefaultValueAttribute(true)]
        public double MaximumScale
        {
            get { return this._MaximumScale; }
            set
            {
                this._MaximumScale = value;
                this._FeatureLayer.MaximumScale = this._MaximumScale;
            }
        }
        [CategoryAttribute("��ʾ��Ϣ"), DefaultValueAttribute(true)]
        public double MinimumScale
        {
            get { return this._MinimunScale; }
            set
            {
                this._MinimunScale = value;
                this._FeatureLayer.MinimumScale = this._MinimunScale;
            }
        }
        [CategoryAttribute("����"), DefaultValueAttribute(true)]
        public bool Cached
        {
            get { return this._Cached; }
            set
            {
                this._Cached = value;
                this._FeatureLayer.Cached = this._Cached;
            }
        }
        [CategoryAttribute("����"), DefaultValueAttribute(true)]
        public bool Selectable
        {
            get { return this._Selectable; }
            set
            {
                this._Selectable = value;
                this._FeatureLayer.Selectable = this._Selectable;
            }
        }
        [CategoryAttribute("����"), DefaultValueAttribute(true)]
        public bool ScaleSymbols
        {
            get { return this._ScaleSymbols; }
            set
            {
                this._ScaleSymbols = value;
                this._FeatureLayer.ScaleSymbols = this._ScaleSymbols;
            }
        }
        [CategoryAttribute("����"), DefaultValueAttribute(true)]
        public bool Visible
        {
            get { return this._Visible; }
            set
            {
                this._Visible = value;
                this._FeatureLayer.Visible = this._Visible;
                IActiveView pAV = (IActiveView)this._Map;
                pAV.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
            }
        }
        [CategoryAttribute("����"), DefaultValueAttribute(true)]
        public bool ShowTips
        {
            get { return this._ShowTips; }
            set
            {
                this._ShowTips = value;
                this._FeatureLayer.ShowTips = this._ShowTips;
            }
        }
    }


}
