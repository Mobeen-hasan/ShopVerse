using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbprojtest
{
    public partial class SellerMessages : Form
    {
        string susn;
        public SellerMessages()
        {
            InitializeComponent();
            InitializeDataGridView();
        }
        public SellerMessages(string a)
        {
            InitializeComponent();
            InitializeDataGridView();
            susn = a;
        }

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
            DataGridViewTextBoxColumn senderColumn = new DataGridViewTextBoxColumn();
            senderColumn.HeaderText = "Sender Id";
            senderColumn.Name = "SenderId";
            dataGridView1.Columns.Add(senderColumn);

            DataGridViewTextBoxColumn msgColumn = new DataGridViewTextBoxColumn();
            msgColumn.HeaderText = "Message Sent";
            msgColumn.Name = "MessageSent";
            dataGridView1.Columns.Add(msgColumn);

            DataGridViewTextBoxColumn dateColumn = new DataGridViewTextBoxColumn();
            dateColumn.HeaderText = "Message Date";
            dateColumn.Name = "MessageDate";
            dataGridView1.Columns.Add(dateColumn);

            
            // Adding data to the DataGridView
            string sender = "Mobeen";
            string msg = "How we doing";

            string msgdate = "20-09-2024";

            dataGridView1.Rows.Add(sender, msg, msgdate);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 100;
            }
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                int a = dataGridView1.Size.Width / 3;
                column.Width = 300;
            }

            dataGridView1.AllowUserToAddRows = false;

            //Console.WriteLine(dataGridView1.Size.Width);

        }
    }
}
