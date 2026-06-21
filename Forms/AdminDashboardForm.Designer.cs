namespace SmartMedPharmacy.Forms
{
    partial class AdminDashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnManageOrders = new System.Windows.Forms.Button();
            this.btnManageCustomers = new System.Windows.Forms.Button();
            this.btnManageMedicine = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.lblSidebarTitle = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelHome = new System.Windows.Forms.Panel();
            this.tileActiveOrders = new System.Windows.Forms.Panel();
            this.lblActiveOrdersValue = new System.Windows.Forms.Label();
            this.lblActiveOrdersTitle = new System.Windows.Forms.Label();
            this.tileStock = new System.Windows.Forms.Panel();
            this.lblStockValue = new System.Windows.Forms.Label();
            this.lblStockTitle = new System.Windows.Forms.Label();
            this.tileTotalSales = new System.Windows.Forms.Panel();
            this.lblTotalSalesValue = new System.Windows.Forms.Label();
            this.lblTotalSalesTitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panelSidebar.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelHome.SuspendLayout();
            this.tileActiveOrders.SuspendLayout();
            this.tileStock.SuspendLayout();
            this.tileTotalSales.SuspendLayout();
            this.SuspendLayout();

            // panelSidebar
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(33, 47, 61);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.btnReports);
            this.panelSidebar.Controls.Add(this.btnManageOrders);
            this.panelSidebar.Controls.Add(this.btnManageCustomers);
            this.panelSidebar.Controls.Add(this.btnManageMedicine);
            this.panelSidebar.Controls.Add(this.btnHome);
            this.panelSidebar.Controls.Add(this.lblSidebarTitle);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(200, 600);

            // lblSidebarTitle
            this.lblSidebarTitle.AutoSize = true;
            this.lblSidebarTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSidebarTitle.ForeColor = System.Drawing.Color.White;
            this.lblSidebarTitle.Location = new System.Drawing.Point(20, 20);
            this.lblSidebarTitle.Name = "lblSidebarTitle";
            this.lblSidebarTitle.Size = new System.Drawing.Size(120, 21);
            this.lblSidebarTitle.Text = "SmartMed Admin";

            // btnHome
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.Location = new System.Drawing.Point(0, 80);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(200, 40);
            this.btnHome.Text = "Dashboard";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(33, 47, 61);
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);

            // btnManageMedicine
            this.btnManageMedicine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageMedicine.ForeColor = System.Drawing.Color.White;
            this.btnManageMedicine.FlatAppearance.BorderSize = 0;
            this.btnManageMedicine.Location = new System.Drawing.Point(0, 120);
            this.btnManageMedicine.Name = "btnManageMedicine";
            this.btnManageMedicine.Size = new System.Drawing.Size(200, 40);
            this.btnManageMedicine.Text = "Manage Medicine";
            this.btnManageMedicine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageMedicine.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnManageMedicine.UseVisualStyleBackColor = false;
            this.btnManageMedicine.BackColor = System.Drawing.Color.FromArgb(33, 47, 61);
            this.btnManageMedicine.Click += new System.EventHandler(this.btnManageMedicine_Click);

            // btnManageCustomers
            this.btnManageCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageCustomers.ForeColor = System.Drawing.Color.White;
            this.btnManageCustomers.FlatAppearance.BorderSize = 0;
            this.btnManageCustomers.Location = new System.Drawing.Point(0, 160);
            this.btnManageCustomers.Name = "btnManageCustomers";
            this.btnManageCustomers.Size = new System.Drawing.Size(200, 40);
            this.btnManageCustomers.Text = "Manage Customers";
            this.btnManageCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageCustomers.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnManageCustomers.UseVisualStyleBackColor = false;
            this.btnManageCustomers.BackColor = System.Drawing.Color.FromArgb(33, 47, 61);
            this.btnManageCustomers.Click += new System.EventHandler(this.btnManageCustomers_Click);

            // btnManageOrders
            this.btnManageOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageOrders.ForeColor = System.Drawing.Color.White;
            this.btnManageOrders.FlatAppearance.BorderSize = 0;
            this.btnManageOrders.Location = new System.Drawing.Point(0, 200);
            this.btnManageOrders.Name = "btnManageOrders";
            this.btnManageOrders.Size = new System.Drawing.Size(200, 40);
            this.btnManageOrders.Text = "Manage Orders";
            this.btnManageOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageOrders.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnManageOrders.UseVisualStyleBackColor = false;
            this.btnManageOrders.BackColor = System.Drawing.Color.FromArgb(33, 47, 61);
            this.btnManageOrders.Click += new System.EventHandler(this.btnManageOrders_Click);

            // btnReports
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.Location = new System.Drawing.Point(0, 240);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(200, 40);
            this.btnReports.Text = "Reports";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(33, 47, 61);
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);

            // btnLogout
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.Location = new System.Drawing.Point(0, 520);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(200, 40);
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(33, 47, 61);
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // panelMain
            this.panelMain.Controls.Add(this.panelContent);
            this.panelMain.Controls.Add(this.panelHome);
            this.panelMain.Controls.Add(this.lblWelcome);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(200, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(30);
            this.panelMain.Size = new System.Drawing.Size(800, 600);

            // lblWelcome
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(30, 30);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(180, 25);
            this.lblWelcome.Text = "Welcome, Admin";

            // panelHome (the stat tiles live in here, shown on dashboard home)
            this.panelHome.Controls.Add(this.tileActiveOrders);
            this.panelHome.Controls.Add(this.tileStock);
            this.panelHome.Controls.Add(this.tileTotalSales);
            this.panelHome.Location = new System.Drawing.Point(30, 80);
            this.panelHome.Name = "panelHome";
            this.panelHome.Size = new System.Drawing.Size(740, 200);

            // tileTotalSales
            this.tileTotalSales.BackColor = System.Drawing.Color.FromArgb(46, 134, 122);
            this.tileTotalSales.Controls.Add(this.lblTotalSalesValue);
            this.tileTotalSales.Controls.Add(this.lblTotalSalesTitle);
            this.tileTotalSales.Location = new System.Drawing.Point(0, 0);
            this.tileTotalSales.Name = "tileTotalSales";
            this.tileTotalSales.Size = new System.Drawing.Size(230, 120);

            // lblTotalSalesTitle
            this.lblTotalSalesTitle.AutoSize = true;
            this.lblTotalSalesTitle.ForeColor = System.Drawing.Color.White;
            this.lblTotalSalesTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalSalesTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTotalSalesTitle.Name = "lblTotalSalesTitle";
            this.lblTotalSalesTitle.Size = new System.Drawing.Size(100, 19);
            this.lblTotalSalesTitle.Text = "Total Sales";

            // lblTotalSalesValue
            this.lblTotalSalesValue.AutoSize = true;
            this.lblTotalSalesValue.ForeColor = System.Drawing.Color.White;
            this.lblTotalSalesValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotalSalesValue.Location = new System.Drawing.Point(20, 55);
            this.lblTotalSalesValue.Name = "lblTotalSalesValue";
            this.lblTotalSalesValue.Size = new System.Drawing.Size(100, 32);
            this.lblTotalSalesValue.Text = "Rs. 0.00";

            // tileStock
            this.tileStock.BackColor = System.Drawing.Color.FromArgb(52, 99, 168);
            this.tileStock.Controls.Add(this.lblStockValue);
            this.tileStock.Controls.Add(this.lblStockTitle);
            this.tileStock.Location = new System.Drawing.Point(250, 0);
            this.tileStock.Name = "tileStock";
            this.tileStock.Size = new System.Drawing.Size(230, 120);

            // lblStockTitle
            this.lblStockTitle.AutoSize = true;
            this.lblStockTitle.ForeColor = System.Drawing.Color.White;
            this.lblStockTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStockTitle.Location = new System.Drawing.Point(20, 20);
            this.lblStockTitle.Name = "lblStockTitle";
            this.lblStockTitle.Size = new System.Drawing.Size(150, 19);
            this.lblStockTitle.Text = "Medicines in Stock";

            // lblStockValue
            this.lblStockValue.AutoSize = true;
            this.lblStockValue.ForeColor = System.Drawing.Color.White;
            this.lblStockValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblStockValue.Location = new System.Drawing.Point(20, 55);
            this.lblStockValue.Name = "lblStockValue";
            this.lblStockValue.Size = new System.Drawing.Size(50, 32);
            this.lblStockValue.Text = "0";

            // tileActiveOrders
            this.tileActiveOrders.BackColor = System.Drawing.Color.FromArgb(168, 109, 52);
            this.tileActiveOrders.Controls.Add(this.lblActiveOrdersValue);
            this.tileActiveOrders.Controls.Add(this.lblActiveOrdersTitle);
            this.tileActiveOrders.Location = new System.Drawing.Point(500, 0);
            this.tileActiveOrders.Name = "tileActiveOrders";
            this.tileActiveOrders.Size = new System.Drawing.Size(230, 120);

            // lblActiveOrdersTitle
            this.lblActiveOrdersTitle.AutoSize = true;
            this.lblActiveOrdersTitle.ForeColor = System.Drawing.Color.White;
            this.lblActiveOrdersTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblActiveOrdersTitle.Location = new System.Drawing.Point(20, 20);
            this.lblActiveOrdersTitle.Name = "lblActiveOrdersTitle";
            this.lblActiveOrdersTitle.Size = new System.Drawing.Size(100, 19);
            this.lblActiveOrdersTitle.Text = "Active Orders";

            // lblActiveOrdersValue
            this.lblActiveOrdersValue.AutoSize = true;
            this.lblActiveOrdersValue.ForeColor = System.Drawing.Color.White;
            this.lblActiveOrdersValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblActiveOrdersValue.Location = new System.Drawing.Point(20, 55);
            this.lblActiveOrdersValue.Name = "lblActiveOrdersValue";
            this.lblActiveOrdersValue.Size = new System.Drawing.Size(50, 32);
            this.lblActiveOrdersValue.Text = "0";

            // panelContent (empty for now - future forms load in here)
            this.panelContent.Location = new System.Drawing.Point(30, 80);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(740, 480);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.None;

            // AdminDashboardForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSidebar);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "AdminDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Dashboard - SmartMed Pharmacy";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminDashboardForm_FormClosed);
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelHome.ResumeLayout(false);
            this.tileActiveOrders.ResumeLayout(false);
            this.tileActiveOrders.PerformLayout();
            this.tileStock.ResumeLayout(false);
            this.tileStock.PerformLayout();
            this.tileTotalSales.ResumeLayout(false);
            this.tileTotalSales.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Label lblSidebarTitle;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnManageMedicine;
        private System.Windows.Forms.Button btnManageCustomers;
        private System.Windows.Forms.Button btnManageOrders;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel panelHome;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel tileTotalSales;
        private System.Windows.Forms.Label lblTotalSalesTitle;
        private System.Windows.Forms.Label lblTotalSalesValue;
        private System.Windows.Forms.Panel tileStock;
        private System.Windows.Forms.Label lblStockTitle;
        private System.Windows.Forms.Label lblStockValue;
        private System.Windows.Forms.Panel tileActiveOrders;
        private System.Windows.Forms.Label lblActiveOrdersTitle;
        private System.Windows.Forms.Label lblActiveOrdersValue;
    }
}
