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
    /// ����ͼ����Ϣת����DataTable
    /// </summary>
    public class LayerDataTable
    {
        /// <summary>
        /// ����ͼ����Ϣת����DataTable
        /// </summary>
        /// <param name="pLayer"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private static DataTable CreateDataTableByLayer(ILayer pLayer, string tableName)
        {
            //����һ��DataTable��
            DataTable pDataTable = new DataTable(tableName);
            ITable pTable = pLayer as ITable;
            IField pField = null;
            DataColumn pDataColumn;
            //����ÿ���ֶε����Խ���DataColumn����
            for (int i = 0; i < pTable.Fields.FieldCount; i++)
            {
                pField = pTable.Fields.get_Field(i);
                //�½�һ��DataColumn������������
                pDataColumn = new DataColumn(pField.Name);
                if (pField.Name == pTable.OIDFieldName)
                {
                    pDataColumn.Unique = true;//�ֶ�ֵ�Ƿ�Ψһ
                }
                //�ֶ�ֵ�Ƿ�����Ϊ��
                pDataColumn.AllowDBNull = pField.IsNullable;
                //�ֶα���
                pDataColumn.Caption = pField.AliasName;
                //�ֶ���������
                pDataColumn.DataType = System.Type.GetType(ParseFieldType(pField.Type));
                //�ֶ�Ĭ��ֵ
                pDataColumn.DefaultValue = pField.DefaultValue;
                //���ֶ�ΪString�����������ֶγ���
                if (pField.VarType == 8)
                {
                    pDataColumn.MaxLength = pField.Length;
                }
                //�ֶ���ӵ�����
                pDataTable.Columns.Add(pDataColumn);
                pField = null;
                pDataColumn = null;
            }
            return pDataTable;
        }

        /// <summary>
        /// GeoDataBase�ֶ����ͺ�.Net��������ת��
        /// </summary>
        /// <param name="fieldType">�ֶ�����</param>
        /// <returns></returns>
        public static string ParseFieldType(esriFieldType fieldType)
        {
            switch (fieldType)
            {
                case esriFieldType.esriFieldTypeBlob:
                    return "System.String";
                case esriFieldType.esriFieldTypeDate:
                    return "System.DateTime";
                case esriFieldType.esriFieldTypeDouble:
                    return "System.Double";
                case esriFieldType.esriFieldTypeGeometry:
                    return "System.String";
                case esriFieldType.esriFieldTypeGlobalID:
                    return "System.String";
                case esriFieldType.esriFieldTypeGUID:
                    return "System.String";
                case esriFieldType.esriFieldTypeInteger:
                    return "System.Int32";
                case esriFieldType.esriFieldTypeOID:
                    return "System.String";
                case esriFieldType.esriFieldTypeRaster:
                    return "System.String";
                case esriFieldType.esriFieldTypeSingle:
                    return "System.Single";
                case esriFieldType.esriFieldTypeSmallInteger:
                    return "System.Int32";
                case esriFieldType.esriFieldTypeString:
                    return "System.String";
                default:
                    return "System.String";
            }
        }

        /// <summary>
        /// �滻���ݱ����ĵ�
        /// </summary>
        /// <param name="FCname"></param>
        /// <returns></returns>
        public static string getValidFeatureClassName(string FCname)
        {
            int dot = FCname.IndexOf(".");
            if (dot != -1)
            {
                return FCname.Replace(".", "_");
            }
            return FCname;
        }

        /// <summary>
        /// ���Ҫ��ͼ���Shape����
        /// </summary>
        /// <param name="pLayer">ͼ��</param>
        /// <returns></returns>
        public static string getShapeType(ILayer pLayer)
        {
            IFeatureLayer pFeatLyr = (IFeatureLayer)pLayer;
            switch (pFeatLyr.FeatureClass.ShapeType)
            {
                case esriGeometryType.esriGeometryPoint:
                    return "Point";
                case esriGeometryType.esriGeometryPolyline:
                    return "Polyline";
                case esriGeometryType.esriGeometryPolygon:
                    return "Polygon";
                default:
                    return "";
            }
        }

        public static DataTable CreateDataTable(ILayer pLayer, string tableName)
        {
            DataTable pDataTable = CreateDataTableByLayer(pLayer, tableName);
            string shapeType = getShapeType(pLayer);

            DataRow pDataRow = null;

            ITable pTable = pLayer as ITable;
            ICursor pCursor = pTable.Search(null, false);
            IRow pRow = pCursor.NextRow();
            int n = 0;
            while (pRow != null)
            {
                pDataRow = pDataTable.NewRow();
                for (int i = 0; i < pRow.Fields.FieldCount; i++)
                {
                    if (pRow.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeGeometry)
                    {
                        pDataRow[i] = shapeType;
                    }
                    else if (pRow.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeBlob)
                    {
                        pDataRow[i] = "Element";
                    }
                    else
                    {
                        pDataRow[i] = pRow.get_Value(i);
                    }
                }
                pDataTable.Rows.Add(pDataRow);
                pDataRow = null;

                n++;
                if (n == 2000)//һ��ֻ��ѡ��һ����¼
                {
                    pRow = null;
                }
                else
                {
                    pRow = pCursor.NextRow();
                }
            }
            return pDataTable;
        }
    }
}
