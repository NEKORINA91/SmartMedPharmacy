using System.Windows.Forms;

namespace SmartMedPharmacy.Forms
{
    // TEMPORARY STUB - will be replaced with the real registration form
    // in the next step. This exists only so CustomerLoginForm compiles today.
    public partial class CustomerRegisterForm : Form
    {
        public CustomerRegisterForm()
        {
            this.Text = "Customer Registration (Coming Soon)";
            this.Width = 400;
            this.Height = 200;
            Label placeholder = new Label
            {
                Text = "Registration form coming in the next step!",
                AutoSize = true,
                Location = new System.Drawing.Point(40, 70)
            };
            this.Controls.Add(placeholder);
        }
    }
}
