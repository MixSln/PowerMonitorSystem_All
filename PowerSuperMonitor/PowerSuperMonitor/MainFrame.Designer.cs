namespace PowerSuperMonitor
{
    partial class MainFrame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrame));
            this.MySkin = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.MainStatus = new System.Windows.Forms.StatusStrip();
            this.MainTools = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.注销ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.配电室管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设备管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.状态查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.MainTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // MySkin
            // 
            this.MySkin.SerialNumber = "";
            this.MySkin.SkinFile = null;
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始ToolStripMenuItem,
            this.用户管理ToolStripMenuItem,
            this.配电室管理ToolStripMenuItem,
            this.设备管理ToolStripMenuItem,
            this.状态查询ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1030, 24);
            this.MainMenu.TabIndex = 3;
            this.MainMenu.Text = "主菜单";
            // 
            // MainStatus
            // 
            this.MainStatus.Location = new System.Drawing.Point(0, 655);
            this.MainStatus.Name = "MainStatus";
            this.MainStatus.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MainStatus.Size = new System.Drawing.Size(1030, 22);
            this.MainStatus.TabIndex = 4;
            this.MainStatus.Text = "当前状态";
            // 
            // MainTools
            // 
            this.MainTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.MainTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1});
            this.MainTools.Location = new System.Drawing.Point(0, 24);
            this.MainTools.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.MainTools.Name = "MainTools";
            this.MainTools.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MainTools.Size = new System.Drawing.Size(1030, 54);
            this.MainTools.TabIndex = 5;
            this.MainTools.Text = "MainMenu";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(59, 51);
            this.toolStripButton1.Text = "添加用户";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(59, 51);
            this.toolStripButton2.Text = "用户列表";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 54);
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.注销ToolStripMenuItem,
            this.关闭ToolStripMenuItem});
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.开始ToolStripMenuItem.Text = "开始";
            // 
            // 注销ToolStripMenuItem
            // 
            this.注销ToolStripMenuItem.Name = "注销ToolStripMenuItem";
            this.注销ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.注销ToolStripMenuItem.Text = "注销";
            // 
            // 关闭ToolStripMenuItem
            // 
            this.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            this.关闭ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.关闭ToolStripMenuItem.Text = "关闭";
            // 
            // 用户管理ToolStripMenuItem
            // 
            this.用户管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.用户添加ToolStripMenuItem,
            this.用户列表ToolStripMenuItem});
            this.用户管理ToolStripMenuItem.Name = "用户管理ToolStripMenuItem";
            this.用户管理ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.用户管理ToolStripMenuItem.Text = "用户管理";
            // 
            // 用户添加ToolStripMenuItem
            // 
            this.用户添加ToolStripMenuItem.Name = "用户添加ToolStripMenuItem";
            this.用户添加ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.用户添加ToolStripMenuItem.Text = "用户添加";
            // 
            // 用户列表ToolStripMenuItem
            // 
            this.用户列表ToolStripMenuItem.Name = "用户列表ToolStripMenuItem";
            this.用户列表ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.用户列表ToolStripMenuItem.Text = "用户列表";
            // 
            // 配电室管理ToolStripMenuItem
            // 
            this.配电室管理ToolStripMenuItem.Name = "配电室管理ToolStripMenuItem";
            this.配电室管理ToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.配电室管理ToolStripMenuItem.Text = "配电室管理";
            // 
            // 设备管理ToolStripMenuItem
            // 
            this.设备管理ToolStripMenuItem.Name = "设备管理ToolStripMenuItem";
            this.设备管理ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.设备管理ToolStripMenuItem.Text = "设备管理";
            // 
            // 状态查询ToolStripMenuItem
            // 
            this.状态查询ToolStripMenuItem.Name = "状态查询ToolStripMenuItem";
            this.状态查询ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.状态查询ToolStripMenuItem.Text = "状态查询";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 677);
            this.Controls.Add(this.MainTools);
            this.Controls.Add(this.MainStatus);
            this.Controls.Add(this.MainMenu);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MainMenu;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainFrame";
            this.Text = "PowerSuperMonitor";
            this.Shown += new System.EventHandler(this.MainFrame_Shown);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.MainTools.ResumeLayout(false);
            this.MainTools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunisoft.IrisSkin.SkinEngine MySkin;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.StatusStrip MainStatus;
        private System.Windows.Forms.ToolStrip MainTools;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 注销ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用户管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用户添加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用户列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 配电室管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设备管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 状态查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
    }
}

