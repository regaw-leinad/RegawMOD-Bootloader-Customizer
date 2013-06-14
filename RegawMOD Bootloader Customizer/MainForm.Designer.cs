namespace RegawMOD_Bootloader_Customizer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cbCustomDisclaimer = new System.Windows.Forms.CheckBox();
            this.cbSOn = new System.Windows.Forms.CheckBox();
            this.cbHideDisclaimer = new System.Windows.Forms.CheckBox();
            this.sfDialog = new System.Windows.Forms.SaveFileDialog();
            this.lblBanner = new System.Windows.Forms.Label();
            this.gbLook = new System.Windows.Forms.GroupBox();
            this.rbCustomLook = new System.Windows.Forms.RadioButton();
            this.rbStockLook = new System.Windows.Forms.RadioButton();
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtBanner = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblLoadedPluginTitle = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLoadedPlugin = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuBar = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPlugin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.bwLoadPlugins = new System.ComponentModel.BackgroundWorker();
            this.gbCustom = new System.Windows.Forms.GroupBox();
            this.cbUpdateDateTime = new System.Windows.Forms.CheckBox();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.cbVersion = new System.Windows.Forms.CheckBox();
            this.gbLook.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.mnuBar.SuspendLayout();
            this.gbCustom.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbCustomDisclaimer
            // 
            this.cbCustomDisclaimer.AutoSize = true;
            this.cbCustomDisclaimer.Location = new System.Drawing.Point(18, 103);
            this.cbCustomDisclaimer.Name = "cbCustomDisclaimer";
            this.cbCustomDisclaimer.Size = new System.Drawing.Size(229, 18);
            this.cbCustomDisclaimer.TabIndex = 8;
            this.cbCustomDisclaimer.Text = "Custom Development Disclaimer";
            this.cbCustomDisclaimer.UseVisualStyleBackColor = true;
            this.cbCustomDisclaimer.CheckedChanged += new System.EventHandler(this.cbCustomDisclaimer_CheckedChanged);
            // 
            // cbSOn
            // 
            this.cbSOn.AutoSize = true;
            this.cbSOn.Location = new System.Drawing.Point(18, 19);
            this.cbSOn.Name = "cbSOn";
            this.cbSOn.Size = new System.Drawing.Size(89, 18);
            this.cbSOn.TabIndex = 3;
            this.cbSOn.Text = "Show S-ON";
            this.cbSOn.UseVisualStyleBackColor = true;
            // 
            // cbHideDisclaimer
            // 
            this.cbHideDisclaimer.AutoSize = true;
            this.cbHideDisclaimer.Location = new System.Drawing.Point(18, 82);
            this.cbHideDisclaimer.Name = "cbHideDisclaimer";
            this.cbHideDisclaimer.Size = new System.Drawing.Size(215, 18);
            this.cbHideDisclaimer.TabIndex = 7;
            this.cbHideDisclaimer.Text = "Hide Development Disclaimer";
            this.cbHideDisclaimer.UseVisualStyleBackColor = true;
            this.cbHideDisclaimer.CheckedChanged += new System.EventHandler(this.cbHideDisclaimer_CheckedChanged);
            // 
            // sfDialog
            // 
            this.sfDialog.DefaultExt = "zip";
            this.sfDialog.FileName = "PJ75IMG";
            this.sfDialog.Filter = "Zip File|*.zip";
            this.sfDialog.InitialDirectory = "C:\\Users\\Dan\\Documents";
            this.sfDialog.Title = "Where do you want to save the PJ75IMG.zip?";
            // 
            // lblBanner
            // 
            this.lblBanner.AutoSize = true;
            this.lblBanner.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanner.Location = new System.Drawing.Point(101, 35);
            this.lblBanner.Name = "lblBanner";
            this.lblBanner.Size = new System.Drawing.Size(120, 22);
            this.lblBanner.TabIndex = 10;
            this.lblBanner.Text = "Banner Text";
            // 
            // gbLook
            // 
            this.gbLook.Controls.Add(this.rbCustomLook);
            this.gbLook.Controls.Add(this.rbStockLook);
            this.gbLook.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLook.Location = new System.Drawing.Point(107, 109);
            this.gbLook.Name = "gbLook";
            this.gbLook.Size = new System.Drawing.Size(108, 69);
            this.gbLook.TabIndex = 13;
            this.gbLook.TabStop = false;
            this.gbLook.Text = "Look";
            // 
            // rbCustomLook
            // 
            this.rbCustomLook.AutoSize = true;
            this.rbCustomLook.Checked = true;
            this.rbCustomLook.Location = new System.Drawing.Point(22, 40);
            this.rbCustomLook.Name = "rbCustomLook";
            this.rbCustomLook.Size = new System.Drawing.Size(67, 18);
            this.rbCustomLook.TabIndex = 2;
            this.rbCustomLook.TabStop = true;
            this.rbCustomLook.Text = "Custom";
            this.rbCustomLook.UseVisualStyleBackColor = true;
            // 
            // rbStockLook
            // 
            this.rbStockLook.AutoSize = true;
            this.rbStockLook.Location = new System.Drawing.Point(22, 17);
            this.rbStockLook.Name = "rbStockLook";
            this.rbStockLook.Size = new System.Drawing.Size(60, 18);
            this.rbStockLook.TabIndex = 1;
            this.rbStockLook.Text = "Stock";
            this.rbStockLook.UseVisualStyleBackColor = true;
            this.rbStockLook.CheckedChanged += new System.EventHandler(this.rbStockLook_CheckedChanged);
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCreate.FlatAppearance.BorderSize = 2;
            this.btnCreate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCreate.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(102, 351);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(118, 37);
            this.btnCreate.TabIndex = 9;
            this.btnCreate.TabStop = false;
            this.btnCreate.Text = "Create Zip";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtBanner
            // 
            this.txtBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(30)))), ((int)(((byte)(183)))));
            this.txtBanner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBanner.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBanner.ForeColor = System.Drawing.SystemColors.Info;
            this.txtBanner.Location = new System.Drawing.Point(34, 59);
            this.txtBanner.MaxLength = 16;
            this.txtBanner.Name = "txtBanner";
            this.txtBanner.Size = new System.Drawing.Size(254, 30);
            this.txtBanner.TabIndex = 0;
            this.txtBanner.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBanner.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBanner_KeyPress);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblLoadedPluginTitle,
            this.lblLoadedPlugin});
            this.statusStrip.Location = new System.Drawing.Point(0, 406);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip.Size = new System.Drawing.Size(322, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 14;
            // 
            // lblLoadedPluginTitle
            // 
            this.lblLoadedPluginTitle.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadedPluginTitle.Name = "lblLoadedPluginTitle";
            this.lblLoadedPluginTitle.Size = new System.Drawing.Size(97, 17);
            this.lblLoadedPluginTitle.Text = "Loaded Plugin -";
            // 
            // lblLoadedPlugin
            // 
            this.lblLoadedPlugin.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadedPlugin.IsLink = true;
            this.lblLoadedPlugin.Name = "lblLoadedPlugin";
            this.lblLoadedPlugin.Size = new System.Drawing.Size(31, 17);
            this.lblLoadedPlugin.Text = "None";
            this.lblLoadedPlugin.Click += new System.EventHandler(this.lblLoadedPlugin_Click);
            // 
            // mnuBar
            // 
            this.mnuBar.BackColor = System.Drawing.SystemColors.ControlDark;
            this.mnuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuPlugin,
            this.mnuHelp});
            this.mnuBar.Location = new System.Drawing.Point(0, 0);
            this.mnuBar.Name = "mnuBar";
            this.mnuBar.Size = new System.Drawing.Size(322, 24);
            this.mnuBar.TabIndex = 15;
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileCreate,
            this.mnuFileSeparator,
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuFileCreate
            // 
            this.mnuFileCreate.Image = ((System.Drawing.Image)(resources.GetObject("mnuFileCreate.Image")));
            this.mnuFileCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuFileCreate.Name = "mnuFileCreate";
            this.mnuFileCreate.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileCreate.ShowShortcutKeys = false;
            this.mnuFileCreate.Size = new System.Drawing.Size(121, 22);
            this.mnuFileCreate.Text = "Create &Zip";
            this.mnuFileCreate.Click += new System.EventHandler(this.mnuFileCreate_Click);
            // 
            // mnuFileSeparator
            // 
            this.mnuFileSeparator.Name = "mnuFileSeparator";
            this.mnuFileSeparator.Size = new System.Drawing.Size(118, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(121, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // mnuPlugin
            // 
            this.mnuPlugin.Name = "mnuPlugin";
            this.mnuPlugin.Size = new System.Drawing.Size(58, 20);
            this.mnuPlugin.Text = "&Plugins";
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "&Help";
            // 
            // mnuHelpAbout
            // 
            this.mnuHelpAbout.Name = "mnuHelpAbout";
            this.mnuHelpAbout.Size = new System.Drawing.Size(107, 22);
            this.mnuHelpAbout.Text = "&About";
            this.mnuHelpAbout.Click += new System.EventHandler(this.mnuHelpAbout_Click);
            // 
            // bwLoadPlugins
            // 
            this.bwLoadPlugins.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwLoadPlugins_DoWork);
            this.bwLoadPlugins.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwLoadPlugins_RunWorkerCompleted);
            // 
            // gbCustom
            // 
            this.gbCustom.Controls.Add(this.cbUpdateDateTime);
            this.gbCustom.Controls.Add(this.txtVersion);
            this.gbCustom.Controls.Add(this.cbVersion);
            this.gbCustom.Controls.Add(this.cbHideDisclaimer);
            this.gbCustom.Controls.Add(this.cbSOn);
            this.gbCustom.Controls.Add(this.cbCustomDisclaimer);
            this.gbCustom.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.gbCustom.Location = new System.Drawing.Point(34, 198);
            this.gbCustom.Name = "gbCustom";
            this.gbCustom.Size = new System.Drawing.Size(254, 133);
            this.gbCustom.TabIndex = 14;
            this.gbCustom.TabStop = false;
            this.gbCustom.Text = "Custom Options";
            // 
            // cbUpdateDateTime
            // 
            this.cbUpdateDateTime.AutoSize = true;
            this.cbUpdateDateTime.Location = new System.Drawing.Point(18, 61);
            this.cbUpdateDateTime.Name = "cbUpdateDateTime";
            this.cbUpdateDateTime.Size = new System.Drawing.Size(180, 18);
            this.cbUpdateDateTime.TabIndex = 6;
            this.cbUpdateDateTime.Text = "Update Build Date/Time";
            this.cbUpdateDateTime.UseVisualStyleBackColor = true;
            // 
            // txtVersion
            // 
            this.txtVersion.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtVersion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVersion.Enabled = false;
            this.txtVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(0)))));
            this.txtVersion.Location = new System.Drawing.Point(119, 40);
            this.txtVersion.MaxLength = 4;
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(38, 15);
            this.txtVersion.TabIndex = 5;
            this.txtVersion.Text = "0000";
            this.txtVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVersion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVersion_KeyPress);
            // 
            // cbVersion
            // 
            this.cbVersion.AutoSize = true;
            this.cbVersion.Location = new System.Drawing.Point(18, 40);
            this.cbVersion.Name = "cbVersion";
            this.cbVersion.Size = new System.Drawing.Size(110, 18);
            this.cbVersion.TabIndex = 4;
            this.cbVersion.Text = "Version # - ";
            this.cbVersion.UseVisualStyleBackColor = true;
            this.cbVersion.CheckedChanged += new System.EventHandler(this.cbVersion_CheckedChanged);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(322, 428);
            this.Controls.Add(this.gbCustom);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mnuBar);
            this.Controls.Add(this.lblBanner);
            this.Controls.Add(this.gbLook);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtBanner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::RegawMOD_Bootloader_Customizer.Properties.Resources.RegawMOD;
            this.MainMenuStrip = this.mnuBar;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegawMOD Bootloader Customizer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.gbLook.ResumeLayout(false);
            this.gbLook.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.mnuBar.ResumeLayout(false);
            this.mnuBar.PerformLayout();
            this.gbCustom.ResumeLayout(false);
            this.gbCustom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbCustomDisclaimer;
        private System.Windows.Forms.CheckBox cbSOn;
        private System.Windows.Forms.CheckBox cbHideDisclaimer;
        private System.Windows.Forms.SaveFileDialog sfDialog;
        private System.Windows.Forms.Label lblBanner;
        private System.Windows.Forms.GroupBox gbLook;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtBanner;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblLoadedPluginTitle;
        private System.Windows.Forms.ToolStripStatusLabel lblLoadedPlugin;
        private System.Windows.Forms.MenuStrip mnuBar;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileCreate;
        private System.Windows.Forms.ToolStripSeparator mnuFileSeparator;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem mnuPlugin;
        private System.Windows.Forms.RadioButton rbCustomLook;
        private System.Windows.Forms.RadioButton rbStockLook;
        private System.ComponentModel.BackgroundWorker bwLoadPlugins;
        private System.Windows.Forms.GroupBox gbCustom;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.CheckBox cbVersion;
        private System.Windows.Forms.CheckBox cbUpdateDateTime;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpAbout;
    }
}

