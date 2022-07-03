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
    public partial class CommandeForm : Form
    {
        public CommandeForm()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Chaimae Moumni\Desktop\GestionStock\Database1.mdf;Integrated Security=True");

        private void populateClient()
        {
            //conn.Open();
            string query = "select * from Client";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            guna2DataGridView1.DataSource = ds.Tables[0];
            // conn.Close();
        }
        private void populateProduit()
        {
            //conn.Open();
            string query = "select * from Produit";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            guna2DataGridView2.DataSource = ds.Tables[0];
            // conn.Close();
        }
        private void CommandeForm_Load(object sender, EventArgs e)
        {
            populateClient();
            populateProduit();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int SelectedRow = 0;
            SelectedRow = e.RowIndex;
            if (SelectedRow != -1)
            {

                DataGridViewRow row = guna2DataGridView1.Rows[SelectedRow];
                Id.Text = row.Cells["Id"].Value.ToString();
                Nom.Text = row.Cells["Nom"].Value.ToString();
                Prenom.Text = row.Cells["Prenom"].Value.ToString();

            }
            //conn.Open();
            //SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from Commande where IdClient = "+ Id.Text + "", conn);
            //DataTable dt = new DataTable();
           //sda.Fill(dt);
            //conn.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Quantite.Value) > qte)
            {
                MessageBox.Show("La quantite en stock est insuffisante !", "Attention",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Quantite.Value = Quantite.Value - 1;
                return;
            }
            int total = Convert.ToInt32(Prix.Text) * Convert.ToInt32(Quantite.Value);
            Total.Text = total.ToString();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Nom.Text = "";
            Prenom.Text = "";
            Id.Text = "";
            guna2TextBox1.Text = "";
            Marque.Text = "";
            Prix.Text = "";
            Total.Text = "";
            Date.Text = "";
            Quantite.Text = "";
        }

        int qte = 0;
        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int SelectedRow = 0;
            SelectedRow = e.RowIndex;
            if (SelectedRow != -1)
            {

                DataGridViewRow row = guna2DataGridView2.Rows[SelectedRow];
                guna2TextBox1.Text = row.Cells["Id"].Value.ToString();
                Prix.Text = row.Cells["Prix"].Value.ToString();
                Marque.Text = row.Cells["Marque"].Value.ToString();
                qte = Convert.ToInt32(row.Cells["Quantite"].Value.ToString());
                updateProd();


                //Quantite.Text = row.Cells["Quantite"].Value.ToString();
                //Description.Text = row.Cells["Description"].Value.ToString();
                //CatCb.Text = row.Cells["Categorie"].Value.ToString();


            }
        }

        int Grdtotal = 0;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int  n = 0;
            int total = Convert.ToInt32(Prix.Text) * Convert.ToInt32(Quantite.Value);
            DataGridViewRow newRow = new DataGridViewRow(); 
            newRow.CreateCells(guna2DataGridView3); 
            newRow.Cells[0].Value = n + 1;
            newRow.Cells[1].Value = Id.Text;
            newRow.Cells[2].Value = guna2TextBox1.Text;
            newRow.Cells[3].Value = Marque.Text; 
            newRow.Cells[4].Value = Prix.Text;
            newRow.Cells[5].Value = Quantite.Value.ToString(); 
            newRow.Cells[6].Value = Convert.ToInt32(Prix.Text) * Convert.ToInt32(Quantite.Value);
            guna2DataGridView3.Rows.Add(newRow);
            Grdtotal = Grdtotal + total;
            TotalCommande.Text = Grdtotal + "DHs";
            Quantite.Value = 0;
            updateProd();
            populateProduit();
        }
        void updateProd()
        {
            conn.Open();
            int newQte = qte - Convert.ToInt32(Quantite.Value);
            string query = "update Produit set Quantite = " + newQte + " where Id ="+ Convert.ToInt32(guna2TextBox1.Text) + " ; ";
            SqlCommand cm = new SqlCommand(query, conn);
            cm.ExecuteNonQuery();
            conn.Close();
            populateProduit();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

            string NomClient = Nom.Text +" "+ Prenom.Text;
            int idClient = Convert.ToInt32(Id.Text);
            int Total = Grdtotal;
            string dateC = Date.Text;
            conn.Open();
            string query = "insert into Commande (IdClient,NomClient,Date,Total)  values('" + idClient + "','" + NomClient + "','" + dateC + "','" + Total + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("La commande a été bien ajoutée");
           



        }

        int flag = 0;
        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Commande comm = new Commande();
            comm.Show();
            this.Hide();
        }
    }
}
