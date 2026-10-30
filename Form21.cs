using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;
using System.Data;
using System.Data.SqlClient;
//using Microsoft.VisualBasic;

namespace dbprojtest
{

    public partial class Form21 : Form
    {
        private List<Product> products = new List<Product>();
        private List<Category> categories = new List<Category>();
        private SqlConnection connection;  // Store the connection in a field


        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        public Form21()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            InitializeUserManagementPanel();
            InitializeSellerManagementPanel();
            InitializeProductManagement();
            InitializeOrderOversight();
            InitializeSystemReports();
            InitializeSystemReports();
            InitializeFeedback();
        }

        public Form21(SqlConnection sqlConnection) : this()  // Call default constructor
        {
            this.connection = sqlConnection;  // Store the connection
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            InitializeUserManagementPanel();
            InitializeSellerManagementPanel();
            InitializeProductManagement();
            InitializeOrderOversight();
            InitializeSystemReports();
            InitializeSystemReports();
            InitializeFeedback();
        }

        private List<Seller> sellers = new List<Seller>
        {
            new Seller { Id = 1, Name = "Seller 1", Status = "Approved" },
            new Seller { Id = 2, Name = "Seller 2", Status = "Disapproved" }
        };
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowWelcome();
            dgvSellers.DataSource = sellers;
            categories.Add(new Category { Id = 1, Name = "Electronics" });
            categories.Add(new Category { Id = 2, Name = "Clothing" });

            // Example products
            products.Add(new Product { Id = 1, Name = "Laptop", Description = "Gaming Laptop", Category = "Electronics", Status = "Pending" });
            products.Add(new Product { Id = 2, Name = "T-shirt", Description = "Cotton T-shirt", Category = "Clothing", Status = "Pending" });


        }

        private void ShowWelcome()
        {
            //label1.Visible = true;
            //label2.Visible = true;
            //label3.Visible = true; 

            panelUserManagement.Visible = false;
            panelProductManagement.Visible = false;
            panelOrderOversight.Visible = false;
            panelReports.Visible = false;
            panelFeedback.Visible = false;
            //label1.BringToFront();
            //label2.BringToFront();
            //label3.BringToFront();
        }

        private void HideWelcome()
        {
            //label1.Visible = false;
            //label2.Visible = false;
            //label3.Visible = false;
        }

        private void btnUmanagement_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnUmanagement);
            HideWelcome();
            ShowPanel(panelUserManagement);
            LoadUsers();
        }

        private void btnSmanagement_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnSmanagement);
            HideWelcome();
            ShowPanel(panelSellerManagement);
            LoadSellers();
        }

        private void btnPCManagement_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnPCManagement);
            HideWelcome();
            ShowPanel(panelProductManagement);
            LoadProducts();
        }

        private void btnOrderOversight_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnOrderOversight);
            HideWelcome();
            ShowPanel(panelOrderOversight);
            LoadOrders();
        }

        private void btnSystemReport_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnSystemReport);
            HideWelcome();
            ShowPanel(panelReports);

        }

        private void btnFeedback_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnFeedback);
            HideWelcome();
            ShowPanel(panelFeedback);
            LoadReviews();

        }

        private void SetActiveButton(Button activeButton)
        {
            panelNav.Height = activeButton.Height;
            panelNav.Top = activeButton.Top;
            activeButton.BackColor = Color.FromArgb(250, 128, 114);
        }

        private void ShowPanel(Panel panel)
        {
            panelUserManagement.Visible = false;
            panelProductManagement.Visible = false;
            panelSellerManagement.Visible = false;
            panelOrderOversight.Visible = false;
            panelReports.Visible = false;
            panelFeedback.Visible = false;

            panel.Visible = true;
        }

        private void btnUmanagement_Leave(object sender, EventArgs e)
        {
            btnUmanagement.BackColor = Color.FromArgb(255, 99, 71);
        }

        private void btnSmanagement_Leave(object sender, EventArgs e)
        {
            btnSmanagement.BackColor = Color.FromArgb(255, 99, 71);
        }

        private void btnPCManagement_Leave(object sender, EventArgs e)
        {
            btnPCManagement.BackColor = Color.FromArgb(255, 99, 71);
        }

        private void btnOrderOversight_Leave(object sender, EventArgs e)
        {
            btnOrderOversight.BackColor = Color.FromArgb(255, 99, 71);
        }

        private void btnSystemReport_Leave(object sender, EventArgs e)
        {
            btnSystemReport.BackColor = Color.FromArgb(255, 99, 71);
        }

        private void btnFeedback_Leave(object sender, EventArgs e)
        {
            btnFeedback.BackColor = Color.FromArgb(255, 99, 71);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            // Show input box to enter a new user's name
            string username = Interaction.InputBox("Enter the new user's name:", "Add User", "");

            if (!string.IsNullOrEmpty(username))
            {
                // Add the user to the DataGridView (for now, just add to a sample list)
                AddUserToGrid(username);
            }
        }


        private void AddUserToGrid(string username)
        {
            // Add a new row to the DataGridView with the username
            int rowIndex = dgvUsers.Rows.Add();
            dgvUsers.Rows[rowIndex].Cells[0].Value = username;  // Assuming column 0 holds the username
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected
            if (dgvUsers.SelectedRows.Count > 0)
            {
                // Get the selected row index
                int selectedIndex = dgvUsers.SelectedRows[0].Index;

                // Remove the selected row
                dgvUsers.Rows.RemoveAt(selectedIndex);
            }
            else
            {
                // Show a message if no row is selected
                MessageBox.Show("Please select a user to delete.");
            }
        }

        private void panelFeedback_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnApproveSeller_Click(object sender, EventArgs e)
        {
            // Handle logic for approving a seller
            if (dgvSellers.SelectedRows.Count > 0)
            {
                // Assuming 'Seller' is an object and 'Approve' is a method that updates seller status
                var selectedSeller = dgvSellers.SelectedRows[0].DataBoundItem as Seller;  // Adjust according to your data model
                if (selectedSeller != null)
                {
                    // Approve the seller (for example, by updating their status in your database or list)
                    selectedSeller.Status = "Approved";  // Modify as necessary
                    MessageBox.Show("Seller approved.");
                    ApproveSeller(selectedSeller.Id);
                }
            }

        }

        private void btnDisapproveSeller_Click(object sender, EventArgs e)
        {
            // Handle logic for disapproving a seller
            if (dgvSellers.SelectedRows.Count > 0)
            {
                var selectedSeller = dgvSellers.SelectedRows[0].DataBoundItem as Seller;  // Adjust according to your data model
                if (selectedSeller != null)
                {
                    // Disapprove the seller
                    selectedSeller.Status = "Disapproved";  // Modify as necessary
                    MessageBox.Show("Seller disapproved.");
                    DispproveSeller(selectedSeller.Id);
                }
            }
        }

        private void btnDeleteSeller_Click(object sender, EventArgs e)
        {
            // Handle logic for deleting a seller
            if (dgvSellers.SelectedRows.Count > 0)
            {
                var selectedSeller = dgvSellers.SelectedRows[0].DataBoundItem as Seller;  // Adjust according to your data model
                if (selectedSeller != null)
                {
                    // Delete the seller from the list or database
                    // Your delete logic here, e.g., remove from a list or database
                    MessageBox.Show("Seller deleted.");
                }
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            HideWelcome();
            SetActiveButton(btnHome);
            ShowPanel(panel1);
            ShowWelcome();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void BtnApproveCategory_Click(object sender, EventArgs e)
        {
            // Logic to approve a product category
            MessageBox.Show("Category approved successfully!");
        }

        private void BtnDisapproveCategory_Click(object sender, EventArgs e)
        {
            // Logic to disapprove a product category
            MessageBox.Show("Category disapproved.");
        }

        private void BtnDeleteCategory_Click(object sender, EventArgs e)
        {
            // Logic to delete a product category
            MessageBox.Show("Category deleted.");
        }

        // Resolve Conflict button click event
        private void BtnResolveConflict_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Conflict resolved between customer and seller.");
            // Here, you would update the 'Conflict' column in the DataGridView for the selected order
            // Add logic for resolving the conflict, like updating the database or order status
        }

        // Approve Order button click event
        private void BtnApproveOrder_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Order approved.");
            // Here, you can mark the selected order as approved, and update the status column
            // Add logic for updating the order in the database or the order system
        }

        // Disapprove Order button click event
        private void BtnDisapproveOrder_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Order disapproved.");
            // Here, you would mark the selected order as disapproved
            // Add logic for handling disapproval, such as updating the database
        }

        private void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            // Fetch selected report type from ComboBox
            string reportType = cmbReportType.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(reportType))
            {
                MessageBox.Show("Please select a report type.");
                return;
            }

            // Depending on the report type, generate the respective data for the report
            GenerateReport(reportType);
        }

        private void GenerateReport(string reportType)
        {
            // Clear existing data
            dgvReports.Rows.Clear();

            // Example of populating the DataGridView with data based on the report type
            if (reportType == "Sales Performance")
            {
                dgvReports.Rows.Add("1", "Sales Report for Q1", DateTime.Now.ToString("MM/dd/yyyy"), "Sales data from January to March");
                // Add more rows with data for Sales Performance
            }
            else if (reportType == "User Activity")
            {
                dgvReports.Rows.Add("2", "User Activity Report", DateTime.Now.ToString("MM/dd/yyyy"), "User login data and activity summary");
                // Add more rows for User Activity report
            }
            else if (reportType == "Platform Performance")
            {
                dgvReports.Rows.Add("3", "Platform Performance Report", DateTime.Now.ToString("MM/dd/yyyy"), "Platform usage and uptime statistics");
                // Add more rows for Platform Performance report
            }
        }

        private void BtnExportReport_Click(object sender, EventArgs e)
        {
            // Export the report to CSV or any other format
            ExportReport();
        }

        private void ExportReport()
        {
            // For simplicity, we are exporting the report to a CSV file
            if (dgvReports.Rows.Count == 0)
            {
                MessageBox.Show("No report data to export.");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv",
                Title = "Save Report",
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                StringBuilder csvData = new StringBuilder();

                // Write column headers to CSV
                for (int i = 0; i < dgvReports.Columns.Count; i++)
                {
                    csvData.Append(dgvReports.Columns[i].HeaderText + ",");
                }
                csvData.AppendLine();

                // Write data rows to CSV
                foreach (DataGridViewRow row in dgvReports.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        csvData.Append(cell.Value?.ToString() + ",");
                    }
                    csvData.AppendLine();
                }

                // Save to the file
                File.WriteAllText(filePath, csvData.ToString());
                MessageBox.Show("Report exported successfully!");
            }
        }

        // Approve review functionality
        private void BtnApproveFeedback_Click(object sender, EventArgs e)
        {
            if (dgvFeedback.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvFeedback.SelectedRows)
                {
                    row.Cells["Status"].Value = "Approved"; // Set the status to Approved
                }
                MessageBox.Show("Review approved successfully!");
            }
            else
            {
                MessageBox.Show("Please select a review to approve.");
            }
        }

        // Flag review functionality
        private void BtnFlagFeedback_Click(object sender, EventArgs e)
        {
            if (dgvFeedback.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvFeedback.SelectedRows)
                {
                    row.Cells["Status"].Value = "Flagged"; // Set the status to Flagged
                }
                MessageBox.Show("Review flagged for moderation.");
            }
            else
            {
                MessageBox.Show("Please select a review to flag.");
            }
        }

        // Delete review functionality
        private void BtnDeleteFeedback_Click(object sender, EventArgs e)
        {
            if (dgvFeedback.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvFeedback.SelectedRows)
                {
                    dgvFeedback.Rows.Remove(row); // Remove selected review from DataGridView
                }
                MessageBox.Show("Review deleted successfully.");
            }
            else
            {
                MessageBox.Show("Please select a review to delete.");
            }
        }

        // Fetching users and sellers
        private void LoadUsers()
        {
            string query = "SELECT * FROM Customer;";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            // Bind to data grid for display
            dgvUsersAndSellers.DataSource = reader;
        }

        private void LoadSellers()
        {
            string query = " SELECT * FROM Seller;";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            // Bind to data grid for display
            dgvUsersAndSellers.DataSource = reader;
        }

        // Approve new sellers
        private void ApproveSeller(int sellerID)
        {
            string query = "UPDATE Seller SET Status='Approved' WHERE SellerID = @SellerID;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@SellerID", sellerID);
            cmd.ExecuteNonQuery();
        }

        private void DispproveSeller(int sellerID)
        {
            string query = "UPDATE Seller SET Status='Disapproved' WHERE SellerID = @SellerID;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@SellerID", sellerID);
            cmd.ExecuteNonQuery();
        }

        // Fetching all orders
        private void LoadOrders()
        {
            string query = "SELECT * FROM [Order];";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            dgvOrders.DataSource = reader;
        }

        // Resolving issues with an order (e.g., cancel or resolve conflict)
        private void ResolveOrderIssue(int orderID)
        {
            string query = "UPDATE [Order] SET Status='Resolved' WHERE OrderID = @OrderID;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@OrderID", orderID);
            cmd.ExecuteNonQuery();
        }

        // Fetching reviews and moderating
        private void LoadReviews()
        {
            string query = "SELECT * FROM Reviews WHERE Status='Pending';";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            dgvReviews.DataSource = reader;
        }

        // Flagging a review as inappropriate
        private void FlagInappropriateReview(int reviewID)
        {
            string query = "UPDATE Reviews SET Status='Flagged' WHERE ReviewID = @ReviewID;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ReviewID", reviewID);
            cmd.ExecuteNonQuery();
        }

        // Assign shipment to a shipper
        private void AssignShipment(int shipmentID, int shipperID)
        {
            string query = "UPDATE Shipment SET ShipperID = @ShipperID WHERE ShipmentID = @ShipmentID;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ShipperID", shipperID);
            cmd.Parameters.AddWithValue("@ShipmentID", shipmentID);
            cmd.ExecuteNonQuery();
        }

        // Updating delivery status
        private void UpdateDeliveryStatus(int shipmentID, string status)
        {
            string query = "UPDATE Shipment SET Status = @Status WHERE ShipmentID = @ShipmentID;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@ShipmentID", shipmentID);
            cmd.ExecuteNonQuery();
        }

        private void LoadCategories()
        {
            string query = "SELECT * FROM Category;";
            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dgvCategories.DataSource = table; // Assuming `dgvCategories` is the DataGridView for categories
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}");
            }
        }

        private void LoadProducts()
        {
            string query = @"
        SELECT 
            Product.ProductID, 
            Product.ProductName, 
            Product.UnitPrice, 
            Product.Stock, 
            Category.Name AS CategoryName, 
            Seller.StoreName AS SellerName
        FROM Product
        INNER JOIN Category ON Product.CategoryID = Category.CategoryID
        INNER JOIN Seller ON Product.SellerID = Seller.SellerID;";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dgvCategories.DataSource = table; // Assuming `dgvProducts` is the DataGridView for products
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}");
            }
        }


    }
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; } // "Approved", "Disapproved"
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Status { get; set; } // "Approved", "Rejected", "Pending"
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}

