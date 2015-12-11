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
    /// 根据反射机制产生插件对象并将其装入插件容器
    /// </summary>
    public class PluginHandle
    {
        /// <summary>
        /// 定义插件文件夹全路径
        /// </summary>
        private static readonly string pluginFolder = System.Windows.Forms.Application.StartupPath + "\\plugin";

        /// <summary>
        /// 从DLL中获得插件对象并加入到插件容器
        /// </summary>
        /// <returns></returns>
        public static PluginCollection GetPluginsFromDll()
        {
            //存储插件的容器
            PluginCollection _PluginCol = new PluginCollection();
            //判断是否存在该文件夹,如果不存在则自动创建一个,避免异常
            if (!Directory.Exists(pluginFolder))
            {
                Directory.CreateDirectory(pluginFolder);
                if (AppLog.log.IsDebugEnabled)
                {
                    AppLog.log.Debug("plugin文件夹不存在,系统自带创建一个!");
                }
            }
            //获得插件文件夹中的每一个dll文件
            string[] _files = Directory.GetFiles(pluginFolder, "*.dll");
            foreach (string _file in _files)
            {
                //根据程序集文件名加载程序集
                Assembly _assembly = Assembly.LoadFrom(_file);
                if (_assembly != null)
                {
                    Type[] _types = null;
                    try
                    {
                        //获得程序集中定义的类型
                        _types = _assembly.GetTypes();
                    }
                    catch
                    {
                        if (AppLog.log.IsErrorEnabled)
                        {
                            AppLog.log.Error("反射类型加载异常!");
                        }
                    }
                    finally
                    {
                        foreach (Type _type in _types)
                        {
                            //获得一个类型所有实现的接口
                            Type[] _interfaces = _type.GetInterfaces();
                            //遍历接口类型
                            foreach (Type theInterface in _interfaces)
                            {
                                //如果满足某种类型,则添加到插件集合对象中
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
        /// 获得插件对象
        /// </summary>
        /// <param name="pluginCol">当前插件集合</param>
        /// <param name="_type">插件类型</param>
        private static void getPluginObject(PluginCollection pluginCol, Type _type)
        {
            IPlugin plugin = null;
            try
            {
                //object aa = Activator.CreateInstance(_type);
                //创建一个插件对象实例
                plugin = Activator.CreateInstance(_type) as NBGIS.PluginEngine.IPlugin;
            }
            catch
            {
                if (AppLog.log.IsErrorEnabled)
                {
                    AppLog.log.Error(_type.FullName + "反射生成对象时发生异常");
                }
            }
            finally
            {
                if (plugin != null)
                {
                    //判断该插件是否已经存在插件集合中了,如果不是则加入该对象
                    if (!pluginCol.Contains(plugin))
                    {
                        pluginCol.Add(plugin);
                    }
                }
            }
        }
    }
}
