namespace SmartMedPharmacy.Forms
{
    partial class CustomerDashboardForm
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
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnMyOrders = new System.Windows.Forms.Button();
            this.btnSearchMedicines = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.lblSidebarTitle = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelHome = new System.Windows.Forms.Panel();
            this.lblHomeMessage = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panelSidebar.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelHome.SuspendLayout();
            this.SuspendLayout();

            // panelSidebar
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(33, 47, 61);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.btnProfile);
            this.panelSidebar.Controls.Add(this.btnMyOrders);
            this.panelSidebar.Controls.Add(this.btnSearchMedicines);
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
            this.lblSidebarTitle.Size = new System.Drawing.Size(140, 21);
            this.lblSidebarTitle.Text = "SmartMed Pharmacy";

            // btnHome
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.Location = new System.Drawing.Point(0, 80);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(200, 40);
            this.btnHome.Text = "Home";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(33, 47, 61);
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);

            // btnSearchMedicines
            this.btnSearchMedicines.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchMedicines.ForeColor = System.Drawing.Color.White;
            this.btnSearchMedicines.FlatAppearance.BorderSize = 0;
            this.btnSearchMedicines.Location = new System.Drawing.Point(0, 120);
            this.btnSearchMedicines.Name = "btnSearchMedicines";
            this.btnSearchMedicines.Size = new System.Drawing.Size(200, 40);
            this.btnSearchMedicines.Text = "Search Medicines";
            this.btnSearchMedicines.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchMedicines.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnSearchMedicines.UseVisualStyleBackColor = false;
            this.btnSearchMedicines.BackColor = System.Drawing.Color.FromArgb(33, 47, 61);
            this.btnSearchMedicines.Click += new System.EventHandler(this.btnSearchMedicines_Click);

            // btnMyOrders
            this.btnMyOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyOrders.ForeColor = System.Drawing.Color.White;
            this.btnMyOrders.FlatAppearance.BorderSize = 0;
            this.btnMyOrders.Location = new System.Drawing.Point(0, 160);
            this.btnMyOrders.Name = "btnMyOrders";
            this.btnMyOrders.Size = new System.Drawing.Size(200, 40);
            this.btnMyOrders.Text = "My Orders";
            this.btnMyOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMyOrders.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnMyOrders.UseVisualStyleBackColor = false;
            this.btnMyOrders.BackColor = System.Drawing.Color.FromArgb(33, 47, 61);
            this.btnMyOrders.Click += new System.EventHandler(this.btnMyOrders_Click);

            // btnProfile
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.ForeColor = System.Drawing.Color.White;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.Location = new System.Drawing.Point(0, 200);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(200, 40);
            this.btnProfile.Text = "My Profile";
            this.btnProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfile.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.BackColor = System.Drawing.Color.FromArgb(33, 47, 61);
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);

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
            this.lblWelcome.Text = "Welcome, Customer";

            // panelHome
            this.panelHome.Controls.Add(this.lblHomeMessage);
            this.panelHome.Location = new System.Drawing.Point(30, 80);
            this.panelHome.Name = "panelHome";
            this.panelHome.Size = new System.Drawing.Size(740, 200);

            // lblHomeMessage
            this.lblHomeMessage.AutoSize = true;
            this.lblHomeMessage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHomeMessage.ForeColor = System.Drawing.Color.DimGray;
            this.lblHomeMessage.Location = new System.Drawing.Point(0, 0);
            this.lblHomeMessage.Name = "lblHomeMessage";
            this.lblHomeMessage.Size = new System.Drawing.Size(400, 20);
            this.lblHomeMessage.Text = "Use the menu on the left to search medicines, track orders, or update your profile.";

            // panelContent
            this.panelContent.Location = new System.Drawing.Point(30, 80);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(740, 480);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.None;

            // CustomerDashboardForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSidebar);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "CustomerDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Dashboard - SmartMed Pharmacy";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CustomerDashboardForm_FormClosed);
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelHome.ResumeLayout(false);
            this.panelHome.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Label lblSidebarTitle;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnSearchMedicines;
        private System.Windows.Forms.Button btnMyOrders;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel panelHome;
        private System.Windows.Forms.Label lblHomeMessage;
        private System.Windows.Forms.Panel panelContent;
    }
}
