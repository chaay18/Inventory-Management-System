using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionStock
{
    public partial class livraison : Form
    {
        public livraison()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Chaimae Moumni\Desktop\GestionStock\Database1.mdf;Integrated Security=True");


        private void populateLiv()
        {
            //conn.Open();
            string query = "select * from Livraison";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            guna2DataGridView1.DataSource = ds.Tables[0];
            // conn.Close();
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
                IdLiv.Text = row.Cells["IdLivraison"].Value.ToString();
                IdCom.Text = row.Cells["IdCommande"].Value.ToString();
                

            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string liv = "oui";
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update [Livraison] set livraison = '" + liv + "' where IdLivraison = '" + IdLiv.Text + "'";
            cmd.ExecuteNonQuery();
            conn.Close();
            populateLiv();
        }

        private void livraison_Load(object sender, EventArgs e)
        {
            populateLiv();

        }

        private void customerButton4_Click(object sender, EventArgs e)
        {
            Form1 fo = new Form1();
            fo.Show();
            this.Hide();
        }
    }
}
