using System;
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
            LoadCategoryFilter();
            LoadMedicines();
        }

        /// <summary>
        /// Loads all medicines (no filter) into the grid. Called on first
        /// load and whenever the user clicks "Clear" or after a save/delete.
        /// </summary>
        private void LoadMedicines()
        {
            try
            {
                var medicines = _medicineDal.GetAll();
                BindGrid(medicines);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load medicines.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Populates the category dropdown with distinct categories
        /// currently in the database, plus an "All Categories" option.
        /// </summary>
        private void LoadCategoryFilter()
        {
            try
            {
                var medicines = _medicineDal.GetAll();
                var categories = medicines.Select(m => m.Category).Distinct().OrderBy(c => c).ToList();

                cmbCategory.Items.Clear();
                cmbCategory.Items.Add("All Categories");
                foreach (var category in categories)
                    cmbCategory.Items.Add(category);

                cmbCategory.SelectedIndex = 0;
            }
            catch
            {
                // Non-critical - filter dropdown just stays empty if this fails
            }
        }

        private void BindGrid(System.Collections.Generic.List<Medicine> medicines)
        {
            dgvMedicines.DataSource = null;
            dgvMedicines.DataSource = medicines;

            // Tidy up auto-generated column headers
            if (dgvMedicines.Columns["MedicineId"] != null)
                dgvMedicines.Columns["MedicineId"].HeaderText = "ID";
            if (dgvMedicines.Columns["Name"] != null)
                dgvMedicines.Columns["Name"].HeaderText = "Name";
            if (dgvMedicines.Columns["Category"] != null)
                dgvMedicines.Columns["Category"].HeaderText = "Category";
            if (dgvMedicines.Columns["Dosage"] != null)
                dgvMedicines.Columns["Dosage"].HeaderText = "Dosage";
            if (dgvMedicines.Columns["Price"] != null)
                dgvMedicines.Columns["Price"].HeaderText = "Price (Rs.)";
            if (dgvMedicines.Columns["StockQuantity"] != null)
                dgvMedicines.Columns["StockQuantity"].HeaderText = "Stock";
            if (dgvMedicines.Columns["Supplier"] != null)
                dgvMedicines.Columns["Supplier"].HeaderText = "Supplier";
            if (dgvMedicines.Columns["CreatedAt"] != null)
                dgvMedicines.Columns["CreatedAt"].Visible = false;
            if (dgvMedicines.Columns["IsLowStock"] != null)
                dgvMedicines.Columns["IsLowStock"].Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtSearchName.Text.Trim();
                string category = (cmbCategory.SelectedItem?.ToString() == "All Categories")
                    ? null
                    : cmbCategory.SelectedItem?.ToString();

                decimal? minPrice = null;
                decimal? maxPrice = null;

                if (!string.IsNullOrWhiteSpace(txtMinPrice.Text))
                {
                    if (decimal.TryParse(txtMinPrice.Text, out decimal parsedMin))
                        minPrice = parsedMin;
                    else
                    {
                        MessageBox.Show("Minimum price must be a number.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (!string.IsNullOrWhiteSpace(txtMaxPrice.Text))
                {
                    if (decimal.TryParse(txtMaxPrice.Text, out decimal parsedMax))
                        maxPrice = parsedMax;
                    else
                    {
                        MessageBox.Show("Maximum price must be a number.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                var results = _medicineDal.Search(name, category, minPrice, maxPrice);
                BindGrid(results);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search failed.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearchName.Clear();
            txtMinPrice.Clear();
            txtMaxPrice.Clear();
            cmbCategory.SelectedIndex = 0;
            LoadMedicines();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MedicineDialogForm dialog = new MedicineDialogForm();
            if (dialog.ShowDialog() == DialogResult.OK && dialog.SaveSucceeded)
            {
                LoadCategoryFilter();
                LoadMedicines();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Medicine selected = GetSelectedMedicine();
            if (selected == null)
            {
                MessageBox.Show("Please select a medicine to edit.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MedicineDialogForm dialog = new MedicineDialogForm(selected);
            if (dialog.ShowDialog() == DialogResult.OK && dialog.SaveSucceeded)
            {
                LoadCategoryFilter();
                LoadMedicines();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Medicine selected = GetSelectedMedicine();
            if (selected == null)
            {
                MessageBox.Show("Please select a medicine to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                "Are you sure you want to delete \"" + selected.Name + "\"?\nThis cannot be undone.",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    bool success = _medicineDal.Delete(selected.MedicineId);
                    if (success)
                    {
                        LoadCategoryFilter();
                        LoadMedicines();
                    }
                    else
                    {
                        MessageBox.Show("Could not delete the medicine. It may be linked to existing orders.",
                            "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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
            if (dgvMedicines.CurrentRow == null)
                return null;

            return dgvMedicines.CurrentRow.DataBoundItem as Medicine;
        }
    }
}
