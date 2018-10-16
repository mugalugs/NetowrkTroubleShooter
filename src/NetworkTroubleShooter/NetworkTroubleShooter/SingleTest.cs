using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NetworkTroubleshooter
{
    public partial class SingleTest : Form
    {
        public string TestName { get; set; }
        public string Param { get; set; }

        public SingleTest()
        {
            InitializeComponent();

            testsComboBox.Items.Add("Ping");
            testsComboBox.Items.Add("DNS");
            testsComboBox.Items.Add("HTTP");
            testsComboBox.Items.Add("Proxy");
            testsComboBox.Items.Add("PAC");
            testsComboBox.SelectedIndex = 0;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            TestName = testsComboBox.SelectedItem.ToString();
            Param = paramTextBox.Text.Trim();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
