using System;
using System.Windows.Forms;
using SmartMedPharmacy.DAL;
using SmartMedPharmacy.Models;

namespace SmartMedPharmacy.Forms
{
    public partial class CustomerDialogForm : Form
    {
        private readonly CustomerDAL _customerDal = new CustomerDAL();
        private readonly Customer _customer;

        public bool SaveSucceeded { get; private set; } = false;

        public CustomerDialogForm(Customer customer)
        {
            InitializeComponent();
            _customer = customer;
            PopulateFields();
        }

        private void PopulateFields()
        {
            // Username and join date are shown but not editable -
            // username is the account identity, shouldn't change after registration.
            txtUsername.Text = _customer.Username;
            txtUsername.ReadOnly = true;
            lblJoinedValue.Text = _customer.CreatedAt.ToString("dd MMM yyyy");

            txtFullName.Text = _customer.FullName;
            txtEmail.Text = _customer.Email;
            txtPhone.Text = _customer.Phone;
            txtAddress.Text = _customer.Address;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            try
            {
                _customer.FullName = txtFullName.Text.Trim();
                _customer.Email = txtEmail.Text.Trim();
                _customer.Phone = txtPhone.Text.Trim();
                _customer.Address = txtAddress.Text.Trim();

                bool success = _customerDal.UpdateProfile(_customer);
                if (success)
                {
                    SaveSucceeded = true;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Could not update the customer. Please try again.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Full name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                foreach (char c in txtPhone.Text)
                {
                    if (!char.IsDigit(c) && c != '+' && c != '-' && c != ' ')
                    {
                        MessageBox.Show("Phone number contains invalid characters.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPhone.Focus();
                        return false;
                    }
                }
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
