using System;
using System.Windows.Forms;
using SmartMedPharmacy.DAL;
using SmartMedPharmacy.Models;

namespace SmartMedPharmacy.Forms
{
    public partial class CustomerProfileForm : Form
    {
        private readonly Customer _customer;

        public CustomerProfileForm(Customer customer)
        {
            _customer = customer ?? throw new ArgumentNullException(nameof(customer));
            InitializeComponent();
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            txtFullName.Text = _customer.FullName;
            txtEmail.Text    = _customer.Email;
            txtPhone.Text    = _customer.Phone;
            txtAddress.Text  = _customer.Address;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            _customer.FullName = txtFullName.Text.Trim();
            _customer.Email    = txtEmail.Text.Trim();
            _customer.Phone    = txtPhone.Text.Trim();
            _customer.Address  = txtAddress.Text.Trim();

            try
            {
                CustomerDAL dal = new CustomerDAL();
                bool success = dal.UpdateProfile(_customer);

                if (success)
                {
                    MessageBox.Show("Profile updated successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("No changes were saved. Please try again.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update profile:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                ShowValidationError("Full name is required.", txtFullName);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                ShowValidationError("Email address is required.", txtEmail);
                return false;
            }

            if (!IsValidEmail(txtEmail.Text.Trim()))
            {
                ShowValidationError("Please enter a valid email address.", txtEmail);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                ShowValidationError("Phone number is required.", txtPhone);
                return false;
            }

            return true;
        }

        private void ShowValidationError(string message, Control control)
        {
            MessageBox.Show(message, "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
