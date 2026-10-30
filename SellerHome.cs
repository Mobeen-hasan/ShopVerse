using System;
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
    public partial class SellerHome : Form
    {
        string susn;
        public SellerHome()
        {
            InitializeComponent();
            InitializeDataGridView();
        }
        public SellerHome(string a)
        {
            InitializeComponent();
            susn = a;
            label3.Text = susn;
            InitializeDataGridView();

            
            
        }
        string sellerid;
        string prodname;
        private void SellerHome_Load(object sender, EventArgs e)
        {
            panel4.Parent = this;
            panel4.BringToFront();
            //this.reportViewer1.RefreshReport();
        }
        SqlConnection con = new SqlConnection("Data Source=MOBEEN\\SQLEXPRESS;Initial Catalog=dbproj;Integrated Security=True");

        //PROFILE PANEL--------------------------------------------------------------------

        bool panel4expand;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (panel4expand)
            {

                panel4.Height -= 5;
                if (panel4.Height == panel4.MinimumSize.Height)
                {
                    panel4expand = false;
                    panel4.Visible = false;
                    timer1.Stop();
                }
            }
            else
            {
                panel4.Visible = true;
                panel4.Height += 5;
                if (panel4.Height == panel4.MaximumSize.Height)
                {
                    panel4expand = true;
                    timer1.Stop();
                }
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        //sign out
        private void label5_Click(object sender, EventArgs e)
        {
            Form1 form1= new Form1();
            form1.Show();
            this.Hide();
        }

        //settings
        private void label4_Click(object sender, EventArgs e)
        {
            SellerProfile sp=new SellerProfile(susn);
            sp.Show();
            this.Hide();
        }

        //MESSAGES-----------------------------------------------------------------
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SellerMessages sm=new SellerMessages(susn);
            sm.Show();
            this.Hide();
        }


        //PRODUCT LIST---------------------------------------------------------
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

            DataGridViewTextBoxColumn stockColumn = new DataGridViewTextBoxColumn();
            stockColumn.HeaderText = "Stock";
            stockColumn.Name = "stcok";
            dataGridView1.Columns.Add(stockColumn);

            // Adding Image column for Product Image
            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
            imgColumn.HeaderText = "Product Image";
            imgColumn.Name = "ProductImage";
            dataGridView1.Columns.Add(imgColumn);

            // Adding data to the DataGridView
            string productName = "Magnifying Glass";
            string imagePath = @"C:\Users\mobee\Downloads\352091_search_icon.png"; // Ensure the correct image path

            string productPrice = "100";
            string productRating = "4";
            string stock = "10";

            con.Open();

            string query2 = "SELECT sellerid from seller where email=@e";
            SqlCommand comd=new SqlCommand(query2,con);
            comd.Parameters.AddWithValue("@e", susn);
            comd.ExecuteNonQuery();
            comd.Dispose();
            string sid=comd.ExecuteScalar().ToString();
            sellerid = sid;

            string query = "SELECT productname,UnitPrice,stock from product where sellerid=@sid";
            comd=new SqlCommand(query,con);
            comd.Parameters.AddWithValue("@sid", sid);
            SqlDataReader reader = comd.ExecuteReader();

            List<(string ProductName, decimal UnitPrice,int stock)> products = new List<(string, decimal,int)>();
            Console.WriteLine("here23");
            while (reader.Read())
            {
                Console.WriteLine("here2");
                string pdn = reader["productname"].ToString();
                decimal unitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice"));
                int stk= reader.GetInt32(reader.GetOrdinal("stock"));
                products.Add((pdn, unitPrice,stk));
            }

            
            reader.Close();

            foreach(var p in products)
            {
                string pq = "SELECT productid from product where productname=@pn";
                comd = new SqlCommand(pq, con);
                comd.Parameters.AddWithValue("@pn", p.ProductName);
                comd.ExecuteNonQuery();
                comd.Dispose();
                string pid=comd.ExecuteScalar().ToString(); 


                string uq = "SELECT AVG(Rating) FROM reviews where productid=@pid";
                comd=new SqlCommand(uq,con);
                comd.Parameters.AddWithValue("@pid",pid);
                comd.ExecuteNonQuery();
                comd.Dispose();

                dataGridView1.Rows.Add(p.ProductName, p.UnitPrice, productRating, p.stock, Image.FromFile(imagePath));
            }

            //dataGridView1.Rows.Add(productName, productPrice, productRating, stock,Image.FromFile(imagePath));

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 100;
            }
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                int a = dataGridView1.Size.Width / 5;
                column.Width = a;
            }

            dataGridView1.AllowUserToAddRows = false;

            //Console.WriteLine(dataGridView1.Size.Width);
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ordermanagement om=new Ordermanagement(susn);
            om.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        //ADD
        private void button3_Click(object sender, EventArgs e)
        {
            if(button4.BackColor == SystemColors.ActiveCaption)
            {
                button4_Click(sender, e);
            }
            if (button5.BackColor == SystemColors.ActiveCaption)
            {
                button5_Click(sender, e);
            }


            if (panel5.Size == panel5.MinimumSize)//closed
            {
                button3.BackColor = SystemColors.ActiveCaption;
                panel5.Size = panel5.MaximumSize;
                panel5.Visible = true;
            }
            else
            {
                button3.BackColor = SystemColors.ButtonFace;
                panel5.Size = panel5.MinimumSize;
                panel5.Visible = false;
            }





        }
        //DELETE
        private void button4_Click(object sender, EventArgs e)
        {
            if (button3.BackColor == SystemColors.ActiveCaption)
            {
                button3_Click(sender, e);
            }
            if (button5.BackColor == SystemColors.ActiveCaption)
            {
                button5_Click(sender, e);
            }

            if (panel6.Size == panel6.MinimumSize)//closed
            {
                button4.BackColor = SystemColors.ActiveCaption;
                panel6.Size = panel6.MaximumSize;
                panel6.Visible = true;
            }
            else
            {
                button4.BackColor = SystemColors.ButtonFace;
                panel6.Size = panel6.MinimumSize;
                panel6.Visible = false;
            }
        }
        //UPDATE
        private void button5_Click(object sender, EventArgs e)
        {

            if (button4.BackColor == SystemColors.ActiveCaption)
            {
                button4_Click(sender, e);
            }
            if (button3.BackColor == SystemColors.ActiveCaption)
            {
                button3_Click(sender, e);
            }

            if (panel7.Size == panel7.MinimumSize)//closed
            {
                button5.BackColor = SystemColors.ActiveCaption;
                panel7.Size = panel7.MaximumSize;
                panel7.Visible = true;
            }
            else
            {
                button5.BackColor = SystemColors.ButtonFace;
                panel7.Size = panel7.MinimumSize;
                panel7.Visible = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            //adding product
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(comboBox1.Text))
            {
                label18.Visible = false;

                string name = textBox1.Text;
                string s = textBox3.Text;
                string p = textBox2.Text;
                string cat = comboBox1.Text;

                float price;
                float.TryParse(p,out price);
                int stock;
                int.TryParse(s, out stock);

                Console.WriteLine(name + price + stock + cat);

                con.Open();

                string q = "SELECT COUNT(*) FROM product";
                SqlCommand cmd=new SqlCommand(q,con);
                int c=(int)cmd.ExecuteScalar();
                c = c + 1;
                string pid=c.ToString();
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                q = "SELECT Categoryid from category where name=@cname";
                cmd=new SqlCommand(q,con);
                cmd.Parameters.AddWithValue("@cname", cat);
                string cid=cmd.ExecuteScalar().ToString();  
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                q = "INSERT INTO Product(productid,productname,sellerid,categoryid,unitprice,stock) VALUES (@pid,@pname,@sid,@cid,@p,@s)";
                //@pid,@pname,@sid,@cid,@p,@s
                cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@pid", pid);
                cmd.Parameters.AddWithValue("@pname", name);
                cmd.Parameters.AddWithValue("@sid", sellerid);
                cmd.Parameters.AddWithValue("@cid", cid);
                cmd.Parameters.AddWithValue("@p", price);
                cmd.Parameters.AddWithValue("@s", stock);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                con.Close();

                InitializeDataGridView();

            }
            else
            {
                label18.Visible = true;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox10.Text) || !string.IsNullOrEmpty(textBox7.Text) || !string.IsNullOrEmpty(textBox8.Text) || !string.IsNullOrEmpty(comboBox2.Text))
            {
                label18.Visible = false;

                con.Open();

                string q = "SELECT COUNT(*) FROM product where productname=@pn";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@pn", prodname);
                int c = (int)cmd.ExecuteScalar();
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                //if product exists
                if(c > 0 ) 
                { 
                    //name
                    if(!string.IsNullOrEmpty(textBox10.Text))
                    {
                        q = "UPDATE Product SET productname=@pn where productname=@oldpn";
                        cmd=new SqlCommand(q, con);
                        cmd.Parameters.AddWithValue("@pn", textBox7.Text);
                        cmd.Parameters.AddWithValue("@oldpn", prodname);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        //InitializeDataGridView();
                    }
                    //price
                    if (!string.IsNullOrEmpty(textBox7.Text))
                    {
                        q = "UPDATE Product SET Unitprice=@pn where productname=@oldpn";
                        cmd = new SqlCommand(q, con);
                        cmd.Parameters.AddWithValue("@pn", textBox7.Text);
                        cmd.Parameters.AddWithValue("@oldpn", prodname);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        //InitializeDataGridView();
                    }
                    //stock
                    Console.WriteLine(textBox8.Text);
                    if (!string.IsNullOrEmpty(textBox8.Text))
                    {
                        Console.WriteLine("Here in stock");
                        q = "UPDATE Product SET stock=@pn where productname=@oldpn";
                        cmd = new SqlCommand(q, con);
                        cmd.Parameters.AddWithValue("@pn", textBox8.Text);
                        cmd.Parameters.AddWithValue("@oldpn", prodname);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        //InitializeDataGridView();
                    }
                    //category
                    if (!string.IsNullOrEmpty(comboBox2.Text))
                    {
                        q = "SELECT categoryID from category where name=@cn";
                        cmd = new SqlCommand(q, con);
                        string cid2=cmd.ExecuteScalar().ToString();
                        cmd.Parameters.AddWithValue("@cn", comboBox2.Text);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        
                        q = "UPDATE Product SET categoryid=@pn where productname=@oldpn";
                        cmd = new SqlCommand(q, con);
                        cmd.Parameters.AddWithValue("@pn", cid2);
                        cmd.Parameters.AddWithValue("@oldpn", prodname);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        //InitializeDataGridView();
                    }
                }


                MessageBox.Show("Updated");
                con.Close();
                InitializeDataGridView();
            }
            else
            {
                label18.Visible = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            prodname = row.Cells["ProductName"].Value.ToString();
            Console.WriteLine(prodname);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox5.Text))
            {
                label18.Visible = false;

                con.Open();
                string query = "SELECT COUNT(*) from product where productname=@pn";
                SqlCommand cmd=new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@pn", textBox5.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose(); 
                int c=(int)cmd.ExecuteScalar(); 
                if(c>0)
                {
                    query = "DELETE FROM Product where productname=@pn";
                    cmd=new SqlCommand(query,con);
                    cmd.Parameters.AddWithValue("@pn", textBox5.Text);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    MessageBox.Show("Deleted");
                    InitializeDataGridView();   
                }
                else
                {
                    label19.Visible = true;
                    label19.Text = "Not found";
                }

                con.Close();


            }
            else
            {
                label18.Visible = true;
            }
        }

        //ENTER SELLER REPORT
        private void button1_Click(object sender, EventArgs e)
        {
            button9.Visible = true;
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            sellerReport sr = new sellerReport(susn);
            sr.Show();
            this.Hide();
        }
    }
}
