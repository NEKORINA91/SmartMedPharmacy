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
        private readonly List<CartLine> _cart = new List<CartLine>();

        public SearchMedicineForm(Customer customer)
        {
            InitializeComponent();
            _currentCustomer = customer;
            LoadCategoryFilter();
            LoadMedicines();
            RefreshCartGrid();
        }

        // ── Medicine list ────────────────────────────────────────────────────────

        private void LoadMedicines()
        {
            try
            {
                BindMedicineGrid(_medicineDal.GetAll());
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
                var cats = _medicineDal.GetAll()
                    .Select(m => m.Category).Distinct().OrderBy(c => c).ToList();
                cmbCategory.Items.Clear();
                cmbCategory.Items.Add("All Categories");
                foreach (var c in cats) cmbCategory.Items.Add(c);
                cmbCategory.SelectedIndex = 0;
            }
            catch { }
        }

        private void BindMedicineGrid(List<Medicine> medicines)
        {
            dgvMedicines.DataSource = null;
            dgvMedicines.DataSource = medicines;

            void Hide(string col) { if (dgvMedicines.Columns[col] != null) dgvMedicines.Columns[col].Visible = false; }
            void Head(string col, string h) { if (dgvMedicines.Columns[col] != null) dgvMedicines.Columns[col].HeaderText = h; }

            Hide("MedicineId"); Hide("Supplier"); Hide("CreatedAt"); Hide("IsLowStock");
            Head("Name", "Name"); Head("Category", "Category");
            Head("Dosage", "Dosage"); Head("Price", "Price (Rs.)");
            Head("StockQuantity", "In Stock");
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

                BindMedicineGrid(_medicineDal.Search(name, category, minPrice, maxPrice));
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

        // ── Cart ─────────────────────────────────────────────────────────────────

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            Medicine selected = GetSelectedMedicine();
            if (selected == null)
            { MessageBox.Show("Please select a medicine first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            int quantity = (int)numQuantity.Value;
            var existing = _cart.FirstOrDefault(c => c.MedicineId == selected.MedicineId);
            int alreadyInCart = existing?.Quantity ?? 0;

            if (alreadyInCart + quantity > selected.StockQuantity)
            {
                MessageBox.Show("Only " + selected.StockQuantity + " unit(s) in stock" +
                    (alreadyInCart > 0 ? " (" + alreadyInCart + " already in cart)." : "."),
                    "Not Enough Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (existing != null) existing.Quantity += quantity;
            else _cart.Add(new CartLine { MedicineId = selected.MedicineId, MedicineName = selected.Name, UnitPrice = selected.Price, Quantity = quantity });

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

            if (dgvCart.Columns["MedicineId"] != null) dgvCart.Columns["MedicineId"].Visible = false;

            decimal total = _cart.Sum(c => c.UnitPrice * c.Quantity);
            lblCartTotalValue.Text = "Rs. " + total.ToString("N2");
            btnPlaceOrder.Enabled = _cart.Count > 0;
        }

        private void btnIncreaseQty_Click(object sender, EventArgs e) => AdjustSelectedCartLine(1);
        private void btnDecreaseQty_Click(object sender, EventArgs e) => AdjustSelectedCartLine(-1);

        private void AdjustSelectedCartLine(int delta)
        {
            if (dgvCart.CurrentRow == null) return;
            int idx = dgvCart.CurrentRow.Index;
            if (idx < 0 || idx >= _cart.Count) return;

            var line = _cart[idx];
            int newQty = line.Quantity + delta;

            if (newQty <= 0) { _cart.RemoveAt(idx); }
            else
            {
                if (delta > 0)
                {
                    var med = _medicineDal.GetAll().FirstOrDefault(m => m.MedicineId == line.MedicineId);
                    if (med != null && newQty > med.StockQuantity)
                    { MessageBox.Show("Only " + med.StockQuantity + " unit(s) in stock.", "Not Enough Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                }
                line.Quantity = newQty;
            }
            RefreshCartGrid();
        }

        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow == null)
            { MessageBox.Show("Please select a cart item to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            int idx = dgvCart.CurrentRow.Index;
            if (idx >= 0 && idx < _cart.Count) { _cart.RemoveAt(idx); RefreshCartGrid(); }
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (_cart.Count == 0)
            { MessageBox.Show("Your cart is empty.", "Nothing to Order", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            decimal grandTotal = _cart.Sum(c => c.UnitPrice * c.Quantity);
            var confirm = MessageBox.Show(
                "Place this order for a total of Rs. " + grandTotal.ToString("N2") + "?",
                "Confirm Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                Order order = new Order(_currentCustomer.Id)
                {
                    TotalAmount = grandTotal
                };
                foreach (var line in _cart)
                    order.Items.Add(new OrderItem { MedicineId = line.MedicineId, Quantity = line.Quantity, UnitPrice = line.UnitPrice });

                bool success = _orderDal.PlaceOrder(order);

                if (success)
                {
                    // ── Styled order confirmation dialog ─────────────────────────
                    using (var dlg = new System.Windows.Forms.Form())
                    {
                        dlg.Text            = "Order Placed";
                        dlg.ClientSize      = new System.Drawing.Size(420, 220);
                        dlg.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                        dlg.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
                        dlg.MaximizeBox     = false;
                        dlg.MinimizeBox     = false;
                        dlg.BackColor       = UITheme.Background;

                        // Teal header
                        var header = new System.Windows.Forms.Panel
                        {
                            BackColor = UITheme.Accent,
                            Location  = new System.Drawing.Point(0, 0),
                            Size      = new System.Drawing.Size(420, 60)
                        };
                        var hTitle = new System.Windows.Forms.Label
                        {
                            Text      = "✔  Order Placed Successfully",
                            Font      = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Bold),
                            ForeColor = System.Drawing.Color.White,
                            BackColor = System.Drawing.Color.Transparent,
                            AutoSize  = true,
                            Location  = new System.Drawing.Point(16, 18)
                        };
                        header.Controls.Add(hTitle);
                        dlg.Controls.Add(header);

                        // Body
                        var body = new System.Windows.Forms.Label
                        {
                            Text      = "Your order has been placed for Rs. " + grandTotal.ToString("N2") + ".\n\n" +
                                        "You can track its status under  My Orders.",
                            Font      = UITheme.FontBody,
                            ForeColor = UITheme.TextPrimary,
                            Location  = new System.Drawing.Point(20, 76),
                            Size      = new System.Drawing.Size(380, 60)
                        };
                        dlg.Controls.Add(body);

                        // OK button
                        var ok = new System.Windows.Forms.Button
                        {
                            Text      = "OK",
                            BackColor = UITheme.Accent,
                            ForeColor = System.Drawing.Color.White,
                            FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                            Font      = UITheme.FontButton,
                            Location  = new System.Drawing.Point(300, 162),
                            Size      = new System.Drawing.Size(100, 34),
                            DialogResult = System.Windows.Forms.DialogResult.OK,
                            Cursor    = System.Windows.Forms.Cursors.Hand
                        };
                        ok.FlatAppearance.BorderSize = 0;
                        dlg.Controls.Add(ok);
                        dlg.AcceptButton = ok;

                        dlg.ShowDialog(this);
                    }

                    _cart.Clear();
                    RefreshCartGrid();
                    LoadMedicines();
                }
                else
                {
                    MessageBox.Show("Could not place the order. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error while placing the order.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Medicine GetSelectedMedicine()
        {
            if (dgvMedicines.CurrentRow == null) return null;
            return dgvMedicines.CurrentRow.DataBoundItem as Medicine;
        }

        private class CartLine
        {
            public int MedicineId { get; set; }
            public string MedicineName { get; set; }
            public decimal UnitPrice { get; set; }
            public int Quantity { get; set; }
        }
    }
}
