using System;
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
            LoadStats();
        }

        /// <summary>
        /// Pulls the headline numbers and populates the three stat tiles
        /// on the dashboard home view.
        /// </summary>
        private void LoadStats()
        {
            try
            {
                DashboardDAL dashboardDal = new DashboardDAL();
                DashboardStats stats = dashboardDal.GetStats();

                lblTotalSalesValue.Text = "Rs. " + stats.TotalSales.ToString("N2");
                lblStockValue.Text = stats.TotalMedicinesInStock.ToString();
                lblActiveOrdersValue.Text = stats.ActiveOrders.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load dashboard stats.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Swaps whatever is currently in the content panel for a new
        /// child form/control. This is what gives the sidebar-navigation
        /// feel without opening separate floating windows.
        /// </summary>
        private void LoadIntoContentPanel(Form childForm)
        {
            panelHome.Visible = false;
            panelContent.Controls.Clear();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelContent.Controls.Add(childForm);
            childForm.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();
            panelHome.Visible = true;
            LoadStats();
        }

        private void btnManageMedicine_Click(object sender, EventArgs e)
        {
            panelHome.Visible = false;
            MessageBox.Show("Manage Medicine form coming in the next step!",
                "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnManageCustomers_Click(object sender, EventArgs e)
        {
            panelHome.Visible = false;
            MessageBox.Show("Manage Customers form coming in a future step!",
                "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnManageOrders_Click(object sender, EventArgs e)
        {
            panelHome.Visible = false;
            MessageBox.Show("Manage Orders form coming in a future step!",
                "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            panelHome.Visible = false;
            MessageBox.Show("Reports form coming in a future step!",
                "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }

        private void AdminDashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
        }
    }
}
