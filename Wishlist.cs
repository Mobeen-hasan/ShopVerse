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
    public partial class Wishlist : Form
    {
        public Wishlist()
        {
            InitializeComponent();
            InitializeDataGridView();
        }
        string usn;
        string pname;
        public Wishlist(string a)
        {
            InitializeComponent();
            label2.Text = a;
            usn = a;
            InitializeDataGridView();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Home h=new Home(usn);
            h.Show();
            this.Hide();
        }
        SqlConnection con = new SqlConnection("Data Source=MOBEEN\\SQLEXPRESS;Initial Catalog=dbproj;Integrated Security=True");

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public void InitializeDataGridView()
        {
            //product name and date added
            con.Open();

            string q3 = "SELECT COUNT(*) \r\nFROM Wishlistdetails  wd\r\nJOIN Wishlist w\r\nON w.WishlistID=wd.WishlistID\r\nJOIN Customer c\r\nON c.CustomerID=w.CustomerID\r\nWHERE c.Email=@e";
            SqlCommand cd= new SqlCommand(q3, con);
            cd.Parameters.AddWithValue("@e", usn);
            int wcoun = (int)cd.ExecuteScalar();
            cd.ExecuteNonQuery();
            cd.Dispose();

            if (wcoun > 0)
            {

                label4.Visible = false;


                dataGridView1.Columns.Clear();

                dataGridView1.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Regular);
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);

                // Adding Text column for Product Name
                DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
                nameColumn.HeaderText = "Product Name";
                nameColumn.Name = "ProductName";
                dataGridView1.Columns.Add(nameColumn);

                // Adding Image column for Product Image
                DataGridViewTextBoxColumn dateColumn = new DataGridViewTextBoxColumn();
                dateColumn.HeaderText = "Date added";
                dateColumn.Name = "DateAdded";
                dataGridView1.Columns.Add(dateColumn);

                string q2 = "SELECT WishlistID\r\nFrom Wishlist w\r\nJoin Customer c\r\nON w.CustomerID=c.CustomerID\r\nWHERE c.Email=@e";
                SqlCommand cmd = new SqlCommand(q2, con);
                cmd.Parameters.AddWithValue("@e", usn);
                string wid = cmd.ExecuteScalar().ToString();
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                string q = "SELECT ProductName,dateadded\r\nFrom Product p\r\nJoin WishlistDetails wd\r\nON p.ProductID=wd.ProductID\r\nWHERE WishlistID=@wid";
                cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@wid", wid);
                
                SqlDataReader reader = cmd.ExecuteReader();
                List<(string ProductName, string dateadded)> wishllist = new List<(string, string)>();
                Console.WriteLine("here23");
                while (reader.Read())
                {
                    Console.WriteLine("here2");
                    string productName = reader["ProductName"].ToString();
                    string dateadded = reader["dateadded"].ToString();
                    wishllist.Add((productName, dateadded));
                }

                reader.Close();

                foreach (var w in wishllist)
                {
                  
                    dataGridView1.Rows.Add(w.ProductName, w.dateadded);
                    
                    //Console.WriteLine($"Product: {product.ProductName}, Price: {product.UnitPrice}");
                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();




                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Height = 100;

                }
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    int a = dataGridView1.Size.Width / 2;
                    column.Width = 300;
                }

                dataGridView1.AllowUserToAddRows = false;
            }
            else
            {
                label4.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string q3 = "SELECT COUNT(*) \r\nFROM Wishlistdetails  wd\r\nJOIN Wishlist w\r\nON w.WishlistID=wd.WishlistID\r\nJOIN Customer c\r\nON c.CustomerID=w.CustomerID\r\nWHERE c.Email=@e";
            SqlCommand cd = new SqlCommand(q3, con);
            cd.Parameters.AddWithValue("@e", usn);
            int wcoun = (int)cd.ExecuteScalar();
            //cd.ExecuteNonQuery();
            //cd.Dispose();
            if (wcoun > 0 && !string.IsNullOrEmpty(pname))
            {
                //con.Open();

                string q2 = "SELECT WishlistID\r\nFrom Wishlist w\r\nJoin Customer c\r\nON w.CustomerID=c.CustomerID\r\nWHERE c.Email=@e";
                SqlCommand cmd = new SqlCommand(q2, con);
                cmd.Parameters.AddWithValue("@e", usn);
                string wid = cmd.ExecuteScalar().ToString();
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                string q4 = "SELECT ProductID FROM Product WHERE productname=@p";
                cmd = new SqlCommand(q4, con);
                cmd.Parameters.AddWithValue("@p", pname);
                string pid=cmd.ExecuteScalar().ToString();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Console.WriteLine(pid + "   " + wid);

                string q = "DELETE FROM wishlistdetails WHERE WishlistID=@wid AND ProductID=@pid";
                SqlCommand cmd2 = new SqlCommand(q, con);
                cmd2.Parameters.AddWithValue("@wid", wid);
                cmd2.Parameters.AddWithValue("@pid", pid);
                cmd2.ExecuteNonQuery();
                cmd2.Dispose();

                MessageBox.Show("Deleted");
               //con.Close();
            }
            else 
            {
                label6.Visible = true;
            }
            con.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            // gives row data
            pname = row.Cells["productName"].Value.ToString();
            label5.Visible = true;
            label5.Text = pname;
        }
    }
}
