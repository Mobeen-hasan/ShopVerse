using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbprojtest
{
    public partial class MyProfile : Form
    {
        string usn;
        public MyProfile()
        {
            InitializeComponent();
            olddata();
        }
        public MyProfile(string a)//pass email here
        {
            InitializeComponent();
            usn = a;
            olddata();
        }

        SqlConnection con = new SqlConnection("Data Source=MOBEEN\\SQLEXPRESS;Initial Catalog=dbproj;Integrated Security=True");
        int eval = 1;
        private void label2_Click(object sender, EventArgs e)
        {
            Home hm= new Home(usn);
            hm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //CALLS A FUNCTION TO CHECK NEW DATA
            chknewdata();
            if (eval == 1)
            {
                MessageBox.Show("Profile Updated");
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
        }

        private void MyProfile_Load(object sender, EventArgs e)
        {
            string t1 = "Note\nClicking Update Profile will\nbring you back to the\nSign In";
            string t2 = " page.";
            label3.Text = t1 + t2;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            label3.Visible= false;
            label10.Visible= false;
        }


        //OLD DATA
        public void olddata()
        {
            con.Open();
            string q = "Select FirstName FROM Customer WHERE Email=@e";
            SqlCommand cmd = new SqlCommand(q,con);
            cmd.Parameters.AddWithValue("@e", usn);
            label11.Text = (string)cmd.ExecuteScalar();

            q = "Select LastName FROM Customer WHERE Email=@e";
            cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@e", usn);
            label12.Text = (string)cmd.ExecuteScalar();

            label13.Text = usn;

            q = "Select PhoneNumber FROM Customer WHERE Email=@e";
            cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@e", usn);
            label14.Text = (string)cmd.ExecuteScalar();


            q = "Select Address FROM Customer WHERE Email=@e";
            cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@e", usn);
            label15.Text = (string)cmd.ExecuteScalar();

            q = "Select PaymentMethod FROM Customer WHERE Email=@e";
            cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@e", usn);
            label16.Text = (string)cmd.ExecuteScalar();


            con.Close();
        }


        public void chknewdata()
        {
            con.Open();
            string q = "";
            SqlCommand cmd=new SqlCommand(q,con);
            if(!string.IsNullOrEmpty(textBox1.Text))
            {
                q = "UPDATE Customer SET FirstName=@i WHERE Email=@e";
                cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@e", usn);
                cmd.Parameters.AddWithValue("@i", textBox1.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                Console.WriteLine("kelo");
                q = "UPDATE Customer SET LastName=@i WHERE Email=@e";
                cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@e", usn);
                cmd.Parameters.AddWithValue("@i", textBox2.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            if (!string.IsNullOrEmpty(textBox3.Text))
            {

                string emailPattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{1,}$";

                //IF EMAIL DOESNT ALREADY EXIST
                con.Open();
                string qu = "SELECT COUNT(*) FROM Customer WHERE Email=@e";
                SqlCommand scmd = new SqlCommand(qu, con);
                scmd.Parameters.AddWithValue("@e", usn);
                int eco = (int)scmd.ExecuteScalar();
                con.Close();
                eval = 1;
                if (eco > 0)
                {
                    label17.Visible = true;
                    eval = 0;
                }

                if (!Regex.IsMatch(usn, emailPattern))
                {
                    //Console.WriteLine("Here2");
                    label18.Visible = true;
                    label18.Text = "Not valid email format. [a@g.s]";
                    eval = 0;
                }

                if (eval == 1)
                {

                    q = "UPDATE Customer SET Email=@i WHERE Email=@e";
                    cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@e", usn);
                    cmd.Parameters.AddWithValue("@i", textBox3.Text);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            if (!string.IsNullOrEmpty(textBox4.Text))
            {
                q = "UPDATE Customer SET PhoneNumber=@i WHERE Email=@e";
                cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@e", usn);
                cmd.Parameters.AddWithValue("@i", textBox4.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            if (!string.IsNullOrEmpty(textBox5.Text))
            {
                q = "UPDATE Customer SET Address=@i WHERE Email=@e";
                cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@e", usn);
                cmd.Parameters.AddWithValue("@i", textBox5.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                q = "UPDATE Customer SET PaymentMethod=@i WHERE Email=@e";
                cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@e", usn);
                cmd.Parameters.AddWithValue("@i", comboBox1.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            con.Close();
        }



    }
}
