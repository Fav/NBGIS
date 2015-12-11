using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// �������
    /// </summary>
    public class PluginCollection : CollectionBase
    {
        #region ���캯��

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
        /// ������ӿڵ�������
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public IPlugin this[int index]
        {
            get { return (IPlugin)(this.List[index]); }
        }

        /// <summary>
        /// ��Ӳ�����������
        /// </summary>
        /// <param name="value">���</param>
        /// <returns></returns>
        public int Add(IPlugin value)
        {
            return this.List.Add(value);
        }

        /// <summary>
        /// ���ݲ��ֵȷ�������ڼ����е�����
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(IPlugin value)
        {
            return this.List.IndexOf(value);
        }

        /// <summary>
        /// �鿴�������Ƿ���ڸò��
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(IPlugin value)
        {
            return this.List.Contains(value);
        }

        /// <summary>
        /// �����������ڵ��������ȥ
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        public void CopyTo(IPlugin[] array, int index)
        {
            this.List.CopyTo(array, index);
        }

        /// <summary>
        /// �Ѳ������ת������������
        /// </summary>
        /// <returns></returns>
        public IPlugin[] ToArray()
        {
            IPlugin[] array = new IPlugin[this.Count];
            this.CopyTo(array, 0);
            return array;
        }

        /// <summary>
        /// ����һ��������󵽲������
        /// </summary>
        /// <param name="index">����</param>
        /// <param name="value">�������</param>
        public void Insert(int index, IPlugin value)
        {
            this.List.Insert(index, value);
        }

        /// <summary>
        ///ɾ��һ���������
        /// </summary>
        /// <param name="value">�������</param>
        public void Remove(IPlugin value)
        {
            this.List.Remove(value);
        }

        /// <summary>
        /// ��õ�ǰ������ϵĵ�����
        /// </summary>
        /// <returns></returns>
        public new PluginCollectionEnumerator GetEnumerator()
        {
            return new PluginCollectionEnumerator(this);
        }

        /// <summary>
        /// ��Ӳ���������鵽��ǰ�������
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
        /// ��Ӳ�����ϵ���ǰ�ļ���
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
