using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionStock
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Chaimae Moumni\Desktop\GestionStock\Database1.mdf;Integrated Security=True");


        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void customerButton3_Click(object sender, EventArgs e)
        {
            CaissierForm Cai = new CaissierForm();
            Cai.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void customerButton1_Click(object sender, EventArgs e)
        {
            ProduitForm prod = new ProduitForm();
            prod.Show();
            this.Hide();
        }

        private void customerButton2_Click(object sender, EventArgs e)
        {
            categoForm prod = new categoForm();
            prod.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            string stmt = "SELECT COUNT(*) FROM Produit";
            int count = 0;
            SqlCommand cmdCount = new SqlCommand(stmt, conn);
            conn.Open();
            count = (int)cmdCount.ExecuteScalar();
            conn.Close();
            label11.Text =  ""+count;

            string stmt1 = "SELECT COUNT(*) FROM Categori";
            int count1 = 0;
            SqlCommand cmdCount1 = new SqlCommand(stmt1, conn);
            conn.Open();
            count1 = (int)cmdCount1.ExecuteScalar();
            conn.Close();
            label16.Text =  ""+count1;

            string stmt2 = "SELECT COUNT(*) FROM Utilisateur";
            int count2 = 0;
            SqlCommand cmdCount2 = new SqlCommand(stmt2, conn);
            conn.Open();
            count2 = (int)cmdCount2.ExecuteScalar();
            conn.Close();
            label12.Text =  ""+count2;

            string stmt3 = "SELECT COUNT(*) FROM Client";
            int count3 = 0;
            SqlCommand cmdCount3 = new SqlCommand(stmt3, conn);
            conn.Open();
            count3 = (int)cmdCount3.ExecuteScalar();
            conn.Close();
            label13.Text = ""+count3;

            string stmt4 = "SELECT COUNT(*) FROM Commande";
            int count4 = 0;
            SqlCommand cmdCount4 = new SqlCommand(stmt4, conn);
            conn.Open();
            count4 = (int)cmdCount4.ExecuteScalar();
            conn.Close();
            label14.Text = ""+count4;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void customerButton4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}
