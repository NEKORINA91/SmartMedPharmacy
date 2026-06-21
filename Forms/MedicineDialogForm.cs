using System;
using System.Windows.Forms;
using SmartMedPharmacy.DAL;
using SmartMedPharmacy.Models;

namespace SmartMedPharmacy.Forms
{
    public partial class MedicineDialogForm : Form
    {
        private readonly MedicineDAL _medicineDal = new MedicineDAL();
        private readonly Medicine _editingMedicine; // null = Add mode, populated = Edit mode

        /// <summary>
        /// True if the caller should refresh their list after this dialog closes
        /// (i.e. a save actually happened).
        /// </summary>
        public bool SaveSucceeded { get; private set; } = false;

        // Constructor for ADD mode
        public MedicineDialogForm()
        {
            InitializeComponent();
            _editingMedicine = null;
            this.Text = "Add Medicine";
        }

        // Constructor for EDIT mode
        public MedicineDialogForm(Medicine medicineToEdit)
        {
            InitializeComponent();
            _editingMedicine = medicineToEdit;
            this.Text = "Edit Medicine";
            PopulateFields();
        }

        private void PopulateFields()
        {
            txtName.Text = _editingMedicine.Name;
            txtCategory.Text = _editingMedicine.Category;
            txtDosage.Text = _editingMedicine.Dosage;
            txtPrice.Text = _editingMedicine.Price.ToString("0.00");
            txtStock.Text = _editingMedicine.StockQuantity.ToString();
            txtSupplier.Text = _editingMedicine.Supplier;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out decimal price, out int stock))
                return;

            try
            {
                if (_editingMedicine == null)
                {
                    // ADD mode
                    Medicine newMedicine = new Medicine(
                        txtName.Text.Trim(),
                        txtCategory.Text.Trim(),
                        txtDosage.Text.Trim(),
                        price,
                        stock,
                        txtSupplier.Text.Trim()
                    );

                    bool success = _medicineDal.Add(newMedicine);
                    if (success)
                    {
                        SaveSucceeded = true;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Could not add the medicine. Please try again.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // EDIT mode
                    _editingMedicine.Name = txtName.Text.Trim();
                    _editingMedicine.Category = txtCategory.Text.Trim();
                    _editingMedicine.Dosage = txtDosage.Text.Trim();
                    _editingMedicine.Price = price;
                    _editingMedicine.StockQuantity = stock;
                    _editingMedicine.Supplier = txtSupplier.Text.Trim();

                    bool success = _medicineDal.Update(_editingMedicine);
                    if (success)
                    {
                        SaveSucceeded = true;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Could not update the medicine. Please try again.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs(out decimal price, out int stock)
        {
            price = 0;
            stock = 0;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Medicine name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                MessageBox.Show("Category is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategory.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, out price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid price (a positive number).", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return false;
            }

            if (!int.TryParse(txtStock.Text, out stock) || stock < 0)
            {
                MessageBox.Show("Please enter a valid stock quantity (zero or more, whole number).", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStock.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
