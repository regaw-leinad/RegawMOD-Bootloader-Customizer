using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using RegawMOD.Android;

namespace RegawMOD_Bootloader_Customizer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Dictionary<string, IBootloaderPlugin> loadedPlugins;
        private IBootloaderPlugin current;
        
        private ToolStripMenuItem[] pluginMenuItems;
        private ToolStripMenuItem refreshPlugins;
        private ToolStripSeparator separator;

        private PluginInfo pluginInfo;
        private SplashText splashText;

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.SetUp();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.ReLoadPlugins();
        }

        private void SetUp()
        {
            this.loadedPlugins = new Dictionary<string, IBootloaderPlugin>();
            this.pluginInfo = new PluginInfo();
            this.splashText = new SplashText();

            this.refreshPlugins = new ToolStripMenuItem();
            this.refreshPlugins.Name = "mnuPluginRefresh";
            this.refreshPlugins.Text = "&Refresh Plugins";
            this.refreshPlugins.Click += new EventHandler(mnuPluginsRefresh_Click);

            this.separator = new ToolStripSeparator();
            this.separator.Name = "mnuSeparator";
            
            this.mnuPlugin.DropDownItems.Add(this.refreshPlugins);
            this.mnuPlugin.DropDownItems.Add(this.separator);
        }

        private void ReLoadPlugins()
        {
            this.loadedPlugins.Clear();

            this.current = null;
            
            this.ResetForm();
            
            string[] potentialPlugins = Directory.GetFiles(Application.StartupPath, "*.dll");

            if (potentialPlugins.Length == 0)
                return;

            this.bwLoadPlugins.RunWorkerAsync(potentialPlugins);
        }

        private void bwLoadPlugins_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] potentialPlugins = e.Argument as string[];

            Assembly plugin = null;
            IBootloaderPlugin temp = null;
            Dictionary<string, IBootloaderPlugin> outPut = new Dictionary<string, IBootloaderPlugin>();

            for (int i = 0; i < potentialPlugins.Length; i++)
            {
                try
                {
                    plugin = null;
                    plugin = Assembly.LoadFile(potentialPlugins[i]);
                }
                catch (NotSupportedException)
                {
                    MessageBox.Show("Error loading plugin\n\n" + Path.GetFileName(potentialPlugins[i]) + "\n\n1. Right Click on the plugin\n2. Select Properties\n3. General Tab\n4. Click the 'Unblock' button",
                        "Plugin Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                catch
                {
                    continue;
                }

                if (plugin != null)
                {
                    try
                    {
                        if (typeof(IBootloaderPlugin).IsAssignableFrom(plugin.GetTypes()[0]) && plugin.GetTypes()[0].Namespace != "BootloaderPluginTemplate")
                        {
                            temp = (IBootloaderPlugin)Activator.CreateInstance(plugin.GetTypes()[0]);

                            if (!outPut.ContainsKey(EnumHelper.GetEnumDescription((HTC_DEVICE)temp.DEVICE) + " - " + temp.BOOTLOADER_ORIG_VERSION))
                                outPut.Add(EnumHelper.GetEnumDescription((HTC_DEVICE)temp.DEVICE) + " - " + temp.BOOTLOADER_ORIG_VERSION, temp);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error loading plugin\n\n" + Path.GetFileName(plugin.Location) + 
                            "\n\nPlugin not compatable with this version of\nRegawMOD Bootloader Customizer!", 
                            "Plugin Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            e.Result = outPut;
        }

        private void bwLoadPlugins_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.loadedPlugins = e.Result as Dictionary<string, IBootloaderPlugin>;
            this.BuildPluginMenu();

            // If only one plugin exists, select it!
            if (this.loadedPlugins.Count == 1)
                this.pluginMenuItems[0].Checked = true;
        }

        private void BuildPluginMenu()
        {
            this.mnuPlugin.DropDownItems.Clear();

            this.pluginMenuItems = new ToolStripMenuItem[this.loadedPlugins.Count];

            int count = 0;

            foreach (IBootloaderPlugin b in this.loadedPlugins.Values)
            {
                this.pluginMenuItems[count] = new ToolStripMenuItem();
                this.pluginMenuItems[count].Name = "mnuPlugin" + b.DEVICE + count;
                this.pluginMenuItems[count].Text = EnumHelper.GetEnumDescription(b.DEVICE) + " - " + b.BOOTLOADER_ORIG_VERSION;
                this.pluginMenuItems[count].CheckOnClick = true;
                this.pluginMenuItems[count].Checked = false;
                this.pluginMenuItems[count].CheckedChanged += new EventHandler(PluginMenuItem_CheckedChanged);

                count++;
            }

            this.mnuPlugin.DropDownItems.Add(this.refreshPlugins);
            this.mnuPlugin.DropDownItems.Add(this.separator);
            this.mnuPlugin.DropDownItems.AddRange(this.pluginMenuItems);
        }

        private void ResetForm()
        {
            this.lblLoadedPlugin.Text = "Click HERE To Select Plugin";

            this.txtBanner.Text = "";
            this.txtBanner.Enabled = false;

            this.gbLook.Enabled = false;
            this.rbCustomLook.Checked = true;

            this.gbCustom.Enabled = false;
            this.cbSOn.Checked = false;
            this.cbVersion.Checked = false;
            this.cbUpdateDateTime.Checked = false;
            this.cbHideDisclaimer.Checked = false;
            this.cbCustomDisclaimer.Checked = false;

            this.btnCreate.Enabled = false;
        }

        private void UpdateFormBasedOnPlugin()
        {
            if (this.current == null)
                return;

            this.sfDialog.FileName = this.current.FIRMWARE_ZIP_NAME;
            
            this.lblLoadedPlugin.Text = EnumHelper.GetEnumDescription(this.current.DEVICE);
            this.lblLoadedPlugin.IsLink = true;

            this.txtBanner.Enabled = true;
            this.txtBanner.MaxLength = this.current.LENGTH_MAX_BANNER_TEXT;

            this.gbLook.Enabled = true;

            this.gbCustom.Enabled = true;
            this.cbSOn.Checked = false;
            this.cbVersion.Checked = false;
            this.txtVersion.Text = this.current.BOOTLOADER_ORIG_VERSION.Substring(this.current.BOOTLOADER_ORIG_VERSION.Length - 4);
            this.cbUpdateDateTime.Checked = false;
            this.cbHideDisclaimer.Checked = false;
            this.cbCustomDisclaimer.Checked = false;

            this.btnCreate.Enabled = true;

            this.txtBanner.Focus();

            if (!this.current.ALLOW_CHANGE_BANNER_TEXT)
            {
                this.txtBanner.Text = "*NOT EDITABLE*";
                this.txtBanner.Enabled = false;
            }

            if (!this.current.ALLOW_CHANGE_BUILD_DATE_TIME)
                this.cbUpdateDateTime.Enabled = false;

            if (!this.current.ALLOW_CHANGE_HTC_DEVELOPMENT_DISCLAIMER)
            {
                this.cbHideDisclaimer.Enabled = false;
                this.cbCustomDisclaimer.Enabled = false;
            }

            if (!this.current.ALLOW_CHANGE_MINOR_VERSION_NUMBER_TEXT)
                this.cbVersion.Enabled = false;

            if (!this.current.ALLOW_CHANGE_S_OFF_TEXT)
                this.cbSOn.Enabled = false;

            this.splashText.UpdateLengths(this.current.LENGTHS_MAX_HTC_DEVELOPMENT_DISCLAIMER);
            this.splashText.ClearBoxes();
        }

        internal static bool isOkCharacter(char test)
        {
            if (char.IsNumber(test) || char.IsLetter(test) || char.IsWhiteSpace(test) || 
                char.IsControl(test) || test == '-' || test == '*' || test == '_' ||
                test == '!' || test == '@' || test == '$' && test < 127)
                return true;

            return false;
        }

        private void ToggleStockLook(bool toggleTo)
        {
            if (toggleTo)
            {
                if (this.current.ALLOW_CHANGE_BANNER_TEXT)
                    this.txtBanner.Text = "*** LOCKED ***";

                this.cbSOn.Checked = true;
                this.cbVersion.Checked = true;
                this.txtVersion.Text = this.current.BOOTLOADER_ORIG_VERSION.Substring(this.current.BOOTLOADER_ORIG_VERSION.Length - 4);
                this.cbHideDisclaimer.Checked = true; // Custom unchecks automatically
                this.cbUpdateDateTime.Checked = false;

                this.txtBanner.Enabled = false;
                this.cbSOn.Enabled = false;
                this.cbVersion.Enabled = false;
                this.txtVersion.Enabled = false;
                this.cbUpdateDateTime.Enabled = false;
                this.cbHideDisclaimer.Enabled = false;
                this.cbCustomDisclaimer.Enabled = false;
            }
            else
            {
                if (this.current.ALLOW_CHANGE_BANNER_TEXT)
                    this.txtBanner.Text = "";

                this.cbSOn.Checked = false;
                this.cbHideDisclaimer.Checked = false;
                this.cbCustomDisclaimer.Checked = false;
                this.cbVersion.Checked = false;

                if (this.current.ALLOW_CHANGE_BANNER_TEXT)
                    this.txtBanner.Enabled = true;

                if (this.current.ALLOW_CHANGE_S_OFF_TEXT)
                    this.cbSOn.Enabled = true;

                if (this.current.ALLOW_CHANGE_MINOR_VERSION_NUMBER_TEXT)
                    this.cbVersion.Enabled = true;

                if (this.current.ALLOW_CHANGE_BUILD_DATE_TIME)
                    this.cbUpdateDateTime.Enabled = true;

                if (this.current.ALLOW_CHANGE_HTC_DEVELOPMENT_DISCLAIMER)
                {
                    this.cbHideDisclaimer.Enabled = true;
                    this.cbCustomDisclaimer.Enabled = true;
                }
            }
        }
    }
}