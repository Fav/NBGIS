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
        #region ��������
        //��ͼ�ؼ�����
        private INBMapControl _mapControl = null;
        private INBPageLayoutControl _pageLayoutControl = null;
        //private ESRI.ArcGIS.Controls.ITOCControlDefault _tocControl = null;

        //��������
        private NBGIS.PluginEngine.IApplication _App = null;
        //�����ͼ���ݵ�DataSet
        private DataSet _DataSet = null;
        //������󼯺�
        //Command����
        private Dictionary<string, NBGIS.PluginEngine.ICommand> _CommandCol = null;
        //Tool����
        private Dictionary<string, NBGIS.PluginEngine.ITool> _ToolCol = null;
        //ToolBar����
        private Dictionary<string, NBGIS.PluginEngine.IToolBarDef> _ToolBarCol = null;
        //Menu����
        private Dictionary<string, NBGIS.PluginEngine.IMenuDef> _MenuItemCol = null;
        //DockableWindow����
        private Dictionary<string, NBGIS.PluginEngine.IDockableWindowDef> _DockableWindowCol = null;
        //��ǰʹ�õ�Tool
        //private NBGIS.PluginEngine.ITool _Tool = null;

        //ͬ����
        //private ControlsSynchronizer m_controlsSynchronizer = null;
        ////TOCControl��esriTOOControlItemMap���Ҽ�����󵯳��Ŀ�ݲ˵�
        //private IToolbarMenu _mapMenu = null;

        #endregion

        #region ���캯��

        public MainGIS()
        {
            InitializeComponent();
            //����ͼ��ؼ���ͬ���ؼ�
            //axTOCControl.SetBuddyControl(axMapControl);
            //��ʼ����������
            _mapControl = mapControl1;
            _pageLayoutControl = pageLayoutControl1;
            //_tocControl = axTOCControl.Object as ITOCControlDefault;
            _DataSet = new DataSet();
            //��ʼ�������
            _App = new NBGIS.PluginEngine.Application();
            _App.StatusBar = this.uiStatusBar;
            _App.MapControl = _mapControl;
            _App.PageLayoutControl = _pageLayoutControl;
            _App.MainPlatfrom = this;
            _App.Caption = this.Text;
            _App.Visible = this.Visible;
            _App.CurrentTool = null;
            _App.MainDataSet = _DataSet;

            ////��MapControl��PageLatoutControl����ͬ��
            //m_controlsSynchronizer = new ControlsSynchronizer(_mapControl, _pageLayoutControl);
            //m_controlsSynchronizer.BindControls(true);
            //m_controlsSynchronizer.AddFrameWorkControl(axTOCControl.Object);

            //TOCControl��esriTOOControlItemMap���Ҽ�����󵯳��Ŀ�ݲ˵�
            //_mapMenu = new ToolbarMenuClass();
            //_mapMenu.AddItem(new MapMenu(), 1, 0, false, esriCommandStyles.esriCommandStyleTextOnly);
            //_mapMenu.AddItem(new MapMenu(), 2, 1, false, esriCommandStyles.esriCommandStyleTextOnly);
            //_mapMenu.SetHook(this._mapControl);

        }

        #endregion

        /// <summary>
        /// ��ʼ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainGIS_Load(object sender, EventArgs e)
        {
            //�Ӳ���ļ����л��ʵ�ֲ���ӿڵĶ���
            PluginCollection pluginCol = PluginHandle.GetPluginsFromDll();
            //������Щ�������,��ò�ͬ���͵Ĳ������
            ParsePluginCollection parsePluhinCol = new ParsePluginCollection();
            parsePluhinCol.GetPluginArray(pluginCol);
            _CommandCol = parsePluhinCol.GetCommands;
            _ToolCol = parsePluhinCol.GetTools;
            _ToolBarCol = parsePluhinCol.GetToolBarDefs;
            _MenuItemCol = parsePluhinCol.GetMenuDefs;
            _DockableWindowCol = parsePluhinCol.GetDockableWindows;

            //���Command��Tool��UI���ϵ�Category����
            //foreach (string categoryName in parsePluhinCol.GetCommandCategorys)
            //{
            //    //uiCommandManager.Categories.Add(new UICommandCategory(categoryName));
            //}
            //����UI����
            CreateUICommandTool(_CommandCol, _ToolCol);
            CreateToolBars(_ToolBarCol);
            CreateMenus(_MenuItemCol);
            CreateDockableWindow(_DockableWindowCol);
            //��֤�������������󲻴����κ�Ĭ�ϵĴ���ʹ��״̬��ITool����
            //_mapControl.CurrentTool = null;
            //_pageLayoutControl.CurrentTool = null;
        }

        #region ����
        //Dictionary<string, CCmdBtn> m_DicPlugins = new Dictionary<string, CCmdBtn>();
        Dictionary<string, NBGIS.PluginEngine.IPlugin> m_DicPlugins = new Dictionary<string, NBGIS.PluginEngine.IPlugin>();
        /// <summary>
        /// ����Command�ؼ�����ӵ�CommandManager��
        /// </summary>
        /// <param name="Cmds">ICommand����</param>
        /// <param name="Tools">ITool����</param>
        private void CreateUICommandTool(Dictionary<string, NBGIS.PluginEngine.ICommand> Cmds, Dictionary<string, NBGIS.PluginEngine.ITool> Tools)
        {
            //����ICommand���󼯺�
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
        /// ����ToolBar��UI�����
        /// </summary>
        /// <param name="toolBars"></param>
        private void CreateToolBars(Dictionary<string, NBGIS.PluginEngine.IToolBarDef> toolBars)
        {
            foreach (KeyValuePair<string, NBGIS.PluginEngine.IToolBarDef> toolbar in toolBars)
            {
                NBGIS.PluginEngine.IToolBarDef nbtoolbar = toolbar.Value;
                //����UICommandBar����
                ToolStrip UIToolbar = new ToolStrip();
                //����UICommandBar������
                //UIToolbar.CommandManager = this.uiCommandManager;
                UIToolbar.Name = nbtoolbar.Name;
                UIToolbar.Text = nbtoolbar.Caption;
                UIToolbar.Tag = nbtoolbar;
                UIToolbar.AccessibleName = nbtoolbar.ToString();
                //��Command��Tool���뵽ToolBar��
                NBGIS.PluginEngine.ItemDef itemDef = new ItemDef();
                for (int i = 0; i < nbtoolbar.ItemCount; i++)
                {
                    nbtoolbar.GetItemInfo(i, itemDef);
                    NBGIS.PluginEngine.ICommand nbcmd = m_DicPlugins[itemDef.ID] as NBGIS.PluginEngine.ICommand; 
                    if (nbcmd != null)
                    {
                        //����һ��UICommand����
                        ToolStripButton UICommand = new ToolStripButton();
                        //����ICommand����Ϣ����UICommand������
                        UICommand.ToolTipText = nbcmd.Tooltip;
                        UICommand.Text = nbcmd.Caption;
                        UICommand.Image = nbcmd.Bitmap;
                        UICommand.AccessibleName = nbcmd.ToString();
                        UICommand.Enabled = nbcmd.Enabled;
                        //UICommand��Checked��command������һ��
                        UICommand.Checked = nbcmd.Checked;
                        //����UICommand�ǵ���OnCreate����,������ܶ��󴫵ݸ��������
                        nbcmd.OnCreate(this._App);
                        //ʹ��ί�л��ƴ���Command���¼�
                        //���е�UICommand����Click�¼���ʹ��this.Command_Click��������
                        UICommand.Click += new EventHandler(UICommand_Click);
                        //�����ɵ�UICommand��ӵ�CommandManager��
                        //�������,���ڸ�UI����ǰ����һ���ָ���
                        if (itemDef.Group)
                        {
                            UIToolbar.Items.Add(new ToolStripSeparator());
                        }
                        UIToolbar.Items.Add(UICommand);
                    }

                    //���һ��ITool����
                    NBGIS.PluginEngine.ITool nbtool = m_DicPlugins[itemDef.ID] as NBGIS.PluginEngine.ITool;
                    if (nbtool != null)
                    {
                        //����һ��ITool����
                        ToolStripButton UITool = new ToolStripButton();
                        //����ITool����Ϣ����UITool������
                        UITool.ToolTipText = nbtool.Tooltip;
                        UITool.Text = nbtool.Caption;
                        UITool.Image = nbtool.Bitmap;
                        UITool.AccessibleName = nbtool.ToString();
                        //UITool.Key = nbtool.ToString();
                        UITool.Enabled = nbtool.Enabled;
                        UITool.Checked = nbtool.Checked;
                        //����UICommand�ǵ���OnCreate����,������ܶ��󴫵ݸ��������
                        nbtool.OnCreate(this._App);
                        //ʹ��ί�л��ƴ���Command���¼�
                        //���е�UICommand����Click�¼���ʹ��this.UITool_Click��������
                        UITool.Click += new EventHandler(UITool_Click);
                        //�����ɵ�UICommand��ӵ�CommandManager��
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
        /// ����UI��Ĳ˵���
        /// </summary>
        /// <param name="Menus"></param>
        private void CreateMenus(Dictionary<string, NBGIS.PluginEngine.IMenuDef> Menus)
        {
            //����Menu�����е�Ԫ��
            foreach (KeyValuePair<string, NBGIS.PluginEngine.IMenuDef> menu in Menus)
            {
                NBGIS.PluginEngine.IMenuDef nbMenu = menu.Value;
                //�½��˵�����
                ToolStripMenuItem UIMenu = new ToolStripMenuItem();
                //���ò˵�����
                UIMenu.Text = nbMenu.Caption;
                UIMenu.Tag = nbMenu;
                UIMenu.AccessibleName = nbMenu.ToString();
                //��Menu���MainMenu��Commands��
                MainMenu.Items.Add(UIMenu);
                //��Command��Tool���뵽menu��
                //����ÿһ���˵�item
                NBGIS.PluginEngine.ItemDef itemDef = new NBGIS.PluginEngine.ItemDef();
                for (int i = 0; i < nbMenu.ItemCount; i++)
                {
                    //Ѱ�Ҹò˵��������Ϣ,��ò˵��ϵ�Item����,�Ƿ�ΪGroup
                    nbMenu.GetItemInfo(i, itemDef);

                    NBGIS.PluginEngine.ITool nbtool = m_DicPlugins[itemDef.ID] as NBGIS.PluginEngine.ITool;
                    if (nbtool != null)
                    {
                        //����һ��ITool����
                        ToolStripMenuItem UITool = new ToolStripMenuItem();
                        //����ITool����Ϣ����UITool������
                        UITool.ToolTipText = nbtool.Tooltip;
                        UITool.Text = nbtool.Caption;
                        UITool.Image = nbtool.Bitmap;
                        UITool.AccessibleName = nbtool.ToString();
                        //UITool.Key = nbtool.ToString();
                        UITool.Enabled = nbtool.Enabled;
                        UITool.Checked = nbtool.Checked;
                        //����UICommand�ǵ���OnCreate����,������ܶ��󴫵ݸ��������
                        nbtool.OnCreate(this._App);
                        //ʹ��ί�л��ƴ���Command���¼�
                        //���е�UICommand����Click�¼���ʹ��this.UITool_Click��������
                        UITool.Click += new EventHandler(UITool_Click);
                        //�����ɵ�UICommand��ӵ�CommandManager��
                        if (itemDef.Group)
                        {
                            UIMenu.DropDownItems.Add(new ToolStripSeparator());
                        }
                        UIMenu.DropDownItems.Add(UITool);
                    }
                    NBGIS.PluginEngine.ICommand nbcmd = m_DicPlugins[itemDef.ID] as NBGIS.PluginEngine.ICommand;
                    if (nbcmd != null)
                    {
                        //����һ��UICommand����
                        ToolStripMenuItem UICommand = new ToolStripMenuItem();
                        //����ICommand����Ϣ����UICommand������
                        UICommand.ToolTipText = nbcmd.Tooltip;
                        UICommand.Text = nbcmd.Caption;
                        UICommand.Image = nbcmd.Bitmap;
                        UICommand.AccessibleName = nbcmd.ToString();
                        UICommand.Enabled = nbcmd.Enabled;
                        //UICommand��Checked��command������һ��
                        UICommand.Checked = nbcmd.Checked;
                        //����UICommand�ǵ���OnCreate����,������ܶ��󴫵ݸ��������
                        nbcmd.OnCreate(this._App);
                        //ʹ��ί�л��ƴ���Command���¼�
                        //���е�UICommand����Click�¼���ʹ��this.Command_Click��������
                        UICommand.Click += new EventHandler(UICommand_Click);
                        //�����ɵ�UICommand��ӵ�CommandManager��
                        //�������,���ڸ�UI����ǰ����һ���ָ���
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
        ///  ����Floating Panel��UI�����(��������)
        /// </summary>
        /// <param name="dockWindows">�������弯��</param>
        private void CreateDockableWindow(Dictionary<string, NBGIS.PluginEngine.IDockableWindowDef> dockWindows)
        {
            //������������������ļ���
            foreach (KeyValuePair<string, NBGIS.PluginEngine.IDockableWindowDef> dockWindowItem in dockWindows)
            {
            //    //����һ�������������
            //    NBGIS.PluginEngine.IDockableWindowDef item = dockWindowItem.Value;
            //    //���������������ʱ������ܶ��󴫵ݸ��������
            //    item.OnCreate(_App);
            //    //����һ������Panel
            //    UIPanel panel = new UIPanel();
            //    panel.FloatingLocation = new System.Drawing.Point(120, 180);
            //    panel.Size = new System.Drawing.Size(188, 188);
            //    panel.Name = item.Name;
            //    panel.Text = item.Caption;
            //    panel.DockState = PanelDockState.Floating;//����
            //    //�����ʼ��
            //    ((System.ComponentModel.ISupportInitialize)(panel)).BeginInit();
            //    panel.Id = Guid.NewGuid();
            //    //��ʱ����ؼ��Ĳ����߼�
            //    panel.SuspendLayout();
            //    uiPanelManager.Panels.Add(panel);
            //    UIPanelInnerContainer panelContainer = new UIPanelInnerContainer();
            //    panel.InnerContainer = panelContainer;
            //    try
            //    {
            //        //������뱣֤ChildHWND��ȷ,����ᷢ���쳣
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
            //            AppLog.log.Error("������������ӿؼ�û����ȷ����");
            //        }
            //    }
            }
        }

        #endregion

        #region �Զ����¼�
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
            //��ǰCommand������ʱ,CurrentTool����Ϊnull
            //MapControl��PageLayoutControl��Ҳ����Ϊnull
            _App.CurrentTool = null;
            _App.MapControl.CurrentTool = null;
            _App.PageLayoutControl.CurrentTool = null;
            //һ����Command������ǰδ��ɵ�Tool����������ʹTool��CheckedΪtrue
            //�����������ΪFalse
            //�������е�Command,����ÿһ��Command��ѡ��״̬ΪFalse
            ToolStripButton UICmd = null;
            foreach (var item in pItem.GetCurrentParent().Items)
            {
                UICmd = item as ToolStripButton;
                if (null == UICmd)
                    continue;
                UICmd.Checked = false;
            }
            NBGIS.PluginEngine.ICommand cmd = _CommandCol[strKey];
            ////��״̬����ʾ�����Ϣ
            this.toolStripStatusLabel1.Text = cmd.Message;
            if (null != pTempBtn)
            {
                pTempBtn.Checked = true;
            }
            //((ToolStripButton)sender).Checked = true;
            //����Map�ؼ������
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
            //��õ�ǰ�����ITool����
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
            //��һ�ΰ���
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
                    //������������ΰ���,��ʹ���Tool��ɲ������ڹر�״̬
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
                    ////����һ��Tool��û�йرս���ȥ����һ��Tool,��ر�ǰһ��Tool
                    ////���ǰһ��Tool
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
                    //���ú�һ��Tool��״̬
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

        //#region MapControl�¼�����
        //private void axMapControl_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        //{
        //    if (_App.CurrentTool != null)
        //    {
        //        _Tool = _ToolCol[_App.CurrentTool];
        //        //���
        //        if (e.button == 1)
        //        {
        //            _Tool.OnMouseDown(e.button, e.shift, (int)e.mapX, (int)e.mapY);
        //        }
        //        else if (e.button == 2)//�Ҽ�
        //        {
        //            _Tool.OnContextMenu(e.x, e.y);
        //        }
        //    }
        //    toolStripStatusLabel2.Text = " ��ǰ����X��" + e.mapX.ToString() + "  Y��" + e.mapY.ToString();
        //}

        //private void axMapControl_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        //{
        //    if (_App.CurrentTool != null)
        //    {
        //        _Tool = _ToolCol[_App.CurrentTool];
        //        _Tool.OnMouseMove(e.button, e.shift, (int)e.mapX, (int)e.mapY);
        //    }
        //    toolStripStatusLabel2.Text = " ��ǰ����X��" + e.mapX.ToString() + "  Y��" + e.mapY.ToString();
        //    toolStripStatusLabel3.Text = "�����ߣ�" + ((long)(_mapControl.MapScale)).ToString();
        //}

        //private void axMapControl_OnMouseUp(object sender, IMapControlEvents2_OnMouseUpEvent e)
        //{
        //    if (_App.CurrentTool != null)
        //    {
        //        _Tool = _ToolCol[_App.CurrentTool];
        //        _Tool.OnMouseUp(e.button, e.shift, (int)e.mapX, (int)e.mapY);
        //    }
        //    toolStripStatusLabel2.Text = " ��ǰ����X��" + e.mapX.ToString() + "  Y��" + e.mapY.ToString();
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

        //#region PageLayoutControl�¼�����

        //private void axPageLayoutControl_OnMouseDown(object sender, IPageLayoutControlEvents_OnMouseDownEvent e)
        //{
        //    if (_App.CurrentTool != null)
        //    {
        //        _Tool = _ToolCol[_App.CurrentTool];
        //        //���
        //        if (e.button == 1)
        //        {
        //            _Tool.OnMouseDown(e.button, e.shift, (int)e.pageX, (int)e.pageY);
        //        }
        //        else if (e.button == 2)//�Ҽ�
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
        //    //ȷ������Ŀ��ѡ��
        //    if (item == esriTOCControlItem.esriTOCControlItemMap)
        //        _tocControl.SelectItem(map, null);
        //    else
        //        _tocControl.SelectItem(layer, null);

        //    //ѡ�����Map
        //    if (item == esriTOCControlItem.esriTOCControlItemMap)
        //    {
        //        //��Map��Ϣ���ݸ�propertyGrid�ؼ�
        //        MapInfo _mapInfo = new MapInfo(_mapControl.Map);
        //        //propertyGrid.SelectedObject = _mapInfo;
        //        //������Ҽ����,�����˵�
        //        if (e.button == 2)
        //        {
        //            _mapMenu.PopupMenu(e.x, e.y, _tocControl.hWnd);
        //        }
        //    }
        //    //ѡ����� Layer
        //    if (item == esriTOCControlItem.esriTOCControlItemLayer)
        //    {
        //        //��Layer��Ϣ���ݸ�PropertyGrid�ؼ�
        //        _mapControl.CustomProperty = layer;

        //        IFeatureLayer pFeatLyr = layer as IFeatureLayer;

        //        if (pFeatLyr == null)
        //            return;
        //        MapLayerInfo _mapLyrInfo = new MapLayerInfo(pFeatLyr, _mapControl.Map);
        //        //propertyGrid.SelectedObject = _mapLyrInfo;

        //        //_App.StatusBar.Panels[0].Text = "��ǰѡ��ͼ��:" + layer.Name;

        //        //���ݱ��г��ֵ�ǰͼ������
        //        //��ȡ��Ч��ͼ������ a_b������Ϊa.b
        //        string LayerName = LayerDataTable.getValidFeatureClassName(layer.Name);
        //        //�жϵ�ǰͼ���Ƿ����Selection
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
        //        //DataPanel.Text = "���ݱ�[" + LayerName + "]" + "  ��¼����" + _DataSet.Tables[LayerName].Rows.Count.ToString();
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
            //        //Ѱ�Ҹ��м�¼��Ӧ��Ҫ��
            //        //pFeat = pFeatCls.GetFeature(Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value));
            //    }
            //    catch
            //    {
            //        pFeat = null;
            //    }
            //    if (pFeat != null)
            //    {
            //        //Ҫ�صĶ���
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
            //        //���ڽ���ȶ�λ����˸������
            //        //�Զ�����˸����
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