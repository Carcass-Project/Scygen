using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScygenSetup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.BackColor == Color.FromArgb(221,221,221))
            {
                this.BackColor = Color.FromArgb(56, 56, 56);
                this.ForeColor = Color.White;
                label1.Text = "need sun?";
                button1.Text = "W";
                button1.ForeColor = Color.Black;
                button1.BackColor = Color.White;
                button2.ForeColor = Color.Black;
                button3.ForeColor = Color.Black;
            }
            else
            {
                this.BackColor = Color.FromArgb(221,221,221);
                this.ForeColor = Color.Black;
                label1.Text = "eyes hurt?";
                button1.Text = "D";
                button1.ForeColor = Color.White;
                button1.BackColor = Color.FromArgb(64,64,64);
                button2.ForeColor = Color.Black;
                button2.BackColor = Color.White;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var res = InstallChooser.ShowDialog();
            if(res == DialogResult.OK)
            {
                textBox1.Text = InstallChooser.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
