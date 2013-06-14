using System;
using System.Windows.Forms;

namespace RegawMOD_Bootloader_Customizer
{
    public partial class MainForm
    {
        private void PluginMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem t = (ToolStripMenuItem)sender;

            if (t.Checked)
            {
                //Uncheck others first
                for (int i = 0; i < this.pluginMenuItems.Length; i++)
                    if (this.pluginMenuItems[i].Checked && this.pluginMenuItems[i].Text != t.Text)
                        this.pluginMenuItems[i].Checked = false;

                //this.current = this.FindPlugin(t.Text);
                this.current = loadedPlugins[t.Text];

                //MessageBox.Show(t.Text);

                this.UpdateFormBasedOnPlugin();
            }
            else
            {
                this.ResetForm();
            }
        }

        private void mnuPluginsRefresh_Click(object sender, EventArgs e)
        {
            this.ReLoadPlugins();
        }

        private void cbHideDisclaimer_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbHideDisclaimer.Checked)
                this.cbCustomDisclaimer.Checked = false;
        }

        private void cbCustomDisclaimer_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbCustomDisclaimer.Checked)
            {
                this.cbHideDisclaimer.Checked = false;

                if (this.splashText.ShowDialog() != DialogResult.OK)
                    this.cbCustomDisclaimer.Checked = false;
            }
        }

        private void rbStockLook_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = (RadioButton)sender;

            if (r.Text == "Stock" && r.Checked && (!this.current.ALLOW_CHANGE_BANNER_TEXT || !this.current.ALLOW_CHANGE_HTC_DEVELOPMENT_DISCLAIMER || !this.current.ALLOW_CHANGE_S_OFF_TEXT))
            {
                string disabledPerms = "";

                if (!this.current.ALLOW_CHANGE_BANNER_TEXT)
                    disabledPerms += "-Change Banner Text\n";

                if (!this.current.ALLOW_CHANGE_HTC_DEVELOPMENT_DISCLAIMER)
                    disabledPerms += "-Change HTC Disclaimer\n";

                if (!this.current.ALLOW_CHANGE_S_OFF_TEXT)
                    disabledPerms += "-Change S-OFF Text";

                this.rbCustomLook.Checked = true;

                MessageBox.Show(string.Format("Can not select 'Stock' look.\nPlugin developer {0}\nhas the following permissions disabled:\n\n{1}", this.current.DEVELOPER_NAME, disabledPerms),
                    "RegawMOD Bootloader Customizer - Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.ToggleStockLook(this.rbStockLook.Checked);
            }
        }

        private void cbVersion_CheckedChanged(object sender, EventArgs e)
        {
            this.txtVersion.Enabled = this.cbVersion.Checked;
        }

        private void lblLoadedPlugin_Click(object sender, EventArgs e)
        {
            ToolStripLabel t = (ToolStripLabel)sender;

            if (t.Text == "Click HERE To Select Plugin")
            {
                this.mnuPlugin.ShowDropDown();
                return;
            }
            else
            {
                this.pluginInfo.UpdateData(this.current);
                this.pluginInfo.ShowDialog();
            }
        }

        private void txtBanner_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !isOkCharacter(e.KeyChar);
        }

        private void txtVersion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuFileCreate_Click(object sender, EventArgs e)
        {
            this.btnCreate.PerformClick();
        }

        private void mnuHelpAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This tool is open to all HTC Devices that either have S-OFF or the ability to flash unsigned firmware packages.\n\nDan Wager (regaw_leinad)",
                "RegawMOD Bootloader Customizer v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " - About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}