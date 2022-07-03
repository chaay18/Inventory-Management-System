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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Chaimae Moumni\Desktop\GestionStock\Database1.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (Email.Text == "" || Password.Text == "" || Role.Text == "")
            {
                MessageBox.Show("Veuillez renseigner les champs vides !!");
            }
            else
            {
                  cmd = new SqlCommand("SELECT * FROM Utilisateur WHERE Email=@Email AND Password=@Password", conn);
                  cmd.Parameters.AddWithValue("@Email", Email.Text);
                  cmd.Parameters.AddWithValue("@Password", Password.Text);
   
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
               
                    if (dr.HasRows)
                    {
                       if (Role.Text == "ADMINISTRATEUR" && dr["Fct"].ToString() == "Administrateur")
                       {
                        MessageBox.Show("La Connexion est bien etablit");
                        Menu menu = new Menu();
                        menu.Show();
                        this.Hide();
                       }
                      else if (Role.Text == "CAISSIER" && dr["Fct"].ToString() == "Caissier")
                     {
                        MessageBox.Show("La Connexion est bien etablit");
                        ProduitForm Prod = new ProduitForm();
                        Prod.Show();
                        this.Hide();
                    }
                    else if (Role.Text == "AGENT LIVRAISON" && dr["Fct"].ToString() == "Agent De Livraison")
                    {
                        MessageBox.Show("La Connexion est bien etablit");
                        livraison liv = new livraison();
                        liv.Show();
                        this.Hide();
                    }
                    else { MessageBox.Show("Veuillez choisir le role adequat"); }
                }

                    else { MessageBox.Show("Email ou password incorrect"); }
                conn.Close();
            }
        }
    }
}
