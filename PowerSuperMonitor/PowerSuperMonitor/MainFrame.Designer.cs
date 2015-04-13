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
            this.MySkin = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.btn_changeskin = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.用户管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看所有ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MySkin
            // 
            this.MySkin.SerialNumber = "";
            this.MySkin.SkinFile = null;
            // 
            // btn_changeskin
            // 
            this.btn_changeskin.Location = new System.Drawing.Point(479, 50);
            this.btn_changeskin.Name = "btn_changeskin";
            this.btn_changeskin.Size = new System.Drawing.Size(75, 23);
            this.btn_changeskin.TabIndex = 2;
            this.btn_changeskin.Text = "更换皮肤";
            this.btn_changeskin.UseVisualStyleBackColor = true;
            this.btn_changeskin.Click += new System.EventHandler(this.btn_changeskin_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.用户管理ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1030, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 655);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1030, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1030, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // 用户管理ToolStripMenuItem
            // 
            this.用户管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加用户ToolStripMenuItem,
            this.查看所有ToolStripMenuItem});
            this.用户管理ToolStripMenuItem.Name = "用户管理ToolStripMenuItem";
            this.用户管理ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.用户管理ToolStripMenuItem.Text = "用户管理";
            // 
            // 添加用户ToolStripMenuItem
            // 
            this.添加用户ToolStripMenuItem.Name = "添加用户ToolStripMenuItem";
            this.添加用户ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.添加用户ToolStripMenuItem.Text = "添加用户";
            // 
            // 查看所有ToolStripMenuItem
            // 
            this.查看所有ToolStripMenuItem.Name = "查看所有ToolStripMenuItem";
            this.查看所有ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.查看所有ToolStripMenuItem.Text = "查看所有";
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 677);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn_changeskin);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainFrame";
            this.Text = "PowerSuperMonitor";
            this.Shown += new System.EventHandler(this.MainFrame_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunisoft.IrisSkin.SkinEngine MySkin;
        private System.Windows.Forms.Button btn_changeskin;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem 用户管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加用户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看所有ToolStripMenuItem;
    }
}

