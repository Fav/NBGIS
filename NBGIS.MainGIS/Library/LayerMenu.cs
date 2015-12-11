using System;
using System.Collections.Generic;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.ADF;

namespace NBGIS.MainGIS.Library
{
    public class LayerMenu : ESRI.ArcGIS.ADF.BaseClasses.BaseCommand
    {
        private IHookHelper m_hookHelper = new HookHelperClass();
        private NBGIS.PluginEngine.IApplication m_App = new NBGIS.PluginEngine.Application();
        public override void OnCreate(object hook)
        {
            m_hookHelper.Hook = hook;
        }

        public override void OnClick()
        {
            IMapControlDefault pMapControl = m_hookHelper.Hook as IMapControlDefault;
            IGeoFeatureLayer pGeoFeatLyr = pMapControl.CustomProperty as IGeoFeatureLayer;
            if (pGeoFeatLyr == null) return;

            SymbolForm symbolForm = new SymbolForm();

            IStyleGalleryItem styleGalleryItem = null;
            switch (pGeoFeatLyr.FeatureClass.ShapeType)
            {
                case esriGeometryType.esriGeometryPoint:
                    styleGalleryItem = symbolForm.GetItem(esriSymbologyStyleClass.esriStyleClassMarkerSymbols);
                    break;
                case esriGeometryType.esriGeometryPolyline:
                    styleGalleryItem = symbolForm.GetItem(esriSymbologyStyleClass.esriStyleClassLineSymbols);
                    break;
                case esriGeometryType.esriGeometryPolygon:
                    styleGalleryItem = symbolForm.GetItem(esriSymbologyStyleClass.esriStyleClassFillSymbols);
                    break;
            }

            symbolForm.Dispose();

            m_App.MainPlatfrom.Activate();

            if (styleGalleryItem == null) return;

            ISimpleRenderer simpleRenderer = new SimpleRendererClass();
            simpleRenderer.Symbol = (ISymbol)styleGalleryItem.Item;
            pGeoFeatLyr.Renderer = simpleRenderer as IFeatureRenderer;

            pMapControl.Refresh(esriViewDrawPhase.esriViewGeography, null, null);
            
        }
    }
}
