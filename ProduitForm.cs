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
namespace GestionStock
{
    public partial class ProduitForm : Form
    {
        public ProduitForm()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Chaimae Moumni\Desktop\GestionStock\Database1.mdf;Integrated Security=True");
        private void populate()
        {
            //con.Open();
            string query = "select * from Produit";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DataGridView1.DataSource = ds.Tables[0];
           // con.Close();
        }



        void fillCombo()
        {
            string query = "select Nom from Categori";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            conn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "Categori");
            CatCb.DisplayMember = "Nom";
            CatCb.ValueMember = "Nom";
            CatCb.DataSource = ds.Tables["Categori"];


        }
        private void ProduitForm_Load(object sender, EventArgs e)
        {
            fillCombo();
            populate();

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Id.Text == "")

                {
                    MessageBox.Show("Sélectionnez la catégorie à supprimer");
                }
                else
                {
                   // con.Open();
                    string query = "delete from Produit where Id =" + Id.Text + " ";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Produit supprimé avec succès ");
                  //  con.Close();
                    populate();
                    Prix.Text = "";
                    Marque.Text = "";
                    Quantite.Text = "";
                    Description.Text = "";
                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = DataGridView1.SelectedRows[0].Index;
                int rowID = int.Parse(DataGridView1.Rows[selectedIndex].Cells["Id"].Value.ToString());

               // con.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update [Produit] set Marque = '" + Marque.Text + "' ,  Prix = '" + Prix.Text + "', Quantite = '" + Quantite.Text + "' , DateStock = '" + DateStock.Text + "' , Description = '" + Description.Text + "',  Categorie = '" + CatCb.Text + "' where Id = '" + rowID + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Produit Modifiè avec succès ");

                // con.Close();
                populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }
   


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Prix.Text == "" && Marque.Text == "" && Quantite.Text == "" )

                    MessageBox.Show(this, "Veuillez remplir le(s) champ(s) vide(s)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // conn.Open();
                else
                { 
                string query = "insert into Produit (Marque,Prix,Quantite,DateStock,Description,Categorie)  values('" + Marque.Text + "','" + Prix.Text + "','" + Quantite.Text + "','" + DateStock.Text + "','" + Description.Text + "','" + CatCb.SelectedValue.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Le Produit a été bien ajouté");
                populate();
                    // conn.Close();
                }
                populate();
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2HtmlLabel9_Click(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int SelectedRow = 0;
            SelectedRow = e.RowIndex;
            if (SelectedRow != -1)
            {

                DataGridViewRow row = DataGridView1.Rows[SelectedRow];
                Id.Text = row.Cells["Id"].Value.ToString();
                Prix.Text = row.Cells["Prix"].Value.ToString();
                Marque.Text = row.Cells["Marque"].Value.ToString();
                Quantite.Text = row.Cells["Quantite"].Value.ToString();
                Description.Text = row.Cells["Description"].Value.ToString();
                CatCb.Text = row.Cells["Categorie"].Value.ToString();



            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            categoForm prod = new categoForm();
            prod.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProduitForm prod = new ProduitForm();
            prod.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CommandeForm prod = new CommandeForm();
            prod.Show();
            //this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Client prod = new Client();
            prod.Show();
            this.Hide();
        }

        private void customerButton4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void customerButton6_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            m.Show();
            this.Hide();
        }
    }
}
