using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SmartMedPharmacy.DAL;
using SmartMedPharmacy.Models;

namespace SmartMedPharmacy.Forms
{
    public partial class SearchMedicineForm : Form
    {
        private readonly MedicineDAL _medicineDal = new MedicineDAL();
        private readonly OrderDAL _orderDal = new OrderDAL();
        private readonly Customer _currentCustomer;

        // The cart is just an in-memory list until checkout actually saves it
        private readonly List<CartLine> _cart = new List<CartLine>();

        public SearchMedicineForm(Customer customer)
        {
            InitializeComponent();
            _currentCustomer = customer;
            LoadCategoryFilter();
            LoadMedicines();
            RefreshCartGrid();
        }

        // ===================== MEDICINE SEARCH / LIST =====================

        private void LoadMedicines()
        {
            try
            {
                var medicines = _medicineDal.GetAll();
                BindMedicineGrid(medicines);
            }
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
                // Non-critical
            }
        }

        private void BindMedicineGrid(List<Medicine> medicines)
        {
            dgvMedicines.DataSource = null;
            dgvMedicines.DataSource = medicines;

            if (dgvMedicines.Columns["MedicineId"] != null)
                dgvMedicines.Columns["MedicineId"].Visible = false;
            if (dgvMedicines.Columns["Name"] != null)
                dgvMedicines.Columns["Name"].HeaderText = "Name";
            if (dgvMedicines.Columns["Category"] != null)
                dgvMedicines.Columns["Category"].HeaderText = "Category";
            if (dgvMedicines.Columns["Dosage"] != null)
                dgvMedicines.Columns["Dosage"].HeaderText = "Dosage";
            if (dgvMedicines.Columns["Price"] != null)
                dgvMedicines.Columns["Price"].HeaderText = "Price (Rs.)";
            if (dgvMedicines.Columns["StockQuantity"] != null)
                dgvMedicines.Columns["StockQuantity"].HeaderText = "In Stock";
            if (dgvMedicines.Columns["Supplier"] != null)
                dgvMedicines.Columns["Supplier"].Visible = false;
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
                BindMedicineGrid(results);
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

        // ===================== CART =====================

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            Medicine selected = GetSelectedMedicine();
            if (selected == null)
            {
                MessageBox.Show("Please select a medicine first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int quantity = (int)numQuantity.Value;

            if (quantity <= 0)
            {
                MessageBox.Show("Quantity must be at least 1.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check how much is already in the cart for this medicine, so we
            // don't let the customer add more than what's actually in stock
            var existingLine = _cart.FirstOrDefault(c => c.MedicineId == selected.MedicineId);
            int alreadyInCart = existingLine?.Quantity ?? 0;

            if (alreadyInCart + quantity > selected.StockQuantity)
            {
                MessageBox.Show(
                    "Only " + selected.StockQuantity + " unit(s) of \"" + selected.Name + "\" are in stock" +
                    (alreadyInCart > 0 ? " (" + alreadyInCart + " already in your cart)." : "."),
                    "Not Enough Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (existingLine != null)
            {
                existingLine.Quantity += quantity;
            }
            else
            {
                _cart.Add(new CartLine
                {
                    MedicineId = selected.MedicineId,
                    MedicineName = selected.Name,
                    UnitPrice = selected.Price,
                    Quantity = quantity
                });
            }

            numQuantity.Value = 1;
            RefreshCartGrid();
        }

        private void RefreshCartGrid()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = _cart.Select(c => new
            {
                c.MedicineId,
                Medicine = c.MedicineName,
                c.Quantity,
                UnitPrice = c.UnitPrice.ToString("N2"),
                LineTotal = (c.UnitPrice * c.Quantity).ToString("N2")
            }).ToList();

            if (dgvCart.Columns["MedicineId"] != null)
                dgvCart.Columns["MedicineId"].Visible = false;

            decimal grandTotal = _cart.Sum(c => c.UnitPrice * c.Quantity);
            lblCartTotalValue.Text = "Rs. " + grandTotal.ToString("N2");

            btnPlaceOrder.Enabled = _cart.Count > 0;
        }

        private void btnIncreaseQty_Click(object sender, EventArgs e)
        {
            AdjustSelectedCartLine(1);
        }

        private void btnDecreaseQty_Click(object sender, EventArgs e)
        {
            AdjustSelectedCartLine(-1);
        }

        private void AdjustSelectedCartLine(int delta)
        {
            if (dgvCart.CurrentRow == null)
                return;

            int rowIndex = dgvCart.CurrentRow.Index;
            if (rowIndex < 0 || rowIndex >= _cart.Count)
                return;

            var line = _cart[rowIndex];
            int newQuantity = line.Quantity + delta;

            if (newQuantity <= 0)
            {
                _cart.RemoveAt(rowIndex);
            }
            else
            {
                // Re-check stock before increasing
                if (delta > 0)
                {
                    var medicine = _medicineDal.GetAll().FirstOrDefault(m => m.MedicineId == line.MedicineId);
                    if (medicine != null && newQuantity > medicine.StockQuantity)
                    {
                        MessageBox.Show("Only " + medicine.StockQuantity + " unit(s) in stock.",
                            "Not Enough Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                line.Quantity = newQuantity;
            }

            RefreshCartGrid();
        }

        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow == null)
            {
                MessageBox.Show("Please select a cart item to remove.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int rowIndex = dgvCart.CurrentRow.Index;
            if (rowIndex >= 0 && rowIndex < _cart.Count)
            {
                _cart.RemoveAt(rowIndex);
                RefreshCartGrid();
            }
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (_cart.Count == 0)
            {
                MessageBox.Show("Your cart is empty.", "Nothing to Order",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                "Place this order for a total of Rs. " + _cart.Sum(c => c.UnitPrice * c.Quantity).ToString("N2") + "?",
                "Confirm Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                Order order = new Order(_currentCustomer.Id)
                {
                    TotalAmount = _cart.Sum(c => c.UnitPrice * c.Quantity)
                };

                foreach (var line in _cart)
                {
                    order.Items.Add(new OrderItem
                    {
                        MedicineId = line.MedicineId,
                        Quantity = line.Quantity,
                        UnitPrice = line.UnitPrice
                    });
                }

                bool success = _orderDal.PlaceOrder(order);

                if (success)
                {
                    MessageBox.Show("Order placed successfully! You can track its status under \"My Orders\".",
                        "Order Placed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _cart.Clear();
                    RefreshCartGrid();
                    LoadMedicines(); // refresh stock numbers shown on screen
                }
                else
                {
                    MessageBox.Show("Could not place the order. Please try again.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error while placing the order.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Medicine GetSelectedMedicine()
        {
            if (dgvMedicines.CurrentRow == null)
                return null;

            return dgvMedicines.CurrentRow.DataBoundItem as Medicine;
        }

        /// <summary>
        /// Simple internal representation of a cart line before it becomes
        /// a real OrderItem at checkout time.
        /// </summary>
        private class CartLine
        {
            public int MedicineId { get; set; }
            public string MedicineName { get; set; }
            public decimal UnitPrice { get; set; }
            public int Quantity { get; set; }
        }
    }
}
