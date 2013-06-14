using System;
using System.Diagnostics;
using System.Windows.Forms;
using RegawMOD.Android;

namespace RegawMOD_Bootloader_Customizer
{
    public partial class PluginInfo : Form
    {
        public PluginInfo()
        {
            InitializeComponent();
        }

        LinkLabel.Link homePage = new LinkLabel.Link();
        LinkLabel.Link xdaProfile = new LinkLabel.Link();

        internal void UpdateData(IBootloaderPlugin plugin)
        {
            this.Text = "Plugin for " + EnumHelper.GetEnumDescription(plugin.DEVICE) + " - Information";

            this.lblDevice.Text = EnumHelper.GetEnumDescription(plugin.DEVICE);
            this.lblHbootVersion.Text = plugin.BOOTLOADER_ORIG_VERSION;
            this.lblFirmwareZip.Text = plugin.FIRMWARE_ZIP_NAME + ".zip";
            this.lblStockLook.Text = (plugin.ALLOW_CHANGE_BANNER_TEXT && plugin.ALLOW_CHANGE_S_OFF_TEXT && plugin.ALLOW_CHANGE_HTC_DEVELOPMENT_DISCLAIMER) ? "Yes" : "No";
            this.lblChangeBanner.Text = plugin.ALLOW_CHANGE_BANNER_TEXT ? "Yes" : "No";
            this.lblChangeSOFF.Text = plugin.ALLOW_CHANGE_S_OFF_TEXT ? "Yes" : "No";
            this.lblChangeVersion.Text = plugin.ALLOW_CHANGE_MINOR_VERSION_NUMBER_TEXT ? "Yes" : "No";
            this.lblChangeDateTime.Text = plugin.ALLOW_CHANGE_BUILD_DATE_TIME ? "Yes" : "No";
            this.lblChangeDisclaimer.Text = plugin.ALLOW_CHANGE_HTC_DEVELOPMENT_DISCLAIMER ? "Yes" : "No";

            this.txtDescription.Text = plugin.PLUGIN_DESCRIPTION;

            this.lblDeveloper.Text = plugin.DEVELOPER_NAME;
            this.lblHomePage.Links.Clear();
            this.homePage.LinkData = plugin.DEVELOPER_PERSONAL_WEBSITE;
            this.lblHomePage.Links.Add(this.homePage);
            this.lblXdaProfile.Links.Clear();
            this.xdaProfile.LinkData = @"http://forum.xda-developers.com/member.php?u=" + plugin.DEVELOPER_XDA_PROFILE_ID;
            this.lblXdaProfile.Links.Add(this.xdaProfile);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Developer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.Link.LinkData.ToString()))
                Process.Start(e.Link.LinkData.ToString());
        }
    }
}