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
    /// 地图集合,在MXD文件有可能存在多个地图
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
        /// 释放集合对象
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
        /// 移除指定的地图
        /// </summary>
        /// <param name="Index"></param>
        public void RemoveAt(int Index)
        {
            if (Index > _mapList.Count || Index < 0)
                throw new Exception("Maps::RemoveAt:\r\n索引越界!");

            _mapList.RemoveAt(Index);
        }

        /// <summary>
        /// 清除所有Map
        /// </summary>
        public void Reset()
        {
            _mapList.Clear();
        }

        /// <summary>
        /// 返回Map集合中Map数量
        /// </summary>
        public int Count
        {
            get
            {
                return _mapList.Count;
            }
        }

        /// <summary>
        /// 返回指定的Map对象
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public IMap get_Item(int Index)
        {
            if (Index > _mapList.Count || Index < 0)
                throw new Exception("Maps::get_Item:\r\n索引值越界!");

            return _mapList[Index];
        }

        /// <summary>
        /// 删除一个指定的Map对象
        /// </summary>
        /// <param name="Map"></param>
        public void Remove(IMap Map)
        {
            _mapList.Remove(Map);
        }

        /// <summary>
        /// 产生一个新地图并将其添加到Map集合中
        /// </summary>
        /// <returns></returns>
        public IMap Create()
        {
            IMap newMap = new MapClass();
            _mapList.Add(newMap);

            return newMap;
        }

        /// <summary>
        /// 将一个Map添加到集合中
        /// </summary>
        /// <param name="Map"></param>
        public void Add(IMap Map)
        {
            if (Map == null)
                throw new Exception("Maps::Add:\r\n新地图没有初始化!");

            _mapList.Add(Map);
        }

        #endregion
    }

}
