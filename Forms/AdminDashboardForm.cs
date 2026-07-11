using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SmartMedPharmacy.DAL;
using SmartMedPharmacy.Models;

namespace SmartMedPharmacy.Forms
{
    public partial class AdminDashboardForm : Form
    {
        private readonly Admin _currentAdmin;

        public AdminDashboardForm(Admin admin)
        {
            InitializeComponent();
            _currentAdmin = admin;
            lblWelcome.Text = "Welcome, " + _currentAdmin.FullName;

            // Wire rounded-card paint events
            cardSales.Paint    += RoundedCard_Paint;
            cardStock.Paint    += RoundedCard_Paint;
            cardOrders.Paint   += RoundedCard_Paint;
            cardLowStock.Paint += RoundedCard_Paint;

            // Wire status badge colouring
            dgvRecentOrders.CellFormatting += DgvOrders_CellFormatting;

            LoadStats();
        }

        private void LoadStats()
        {
            try
            {
                DashboardDAL dashboardDal = new DashboardDAL();
                DashboardStats stats = dashboardDal.GetStats();

                lblTotalSalesValue.Text   = "Rs. " + stats.TotalSales.ToString("N2");
                lblStockValue.Text        = stats.TotalMedicinesInStock.ToString();
                lblActiveOrdersValue.Text = stats.ActiveOrders.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load dashboard stats.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadIntoContentPanel(Form childForm)
        {
            panelHome.Visible = false;
            panelContent.Controls.Clear();

            childForm.TopLevel        = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock            = DockStyle.Fill;

            panelContent.Controls.Add(childForm);
            childForm.Show();
        }

        // ── Nav handlers ────────────────────────────────────────────────────────

        private void btnHome_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();
            if (!panelContent.Controls.Contains(panelHome))
                panelContent.Controls.Add(panelHome);
            panelHome.Dock = DockStyle.Fill;
            panelHome.Visible = true;
            LoadStats(); 
        }

        private void btnManageMedicine_Click(object sender, EventArgs e)
        {
            LoadIntoContentPanel(new ManageMedicineForm());
        }

        private void btnManageCustomers_Click(object sender, EventArgs e)
        {
            LoadIntoContentPanel(new ManageCustomerForm());
        }

        private void btnManageOrders_Click(object sender, EventArgs e)
        {
            LoadIntoContentPanel(new ManageOrdersForm());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            LoadIntoContentPanel(new ReportsForm());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                new LoginForm().Show();
                this.Close();
            }
        }

        private void AdminDashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
                Application.Exit();
        }

        // ── Paint helpers ────────────────────────────────────────────────────────

        private void RoundedCard_Paint(object sender, PaintEventArgs e)
        {
            var panel = (Panel)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            var rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);

            using (var brush = new SolidBrush(UITheme.Surface))
            using (var path = GetRoundedRect(rect, UITheme.CardRadius))
                e.Graphics.FillPath(brush, path);

            using (var pen = new Pen(UITheme.StatCardBorder, 1f))
            using (var path = GetRoundedRect(rect, UITheme.CardRadius))
                e.Graphics.DrawPath(pen, path);
        }

        private GraphicsPath GetRoundedRect(Rectangle bounds, int radius)
        {
            int d    = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(bounds.X,              bounds.Y,               d, d, 180, 90);
            path.AddArc(bounds.Right - d,      bounds.Y,               d, d, 270, 90);
            path.AddArc(bounds.Right - d,      bounds.Bottom - d,      d, d, 0,   90);
            path.AddArc(bounds.X,              bounds.Bottom - d,      d, d, 90,  90);
            path.CloseFigure();
            return path;
        }

        private void DgvOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid      = (DataGridView)sender;
            int statusCol = grid.Columns.Count - 1;
            if (e.ColumnIndex != statusCol || e.Value == null) return;

            switch (e.Value.ToString().ToLower())
            {
                case "pending":
                    e.CellStyle.BackColor = UITheme.StatusPending;
                    e.CellStyle.ForeColor = UITheme.StatusPendingFg;
                    break;
                case "completed":
                case "delivered":
                    e.CellStyle.BackColor = UITheme.StatusDone;
                    e.CellStyle.ForeColor = UITheme.StatusDoneFg;
                    break;
                case "shipped":
                    e.CellStyle.BackColor = UITheme.StatusShipped;
                    e.CellStyle.ForeColor = UITheme.StatusShippedFg;
                    break;
            }
            e.CellStyle.Font      = UITheme.FontSmall;
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

      

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AdminDashboardForm
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "AdminDashboardForm";
            this.Load += new System.EventHandler(this.AdminDashboardForm_Load_1);
            this.ResumeLayout(false);

        }

        private void AdminDashboardForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
