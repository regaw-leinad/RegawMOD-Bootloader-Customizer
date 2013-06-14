using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Ionic.Zip;
using Ionic.Zlib;

namespace RegawMOD_Bootloader_Customizer
{
    public partial class MainForm
    {
        /// <summary>
        /// To write S-ON
        /// </summary>
        private const string S_ON = "S-ON\0";
        /// <summary>
        /// Output dialog message after building zip
        /// </summary>
        private const string COMPLETE = "{0}.zip Details:\n\nPath:  {1}\nBanner Text:  {2}\nShow S-ON:  {3}\nHboot Version:  {4}\nBuild Date/Time Update:  {5}" + 
                                        "\nHide Disclaimer:  {6}\nCustom Disclaimer:  {7}";

        private ASCIIEncoding encoding = new ASCIIEncoding();

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (this.current.DEVELOPER_NAME != "regaw_leinad")
                MessageBox.Show("Make sure to use plugins only from developers you trust!", "RegawMOD Bootloader Customizer - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (this.sfDialog.ShowDialog() == DialogResult.OK)
            {
                bool goodZip;
                byte[] hbootImageBytes, androidInfoBytes, bannerBytes, securityBytes, versionBytes, dateTimeBytes, disclaimerBytes;
                int failCounter;
                string tmpExtract = "";

                goodZip = false;
                failCounter = 0;

                while (!goodZip)
                {
                    if (failCounter == 10)
                    {
                        MessageBox.Show("Error Creating Zip", "Zip Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Get hboot image and android-info.txt from plugin's stream
                    hbootImageBytes = new byte[this.current.HBOOT_IMAGE.Length];
                    this.current.HBOOT_IMAGE.Read(hbootImageBytes, 0, hbootImageBytes.Length);

                    androidInfoBytes = new byte[this.current.ANDROID_INFO.Length];
                    this.current.ANDROID_INFO.Read(androidInfoBytes, 0, androidInfoBytes.Length);

                    using (MemoryStream m = new MemoryStream(hbootImageBytes, true))
                    {
                        if (this.current.ALLOW_CHANGE_BANNER_TEXT)
                        {
                            // Get bytes for the Banner Text padded right w/ 0x00 to LENGTH_MAX_BANNER_TEXT, then write to hboot image
                            bannerBytes = encoding.GetBytes(this.txtBanner.Text.PadRight(this.current.LENGTH_MAX_BANNER_TEXT, '\0'));
                            m.Seek(this.current.OFFSET_BANNER_TEXT_START, SeekOrigin.Begin);
                            m.Write(bannerBytes, 0, bannerBytes.Length);
                        }

                        if (this.current.ALLOW_CHANGE_S_OFF_TEXT && this.cbSOn.Checked)
                        {
                            // Get bytes of S-ON followed by 0x00 then write to hboot image
                            securityBytes = encoding.GetBytes(S_ON);
                            m.Seek(this.current.OFFSET_S_OFF_TEXT_START, SeekOrigin.Begin);
                            m.Write(securityBytes, 0, securityBytes.Length);
                        }

                        if (this.current.ALLOW_CHANGE_MINOR_VERSION_NUMBER_TEXT && this.cbVersion.Checked)
                        {
                            // Get bytes of version # padded right to 4 w/ 0x00 then write to hboot image
                            versionBytes = encoding.GetBytes(this.txtVersion.Text.PadRight(4, '\0'));
                            m.Seek(this.current.OFFSET_MINOR_VERSION_TEXT_START, SeekOrigin.Begin);
                            m.Write(versionBytes, 0, versionBytes.Length);
                        }

                        if (this.current.ALLOW_CHANGE_BUILD_DATE_TIME && this.cbUpdateDateTime.Checked)
                        {
                            // Get bytes of DateTime.Now.ToString(), make sure length is good, then write to hboot image
                            dateTimeBytes = encoding.GetBytes(DateTime.Now.ToString(this.current.FORMAT_DATE_TIME_DISPLAY));
                            if (dateTimeBytes.Length != this.current.LENGTH_MAX_DATE_TIME)
                            {
                                MessageBox.Show("Error Setting Build Date/Time Stamp", "RegawMOD Bootloader Customizer - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            m.Seek(this.current.OFFSET_DATE_TIME_TEXT_START, SeekOrigin.Begin);
                            m.Write(dateTimeBytes, 0, dateTimeBytes.Length);
                        }

                        if (this.current.ALLOW_CHANGE_HTC_DEVELOPMENT_DISCLAIMER)
                        {
                            if (this.cbHideDisclaimer.Checked)
                            {
                                // Loop through all lines in HTC Development Disclaimer
                                // Pad Bytes Right w/ 0x00 to LENGTHS_MAX_HTC_DEVELOPMENT_DISCLAIMER[i]
                                // Then write to hboot image
                                for (int i = 0; i < this.current.OFFSETS_HTC_DEVELOPMENT_DISCLAIMER.Length; i++)
                                {
                                    disclaimerBytes = encoding.GetBytes(String.Empty.PadRight(this.current.LENGTHS_MAX_HTC_DEVELOPMENT_DISCLAIMER[i], '\0'));
                                    m.Seek(this.current.OFFSETS_HTC_DEVELOPMENT_DISCLAIMER[i], SeekOrigin.Begin);
                                    m.Write(disclaimerBytes, 0, disclaimerBytes.Length);
                                }
                            }
                            else if (this.cbCustomDisclaimer.Checked)
                            {
                                // Loop through all lines in HTC Development Disclaimer
                                // Get Bytes from this.splashText[i]
                                // Then write to hboot image
                                for (int i = 0; i < this.current.OFFSETS_HTC_DEVELOPMENT_DISCLAIMER.Length; i++)
                                {
                                    disclaimerBytes = encoding.GetBytes(this.splashText[i]);
                                    m.Seek(this.current.OFFSETS_HTC_DEVELOPMENT_DISCLAIMER[i], SeekOrigin.Begin);
                                    m.Write(disclaimerBytes, 0, disclaimerBytes.Length);
                                }
                            }
                        }
                    }

                    // Create the firmware zip
                    using (ZipFile zip = new ZipFile())
                    {
                        zip.AddEntry("hboot.img", hbootImageBytes);
                        zip.AddEntry("android-info.txt", androidInfoBytes);
                        zip.CompressionLevel = CompressionLevel.Default;
                        zip.CompressionMethod = CompressionMethod.Deflate;

                        zip.Save(this.sfDialog.FileName);
                    }

                    // Wait for .5 sec for file to appear
                    Thread.Sleep(500);

                    // Test for corruption in zip (Happened a lot in testing)
                    try
                    {
                        tmpExtract = Path.GetTempPath();

                        using (ZipFile zip = ZipFile.Read(this.sfDialog.FileName))
                            zip["hboot.img"].Extract(tmpExtract);

                        goodZip = true;
                    }
                    catch (BadReadException)
                    {
                        goodZip = false;
                    }
                    catch
                    {
                        MessageBox.Show("Error Creating Zip", "Zip Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    finally
                    {
                        File.Delete(Path.Combine(tmpExtract, "hboot.img"));
                    }
                }

                // Zip is GOOD!
                MessageBox.Show(string.Format(COMPLETE, this.current.FIRMWARE_ZIP_NAME, this.sfDialog.FileName, this.txtBanner.Text,
                    this.cbSOn.Checked ? "Yes" : "No", this.txtVersion.Text, this.cbUpdateDateTime.Checked ? "Yes" : "No",
                    this.cbHideDisclaimer.Checked ? "Yes" : "No", this.cbCustomDisclaimer.Checked ? "Yes" : "No"), this.current.FIRMWARE_ZIP_NAME + ".zip Created",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}