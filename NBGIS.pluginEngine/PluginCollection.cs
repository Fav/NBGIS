using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// 插件容器
    /// </summary>
    public class PluginCollection : CollectionBase
    {
        #region 构造函数

        public PluginCollection() { }

        public PluginCollection(PluginCollection value)
        {
            this.AddRange(value);
        }

        public PluginCollection(IPlugin[] value)
        {
            this.AddRange(value);
        }

        #endregion

        /// <summary>
        /// 插件基接口的索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public IPlugin this[int index]
        {
            get { return (IPlugin)(this.List[index]); }
        }

        /// <summary>
        /// 添加插件到插件容器
        /// </summary>
        /// <param name="value">插件</param>
        /// <returns></returns>
        public int Add(IPlugin value)
        {
            return this.List.Add(value);
        }

        /// <summary>
        /// 根据插件值确定该项在集合中的索引
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(IPlugin value)
        {
            return this.List.IndexOf(value);
        }

        /// <summary>
        /// 查看容器中是否存在该插件
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(IPlugin value)
        {
            return this.List.Contains(value);
        }

        /// <summary>
        /// 复制索引所在的项到集合中去
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        public void CopyTo(IPlugin[] array, int index)
        {
            this.List.CopyTo(array, index);
        }

        /// <summary>
        /// 把插件数组转换程序插件集合
        /// </summary>
        /// <returns></returns>
        public IPlugin[] ToArray()
        {
            IPlugin[] array = new IPlugin[this.Count];
            this.CopyTo(array, 0);
            return array;
        }

        /// <summary>
        /// 插入一个插件对象到插件容器
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="value">插件对象</param>
        public void Insert(int index, IPlugin value)
        {
            this.List.Insert(index, value);
        }

        /// <summary>
        ///删除一个插件对象
        /// </summary>
        /// <param name="value">插件对象</param>
        public void Remove(IPlugin value)
        {
            this.List.Remove(value);
        }

        /// <summary>
        /// 获得当前插件集合的迭代器
        /// </summary>
        /// <returns></returns>
        public new PluginCollectionEnumerator GetEnumerator()
        {
            return new PluginCollectionEnumerator(this);
        }

        /// <summary>
        /// 添加插件对象数组到当前插件集合
        /// </summary>
        /// <param name="value"></param>
        private void AddRange(IPlugin[] value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                this.Add(value[i]);
            }
        }
        /// <summary>
        /// 添加插件集合到当前的集合
        /// </summary>
        /// <param name="value"></param>
        private void AddRange(PluginCollection value)
        {
            for (int i = 0; i < value.Capacity; i++)
            {
                this.Add((IPlugin)value.List[i]);
            }
        }
    }
}
