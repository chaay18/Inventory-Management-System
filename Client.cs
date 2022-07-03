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
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Chaimae Moumni\Desktop\GestionStock\Database1.mdf;Integrated Security=True");

        private void populate()
        {
            //conn.Open();
            string query = "select * from Client";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DataGridView1.DataSource = ds.Tables[0];
            // conn.Close();
        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void customerButton1_Click(object sender, EventArgs e)
        {

        }

        private void customerButton3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProduitForm prod = new ProduitForm();
            prod.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            categoForm prod = new categoForm();
            prod.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CommandeForm prod = new CommandeForm();
            prod.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Client prod = new Client();
            prod.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Nom.Text == "" && Prenom.Text == "" && Email.Text == "" && NumTel.Text == ""  && NumTel.Text == "" )

                    MessageBox.Show(this, "Veuillez remplir le(s) champ(s) vide(s)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    conn.Open();
                    string query = "insert into Client (Nom,Prenom,Adresse,NumTel)  values('" + Nom.Text + "','" + Prenom.Text + "','" + Email.Text + "','" + NumTel.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    populate();
                    MessageBox.Show("Client ajoute avec succes.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Id.Text == "")

                {
                    MessageBox.Show("Sélectionnez le client à supprimer");
                }
                else
                {
                    conn.Open();
                    string query = "delete from Client where Id =" + Id.Text + " ";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Client supprimé avec succès ");
                    conn.Close();
                    populate();
                    Nom.Text = "";
                    Prenom.Text = "";
                    Email.Text = "";
                    NumTel.Text = "";
                  


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {

                if (Nom.Text == "" && Prenom.Text == "" && Email.Text == "" && NumTel.Text == "" )

                    MessageBox.Show(this, "Veuillez Selectionner le client  à modifier ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    int selectedIndex = DataGridView1.SelectedRows[0].Index;
                    int rowID = int.Parse(DataGridView1.Rows[selectedIndex].Cells["Id"].Value.ToString());
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update [Client] set Nom = '" + Nom.Text + "' ,  Prenom = '" + Prenom.Text + "', Adresse = '" + Email.Text + "' , NumTel = '" + NumTel.Text + "'  where Id = '" + rowID + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Client Modifiè avec succès ");
                    conn.Close();
                    populate();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int SelectedRow = 0;
            SelectedRow = e.RowIndex;
            if (SelectedRow != -1)
            {

                DataGridViewRow row = DataGridView1.Rows[SelectedRow];
                Id.Text = row.Cells["Id"].Value.ToString();
                Nom.Text = row.Cells["Nom"].Value.ToString();
                Prenom.Text = row.Cells["Prenom"].Value.ToString();
                Email.Text = row.Cells["Adresse"].Value.ToString();
                NumTel.Text = row.Cells["NumTel"].Value.ToString();
               



            }
        }

        private void customerButton4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void customerButton6_Click(object sender, EventArgs e)
        {
            Menu mn = new Menu();
            mn.Show();
            this.Hide();
        }
    }
}
