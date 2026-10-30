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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dbprojtest
{
    public partial class MyOrders : Form
    {
        string usn="";
        string orderNumber;
        public MyOrders()
        {
            InitializeComponent();
            InitializeDataGridView();
        }
        public MyOrders(string a)
        {
            InitializeComponent();
            usn = a;
            InitializeDataGridView();
            
            Console.WriteLine("Here:---->" + usn);
            label2.Text = a;//username
        }
        SqlConnection con = new SqlConnection("Data Source=MOBEEN\\SQLEXPRESS;Initial Catalog=dbproj;Integrated Security=True");

        private void MyOrders_Load(object sender, EventArgs e)
        {

        }

        public void InitializeDataGridView()
        {
            dataGridView1.Columns.Clear();

            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Regular);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);

            // Adding Text column for Product Name

            DataGridViewTextBoxColumn ordernumberColumn = new DataGridViewTextBoxColumn();
            ordernumberColumn.HeaderText = "Order Number";
            ordernumberColumn.Name = "OrderNumber";
            dataGridView1.Columns.Add(ordernumberColumn);

            DataGridViewTextBoxColumn orderdateColumn = new DataGridViewTextBoxColumn();
            orderdateColumn.HeaderText = "Order Date";
            orderdateColumn.Name = "OrderDate";
            dataGridView1.Columns.Add(orderdateColumn);

            DataGridViewTextBoxColumn orderamountColumn = new DataGridViewTextBoxColumn();
            orderamountColumn.HeaderText = "Order Amount";
            orderamountColumn.Name = "OrderAmount";
            dataGridView1.Columns.Add(orderamountColumn);


            DataGridViewTextBoxColumn statusColumn = new DataGridViewTextBoxColumn();
            statusColumn.HeaderText = "Order Status";
            statusColumn.Name = "OrderStatus";
            dataGridView1.Columns.Add(statusColumn);


            string oddate = "20-08-2024";
            string odnum = "O101";
            string totalamount = "100";
            string stat = "Arrived";

            //DISPLAYING ORDERS
            con.Open();
            string q = "SELECT o.OrderID,OrderDate,SUM(od.TotalPrice) as TotalPrice,Status FROM [Order] o JOIN orderDetails od ON o.OrderID=od.OrderID JOIN Shipment s ON o.ShipmentID=s.ShipmentID JOIN Customer c ON c.CustomerID=o.CustomerID WHERE EMail=@e GROUP BY o.OrderID, o.OrderDate, s.Status";
            SqlCommand cmd=new SqlCommand(q,con);
            cmd.Parameters.AddWithValue("@e", usn);
            Console.WriteLine("Here:---->"+usn);
            SqlDataReader reader = cmd.ExecuteReader();
            
            List<(int OrderID, string OrderDate,float amt,string status)> orders = new List<(int,string,float,string)>();
            while (reader.Read())
            {
                string od= reader["OrderID"].ToString();
                int OrderID = int.Parse(od);
                string OrderDate = reader["OrderDate"].ToString();
                float amt = (float)reader.GetDecimal(reader.GetOrdinal("TotalPrice"));
                string status = reader["Status"].ToString();
                orders.Add((OrderID, OrderDate, amt, status));
            }

            reader.Close();

            foreach(var order in orders)
            {
                dataGridView1.Rows.Add(order.OrderID,order.OrderDate,order.amt,order.status);
            }

            //dataGridView1.Rows.Add(odnum,oddate, totalamount, stat);

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

        private void label3_Click(object sender, EventArgs e)
        {
            Home h=new Home(usn);
            h.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure it's not the header row
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Access data from the row
                string o;
                orderNumber = row.Cells["OrderNumber"].Value.ToString();
               
                //MessageBox.Show(orderNumber);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //WE ALSO NEED 
            if (string.IsNullOrEmpty(orderNumber))
            {
                label4.Visible = true;
            }
            else
            {
                label4.Visible = false;
                OrderDetails od = new OrderDetails(usn, orderNumber);
                od.Show();
                this.Hide();
            }
        }
    }
}
