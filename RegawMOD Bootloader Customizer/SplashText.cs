using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RegawMOD;

namespace RegawMOD_Bootloader_Customizer
{
    public partial class SplashText : Form
    {
        public SplashText()
        {
            InitializeComponent();

            this.lines = new Dictionary<int, TextBox>();

            this.lines.Add(0, this.txtLine1);
            this.lines.Add(1, this.txtLine2);
            this.lines.Add(2, this.txtLine3);
            this.lines.Add(3, this.txtLine4);
            this.lines.Add(4, this.txtLine5);
            this.lines.Add(5, this.txtLine6);
        }

        internal void UpdateLengths(int[] lengths)
        {
            for (int i = 0; i < this.lines.Count; i++)
                this.lines[i].MaxLength = lengths[i];
        }

        internal void ClearBoxes()
        {
            foreach (TextBox t in this.lines.Values)
                t.Clear();
        }

        private Dictionary<int, TextBox> lines;

        internal string this[int i]
        {
            get { return this.lines[i].Text.PadCenter(this.lines[i].MaxLength, ' '); }
        }

        private void txtLines_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || e.KeyChar == ',')
                return;

            e.Handled = !MainForm.isOkCharacter(e.KeyChar);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SplashText_Shown(object sender, EventArgs e)
        {
            this.lines[0].Focus();
        }
    }
}