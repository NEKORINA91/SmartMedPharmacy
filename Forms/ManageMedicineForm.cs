using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SmartMedPharmacy.DAL;
using SmartMedPharmacy.Models;

namespace SmartMedPharmacy.Forms
{
    public partial class ManageMedicineForm : Form
    {
        private readonly MedicineDAL _medicineDal = new MedicineDAL();

        public ManageMedicineForm()
        {
            InitializeComponent();
            dgvMedicines.CellFormatting += DgvMedicines_CellFormatting;
            LoadCategoryFilter();
            LoadMedicines();
        }

        private void LoadMedicines()
        {
            try { BindGrid(_medicineDal.GetAll()); }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load medicines.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCategoryFilter()
        {
            try
            {
                var cats = _medicineDal.GetAll()
                    .Select(m => m.Category).Distinct().OrderBy(c => c).ToList();
                cmbCategory.Items.Clear();
                cmbCategory.Items.Add("All Categories");
                foreach (var c in cats) cmbCategory.Items.Add(c);
                cmbCategory.SelectedIndex = 0;
            }
            catch { }
        }

        private void BindGrid(System.Collections.Generic.List<Medicine> medicines)
        {
            dgvMedicines.DataSource = null;
            dgvMedicines.DataSource = medicines;

            if (dgvMedicines.Columns["MedicineId"] != null)    dgvMedicines.Columns["MedicineId"].HeaderText = "ID";
            if (dgvMedicines.Columns["Name"] != null)          dgvMedicines.Columns["Name"].HeaderText = "Name";
            if (dgvMedicines.Columns["Category"] != null)      dgvMedicines.Columns["Category"].HeaderText = "Category";
            if (dgvMedicines.Columns["Dosage"] != null)        dgvMedicines.Columns["Dosage"].HeaderText = "Dosage";
            if (dgvMedicines.Columns["Price"] != null)         dgvMedicines.Columns["Price"].HeaderText = "Price (Rs.)";
            if (dgvMedicines.Columns["StockQuantity"] != null) dgvMedicines.Columns["StockQuantity"].HeaderText = "Stock";
            if (dgvMedicines.Columns["Supplier"] != null)      dgvMedicines.Columns["Supplier"].HeaderText = "Supplier";
            if (dgvMedicines.Columns["ExpiryDate"] != null)    dgvMedicines.Columns["ExpiryDate"].HeaderText = "Expiry Date";
            if (dgvMedicines.Columns["CreatedAt"] != null)     dgvMedicines.Columns["CreatedAt"].Visible = false;
            if (dgvMedicines.Columns["IsLowStock"] != null)    dgvMedicines.Columns["IsLowStock"].Visible = false;
            if (dgvMedicines.Columns["IsExpired"] != null)     dgvMedicines.Columns["IsExpired"].Visible = false;
            if (dgvMedicines.Columns["IsExpiringSoon"] != null) dgvMedicines.Columns["IsExpiringSoon"].Visible = false;

            // Format ExpiryDate column to show date only
            if (dgvMedicines.Columns["ExpiryDate"] != null)
                dgvMedicines.Columns["ExpiryDate"].DefaultCellStyle.Format = "dd MMM yyyy";
        }

        // ── Expiry colour coding ─────────────────────────────────────────────────
        private void DgvMedicines_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var med = dgvMedicines.Rows[e.RowIndex].DataBoundItem as Medicine;
            if (med == null) return;

            if (med.IsExpired)
            {
                // Red row — expired
                dgvMedicines.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(254, 226, 226);
                dgvMedicines.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(153, 27, 27);

                // Bold the expiry cell specifically
                if (dgvMedicines.Columns["ExpiryDate"] != null &&
                    e.ColumnIndex == dgvMedicines.Columns["ExpiryDate"].Index)
                {
                    e.CellStyle.Font = UITheme.FontBodyBold;
                    e.CellStyle.BackColor = Color.FromArgb(220, 38, 38);
                    e.CellStyle.ForeColor = Color.White;
                }
            }
            else if (med.IsExpiringSoon)
            {
                // Amber row — expiring within 30 days
                dgvMedicines.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(254, 243, 199);
                dgvMedicines.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(120, 53, 15);

                if (dgvMedicines.Columns["ExpiryDate"] != null &&
                    e.ColumnIndex == dgvMedicines.Columns["ExpiryDate"].Index)
                {
                    e.CellStyle.Font = UITheme.FontBodyBold;
                    e.CellStyle.BackColor = Color.FromArgb(245, 158, 11);
                    e.CellStyle.ForeColor = Color.White;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtSearchName.Text.Trim();
                string category = cmbCategory.SelectedItem?.ToString() == "All Categories"
                    ? null : cmbCategory.SelectedItem?.ToString();

                decimal? minPrice = null, maxPrice = null;
                if (!string.IsNullOrWhiteSpace(txtMinPrice.Text))
                {
                    if (!decimal.TryParse(txtMinPrice.Text, out decimal mn))
                    { MessageBox.Show("Minimum price must be a number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    minPrice = mn;
                }
                if (!string.IsNullOrWhiteSpace(txtMaxPrice.Text))
                {
                    if (!decimal.TryParse(txtMaxPrice.Text, out decimal mx))
                    { MessageBox.Show("Maximum price must be a number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    maxPrice = mx;
                }
                BindGrid(_medicineDal.Search(name, category, minPrice, maxPrice));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search failed.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearchName.Clear(); txtMinPrice.Clear(); txtMaxPrice.Clear();
            cmbCategory.SelectedIndex = 0;
            LoadMedicines();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var dialog = new MedicineDialogForm();
            if (dialog.ShowDialog() == DialogResult.OK && dialog.SaveSucceeded)
            { LoadCategoryFilter(); LoadMedicines(); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Medicine selected = GetSelectedMedicine();
            if (selected == null)
            { MessageBox.Show("Please select a medicine to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            var dialog = new MedicineDialogForm(selected);
            if (dialog.ShowDialog() == DialogResult.OK && dialog.SaveSucceeded)
            { LoadCategoryFilter(); LoadMedicines(); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Medicine selected = GetSelectedMedicine();
            if (selected == null)
            { MessageBox.Show("Please select a medicine to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            var confirm = MessageBox.Show(
                "Are you sure you want to delete \"" + selected.Name + "\"?\nThis cannot be undone.",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    if (_medicineDal.Delete(selected.MedicineId))
                    { LoadCategoryFilter(); LoadMedicines(); }
                    else
                        MessageBox.Show("Could not delete the medicine. It may be linked to existing orders.",
                            "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error while deleting.\n\n" + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Medicine GetSelectedMedicine()
        {
            if (dgvMedicines.CurrentRow == null) return null;
            return dgvMedicines.CurrentRow.DataBoundItem as Medicine;
        }
    }
}
