using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dbprojtest
{
    public partial class Home : Form
    {
        string usn;
        int productquantity = 0;
        public Home()
        {
            InitializeComponent();
            InitializeDataGridView();
            cartamount();
        }
        public Home(string val)
        {
            InitializeComponent();
            usn = val;
            label3.Text = val;
            InitializeDataGridView();
            cartamount();
            //usn = val;
            //label3.Text = val;
        }

        SqlConnection con = new SqlConnection("Data Source=MOBEEN\\SQLEXPRESS;Initial Catalog=dbproj;Integrated Security=True");

        
        public void cartamount()
        {
            con.Open();

            //CART CREATION IF CART DOES NOT EXIST

            string q;
            SqlCommand cmd;

            q = "SELECT CustomerID FROM customer where email=@e";
            cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@e", usn);
            string id = cmd.ExecuteScalar().ToString();
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            int cartq = 0;

            q = "SELECT cartid FROM shoppingCart WHERE CustomerID=@id";
            cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@id", id);
            //int cartcheck = (int)cmd.ExecuteScalar();
            string scq = cmd.ExecuteScalar().ToString();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            
            //cart does not exist
            

            q = "SELECT COUNT(*) FROM shoppingcartdetail where cartid=@cid";
            cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@cid", scq);
            int ciq = (int)cmd.ExecuteScalar();
            label4.Text = ciq.ToString();

            con.Close();
        }






        //checking if customer has previously had a cart


        int idcart=0;
        string productName, imagePath, productPrice, productRating;
        string universalimagepath = @"C:\Users\mobee\source\repos\dbprojtest\dbprojtest\images\";
        string pname;

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            label15.SendToBack();
            label26.SendToBack();
            label17.SendToBack();
            label19.SendToBack();
            //textBox1.Width = 300;
            textBox1.Height= 50;
            textBox1.Font = new Font(textBox1.Font.FontFamily, 15);//changes height
            Console.WriteLine(panel4.Parent.Name);
            panel4.Parent= this;
            panel4.BringToFront();

            Console.WriteLine(panel5.Parent.Name);
            Console.WriteLine(panel6.Parent.Name);
            Console.WriteLine(panel7.Parent.Name);
            Console.WriteLine(panel8.Parent.Name);

            //panel6.Parent = panel3;
            label17.Text = "None";
            label18.Text = "None";//label18 is lost
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))//if textbox is not empty
            {
                label2.Visible = false;
            }
            else
            {
                label2.Visible = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        //PANEL OPENED CODES---------------------
        public void p9e()
        {
            if (panel9expand)//category
            {
                button1.BackColor= SystemColors.ScrollBar;
                timer3.Start();
                panel9.Width -= 10;
                if (panel9.Width == panel9.MinimumSize.Width)
                {
                    panel9expand = false;
                    panel9.Visible = false;
                    timer3.Stop();
                }
            }
        }
        public void p10e()
        {
            if (panel10expand)//PRICE RANGE
            {
                button2.BackColor = SystemColors.ScrollBar;
                timer4.Start();
                panel10.Width -= 10;
                if (panel10.Width == panel10.MinimumSize.Width)
                {
                    panel10expand = false;
                    panel10.Visible = false;
                    timer4.Stop();
                }
            }
        }
        public void p11e()
        {
            if (panel11expand)//RATING
            {
                button3.BackColor = SystemColors.ScrollBar;
                timer5.Start();
                panel11.Width -= 10;
                if (panel11.Width == panel11.MinimumSize.Width)
                {
                    panel11expand = false;
                    panel11.Visible = false;
                    timer5.Stop();
                }
            }
        }
        public void p12e()
        {
            if (panel12expand)//BRANDS
            {
                button4.BackColor = SystemColors.ScrollBar;
                timer6.Start();
                panel12.Width -= 10;
                if (panel12.Width == panel12.MinimumSize.Width)
                {
                    panel12expand = false;
                    panel12.Visible = false;
                    timer6.Stop();
                }
            }
        }

        //MENU-------------------------------------------------------------------   

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ///panel3.Visible = true;
            ///

            //CLOSE THE MENUS SIDEBARS SIDEBARS IF OPENED

            p9e();
            p10e();
            p11e();
            p12e();

            timer1.Start();//start the timer to get the animation effect

        }

        bool panel3expand;
        private void timer1_Tick(object sender, EventArgs e)
        {
           //if expanded
            if(panel3expand)
            {
                
                panel3.Width -= 5;
                if(panel3.Width== panel3.MinimumSize.Width)
                {
                    panel3expand = false;
                    panel3.Visible = false;
                    timer1.Stop();
                }
            }
            else
            {
                panel3.Visible = true;
                panel3.Width += 5;
                if (panel3.Width == panel3.MaximumSize.Width)
                {
                    panel3expand = true;
                    timer1.Stop();
                }
            }
        }


        //PROFILE-----------------------------------------------------------
        bool profileexpand;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if(profileexpand)
            {
                panel4.Height -= 5;
                if (panel4.Height == panel4.MinimumSize.Height)
                {
                    profileexpand = false;
                    panel4.Visible = false;
                    timer2.Stop();
                }

            }
            else
            {
                panel4.Visible = true;
                panel4.Height += 5;
                if (panel4.Height == panel4.MaximumSize.Height)
                {
                    profileexpand = true;
                    timer2.Stop();
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }


        //DATAGRIDVIEW TABLE----------------------------------------------------
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        /*
        public void InitializeDataGridView()
        {
            //dataGridView1.Columns.Clear();

            Image imgg = Image.FromFile("\"C:\\Users\\mobee\\Downloads\\352091_search_icon.png\"");
            Object[] row=new object[] { imgg };
            String i = "Iphone";
            String p = "800";
            dataGridView1.Rows.Add(row,i,p);

        }
        */

        public void gridviewsettings()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 100;

            }
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                int a = dataGridView1.Size.Width / 4;
                column.Width = 300;
            }

            dataGridView1.AllowUserToAddRows = false;
        }
        public void InitializeDataGridView()
        {
            dataGridView1.Columns.Clear();

            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Regular);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);

            // Adding Text column for Product Name
            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.HeaderText = "Product Name";
            nameColumn.Name = "ProductName";
            dataGridView1.Columns.Add(nameColumn);

            DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn();
            priceColumn.HeaderText = "Product Price";
            priceColumn.Name = "ProductPrice";
            dataGridView1.Columns.Add(priceColumn);

            DataGridViewTextBoxColumn ratingColumn = new DataGridViewTextBoxColumn();
            ratingColumn.HeaderText = "Rating Name";
            ratingColumn.Name = "RatingName";
            dataGridView1.Columns.Add(ratingColumn);

            // Adding Image column for Product Image
            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
            imgColumn.HeaderText = "Product Image";
            imgColumn.Name = "ProductImage";
            dataGridView1.Columns.Add(imgColumn);
            
            // Adding data to the DataGridView
            productName = "Apple Airpods Pro";
            string copyimgpath = universalimagepath;
            copyimgpath = copyimgpath + "Apple AirPods Pro.jpg";
            imagePath = copyimgpath;//@"C:\Users\mobee\OneDrive\Pictures\dbprojimgs\pexels-md17-4812923.jpg";
            productPrice = "249.99";
            productRating = "-";
            dataGridView1.Rows.Add(productName,productPrice,productRating ,Image.FromFile(imagePath));

            productName = "H&M Cotton T-Shirt Pack (3)";
            copyimgpath = universalimagepath;
            copyimgpath = copyimgpath + "pexels-mockupbee-221716013-12039633.jpg";
            imagePath = copyimgpath;
            //imagePath = @"C:\Users\mobee\OneDrive\Pictures\dbprojimgs\pexels-mockupbee-221716013-12039633.jpg";
            productPrice = "24.99";
            productRating = "-";
            dataGridView1.Rows.Add(productName, productPrice, productRating, Image.FromFile(imagePath));

            productName = "Instant Pot Duo 7-in-1";
            copyimgpath = universalimagepath;
            copyimgpath = copyimgpath + "pexels-taryn-elliott-9508451.jpg";
            imagePath = copyimgpath;
            //imagePath = @"C:\Users\mobee\OneDrive\Pictures\dbprojimgs\pexels-taryn-elliott-9508451.jpg";
            productPrice = "89.99";
            productRating = "-";
            dataGridView1.Rows.Add(productName, productPrice, productRating, Image.FromFile(imagePath));


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 100;
            
            }
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                int a = dataGridView1.Size.Width / 4;
                column.Width = 300;
            }
            
            dataGridView1.AllowUserToAddRows= false;

            //Console.WriteLine(dataGridView1.Size.Width);

        }

        private void label7_Click(object sender, EventArgs e)//signout button
        {
            Form1 f1=new Form1();
            f1.Show();
            this.Hide();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Click(object sender, EventArgs e)
        {
            panel9.Visible = true;
        }

        //CATEGORIES-----------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            //p9e();
            p10e();
            p11e();
            p12e();

            if(button1.BackColor==SystemColors.ScrollBar)//not opened
            {
                button1.BackColor = Color.Tomato;
            }
            else if(button1.BackColor == Color.Tomato)
            {
                button1.BackColor = SystemColors.ScrollBar;
            }

            timer3.Start();
        }

        bool panel9expand;
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (panel9expand)
            {

                panel9.Width -= 10;
                if (panel9.Width == panel9.MinimumSize.Width)
                {
                    panel9expand = false;
                    panel9.Visible = false;
                    timer3.Stop();
                }
            }
            else
            {
                panel9.Visible = true;
                panel9.Width += 10;
                if (panel9.Width == panel9.MaximumSize.Width)
                {
                    panel9expand = true;
                    timer3.Stop();
                }
            }
        }

        //PRICE RANGE------------------------------------------------------------------
        bool panel10expand;
        private void timer4_Tick(object sender, EventArgs e)
        {
            if (panel10expand)
            {

                panel10.Width -= 10;
                if (panel10.Width == panel10.MinimumSize.Width)
                {
                    panel10expand = false;
                    panel10.Visible = false;
                    timer4.Stop();
                }
            }
            else
            {
                panel10.Visible = true;
                panel10.Width += 10;
                if (panel10.Width == panel10.MaximumSize.Width)
                {
                    panel10expand = true;
                    timer4.Stop();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p9e();
            //p10e();
            p11e();
            p12e();

            if (button2.BackColor == SystemColors.ScrollBar)//not opened
            {
                button2.BackColor = Color.Tomato;
            }
            else if (button2.BackColor == Color.Tomato)
            {
                button2.BackColor = SystemColors.ScrollBar;
            }

            timer4.Start();
        }


        //RATINGS---------------------------------------------------------------------

        bool panel11expand;
        private void timer5_Tick(object sender, EventArgs e)
        {
            if (panel11expand)
            {

                panel11.Width -= 10;
                if (panel11.Width == panel11.MinimumSize.Width)
                {
                    panel11expand = false;
                    panel11.Visible = false;
                    timer5.Stop();
                }
            }
            else
            {
                panel11.Visible = true;
                panel11.Width += 10;
                if (panel11.Width == panel11.MaximumSize.Width)
                {
                    panel11expand = true;
                    timer5.Stop();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            p9e();
            p10e();
            //p11e();
            p12e();

            if (button3.BackColor == SystemColors.ScrollBar)//not opened
            {
                button3.BackColor = Color.Tomato;
            }
            else if (button3.BackColor == Color.Tomato)
            {
                button3.BackColor = SystemColors.ScrollBar;
            }


            timer5.Start();
        }


        //BRANDS-------------------------------------------------------------------------

        bool panel12expand;
        private void timer6_Tick(object sender, EventArgs e)
        {
            if (panel12expand)
            {

                panel12.Width -= 10;
                if (panel12.Width == panel12.MinimumSize.Width)
                {
                    panel12expand = false;
                    panel12.Visible = false;
                    timer6.Stop();
                }
            }
            else
            {
                panel12.Visible = true;
                panel12.Width += 10;
                if (panel12.Width == panel12.MaximumSize.Width)
                {
                    panel12expand = true;
                    timer6.Stop();
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            p9e();
            p10e();
            p11e();
            //p12e();

            if (button4.BackColor == SystemColors.ScrollBar)//not opened
            {
                button4.BackColor = Color.Tomato;
            }
            else if (button4.BackColor == Color.Tomato)
            {
                button4.BackColor = SystemColors.ScrollBar;
            }

            timer6.Start();
        }

        //private void checkBox13_CheckedChanged(object sender, EventArgs e)
        //{

        //}

        //private void checkBox12_CheckedChanged(object sender, EventArgs e)
        //{

        //}

        //private void checkBox11_CheckedChanged(object sender, EventArgs e)
        //{

        //}

        //private void checkBox10_CheckedChanged(object sender, EventArgs e)
        //{

        //}

        //private void checkBox9_CheckedChanged(object sender, EventArgs e)
        //{

        //}

        private void label18_Click(object sender, EventArgs e)
        {

        }

        //MY ORDERS-----------------------------------------------------------------
        private void label9_Click(object sender, EventArgs e)
        {
            MyOrders mo = new MyOrders(usn);
            mo.Show();
            this.Hide();
        }

        //MY PROFILE--------------------------------------------------------------
        private void label8_Click(object sender, EventArgs e)
        {
            MyProfile mp=new MyProfile(usn);
            mp.Show();
            this.Hide();
        }

        //CART-------------------------------------------------------------------
        private void panel13_Click(object sender, EventArgs e)
        {
            Cart c = new Cart(usn);
            c.Show();
            this.Hide();

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Cart c = new Cart(usn);
            c.Show();
            this.Hide();
        }

        //MINUS QUANTITY    
        private void label21_Click(object sender, EventArgs e)
        {
            //WILL NEED TO CHECK IF ANYTHIING IS SELECTED OR NOT

            int a = Int32.Parse(textBox2.Text);
            if(a>0)
            {
                a = a - 1;
                textBox2.Text = a.ToString();
            }
        }

        private void label22_Click(object sender, EventArgs e)
        {
            label29.Visible = false;
            int a = Int32.Parse(textBox2.Text);
            //HERE WE WILL HAVE TO GIVE CONDITION IF A IS LESS THAN THE QUANTITY OF THE PROD

            con.Open();
            string query = "SELECT stock FROM Product WHERE productname=@pname";
            Console.WriteLine(pname);
            SqlCommand com=new SqlCommand(query,con);
            com.Parameters.AddWithValue("@pname",pname);
            int co= (int)com.ExecuteScalar();//gets quantity value
            com.ExecuteNonQuery();
            com.Dispose();
            con.Close();

            Console.WriteLine(co);
            if (co > a)
            {
                a = a + 1;
                textBox2.Text = a.ToString();
            }
            if(co==0)
            {
                label29.Visible= true;
            }

        }

        //private void checkBox15_CheckedChanged(object sender, EventArgs e)
        //{

        //}

        //CHECKBOXES DONT OVERLAP CONDITIONS-----------------------------------------------
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (checkBox2.Checked)
                {
                    checkBox2.Checked = false;
                }
                if (checkBox3.Checked)
                {
                    checkBox3.Checked = false;
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                if (checkBox1.Checked)
                {
                    checkBox1.Checked = false;
                }
                if (checkBox3.Checked)
                {
                    checkBox3.Checked = false;
                }
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                if (checkBox2.Checked)
                {
                    checkBox2.Checked = false;
                }
                if (checkBox1.Checked)
                {
                    checkBox1.Checked = false;
                }
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                if (checkBox5.Checked)
                {
                    checkBox5.Checked = false;
                }
                if (checkBox6.Checked)
                {
                    checkBox6.Checked = false;
                }
                if (checkBox7.Checked)
                {
                    checkBox7.Checked = false;
                }
                if (checkBox8.Checked)
                {
                    checkBox8.Checked = false;
                }
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                if (checkBox4.Checked)
                {
                    checkBox4.Checked = false;
                }
                if (checkBox6.Checked)
                {
                    checkBox6.Checked = false;
                }
                if (checkBox7.Checked)
                {
                    checkBox7.Checked = false;
                }
                if (checkBox8.Checked)
                {
                    checkBox8.Checked = false;
                }
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                if (checkBox5.Checked)
                {
                    checkBox5.Checked = false;
                }
                if (checkBox4.Checked)
                {
                    checkBox4.Checked = false;
                }
                if (checkBox7.Checked)
                {
                    checkBox7.Checked = false;
                }
                if (checkBox8.Checked)
                {
                    checkBox8.Checked = false;
                }
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                if (checkBox5.Checked)
                {
                    checkBox5.Checked = false;
                }
                if (checkBox6.Checked)
                {
                    checkBox6.Checked = false;
                }
                if (checkBox4.Checked)
                {
                    checkBox4.Checked = false;
                }
                if (checkBox8.Checked)
                {
                    checkBox8.Checked = false;
                }
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                if (checkBox5.Checked)
                {
                    checkBox5.Checked = false;
                }
                if (checkBox6.Checked)
                {
                    checkBox6.Checked = false;
                }
                if (checkBox7.Checked)
                {
                    checkBox7.Checked = false;
                }
                if (checkBox4.Checked)
                {
                    checkBox4.Checked = false;
                }
            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked)
            {
                if (checkBox15.Checked)
                {
                    checkBox15.Checked = false;
                }
                if (checkBox16.Checked)
                {
                    checkBox16.Checked = false;
                }
                if (checkBox17.Checked)
                {
                    checkBox17.Checked = false;
                }
                if (checkBox18.Checked)
                {
                    checkBox18.Checked = false;
                }
            }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox15.Checked)
            {
                if (checkBox14.Checked)
                {
                    checkBox14.Checked = false;
                }
                if (checkBox16.Checked)
                {
                    checkBox16.Checked = false;
                }
                if (checkBox17.Checked)
                {
                    checkBox17.Checked = false;
                }
                if (checkBox18.Checked)
                {
                    checkBox18.Checked = false;
                }
            }
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox16.Checked)
            {
                if (checkBox15.Checked)
                {
                    checkBox15.Checked = false;
                }
                if (checkBox14.Checked)
                {
                    checkBox14.Checked = false;
                }
                if (checkBox17.Checked)
                {
                    checkBox17.Checked = false;
                }
                if (checkBox18.Checked)
                {
                    checkBox18.Checked = false;
                }
            }
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked)
            {
                if (checkBox15.Checked)
                {
                    checkBox15.Checked = false;
                }
                if (checkBox16.Checked)
                {
                    checkBox16.Checked = false;
                }
                if (checkBox14.Checked)
                {
                    checkBox14.Checked = false;
                }
                if (checkBox18.Checked)
                {
                    checkBox18.Checked = false;
                }
            }
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox18.Checked)
            {
                if (checkBox15.Checked)
                {
                    checkBox15.Checked = false;
                }
                if (checkBox16.Checked)
                {
                    checkBox16.Checked = false;
                }
                if (checkBox17.Checked)
                {
                    checkBox17.Checked = false;
                }
                if (checkBox14.Checked)
                {
                    checkBox14.Checked = false;
                }
            }
        }


        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked)
            {
                if (checkBox12.Checked)
                {
                    checkBox12.Checked = false;
                }
                if (checkBox11.Checked)
                {
                    checkBox11.Checked = false;
                }
                if (checkBox10.Checked)
                {
                    checkBox10.Checked = false;
                }
                if (checkBox9.Checked)
                {
                    checkBox9.Checked = false;
                }
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked)
            {
                if (checkBox13.Checked)
                {
                    checkBox13.Checked = false;
                }
                if (checkBox11.Checked)
                {
                    checkBox11.Checked = false;
                }
                if (checkBox10.Checked)
                {
                    checkBox10.Checked = false;
                }
                if (checkBox9.Checked)
                {
                    checkBox9.Checked = false;
                }
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked)
            {
                if (checkBox12.Checked)
                {
                    checkBox12.Checked = false;
                }
                if (checkBox13.Checked)
                {
                    checkBox13.Checked = false;
                }
                if (checkBox10.Checked)
                {
                    checkBox10.Checked = false;
                }
                if (checkBox9.Checked)
                {
                    checkBox9.Checked = false;
                }
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
            {
                if (checkBox12.Checked)
                {
                    checkBox12.Checked = false;
                }
                if (checkBox11.Checked)
                {
                    checkBox11.Checked = false;
                }
                if (checkBox13.Checked)
                {
                    checkBox13.Checked = false;
                }
                if (checkBox9.Checked)
                {
                    checkBox9.Checked = false;
                }
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
            {
                if (checkBox12.Checked)
                {
                    checkBox12.Checked = false;
                }
                if (checkBox11.Checked)
                {
                    checkBox11.Checked = false;
                }
                if (checkBox10.Checked)
                {
                    checkBox10.Checked = false;
                }
                if (checkBox13.Checked)
                {
                    checkBox13.Checked = false;
                }
            }
        }

        //ADD TO CART BUTTON --------------------------------------------------------------
        private void button6_Click(object sender, EventArgs e)
        {
            //textBox2 tell quantity
            //write query to check product quantity
            int qu = int.Parse(textBox2.Text);
            
            //Add the things in the cart through query
            if (!string.IsNullOrEmpty(pname) && qu>0)
            {
                label31.Visible = false;

                con.Open();

                //CART CREATION IF CART DOES NOT EXIST

                string q = "SELECT COUNT(*)\r\nFROM ShoppingCart";
                SqlCommand cmd=new SqlCommand(q,con);
                string cq=cmd.ExecuteScalar().ToString();
                int cartq = int.Parse(cq);
                //cartq = cartq + 1;
                cmd.ExecuteNonQuery();
                cmd.Dispose();



                q = "SELECT CustomerID FROM customer where email=@e";
                cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@e", usn);
                string id = cmd.ExecuteScalar().ToString();
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                string dat=DateTime.Now.Date.ToString("yyyy-MM-dd");

                q = "SELECT ProductID FROM product WHERE Productname=@pn";
                cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@pn", pname);
                string pid = cmd.ExecuteScalar().ToString();
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                //CHECK IF PRODUCT ALREADY EXISTS
                string scq= cartq.ToString();
                q = "SELECT COUNT(*) FROM shoppingcartdetail where productid=@pid";
                cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@pid", pid);
                int pcount = (int)cmd.ExecuteScalar();
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (pcount == 0)//if product does not exist
                {

                    q = "SELECT COUNT(*) FROM shoppingCart WHERE CustomerID=@id";
                    cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    int cartcheck = (int)cmd.ExecuteScalar();
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    scq = cartq.ToString();

                    //cart does not exist
                    if (cartcheck == 0)
                    {
                        cartq = cartq + 1;
                        scq = cartq.ToString();
                        Console.WriteLine("scq--------------->" + scq);
                        q = "INSERT INTO shoppingcart(cartID,customerid,Datecreated) VALUES (@id,@cid,@d)";
                        cmd = new SqlCommand(q, con);
                        cmd.Parameters.AddWithValue("@id", scq);
                        cmd.Parameters.AddWithValue("@cid", id);
                        cmd.Parameters.AddWithValue("@d", dat);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }

                    //IF CART EXISTS

                    //get the customer cartid
                    q = "SELECT Cartid FROM shoppingcart where customerid=@cid";
                    cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@cid",id);
                    scq=cmd.ExecuteScalar().ToString();

                    //VERIFY IS QUANTITY IS AVAILABLE
                    q = "SELECT stock\r\nFROM Product\r\nwhere productid=@pid";
                    cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@pid", pid);
                    int stock = (int)cmd.ExecuteScalar();
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    if (stock > qu)//if there is enough stock
                    {
                        q = "INSERT INTO shoppingcartdetail(cartid,productid,quantity,dateadded) VALUES (@id,@pid,@q,@d)";
                        cmd = new SqlCommand(q, con);
                        cmd.Parameters.AddWithValue("@id", scq);
                        cmd.Parameters.AddWithValue("@pid", pid);
                        cmd.Parameters.AddWithValue("@q", qu);
                        cmd.Parameters.AddWithValue("@d", dat);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();

                    }

                    stock = stock - qu;
                    q = "UPDATE Product SET stock=@stk WHERE productid=@pid";
                    cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@stk", stock);
                    cmd.Parameters.AddWithValue("@pid", pid);

                    MessageBox.Show("Item added to cart");

                    q = "SELECT COUNT(*) FROM shoppingcartdetail where cartid=@cid";
                    cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@cid", scq);
                    int ciq = (int)cmd.ExecuteScalar();
                    label4.Text = ciq.ToString();


                }
                else
                {
                    //get old quantity
                    q = "SELECT quantity from shoppingcartdetail where cartid=@cid and productid=@pid";
                    cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@cid", scq);
                    cmd.Parameters.AddWithValue("@pid", pid);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    int tempq=(int)cmd.ExecuteScalar();
                    qu=qu+tempq;

                    q = "UPDATE shoppingcartdetail set quantity=@qu WHERE productid=@pid and cartid=@id";
                    cmd=new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@qu", qu);
                    cmd.Parameters.AddWithValue("@pid",pid);
                    cmd.Parameters.AddWithValue("@id", scq);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                textBox2.Text="0";

                





                con.Close();




            }
            else
            {
                label31.Visible = true;
            }

        }

        //KNOWING WHAT ROW IS SELECTED
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure it's not the header row
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // gives row data
                pname= row.Cells["productName"].Value.ToString();
                Console.WriteLine(pname);
                //MessageBox.Show(orderNumber);
            }
        }

        //FILTER BUTTON------------------------------------------------------------------

        //This function displays everything on the datagrid, without overwritting it
        public void productlisting(string q)
        {
            con.Open();

            SqlCommand com = new SqlCommand(q, con);
            Console.WriteLine("here");
            SqlDataReader reader = com.ExecuteReader();
            List<(string ProductName, decimal UnitPrice)> products = new List<(string, decimal)>();
            Console.WriteLine("here23");
            while (reader.Read())
            {
                Console.WriteLine("here2");
                string productName = reader["productname"].ToString();
                decimal unitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice"));
                products.Add((productName, unitPrice));
            }

            reader.Close();
            if (!products.Any())//empty
            {
                label30.Visible = true;
            }

            else
            {
                label30.Visible = false;
                // Use the products list created above
                foreach (var product in products)
                {
                    Console.WriteLine("here");
                    //get prodid
                    string qq = "SELECT productid from product where productname=@pn";
                    SqlCommand comd= new SqlCommand(qq, con);
                    comd.Parameters.AddWithValue("@pn", product.ProductName);
                    string prodidd=comd.ExecuteScalar().ToString();
                    comd.ExecuteNonQuery();
                    comd.Dispose();
                    //gets avg rating
                    qq = "SELECT AVG(rating) FROM reviews where productid=@pid";
                    comd=new SqlCommand(qq, con);
                    comd.Parameters.AddWithValue("@pid", prodidd);
                    string ratt=comd.ExecuteScalar().ToString();    
                    comd.ExecuteNonQuery();
                    comd.Dispose();

                    if (string.IsNullOrEmpty(ratt))
                    {
                        productRating = "           -------";
                    }
                    else
                    {
                        productRating = ratt;
                    }
                    imagePath = @"C:\Users\mobee\OneDrive\Pictures\dbprojimgs\pexels-taryn-elliott-9508451.jpg";
                    dataGridView1.Rows.Add(product.ProductName, product.UnitPrice, productRating, Image.FromFile(imagePath));
                    gridviewsettings();
                    Console.WriteLine($"Product: {product.ProductName}, Price: {product.UnitPrice}");
                }

                com.ExecuteNonQuery();
                com.Dispose();
               
            }
            con.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Wishlist w=new Wishlist(usn);
            w.Show();
            this.Hide();
        }

        //WISHLIST------------------------------------------------------------------
        private void button7_Click(object sender, EventArgs e)
        {
            //user selects an item and adds to wishlist
            Console.WriteLine(pname);
            if (!string.IsNullOrEmpty(pname))
            {
                label31.Visible = false;
                con.Open();
                string q = "SELECT customerid\r\nFROM Customer\r\nWHERE Email=@e";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@e", usn);
                string id = cmd.ExecuteScalar().ToString();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Console.WriteLine(id);

                q = "SELECT COUNT(*)\r\nFROM Wishlist";
                cmd = new SqlCommand(q, con);
                int coun = (int)cmd.ExecuteScalar();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Console.WriteLine(coun);

                //CHECKS IF WISHLIST ALREADY EXISTS OR NOT
                q = "SELECT COUNT(*)\r\nFROM Wishlist WHERE CustomerID=@id";
                cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@id", id);
                int vercoun = (int)cmd.ExecuteScalar();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Console.WriteLine(vercoun);

                //con.Close();

                if (vercoun == 0)//wishlist doesnt exist
                {
                    //con.Open();
                    //takes the coun and +1
                    coun = coun + 1;
                    q = "INSERT INTO Wishlist(WishlistID,CustomerID) VALUES (@wid,@id)";
                    cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@wid", coun);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    //con
                }

                q = "SELECT ProductID\r\nFROM Product WHERE productName=@pn";
                cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@pn", pname);
                string pidd = cmd.ExecuteScalar().ToString();
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                //check if product doesnt already exist
                q = "SELECT COUNT(*) FROM wishlistdetails where productid=@pid and wishlistid=@wid";
                cmd= new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@wid", coun);
                cmd.Parameters.AddWithValue("@pid", pidd);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                int wpc = (int)cmd.ExecuteScalar();

                if (wpc == 0)
                {
                    q = "INSERT INTO WishlistDetails(WishlistID,ProductID,DateAdded) VALUES (@wid,@pid,@da)";
                    cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@wid", coun);
                    cmd.Parameters.AddWithValue("@pid", pidd);
                    cmd.Parameters.AddWithValue("@da", DateTime.Now.Date.ToString("yyyy-MM-dd"));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();




                    MessageBox.Show("Item added to wishlist");
                }
                else
                {
                    MessageBox.Show("Product already exists");
                }

                con.Close();



                }
            else 
            {
                label31.Visible = true;
            }



        }

        ////KNOWING WHAT ROW IS SELECTED
        //private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0) // Ensure it's not the header row
        //    {
        //        DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

        //        // gives row data
        //        string prodname = row.Cells["productName"].Value.ToString();
        //        Console.WriteLine(prodname);
        //        //MessageBox.Show(orderNumber);
        //    }
        //}


        ////ADD TO CART BUTTON --------------------------------------------------------------
        //private void button6_Click(object sender, EventArgs e)
        //{

        //}

        public void filteringselection(string q)//this function is used to do correct filtering
        {
            //checking pricerange selection
            if (checkBox1.Checked)
            {
                label18.Text = "<300";
                string q2 = " AND UnitPrice<300";
                q = q + q2;
            }
            else if (checkBox2.Checked)
            {
                label18.Text = ">300 & <600";
                string q2 = " AND (UnitPrice>300 and UnitPrice<600)";
                q = q + q2;
            }
            else if (checkBox3.Checked)
            {
                label18.Text = ">600 & <1000";
                string q2 = " AND (UnitPrice>600 and UnitPrice<1000)";
                q = q + q2;
            }


            //CHECKING SELLERSTORE
            if (checkBox14.Checked)
            {
                label19.Text = "TechTronics";
                string q2 = " AND s.StoreName='TechTronics'";
                q = q + q2;
            }
            else if (checkBox16.Checked)
            {
                label19.Text = "Fashionista";
                string q2 = " AND s.StoreName='Fashionista'";
                q = q + q2;
            }
            else if (checkBox15.Checked)
            {
                label19.Text = "Household Essentials";
                string q2 = " AND s.StoreName='Household Essentials'";
                q = q + q2;
            }
            else if (checkBox17.Checked)
            {
                label19.Text = "ReadMore Books";
                string q2 = " AND s.StoreName='ReadMore Books'";
                q = q + q2;
            }
            else if (checkBox18.Checked)
            {
                label19.Text = "Active Sports";
                string q2 = " AND s.StoreName='Active Sports'";
                q = q + q2;
            }

            
            //CHECKING RATING
            if (checkBox9.Checked)
            {
                label27.Text = "1";
                string q2 = " AND r.Rating='1'";
                q = q + q2;
            }
            else if (checkBox10.Checked)
            {
                label27.Text = "2";
                string q2 = " AND r.Rating='2'";
                q = q + q2;
            }
            else if (checkBox11.Checked)
            {
                label27.Text = "3";
                string q2 = " AND r.Rating='3'";
                q = q + q2;
            }
            else if (checkBox12.Checked)
            {
                label27.Text = "4";
                string q2 = " AND r.Rating='4'";
                q = q + q2;
            }
            else if (checkBox13.Checked)
            {
                label27.Text = "5";
                string q2 = " AND r.Rating='5'";
                q = q + q2;
            }
            //*/
            productlisting(q);
        }

        private void button5_Click(object sender, EventArgs e)//FILTER BUTTON
        {
            //bool l=checkBox1.Checked;
            //Console.WriteLine(l);

            if(checkBox4.Checked|| checkBox5.Checked|| checkBox6.Checked|| checkBox7.Checked|| checkBox8.Checked)
            {
                dataGridView1.Rows.Clear();
                //con.Open();

                //filtering
                label25.Visible = false;
                string q="";

                //Categories[label17]---------------------------------------------------
                //Electronics
                if (checkBox4.Checked)
                {
                    //con.Open();
                    label17.Text = "Electronics";
                    q = "SELECT productname,p.UnitPrice \r\nFROM Product p \r\nJOIN Category c ON p.CategoryID=c.CategoryID \r\nJOIN Seller s ON p.SellerID=s.SellerID \r\nLEFT JOIN Reviews r ON p.ProductID=r.ProductID\r\nWHERE c.Name='Electronics'";

                    filteringselection(q);

                }
                
                //CLOTHING
                else if (checkBox5.Checked)
                {
                    //con.Open();
                    label17.Text+= " Clothing";
                    q = "SELECT productname,p.UnitPrice FROM Product p JOIN Category c ON p.CategoryID=c.CategoryID JOIN Seller s ON p.SellerID=s.SellerID WHERE c.Name='Clothing'";

                    filteringselection(q);
                }
                
                //HOME/KITCHEN
                else if (checkBox6.Checked)
                {
                    //con.Open();
                    label17.Text+= " HOME/KITCHEN";
                    q = "SELECT productname,p.UnitPrice FROM Product p JOIN Category c ON p.CategoryID=c.CategoryID JOIN Seller s ON p.SellerID=s.SellerID WHERE c.Name='Home & Kitchen'";

                    filteringselection(q);
                }
                //BOOKS
                else if (checkBox7.Checked)
                {
                    //con.Open();
                    label17.Text+= " Books";
                    q = "SELECT productname,p.UnitPrice FROM Product p JOIN Category c ON p.CategoryID=c.CategoryID JOIN Seller s ON p.SellerID=s.SellerID WHERE c.Name='Books'";

                    filteringselection(q);
                }
                //SPORTS
                else if (checkBox8.Checked)
                {
                    //con.Open();
                    label17.Text+= " Sports/Outdoor";
                    q = "SELECT productname,p.UnitPrice FROM Product p JOIN Category c ON p.CategoryID=c.CategoryID JOIN Seller s ON p.SellerID=s.SellerID WHERE c.Name='Sports & Outdoors'";

                    filteringselection(q);
                }
                
            }
            else
            {
                label25.Visible= true;
            }


            
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
