using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbprojtest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=MOBEEN\\SQLEXPRESS;Initial Catalog=dbproj;Integrated Security=True");
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)//SignIn
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                label12.Visible = true;
                //Home hm = new Home(textBox1.Text);//pass the user to home
                //hm.Show();
                //this.Hide();
            }
            else// if there is any text
            {
                label12.Visible=false;
                con.Open();
                string em = textBox1.Text;
                string pa= textBox2.Text;
                int emc = 0;
               

              



                if (button5.BackColor == Color.Tomato)//pressed
                {
                    string query = "SELECT COUNT(*) FROM Customer WHERE email=@email and password=@pas";
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@email", em);
                    command.Parameters.AddWithValue("@pas", pa);
                    emc = (int)command.ExecuteScalar();
                    command.ExecuteNonQuery();
                    command.Dispose();
                    if (emc == 0)
                    {
                        label13.Visible = true;
                    }
                    else
                    {
                        Home hm = new Home(textBox1.Text);//pass the user to home
                        hm.Show();
                        this.Hide();
                    }
                }
                else if (button4.BackColor == Color.Tomato)//pressed
                {
                    string query = "SELECT COUNT(*) FROM Seller WHERE email=@email and password=@pas";
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@email", em);
                    command.Parameters.AddWithValue("@pas", pa);
                    emc = (int)command.ExecuteScalar();
                    command.ExecuteNonQuery();
                    command.Dispose();
                    if (emc == 0)
                    {
                        label13.Visible = true;
                    }
                    else
                    {
                        SellerHome shm = new SellerHome(textBox1.Text);//pass the user to home
                        shm.Show();
                        this.Hide();
                    }
                }
                else if(button3.BackColor == Color.Tomato)
                {
                    if(textBox1.Text=="admin" && textBox2.Text == "1")
                    {
                        Form21 f21 = new Form21();
                        f21.Show();
                        this.Hide();
                    }
                    else
                    {
                        label13.Visible = true;
                    }

                    
                }
                else
                {
                    label12.Visible = true;
                    label12.Text = "    Please select Account Type";
                }

                

                con.Close();

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (button3.BackColor == SystemColors.ControlLightLight)
            {
                button3.BackColor = Color.Tomato;

                if(button4.BackColor==Color.Tomato)
                {
                    button4.BackColor = SystemColors.ControlLightLight;
                    button4.ForeColor = Color.Black;
                }
                if (button5.BackColor == Color.Tomato)
                {
                    button5.BackColor = SystemColors.ControlLightLight;
                    button5.ForeColor = Color.Black;
                }

                button3.ForeColor = Color.White;

            }
            else
            {
                button3.BackColor = SystemColors.ControlLightLight;
                button3.ForeColor = Color.Black;
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            if (button5.BackColor == SystemColors.ControlLightLight)
            {
                button5.BackColor = Color.Tomato;

                if (button3.BackColor == Color.Tomato)
                {
                    button3.BackColor = SystemColors.ControlLightLight;
                    button3.ForeColor = Color.Black;
                }
                if (button4.BackColor == Color.Tomato)
                {
                    button4.BackColor = SystemColors.ControlLightLight;
                    button4.ForeColor = Color.Black;
                }
                button5.ForeColor = Color.White;

            }
            else
            {
                button5.BackColor = SystemColors.ControlLightLight;
                button5.ForeColor = Color.Black;
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.BackColor == SystemColors.ControlLightLight)
            {
                button4.BackColor = Color.Tomato;

                if (button3.BackColor == Color.Tomato)
                {
                    button3.BackColor = SystemColors.ControlLightLight;
                    button3.ForeColor = Color.Black;
                }
                if (button5.BackColor == Color.Tomato)
                {
                    button5.BackColor = SystemColors.ControlLightLight;
                    button5.ForeColor = Color.Black;
                }
                button4.ForeColor = Color.White;
            }
            else
            {
                button4.BackColor = SystemColors.ControlLightLight;
                button4.ForeColor = Color.Black;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignUp su = new SignUp();
            su.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            SignUp su = new SignUp();
            su.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            SellerSignUp ssu=new SellerSignUp();
            ssu.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
