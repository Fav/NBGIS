using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// 解析插件容器中的插件对象,将其分别放置在不同集合中
    /// </summary>
    public class ParsePluginCollection
    {
        //Command集合
        private Dictionary<string, NBGIS.PluginEngine.ICommand> _Commands;
        //Tool集合
        private Dictionary<string, NBGIS.PluginEngine.ITool> _Tools;
        //ToolBar集合
        private Dictionary<string, NBGIS.PluginEngine.IToolBarDef> _ToolBars;
        //Menu集合
        private Dictionary<string, NBGIS.PluginEngine.IMenuDef> _Menus;
        //DockableWindow集合
        private Dictionary<string, NBGIS.PluginEngine.IDockableWindowDef> _DockableWindows;
        //命令类型集合
        private ArrayList _CommandCategory;

        public ParsePluginCollection()
        {
            //初始化所有的集合容器
            this._Commands = new Dictionary<string, NBGIS.PluginEngine.ICommand>();
            this._Tools = new Dictionary<string, NBGIS.PluginEngine.ITool>();
            this._ToolBars = new Dictionary<string, NBGIS.PluginEngine.IToolBarDef>();
            this._Menus = new Dictionary<string, NBGIS.PluginEngine.IMenuDef>();
            this._DockableWindows = new Dictionary<string, NBGIS.PluginEngine.IDockableWindowDef>();
            this._CommandCategory = new ArrayList();
        }

        /// <summary>
        /// 获得Command集合
        /// </summary>
        public Dictionary<string, NBGIS.PluginEngine.ICommand> GetCommands
        {
            get { return this._Commands; }
        }

        /// <summary>
        /// 获得命令按钮集合
        /// </summary>
        public Dictionary<string, NBGIS.PluginEngine.ITool> GetTools
        {
            get { return this._Tools; }
        }

        /// <summary>
        /// 获得工具栏集合
        /// </summary>
        public Dictionary<string, NBGIS.PluginEngine.IToolBarDef> GetToolBarDefs
        {
            get { return this._ToolBars; }
        }

        /// <summary>
        /// 获得菜单集合
        /// </summary>
        public Dictionary<string, NBGIS.PluginEngine.IMenuDef> GetMenuDefs
        {
            get { return this._Menus; }
        }

        /// <summary>
        /// 获得浮动窗口集合
        /// </summary>
        public Dictionary<string, NBGIS.PluginEngine.IDockableWindowDef> GetDockableWindows
        {
            get { return this._DockableWindows; }
        }

        /// <summary>
        /// 获得命令按钮所属集合的类别集合
        /// </summary>
        public ArrayList GetCommandCategorys
        {
            get { return this._CommandCategory; }
        }

        /// <summary>
        /// 解析插件集合中所有的对象
        /// 将其分别装入ICommand,ITool,IToolBarDef,IMenuDefI和DockableWindowDef 5个集合
        /// </summary>
        /// <param name="pluginCol">插件集合</param>
        public void GetPluginArray(PluginCollection pluginCol)
        {
            //遍历插件集合
            foreach (NBGIS.PluginEngine.IPlugin plugin in pluginCol)
            {
                //获得Command接口并添加到Command集合中
                NBGIS.PluginEngine.ICommand cmd = plugin as NBGIS.PluginEngine.ICommand;
                if (cmd != null)
                {
                    this._Commands.Add(cmd.ToString(), cmd);
                    //找出该Command的Category,如果它还没有添加到Category则添加
                    if (cmd.Category != null && _CommandCategory.Contains(cmd.Category) == false)
                    {
                        _CommandCategory.Add(cmd.Category);
                    }
                    continue;
                }
                //获得ITool接口并添加到ITool集合中
                NBGIS.PluginEngine.ITool tool = plugin as NBGIS.PluginEngine.ITool;
                if (tool != null)
                {
                    this._Tools.Add(tool.ToString(), tool);
                    if (tool.Category != null && _CommandCategory.Contains(tool.Category) == false)
                    {
                        _CommandCategory.Add(tool.Category);
                    }
                    continue;
                }
                //获得IToolBarDef接口并添加到IToolBarDef集合中
                NBGIS.PluginEngine.IToolBarDef toolbardef = plugin as NBGIS.PluginEngine.IToolBarDef;
                if (toolbardef != null)
                {
                    this._ToolBars.Add(toolbardef.ToString(), toolbardef);
                    continue;
                }
                //获得IMenuDef接口并添加到IMenuDef集合中
                NBGIS.PluginEngine.IMenuDef menudef = plugin as NBGIS.PluginEngine.IMenuDef;
                if (menudef != null)
                {
                    this._Menus.Add(menudef.ToString(), menudef);
                    continue;
                }
                //获得IDockableWindowDef接口并添加到IDockableWindowDef集合中
                NBGIS.PluginEngine.IDockableWindowDef dockablewindowdef = plugin as NBGIS.PluginEngine.IDockableWindowDef;
                if (dockablewindowdef != null)
                {
                    this._DockableWindows.Add(dockablewindowdef.ToString(), dockablewindowdef);
                    continue;
                }
            }
        }
    }
}
