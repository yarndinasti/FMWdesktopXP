using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.OleDb;

namespace FindMyWaifu
{
    public partial class MainFrm : Form
    {
        bool close = false;
        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == false)
            {
                DialogResult closing = MessageBox.Show("Are you Sure close this app?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (closing == DialogResult.Yes)
                {
                    close = true;
                    this.Close();
                }
                e.Cancel = true;
            }
            else
            {
                Application.Exit();
            }
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            Config.CreateConfig();
            statusData.Text = "Count: " + Config.CountData.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new SettingsFrm().ShowDialog();
        }
    }
}
