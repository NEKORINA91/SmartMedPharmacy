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
    }
}
