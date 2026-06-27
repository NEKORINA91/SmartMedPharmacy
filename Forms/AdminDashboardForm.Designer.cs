namespace SmartMedPharmacy.Forms
{
    partial class AdminDashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlSidebar           = new System.Windows.Forms.Panel();
            this.pnlLogoArea          = new System.Windows.Forms.Panel();
            this.lblLogoSmart         = new System.Windows.Forms.Label();
            this.lblLogoMed           = new System.Windows.Forms.Label();
            this.btnHome              = new System.Windows.Forms.Button();
            this.btnManageMedicine    = new System.Windows.Forms.Button();
            this.btnManageCustomers   = new System.Windows.Forms.Button();
            this.btnManageOrders      = new System.Windows.Forms.Button();
            this.btnReports           = new System.Windows.Forms.Button();
            this.btnLogout            = new System.Windows.Forms.Button();
            this.pnlLogout            = new System.Windows.Forms.Panel();
            this.panelContent         = new System.Windows.Forms.Panel();
            this.panelHome            = new System.Windows.Forms.Panel();
            this.lblWelcome           = new System.Windows.Forms.Label();
            this.pnlStats             = new System.Windows.Forms.Panel();
            this.cardSales            = new System.Windows.Forms.Panel();
            this.lblSalesTitle        = new System.Windows.Forms.Label();
            this.lblTotalSalesValue   = new System.Windows.Forms.Label();
            this.cardStock            = new System.Windows.Forms.Panel();
            this.lblStockTitle        = new System.Windows.Forms.Label();
            this.lblStockValue        = new System.Windows.Forms.Label();
            this.cardOrders           = new System.Windows.Forms.Panel();
            this.lblOrdersTitle       = new System.Windows.Forms.Label();
            this.lblActiveOrdersValue = new System.Windows.Forms.Label();
            this.cardLowStock         = new System.Windows.Forms.Panel();
            this.lblLowStockTitle     = new System.Windows.Forms.Label();
            this.lblLowStockValue2    = new System.Windows.Forms.Label();
            this.lblRecentOrders      = new System.Windows.Forms.Label();
            this.dgvRecentOrders      = new System.Windows.Forms.DataGridView();
            this.colOrderID           = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer          = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate              = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal             = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus            = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlLogout.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlLogoArea.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelHome.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.cardSales.SuspendLayout();
            this.cardStock.SuspendLayout();
            this.cardOrders.SuspendLayout();
            this.cardLowStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentOrders)).BeginInit();
            this.SuspendLayout();

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = UITheme.Background;
            this.ClientSize          = new System.Drawing.Size(1100, 680);
            this.Font                = UITheme.FontBody;
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize         = new System.Drawing.Size(900, 580);
            this.Name                = "AdminDashboardForm";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "SmartMed Admin";
            this.FormClosed         += new System.Windows.Forms.FormClosedEventHandler(this.AdminDashboardForm_FormClosed);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.pnlSidebar);

            // Sidebar
            this.pnlSidebar.BackColor = UITheme.Sidebar;
            this.pnlSidebar.Dock      = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Name      = "pnlSidebar";
            this.pnlSidebar.Width     = UITheme.SidebarWidth;
            this.pnlSidebar.Controls.Add(this.pnlLogoArea);
            this.pnlSidebar.Controls.Add(this.btnHome);
            this.pnlSidebar.Controls.Add(this.btnManageMedicine);
            this.pnlSidebar.Controls.Add(this.btnManageCustomers);
            this.pnlSidebar.Controls.Add(this.btnManageOrders);
            this.pnlSidebar.Controls.Add(this.btnReports);
            this.pnlSidebar.Controls.Add(this.pnlLogout);

            this.pnlLogoArea.BackColor = UITheme.Sidebar;
            this.pnlLogoArea.Location  = new System.Drawing.Point(0, 0);
            this.pnlLogoArea.Name      = "pnlLogoArea";
            this.pnlLogoArea.Size      = new System.Drawing.Size(UITheme.SidebarWidth, 72);
            this.pnlLogoArea.Controls.Add(this.lblLogoSmart);
            this.pnlLogoArea.Controls.Add(this.lblLogoMed);

            this.lblLogoSmart.AutoSize  = true;
            this.lblLogoSmart.BackColor = System.Drawing.Color.Transparent;
            this.lblLogoSmart.Font      = UITheme.FontLogo;
            this.lblLogoSmart.ForeColor = System.Drawing.Color.White;
            this.lblLogoSmart.Location  = new System.Drawing.Point(16, 22);
            this.lblLogoSmart.Name      = "lblLogoSmart";
            this.lblLogoSmart.Text      = "SMART";

            this.lblLogoMed.AutoSize    = true;
            this.lblLogoMed.BackColor   = System.Drawing.Color.Transparent;
            this.lblLogoMed.Font        = UITheme.FontLogo;
            this.lblLogoMed.ForeColor   = UITheme.Accent;
            this.lblLogoMed.Location    = new System.Drawing.Point(86, 22);
            this.lblLogoMed.Name        = "lblLogoMed";
            this.lblLogoMed.Text        = "MED";

            System.Action<System.Windows.Forms.Button, string, int, bool> nav =
                (btn, text, top, active) =>
                {
                    btn.BackColor = active ? UITheme.SidebarActive : UITheme.Sidebar;
                    btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize         = 0;
                    btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(45, 58, 74);
                    btn.FlatAppearance.MouseDownBackColor = UITheme.AccentDark;
                    btn.Font      = UITheme.FontSidebarItem;
                    btn.ForeColor = active ? System.Drawing.Color.White : UITheme.SidebarText;
                    btn.Location  = new System.Drawing.Point(0, top);
                    btn.Size      = new System.Drawing.Size(UITheme.SidebarWidth, UITheme.SidebarItemHeight);
                    btn.TabStop   = false;
                    btn.Text      = "   " + text;
                    btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    btn.Cursor    = System.Windows.Forms.Cursors.Hand;
                    btn.UseVisualStyleBackColor = false;
                };

            this.btnHome.Name = "btnHome";
            nav(this.btnHome, "Dashboard", 80, true);
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);

            this.btnManageMedicine.Name = "btnManageMedicine";
            nav(this.btnManageMedicine, "Manage Medicines", 124, false);
            this.btnManageMedicine.Click += new System.EventHandler(this.btnManageMedicine_Click);

            this.btnManageCustomers.Name = "btnManageCustomers";
            nav(this.btnManageCustomers, "Manage Customers", 168, false);
            this.btnManageCustomers.Click += new System.EventHandler(this.btnManageCustomers_Click);

            this.btnManageOrders.Name = "btnManageOrders";
            nav(this.btnManageOrders, "View Orders", 212, false);
            this.btnManageOrders.Click += new System.EventHandler(this.btnManageOrders_Click);

            this.btnReports.Name = "btnReports";
            nav(this.btnReports, "Reports", 256, false);
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);

            // pnlLogout — docked to bottom of sidebar so it always shows
            this.pnlLogout.BackColor = UITheme.Sidebar;
            this.pnlLogout.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLogout.Name      = "pnlLogout";
            this.pnlLogout.Size      = new System.Drawing.Size(UITheme.SidebarWidth, UITheme.SidebarItemHeight);
            this.pnlLogout.Controls.Add(this.btnLogout);

            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize         = 0;
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(45, 58, 74);
            this.btnLogout.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.btnLogout.Font      = UITheme.FontSidebarItem;
            this.btnLogout.ForeColor = UITheme.SidebarText;
            this.btnLogout.Name      = "btnLogout";
            this.btnLogout.TabStop   = false;
            this.btnLogout.Text      = "   Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // panelContent
            this.panelContent.BackColor = UITheme.Background;
            this.panelContent.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Name      = "panelContent";
            this.panelContent.Controls.Add(this.panelHome);

            // panelHome
            this.panelHome.BackColor = UITheme.Background;
            this.panelHome.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.panelHome.Name      = "panelHome";
            this.panelHome.Padding   = new System.Windows.Forms.Padding(UITheme.ContentPadding);
            this.panelHome.Controls.Add(this.lblWelcome);
            this.panelHome.Controls.Add(this.pnlStats);
            this.panelHome.Controls.Add(this.lblRecentOrders);
            this.panelHome.Controls.Add(this.dgvRecentOrders);

            this.lblWelcome.AutoSize  = true;
            this.lblWelcome.Font      = UITheme.FontHeading;
            this.lblWelcome.ForeColor = UITheme.TextPrimary;
            this.lblWelcome.Location  = new System.Drawing.Point(UITheme.ContentPadding, UITheme.ContentPadding);
            this.lblWelcome.Name      = "lblWelcome";
            this.lblWelcome.Text      = "Welcome, System Admin";

            // Stats row
            this.pnlStats.BackColor = System.Drawing.Color.Transparent;
            this.pnlStats.Location  = new System.Drawing.Point(UITheme.ContentPadding, 72);
            this.pnlStats.Name      = "pnlStats";
            this.pnlStats.Size      = new System.Drawing.Size(820, UITheme.StatCardHeight + 4);
            this.pnlStats.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.pnlStats.Controls.Add(this.cardSales);
            this.pnlStats.Controls.Add(this.cardStock);
            this.pnlStats.Controls.Add(this.cardOrders);
            this.pnlStats.Controls.Add(this.cardLowStock);

            System.Action<System.Windows.Forms.Panel, int> placeCard =
                (card, col) =>
                {
                    card.BackColor   = UITheme.StatCardBg;
                    card.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    card.Location    = new System.Drawing.Point(col * (UITheme.StatCardWidth + 14), 0);
                    card.Size        = new System.Drawing.Size(UITheme.StatCardWidth, UITheme.StatCardHeight);
                };

            placeCard(this.cardSales,    0);
            placeCard(this.cardStock,    1);
            placeCard(this.cardOrders,   2);
            placeCard(this.cardLowStock, 3);

            this.cardSales.Name = "cardSales";
            this.cardSales.Controls.Add(this.lblSalesTitle);
            this.cardSales.Controls.Add(this.lblTotalSalesValue);

            this.lblSalesTitle.AutoSize  = true;
            this.lblSalesTitle.Font      = UITheme.FontStatLabel;
            this.lblSalesTitle.ForeColor = UITheme.TextSecondary;
            this.lblSalesTitle.Location  = new System.Drawing.Point(12, 10);
            this.lblSalesTitle.Name      = "lblSalesTitle";
            this.lblSalesTitle.Text      = "Today's Sales";

            this.lblTotalSalesValue.AutoSize  = true;
            this.lblTotalSalesValue.Font      = new System.Drawing.Font("Segoe UI", 16f, System.Drawing.FontStyle.Bold);
            this.lblTotalSalesValue.ForeColor = UITheme.TextPrimary;
            this.lblTotalSalesValue.Location  = new System.Drawing.Point(12, 30);
            this.lblTotalSalesValue.Name      = "lblTotalSalesValue";
            this.lblTotalSalesValue.Text      = "Rs. 0.00";

            this.cardStock.Name = "cardStock";
            this.cardStock.Controls.Add(this.lblStockTitle);
            this.cardStock.Controls.Add(this.lblStockValue);

            this.lblStockTitle.AutoSize  = true;
            this.lblStockTitle.Font      = UITheme.FontStatLabel;
            this.lblStockTitle.ForeColor = UITheme.TextSecondary;
            this.lblStockTitle.Location  = new System.Drawing.Point(12, 10);
            this.lblStockTitle.Name      = "lblStockTitle";
            this.lblStockTitle.Text      = "Medicines in Stock";

            this.lblStockValue.AutoSize  = true;
            this.lblStockValue.Font      = UITheme.FontStat;
            this.lblStockValue.ForeColor = UITheme.TextPrimary;
            this.lblStockValue.Location  = new System.Drawing.Point(12, 30);
            this.lblStockValue.Name      = "lblStockValue";
            this.lblStockValue.Text      = "0";

            this.cardOrders.Name = "cardOrders";
            this.cardOrders.Controls.Add(this.lblOrdersTitle);
            this.cardOrders.Controls.Add(this.lblActiveOrdersValue);

            this.lblOrdersTitle.AutoSize  = true;
            this.lblOrdersTitle.Font      = UITheme.FontStatLabel;
            this.lblOrdersTitle.ForeColor = UITheme.TextSecondary;
            this.lblOrdersTitle.Location  = new System.Drawing.Point(12, 10);
            this.lblOrdersTitle.Name      = "lblOrdersTitle";
            this.lblOrdersTitle.Text      = "Active Orders";

            this.lblActiveOrdersValue.AutoSize  = true;
            this.lblActiveOrdersValue.Font      = UITheme.FontStat;
            this.lblActiveOrdersValue.ForeColor = UITheme.TextPrimary;
            this.lblActiveOrdersValue.Location  = new System.Drawing.Point(12, 30);
            this.lblActiveOrdersValue.Name      = "lblActiveOrdersValue";
            this.lblActiveOrdersValue.Text      = "0";

            this.cardLowStock.Name = "cardLowStock";
            this.cardLowStock.Controls.Add(this.lblLowStockTitle);
            this.cardLowStock.Controls.Add(this.lblLowStockValue2);

            this.lblLowStockTitle.AutoSize  = true;
            this.lblLowStockTitle.Font      = UITheme.FontStatLabel;
            this.lblLowStockTitle.ForeColor = UITheme.TextSecondary;
            this.lblLowStockTitle.Location  = new System.Drawing.Point(12, 10);
            this.lblLowStockTitle.Name      = "lblLowStockTitle";
            this.lblLowStockTitle.Text      = "Low Stock Alerts";

            this.lblLowStockValue2.AutoSize  = true;
            this.lblLowStockValue2.Font      = UITheme.FontStat;
            this.lblLowStockValue2.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.lblLowStockValue2.Location  = new System.Drawing.Point(12, 30);
            this.lblLowStockValue2.Name      = "lblLowStockValue2";
            this.lblLowStockValue2.Text      = "-";

            this.lblRecentOrders.AutoSize  = true;
            this.lblRecentOrders.Font      = UITheme.FontSubHeading;
            this.lblRecentOrders.ForeColor = UITheme.TextPrimary;
            this.lblRecentOrders.Location  = new System.Drawing.Point(UITheme.ContentPadding, 184);
            this.lblRecentOrders.Name      = "lblRecentOrders";
            this.lblRecentOrders.Text      = "Recent Customer Orders";

            this.dgvRecentOrders.AllowUserToAddRows    = false;
            this.dgvRecentOrders.AllowUserToDeleteRows = false;
            this.dgvRecentOrders.AllowUserToResizeRows = false;
            this.dgvRecentOrders.ReadOnly              = true;
            this.dgvRecentOrders.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecentOrders.MultiSelect           = false;
            this.dgvRecentOrders.RowHeadersVisible     = false;
            this.dgvRecentOrders.BorderStyle           = System.Windows.Forms.BorderStyle.None;
            this.dgvRecentOrders.CellBorderStyle       = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRecentOrders.BackgroundColor       = UITheme.Surface;
            this.dgvRecentOrders.GridColor             = UITheme.Border;
            this.dgvRecentOrders.Font                  = UITheme.FontBody;
            this.dgvRecentOrders.Location              = new System.Drawing.Point(UITheme.ContentPadding, 212);
            this.dgvRecentOrders.Name                  = "dgvRecentOrders";
            this.dgvRecentOrders.Size                  = new System.Drawing.Size(820, 390);
            this.dgvRecentOrders.Anchor                = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom;
            this.dgvRecentOrders.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecentOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentOrders.EnableHeadersVisualStyles   = false;

            this.dgvRecentOrders.ColumnHeadersDefaultCellStyle.BackColor          = UITheme.Background;
            this.dgvRecentOrders.ColumnHeadersDefaultCellStyle.ForeColor          = UITheme.TextSecondary;
            this.dgvRecentOrders.ColumnHeadersDefaultCellStyle.Font               = UITheme.FontTableHeader;
            this.dgvRecentOrders.ColumnHeadersDefaultCellStyle.SelectionBackColor = UITheme.Background;
            this.dgvRecentOrders.ColumnHeadersDefaultCellStyle.SelectionForeColor = UITheme.TextSecondary;
            this.dgvRecentOrders.DefaultCellStyle.BackColor          = UITheme.Surface;
            this.dgvRecentOrders.DefaultCellStyle.ForeColor          = UITheme.TextPrimary;
            this.dgvRecentOrders.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(224, 247, 246);
            this.dgvRecentOrders.DefaultCellStyle.SelectionForeColor = UITheme.TextPrimary;
            this.dgvRecentOrders.DefaultCellStyle.Padding            = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dgvRecentOrders.RowTemplate.Height                  = 36;
            this.dgvRecentOrders.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);

            this.colOrderID.HeaderText = "Order ID"; this.colOrderID.DataPropertyName = "OrderID"; this.colOrderID.FillWeight = 80; this.colOrderID.Name = "colOrderID";
            this.colCustomer.HeaderText = "Customer"; this.colCustomer.DataPropertyName = "CustomerName"; this.colCustomer.FillWeight = 160; this.colCustomer.Name = "colCustomer";
            this.colDate.HeaderText = "Date"; this.colDate.DataPropertyName = "OrderDate"; this.colDate.FillWeight = 130; this.colDate.Name = "colDate";
            this.colTotal.HeaderText = "Total"; this.colTotal.DataPropertyName = "TotalAmount"; this.colTotal.FillWeight = 90; this.colTotal.Name = "colTotal"; this.colTotal.DefaultCellStyle.Format = "C2";
            this.colStatus.HeaderText = "Status"; this.colStatus.DataPropertyName = "Status"; this.colStatus.FillWeight = 100; this.colStatus.Name = "colStatus";
            this.dgvRecentOrders.Columns.AddRange(this.colOrderID, this.colCustomer, this.colDate, this.colTotal, this.colStatus);

            this.cardSales.ResumeLayout(false);    this.cardSales.PerformLayout();
            this.cardStock.ResumeLayout(false);    this.cardStock.PerformLayout();
            this.cardOrders.ResumeLayout(false);   this.cardOrders.PerformLayout();
            this.cardLowStock.ResumeLayout(false); this.cardLowStock.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentOrders)).EndInit();
            this.panelHome.ResumeLayout(false);    this.panelHome.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.pnlLogoArea.ResumeLayout(false);  this.pnlLogoArea.PerformLayout();
            this.pnlLogout.ResumeLayout(false);
            this.pnlSidebar.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel          pnlSidebar;
        private System.Windows.Forms.Panel          pnlLogoArea;
        private System.Windows.Forms.Label          lblLogoSmart;
        private System.Windows.Forms.Label          lblLogoMed;
        private System.Windows.Forms.Button         btnHome;
        private System.Windows.Forms.Button         btnManageMedicine;
        private System.Windows.Forms.Button         btnManageCustomers;
        private System.Windows.Forms.Button         btnManageOrders;
        private System.Windows.Forms.Button         btnReports;
        private System.Windows.Forms.Button         btnLogout;
        private System.Windows.Forms.Panel          pnlLogout;
        private System.Windows.Forms.Panel          panelContent;
        private System.Windows.Forms.Panel          panelHome;
        private System.Windows.Forms.Label          lblWelcome;
        private System.Windows.Forms.Panel          pnlStats;
        private System.Windows.Forms.Panel          cardSales;
        private System.Windows.Forms.Label          lblSalesTitle;
        private System.Windows.Forms.Label          lblTotalSalesValue;
        private System.Windows.Forms.Panel          cardStock;
        private System.Windows.Forms.Label          lblStockTitle;
        private System.Windows.Forms.Label          lblStockValue;
        private System.Windows.Forms.Panel          cardOrders;
        private System.Windows.Forms.Label          lblOrdersTitle;
        private System.Windows.Forms.Label          lblActiveOrdersValue;
        private System.Windows.Forms.Panel          cardLowStock;
        private System.Windows.Forms.Label          lblLowStockTitle;
        private System.Windows.Forms.Label          lblLowStockValue2;
        private System.Windows.Forms.Label          lblRecentOrders;
        private System.Windows.Forms.DataGridView   dgvRecentOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}
