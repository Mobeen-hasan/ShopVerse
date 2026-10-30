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
    public partial class OrderDetails : Form
    {
        string usn;
        string od;
        string productchoosen;
        public OrderDetails()
        {
            InitializeComponent();
            InitializeDataGridView();
        }
        public OrderDetails(string a,string b)//name an orderid
        {
            InitializeComponent();
            usn = a;
            od = b;
            InitializeDataGridView();
            
            label4.Text = od;
        }
        SqlConnection con = new SqlConnection("Data Source=MOBEEN\\SQLEXPRESS;Initial Catalog=dbproj;Integrated Security=True");

        private void label2_Click(object sender, EventArgs e)
        {
            MyOrders mo=new MyOrders(usn);//send the user back
            mo.Show();
            this.Hide();
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

            DataGridViewTextBoxColumn quantityColumn = new DataGridViewTextBoxColumn();
            quantityColumn.HeaderText = "productQuantity";
            quantityColumn.Name = "Product Quantity";
            dataGridView1.Columns.Add(quantityColumn);

            // Adding Image column for Product Image
            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
            imgColumn.HeaderText = "Product Image";
            imgColumn.Name = "ProductImage";
            dataGridView1.Columns.Add(imgColumn);

            // Adding data to the DataGridView
            //string productName = "Magnifying Glass";
            string imagePath = @"C:\Users\mobee\Downloads\352091_search_icon.png"; // Ensure the correct image path

            //string productPrice = "100";
            //string quant = "5";

            con.Open();
            string q = "SELECT Productname,TotalPrice,Quantity\r\nFROM OrderDetails od\r\nJOIN Product p\r\nON od.ProductID=p.ProductID\r\nWHERE od.orderID=@odid";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@odid", od);
            SqlDataReader reader = cmd.ExecuteReader();

            List<(string productName, float price, int quan)> orderdetails = new List<(string, float, int)>();
            while (reader.Read())
            {
                
                int quan = reader.GetInt32(reader.GetOrdinal("Quantity"));
                string productname = reader["Productname"].ToString();
                float tprice = (float)reader.GetDecimal(reader.GetOrdinal("TotalPrice"));
                orderdetails.Add((productname, tprice, quan));
            }

            reader.Close();

            foreach (var order in orderdetails)
            {
                dataGridView1.Rows.Add(order.productName, order.price, order.quan, Image.FromFile(imagePath));
            }

            //dataGridView1.Rows.Add(productName, productPrice, quant, Image.FromFile(imagePath));

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 100;
            }
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                int a = dataGridView1.Size.Width / 4;
                column.Width = a;
            }

            dataGridView1.AllowUserToAddRows = false;

            //Console.WriteLine(dataGridView1.Size.Width);


            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label7.Visible = true;
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            string pn=row.Cells["productName"].Value.ToString();
            productchoosen = pn;
            label7.Text = pn;
        }

        
        //public void checkrating()
        //{

        //}

        //BUTTON IS USED FOR REVIEW[rating and column]
        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd"));

            //if any value
            if (comboBox1.SelectedItem.ToString() != null || !string.IsNullOrEmpty(textBox1.Text))
            {
                con.Open();
                //count number of reviews
                string q = "SELECT COUNT(*) FROM Reviews";
                SqlCommand cmd = new SqlCommand(q,con);
                int c=(int)cmd.ExecuteScalar();
                c = c + 1;//REVIEW ID
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                q = "SELECT CustomerID\r\nFROM Customer\r\nWHERE Email=@e";
                cmd=new SqlCommand(q,con);
                cmd.Parameters.AddWithValue("@e",usn);
                string id=cmd.ExecuteScalar().ToString();//customerid
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                string dat = DateTime.Now.ToString("yyyy-MM-dd");//reviewdate

                q = "SELECT ProductID FROM product WHERE Productname=@pn";
                cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@pn", productchoosen);
                string pid=cmd.ExecuteScalar().ToString();//productID
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                int rating = 0;string comment=null;
                Console.WriteLine("Value---->"+ comboBox1.SelectedItem.ToString());
                if (comboBox1.SelectedItem.ToString() != null)
                {
                    Console.WriteLine("kere");
                    string rat = comboBox1.SelectedItem.ToString();
                    rating= int.Parse(rat);
                }
                if(!string.IsNullOrEmpty(textBox1.Text))
                {
                    comment = textBox1.Text;
                }
                Console.WriteLine(rating);
                
                q = "INSERT INTO Reviews(ReviewID,CustomerID,ProductID,Rating,Comments,ReviewDate) VALUES (@c,@id,@pid,@r,@comm,@rd)";
                cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@c", c.ToString());
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@pid", pid);
                cmd.Parameters.AddWithValue("@r", rating);
                cmd.Parameters.AddWithValue("@comm", comment);
                cmd.Parameters.AddWithValue("@rd", dat);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                
                con.Close();

                comboBox1.Items.Clear();
                textBox1.Clear();


            }
            else
            {
                Console.WriteLine("No review");
            }


        }
    }
}
