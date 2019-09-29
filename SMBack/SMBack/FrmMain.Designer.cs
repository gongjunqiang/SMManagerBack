namespace SMBack
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.系统SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUserManage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiModifyPwd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.商品管理PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProductStorage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiProductManage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInventoryManage = new System.Windows.Forms.ToolStripMenuItem();
            this.销售管理XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaleStat = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolAdminName = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnModifyPwd = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnInventoryManage = new System.Windows.Forms.Button();
            this.btnLogQuery = new System.Windows.Forms.Button();
            this.btnProductInventor = new System.Windows.Forms.Button();
            this.btnSalAnalasys = new System.Windows.Forms.Button();
            this.btnProductManage = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.menuStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统SToolStripMenuItem,
            this.商品管理PToolStripMenuItem,
            this.销售管理XToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1264, 25);
            this.menuStrip2.TabIndex = 3;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // 系统SToolStripMenuItem
            // 
            this.系统SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUserManage,
            this.tsmiModifyPwd,
            this.toolStripSeparator3,
            this.tsmiLogs,
            this.toolStripSeparator2,
            this.tsmiExit});
            this.系统SToolStripMenuItem.Name = "系统SToolStripMenuItem";
            this.系统SToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.系统SToolStripMenuItem.Text = "系统(&S)";
            // 
            // tsmiUserManage
            // 
            this.tsmiUserManage.Image = ((System.Drawing.Image)(resources.GetObject("tsmiUserManage.Image")));
            this.tsmiUserManage.Name = "tsmiUserManage";
            this.tsmiUserManage.Size = new System.Drawing.Size(141, 22);
            this.tsmiUserManage.Text = "用户管理(&U)";
            // 
            // tsmiModifyPwd
            // 
            this.tsmiModifyPwd.Image = ((System.Drawing.Image)(resources.GetObject("tsmiModifyPwd.Image")));
            this.tsmiModifyPwd.Name = "tsmiModifyPwd";
            this.tsmiModifyPwd.Size = new System.Drawing.Size(141, 22);
            this.tsmiModifyPwd.Text = "修改密码(&P)";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(138, 6);
            // 
            // tsmiLogs
            // 
            this.tsmiLogs.Image = ((System.Drawing.Image)(resources.GetObject("tsmiLogs.Image")));
            this.tsmiLogs.Name = "tsmiLogs";
            this.tsmiLogs.Size = new System.Drawing.Size(141, 22);
            this.tsmiLogs.Text = "日志查询(&L)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(138, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Image = ((System.Drawing.Image)(resources.GetObject("tsmiExit.Image")));
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(141, 22);
            this.tsmiExit.Text = "退出系统(&E)";
            // 
            // 商品管理PToolStripMenuItem
            // 
            this.商品管理PToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddProduct,
            this.tsmiProductStorage,
            this.toolStripSeparator1,
            this.tsmiProductManage,
            this.tsmiInventoryManage});
            this.商品管理PToolStripMenuItem.Name = "商品管理PToolStripMenuItem";
            this.商品管理PToolStripMenuItem.Size = new System.Drawing.Size(83, 21);
            this.商品管理PToolStripMenuItem.Text = "商品管理(&P)";
            // 
            // tsmiAddProduct
            // 
            this.tsmiAddProduct.Image = ((System.Drawing.Image)(resources.GetObject("tsmiAddProduct.Image")));
            this.tsmiAddProduct.Name = "tsmiAddProduct";
            this.tsmiAddProduct.Size = new System.Drawing.Size(144, 22);
            this.tsmiAddProduct.Text = "添加商品(&A)";
            // 
            // tsmiProductStorage
            // 
            this.tsmiProductStorage.Image = ((System.Drawing.Image)(resources.GetObject("tsmiProductStorage.Image")));
            this.tsmiProductStorage.Name = "tsmiProductStorage";
            this.tsmiProductStorage.Size = new System.Drawing.Size(144, 22);
            this.tsmiProductStorage.Text = "商品入库(&I)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(141, 6);
            // 
            // tsmiProductManage
            // 
            this.tsmiProductManage.Image = ((System.Drawing.Image)(resources.GetObject("tsmiProductManage.Image")));
            this.tsmiProductManage.Name = "tsmiProductManage";
            this.tsmiProductManage.Size = new System.Drawing.Size(144, 22);
            this.tsmiProductManage.Text = "商品维护(&M)";
            // 
            // tsmiInventoryManage
            // 
            this.tsmiInventoryManage.Image = ((System.Drawing.Image)(resources.GetObject("tsmiInventoryManage.Image")));
            this.tsmiInventoryManage.Name = "tsmiInventoryManage";
            this.tsmiInventoryManage.Size = new System.Drawing.Size(144, 22);
            this.tsmiInventoryManage.Text = "库存管理(&K)";
            // 
            // 销售管理XToolStripMenuItem
            // 
            this.销售管理XToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSaleStat});
            this.销售管理XToolStripMenuItem.Name = "销售管理XToolStripMenuItem";
            this.销售管理XToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.销售管理XToolStripMenuItem.Text = "销售管理(&X)";
            // 
            // tsmiSaleStat
            // 
            this.tsmiSaleStat.Image = ((System.Drawing.Image)(resources.GetObject("tsmiSaleStat.Image")));
            this.tsmiSaleStat.Name = "tsmiSaleStat";
            this.tsmiSaleStat.Size = new System.Drawing.Size(139, 22);
            this.tsmiSaleStat.Text = "销售统计(&S)";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolAdminName});
            this.statusStrip1.Location = new System.Drawing.Point(0, 707);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1264, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(125, 17);
            this.toolStripStatusLabel1.Text = "[超市管理系统]  V2.0 ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(80, 17);
            this.toolStripStatusLabel2.Text = "【管理员】：";
            // 
            // toolAdminName
            // 
            this.toolAdminName.Name = "toolAdminName";
            this.toolAdminName.Size = new System.Drawing.Size(26, 17);
            this.toolAdminName.Text = "xxx";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnModifyPwd);
            this.splitContainer1.Panel1.Controls.Add(this.btnExit);
            this.splitContainer1.Panel1.Controls.Add(this.btnInventoryManage);
            this.splitContainer1.Panel1.Controls.Add(this.btnLogQuery);
            this.splitContainer1.Panel1.Controls.Add(this.btnProductInventor);
            this.splitContainer1.Panel1.Controls.Add(this.btnSalAnalasys);
            this.splitContainer1.Panel1.Controls.Add(this.btnProductManage);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddProduct);
            this.splitContainer1.Panel1.Controls.Add(this.monthCalendar1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("splitContainer1.Panel2.BackgroundImage")));
            this.splitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer1.Size = new System.Drawing.Size(1264, 682);
            this.splitContainer1.SplitterDistance = 246;
            this.splitContainer1.TabIndex = 10;
            // 
            // btnModifyPwd
            // 
            this.btnModifyPwd.Image = ((System.Drawing.Image)(resources.GetObject("btnModifyPwd.Image")));
            this.btnModifyPwd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModifyPwd.Location = new System.Drawing.Point(24, 592);
            this.btnModifyPwd.Name = "btnModifyPwd";
            this.btnModifyPwd.Size = new System.Drawing.Size(82, 41);
            this.btnModifyPwd.TabIndex = 2;
            this.btnModifyPwd.Text = "密码修改";
            this.btnModifyPwd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModifyPwd.UseVisualStyleBackColor = true;
            this.btnModifyPwd.Click += new System.EventHandler(this.BtnModifyPwd_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(124, 592);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(82, 41);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "退出系统";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnInventoryManage
            // 
            this.btnInventoryManage.Image = ((System.Drawing.Image)(resources.GetObject("btnInventoryManage.Image")));
            this.btnInventoryManage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventoryManage.Location = new System.Drawing.Point(29, 317);
            this.btnInventoryManage.Name = "btnInventoryManage";
            this.btnInventoryManage.Size = new System.Drawing.Size(82, 41);
            this.btnInventoryManage.TabIndex = 4;
            this.btnInventoryManage.Text = "库存管理";
            this.btnInventoryManage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInventoryManage.UseVisualStyleBackColor = true;
            this.btnInventoryManage.Click += new System.EventHandler(this.BtnInventoryManage_Click);
            // 
            // btnLogQuery
            // 
            this.btnLogQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnLogQuery.Image")));
            this.btnLogQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogQuery.Location = new System.Drawing.Point(124, 399);
            this.btnLogQuery.Name = "btnLogQuery";
            this.btnLogQuery.Size = new System.Drawing.Size(82, 41);
            this.btnLogQuery.TabIndex = 5;
            this.btnLogQuery.Text = "日志查询";
            this.btnLogQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogQuery.UseVisualStyleBackColor = true;
            this.btnLogQuery.Click += new System.EventHandler(this.BtnLogQuery_Click);
            // 
            // btnProductInventor
            // 
            this.btnProductInventor.Image = ((System.Drawing.Image)(resources.GetObject("btnProductInventor.Image")));
            this.btnProductInventor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductInventor.Location = new System.Drawing.Point(124, 235);
            this.btnProductInventor.Name = "btnProductInventor";
            this.btnProductInventor.Size = new System.Drawing.Size(82, 41);
            this.btnProductInventor.TabIndex = 6;
            this.btnProductInventor.Text = "商品入库";
            this.btnProductInventor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProductInventor.UseVisualStyleBackColor = true;
            this.btnProductInventor.Click += new System.EventHandler(this.BtnProductInventor_Click);
            // 
            // btnSalAnalasys
            // 
            this.btnSalAnalasys.Image = ((System.Drawing.Image)(resources.GetObject("btnSalAnalasys.Image")));
            this.btnSalAnalasys.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalAnalasys.Location = new System.Drawing.Point(29, 399);
            this.btnSalAnalasys.Name = "btnSalAnalasys";
            this.btnSalAnalasys.Size = new System.Drawing.Size(82, 41);
            this.btnSalAnalasys.TabIndex = 7;
            this.btnSalAnalasys.Text = "销售统计";
            this.btnSalAnalasys.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalAnalasys.UseVisualStyleBackColor = true;
            this.btnSalAnalasys.Click += new System.EventHandler(this.BtnSalAnalasys_Click);
            // 
            // btnProductManage
            // 
            this.btnProductManage.Image = ((System.Drawing.Image)(resources.GetObject("btnProductManage.Image")));
            this.btnProductManage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductManage.Location = new System.Drawing.Point(124, 317);
            this.btnProductManage.Name = "btnProductManage";
            this.btnProductManage.Size = new System.Drawing.Size(82, 41);
            this.btnProductManage.TabIndex = 8;
            this.btnProductManage.Text = "商品维护";
            this.btnProductManage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProductManage.UseVisualStyleBackColor = true;
            this.btnProductManage.Click += new System.EventHandler(this.BtnProductManage_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Image = ((System.Drawing.Image)(resources.GetObject("btnAddProduct.Image")));
            this.btnAddProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddProduct.Location = new System.Drawing.Point(29, 235);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(82, 41);
            this.btnAddProduct.TabIndex = 9;
            this.btnAddProduct.Text = "新增商品";
            this.btnAddProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.BtnAddProduct_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(12, 21);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 729);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip2);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 系统SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiUserManage;
        private System.Windows.Forms.ToolStripMenuItem tsmiModifyPwd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiLogs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem 商品管理PToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddProduct;
        private System.Windows.Forms.ToolStripMenuItem tsmiProductStorage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiProductManage;
        private System.Windows.Forms.ToolStripMenuItem tsmiInventoryManage;
        private System.Windows.Forms.ToolStripMenuItem 销售管理XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaleStat;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolAdminName;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btnModifyPwd;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnInventoryManage;
        private System.Windows.Forms.Button btnLogQuery;
        private System.Windows.Forms.Button btnProductInventor;
        private System.Windows.Forms.Button btnSalAnalasys;
        private System.Windows.Forms.Button btnProductManage;
        private System.Windows.Forms.Button btnAddProduct;
    }
}