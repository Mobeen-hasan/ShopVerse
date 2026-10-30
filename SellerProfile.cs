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
using System.Web;

namespace dbprojtest
{
    public partial class SellerProfile : Form
    {
        string susn;
        public SellerProfile()
        {
            InitializeComponent();
        }
        public SellerProfile(string a)
        {
            InitializeComponent();
            susn = a;
        }
        SqlConnection connect = new SqlConnection("Data Source=MOBEEN\\SQLEXPRESS;Initial Catalog=dbproj;Integrated Security=True");

        //Back butto------------------------------------
        private void label2_Click(object sender, EventArgs e)
        {
            SellerHome shm = new SellerHome(susn);
            shm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            connect.Open();
            string query = "SELECT sellerid from seller where email=@e";

            SqlCommand cmd = new SqlCommand(query,connect);
            cmd.Parameters.AddWithValue("@e", susn);
            string sid = cmd.ExecuteScalar().ToString();
            int i = 0;
            //name
            if(!string.IsNullOrEmpty(textBox1.Text))
            {
                query = "Update seller set name=@n where sellerid=@sid";
                cmd=new SqlCommand(query,connect);
                cmd.Parameters.AddWithValue("@sid", sid);
                cmd.Parameters.AddWithValue("@n", textBox1.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                i = i + 1;
            }
            //storename
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                query = "Update seller set storename=@n where sellerid=@sid";
                cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@sid", sid);
                cmd.Parameters.AddWithValue("@n", textBox2.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                i = i + 1;
            }
            //storedescription
            if (!string.IsNullOrEmpty(textBox3.Text))
            {
                query = "Update seller set storedescription=@n where sellerid=@sid";
                cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@sid", sid);
                cmd.Parameters.AddWithValue("@n", textBox3.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                i = i + 1;
            }
            //email
            if (!string.IsNullOrEmpty(textBox4.Text))
            {
                query = "Update seller set email=@n where sellerid=@sid";
                cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@sid", sid);
                cmd.Parameters.AddWithValue("@n", textBox4.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                i = i + 1;
            }
            //contact
            if (!string.IsNullOrEmpty(textBox5.Text))
            {
                query = "Update seller set contactno=@n where sellerid=@sid";
                cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@sid", sid);
                cmd.Parameters.AddWithValue("@n", textBox5.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                i = i + 1;
            }
            //password
            if (!string.IsNullOrEmpty(textBox6.Text))
            {
                query = "Update seller set password=@n where sellerid=@sid";
                cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@sid", sid);
                cmd.Parameters.AddWithValue("@n", textBox6.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                i = i + 1;
            }


            connect.Close();

            if (i == 0)
            {
                MessageBox.Show("No input");
            }
            else
            {
                MessageBox.Show("Profile Updated");
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
        }

        private void SellerProfile_Load(object sender, EventArgs e)
        {
            string t1 = "Note\nClicking Update Profile will\nbring you back to the\nSign In";
            string t2 = " page.";
            label3.Text = t1 + t2;
        }
    }
}
