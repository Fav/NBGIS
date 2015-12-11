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
            this.uiCommandManager = new System.Windows.Forms.Panel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.mapTab = new System.Windows.Forms.TabPage();
            this.mapControl1 = new NBGIS.ArcObj.MapControl();
            this.pageTab = new System.Windows.Forms.TabPage();
            this.pageLayoutControl1 = new NBGIS.ArcObj.PageLayoutControl();
            this.uiStatusBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.uiCommandManager.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.mapTab.SuspendLayout();
            this.pageTab.SuspendLayout();
            this.uiStatusBar.SuspendLayout();
            this.SuspendLayout();
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
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer.Size = new System.Drawing.Size(684, 418);
            this.splitContainer.SplitterDistance = 228;
            this.splitContainer.TabIndex = 0;
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
            this.mapTab.Controls.Add(this.mapControl1);
            this.mapTab.Location = new System.Drawing.Point(4, 4);
            this.mapTab.Name = "mapTab";
            this.mapTab.Padding = new System.Windows.Forms.Padding(3);
            this.mapTab.Size = new System.Drawing.Size(444, 392);
            this.mapTab.TabIndex = 0;
            this.mapTab.Text = "视图";
            this.mapTab.UseVisualStyleBackColor = true;
            // 
            // mapControl1
            // 
            this.mapControl1.ActiveView = null;
            this.mapControl1.CurrentTool = null;
            this.mapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapControl1.Location = new System.Drawing.Point(3, 3);
            this.mapControl1.MousePointer = 0;
            this.mapControl1.Name = "mapControl1";
            this.mapControl1.Size = new System.Drawing.Size(438, 386);
            this.mapControl1.TabIndex = 0;
            // 
            // pageTab
            // 
            this.pageTab.Controls.Add(this.pageLayoutControl1);
            this.pageTab.Location = new System.Drawing.Point(4, 4);
            this.pageTab.Name = "pageTab";
            this.pageTab.Padding = new System.Windows.Forms.Padding(3);
            this.pageTab.Size = new System.Drawing.Size(444, 392);
            this.pageTab.TabIndex = 1;
            this.pageTab.Text = "制图";
            this.pageTab.UseVisualStyleBackColor = true;
            // 
            // pageLayoutControl1
            // 
            this.pageLayoutControl1.ActiveView = null;
            this.pageLayoutControl1.CurrentTool = null;
            this.pageLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageLayoutControl1.Location = new System.Drawing.Point(3, 3);
            this.pageLayoutControl1.MousePointer = 0;
            this.pageLayoutControl1.Name = "pageLayoutControl1";
            this.pageLayoutControl1.Size = new System.Drawing.Size(438, 386);
            this.pageLayoutControl1.TabIndex = 0;
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
            this.uiCommandManager.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.mapTab.ResumeLayout(false);
            this.pageTab.ResumeLayout(false);
            this.uiStatusBar.ResumeLayout(false);
            this.uiStatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.PropertyGrid propertyGrid;
        //private System.Windows.Forms.DataGridView dataGridView;
        private SplitContainer splitContainer;
        private TabControl tabControl1;
        private TabPage mapTab;
        private TabPage pageTab;
        private Panel uiCommandManager;
        private ToolStripContainer toolStripContainer1;
        private StatusStrip uiStatusBar;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private MenuStrip MainMenu;
        private ArcObj.MapControl mapControl1;
        private ArcObj.PageLayoutControl pageLayoutControl1;//uiCommandManager
    }
}