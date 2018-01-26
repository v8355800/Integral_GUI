using System;
using System.Windows.Forms;

namespace Integral_GUI
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();;
        }

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Прервать испытания и выйти?", "ИНТЕГРАЛ", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
                this.Activate();
            }   
        }

        private string CRC32(string filename)
        {
            var crc32 = new DamienG.Security.Cryptography.Crc32();
            String hash = String.Empty;

            using (System.IO.FileStream fs = System.IO.File.OpenRead(filename))
                foreach (byte b in crc32.ComputeHash(fs)) hash += b.ToString("X2");

            return hash;
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            lblCRC.Text = CRC32(Application.ExecutablePath);
            tmrTime_Tick(sender, e);
            toolStripStatusLabel2.Text = @"Универсальная плата согласования (0xD100)";
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
        }
    }
}
