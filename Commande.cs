using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
namespace GestionStock
{
    public partial class Commande : Form
    {
        public Commande()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Chaimae Moumni\Desktop\GestionStock\Database1.mdf;Integrated Security=True");

        void populateCommande()
        {
            //conn.Open();
            string query = "select * from Commande";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            guna2DataGridView1.DataSource = ds.Tables[0];
            // conn.Close();
        }

        int flag = 0;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
            //{
                //printDocument1.Print();
            //}
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Commande_Load(object sender, EventArgs e)
        {
            populateCommande();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int SelectedRow = 0;
            SelectedRow = e.RowIndex;
            if (SelectedRow != -1)
            {

                DataGridViewRow row = guna2DataGridView1.Rows[SelectedRow];
                IdComm.Text = row.Cells["IdCommande"].Value.ToString();
                IdClient.Text = row.Cells["IdClient"].Value.ToString();
                nom.Text = row.Cells["NomClient"].Value.ToString();
                Date.Text = row.Cells["Date"].Value.ToString();
                totalTextBox.Text = row.Cells["Total"].Value.ToString();

            }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            e.Graphics.DrawString("Facture", new Font("Century", 25, FontStyle.Bold), Brushes.Red, new Point(250) );
            e.Graphics.DrawString("Id de la Commande: "+ IdComm.Text, new Font("Century", 25, FontStyle.Bold), Brushes.Black, new Point(100, 150));
            e.Graphics.DrawString("Id du Client: "+IdClient.Text, new Font("Century", 25, FontStyle.Bold), Brushes.Black, new Point(100,250));
            e.Graphics.DrawString("Nom du Client: "+ nom.Text, new Font("Century", 25, FontStyle.Bold), Brushes.Black, new Point(100, 350));
            e.Graphics.DrawString("Date de la Commande: " + Date.Text, new Font("Century", 25, FontStyle.Bold), Brushes.Black, new Point(100, 450));
            e.Graphics.DrawString("Montant Total : " + totalTextBox.Text, new Font("Century", 25, FontStyle.Bold), Brushes.Red, new Point(100, 550));
        }



        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            IdComm.Text = " ";
            IdClient.Text = " ";
            nom.Text = " ";
            Date.Text = " ";
            totalTextBox.Text = " ";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string livraison = "non";
            int idCommande = Convert.ToInt32(IdComm.Text);
            conn.Open();
            string query = "insert into Livraison (IdCommande,livraison)  values('" + idCommande + "','" + livraison + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("La livraison a été bien affectée");
        }

        private void customerButton4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            CommandeForm CF = new CommandeForm();
            CF.Show();
            this.Hide();
        }
    }
}
