using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbprojtest
{
    public partial class Cart : Form
    {
        string usn;
        public Cart()
        {
            InitializeComponent();
            InitializeDataGridView();
        }
        public Cart(string a)
        {
            InitializeComponent();
            label3.Text = a;
            usn = a;
            label5.Text = "0";
            InitializeDataGridView();
            populatingdatagrid();

        }
        //THIOS IS BEING USED FOR WHEN WE SEND PRODUCT TO CART
        SqlConnection con = new SqlConnection("Data Source=MOBEEN\\SQLEXPRESS;Initial Catalog=dbproj;Integrated Security=True");
        float total = 0;
        public Cart(string p,int q)
        {
            InitializeComponent();
            InitializeDataGridView();
            //populatingdatagrid(p, q);
        }
        string cid, cartttid;
        string productName, imagePath, productPrice;
        int quantity;
        string universalimagepath = @"C:\Users\mobee\source\repos\dbprojtest\dbprojtest\images\";
        private void Cart_Load(object sender, EventArgs e)
        {

        }

        public void InitializeDataGridView()
        {
            //dataGridView1.Columns.Clear();

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
            quantityColumn.HeaderText = "Product Quantity";
            quantityColumn.Name = "ProductQuantity";
            dataGridView1.Columns.Add(quantityColumn);

            // Adding Image column for Product Image
            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
            imgColumn.HeaderText = "Product Image";
            imgColumn.Name = "ProductImage";
            dataGridView1.Columns.Add(imgColumn);

            

            //Console.WriteLine(dataGridView1.Size.Width);

        }

        //REMOVE ITEM FROM CART
        string pn=null;
        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(pn))
            {
                
                con.Open();
                
                string que = "Select productid from product where productname=@pn";
                SqlCommand cmd = new SqlCommand(que, con);
                cmd.Parameters.AddWithValue("@pn", pn);
                string pidd = cmd.ExecuteScalar().ToString();
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                que = "DELETE FROM Shoppingcartdetail WHERE productid=@pid and cartid=@cid";
                cmd = new SqlCommand(que, con);
                cmd.Parameters.AddWithValue("@pid", pidd);
                cmd.Parameters.AddWithValue("@cid", cartttid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                MessageBox.Show("Item removed");
                con.Close();
                dataGridView1.Rows.Clear();
                populatingdatagrid();
            }
        }

        //CHECKOUT
        private void button1_Click(object sender, EventArgs e)
        {
            if(dataGridView1.RowCount==0)
            {
                MessageBox.Show("No item in cart");
            }
            else
            {
                con.Open();

               
                //CREATING NEW ORDER
                string q = "SELECT CustomerID FROM customer where email=@e";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@e", usn);
                string id = cmd.ExecuteScalar().ToString();
                cid = id;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                
                q = "SELECT COUNT(*) From [order]";
                cmd= new SqlCommand(q, con);
                string orid=cmd.ExecuteScalar().ToString();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                int c = int.Parse(orid);
                c = c + 1;
                orid = c.ToString();


                string dat = DateTime.Now.Date.ToString("yyyy-MM-dd");

                q = "INSERT INTO [order](orderid,customerid,shipmentid,orderdate) values (@oid,@cid,@sid,@d)";
                cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@oid", orid);
                cmd.Parameters.AddWithValue("@cid", id);
                cmd.Parameters.AddWithValue("@sid", id);
                cmd.Parameters.AddWithValue("@d", dat);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                
                //INSERTING PRODUCTS INTO NEW ORDER

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    Console.WriteLine(row.Cells["ProductName"].Value.ToString());
                    string n = row.Cells["ProductName"].Value.ToString();

                    Console.WriteLine(row.Cells["ProductPrice"].Value.ToString());
                    double p = Convert.ToDouble(row.Cells["ProductPrice"].Value.ToString());

                    Console.WriteLine(row.Cells["ProductQuantity"].Value.ToString());
                    int qua = Convert.ToInt32(row.Cells["ProductQuantity"].Value.ToString());

                    double tot = p * qua;
                    Console.WriteLine(tot+" "+qua+" "+p+" "+n);

                    q = "SELECT productid from product where productname=@pn";
                    cmd= new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@pn", n);
                    string pid=cmd.ExecuteScalar().ToString();
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    q = "INSERT INTO Orderdetails(orderid,productid,quantity,totalprice) VALUES (@oid,@pid,@q,@t)";
                    //@oid,@pid,@q,@t
                    cmd=new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@oid",orid);
                    cmd.Parameters.AddWithValue("@pid",pid);
                    cmd.Parameters.AddWithValue("@q",qua);
                    cmd.Parameters.AddWithValue("@t",tot);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    //ALSO NEED TO UPDATE QUANTITY FROM PRODUCTS
                    q = "SELECT stock from product where productid=@pid";
                    cmd=new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@pid",pid);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    int tq=(int)cmd.ExecuteScalar();

                    tq = tq - qua;

                    q = "UPDATE product set stock=@st where productid=@pid";
                    cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@pid", pid);
                    cmd.Parameters.AddWithValue("@st", tq);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();



                    //Console.WriteLine(row.Cells["ProductName"].Value.ToString());
                }
                label5.Text = "0";
                MessageBox.Show("Checked out");
                dataGridView1.Rows.Clear();
                con.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            pn = row.Cells["ProductName"].Value.ToString();
            label6.Visible = true;
            label6.Text = pn;
        }

        //takes productname and quantity
        public void populatingdatagrid()
        {
            //query needed for price
            // Adding data to the DataGridView
            /*
            Console.WriteLine("Here in cart");
            productName = p;
            imagePath = "Apple AirPods Pro.jpg";
            imagePath = universalimagepath + imagePath;
            productPrice = "100";
            quantity = q;
            Console.WriteLine(productName);
            */
            //ADD THINGS FROM QUERY
            imagePath = "Apple AirPods Pro.jpg";
            imagePath = universalimagepath + imagePath;
            con.Open();

            Console.WriteLine("Here in cart");

            string query = "SELECT CustomerID FROM customer where email=@e";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@e", usn);
            string id = cmd.ExecuteScalar().ToString();
            cid = id;
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            query = "SELECT CartID FROM shoppingcart WHERE customerid=@id";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("id", id);
            string cartid=cmd.ExecuteScalar().ToString();
            cartttid= cartid;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Console.WriteLine("Are we here?");
            query = "SELECT productID,quantity from shoppingcartdetail where cartid=@cid";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@cid", cartid);

            SqlDataReader reader = cmd.ExecuteReader();
            //in this list i will put the things in
            List<(string productid, int quan)> cart = new List<(string,int)>();
            while (reader.Read())
            {
                //query for product name
                Console.WriteLine("Here in cart2");
                string pid = reader["productID"].ToString();

              
                int quan = reader.GetInt32(reader.GetOrdinal("Quantity"));
                cart.Add((pid, quan));
            }

            reader.Close();
            //and ad them here
            foreach (var c in cart)
            {
                Console.WriteLine("Here in cart3");
                query = "SELECT Productname from product where productID=@pid";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@pid", c.productid);
                string proname = cmd.ExecuteScalar().ToString();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                query = "SELECT Unitprice from product where productID=@pid";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@pid", c.productid);
                object re=cmd.ExecuteScalar();
                float price = Convert.ToSingle(re);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                total = total+(price * c.quan);
                label5.Text = total.ToString();

                dataGridView1.Rows.Add(proname, price, c.quan, Image.FromFile(imagePath));
            }


            con.Close();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                //Console.WriteLine("Here in cart2");
                row.Height = 100;
            }
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
               
                int a = dataGridView1.Size.Width / 4;
                column.Width = a;
            }

            dataGridView1.AllowUserToAddRows = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Home hs= new Home(usn);
            hs.Show();
            this.Hide();
        }
    }
}
