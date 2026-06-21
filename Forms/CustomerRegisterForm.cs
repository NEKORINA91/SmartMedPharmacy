using System;
using System.Windows.Forms;
using SmartMedPharmacy.DAL;
using SmartMedPharmacy.Models;

namespace SmartMedPharmacy.Forms
{
    public partial class CustomerRegisterForm : Form
    {
        public CustomerRegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            try
            {
                CustomerDAL customerDal = new CustomerDAL();

                if (customerDal.UsernameExists(txtUsername.Text.Trim()))
                {
                    MessageBox.Show("That username is already taken. Please choose another.",
                        "Username Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    return;
                }

                string passwordHash = PasswordHelper.Hash(txtPassword.Text);

                Customer newCustomer = new Customer(
                    txtUsername.Text.Trim(),
                    passwordHash,
                    txtFullName.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtPhone.Text.Trim(),
                    txtAddress.Text.Trim()
                );

                bool success = customerDal.Register(newCustomer);

                if (success)
                {
                    MessageBox.Show("Account created successfully! You can now log in.",
                        "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Registration failed. Please try again.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not connect to the database.\n\n" + ex.Message,
                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Validates all form inputs before attempting registration.
        /// Returns false and shows a message on the first problem found.
        /// </summary>
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Username is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

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

            if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
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

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
    }
}
