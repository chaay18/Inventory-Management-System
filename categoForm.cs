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
    public partial class categoForm : Form
    {
        public categoForm()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Chaimae Moumni\Desktop\GestionStock\Database1.mdf;Integrated Security=True");





        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void populate()
        {
            con.Open();
            string query = "select * from Categori";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "insert into Categori (Numero,Nom)  values(" + TextBoxIdCat.Text + ",'" + TextBoxCat.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery(); 
                MessageBox.Show("La categorie a été bien ajouté"); 
                con.Close();
                populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            populate();

        }
      
     

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBoxIdCat.Text == "")

                {
                    MessageBox.Show("Sélectionnez la catégorie à supprimer");
                }
                else
                {
                    con.Open();
                    string query = "delete from Categori where Id =" + TextBoxIdCat.Text + " ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Catégorie supprimée avec succès ");
                    con.Close();
                    populate();
                    TextBoxIdCat.Text = "";
                    TextBoxCat.Text = "";
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

                TextBoxIdCat.Text = row.Cells["Id"].Value.ToString();
                TextBoxCat.Text = row.Cells["Nom"].Value.ToString();
                
            }
        }
       

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = DataGridView1.SelectedRows[0].Index;
                int rowID = int.Parse(DataGridView1.Rows[selectedIndex].Cells["Id"].Value.ToString());

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update [Categori] set Nom = '" + TextBoxCat.Text + "' where Id = '" + rowID + "'";
                cmd.ExecuteNonQuery();

                con.Close();
                populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      void fillCombo()
        {
            //this method will bind the comboBox with the DB
            con.Open();
            SqlCommand cmd = new SqlCommand(" select Nom from Categorie  ", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Nom", typeof(string));
            dt.Load(rdr);
            guna2ComboBox2.ValueMember = "Nom";
            guna2ComboBox2.DataSource = dt;
            con.Close();


        }
       
        private void categoForm_Load(object sender, EventArgs e)
        {
            populate();
            fillCombo();
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
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
            CaissierForm Cai = new CaissierForm();
            Cai.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            categoForm prod = new categoForm();
            prod.Show();
            this.Hide();
        }

        private void customerButton4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            CommandeForm cf = new CommandeForm();
            cf.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Client cl = new Client();
            cl.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ProduitForm p = new ProduitForm();
            p.Show();
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


