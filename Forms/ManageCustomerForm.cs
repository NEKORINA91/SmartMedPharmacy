using System;
using System.Windows.Forms;
using SmartMedPharmacy.DAL;
using SmartMedPharmacy.Models;

namespace SmartMedPharmacy.Forms
{
    public partial class ManageCustomerForm : Form
    {
        private readonly CustomerDAL _customerDal = new CustomerDAL();

        public ManageCustomerForm()
        {
            InitializeComponent();
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            try
            {
                var customers = _customerDal.GetAll();
                BindGrid(customers);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load customers.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindGrid(System.Collections.Generic.List<Customer> customers)
        {
            dgvCustomers.DataSource = null;
            dgvCustomers.DataSource = customers;

            if (dgvCustomers.Columns["Id"] != null)
                dgvCustomers.Columns["Id"].HeaderText = "ID";
            if (dgvCustomers.Columns["Username"] != null)
                dgvCustomers.Columns["Username"].HeaderText = "Username";
            if (dgvCustomers.Columns["FullName"] != null)
                dgvCustomers.Columns["FullName"].HeaderText = "Full Name";
            if (dgvCustomers.Columns["Email"] != null)
                dgvCustomers.Columns["Email"].HeaderText = "Email";
            if (dgvCustomers.Columns["Phone"] != null)
                dgvCustomers.Columns["Phone"].HeaderText = "Phone";
            if (dgvCustomers.Columns["Address"] != null)
                dgvCustomers.Columns["Address"].HeaderText = "Address";
            if (dgvCustomers.Columns["CreatedAt"] != null)
                dgvCustomers.Columns["CreatedAt"].HeaderText = "Member Since";
            if (dgvCustomers.Columns["PasswordHash"] != null)
                dgvCustomers.Columns["PasswordHash"].Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Customer selected = GetSelectedCustomer();
            if (selected == null)
            {
                MessageBox.Show("Please select a customer to edit.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CustomerDialogForm dialog = new CustomerDialogForm(selected);
            if (dialog.ShowDialog() == DialogResult.OK && dialog.SaveSucceeded)
            {
                LoadCustomers();
            }
        }

        private Customer GetSelectedCustomer()
        {
            if (dgvCustomers.CurrentRow == null)
                return null;

            return dgvCustomers.CurrentRow.DataBoundItem as Customer;
        }

        private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Quick shortcut - double-clicking a row opens edit directly
            if (e.RowIndex >= 0)
            {
                btnEdit_Click(sender, e);
            }
        }
    }
}
