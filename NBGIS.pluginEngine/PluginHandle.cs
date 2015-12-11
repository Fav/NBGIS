using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// ���ݷ�����Ʋ���������󲢽���װ��������
    /// </summary>
    public class PluginHandle
    {
        /// <summary>
        /// �������ļ���ȫ·��
        /// </summary>
        private static readonly string pluginFolder = System.Windows.Forms.Application.StartupPath + "\\plugin";

        /// <summary>
        /// ��DLL�л�ò�����󲢼��뵽�������
        /// </summary>
        /// <returns></returns>
        public static PluginCollection GetPluginsFromDll()
        {
            //�洢���������
            PluginCollection _PluginCol = new PluginCollection();
            //�ж��Ƿ���ڸ��ļ���,������������Զ�����һ��,�����쳣
            if (!Directory.Exists(pluginFolder))
            {
                Directory.CreateDirectory(pluginFolder);
                if (AppLog.log.IsDebugEnabled)
                {
                    AppLog.log.Debug("plugin�ļ��в�����,ϵͳ�Դ�����һ��!");
                }
            }
            //��ò���ļ����е�ÿһ��dll�ļ�
            string[] _files = Directory.GetFiles(pluginFolder, "*.dll");
            foreach (string _file in _files)
            {
                //���ݳ����ļ������س���
                Assembly _assembly = Assembly.LoadFrom(_file);
                if (_assembly != null)
                {
                    Type[] _types = null;
                    try
                    {
                        //��ó����ж��������
                        _types = _assembly.GetTypes();
                    }
                    catch
                    {
                        if (AppLog.log.IsErrorEnabled)
                        {
                            AppLog.log.Error("�������ͼ����쳣!");
                        }
                    }
                    finally
                    {
                        foreach (Type _type in _types)
                        {
                            //���һ����������ʵ�ֵĽӿ�
                            Type[] _interfaces = _type.GetInterfaces();
                            //�����ӿ�����
                            foreach (Type theInterface in _interfaces)
                            {
                                //�������ĳ������,����ӵ�������϶�����
                                switch (theInterface.FullName)
                                {
                                    //NBGIS.PluginEngine.
                                    case "NBGIS.PluginEngine.ICommand":
                                    case "NBGIS.PluginEngine.ITool":
                                    case "NBGIS.PluginEngine.IMenuDef":
                                    case "NBGIS.PluginEngine.IToolBarDef":
                                    case "NBGIS.PluginEngine.IDockableWindowDef":
                                        getPluginObject(_PluginCol, _type);
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }

                }
            }
            return _PluginCol;
        }

        /// <summary>
        /// ��ò������
        /// </summary>
        /// <param name="pluginCol">��ǰ�������</param>
        /// <param name="_type">�������</param>
        private static void getPluginObject(PluginCollection pluginCol, Type _type)
        {
            IPlugin plugin = null;
            try
            {
                //object aa = Activator.CreateInstance(_type);
                //����һ���������ʵ��
                plugin = Activator.CreateInstance(_type) as NBGIS.PluginEngine.IPlugin;
            }
            catch
            {
                if (AppLog.log.IsErrorEnabled)
                {
                    AppLog.log.Error(_type.FullName + "�������ɶ���ʱ�����쳣");
                }
            }
            finally
            {
                if (plugin != null)
                {
                    //�жϸò���Ƿ��Ѿ����ڲ����������,������������ö���
                    if (!pluginCol.Contains(plugin))
                    {
                        pluginCol.Add(plugin);
                    }
                }
            }
        }
    }
}
