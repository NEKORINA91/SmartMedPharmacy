using System;
using System.Windows.Forms;
using SmartMedPharmacy.DAL;

namespace SmartMedPharmacy.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (chkLoginAsAdmin.Checked)
                {
                    AdminDAL adminDal = new AdminDAL();
                    var admin = adminDal.Login(username, password);

                    if (admin != null)
                    {
                        AdminDashboardForm dashboard = new AdminDashboardForm(admin);
                        dashboard.Show();
                        this.Hide();
                        return;
                    }
                }
                else
                {
                    CustomerDAL customerDal = new CustomerDAL();
                    var customer = customerDal.Login(username, password);

                    if (customer != null)
                    {
                        CustomerDashboardForm dashboard = new CustomerDashboardForm(customer);
                        dashboard.Show();
                        this.Hide();
                        return;
                    }
                }

                // Login Fail and invalid role 
                MessageBox.Show("Invalid username or password.", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not connect to the database.\n\n" + ex.Message,
                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            CustomerRegisterForm registerForm = new CustomerRegisterForm();
            registerForm.Show();
            this.Hide();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
        }

        private void pnlCard_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
