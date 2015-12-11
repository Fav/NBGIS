using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using NBGIS.PluginEngine;

namespace NBGIS.DockOverMap
{
    public partial class DockFrom : Form
    {
        #region 属性

        private IApplication hook;
        private IMap pOverMap = null;
        private IGraphicsContainer pGraCon = null;
        private IActiveView pAV = null;
        private IElement pEle;

        public NBGIS.PluginEngine.IApplication Hook
        {
            set
            {
                hook = value;
                if (hook != null)
                {
                    ((ESRI.ArcGIS.Controls.IMapControlEvents2_Event)hook.MapControl).OnExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_OnExtentUpdatedEventHandler(DockForm_OnExtentUpdated);
                    ((ESRI.ArcGIS.Carto.IActiveViewEvents_Event)hook.MapControl.ActiveView).ItemAdded += new IActiveViewEvents_ItemAddedEventHandler(DockFrom_ItemAdded);
                    ((ESRI.ArcGIS.Carto.IActiveViewEvents_Event)hook.MapControl.ActiveView).ContentsCleared += new IActiveViewEvents_ContentsClearedEventHandler(DockForm_ContentsCleared);

                    pAV.Extent = hook.MapControl.ActiveView.FullExtent;
                    IEnvelope pEnv = pAV.Extent;
                    IRectangleElement pRectangleEle = new RectangleElementClass();
                    pEle = (IElement)pRectangleEle;
                    pEle.Geometry = pEnv;
                    IFillShapeElement pFillShapeEle = (IFillShapeElement)pEle;
                    pFillShapeEle.Symbol = CreateFillSymbol();

                    pGraCon.AddElement((IElement)pFillShapeEle, 0);
                    pAV.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
                }
            }
        }
        #endregion

        #region 方法和自定义事件

        /// <summary>
        /// 宿主地图的图层全部删除后,鸟瞰地图也删除所有数据
        /// </summary>
        void DockForm_ContentsCleared()
        {
            pOverMap.ClearLayers();
            pAV.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
        }

        /// <summary>
        /// 宿主地图添加数据以后,鸟瞰地图选择一个图层做为背景层
        /// </summary>
        /// <param name="Item"></param>
        void DockFrom_ItemAdded(object Item)
        {
            if (pOverMap.LayerCount == 0)
            {
                pOverMap.AddLayer(GetBackgroundLayer(hook.MapControl.Map));
                pAV.Extent = hook.MapControl.FullExtent;
                pAV.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                pAV.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

            }
        }

        /// <summary>
        /// 宿主地图添加数据后,鸟瞰地图选择一个图层作为背景层
        /// </summary>
        /// <param name="displayTransfromation"></param>
        /// <param name="sizeChanged"></param>
        /// <param name="newEnvelope"></param>
        void DockForm_OnExtentUpdated(object displayTransfromation, bool sizeChanged, object newEnvelope)
        {
            pAV.Extent = hook.MapControl.ActiveView.FullExtent;
            pEle.Geometry = (IGeometry)newEnvelope;
            pGraCon.UpdateElement(pEle);
            pAV.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        /// <summary>
        /// 鸟瞰地图的红框体移动后,宿主程序地图视图发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void axMapControl_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            IPoint cenpt = new PointClass();
            cenpt.PutCoords(e.mapX, e.mapY);
            IEnvelope pEleEnv = pEle.Geometry.Envelope;
            pEleEnv.CenterAt(cenpt);
            pEle.Geometry = (IGeometry)pEleEnv;

            hook.MapControl.Extent = pEleEnv;
            hook.MapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
            pAV.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        /// <summary>
        /// 产生一个红色范围指示框体
        /// </summary>
        /// <returns></returns>
        private IFillSymbol CreateFillSymbol()
        {
            IRgbColor pColor = new RgbColorClass();
            pColor.Red = 255;
            pColor.Transparency = 0;

            ILineSymbol pOutLine = new SimpleLineSymbolClass();
            pOutLine.Width = 1;
            pOutLine.Color = pColor;
            pColor.Transparency = 0;

            IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            pFillSymbol.Color = pColor;
            pFillSymbol.Outline = pOutLine;
            ISimpleFillSymbol pSimpleFillSymbol = (ISimpleFillSymbol)pFillSymbol;
            pSimpleFillSymbol.Style = esriSimpleFillStyle.esriSFSCross;

            return pFillSymbol;
        }

        /// <summary>
        /// 选择AreaOfInterest范围最大的图层作为鸟瞰地图的背景层
        /// </summary>
        /// <param name="map"></param>
        /// <returns></returns>
        private ILayer GetBackgroundLayer(IMap map)
        {
            ILayer pLyr = map.get_Layer(0);
            ILayer tmpLyr = null;
            for (int i = 1; i < map.LayerCount; i++)
            {
                tmpLyr = map.get_Layer(i);
                if (pLyr.AreaOfInterest.Width < tmpLyr.AreaOfInterest.Width)
                {
                    pLyr = tmpLyr;
                }
            }
            return pLyr;
        }

        #endregion

        public DockFrom()
        {
            InitializeComponent();
            pOverMap = axMapControl.Map;
            pGraCon = (IGraphicsContainer)pOverMap;
            pAV = (IActiveView)pOverMap;
        }


    }
}