using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            lblWelcome.Text = "Welcome back, " + _currentCustomer.FullName;

            // Wire rounded-card paint events
            cardBrowse.Paint  += RoundedCard_Paint;
            cardTrack.Paint   += RoundedCard_Paint;
            cardHistory.Paint += RoundedCard_Paint;

            // Wire status badge colouring
            dgvOrders.CellFormatting += DgvOrders_CellFormatting;
        }

        private void LoadIntoContentPanel(Form childForm)
        {
            panelHome.Visible = false;
            panelContent.Controls.Clear();

            childForm.TopLevel        = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock            = DockStyle.Fill;

            panelContent.Controls.Add(childForm);
            childForm.Show();
        }

        // ── Nav handlers ────────────────────────────────────────────────────────

        private void btnHome_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();
            if (!panelContent.Controls.Contains(panelHome))
                panelContent.Controls.Add(panelHome);
            panelHome.Dock = DockStyle.Fill;
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
            var profileForm = new CustomerProfileForm(_currentCustomer);
            if (profileForm.ShowDialog() == DialogResult.OK)
                lblWelcome.Text = "Welcome back, " + _currentCustomer.FullName;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                new LoginForm().Show();
                this.Close();
            }
        }

        private void CustomerDashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
                Application.Exit();
        }

        // ── Paint helpers ────────────────────────────────────────────────────────

        private void RoundedCard_Paint(object sender, PaintEventArgs e)
        {
            var panel = (Panel)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            var rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);

            using (var brush = new SolidBrush(UITheme.Surface))
            using (var path = GetRoundedRect(rect, UITheme.CardRadius))
                e.Graphics.FillPath(brush, path);

            using (var pen = new Pen(UITheme.StatCardBorder, 1f))
            using (var path = GetRoundedRect(rect, UITheme.CardRadius))
                e.Graphics.DrawPath(pen, path);
        }

        private GraphicsPath GetRoundedRect(Rectangle bounds, int radius)
        {
            int d    = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(bounds.X,         bounds.Y,          d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y,          d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0,   90);
            path.AddArc(bounds.X,         bounds.Bottom - d, d, d, 90,  90);
            path.CloseFigure();
            return path;
        }

        private void DgvOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid      = (DataGridView)sender;
            int statusCol = grid.Columns.Count - 1;
            if (e.ColumnIndex != statusCol || e.Value == null) return;

            switch (e.Value.ToString().ToLower())
            {
                case "pending":
                    e.CellStyle.BackColor = UITheme.StatusPending;
                    e.CellStyle.ForeColor = UITheme.StatusPendingFg;
                    break;
                case "completed":
                case "delivered":
                    e.CellStyle.BackColor = UITheme.StatusDone;
                    e.CellStyle.ForeColor = UITheme.StatusDoneFg;
                    break;
                case "shipped":
                    e.CellStyle.BackColor = UITheme.StatusShipped;
                    e.CellStyle.ForeColor = UITheme.StatusShippedFg;
                    break;
            }
            e.CellStyle.Font      = UITheme.FontSmall;
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

      

        private void CustomerDashboardForm_Load(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CustomerDashboardForm
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "CustomerDashboardForm";
            this.Load += new System.EventHandler(this.CustomerDashboardForm_Load_1);
            this.ResumeLayout(false);

        }

        private void CustomerDashboardForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
