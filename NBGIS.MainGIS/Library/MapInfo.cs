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
    /// 地图信息
    /// </summary>
    public class MapInfo
    {
        private string _Name;
        private string _Description;
        private int _SelectionCount;
        private int _LayoutCount;
        private int _MapsurroundCount;
        private bool _UseSymbolLevels;
        private bool _Expanded;
        private bool _IsFramed;
        private double _ReferenceScale;
        private esriUnits _MapUnits;
        private esriUnits _DistanceUnits;
        private IMap _Map;

        public MapInfo(IMap pMap)
        {
            _Map = pMap;
            _Description = pMap.Description;
            _DistanceUnits = pMap.DistanceUnits;
            _Expanded = pMap.Expanded;
            _IsFramed = pMap.IsFramed;
            _LayoutCount = pMap.LayerCount;
            _MapsurroundCount = pMap.MapSurroundCount;
            _MapUnits = pMap.MapUnits;
            _Name = pMap.Name;
            _ReferenceScale = pMap.ReferenceScale;
            _SelectionCount = pMap.SelectionCount;
            _UseSymbolLevels = pMap.UseSymbolLevels;
        }
 
        [CategoryAttribute("地图基本信息"), DefaultValueAttribute(true),DescriptionAttribute("地图名称")]
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                _Map.Name = _Name;
            }
        }

        [CategoryAttribute("地图基本信息"), DefaultValueAttribute(true), DescriptionAttribute("地图说明")]
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
                _Map.Description = _Description;
            }
        }

        [CategoryAttribute("地图内容"), DefaultValueAttribute(true),DescriptionAttribute("选择的图层数量")]
        public int SelectionCount
        {
            get { return _SelectionCount; }
        }

        [CategoryAttribute("地图内容"), DefaultValueAttribute(true), DescriptionAttribute("图层数量")]
        public int LayoutCount
        {
            get { return _LayoutCount; }
        }

        [CategoryAttribute("地图内容"), DefaultValueAttribute(true), DescriptionAttribute("地图范围")]
        public int MapsurroundCount
        {
            get { return _MapsurroundCount; }
        }

        [CategoryAttribute("地图显示"), DefaultValueAttribute(true), DescriptionAttribute("地图范围精度")]
        public double ReferenceScale
        {
            get { return _ReferenceScale; }
            set
            {
                _ReferenceScale = value;
                _Map.ReferenceScale = _ReferenceScale;
            }
        }

        [CategoryAttribute("地图显示"), DefaultValueAttribute(true)]
        public esriUnits MapUnits 
        {
            get { return _MapUnits; }
            set
            {
                _MapUnits = value;
                _Map.MapUnits = _MapUnits;
            }
        }

        [CategoryAttribute("地图显示"), DefaultValueAttribute(true)]
        public esriUnits DistanceUnits
        {
            get { return _DistanceUnits; }
            set
            {
                _DistanceUnits = value;
                _Map.DistanceUnits = _DistanceUnits;
            }
        }

        [CategoryAttribute("杂项"), DefaultValueAttribute(true)]
        public bool UseSymbolLevels
        {
            get { return _UseSymbolLevels; }
            set
            {
                _UseSymbolLevels = value;
                _Map.UseSymbolLevels = _UseSymbolLevels;
            }
        }

        [CategoryAttribute("杂项"), DefaultValueAttribute(true)]
        public bool Expanded
        {
            get { return _Expanded; }
            set
            {
                _Expanded = value;
                _Map.Expanded = _Expanded;
            }
        }

        [CategoryAttribute("杂项"), DefaultValueAttribute(true)]
        public bool IsFramed
        {
            get { return _IsFramed; }
            set
            {
                _IsFramed = value;
                _Map.IsFramed = _IsFramed;
            }
        }
    }
}
