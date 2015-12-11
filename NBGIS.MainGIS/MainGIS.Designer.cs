using System.Windows.Forms;
namespace NBGIS.MainGIS
{
    partial class MainGIS
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGIS));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.axTOCControl = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.mapTab = new System.Windows.Forms.TabPage();
            this.axLicenseControl = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axMapControl = new ESRI.ArcGIS.Controls.AxMapControl();
            this.pageTab = new System.Windows.Forms.TabPage();
            this.axPageLayoutControl = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.uiCommandManager = new System.Windows.Forms.Panel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.uiStatusBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.mapTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl)).BeginInit();
            this.pageTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl)).BeginInit();
            this.uiCommandManager.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.uiStatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.axTOCControl);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer.Size = new System.Drawing.Size(684, 418);
            this.splitContainer.SplitterDistance = 228;
            this.splitContainer.TabIndex = 0;
            // 
            // axTOCControl
            // 
            this.axTOCControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axTOCControl.Location = new System.Drawing.Point(0, 0);
            this.axTOCControl.Name = "axTOCControl";
            this.axTOCControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl.OcxState")));
            this.axTOCControl.Size = new System.Drawing.Size(228, 418);
            this.axTOCControl.TabIndex = 0;
            this.axTOCControl.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.axTOCControl_OnMouseDown);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.mapTab);
            this.tabControl1.Controls.Add(this.pageTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(452, 418);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // mapTab
            // 
            this.mapTab.Controls.Add(this.axLicenseControl);
            this.mapTab.Controls.Add(this.axMapControl);
            this.mapTab.Location = new System.Drawing.Point(4, 4);
            this.mapTab.Name = "mapTab";
            this.mapTab.Padding = new System.Windows.Forms.Padding(3);
            this.mapTab.Size = new System.Drawing.Size(444, 392);
            this.mapTab.TabIndex = 0;
            this.mapTab.Text = "视图";
            this.mapTab.UseVisualStyleBackColor = true;
            // 
            // axLicenseControl
            // 
            this.axLicenseControl.Enabled = true;
            this.axLicenseControl.Location = new System.Drawing.Point(60, 140);
            this.axLicenseControl.Name = "axLicenseControl";
            this.axLicenseControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl.OcxState")));
            this.axLicenseControl.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl.TabIndex = 1;
            // 
            // axMapControl
            // 
            this.axMapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl.Location = new System.Drawing.Point(3, 3);
            this.axMapControl.Name = "axMapControl";
            this.axMapControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl.OcxState")));
            this.axMapControl.Size = new System.Drawing.Size(438, 386);
            this.axMapControl.TabIndex = 0;
            this.axMapControl.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl_OnMouseDown);
            this.axMapControl.OnMouseUp += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseUpEventHandler(this.axMapControl_OnMouseUp);
            this.axMapControl.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl_OnMouseMove);
            this.axMapControl.OnDoubleClick += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnDoubleClickEventHandler(this.axMapControl_OnDoubleClick);
            this.axMapControl.OnViewRefreshed += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnViewRefreshedEventHandler(this.axMapControl_OnViewRefreshed);
            this.axMapControl.OnKeyDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnKeyDownEventHandler(this.axMapControl_OnKeyDown);
            this.axMapControl.OnKeyUp += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnKeyUpEventHandler(this.axMapControl_OnKeyUp);
            // 
            // pageTab
            // 
            this.pageTab.Controls.Add(this.axPageLayoutControl);
            this.pageTab.Location = new System.Drawing.Point(4, 4);
            this.pageTab.Name = "pageTab";
            this.pageTab.Padding = new System.Windows.Forms.Padding(3);
            this.pageTab.Size = new System.Drawing.Size(444, 416);
            this.pageTab.TabIndex = 1;
            this.pageTab.Text = "制图";
            this.pageTab.UseVisualStyleBackColor = true;
            // 
            // axPageLayoutControl
            // 
            this.axPageLayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axPageLayoutControl.Location = new System.Drawing.Point(3, 3);
            this.axPageLayoutControl.Name = "axPageLayoutControl";
            this.axPageLayoutControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl.OcxState")));
            this.axPageLayoutControl.Size = new System.Drawing.Size(438, 410);
            this.axPageLayoutControl.TabIndex = 0;
            this.axPageLayoutControl.OnMouseDown += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseDownEventHandler(this.axPageLayoutControl_OnMouseDown);
            this.axPageLayoutControl.OnMouseUp += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseUpEventHandler(this.axPageLayoutControl_OnMouseUp);
            this.axPageLayoutControl.OnMouseMove += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseMoveEventHandler(this.axPageLayoutControl_OnMouseMove);
            this.axPageLayoutControl.OnDoubleClick += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnDoubleClickEventHandler(this.axPageLayoutControl_OnDoubleClick);
            this.axPageLayoutControl.OnKeyDown += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnKeyDownEventHandler(this.axPageLayoutControl_OnKeyDown);
            this.axPageLayoutControl.OnKeyUp += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnKeyUpEventHandler(this.axPageLayoutControl_OnKeyUp);
            this.axPageLayoutControl.OnViewRefreshed += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnViewRefreshedEventHandler(this.axPageLayoutControl_OnViewRefreshed);
            // 
            // uiCommandManager
            // 
            this.uiCommandManager.Controls.Add(this.toolStripContainer1);
            this.uiCommandManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiCommandManager.Location = new System.Drawing.Point(0, 24);
            this.uiCommandManager.Name = "uiCommandManager";
            this.uiCommandManager.Size = new System.Drawing.Size(684, 443);
            this.uiCommandManager.TabIndex = 1;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(684, 418);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(684, 443);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // uiStatusBar
            // 
            this.uiStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.uiStatusBar.Location = new System.Drawing.Point(0, 467);
            this.uiStatusBar.Name = "uiStatusBar";
            this.uiStatusBar.Size = new System.Drawing.Size(684, 22);
            this.uiStatusBar.TabIndex = 2;
            this.uiStatusBar.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(13, 17);
            this.toolStripStatusLabel1.Text = "-";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(13, 17);
            this.toolStripStatusLabel2.Text = "-";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(13, 17);
            this.toolStripStatusLabel3.Text = "-";
            // 
            // MainMenu
            // 
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(684, 24);
            this.MainMenu.TabIndex = 3;
            this.MainMenu.Text = "menuStrip1";
            // 
            // MainGIS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 489);
            this.Controls.Add(this.uiCommandManager);
            this.Controls.Add(this.uiStatusBar);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainGIS";
            this.Text = "MainGIS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainGIS_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.mapTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl)).EndInit();
            this.pageTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl)).EndInit();
            this.uiCommandManager.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.uiStatusBar.ResumeLayout(false);
            this.uiStatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.PropertyGrid propertyGrid;
        //private System.Windows.Forms.DataGridView dataGridView;
        private SplitContainer splitContainer;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl;
        private TabControl tabControl1;
        private TabPage mapTab;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl;
        private TabPage pageTab;
        private ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl;
        private Panel uiCommandManager;
        private ToolStripContainer toolStripContainer1;
        private StatusStrip uiStatusBar;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private MenuStrip MainMenu;//uiCommandManager
    }
}