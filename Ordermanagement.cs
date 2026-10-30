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
    public partial class Ordermanagement : Form
    {
        string susn;
        public Ordermanagement()
        {
            InitializeComponent();
            InitializeDataGridView();
        }
        public Ordermanagement(string a)
        {
            InitializeComponent();
            susn = a;
            InitializeDataGridView();
            
        }
        SqlConnection con = new SqlConnection("Data Source=MOBEEN\\SQLEXPRESS;Initial Catalog=dbproj;Integrated Security=True");
        string orid;
        private void label2_Click(object sender, EventArgs e)
        {
            SellerHome shm = new SellerHome(susn);
            shm.Show();
            this.Hide();
        }


        public void InitializeDataGridView()
        {
            dataGridView1.Columns.Clear();

            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Regular);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);

            // Adding Text column for Product Name
            DataGridViewTextBoxColumn orderidColumn = new DataGridViewTextBoxColumn();
            orderidColumn.HeaderText = "Order Id";
            orderidColumn.Name = "OrderId";
            dataGridView1.Columns.Add(orderidColumn);

            DataGridViewTextBoxColumn statusColumn = new DataGridViewTextBoxColumn();
            statusColumn.HeaderText = "Status";
            statusColumn.Name = "OrderStatus";
            dataGridView1.Columns.Add(statusColumn);

            // Adding data to the DataGridView
            string id = orid;
            string stat = "Pending";

            con.Open();

            //1st get sellerif
            string q2 = "SELECT Sellerid from seller where email=@e";
            SqlCommand cmd2 = new SqlCommand(q2, con);
            cmd2.Parameters.AddWithValue("@e", susn);
            string sid=cmd2.ExecuteScalar().ToString();

            string query = "SELECT od.OrderID,Status\r\nFROM [order] o\r\nJOIN OrderDetails od ON o.orderID=od.orderID\r\nJOIN product p ON p.productid=od.ProductID\r\nJOIN Shipment s ON o.ShipmentID=s.ShipmentID\r\nWHERE SellerID=@sid\r\nGROUP BY  od.OrderID,Status";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@sid", sid);
            SqlDataReader reader = cmd.ExecuteReader();
           
            List<(string  orderid, string stat)> order = new List<(string, string)>();
            while (reader.Read())
            {
                //query for product name
                
                string oid = reader["OrderID"].ToString();
                string st = reader["Status"].ToString();
                order.Add((oid, st));
            }

            reader.Close();
            //and ad them here
            foreach (var o in order)
            {
                
                dataGridView1.Rows.Add(o.orderid,o.stat);
            }



            con.Close();

         

            dataGridView1.Rows.Add(id,stat);

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

            //Console.WriteLine(dataGridView1.Size.Width);

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(panel2.Visible==false)
                panel2.Visible = true;
            else
                panel2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string newstat=comboBox1.Text;
            if (!string.IsNullOrEmpty(newstat))
            {
                label6.Visible = false;
                con.Open();

                string q = "SELECT shipmentID from [order] where orderid=@oid ";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@oid", orid);
                string shipid = cmd.ExecuteScalar().ToString();
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                q = "Update shipment set status=@st where shipmentid=@shid";
                cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@st", newstat);
                cmd.Parameters.AddWithValue("@shid", shipid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                con.Close();

                MessageBox.Show("Status Updated");
                panel2.Visible = false;
                InitializeDataGridView();

                if (comboBox1.Text == "Shipped")
                {
                    //if shipped is selected change the data
                    string da = DateTime.Now.Date.ToString("yyyy-MM-DD");
                    q = "UPDATE shipment set shipmentdate=@da where shipmentid=@shid";
                    cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@da", da);
                    cmd.Parameters.AddWithValue("@shid", shipid);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                else if(comboBox1.Text == "Pending")
                {
                    string da = null;
                    q = "UPDATE shipment set shipmentdate=@da where shipmentid=@shid";
                    cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@da", da);
                    cmd.Parameters.AddWithValue("@shid", shipid);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            else
            {
                label6.Visible= true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            orid = row.Cells["OrderID"].Value.ToString();
            label4.Visible = true;
            label4.Text = orid;
        }
    }
}
