using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// �������������
    /// </summary>
    public class PluginCollectionEnumerator : IEnumerator
    {
        /// <summary>
        /// ö�ٽӿ�
        /// </summary>
        private IEnumerable _temp;
        /// <summary>
        /// �Ƿ��͵����ӿ�
        /// </summary>
        private IEnumerator _enumerator;
        public PluginCollectionEnumerator()
        { }
        /// <summary>
        /// ����������������캯��
        /// </summary>
        /// <param name="mappings">�������</param>
        public PluginCollectionEnumerator(PluginCollection mappings)
        {
            _temp = (IEnumerable)mappings;
            _enumerator = _temp.GetEnumerator();
        }
        #region IEnumerator ��Ա
        /// <summary>
        /// ��ü����еĵ�ǰԪ��
        /// </summary>
        public object Current
        {
            get { return _enumerator.Current; }
        }
        /// <summary>
        /// ��ȡ��һ��Ԫ��
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            return _enumerator.MoveNext();
        }
        /// <summary>
        /// �������ü��϶���
        /// </summary>
        public void Reset()
        {
            _enumerator.Reset();
        }

        #endregion
    }
}
