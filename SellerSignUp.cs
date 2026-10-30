using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace dbprojtest
{
    public partial class SellerSignUp : Form
    {
        public SellerSignUp()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        SqlConnection connect = new SqlConnection("Data Source=MOBEEN\\SQLEXPRESS;Initial Catalog=dbproj;Integrated Security=True");

        private void label11_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            connect.Open();

            string name = textBox1.Text;
            string password = textBox6.Text;
            string storeName = textBox2.Text;
            string storeDescription = textBox3.Text;
            string email = textBox4.Text;
            string contactNumber = textBox5.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(storeName) ||
                string.IsNullOrEmpty(storeDescription) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contactNumber))
            {
                MessageBox.Show("Please fill in all the required fields.");
                connect.Close();
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.");
                connect.Close();
                return;
            }

            string check_query = "SELECT COUNT(*) FROM Seller WHERE StoreName = @StoreName OR Email = @Email";
            SqlCommand checkCmd = new SqlCommand(check_query, connect);
            checkCmd.Parameters.AddWithValue("@StoreName", storeName);
            checkCmd.Parameters.AddWithValue("@Email", email);

            int existingRecords = (int)checkCmd.ExecuteScalar();
            if (existingRecords > 0)
            {
                MessageBox.Show("Store name or email already exists. Please choose another.");
                connect.Close();
                return;
            }

            string insert_query = "INSERT INTO Seller(Name, StoreName, StoreDescription, Email, ContactNo, Password) " +
                                  "VALUES (@Name, @StoreName, @StoreDescription, @Email, @ContactNo, @Password)";

            SqlCommand cmd = new SqlCommand(insert_query, connect);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@StoreName", storeName);
            cmd.Parameters.AddWithValue("@StoreDescription", storeDescription);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@ContactNo", contactNumber);
            cmd.Parameters.AddWithValue("@Password", password);

            cmd.ExecuteNonQuery();

            cmd.Dispose();
            connect.Close();

            MessageBox.Show("Seller registered successfully.");
        }
    }
}
