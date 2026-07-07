using System;
using System.Windows.Forms;
using SmartMedPharmacy.DAL;
using SmartMedPharmacy.Models;

namespace SmartMedPharmacy.Forms
{
    public partial class ManagePromotionsForm : Form
    {
        private readonly PromotionDAL _promoDal = new PromotionDAL();

        public ManagePromotionsForm()
        {
            InitializeComponent();
            dgvPromos.CellFormatting += DgvPromos_CellFormatting;
            LoadPromos();
        }

        private void LoadPromos()
        {
            try
            {
                var promos = _promoDal.GetAll();
                dgvPromos.DataSource = null;
                dgvPromos.DataSource = promos;

                if (dgvPromos.Columns["PromoId"] != null)        dgvPromos.Columns["PromoId"].Visible = false;
                if (dgvPromos.Columns["CreatedAt"] != null)      dgvPromos.Columns["CreatedAt"].Visible = false;
                if (dgvPromos.Columns["IsExpired"] != null)      dgvPromos.Columns["IsExpired"].Visible = false;
                if (dgvPromos.Columns["IsValid"] != null)        dgvPromos.Columns["IsValid"].Visible = false;
                if (dgvPromos.Columns["Summary"] != null)        dgvPromos.Columns["Summary"].Visible = false;
                if (dgvPromos.Columns["Code"] != null)           dgvPromos.Columns["Code"].HeaderText = "Code";
                if (dgvPromos.Columns["Description"] != null)    dgvPromos.Columns["Description"].HeaderText = "Description";
                if (dgvPromos.Columns["MinOrderAmount"] != null) dgvPromos.Columns["MinOrderAmount"].HeaderText = "Min Order (Rs.)";
                if (dgvPromos.Columns["DiscountAmount"] != null) dgvPromos.Columns["DiscountAmount"].HeaderText = "Discount (Rs.)";
                if (dgvPromos.Columns["ExpiryDate"] != null)   { dgvPromos.Columns["ExpiryDate"].HeaderText = "Expiry Date"; dgvPromos.Columns["ExpiryDate"].DefaultCellStyle.Format = "dd MMM yyyy"; }
                if (dgvPromos.Columns["IsActive"] != null)       dgvPromos.Columns["IsActive"].HeaderText = "Active";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load promotions.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvPromos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var promo = dgvPromos.Rows[e.RowIndex].DataBoundItem as Promotion;
            if (promo == null) return;

            if (promo.IsExpired)
            {
                dgvPromos.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
                dgvPromos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(160, 160, 160);
            }
            else if (promo.IsActive)
            {
                dgvPromos.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(209, 250, 229);
                dgvPromos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(6, 95, 70);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var dialog = new PromoDialogForm();
            if (dialog.ShowDialog() == DialogResult.OK && dialog.SaveSucceeded)
                LoadPromos();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedPromo();
            if (selected == null)
            { MessageBox.Show("Please select a promotion to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            var dialog = new PromoDialogForm(selected);
            if (dialog.ShowDialog() == DialogResult.OK && dialog.SaveSucceeded)
                LoadPromos();
        }

        private void btnToggleActive_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedPromo();
            if (selected == null)
            { MessageBox.Show("Please select a promotion.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            selected.IsActive = !selected.IsActive;
            try
            {
                if (_promoDal.Update(selected)) LoadPromos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not update promotion.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedPromo();
            if (selected == null)
            { MessageBox.Show("Please select a promotion to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            var confirm = MessageBox.Show("Delete promo code \"" + selected.Code + "\"? This cannot be undone.",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                if (_promoDal.Delete(selected.PromoId)) LoadPromos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not delete promotion.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Promotion GetSelectedPromo()
        {
            if (dgvPromos.CurrentRow == null) return null;
            return dgvPromos.CurrentRow.DataBoundItem as Promotion;
        }
    }
}
