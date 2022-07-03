using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionStock
{
    public partial class Acceuil : Form
    {
        public Acceuil()
        {
            InitializeComponent();
        }
        int start=0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            start += 1;
            Progressbar.Value = start;
            if (Progressbar.Value == 100)
            {
                Progressbar.Value = 0;
                timer1.Stop();
                Form1 login = new Form1();
                this.Hide();
                login.Show();
            }
        }

        private void Acceuil_Load(object sender, EventArgs e)
        {
            timer1.Start();
          
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
