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
    /// ��ͼ����,��MXD�ļ��п��ܴ��ڶ����ͼ
    /// </summary>
    public class Maps : IMaps, IDisposable
    {
        private IList<IMap> _mapList = null;

        #region class constructor
        public Maps()
        {
            _mapList = new List<IMap>();
        }
        #endregion

        #region IDisposable Members

        /// <summary>
        /// �ͷż��϶���
        /// </summary>
        public void Dispose()
        {
            if (_mapList != null)
            {
                _mapList.Clear();
                _mapList = null;
            }
        }

        #endregion

        #region IMaps Members

        /// <summary>
        /// �Ƴ�ָ���ĵ�ͼ
        /// </summary>
        /// <param name="Index"></param>
        public void RemoveAt(int Index)
        {
            if (Index > _mapList.Count || Index < 0)
                throw new Exception("Maps::RemoveAt:\r\n����Խ��!");

            _mapList.RemoveAt(Index);
        }

        /// <summary>
        /// �������Map
        /// </summary>
        public void Reset()
        {
            _mapList.Clear();
        }

        /// <summary>
        /// ����Map������Map����
        /// </summary>
        public int Count
        {
            get
            {
                return _mapList.Count;
            }
        }

        /// <summary>
        /// ����ָ����Map����
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public IMap get_Item(int Index)
        {
            if (Index > _mapList.Count || Index < 0)
                throw new Exception("Maps::get_Item:\r\n����ֵԽ��!");

            return _mapList[Index];
        }

        /// <summary>
        /// ɾ��һ��ָ����Map����
        /// </summary>
        /// <param name="Map"></param>
        public void Remove(IMap Map)
        {
            _mapList.Remove(Map);
        }

        /// <summary>
        /// ����һ���µ�ͼ��������ӵ�Map������
        /// </summary>
        /// <returns></returns>
        public IMap Create()
        {
            IMap newMap = new MapClass();
            _mapList.Add(newMap);

            return newMap;
        }

        /// <summary>
        /// ��һ��Map��ӵ�������
        /// </summary>
        /// <param name="Map"></param>
        public void Add(IMap Map)
        {
            if (Map == null)
                throw new Exception("Maps::Add:\r\n�µ�ͼû�г�ʼ��!");

            _mapList.Add(Map);
        }

        #endregion
    }

}
