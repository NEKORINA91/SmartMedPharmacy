using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SmartMedPharmacy.DAL;
using SmartMedPharmacy.Models;

namespace SmartMedPharmacy.Forms
{
    public partial class SearchMedicineForm : Form
    {
        private readonly MedicineDAL  _medicineDal = new MedicineDAL();
        private readonly OrderDAL     _orderDal    = new OrderDAL();
        private readonly PromotionDAL _promoDal    = new PromotionDAL();
        private readonly Customer     _currentCustomer;
        private readonly List<CartLine> _cart      = new List<CartLine>();
        private Promotion _appliedPromo            = null;

        public SearchMedicineForm(Customer customer)
        {
            InitializeComponent();
            _currentCustomer = customer;
            dgvMedicines.CellFormatting += DgvMedicines_CellFormatting;
            LoadCategoryFilter();
            LoadMedicines();
            LoadPromos();
            RefreshCartGrid();
        }

        // ── Medicine list ────────────────────────────────────────────────────────

        private void LoadMedicines()
        {
            try { BindMedicineGrid(_medicineDal.GetAll()); }
            catch (Exception ex)
            { MessageBox.Show("Could not load medicines.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void LoadCategoryFilter()
        {
            try
            {
                var cats = _medicineDal.GetAll().Select(m => m.Category).Distinct().OrderBy(c => c).ToList();
                cmbCategory.Items.Clear();
                cmbCategory.Items.Add("All Categories");
                foreach (var c in cats) cmbCategory.Items.Add(c);
                cmbCategory.SelectedIndex = 0;
            }
            catch { }
        }

        private void LoadPromos()
        {
            try
            {
                var promos = _promoDal.GetActivePromos();
                cmbPromo.Items.Clear();
                cmbPromo.Items.Add("-- No Promo --");
                foreach (var p in promos) cmbPromo.Items.Add(p);
                cmbPromo.SelectedIndex     = 0;
                cmbPromo.DisplayMember     = "Summary";
            }
            catch { }
        }

        private void BindMedicineGrid(List<Medicine> medicines)
        {
            dgvMedicines.DataSource = null;
            dgvMedicines.DataSource = medicines;

            void Hide(string col) { if (dgvMedicines.Columns[col] != null) dgvMedicines.Columns[col].Visible = false; }
            void Head(string col, string h) { if (dgvMedicines.Columns[col] != null) dgvMedicines.Columns[col].HeaderText = h; }

            Hide("MedicineId"); Hide("Supplier"); Hide("CreatedAt");
            Hide("IsLowStock"); Hide("IsExpired"); Hide("IsExpiringSoon");
            Head("Name", "Name"); Head("Category", "Category");
            Head("Dosage", "Dosage"); Head("Price", "Price (Rs.)");
            Head("StockQuantity", "In Stock");

            if (dgvMedicines.Columns["ExpiryDate"] != null)
            { dgvMedicines.Columns["ExpiryDate"].HeaderText = "Expiry"; dgvMedicines.Columns["ExpiryDate"].DefaultCellStyle.Format = "dd MMM yyyy"; }
        }

        private void DgvMedicines_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var med = dgvMedicines.Rows[e.RowIndex].DataBoundItem as Medicine;
            if (med == null || !med.IsExpired) return;

            dgvMedicines.Rows[e.RowIndex].DefaultCellStyle.BackColor         = Color.FromArgb(240, 240, 240);
            dgvMedicines.Rows[e.RowIndex].DefaultCellStyle.ForeColor         = Color.FromArgb(160, 160, 160);
            dgvMedicines.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 220, 220);
            dgvMedicines.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.FromArgb(130, 130, 130);

            if (dgvMedicines.Columns["ExpiryDate"] != null && e.ColumnIndex == dgvMedicines.Columns["ExpiryDate"].Index)
            { e.Value = "EXPIRED"; e.CellStyle.BackColor = Color.FromArgb(220, 38, 38); e.CellStyle.ForeColor = Color.White; e.CellStyle.Font = UITheme.FontBodyBold; e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; e.FormattingApplied = true; }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtSearchName.Text.Trim();
                string category = cmbCategory.SelectedItem?.ToString() == "All Categories" ? null : cmbCategory.SelectedItem?.ToString();
                decimal? minPrice = null, maxPrice = null;
                if (!string.IsNullOrWhiteSpace(txtMinPrice.Text)) { if (!decimal.TryParse(txtMinPrice.Text, out decimal mn)) { MessageBox.Show("Min price must be a number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } minPrice = mn; }
                if (!string.IsNullOrWhiteSpace(txtMaxPrice.Text)) { if (!decimal.TryParse(txtMaxPrice.Text, out decimal mx)) { MessageBox.Show("Max price must be a number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } maxPrice = mx; }
                BindMedicineGrid(_medicineDal.Search(name, category, minPrice, maxPrice));
            }
            catch (Exception ex) { MessageBox.Show("Search failed.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        { txtSearchName.Clear(); txtMinPrice.Clear(); txtMaxPrice.Clear(); cmbCategory.SelectedIndex = 0; LoadMedicines(); }

        // ── Cart ─────────────────────────────────────────────────────────────────

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            Medicine selected = GetSelectedMedicine();
            if (selected == null) { MessageBox.Show("Please select a medicine first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (selected.IsExpired) { MessageBox.Show("\"" + selected.Name + "\" has expired and cannot be ordered.", "Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            int quantity = (int)numQuantity.Value;
            var existing = _cart.FirstOrDefault(c => c.MedicineId == selected.MedicineId);
            int alreadyInCart = existing?.Quantity ?? 0;

            if (alreadyInCart + quantity > selected.StockQuantity)
            { MessageBox.Show("Only " + selected.StockQuantity + " unit(s) in stock" + (alreadyInCart > 0 ? " (" + alreadyInCart + " in cart)." : "."), "Not Enough Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

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
                Medicine  = c.MedicineName,
                c.Quantity,
                UnitPrice = c.UnitPrice.ToString("N2"),
                LineTotal = (c.UnitPrice * c.Quantity).ToString("N2")
            }).ToList();

            if (dgvCart.Columns["MedicineId"] != null) dgvCart.Columns["MedicineId"].Visible = false;

            decimal subtotal = _cart.Sum(c => c.UnitPrice * c.Quantity);
            decimal discount = 0;

            // Revalidate applied promo against new subtotal
            if (_appliedPromo != null)
            {
                if (subtotal >= _appliedPromo.MinOrderAmount)
                    discount = _appliedPromo.DiscountAmount;
                else
                {
                    _appliedPromo = null;
                    cmbPromo.SelectedIndex = 0;
                    lblPromoStatus.Text    = "";
                }
            }

            decimal total = Math.Max(0, subtotal - discount);
            lblCartTotalValue.Text = "Rs. " + total.ToString("N2");
            if (discount > 0)
                lblCartTotalValue.Text += "  (- Rs. " + discount.ToString("N2") + " promo)";

            btnPlaceOrder.Enabled = _cart.Count > 0;
        }

        private void cmbPromo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPromo.SelectedItem is Promotion promo)
            {
                decimal subtotal = _cart.Sum(c => c.UnitPrice * c.Quantity);
                if (subtotal >= promo.MinOrderAmount)
                {
                    _appliedPromo          = promo;
                    lblPromoStatus.ForeColor = Color.FromArgb(6, 95, 70);
                    lblPromoStatus.Text    = "✔ Promo applied! Rs. " + promo.DiscountAmount.ToString("N0") + " off";
                }
                else
                {
                    _appliedPromo          = null;
                    lblPromoStatus.ForeColor = Color.FromArgb(185, 28, 28);
                    lblPromoStatus.Text    = "✘ Order must be at least Rs. " + promo.MinOrderAmount.ToString("N0") + " to use this promo";
                }
            }
            else
            {
                _appliedPromo        = null;
                lblPromoStatus.Text  = "";
            }
            RefreshCartGrid();
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
                if (delta > 0) { var med = _medicineDal.GetAll().FirstOrDefault(m => m.MedicineId == line.MedicineId); if (med != null && newQty > med.StockQuantity) { MessageBox.Show("Only " + med.StockQuantity + " unit(s) in stock.", "Not Enough Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } }
                line.Quantity = newQty;
            }
            RefreshCartGrid();
        }

        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow == null) { MessageBox.Show("Please select a cart item to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            int idx = dgvCart.CurrentRow.Index;
            if (idx >= 0 && idx < _cart.Count) { _cart.RemoveAt(idx); RefreshCartGrid(); }
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (_cart.Count == 0) { MessageBox.Show("Your cart is empty.", "Nothing to Order", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            decimal subtotal = _cart.Sum(c => c.UnitPrice * c.Quantity);
            decimal discount = (_appliedPromo != null && subtotal >= _appliedPromo.MinOrderAmount) ? _appliedPromo.DiscountAmount : 0;
            decimal grandTotal = Math.Max(0, subtotal - discount);

            string promoLine = discount > 0 ? "\nPromo \"" + _appliedPromo.Code + "\" applied: - Rs. " + discount.ToString("N2") : "";
            var confirm = MessageBox.Show("Place this order?\nSubtotal: Rs. " + subtotal.ToString("N2") + promoLine + "\nTotal: Rs. " + grandTotal.ToString("N2"),
                "Confirm Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                Order order = new Order(_currentCustomer.Id) { TotalAmount = grandTotal };
                foreach (var line in _cart)
                    order.Items.Add(new OrderItem { MedicineId = line.MedicineId, Quantity = line.Quantity, UnitPrice = line.UnitPrice });

                bool success = _orderDal.PlaceOrder(order);
                if (success)
                {
                    using (var dlg = new Form())
                    {
                        dlg.Text = "Order Placed"; dlg.ClientSize = new Size(420, 240);
                        dlg.FormBorderStyle = FormBorderStyle.FixedDialog; dlg.StartPosition = FormStartPosition.CenterParent;
                        dlg.MaximizeBox = false; dlg.MinimizeBox = false; dlg.BackColor = UITheme.Background;

                        var header = new Panel { BackColor = UITheme.Accent, Location = new Point(0, 0), Size = new Size(420, 60) };
                        header.Controls.Add(new Label { Text = "✔  Order Placed Successfully", Font = new Font("Segoe UI", 12f, System.Drawing.FontStyle.Bold), ForeColor = Color.White, BackColor = Color.Transparent, AutoSize = true, Location = new Point(16, 18) });
                        dlg.Controls.Add(header);

                        string bodyText = "Your order has been placed for Rs. " + grandTotal.ToString("N2") + ".";
                        if (discount > 0) bodyText += "\nPromo \"" + _appliedPromo.Code + "\" saved you Rs. " + discount.ToString("N2") + "! 🎉";
                        bodyText += "\n\nTrack your order under  My Orders.";
                        dlg.Controls.Add(new Label { Text = bodyText, Font = UITheme.FontBody, ForeColor = UITheme.TextPrimary, Location = new Point(20, 76), Size = new Size(380, 80) });

                        var ok = new Button { Text = "OK", BackColor = UITheme.Accent, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = UITheme.FontButton, Location = new Point(300, 182), Size = new Size(100, 34), DialogResult = DialogResult.OK, Cursor = Cursors.Hand };
                        ok.FlatAppearance.BorderSize = 0; dlg.Controls.Add(ok); dlg.AcceptButton = ok;
                        dlg.ShowDialog(this);
                    }
                    _cart.Clear(); _appliedPromo = null; cmbPromo.SelectedIndex = 0;
                    lblPromoStatus.Text = ""; RefreshCartGrid(); LoadMedicines();
                }
                else MessageBox.Show("Could not place the order. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show("Database error.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private Medicine GetSelectedMedicine()
        { if (dgvMedicines.CurrentRow == null) return null; return dgvMedicines.CurrentRow.DataBoundItem as Medicine; }

        private class CartLine
        {
            public int MedicineId { get; set; }
            public string MedicineName { get; set; }
            public decimal UnitPrice { get; set; }
            public int Quantity { get; set; }
        }
    }
}
