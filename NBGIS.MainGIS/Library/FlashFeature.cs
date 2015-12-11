using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.Geodatabase;


namespace NBGIS.MainGIS
{
    /// <summary>
    /// 图层闪烁
    /// </summary>
    public class FlashFeature
    {
        public static void FlashPolygon(IScreenDisplay pDisplay, IGeometry pGeometry, int nTimer, int time)
        {
            ISimpleFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            IRgbColor pRGBColor = new RgbColorClass();
            pRGBColor.Green = 60;
            pRGBColor.Red = 255;
            pRGBColor.Blue = 0;
            pFillSymbol.Outline = null;
            pFillSymbol.Color = pRGBColor;
            ISymbol pSymbol = (ISymbol)pFillSymbol;
            pSymbol.ROP2 = esriRasterOpCode.esriROPNotXOrPen;

            pDisplay.StartDrawing(0, (short)esriScreenCache.esriNoScreenCache);
            pDisplay.SetSymbol(pSymbol);
            for (int i = 0; i < nTimer; i++)
            {
                pDisplay.DrawPolygon(pGeometry);
                System.Threading.Thread.Sleep(time);
            }
            pDisplay.FinishDrawing();
        }

        //闪烁目标
        public FlashFeature(AxMapControl mapControl, IFeature iFeature, IMap iMap)
        {
            IActiveView iActiveView = iMap as IActiveView;
            if (iActiveView != null)
            {
                iActiveView.ScreenDisplay.StartDrawing(0, (short)esriScreenCache.esriNoScreenCache);
                //根据几何类型调用不同的过程
                switch (iFeature.Shape.GeometryType)
                {
                    case esriGeometryType.esriGeometryPolyline:
                        FlashLine(mapControl, iActiveView.ScreenDisplay, iFeature.Shape);
                        break;
                    case esriGeometryType.esriGeometryPolygon:
                        FlashPolygon(mapControl, iActiveView.ScreenDisplay, iFeature.Shape);
                        break;
                    case esriGeometryType.esriGeometryPoint:
                        FlashPoint(mapControl, iActiveView.ScreenDisplay, iFeature.Shape);
                        break;
                    default:
                        break;
                }
                iActiveView.ScreenDisplay.FinishDrawing();
            }
        }

        //闪烁线
        public static void FlashLine(AxMapControl mapControl, IScreenDisplay iScreenDisplay, IGeometry iGeometry)
        {
            ISimpleLineSymbol iLineSymbol;
            ISymbol iSymbol;
            IRgbColor iRgbColor;

            iLineSymbol = new SimpleLineSymbol();
            iLineSymbol.Width = 4;
            iRgbColor = new RgbColor();
            iRgbColor.Red = 255;
            iLineSymbol.Color = iRgbColor;
            iSymbol = (ISymbol)iLineSymbol;
            iSymbol.ROP2 = esriRasterOpCode.esriROPNotXOrPen;
            mapControl.FlashShape(iGeometry, 5, 300, iSymbol);
        }

        //闪烁面
        public static void FlashPolygon(AxMapControl mapControl, IScreenDisplay iScreenDisplay, IGeometry iGeometry)
        {
            ISimpleFillSymbol iFillSymbol;
            ISymbol iSymbol;
            IRgbColor iRgbColor;

            iFillSymbol = new SimpleFillSymbol();
            iFillSymbol.Style = esriSimpleFillStyle.esriSFSSolid;
            iFillSymbol.Outline.Width = 12;

            iRgbColor = new RgbColor();
            iRgbColor.RGB = System.Drawing.Color.FromArgb(100, 180, 180).ToArgb();
            iFillSymbol.Color = iRgbColor;

            iSymbol = (ISymbol)iFillSymbol;
            iSymbol.ROP2 = esriRasterOpCode.esriROPNotXOrPen;
            iScreenDisplay.SetSymbol(iSymbol);
            mapControl.FlashShape(iGeometry, 5, 300, iSymbol);
        }

        //闪烁点
        public static void FlashPoint(AxMapControl mapControl, IScreenDisplay iScreenDisplay, IGeometry iGeometry)
        {
            ISimpleMarkerSymbol iMarkerSymbol;
            ISymbol iSymbol;
            IRgbColor iRgbColor;

            iMarkerSymbol = new SimpleMarkerSymbol();
            iMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSCircle;
            iRgbColor = new RgbColor();
            iRgbColor.RGB = System.Drawing.Color.FromArgb(0, 0, 0).ToArgb();
            iMarkerSymbol.Color = iRgbColor;
            iSymbol = (ISymbol)iMarkerSymbol;
            iSymbol.ROP2 = esriRasterOpCode.esriROPNotXOrPen;
            mapControl.FlashShape(iGeometry, 5, 300, iSymbol);
        }


    }
}
