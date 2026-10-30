using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbprojtest
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }
        int emvalid = 0;//not vlaid
        SqlConnection con = new SqlConnection("Data Source=MOBEEN\\SQLEXPRESS;Initial Catalog=dbproj;Integrated Security=True");

        string em,ad,fn,ln,pm,phn,g,pas;



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();

        }

        private void label11_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text))//fn
            {
                label10.Visible= true;
                label10.Text= "*Missing";
            }
            else
            {
                label10.Visible= false;
                fn= textBox1.Text;
            }
            if (string.IsNullOrEmpty(textBox2.Text))//ln
            {
                label12.Visible = true;
                label12.Text = "*Missing";
            }
            else
            {
                label12.Visible= false;
                ln= textBox2.Text;
            }
            if (string.IsNullOrEmpty(textBox3.Text))//email
            {
                label13.Visible = true;
                label13.Text = "*Missing";
            }
            else 
            {
                Console.WriteLine("Here");
                label13.Visible = false;
                em=textBox3.Text;
                string emailPattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{1,}$";

                //IF EMAIL DOESNT ALREADY EXIST
                con.Open();
                string qu = "SELECT COUNT(*) FROM Customer WHERE Email=@e";
                SqlCommand scmd = new SqlCommand(qu, con);
                scmd.Parameters.AddWithValue("@e", em);
                int eco=(int)scmd.ExecuteScalar();
                con.Close();

                if(eco>0)
                {
                    label21.Visible= true;
                }

                if (!Regex.IsMatch(em, emailPattern))
                {
                    Console.WriteLine("Here2");
                    label13.Visible= true;
                    label13.Text = "Not valid email format. [a@g.s]";
                }
                else
                {
                    Console.WriteLine("Here3");
                    emvalid = 1;//email valid
                }
            }
            if (string.IsNullOrEmpty(textBox4.Text))//phn
            {
                label14.Visible = true;
                label14.Text = "*Missing";
            }
            else
            {
                label14.Visible = false;
                phn= textBox4.Text;
            }
            if (string.IsNullOrEmpty(textBox5.Text))//ad
            {
                label15.Visible = true;
                label15.Text = "*Missing";
            }
            else
            {
                label15.Visible = false;
                ad= textBox5.Text;
            }
            if (string.IsNullOrEmpty(comboBox1.Text))//pm
            {
                label16.Visible = true;
                label16.Text = "*Missing";
            }
            else
            {
                label16.Visible = false;
                pm = comboBox1.Text;
            }
            if(string.IsNullOrEmpty(comboBox2.Text))//gender
            {
                label17.Visible = true;
                label17.Text = "*Missing";
            }
            else 
            {
                label17.Visible = false;
                g = comboBox2.Text;
            }
            if(string.IsNullOrEmpty(textBox6.Text))
            {
                label18.Visible = true;
                label18.Text = "*Missing";
            }
            else 
            {
                label18.Visible = false;
                pas = textBox6.Text;

                if (emvalid == 1)
                {

                    con.Open();

                    string idquery = "SELECT COUNT(*) FROM Customer";
                    SqlCommand com2 = new SqlCommand(idquery, con);
                    int idct = (int)com2.ExecuteScalar();
                    idct = idct + 1;

                    string query = "INSERT INTO Customer(CustomerID,Address,PaymentMethod,FirstName,LastName,Email,PhoneNumber,password,gender) VALUES (@id,@ad,@pm,@fn,@ln,@em,@phn,@pas,@g)";
                    SqlCommand com = new SqlCommand(query,con);

                    com.Parameters.AddWithValue("@id", idct);
                    com.Parameters.AddWithValue("@ad",ad);
                    com.Parameters.AddWithValue("@pm", pm);
                    com.Parameters.AddWithValue("@fn", fn);
                    com.Parameters.AddWithValue("@ln", ln);
                    com.Parameters.AddWithValue("@em", em);
                    com.Parameters.AddWithValue("@phn", phn);
                    com.Parameters.AddWithValue("@pas", pas);
                    com.Parameters.AddWithValue("@g", g);

                    com.ExecuteNonQuery();
                    com.Dispose();
                    con.Close();


                    MessageBox.Show("Sign up Complete\n");
                    Form1 f1 = new Form1();
                    f1.Show();
                    this.Hide();
                }
            }
        }
    }
}
