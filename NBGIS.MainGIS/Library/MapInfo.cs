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
    /// ��ͼ��Ϣ
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
 
        [CategoryAttribute("��ͼ������Ϣ"), DefaultValueAttribute(true),DescriptionAttribute("��ͼ����")]
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                _Map.Name = _Name;
            }
        }

        [CategoryAttribute("��ͼ������Ϣ"), DefaultValueAttribute(true), DescriptionAttribute("��ͼ˵��")]
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
                _Map.Description = _Description;
            }
        }

        [CategoryAttribute("��ͼ����"), DefaultValueAttribute(true),DescriptionAttribute("ѡ���ͼ������")]
        public int SelectionCount
        {
            get { return _SelectionCount; }
        }

        [CategoryAttribute("��ͼ����"), DefaultValueAttribute(true), DescriptionAttribute("ͼ������")]
        public int LayoutCount
        {
            get { return _LayoutCount; }
        }

        [CategoryAttribute("��ͼ����"), DefaultValueAttribute(true), DescriptionAttribute("��ͼ��Χ")]
        public int MapsurroundCount
        {
            get { return _MapsurroundCount; }
        }

        [CategoryAttribute("��ͼ��ʾ"), DefaultValueAttribute(true), DescriptionAttribute("��ͼ��Χ����")]
        public double ReferenceScale
        {
            get { return _ReferenceScale; }
            set
            {
                _ReferenceScale = value;
                _Map.ReferenceScale = _ReferenceScale;
            }
        }

        [CategoryAttribute("��ͼ��ʾ"), DefaultValueAttribute(true)]
        public esriUnits MapUnits 
        {
            get { return _MapUnits; }
            set
            {
                _MapUnits = value;
                _Map.MapUnits = _MapUnits;
            }
        }

        [CategoryAttribute("��ͼ��ʾ"), DefaultValueAttribute(true)]
        public esriUnits DistanceUnits
        {
            get { return _DistanceUnits; }
            set
            {
                _DistanceUnits = value;
                _Map.DistanceUnits = _DistanceUnits;
            }
        }

        [CategoryAttribute("����"), DefaultValueAttribute(true)]
        public bool UseSymbolLevels
        {
            get { return _UseSymbolLevels; }
            set
            {
                _UseSymbolLevels = value;
                _Map.UseSymbolLevels = _UseSymbolLevels;
            }
        }

        [CategoryAttribute("����"), DefaultValueAttribute(true)]
        public bool Expanded
        {
            get { return _Expanded; }
            set
            {
                _Expanded = value;
                _Map.Expanded = _Expanded;
            }
        }

        [CategoryAttribute("����"), DefaultValueAttribute(true)]
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
