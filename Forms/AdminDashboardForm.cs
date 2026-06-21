using System.Windows.Forms;
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
            lblWelcome.Text = "Welcome, " + _currentAdmin.FullName + " (Admin)";
        }
    }
}
