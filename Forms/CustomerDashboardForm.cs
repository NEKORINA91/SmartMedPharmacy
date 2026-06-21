using System;
using System.Windows.Forms;
using SmartMedPharmacy.Models;

namespace SmartMedPharmacy.Forms
{
    public partial class CustomerDashboardForm : Form
    {
        private readonly Customer _currentCustomer;

        public CustomerDashboardForm(Customer customer)
        {
            InitializeComponent();
            _currentCustomer = customer;
            lblWelcome.Text = "Welcome, " + _currentCustomer.FullName;
        }

        /// <summary>
        /// Swaps whatever is currently in the content panel for a new
        /// child form/control - same pattern as the Admin Dashboard.
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
        }

        private void btnSearchMedicines_Click(object sender, EventArgs e)
        {
            LoadIntoContentPanel(new SearchMedicineForm(_currentCustomer));
        }

        private void btnMyOrders_Click(object sender, EventArgs e)
        {
            LoadIntoContentPanel(new TrackOrdersForm(_currentCustomer));
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            panelHome.Visible = false;
            MessageBox.Show("Profile management form coming in a future step!",
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

        private void CustomerDashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
        }
    }
}
