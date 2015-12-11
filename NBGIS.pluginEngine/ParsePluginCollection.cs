using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// ������������еĲ������,����ֱ�����ڲ�ͬ������
    /// </summary>
    public class ParsePluginCollection
    {
        //Command����
        private Dictionary<string, NBGIS.PluginEngine.ICommand> _Commands;
        //Tool����
        private Dictionary<string, NBGIS.PluginEngine.ITool> _Tools;
        //ToolBar����
        private Dictionary<string, NBGIS.PluginEngine.IToolBarDef> _ToolBars;
        //Menu����
        private Dictionary<string, NBGIS.PluginEngine.IMenuDef> _Menus;
        //DockableWindow����
        private Dictionary<string, NBGIS.PluginEngine.IDockableWindowDef> _DockableWindows;
        //�������ͼ���
        private ArrayList _CommandCategory;

        public ParsePluginCollection()
        {
            //��ʼ�����еļ�������
            this._Commands = new Dictionary<string, NBGIS.PluginEngine.ICommand>();
            this._Tools = new Dictionary<string, NBGIS.PluginEngine.ITool>();
            this._ToolBars = new Dictionary<string, NBGIS.PluginEngine.IToolBarDef>();
            this._Menus = new Dictionary<string, NBGIS.PluginEngine.IMenuDef>();
            this._DockableWindows = new Dictionary<string, NBGIS.PluginEngine.IDockableWindowDef>();
            this._CommandCategory = new ArrayList();
        }

        /// <summary>
        /// ���Command����
        /// </summary>
        public Dictionary<string, NBGIS.PluginEngine.ICommand> GetCommands
        {
            get { return this._Commands; }
        }

        /// <summary>
        /// ������ť����
        /// </summary>
        public Dictionary<string, NBGIS.PluginEngine.ITool> GetTools
        {
            get { return this._Tools; }
        }

        /// <summary>
        /// ��ù���������
        /// </summary>
        public Dictionary<string, NBGIS.PluginEngine.IToolBarDef> GetToolBarDefs
        {
            get { return this._ToolBars; }
        }

        /// <summary>
        /// ��ò˵�����
        /// </summary>
        public Dictionary<string, NBGIS.PluginEngine.IMenuDef> GetMenuDefs
        {
            get { return this._Menus; }
        }

        /// <summary>
        /// ��ø������ڼ���
        /// </summary>
        public Dictionary<string, NBGIS.PluginEngine.IDockableWindowDef> GetDockableWindows
        {
            get { return this._DockableWindows; }
        }

        /// <summary>
        /// ������ť�������ϵ���𼯺�
        /// </summary>
        public ArrayList GetCommandCategorys
        {
            get { return this._CommandCategory; }
        }

        /// <summary>
        /// ����������������еĶ���
        /// ����ֱ�װ��ICommand,ITool,IToolBarDef,IMenuDefI��DockableWindowDef 5������
        /// </summary>
        /// <param name="pluginCol">�������</param>
        public void GetPluginArray(PluginCollection pluginCol)
        {
            //�����������
            foreach (NBGIS.PluginEngine.IPlugin plugin in pluginCol)
            {
                //���Command�ӿڲ���ӵ�Command������
                NBGIS.PluginEngine.ICommand cmd = plugin as NBGIS.PluginEngine.ICommand;
                if (cmd != null)
                {
                    this._Commands.Add(cmd.ToString(), cmd);
                    //�ҳ���Command��Category,�������û����ӵ�Category�����
                    if (cmd.Category != null && _CommandCategory.Contains(cmd.Category) == false)
                    {
                        _CommandCategory.Add(cmd.Category);
                    }
                    continue;
                }
                //���ITool�ӿڲ���ӵ�ITool������
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
                //���IToolBarDef�ӿڲ���ӵ�IToolBarDef������
                NBGIS.PluginEngine.IToolBarDef toolbardef = plugin as NBGIS.PluginEngine.IToolBarDef;
                if (toolbardef != null)
                {
                    this._ToolBars.Add(toolbardef.ToString(), toolbardef);
                    continue;
                }
                //���IMenuDef�ӿڲ���ӵ�IMenuDef������
                NBGIS.PluginEngine.IMenuDef menudef = plugin as NBGIS.PluginEngine.IMenuDef;
                if (menudef != null)
                {
                    this._Menus.Add(menudef.ToString(), menudef);
                    continue;
                }
                //���IDockableWindowDef�ӿڲ���ӵ�IDockableWindowDef������
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
