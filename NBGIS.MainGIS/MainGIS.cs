using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using NBGIS.PluginEngine;

namespace NBGIS.MainGIS
{
    public partial class MainGIS : Form
    {
        #region 公共变量
        //地图控件对象
        private INBMapControl _mapControl = null;
        private INBPageLayoutControl _pageLayoutControl = null;
        //private ESRI.ArcGIS.Controls.ITOCControlDefault _tocControl = null;

        //宿主对象
        private NBGIS.PluginEngine.IApplication _App = null;
        //保存地图数据的DataSet
        private DataSet _DataSet = null;
        //插件对象集合
        //Command集合
        private Dictionary<string, NBGIS.PluginEngine.ICommand> _CommandCol = null;
        //Tool集合
        private Dictionary<string, NBGIS.PluginEngine.ITool> _ToolCol = null;
        //ToolBar集合
        private Dictionary<string, NBGIS.PluginEngine.IToolBarDef> _ToolBarCol = null;
        //Menu集合
        private Dictionary<string, NBGIS.PluginEngine.IMenuDef> _MenuItemCol = null;
        //DockableWindow集合
        private Dictionary<string, NBGIS.PluginEngine.IDockableWindowDef> _DockableWindowCol = null;
        //当前使用的Tool
        //private NBGIS.PluginEngine.ITool _Tool = null;

        //同步类
        //private ControlsSynchronizer m_controlsSynchronizer = null;
        ////TOCControl的esriTOOControlItemMap被右键点击后弹出的快捷菜单
        //private IToolbarMenu _mapMenu = null;

        #endregion

        #region 构造函数

        public MainGIS()
        {
            InitializeComponent();
            //设置图层控件的同步控件
            //axTOCControl.SetBuddyControl(axMapControl);
            //初始化公共变量
            _mapControl = mapControl1;
            _pageLayoutControl = pageLayoutControl1;
            //_tocControl = axTOCControl.Object as ITOCControlDefault;
            _DataSet = new DataSet();
            //初始化主框架
            _App = new NBGIS.PluginEngine.Application();
            _App.StatusBar = this.uiStatusBar;
            _App.MapControl = _mapControl;
            _App.PageLayoutControl = _pageLayoutControl;
            _App.MainPlatfrom = this;
            _App.Caption = this.Text;
            _App.Visible = this.Visible;
            _App.CurrentTool = null;
            _App.MainDataSet = _DataSet;

            ////让MapControl和PageLatoutControl保存同步
            //m_controlsSynchronizer = new ControlsSynchronizer(_mapControl, _pageLayoutControl);
            //m_controlsSynchronizer.BindControls(true);
            //m_controlsSynchronizer.AddFrameWorkControl(axTOCControl.Object);

            //TOCControl的esriTOOControlItemMap被右键点击后弹出的快捷菜单
            //_mapMenu = new ToolbarMenuClass();
            //_mapMenu.AddItem(new MapMenu(), 1, 0, false, esriCommandStyles.esriCommandStyleTextOnly);
            //_mapMenu.AddItem(new MapMenu(), 2, 1, false, esriCommandStyles.esriCommandStyleTextOnly);
            //_mapMenu.SetHook(this._mapControl);

        }

        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainGIS_Load(object sender, EventArgs e)
        {
            //从插件文件夹中获得实现插件接口的对象
            PluginCollection pluginCol = PluginHandle.GetPluginsFromDll();
            //解析这些插件对象,获得不同类型的插件集合
            ParsePluginCollection parsePluhinCol = new ParsePluginCollection();
            parsePluhinCol.GetPluginArray(pluginCol);
            _CommandCol = parsePluhinCol.GetCommands;
            _ToolCol = parsePluhinCol.GetTools;
            _ToolBarCol = parsePluhinCol.GetToolBarDefs;
            _MenuItemCol = parsePluhinCol.GetMenuDefs;
            _DockableWindowCol = parsePluhinCol.GetDockableWindows;

            //获得Command和Tool在UI层上的Category属性
            //foreach (string categoryName in parsePluhinCol.GetCommandCategorys)
            //{
            //    //uiCommandManager.Categories.Add(new UICommandCategory(categoryName));
            //}
            //产生UI对象
            CreateUICommandTool(_CommandCol, _ToolCol);
            CreateToolBars(_ToolBarCol);
            CreateMenus(_MenuItemCol);
            CreateDockableWindow(_DockableWindowCol);
            //保证宿主程序启动后不存在任何默认的处于使用状态的ITool对象
            //_mapControl.CurrentTool = null;
            //_pageLayoutControl.CurrentTool = null;
        }

        #region 方法
        //Dictionary<string, CCmdBtn> m_DicPlugins = new Dictionary<string, CCmdBtn>();
        Dictionary<string, NBGIS.PluginEngine.IPlugin> m_DicPlugins = new Dictionary<string, NBGIS.PluginEngine.IPlugin>();
        /// <summary>
        /// 创建Command控件并添加到CommandManager中
        /// </summary>
        /// <param name="Cmds">ICommand集合</param>
        /// <param name="Tools">ITool集合</param>
        private void CreateUICommandTool(Dictionary<string, NBGIS.PluginEngine.ICommand> Cmds, Dictionary<string, NBGIS.PluginEngine.ITool> Tools)
        {
            //遍历ICommand对象集合
            foreach (KeyValuePair<string, NBGIS.PluginEngine.ICommand> cmd in Cmds)
            {
                m_DicPlugins[cmd.Value.ToString()] = cmd.Value;
            }
            foreach (KeyValuePair<string, NBGIS.PluginEngine.ITool> tool in Tools)
            {
                m_DicPlugins[tool.Value.ToString()] = tool.Value;
            }
        }

        /// <summary>
        /// 创建ToolBar的UI层对象
        /// </summary>
        /// <param name="toolBars"></param>
        private void CreateToolBars(Dictionary<string, NBGIS.PluginEngine.IToolBarDef> toolBars)
        {
            foreach (KeyValuePair<string, NBGIS.PluginEngine.IToolBarDef> toolbar in toolBars)
            {
                NBGIS.PluginEngine.IToolBarDef nbtoolbar = toolbar.Value;
                //产生UICommandBar对象
                ToolStrip UIToolbar = new ToolStrip();
                //设置UICommandBar的属性
                //UIToolbar.CommandManager = this.uiCommandManager;
                UIToolbar.Name = nbtoolbar.Name;
                UIToolbar.Text = nbtoolbar.Caption;
                UIToolbar.Tag = nbtoolbar;
                UIToolbar.AccessibleName = nbtoolbar.ToString();
                //将Command和Tool插入到ToolBar中
                NBGIS.PluginEngine.ItemDef itemDef = new ItemDef();
                for (int i = 0; i < nbtoolbar.ItemCount; i++)
                {
                    nbtoolbar.GetItemInfo(i, itemDef);
                    NBGIS.PluginEngine.ICommand nbcmd = m_DicPlugins[itemDef.ID] as NBGIS.PluginEngine.ICommand; 
                    if (nbcmd != null)
                    {
                        //产生一个UICommand对象
                        ToolStripButton UICommand = new ToolStripButton();
                        //根据ICommand的信息设置UICommand的属性
                        UICommand.ToolTipText = nbcmd.Tooltip;
                        UICommand.Text = nbcmd.Caption;
                        UICommand.Image = nbcmd.Bitmap;
                        UICommand.AccessibleName = nbcmd.ToString();
                        UICommand.Enabled = nbcmd.Enabled;
                        //UICommand的Checked与command的属性一致
                        UICommand.Checked = nbcmd.Checked;
                        //产生UICommand是调用OnCreate方法,将主框架对象传递给插件对象
                        nbcmd.OnCreate(this._App);
                        //使用委托机制处理Command的事件
                        //所有的UICommand对象Click事件均使用this.Command_Click方法处理
                        UICommand.Click += new EventHandler(UICommand_Click);
                        //将生成的UICommand添加到CommandManager中
                        //如果分组,则在该UI对象前加上一个分隔符
                        if (itemDef.Group)
                        {
                            UIToolbar.Items.Add(new ToolStripSeparator());
                        }
                        UIToolbar.Items.Add(UICommand);
                    }

                    //获得一个ITool对象
                    NBGIS.PluginEngine.ITool nbtool = m_DicPlugins[itemDef.ID] as NBGIS.PluginEngine.ITool;
                    if (nbtool != null)
                    {
                        //产生一个ITool对象
                        ToolStripButton UITool = new ToolStripButton();
                        //根据ITool的信息设置UITool的属性
                        UITool.ToolTipText = nbtool.Tooltip;
                        UITool.Text = nbtool.Caption;
                        UITool.Image = nbtool.Bitmap;
                        UITool.AccessibleName = nbtool.ToString();
                        //UITool.Key = nbtool.ToString();
                        UITool.Enabled = nbtool.Enabled;
                        UITool.Checked = nbtool.Checked;
                        //产生UICommand是调用OnCreate方法,将主框架对象传递给插件对象
                        nbtool.OnCreate(this._App);
                        //使用委托机制处理Command的事件
                        //所有的UICommand对象Click事件均使用this.UITool_Click方法处理
                        UITool.Click += new EventHandler(UITool_Click);
                        //将生成的UICommand添加到CommandManager中
                        if (itemDef.Group)
                        {
                            UIToolbar.Items.Add(new ToolStripSeparator());
                        }
                        UIToolbar.Items.Add(UITool);
                    }
                }
                UIToolbar.Dock = DockStyle.Top;
                this.toolStripContainer1.TopToolStripPanel.Controls.Add(UIToolbar);
            }
        }

        /// <summary>
        /// 创建UI层的菜单栏
        /// </summary>
        /// <param name="Menus"></param>
        private void CreateMenus(Dictionary<string, NBGIS.PluginEngine.IMenuDef> Menus)
        {
            //遍历Menu集合中的元素
            foreach (KeyValuePair<string, NBGIS.PluginEngine.IMenuDef> menu in Menus)
            {
                NBGIS.PluginEngine.IMenuDef nbMenu = menu.Value;
                //新建菜单对象
                ToolStripMenuItem UIMenu = new ToolStripMenuItem();
                //设置菜单属性
                UIMenu.Text = nbMenu.Caption;
                UIMenu.Tag = nbMenu;
                UIMenu.AccessibleName = nbMenu.ToString();
                //将Menu添加MainMenu的Commands中
                MainMenu.Items.Add(UIMenu);
                //将Command和Tool插入到menu中
                //遍历每一个菜单item
                NBGIS.PluginEngine.ItemDef itemDef = new NBGIS.PluginEngine.ItemDef();
                for (int i = 0; i < nbMenu.ItemCount; i++)
                {
                    //寻找该菜单对象的信息,如该菜单上的Item数量,是否为Group
                    nbMenu.GetItemInfo(i, itemDef);

                    NBGIS.PluginEngine.ITool nbtool = m_DicPlugins[itemDef.ID] as NBGIS.PluginEngine.ITool;
                    if (nbtool != null)
                    {
                        //产生一个ITool对象
                        ToolStripMenuItem UITool = new ToolStripMenuItem();
                        //根据ITool的信息设置UITool的属性
                        UITool.ToolTipText = nbtool.Tooltip;
                        UITool.Text = nbtool.Caption;
                        UITool.Image = nbtool.Bitmap;
                        UITool.AccessibleName = nbtool.ToString();
                        //UITool.Key = nbtool.ToString();
                        UITool.Enabled = nbtool.Enabled;
                        UITool.Checked = nbtool.Checked;
                        //产生UICommand是调用OnCreate方法,将主框架对象传递给插件对象
                        nbtool.OnCreate(this._App);
                        //使用委托机制处理Command的事件
                        //所有的UICommand对象Click事件均使用this.UITool_Click方法处理
                        UITool.Click += new EventHandler(UITool_Click);
                        //将生成的UICommand添加到CommandManager中
                        if (itemDef.Group)
                        {
                            UIMenu.DropDownItems.Add(new ToolStripSeparator());
                        }
                        UIMenu.DropDownItems.Add(UITool);
                    }
                    NBGIS.PluginEngine.ICommand nbcmd = m_DicPlugins[itemDef.ID] as NBGIS.PluginEngine.ICommand;
                    if (nbcmd != null)
                    {
                        //产生一个UICommand对象
                        ToolStripMenuItem UICommand = new ToolStripMenuItem();
                        //根据ICommand的信息设置UICommand的属性
                        UICommand.ToolTipText = nbcmd.Tooltip;
                        UICommand.Text = nbcmd.Caption;
                        UICommand.Image = nbcmd.Bitmap;
                        UICommand.AccessibleName = nbcmd.ToString();
                        UICommand.Enabled = nbcmd.Enabled;
                        //UICommand的Checked与command的属性一致
                        UICommand.Checked = nbcmd.Checked;
                        //产生UICommand是调用OnCreate方法,将主框架对象传递给插件对象
                        nbcmd.OnCreate(this._App);
                        //使用委托机制处理Command的事件
                        //所有的UICommand对象Click事件均使用this.Command_Click方法处理
                        UICommand.Click += new EventHandler(UICommand_Click);
                        //将生成的UICommand添加到CommandManager中
                        //如果分组,则在该UI对象前加上一个分隔符
                        if (itemDef.Group)
                        {
                            UIMenu.DropDownItems.Add(new ToolStripSeparator());
                        }
                        UIMenu.DropDownItems.Add(UICommand);
                    }
                }
            }
        }

        /// <summary>
        ///  产生Floating Panel的UI层对象(浮动窗体)
        /// </summary>
        /// <param name="dockWindows">浮动窗体集合</param>
        private void CreateDockableWindow(Dictionary<string, NBGIS.PluginEngine.IDockableWindowDef> dockWindows)
        {
            //遍历浮动窗体插件对象的集合
            foreach (KeyValuePair<string, NBGIS.PluginEngine.IDockableWindowDef> dockWindowItem in dockWindows)
            {
            //    //创建一个浮动窗体对象
            //    NBGIS.PluginEngine.IDockableWindowDef item = dockWindowItem.Value;
            //    //产生浮动窗体对象时将主框架对象传递给插件对象
            //    item.OnCreate(_App);
            //    //创建一个浮动Panel
            //    UIPanel panel = new UIPanel();
            //    panel.FloatingLocation = new System.Drawing.Point(120, 180);
            //    panel.Size = new System.Drawing.Size(188, 188);
            //    panel.Name = item.Name;
            //    panel.Text = item.Caption;
            //    panel.DockState = PanelDockState.Floating;//浮动
            //    //对象初始化
            //    ((System.ComponentModel.ISupportInitialize)(panel)).BeginInit();
            //    panel.Id = Guid.NewGuid();
            //    //临时挂起控件的布局逻辑
            //    panel.SuspendLayout();
            //    uiPanelManager.Panels.Add(panel);
            //    UIPanelInnerContainer panelContainer = new UIPanelInnerContainer();
            //    panel.InnerContainer = panelContainer;
            //    try
            //    {
            //        //插件必须保证ChildHWND正确,否则会发生异常
            //        panelContainer.Controls.Add(item.ChildHWND);
            //        panelContainer.Location = new System.Drawing.Point(1, 27);
            //        panelContainer.Name = item.Name + "Container";
            //        panelContainer.Size = new System.Drawing.Size(188, 188);
            //        panelContainer.TabIndex = 0;
            //    }
            //    catch (Exception ex)
            //    {
            //        if (AppLog.log.IsErrorEnabled)
            //        {
            //            AppLog.log.Error("浮动窗插件的子控件没有正确加载");
            //        }
            //    }
            }
        }

        #endregion

        #region 自定义事件
        void UICommand_Click(object sender, EventArgs e)
        {
            ToolStripButton pTempBtn = sender as ToolStripButton;
            ToolStripMenuItem pTempMenuItem = sender as ToolStripMenuItem;
            ToolStripItem pItem = pTempBtn;
            if (null == pTempBtn)
            {
                pItem = pTempMenuItem;
            }
            if (null == pItem)
            { 
                return; 
            }
            string strKey = pItem.AccessibleName;
            //当前Command被按下时,CurrentTool设置为null
            //MapControl和PageLayoutControl的也设置为null
            _App.CurrentTool = null;
            _App.MapControl.CurrentTool = null;
            _App.PageLayoutControl.CurrentTool = null;
            //一切在Command被按下前未完成的Tool操作都可能使Tool的Checked为true
            //此项必须设置为False
            //遍历所有的Command,设置每一个Command的选择状态为False
            ToolStripButton UICmd = null;
            foreach (var item in pItem.GetCurrentParent().Items)
            {
                UICmd = item as ToolStripButton;
                if (null == UICmd)
                    continue;
                UICmd.Checked = false;
            }
            NBGIS.PluginEngine.ICommand cmd = _CommandCol[strKey];
            ////在状态栏显示插件信息
            this.toolStripStatusLabel1.Text = cmd.Message;
            if (null != pTempBtn)
            {
                pTempBtn.Checked = true;
            }
            //((ToolStripButton)sender).Checked = true;
            //设置Map控件的鼠标
            _mapControl.MousePointer = 0;
            cmd.OnClick();
            //((ToolStripButton)sender).Checked = false;
            if (null != pTempBtn)
            {
                pTempBtn.Checked = false;
            }
        }
        void UITool_Click(object sender, EventArgs e)
        {
            //获得当前点击的ITool对象
            ToolStripButton pTempBtn = sender as ToolStripButton;
            ToolStripMenuItem pTempMenuItem = sender as ToolStripMenuItem;
            ToolStripItem pItem = pTempBtn;
            if (null == pTempBtn)
            {
                pItem = pTempMenuItem;
            }
            if (null == pItem)
            {
                return;
            }
            string strKey = pItem.AccessibleName;
            NBGIS.PluginEngine.ITool tool = this._ToolCol[strKey];
            //第一次按下
            if (_App.CurrentTool == null && _mapControl.CurrentTool == null && _pageLayoutControl.CurrentTool == null)
            {
                toolStripStatusLabel1.Text = tool.Message;
                if (null != pTempBtn)
                {
                    pTempBtn.Checked = true;
                }
                _mapControl.MousePointer = tool.Cursor;
                _pageLayoutControl.MousePointer = tool.Cursor;
                tool.OnClick();
                _App.CurrentTool = tool.ToString();
            }
            else
            {
                if (_App.CurrentTool == strKey)
                {
                    //如果是连续二次按下,则使这个Tool完成操作后处于关闭状态
                    if (null != pTempBtn)
                    {
                        pTempBtn.Checked = false;
                    }
                    _mapControl.MousePointer = 0;
                    _pageLayoutControl.MousePointer = 0;
                    _App.CurrentTool = null;
                    _App.MapControl.CurrentTool = null;
                    _App.PageLayoutControl.CurrentTool = null;
                }
                else
                {
                    ////按下一个Tool后没有关闭接着去按另一个Tool,则关闭前一个Tool
                    ////获得前一个Tool
                    if (null != pTempBtn)
                    {
                        ToolStripItem pItem1 = GetCurBtn(pItem.GetCurrentParent(), _App.CurrentTool);
                        if (null == pItem1)
                            return;
                        ToolStripButton lastTool = pItem1 as ToolStripButton;
                        if (lastTool != null)
                        {
                            lastTool.Checked = false;
                        }
                        _App.PageLayoutControl.CurrentTool = null;
                        _App.MapControl.CurrentTool = null;
                    }
                    //设置后一个Tool的状态
                    toolStripStatusLabel1.Text = tool.Message;
                    if (null != pTempBtn)
                    {
                        pTempBtn.Checked = false;
                    }
                    _mapControl.MousePointer = tool.Cursor;
                    _pageLayoutControl.MousePointer = tool.Cursor;
                    tool.OnClick();
                    _App.CurrentTool = tool.ToString();
                }
            }
        }
        private ToolStripItem GetCurBtn(ToolStrip tsTools, string p)
        {
            if (null == tsTools)
            {
                return null;
            }
            for (int i = 0; i < tsTools.Items.Count; i++)
            {
                ToolStripButton item = tsTools.Items[i] as ToolStripButton;
                if (item == null)
                {
                    continue;
                }
                if (!item.AccessibleName.ToUpper().Equals(p.ToUpper()))
                    continue;
                return item;
            }
            return null;
        }
 
        #endregion

        //#region MapControl事件处理
        //private void axMapControl_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        //{
        //    if (_App.CurrentTool != null)
        //    {
        //        _Tool = _ToolCol[_App.CurrentTool];
        //        //左键
        //        if (e.button == 1)
        //        {
        //            _Tool.OnMouseDown(e.button, e.shift, (int)e.mapX, (int)e.mapY);
        //        }
        //        else if (e.button == 2)//右键
        //        {
        //            _Tool.OnContextMenu(e.x, e.y);
        //        }
        //    }
        //    toolStripStatusLabel2.Text = " 当前坐标X：" + e.mapX.ToString() + "  Y：" + e.mapY.ToString();
        //}

        //private void axMapControl_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        //{
        //    if (_App.CurrentTool != null)
        //    {
        //        _Tool = _ToolCol[_App.CurrentTool];
        //        _Tool.OnMouseMove(e.button, e.shift, (int)e.mapX, (int)e.mapY);
        //    }
        //    toolStripStatusLabel2.Text = " 当前坐标X：" + e.mapX.ToString() + "  Y：" + e.mapY.ToString();
        //    toolStripStatusLabel3.Text = "比例尺：" + ((long)(_mapControl.MapScale)).ToString();
        //}

        //private void axMapControl_OnMouseUp(object sender, IMapControlEvents2_OnMouseUpEvent e)
        //{
        //    if (_App.CurrentTool != null)
        //    {
        //        _Tool = _ToolCol[_App.CurrentTool];
        //        _Tool.OnMouseUp(e.button, e.shift, (int)e.mapX, (int)e.mapY);
        //    }
        //    toolStripStatusLabel2.Text = " 当前坐标X：" + e.mapX.ToString() + "  Y：" + e.mapY.ToString();
        //}

        //private void axMapControl_OnKeyDown(object sender, IMapControlEvents2_OnKeyDownEvent e)
        //{
        //    if (_App.CurrentTool != null)
        //    {
        //        _Tool = _ToolCol[_App.CurrentTool];
        //        _Tool.OnKeyDown(e.keyCode, e.shift);
        //    }
        //}

        //private void axMapControl_OnKeyUp(object sender, IMapControlEvents2_OnKeyUpEvent e)
        //{
        //    if (_App.CurrentTool != null)
        //    {
        //        _Tool = _ToolCol[_App.CurrentTool];
        //        _Tool.OnKeyUp(e.keyCode, e.shift);
        //    }
        //}

        //private void axMapControl_OnDoubleClick(object sender, IMapControlEvents2_OnDoubleClickEvent e)
        //{
        //    if (_App.CurrentTool != null)
        //    {
        //        _Tool = _ToolCol[_App.CurrentTool];
        //        _Tool.OnDblClick();
        //    }
        //}

        //private void axMapControl_OnViewRefreshed(object sender, IMapControlEvents2_OnViewRefreshedEvent e)
        //{
        //    if (_App.CurrentTool != null)
        //    {
        //        _Tool = _ToolCol[_App.CurrentTool];
        //        _Tool.Refresh(0);
        //    }
        //}

        //#endregion

        //#region PageLayoutControl事件处理

        //private void axPageLayoutControl_OnMouseDown(object sender, IPageLayoutControlEvents_OnMouseDownEvent e)
        //{
        //    if (_App.CurrentTool != null)
        //    {
        //        _Tool = _ToolCol[_App.CurrentTool];
        //        //左键
        //        if (e.button == 1)
        //        {
        //            _Tool.OnMouseDown(e.button, e.shift, (int)e.pageX, (int)e.pageY);
        //        }
        //        else if (e.button == 2)//右键
        //        {
        //            _Tool.OnContextMenu(e.x, e.y);
        //        }
        //    }
        //}

        //private void axPageLayoutControl_OnMouseMove(object sender, IPageLayoutControlEvents_OnMouseMoveEvent e)
        //{
        //    if (_App.CurrentTool != null)
        //    {
        //        _Tool = _ToolCol[_App.CurrentTool];
        //        _Tool.OnMouseMove(e.button, e.shift, (int)e.pageX, (int)e.pageY);
        //    }
        //}

        //private void axPageLayoutControl_OnMouseUp(object sender, IPageLayoutControlEvents_OnMouseUpEvent e)
        //{
        //    if (_App.CurrentTool != null)
        //    {
        //        _Tool = _ToolCol[_App.CurrentTool];
        //        _Tool.OnMouseUp(e.button, e.shift, (int)e.pageX, (int)e.pageY);
        //    }
        //}

        //private void axPageLayoutControl_OnDoubleClick(object sender, IPageLayoutControlEvents_OnDoubleClickEvent e)
        //{
        //    if (_App.CurrentTool != null)
        //    {
        //        _Tool = _ToolCol[_App.CurrentTool];
        //        _Tool.OnDblClick();
        //    }
        //}

        //private void axPageLayoutControl_OnKeyDown(object sender, IPageLayoutControlEvents_OnKeyDownEvent e)
        //{
        //    if (_App.CurrentTool != null)
        //    {
        //        _Tool = _ToolCol[_App.CurrentTool];
        //        _Tool.OnKeyDown(e.keyCode, e.shift);
        //    }
        //}

        //private void axPageLayoutControl_OnKeyUp(object sender, IPageLayoutControlEvents_OnKeyUpEvent e)
        //{
        //    if (_App.CurrentTool != null)
        //    {
        //        _Tool = _ToolCol[_App.CurrentTool];
        //        _Tool.OnKeyUp(e.keyCode, e.shift);
        //    }
        //}

        //private void axPageLayoutControl_OnViewRefreshed(object sender, IPageLayoutControlEvents_OnViewRefreshedEvent e)
        //{
        //    if (_App.CurrentTool != null)
        //    {
        //        _Tool = _ToolCol[_App.CurrentTool];
        //        _Tool.Refresh(0);
        //    }
        //}

        //#endregion

        //private void axTOCControl_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        //{
        //    esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
        //    IBasicMap map = null;
        //    ILayer layer = null;
        //    object other = null;
        //    object index = null;

        //    _tocControl.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);
        //    //确保有项目被选择
        //    if (item == esriTOCControlItem.esriTOCControlItemMap)
        //        _tocControl.SelectItem(map, null);
        //    else
        //        _tocControl.SelectItem(layer, null);

        //    //选择的是Map
        //    if (item == esriTOCControlItem.esriTOCControlItemMap)
        //    {
        //        //将Map信息传递给propertyGrid控件
        //        MapInfo _mapInfo = new MapInfo(_mapControl.Map);
        //        //propertyGrid.SelectedObject = _mapInfo;
        //        //如果是右键点击,弹出菜单
        //        if (e.button == 2)
        //        {
        //            _mapMenu.PopupMenu(e.x, e.y, _tocControl.hWnd);
        //        }
        //    }
        //    //选择的是 Layer
        //    if (item == esriTOCControlItem.esriTOCControlItemLayer)
        //    {
        //        //将Layer信息传递给PropertyGrid控件
        //        _mapControl.CustomProperty = layer;

        //        IFeatureLayer pFeatLyr = layer as IFeatureLayer;

        //        if (pFeatLyr == null)
        //            return;
        //        MapLayerInfo _mapLyrInfo = new MapLayerInfo(pFeatLyr, _mapControl.Map);
        //        //propertyGrid.SelectedObject = _mapLyrInfo;

        //        //_App.StatusBar.Panels[0].Text = "当前选择图层:" + layer.Name;

        //        //数据表中出现当前图层数据
        //        //获取有效的图层名称 a_b被解析为a.b
        //        string LayerName = LayerDataTable.getValidFeatureClassName(layer.Name);
        //        //判断当前图层是否存在Selection
        //        IFeatureSelection pFeatureSelection = layer as IFeatureSelection;
        //        if (pFeatureSelection.SelectionSet.Count > 0)
        //        {
        //            LayerName += "_Selection";
        //            if (_App.MainDataSet.Tables.Contains(LayerName))
        //            {
        //                _App.MainDataSet.Tables.Remove(LayerName);
        //            }
        //            DataTable dt = LayerDataTable.CreateDataTable(layer, LayerName);
        //            _App.MainDataSet.Tables.Add(dt);
        //        }
        //        else
        //        {
        //            if (!this._App.MainDataSet.Tables.Contains(LayerName))
        //            {
        //                DataTable dt = LayerDataTable.CreateDataTable(layer, LayerName);
        //                _App.MainDataSet.Tables.Add(dt);
        //            }
        //        }
        //        //bindingSource.DataSource = _App.MainDataSet;
        //        //bindingSource.DataMember = LayerName;
        //        //dataGridView.DataSource = bindingSource;
        //        //DataPanel.Text = "数据表[" + LayerName + "]" + "  记录数：" + _DataSet.Tables[LayerName].Rows.Count.ToString();
        //        //dataGridView.Refresh();
        //    }
        //}

        //private void TOCPanel_SelectedPanelChanged(object sender, PanelActionEventArgs e)
        //{
        //    if (e.Panel.Name == "LayerPanel" && _mapControl != null)
        //    {
        //        _tocControl.Update();
        //    }
        //}

        private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.RowIndex != -1)
            //{
            //    IFeature pFeat = null;
            //    try
            //    {
            //        IFeatureClass pFeatCls = (_mapControl.CustomProperty as IFeatureLayer).FeatureClass;
            //        //寻找该行记录对应的要素
            //        //pFeat = pFeatCls.GetFeature(Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value));
            //    }
            //    catch
            //    {
            //        pFeat = null;
            //    }
            //    if (pFeat != null)
            //    {
            //        //要素的定义
            //        if (pFeat.Shape.GeometryType == esriGeometryType.esriGeometryPoint)
            //        {
            //            this.axMapControl.CenterAt((IPoint)pFeat.Shape);
            //        }
            //        else
            //        {
            //            IEnvelope pEnv = pFeat.Shape.Envelope;
            //            pEnv.Expand(5, 5, true);
            //            axMapControl.ActiveView.Extent = pEnv;
            //        }
            //        axMapControl.ActiveView.Refresh();
            //        axMapControl.ActiveView.ScreenDisplay.UpdateWindow();
            //        //用于解决先定位后闪烁的问题
            //        //自定义闪烁功能
            //        switch (pFeat.Shape.GeometryType)
            //        {
            //            case esriGeometryType.esriGeometryPoint:
            //                FlashFeature.FlashPoint(axMapControl, axMapControl.ActiveView.ScreenDisplay, pFeat.Shape);
            //                break;
            //            case esriGeometryType.esriGeometryPolyline:
            //                FlashFeature.FlashLine(axMapControl, axMapControl.ActiveView.ScreenDisplay, pFeat.Shape);
            //                break;
            //            case esriGeometryType.esriGeometryPolygon:
            //                FlashFeature.FlashPolygon(axMapControl, axMapControl.ActiveView.ScreenDisplay, pFeat.Shape);
            //                break;
            //            default:
            //                break;
            //        }

            //        axMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            //        axMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
            //    }
            //}
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (m_controlsSynchronizer == null)
            //{
            //    return;
            //}
            //if (tabControl1.SelectedTab.Name.ToUpper().Equals("MAPTAB"))
            //{
            //    m_controlsSynchronizer.ActivateMap();
            //}
            //else if (tabControl1.SelectedTab.Name.ToUpper().Equals("PAGETAB"))
            //{
            //    m_controlsSynchronizer.ActivatePageLayout();
            //}
        }

    }
}