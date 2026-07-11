using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SmartMedPharmacy.DAL;
using SmartMedPharmacy.Models;

namespace SmartMedPharmacy.Forms
{
    public partial class CustomerDashboardForm : Form
    {
        private readonly Customer _currentCustomer;
        private readonly PromotionDAL _promoDal = new PromotionDAL();

        public CustomerDashboardForm(Customer customer)
        {
            InitializeComponent();
            _currentCustomer = customer;
            lblWelcome.Text = "Welcome back, " + _currentCustomer.FullName;

            cardBrowse.Paint  += RoundedCard_Paint;
            cardTrack.Paint   += RoundedCard_Paint;
            cardHistory.Paint += RoundedCard_Paint;
            dgvOrders.CellFormatting += DgvOrders_CellFormatting;

            LoadPromoCards();
        }

        // ── Promo cards ──────────────────────────────────────────────────────────

        private void LoadPromoCards()
        {
            pnlPromos.Controls.Clear();
            try
            {
                var promos = _promoDal.GetActivePromos();
                if (promos.Count == 0)
                {
                    var lbl = new Label
                    {
                        Text      = "No active promotions at the moment.",
                        Font      = UITheme.FontSmall,
                        ForeColor = UITheme.TextMuted,
                        AutoSize  = true,
                        Margin    = new Padding(0, 8, 0, 0)
                    };
                    pnlPromos.Controls.Add(lbl);
                    return;
                }

                foreach (var promo in promos)
                {
                    var card = new Panel
                    {
                        BackColor = Color.FromArgb(240, 253, 252),
                        Size      = new Size(210, 66),
                        Margin    = new Padding(0, 0, 10, 0),
                        Cursor    = Cursors.Default
                    };

                    // Teal left accent bar
                    var bar = new Panel
                    {
                        BackColor = UITheme.Accent,
                        Location  = new Point(0, 0),
                        Size      = new Size(5, 66)
                    };
                    card.Controls.Add(bar);

                    // Code badge
                    var lblCode = new Label
                    {
                        Text      = promo.Code,
                        Font      = UITheme.FontBodyBold,
                        ForeColor = UITheme.Accent,
                        AutoSize  = true,
                        Location  = new Point(12, 8),
                        BackColor = Color.Transparent
                    };
                    card.Controls.Add(lblCode);

                    // Discount amount
                    var lblDiscount = new Label
                    {
                        Text      = "Rs. " + promo.DiscountAmount.ToString("N0") + " off",
                        Font      = new Font("Segoe UI", 11f, FontStyle.Bold),
                        ForeColor = UITheme.TextPrimary,
                        AutoSize  = true,
                        Location  = new Point(12, 26),
                        BackColor = Color.Transparent
                    };
                    card.Controls.Add(lblDiscount);

                    // Min order + expiry
                    var lblDetail = new Label
                    {
                        Text      = "Min Rs. " + promo.MinOrderAmount.ToString("N0") + "  |  Expires " + promo.ExpiryDate.ToString("dd MMM yyyy"),
                        Font      = UITheme.FontSmall,
                        ForeColor = UITheme.TextSecondary,
                        AutoSize  = true,
                        Location  = new Point(12, 48),
                        BackColor = Color.Transparent
                    };
                    card.Controls.Add(lblDetail);

                    pnlPromos.Controls.Add(card);
                }
            }
            catch { /* non-critical — promos just won't show if DB fails */ }
        }

        // ── Navigation ───────────────────────────────────────────────────────────

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

        private void btnHome_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();
            if (!panelContent.Controls.Contains(panelHome))
                panelContent.Controls.Add(panelHome);
            panelHome.Dock    = DockStyle.Fill;
            panelHome.Visible = true;
            LoadPromoCards(); // refresh promos on return to home
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
            if (Application.OpenForms.Count == 0) Application.Exit();
        }

        private void CustomerDashboardForm_Load(object sender, EventArgs e) { }

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
            int d = radius * 2;
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
            var grid = (DataGridView)sender;
            int statusCol = grid.Columns.Count - 1;
            if (e.ColumnIndex != statusCol || e.Value == null) return;
            switch (e.Value.ToString().ToLower())
            {
                case "pending":   e.CellStyle.BackColor = UITheme.StatusPending;  e.CellStyle.ForeColor = UITheme.StatusPendingFg; break;
                case "completed":
                case "delivered": e.CellStyle.BackColor = UITheme.StatusDone;     e.CellStyle.ForeColor = UITheme.StatusDoneFg;    break;
                case "shipped":   e.CellStyle.BackColor = UITheme.StatusShipped;  e.CellStyle.ForeColor = UITheme.StatusShippedFg; break;
            }
            e.CellStyle.Font      = UITheme.FontSmall;
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
