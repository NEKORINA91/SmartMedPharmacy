namespace SmartMedPharmacy.Forms
{
    partial class SearchMedicineForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.lblTitle          = new System.Windows.Forms.Label();
            this.pnlSearchBar      = new System.Windows.Forms.Panel();
            this.lblSearchName     = new System.Windows.Forms.Label();
            this.txtSearchName     = new System.Windows.Forms.TextBox();
            this.lblCategory       = new System.Windows.Forms.Label();
            this.cmbCategory       = new System.Windows.Forms.ComboBox();
            this.lblMinPrice       = new System.Windows.Forms.Label();
            this.txtMinPrice       = new System.Windows.Forms.TextBox();
            this.lblMaxPrice       = new System.Windows.Forms.Label();
            this.txtMaxPrice       = new System.Windows.Forms.TextBox();
            this.btnSearch         = new System.Windows.Forms.Button();
            this.btnClearSearch    = new System.Windows.Forms.Button();
            this.dgvMedicines      = new System.Windows.Forms.DataGridView();
            this.pnlAddToCart      = new System.Windows.Forms.Panel();
            this.lblQuantity       = new System.Windows.Forms.Label();
            this.numQuantity       = new System.Windows.Forms.NumericUpDown();
            this.btnAddToCart      = new System.Windows.Forms.Button();
            this.lblCartTitle      = new System.Windows.Forms.Label();
            this.dgvCart           = new System.Windows.Forms.DataGridView();
            this.pnlPromo          = new System.Windows.Forms.Panel();
            this.lblPromoLabel     = new System.Windows.Forms.Label();
            this.cmbPromo          = new System.Windows.Forms.ComboBox();
            this.lblPromoStatus    = new System.Windows.Forms.Label();
            this.pnlCartActions    = new System.Windows.Forms.Panel();
            this.btnIncreaseQty    = new System.Windows.Forms.Button();
            this.btnDecreaseQty    = new System.Windows.Forms.Button();
            this.btnRemoveFromCart = new System.Windows.Forms.Button();
            this.lblCartTotal      = new System.Windows.Forms.Label();
            this.lblCartTotalValue = new System.Windows.Forms.Label();
            this.btnPlaceOrder     = new System.Windows.Forms.Button();

            this.pnlSearchBar.SuspendLayout();
            this.pnlAddToCart.SuspendLayout();
            this.pnlPromo.SuspendLayout();
            this.pnlCartActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.SuspendLayout();

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = UITheme.Background;
            this.ClientSize          = new System.Drawing.Size(800, 640);
            this.Font                = UITheme.FontBody;
            this.Name                = "SearchMedicineForm";
            this.Text                = "Search Medicines";
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlSearchBar);
            this.Controls.Add(this.dgvMedicines);
            this.Controls.Add(this.pnlAddToCart);
            this.Controls.Add(this.lblCartTitle);
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.pnlPromo);
            this.Controls.Add(this.pnlCartActions);

            // Title
            this.lblTitle.AutoSize = true; this.lblTitle.Font = UITheme.FontHeading; this.lblTitle.ForeColor = UITheme.TextPrimary;
            this.lblTitle.Location = new System.Drawing.Point(0, 0); this.lblTitle.Name = "lblTitle"; this.lblTitle.Text = "Search Medicines";

            // Search bar
            this.pnlSearchBar.BackColor = UITheme.Surface; this.pnlSearchBar.Location = new System.Drawing.Point(0, 36);
            this.pnlSearchBar.Name = "pnlSearchBar"; this.pnlSearchBar.Size = new System.Drawing.Size(800, 52);
            this.pnlSearchBar.Controls.Add(this.lblSearchName); this.pnlSearchBar.Controls.Add(this.txtSearchName);
            this.pnlSearchBar.Controls.Add(this.lblCategory);   this.pnlSearchBar.Controls.Add(this.cmbCategory);
            this.pnlSearchBar.Controls.Add(this.lblMinPrice);   this.pnlSearchBar.Controls.Add(this.txtMinPrice);
            this.pnlSearchBar.Controls.Add(this.lblMaxPrice);   this.pnlSearchBar.Controls.Add(this.txtMaxPrice);
            this.pnlSearchBar.Controls.Add(this.btnSearch);     this.pnlSearchBar.Controls.Add(this.btnClearSearch);

            System.Action<System.Windows.Forms.Label, string, int> sl = (l, t, x) => { l.AutoSize = true; l.Font = UITheme.FontSmall; l.ForeColor = UITheme.TextSecondary; l.Location = new System.Drawing.Point(x, 6); l.Text = t; };
            System.Action<System.Windows.Forms.TextBox, int, int> st = (tb, x, w) => { tb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; tb.Location = new System.Drawing.Point(x, 22); tb.Size = new System.Drawing.Size(w, 23); };

            sl(this.lblSearchName, "Name",     8);  this.lblSearchName.Name = "lblSearchName";
            st(this.txtSearchName, 8, 140);          this.txtSearchName.Name = "txtSearchName";
            sl(this.lblCategory,   "Category", 158); this.lblCategory.Name = "lblCategory";
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbCategory.Location = new System.Drawing.Point(158, 22); this.cmbCategory.Name = "cmbCategory"; this.cmbCategory.Size = new System.Drawing.Size(140, 23);
            sl(this.lblMinPrice,   "Min Price", 308); this.lblMinPrice.Name = "lblMinPrice";
            st(this.txtMinPrice, 308, 80);             this.txtMinPrice.Name = "txtMinPrice";
            sl(this.lblMaxPrice,   "Max Price", 398); this.lblMaxPrice.Name = "lblMaxPrice";
            st(this.txtMaxPrice, 398, 80);             this.txtMaxPrice.Name = "txtMaxPrice";

            this.btnSearch.BackColor = UITheme.Accent; this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Font = UITheme.FontButton; this.btnSearch.ForeColor = System.Drawing.Color.White; this.btnSearch.Location = new System.Drawing.Point(490, 20);
            this.btnSearch.Name = "btnSearch"; this.btnSearch.Size = new System.Drawing.Size(80, 26); this.btnSearch.Text = "Search"; this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand; this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            this.btnClearSearch.BackColor = System.Drawing.Color.FromArgb(226, 232, 240); this.btnClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnClearSearch.FlatAppearance.BorderSize = 0;
            this.btnClearSearch.Font = UITheme.FontButton; this.btnClearSearch.ForeColor = UITheme.TextPrimary; this.btnClearSearch.Location = new System.Drawing.Point(578, 20);
            this.btnClearSearch.Name = "btnClearSearch"; this.btnClearSearch.Size = new System.Drawing.Size(70, 26); this.btnClearSearch.Text = "Clear"; this.btnClearSearch.Cursor = System.Windows.Forms.Cursors.Hand; this.btnClearSearch.UseVisualStyleBackColor = false;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);

            // Medicine grid
            this.dgvMedicines.AllowUserToAddRows = false; this.dgvMedicines.AllowUserToDeleteRows = false; this.dgvMedicines.ReadOnly = true;
            this.dgvMedicines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect; this.dgvMedicines.MultiSelect = false; this.dgvMedicines.RowHeadersVisible = false;
            this.dgvMedicines.BorderStyle = System.Windows.Forms.BorderStyle.None; this.dgvMedicines.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMedicines.BackgroundColor = UITheme.Surface; this.dgvMedicines.GridColor = UITheme.Border; this.dgvMedicines.Font = UITheme.FontBody;
            this.dgvMedicines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMedicines.Location = new System.Drawing.Point(0, 98); this.dgvMedicines.Name = "dgvMedicines"; this.dgvMedicines.Size = new System.Drawing.Size(800, 180);
            this.dgvMedicines.EnableHeadersVisualStyles = false; this.dgvMedicines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicines.ColumnHeadersDefaultCellStyle.BackColor = UITheme.Background; this.dgvMedicines.ColumnHeadersDefaultCellStyle.ForeColor = UITheme.TextSecondary;
            this.dgvMedicines.ColumnHeadersDefaultCellStyle.Font = UITheme.FontTableHeader; this.dgvMedicines.ColumnHeadersDefaultCellStyle.SelectionBackColor = UITheme.Background;
            this.dgvMedicines.DefaultCellStyle.BackColor = UITheme.Surface; this.dgvMedicines.DefaultCellStyle.ForeColor = UITheme.TextPrimary;
            this.dgvMedicines.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(224, 247, 246); this.dgvMedicines.DefaultCellStyle.SelectionForeColor = UITheme.TextPrimary;
            this.dgvMedicines.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0); this.dgvMedicines.RowTemplate.Height = 34;
            this.dgvMedicines.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);

            // Add to cart row
            this.pnlAddToCart.BackColor = UITheme.Surface; this.pnlAddToCart.Location = new System.Drawing.Point(0, 288);
            this.pnlAddToCart.Name = "pnlAddToCart"; this.pnlAddToCart.Size = new System.Drawing.Size(800, 44);
            this.pnlAddToCart.Controls.Add(this.lblQuantity); this.pnlAddToCart.Controls.Add(this.numQuantity); this.pnlAddToCart.Controls.Add(this.btnAddToCart);

            this.lblQuantity.AutoSize = true; this.lblQuantity.Font = UITheme.FontBodyBold; this.lblQuantity.ForeColor = UITheme.TextSecondary; this.lblQuantity.Location = new System.Drawing.Point(10, 14); this.lblQuantity.Name = "lblQuantity"; this.lblQuantity.Text = "Qty:";
            this.numQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; this.numQuantity.Location = new System.Drawing.Point(44, 10); this.numQuantity.Minimum = 1; this.numQuantity.Maximum = 1000; this.numQuantity.Value = 1; this.numQuantity.Name = "numQuantity"; this.numQuantity.Size = new System.Drawing.Size(64, 23);
            this.btnAddToCart.BackColor = UITheme.Accent; this.btnAddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnAddToCart.FlatAppearance.BorderSize = 0;
            this.btnAddToCart.Font = UITheme.FontButton; this.btnAddToCart.ForeColor = System.Drawing.Color.White; this.btnAddToCart.Location = new System.Drawing.Point(118, 9);
            this.btnAddToCart.Name = "btnAddToCart"; this.btnAddToCart.Size = new System.Drawing.Size(110, 26); this.btnAddToCart.Text = "+ Add to Cart"; this.btnAddToCart.Cursor = System.Windows.Forms.Cursors.Hand; this.btnAddToCart.UseVisualStyleBackColor = false;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);

            // Cart title
            this.lblCartTitle.AutoSize = true; this.lblCartTitle.Font = UITheme.FontSubHeading; this.lblCartTitle.ForeColor = UITheme.TextPrimary;
            this.lblCartTitle.Location = new System.Drawing.Point(0, 342); this.lblCartTitle.Name = "lblCartTitle"; this.lblCartTitle.Text = "Your Cart";

            // Cart grid
            this.dgvCart.AllowUserToAddRows = false; this.dgvCart.AllowUserToDeleteRows = false; this.dgvCart.ReadOnly = true;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect; this.dgvCart.MultiSelect = false; this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.BorderStyle = System.Windows.Forms.BorderStyle.None; this.dgvCart.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCart.BackgroundColor = UITheme.Surface; this.dgvCart.GridColor = UITheme.Border; this.dgvCart.Font = UITheme.FontBody;
            this.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCart.Location = new System.Drawing.Point(0, 368); this.dgvCart.Name = "dgvCart"; this.dgvCart.Size = new System.Drawing.Size(800, 100);
            this.dgvCart.EnableHeadersVisualStyles = false; this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.ColumnHeadersDefaultCellStyle.BackColor = UITheme.Background; this.dgvCart.ColumnHeadersDefaultCellStyle.ForeColor = UITheme.TextSecondary;
            this.dgvCart.ColumnHeadersDefaultCellStyle.Font = UITheme.FontTableHeader;
            this.dgvCart.DefaultCellStyle.BackColor = UITheme.Surface; this.dgvCart.DefaultCellStyle.ForeColor = UITheme.TextPrimary;
            this.dgvCart.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(224, 247, 246); this.dgvCart.DefaultCellStyle.SelectionForeColor = UITheme.TextPrimary;
            this.dgvCart.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0); this.dgvCart.RowTemplate.Height = 32;

            // Promo panel
            this.pnlPromo.BackColor = System.Drawing.Color.FromArgb(240, 253, 252);
            this.pnlPromo.Location  = new System.Drawing.Point(0, 476);
            this.pnlPromo.Name      = "pnlPromo";
            this.pnlPromo.Size      = new System.Drawing.Size(800, 44);
            this.pnlPromo.Controls.Add(this.lblPromoLabel);
            this.pnlPromo.Controls.Add(this.cmbPromo);
            this.pnlPromo.Controls.Add(this.lblPromoStatus);

            this.lblPromoLabel.AutoSize = true; this.lblPromoLabel.Font = UITheme.FontBodyBold; this.lblPromoLabel.ForeColor = UITheme.Accent;
            this.lblPromoLabel.Location = new System.Drawing.Point(10, 14); this.lblPromoLabel.Name = "lblPromoLabel"; this.lblPromoLabel.Text = "🏷  Promo:";

            this.cmbPromo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPromo.Location = new System.Drawing.Point(90, 10); this.cmbPromo.Name = "cmbPromo"; this.cmbPromo.Size = new System.Drawing.Size(340, 23);
            this.cmbPromo.SelectedIndexChanged += new System.EventHandler(this.cmbPromo_SelectedIndexChanged);

            this.lblPromoStatus.AutoSize = true; this.lblPromoStatus.Font = UITheme.FontSmall; this.lblPromoStatus.ForeColor = System.Drawing.Color.FromArgb(6, 95, 70);
            this.lblPromoStatus.Location = new System.Drawing.Point(440, 14); this.lblPromoStatus.Name = "lblPromoStatus"; this.lblPromoStatus.Text = "";

            // Cart actions
            this.pnlCartActions.BackColor = UITheme.Background; this.pnlCartActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCartActions.Name = "pnlCartActions"; this.pnlCartActions.Size = new System.Drawing.Size(800, 52);
            this.pnlCartActions.Controls.Add(this.btnIncreaseQty); this.pnlCartActions.Controls.Add(this.btnDecreaseQty);
            this.pnlCartActions.Controls.Add(this.btnRemoveFromCart); this.pnlCartActions.Controls.Add(this.lblCartTotal);
            this.pnlCartActions.Controls.Add(this.lblCartTotalValue); this.pnlCartActions.Controls.Add(this.btnPlaceOrder);

            System.Action<System.Windows.Forms.Button, string, System.Drawing.Color, System.Drawing.Color, int, int> sb =
                (btn, text, bg, fg, left, width) => { btn.BackColor = bg; btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat; btn.FlatAppearance.BorderSize = 0; btn.Font = UITheme.FontButton; btn.ForeColor = fg; btn.Location = new System.Drawing.Point(left, 10); btn.Size = new System.Drawing.Size(width, 30); btn.Text = text; btn.Cursor = System.Windows.Forms.Cursors.Hand; btn.UseVisualStyleBackColor = false; };

            this.btnIncreaseQty.Name = "btnIncreaseQty";
            sb(this.btnIncreaseQty, "+", UITheme.Accent, System.Drawing.Color.White, 0, 36);
            this.btnIncreaseQty.Click += new System.EventHandler(this.btnIncreaseQty_Click);

            this.btnDecreaseQty.Name = "btnDecreaseQty";
            sb(this.btnDecreaseQty, "−", System.Drawing.Color.FromArgb(226, 232, 240), UITheme.TextPrimary, 42, 36);
            this.btnDecreaseQty.Click += new System.EventHandler(this.btnDecreaseQty_Click);

            this.btnRemoveFromCart.BackColor = System.Drawing.Color.FromArgb(254, 226, 226); this.btnRemoveFromCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnRemoveFromCart.FlatAppearance.BorderSize = 0;
            this.btnRemoveFromCart.Font = UITheme.FontButton; this.btnRemoveFromCart.ForeColor = System.Drawing.Color.FromArgb(185, 28, 28); this.btnRemoveFromCart.Location = new System.Drawing.Point(84, 10);
            this.btnRemoveFromCart.Name = "btnRemoveFromCart"; this.btnRemoveFromCart.Size = new System.Drawing.Size(90, 30); this.btnRemoveFromCart.Text = "Remove"; this.btnRemoveFromCart.Cursor = System.Windows.Forms.Cursors.Hand; this.btnRemoveFromCart.UseVisualStyleBackColor = false;
            this.btnRemoveFromCart.Click += new System.EventHandler(this.btnRemoveFromCart_Click);

            this.lblCartTotal.AutoSize = true; this.lblCartTotal.Font = UITheme.FontBodyBold; this.lblCartTotal.ForeColor = UITheme.TextSecondary; this.lblCartTotal.Location = new System.Drawing.Point(390, 18); this.lblCartTotal.Name = "lblCartTotal"; this.lblCartTotal.Text = "Total:";
            this.lblCartTotalValue.AutoSize = true; this.lblCartTotalValue.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold); this.lblCartTotalValue.ForeColor = UITheme.Accent; this.lblCartTotalValue.Location = new System.Drawing.Point(438, 16); this.lblCartTotalValue.Name = "lblCartTotalValue"; this.lblCartTotalValue.Text = "Rs. 0.00";

            this.btnPlaceOrder.BackColor = UITheme.Accent; this.btnPlaceOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnPlaceOrder.FlatAppearance.BorderSize = 0;
            this.btnPlaceOrder.Font = UITheme.FontButton; this.btnPlaceOrder.ForeColor = System.Drawing.Color.White; this.btnPlaceOrder.Location = new System.Drawing.Point(648, 8);
            this.btnPlaceOrder.Name = "btnPlaceOrder"; this.btnPlaceOrder.Size = new System.Drawing.Size(140, 34); this.btnPlaceOrder.Text = "Place Order"; this.btnPlaceOrder.Enabled = false; this.btnPlaceOrder.Cursor = System.Windows.Forms.Cursors.Hand; this.btnPlaceOrder.UseVisualStyleBackColor = false;
            this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);

            this.pnlSearchBar.ResumeLayout(false);   this.pnlSearchBar.PerformLayout();
            this.pnlAddToCart.ResumeLayout(false);   this.pnlAddToCart.PerformLayout();
            this.pnlPromo.ResumeLayout(false);       this.pnlPromo.PerformLayout();
            this.pnlCartActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label            lblTitle;
        private System.Windows.Forms.Panel            pnlSearchBar;
        private System.Windows.Forms.Label            lblSearchName;
        private System.Windows.Forms.TextBox          txtSearchName;
        private System.Windows.Forms.Label            lblCategory;
        private System.Windows.Forms.ComboBox         cmbCategory;
        private System.Windows.Forms.Label            lblMinPrice;
        private System.Windows.Forms.TextBox          txtMinPrice;
        private System.Windows.Forms.Label            lblMaxPrice;
        private System.Windows.Forms.TextBox          txtMaxPrice;
        private System.Windows.Forms.Button           btnSearch;
        private System.Windows.Forms.Button           btnClearSearch;
        private System.Windows.Forms.DataGridView     dgvMedicines;
        private System.Windows.Forms.Panel            pnlAddToCart;
        private System.Windows.Forms.Label            lblQuantity;
        private System.Windows.Forms.NumericUpDown    numQuantity;
        private System.Windows.Forms.Button           btnAddToCart;
        private System.Windows.Forms.Label            lblCartTitle;
        private System.Windows.Forms.DataGridView     dgvCart;
        private System.Windows.Forms.Panel            pnlPromo;
        private System.Windows.Forms.Label            lblPromoLabel;
        private System.Windows.Forms.ComboBox         cmbPromo;
        private System.Windows.Forms.Label            lblPromoStatus;
        private System.Windows.Forms.Panel            pnlCartActions;
        private System.Windows.Forms.Button           btnIncreaseQty;
        private System.Windows.Forms.Button           btnDecreaseQty;
        private System.Windows.Forms.Button           btnRemoveFromCart;
        private System.Windows.Forms.Label            lblCartTotal;
        private System.Windows.Forms.Label            lblCartTotalValue;
        private System.Windows.Forms.Button           btnPlaceOrder;
    }
}
