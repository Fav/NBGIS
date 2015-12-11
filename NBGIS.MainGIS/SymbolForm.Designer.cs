namespace NBGIS.MainGIS
{
    partial class SymbolForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SymbolForm));
            this.axSymbologyControl = new ESRI.ArcGIS.Controls.AxSymbologyControl();
            this.SymbolPictureBox = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCencel = new System.Windows.Forms.Button();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SymbolPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // axSymbologyControl
            // 
            this.axSymbologyControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.axSymbologyControl.Location = new System.Drawing.Point(0, 0);
            this.axSymbologyControl.Name = "axSymbologyControl";
            this.axSymbologyControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSymbologyControl.OcxState")));
            this.axSymbologyControl.Size = new System.Drawing.Size(300, 316);
            this.axSymbologyControl.TabIndex = 0;
            this.axSymbologyControl.OnItemSelected += new ESRI.ArcGIS.Controls.ISymbologyControlEvents_Ax_OnItemSelectedEventHandler(this.axSymbologyControl_OnItemSelected);
            // 
            // SymbolPictureBox
            // 
            this.SymbolPictureBox.Location = new System.Drawing.Point(311, 12);
            this.SymbolPictureBox.Name = "SymbolPictureBox";
            this.SymbolPictureBox.Size = new System.Drawing.Size(119, 50);
            this.SymbolPictureBox.TabIndex = 1;
            this.SymbolPictureBox.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(332, 242);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCencel
            // 
            this.btnCencel.Location = new System.Drawing.Point(332, 271);
            this.btnCencel.Name = "btnCencel";
            this.btnCencel.Size = new System.Drawing.Size(75, 23);
            this.btnCencel.TabIndex = 3;
            this.btnCencel.Text = "取消";
            this.btnCencel.UseVisualStyleBackColor = true;
            this.btnCencel.Click += new System.EventHandler(this.btnCencel_Click);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(93, 214);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 4;
            // 
            // SymbolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 316);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.btnCencel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.SymbolPictureBox);
            this.Controls.Add(this.axSymbologyControl);
            this.Name = "SymbolForm";
            this.Text = "SymbolForm";
            this.Load += new System.EventHandler(this.SymbolForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SymbolPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxSymbologyControl axSymbologyControl;
        private System.Windows.Forms.PictureBox SymbolPictureBox;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCencel;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
    }
}