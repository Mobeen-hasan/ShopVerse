using System.Windows.Forms;

namespace dbprojtest
{
    partial class Form21
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.panelNav = new System.Windows.Forms.Panel();
            this.btnFeedback = new System.Windows.Forms.Button();
            this.btnSystemReport = new System.Windows.Forms.Button();
            this.btnOrderOversight = new System.Windows.Forms.Button();
            this.btnPCManagement = new System.Windows.Forms.Button();
            this.btnSmanagement = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnUmanagement = new System.Windows.Forms.Button();
            this.panelUserManagement = new System.Windows.Forms.Panel();
            this.panelProductManagement = new System.Windows.Forms.Panel();
            this.panelOrderOversight = new System.Windows.Forms.Panel();
            this.panelReports = new System.Windows.Forms.Panel();
            this.panelFeedback = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelSideMenu.SuspendLayout();
            this.panelFeedback.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(0)))));
            this.panelSideMenu.Controls.Add(this.panelNav);
            this.panelSideMenu.Controls.Add(this.btnFeedback);
            this.panelSideMenu.Controls.Add(this.btnSystemReport);
            this.panelSideMenu.Controls.Add(this.btnOrderOversight);
            this.panelSideMenu.Controls.Add(this.btnPCManagement);
            this.panelSideMenu.Controls.Add(this.btnSmanagement);
            this.panelSideMenu.Controls.Add(this.btnHome);
            this.panelSideMenu.Controls.Add(this.btnUmanagement);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Margin = new System.Windows.Forms.Padding(4);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(248, 710);
            this.panelSideMenu.TabIndex = 0;
            // 
            // panelNav
            // 
            this.panelNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.Margin = new System.Windows.Forms.Padding(4);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(7, 62);
            this.panelNav.TabIndex = 0;
            // 
            // btnFeedback
            // 
            this.btnFeedback.FlatAppearance.BorderSize = 0;
            this.btnFeedback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnFeedback.ForeColor = System.Drawing.Color.White;
            this.btnFeedback.Location = new System.Drawing.Point(0, 369);
            this.btnFeedback.Margin = new System.Windows.Forms.Padding(4);
            this.btnFeedback.Name = "btnFeedback";
            this.btnFeedback.Size = new System.Drawing.Size(248, 62);
            this.btnFeedback.TabIndex = 6;
            this.btnFeedback.Text = "Feedback";
            this.btnFeedback.UseVisualStyleBackColor = true;
            this.btnFeedback.Click += new System.EventHandler(this.btnFeedback_Click);
            this.btnFeedback.Leave += new System.EventHandler(this.btnFeedback_Leave);
            // 
            // btnSystemReport
            // 
            this.btnSystemReport.FlatAppearance.BorderSize = 0;
            this.btnSystemReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSystemReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnSystemReport.ForeColor = System.Drawing.Color.White;
            this.btnSystemReport.Location = new System.Drawing.Point(0, 308);
            this.btnSystemReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnSystemReport.Name = "btnSystemReport";
            this.btnSystemReport.Size = new System.Drawing.Size(248, 62);
            this.btnSystemReport.TabIndex = 5;
            this.btnSystemReport.Text = "System Reports";
            this.btnSystemReport.UseVisualStyleBackColor = true;
            this.btnSystemReport.Click += new System.EventHandler(this.btnSystemReport_Click);
            this.btnSystemReport.Leave += new System.EventHandler(this.btnSystemReport_Leave);
            // 
            // btnOrderOversight
            // 
            this.btnOrderOversight.FlatAppearance.BorderSize = 0;
            this.btnOrderOversight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderOversight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnOrderOversight.ForeColor = System.Drawing.Color.White;
            this.btnOrderOversight.Location = new System.Drawing.Point(0, 246);
            this.btnOrderOversight.Margin = new System.Windows.Forms.Padding(4);
            this.btnOrderOversight.Name = "btnOrderOversight";
            this.btnOrderOversight.Size = new System.Drawing.Size(248, 62);
            this.btnOrderOversight.TabIndex = 4;
            this.btnOrderOversight.Text = "Order Oversight";
            this.btnOrderOversight.UseVisualStyleBackColor = true;
            this.btnOrderOversight.Click += new System.EventHandler(this.btnOrderOversight_Click);
            this.btnOrderOversight.Leave += new System.EventHandler(this.btnOrderOversight_Leave);
            // 
            // btnPCManagement
            // 
            this.btnPCManagement.FlatAppearance.BorderSize = 0;
            this.btnPCManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPCManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnPCManagement.ForeColor = System.Drawing.Color.White;
            this.btnPCManagement.Location = new System.Drawing.Point(0, 185);
            this.btnPCManagement.Margin = new System.Windows.Forms.Padding(4);
            this.btnPCManagement.Name = "btnPCManagement";
            this.btnPCManagement.Size = new System.Drawing.Size(248, 62);
            this.btnPCManagement.TabIndex = 3;
            this.btnPCManagement.Text = "Product Management";
            this.btnPCManagement.UseVisualStyleBackColor = true;
            this.btnPCManagement.Click += new System.EventHandler(this.btnPCManagement_Click);
            this.btnPCManagement.Leave += new System.EventHandler(this.btnPCManagement_Leave);
            // 
            // btnSmanagement
            // 
            this.btnSmanagement.FlatAppearance.BorderSize = 0;
            this.btnSmanagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSmanagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnSmanagement.ForeColor = System.Drawing.Color.White;
            this.btnSmanagement.Location = new System.Drawing.Point(0, 123);
            this.btnSmanagement.Margin = new System.Windows.Forms.Padding(4);
            this.btnSmanagement.Name = "btnSmanagement";
            this.btnSmanagement.Size = new System.Drawing.Size(248, 62);
            this.btnSmanagement.TabIndex = 2;
            this.btnSmanagement.Text = "Seller Management";
            this.btnSmanagement.UseVisualStyleBackColor = true;
            this.btnSmanagement.Click += new System.EventHandler(this.btnSmanagement_Click);
            this.btnSmanagement.Leave += new System.EventHandler(this.btnSmanagement_Leave);
            // 
            // btnHome
            // 
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Location = new System.Drawing.Point(0, 0);
            this.btnHome.Margin = new System.Windows.Forms.Padding(4);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(248, 62);
            this.btnHome.TabIndex = 1;
            this.btnHome.Text = "ShopVerse";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnUmanagement_Click);
            this.btnHome.Leave += new System.EventHandler(this.btnUmanagement_Leave);
            // 
            // btnUmanagement
            // 
            this.btnUmanagement.FlatAppearance.BorderSize = 0;
            this.btnUmanagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUmanagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnUmanagement.ForeColor = System.Drawing.Color.White;
            this.btnUmanagement.Location = new System.Drawing.Point(0, 62);
            this.btnUmanagement.Margin = new System.Windows.Forms.Padding(4);
            this.btnUmanagement.Name = "btnUmanagement";
            this.btnUmanagement.Size = new System.Drawing.Size(248, 62);
            this.btnUmanagement.TabIndex = 1;
            this.btnUmanagement.Text = "User Management";
            this.btnUmanagement.UseVisualStyleBackColor = true;
            this.btnUmanagement.Click += new System.EventHandler(this.btnUmanagement_Click);
            this.btnUmanagement.Leave += new System.EventHandler(this.btnUmanagement_Leave);
            // 
            // panelUserManagement
            // 
            this.panelUserManagement.BackColor = System.Drawing.Color.White;
            this.panelUserManagement.Location = new System.Drawing.Point(248, 0);
            this.panelUserManagement.Margin = new System.Windows.Forms.Padding(4);
            this.panelUserManagement.Name = "panelUserManagement";
            this.panelUserManagement.Size = new System.Drawing.Size(1020, 710);
            this.panelUserManagement.TabIndex = 3;
            this.panelUserManagement.Visible = false;
            // 
            // panelProductManagement
            // 
            this.panelProductManagement.BackColor = System.Drawing.Color.White;
            this.panelProductManagement.Location = new System.Drawing.Point(248, 0);
            this.panelProductManagement.Margin = new System.Windows.Forms.Padding(4);
            this.panelProductManagement.Name = "panelProductManagement";
            this.panelProductManagement.Size = new System.Drawing.Size(1020, 710);
            this.panelProductManagement.TabIndex = 4;
            this.panelProductManagement.Visible = false;
            // 
            // panelOrderOversight
            // 
            this.panelOrderOversight.BackColor = System.Drawing.Color.White;
            this.panelOrderOversight.Location = new System.Drawing.Point(248, 0);
            this.panelOrderOversight.Margin = new System.Windows.Forms.Padding(4);
            this.panelOrderOversight.Name = "panelOrderOversight";
            this.panelOrderOversight.Size = new System.Drawing.Size(1020, 710);
            this.panelOrderOversight.TabIndex = 5;
            this.panelOrderOversight.Visible = false;
            // 
            // panelReports
            // 
            this.panelReports.BackColor = System.Drawing.Color.White;
            this.panelReports.Location = new System.Drawing.Point(248, 0);
            this.panelReports.Margin = new System.Windows.Forms.Padding(4);
            this.panelReports.Name = "panelReports";
            this.panelReports.Size = new System.Drawing.Size(1020, 710);
            this.panelReports.TabIndex = 6;
            this.panelReports.Visible = false;
            // 
            // panelFeedback
            // 
            this.panelFeedback.BackColor = System.Drawing.Color.White;
            this.panelFeedback.Controls.Add(this.panel1);
            this.panelFeedback.Location = new System.Drawing.Point(248, 0);
            this.panelFeedback.Margin = new System.Windows.Forms.Padding(4);
            this.panelFeedback.Name = "panelFeedback";
            this.panelFeedback.Size = new System.Drawing.Size(1020, 710);
            this.panelFeedback.TabIndex = 7;
            this.panelFeedback.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(916, 606);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 710);
            this.Controls.Add(this.panelFeedback);
            this.Controls.Add(this.panelReports);
            this.Controls.Add(this.panelOrderOversight);
            this.Controls.Add(this.panelProductManagement);
            this.Controls.Add(this.panelUserManagement);
            this.Controls.Add(this.panelSideMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Dashboard";
            this.panelSideMenu.ResumeLayout(false);
            this.panelFeedback.ResumeLayout(false);
            this.ResumeLayout(false);

            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.dgvUsersAndSellers = new System.Windows.Forms.DataGridView();
            this.dgvReviews = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersAndSellers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReviews)).BeginInit();

            // 
            // dgvOrders
            // 
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(12, 12);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.Size = new System.Drawing.Size(760, 150);
            this.dgvOrders.TabIndex = 0;

        }

        #endregion

        private void InitializeUserManagementPanel()
        {
            this.panelUserManagement = new System.Windows.Forms.Panel();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();

            // Panel configuration
            this.panelUserManagement.SuspendLayout();
            this.panelUserManagement.Location = new System.Drawing.Point(200, 100); // Adjust as needed
            this.panelUserManagement.Name = "panelUserManagement";
            this.panelUserManagement.Size = new System.Drawing.Size(600, 400);
            this.panelUserManagement.TabIndex = 0;
            this.panelUserManagement.Visible = false;

            // DataGridView configuration
            this.dgvUsers.Location = new System.Drawing.Point(20, 20);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.Size = new System.Drawing.Size(560, 300);
            this.dgvUsers.TabIndex = 1;

            // Add User button configuration
            this.btnAddUser.Location = new System.Drawing.Point(20, 340);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(100, 30);
            this.btnAddUser.TabIndex = 2;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);

            // Delete User button configuration
            this.btnDeleteUser.Location = new System.Drawing.Point(140, 340);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(100, 30);
            this.btnDeleteUser.TabIndex = 3;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);

            // Add components to the panel
            this.panelUserManagement.Controls.Add(this.dgvUsers);
            this.panelUserManagement.Controls.Add(this.btnAddUser);
            this.panelUserManagement.Controls.Add(this.btnDeleteUser);

            // Add panel to the form
            this.Controls.Add(this.panelUserManagement);
            this.panelUserManagement.ResumeLayout(false);
        }

        private void InitializeSellerManagementPanel()
        {
            this.panelSellerManagement = new System.Windows.Forms.Panel();
            this.dgvSellers = new System.Windows.Forms.DataGridView();
            this.btnApproveSeller = new System.Windows.Forms.Button();
            this.btnDisapproveSeller = new System.Windows.Forms.Button();
            this.btnDeleteSeller = new System.Windows.Forms.Button();

            // Panel configuration
            this.panelSellerManagement.SuspendLayout();
            this.panelSellerManagement.Location = new System.Drawing.Point(200, 100); // Adjust position
            this.panelSellerManagement.Name = "panelSellerManagement";
            this.panelSellerManagement.Size = new System.Drawing.Size(600, 400);
            this.panelSellerManagement.TabIndex = 0;
            this.panelSellerManagement.Visible = false;

            // DataGridView configuration
            this.dgvSellers.Location = new System.Drawing.Point(20, 20);
            this.dgvSellers.Name = "dgvSellers";
            this.dgvSellers.Size = new System.Drawing.Size(560, 300);
            this.dgvSellers.TabIndex = 1;

            // Approve Seller button configuration
            this.btnApproveSeller.Location = new System.Drawing.Point(20, 340);
            this.btnApproveSeller.Name = "btnApproveSeller";
            this.btnApproveSeller.Size = new System.Drawing.Size(100, 30);
            this.btnApproveSeller.TabIndex = 2;
            this.btnApproveSeller.Text = "Approve Seller";
            this.btnApproveSeller.UseVisualStyleBackColor = true;
            this.btnApproveSeller.Click += new System.EventHandler(this.btnApproveSeller_Click);

            // Disapprove Seller button configuration
            this.btnDisapproveSeller.Location = new System.Drawing.Point(140, 340);
            this.btnDisapproveSeller.Name = "btnDisapproveSeller";
            this.btnDisapproveSeller.Size = new System.Drawing.Size(120, 30);
            this.btnDisapproveSeller.TabIndex = 3;
            this.btnDisapproveSeller.Text = "Disapprove Seller";
            this.btnDisapproveSeller.UseVisualStyleBackColor = true;
            this.btnDisapproveSeller.Click += new System.EventHandler(this.btnDisapproveSeller_Click);

            // Delete Seller button configuration
            this.btnDeleteSeller.Location = new System.Drawing.Point(280, 340);
            this.btnDeleteSeller.Name = "btnDeleteSeller";
            this.btnDeleteSeller.Size = new System.Drawing.Size(100, 30);
            this.btnDeleteSeller.TabIndex = 4;
            this.btnDeleteSeller.Text = "Delete Seller";
            this.btnDeleteSeller.UseVisualStyleBackColor = true;
            this.btnDeleteSeller.Click += new System.EventHandler(this.btnDeleteSeller_Click);

            // Add components to the panel
            this.panelSellerManagement.Controls.Add(this.dgvSellers);
            this.panelSellerManagement.Controls.Add(this.btnApproveSeller);
            this.panelSellerManagement.Controls.Add(this.btnDisapproveSeller);
            this.panelSellerManagement.Controls.Add(this.btnDeleteSeller);

            // Add panel to the form
            this.Controls.Add(this.panelSellerManagement);
            this.panelSellerManagement.ResumeLayout(false);
        }

        private void InitializeProductManagement()
        {
            // Panel for Product Management
            panelProductManagement = new Panel
            {
                Name = "pnlProductManagement",
                Size = new System.Drawing.Size(800, 600),
                Location = new System.Drawing.Point(200, 100), // Adjust to align with your layout
                Visible = false,
            };

            // DataGridView for displaying product categories
            dgvCategories = new DataGridView
            {
                Name = "dgvCategories",
                Size = new System.Drawing.Size(600, 300),
                Location = new System.Drawing.Point(100, 50),
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            };
            dgvCategories.Columns.Add("CategoryID", "Category ID");
            dgvCategories.Columns.Add("CategoryName", "Category Name");

            // TextBox for entering/moderating product categories
            txtCategoryName = new TextBox
            {
                Name = "txtCategoryName",
                Size = new System.Drawing.Size(200, 25),
                Location = new System.Drawing.Point(100, 370),
                Text = "Enter category name...", // Placeholder text
                ForeColor = System.Drawing.Color.Gray,
            };

            txtCategoryName.Enter += (s, e) =>
            {
                if (txtCategoryName.Text == "Enter category name...")
                {
                    txtCategoryName.Text = "";
                    txtCategoryName.ForeColor = System.Drawing.Color.Black;
                }
            };

            txtCategoryName.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
                {
                    txtCategoryName.Text = "Enter category name...";
                    txtCategoryName.ForeColor = System.Drawing.Color.Gray;
                }
            };

            // Buttons for managing product categories
            btnApproveCategory = new Button
            {
                Name = "btnApproveCategory",
                Text = "Approve Category",
                Size = new System.Drawing.Size(150, 30),
                Location = new System.Drawing.Point(100, 410),
            };
            btnApproveCategory.Click += BtnApproveCategory_Click;

            btnDisapproveCategory = new Button
            {
                Name = "btnDisapproveCategory",
                Text = "Disapprove Category",
                Size = new System.Drawing.Size(150, 30),
                Location = new System.Drawing.Point(300, 410),
            };
            btnDisapproveCategory.Click += BtnDisapproveCategory_Click;

            btnDeleteCategory = new Button
            {
                Name = "btnDeleteCategory",
                Text = "Delete Category",
                Size = new System.Drawing.Size(150, 30),
                Location = new System.Drawing.Point(500, 410),
            };
            btnDeleteCategory.Click += BtnDeleteCategory_Click;

            // Add controls to panel
            panelProductManagement.Controls.Add(dgvCategories);
            panelProductManagement.Controls.Add(txtCategoryName);
            panelProductManagement.Controls.Add(btnApproveCategory);
            panelProductManagement.Controls.Add(btnDisapproveCategory);
            panelProductManagement.Controls.Add(btnDeleteCategory);

            // Add the panel to the form
            this.Controls.Add(panelProductManagement);
        }

        private void InitializeOrderOversight()
        {
            // Initialize the Order Oversight panel
            panelOrderOversight = new Panel
            {
                Name = "panelOrderOversight",
                Size = new System.Drawing.Size(916, 710), // Same size as the product management panel
                Location = new System.Drawing.Point(248, 0), // Start location after side panel
                Visible = false,
            };

            // Initialize the DataGridView to display orders
            dgvOrders = new DataGridView
            {
                Name = "dgvOrders",
                Size = new System.Drawing.Size(858, 300), // Fill the panel width with some margin
                Location = new System.Drawing.Point(20, 50), // Starting position with margin from top and left
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            };

            // Add columns to the DataGridView
            dgvOrders.Columns.Add("OrderID", "Order ID");
            dgvOrders.Columns.Add("CustomerName", "Customer");
            dgvOrders.Columns.Add("SellerName", "Seller");
            dgvOrders.Columns.Add("OrderStatus", "Status");
            dgvOrders.Columns.Add("Conflict", "Conflict Status");

            // Initialize the buttons for conflict resolution and order management
            btnResolveConflict = new Button
            {
                Name = "btnResolveConflict",
                Text = "Resolve Conflict",
                Size = new System.Drawing.Size(150, 30),
                Location = new System.Drawing.Point(20, 380), // Positioned at the bottom of the grid
            };
            btnResolveConflict.Click += BtnResolveConflict_Click;

            btnApproveOrder = new Button
            {
                Name = "btnApproveOrder",
                Text = "Approve Order",
                Size = new System.Drawing.Size(150, 30),
                Location = new System.Drawing.Point(200, 380),
            };
            btnApproveOrder.Click += BtnApproveOrder_Click;

            btnDisapproveOrder = new Button
            {
                Name = "btnDisapproveOrder",
                Text = "Disapprove Order",
                Size = new System.Drawing.Size(150, 30),
                Location = new System.Drawing.Point(380, 380),
            };
            btnDisapproveOrder.Click += BtnDisapproveOrder_Click;

            // Add the controls to the panel
            panelOrderOversight.Controls.Add(dgvOrders);
            panelOrderOversight.Controls.Add(btnResolveConflict);
            panelOrderOversight.Controls.Add(btnApproveOrder);
            panelOrderOversight.Controls.Add(btnDisapproveOrder);

            // Add the panel to the form
            this.Controls.Add(panelOrderOversight);
        }

        private void InitializeSystemReports()
        {
            // If panelReports already exists, just add the necessary controls

            // Initialize DataGridView for displaying reports
            dgvReports = new DataGridView
            {
                Name = "dgvReports",
                Size = new System.Drawing.Size(858, 400), // Large enough to show report data
                Location = new System.Drawing.Point(20, 80), // Margins around the grid
                AllowUserToAddRows = false, // Prevent adding rows manually
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, // Auto-fit columns
            };

            // Add columns to DataGridView for displaying report data
            dgvReports.Columns.Add("ReportID", "Report ID");
            dgvReports.Columns.Add("ReportName", "Report Name");
            dgvReports.Columns.Add("GeneratedOn", "Generated On");
            dgvReports.Columns.Add("Details", "Details");

            // Initialize ComboBox for selecting report type
            lblReportType = new Label
            {
                Name = "lblReportType",
                Text = "Select Report Type:",
                Location = new System.Drawing.Point(20, 20), // Positioned above the grid
                Size = new System.Drawing.Size(150, 30),
            };

            cmbReportType = new ComboBox
            {
                Name = "cmbReportType",
                Size = new System.Drawing.Size(200, 30),
                Location = new System.Drawing.Point(150, 20), // Positioned next to the label
                DropDownStyle = ComboBoxStyle.DropDownList, // Disallow typing
                Items = { "Sales Performance", "User Activity", "Platform Performance" }, // Example report types
            };

            // Initialize the Generate Report button
            btnGenerateReport = new Button
            {
                Name = "btnGenerateReport",
                Text = "Generate Report",
                Size = new System.Drawing.Size(150, 30),
                Location = new System.Drawing.Point(400, 20), // Positioned beside the ComboBox
            };
            btnGenerateReport.Click += BtnGenerateReport_Click; // Event handler for generating reports

            // Initialize the Export Report button
            btnExportReport = new Button
            {
                Name = "btnExportReport",
                Text = "Export Report",
                Size = new System.Drawing.Size(150, 30),
                Location = new System.Drawing.Point(600, 20), // Positioned beside the Generate button
            };
            btnExportReport.Click += BtnExportReport_Click; // Event handler for exporting reports

            // Add controls to the panelReports (which already exists)
            panelReports.Controls.Add(dgvReports);
            panelReports.Controls.Add(lblReportType);
            panelReports.Controls.Add(cmbReportType);
            panelReports.Controls.Add(btnGenerateReport);
            panelReports.Controls.Add(btnExportReport);

            // Add the panel to the form (it might already be in the form)
            if (!this.Controls.Contains(panelReports))
            {
                this.Controls.Add(panelReports);
            }

            // Optionally, handle button visibility for btnSystemReport
            btnSystemReport.Click += (sender, e) =>
            {
                // Toggle panel visibility
                panelReports.Visible = !panelReports.Visible;
            };
        }

        private void InitializeFeedback()
        {
            // Panel for Feedback Management
            panelFeedback = new System.Windows.Forms.Panel();
            panelFeedback.Name = "panelFeedback";
            panelFeedback.Size = new System.Drawing.Size(800, 600);
            panelFeedback.Location = new System.Drawing.Point(248, 0); // Since side panel width is 248
            panelFeedback.Visible = false;

            // DataGridView for displaying user reviews
            DataGridView dgvFeedback = new DataGridView
            {
                Name = "dgvFeedback",
                Size = new System.Drawing.Size(600, 300),
                Location = new System.Drawing.Point(100, 50),
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            };

            // Add columns to DataGridView
            dgvFeedback.Columns.Add("ReviewID", "Review ID");
            dgvFeedback.Columns.Add("UserName", "User Name");
            dgvFeedback.Columns.Add("ReviewContent", "Review Content");
            dgvFeedback.Columns.Add("Status", "Status"); // Approve/Flagged

            // Buttons for moderating reviews
            Button btnApproveFeedback = new Button
            {
                Name = "btnApproveFeedback",
                Text = "Approve Review",
                Size = new System.Drawing.Size(150, 30),
                Location = new System.Drawing.Point(100, 370),
            };
            btnApproveFeedback.Click += BtnApproveFeedback_Click;

            Button btnFlagFeedback = new Button
            {
                Name = "btnFlagFeedback",
                Text = "Flag Review",
                Size = new System.Drawing.Size(150, 30),
                Location = new System.Drawing.Point(300, 370),
            };
            btnFlagFeedback.Click += BtnFlagFeedback_Click;

            Button btnDeleteFeedback = new Button
            {
                Name = "btnDeleteFeedback",
                Text = "Delete Review",
                Size = new System.Drawing.Size(150, 30),
                Location = new System.Drawing.Point(500, 370),
            };
            btnDeleteFeedback.Click += BtnDeleteFeedback_Click;

            // Add controls to panel
            panelFeedback.Controls.Add(dgvFeedback);
            panelFeedback.Controls.Add(btnApproveFeedback);
            panelFeedback.Controls.Add(btnFlagFeedback);
            panelFeedback.Controls.Add(btnDeleteFeedback);

            // Add the panel to the form
            this.Controls.Add(panelFeedback);
        }

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelNav;
        private System.Windows.Forms.Button btnUmanagement;
        private System.Windows.Forms.Button btnSmanagement;
        private System.Windows.Forms.Button btnPCManagement;
        private System.Windows.Forms.Button btnOrderOversight;
        private System.Windows.Forms.Button btnSystemReport;
        private System.Windows.Forms.Button btnFeedback;

        private System.Windows.Forms.Panel panelProductManagement;
        private System.Windows.Forms.Panel panelOrderOversight;
        private System.Windows.Forms.Panel panelReports;
        private System.Windows.Forms.Panel panelFeedback;
        private System.Windows.Forms.Panel panelUserManagement;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnDeleteUser;

        private System.Windows.Forms.Panel panelSellerManagement;
        private System.Windows.Forms.DataGridView dgvSellers;  // To show list of sellers
        private System.Windows.Forms.Button btnApproveSeller;
        private System.Windows.Forms.Button btnDisapproveSeller;
        private System.Windows.Forms.Button btnDeleteSeller;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCategoryName;

        private DataGridView dgvCategories;

        private Button btnApproveCategory;
        private Button btnDisapproveCategory;
        private Button btnDeleteCategory;

        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Button btnResolveConflict;
        private System.Windows.Forms.Button btnApproveOrder;
        private System.Windows.Forms.Button btnDisapproveOrder;

        private System.Windows.Forms.DataGridView dgvReports;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Button btnExportReport;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label lblReportType;

        private DataGridView dgvFeedback;

        private System.Windows.Forms.DataGridView dgvUsersAndSellers;
        private System.Windows.Forms.DataGridView dgvReviews;


    }
}
