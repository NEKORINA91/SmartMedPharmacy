namespace SmartMedPharmacy.Forms
{
    partial class MedicineDialogForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblName       = new System.Windows.Forms.Label();
            this.txtName       = new System.Windows.Forms.TextBox();
            this.lblCategory   = new System.Windows.Forms.Label();
            this.txtCategory   = new System.Windows.Forms.TextBox();
            this.lblDosage     = new System.Windows.Forms.Label();
            this.txtDosage     = new System.Windows.Forms.TextBox();
            this.lblPrice      = new System.Windows.Forms.Label();
            this.txtPrice      = new System.Windows.Forms.TextBox();
            this.lblStock      = new System.Windows.Forms.Label();
            this.txtStock      = new System.Windows.Forms.TextBox();
            this.lblSupplier   = new System.Windows.Forms.Label();
            this.txtSupplier   = new System.Windows.Forms.TextBox();
            this.lblExpiry     = new System.Windows.Forms.Label();
            this.chkHasExpiry  = new System.Windows.Forms.CheckBox();
            this.dtpExpiry     = new System.Windows.Forms.DateTimePicker();
            this.pnlButtons    = new System.Windows.Forms.Panel();
            this.btnSave       = new System.Windows.Forms.Button();
            this.btnCancel     = new System.Windows.Forms.Button();

            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = UITheme.Background;
            this.ClientSize          = new System.Drawing.Size(440, 400);
            this.Font                = UITheme.FontBody;
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox         = false;
            this.MinimizeBox         = false;
            this.Name                = "MedicineDialogForm";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text                = "Add Medicine";
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.lblDosage);
            this.Controls.Add(this.txtDosage);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.txtSupplier);
            this.Controls.Add(this.lblExpiry);
            this.Controls.Add(this.chkHasExpiry);
            this.Controls.Add(this.dtpExpiry);
            this.Controls.Add(this.pnlButtons);

            // Helper for label/field pairs
            System.Action<System.Windows.Forms.Label, string, int> lbl =
                (l, text, top) =>
                {
                    l.AutoSize  = true;
                    l.Font      = UITheme.FontSmall;
                    l.ForeColor = UITheme.TextSecondary;
                    l.Location  = new System.Drawing.Point(30, top);
                };

            System.Action<System.Windows.Forms.TextBox, int> txt =
                (t, top) =>
                {
                    t.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    t.Font        = UITheme.FontBody;
                    t.Location    = new System.Drawing.Point(160, top - 3);
                    t.Size        = new System.Drawing.Size(240, 23);
                };

            // Name
            lbl(this.lblName, "Name", 30); this.lblName.Name = "lblName"; this.lblName.Text = "NAME";
            txt(this.txtName, 30);         this.txtName.Name = "txtName";

            // Category
            lbl(this.lblCategory, "Category", 68); this.lblCategory.Name = "lblCategory"; this.lblCategory.Text = "CATEGORY";
            txt(this.txtCategory, 68);             this.txtCategory.Name = "txtCategory";

            // Dosage
            lbl(this.lblDosage, "Dosage", 106); this.lblDosage.Name = "lblDosage"; this.lblDosage.Text = "DOSAGE";
            txt(this.txtDosage, 106);           this.txtDosage.Name = "txtDosage";

            // Price
            lbl(this.lblPrice, "Price", 144); this.lblPrice.Name = "lblPrice"; this.lblPrice.Text = "PRICE (RS.)";
            txt(this.txtPrice, 144);          this.txtPrice.Name = "txtPrice";

            // Stock
            lbl(this.lblStock, "Stock", 182); this.lblStock.Name = "lblStock"; this.lblStock.Text = "STOCK QTY";
            txt(this.txtStock, 182);          this.txtStock.Name = "txtStock";

            // Supplier
            lbl(this.lblSupplier, "Supplier", 220); this.lblSupplier.Name = "lblSupplier"; this.lblSupplier.Text = "SUPPLIER";
            txt(this.txtSupplier, 220);             this.txtSupplier.Name = "txtSupplier";

            // Expiry Date label
            this.lblExpiry.AutoSize  = true;
            this.lblExpiry.Font      = UITheme.FontSmall;
            this.lblExpiry.ForeColor = UITheme.TextSecondary;
            this.lblExpiry.Location  = new System.Drawing.Point(30, 260);
            this.lblExpiry.Name      = "lblExpiry";
            this.lblExpiry.Text      = "EXPIRY DATE";

            // Checkbox to enable/disable expiry
            this.chkHasExpiry.AutoSize  = true;
            this.chkHasExpiry.Font      = UITheme.FontBody;
            this.chkHasExpiry.ForeColor = UITheme.TextPrimary;
            this.chkHasExpiry.Location  = new System.Drawing.Point(160, 257);
            this.chkHasExpiry.Name      = "chkHasExpiry";
            this.chkHasExpiry.Text      = "Set expiry date";
            this.chkHasExpiry.CheckedChanged += new System.EventHandler(this.chkHasExpiry_CheckedChanged);

            // DateTimePicker
            this.dtpExpiry.Enabled  = false;
            this.dtpExpiry.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpiry.Location = new System.Drawing.Point(160, 285);
            this.dtpExpiry.MinDate  = System.DateTime.Today;
            this.dtpExpiry.Name     = "dtpExpiry";
            this.dtpExpiry.Size     = new System.Drawing.Size(160, 23);

            // Buttons panel
            this.pnlButtons.BackColor = UITheme.Background;
            this.pnlButtons.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Name      = "pnlButtons";
            this.pnlButtons.Size      = new System.Drawing.Size(440, 56);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnCancel);

            this.btnSave.BackColor = UITheme.Accent;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font      = UITheme.FontButton;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location  = new System.Drawing.Point(200, 12);
            this.btnSave.Name      = "btnSave";
            this.btnSave.Size      = new System.Drawing.Size(100, 32);
            this.btnSave.Text      = "Save";
            this.btnSave.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click    += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font      = UITheme.FontButton;
            this.btnCancel.ForeColor = UITheme.TextPrimary;
            this.btnCancel.Location  = new System.Drawing.Point(310, 12);
            this.btnCancel.Name      = "btnCancel";
            this.btnCancel.Size      = new System.Drawing.Size(100, 32);
            this.btnCancel.Text      = "Cancel";
            this.btnCancel.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click    += new System.EventHandler(this.btnCancel_Click);

            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label           lblName;
        private System.Windows.Forms.TextBox         txtName;
        private System.Windows.Forms.Label           lblCategory;
        private System.Windows.Forms.TextBox         txtCategory;
        private System.Windows.Forms.Label           lblDosage;
        private System.Windows.Forms.TextBox         txtDosage;
        private System.Windows.Forms.Label           lblPrice;
        private System.Windows.Forms.TextBox         txtPrice;
        private System.Windows.Forms.Label           lblStock;
        private System.Windows.Forms.TextBox         txtStock;
        private System.Windows.Forms.Label           lblSupplier;
        private System.Windows.Forms.TextBox         txtSupplier;
        private System.Windows.Forms.Label           lblExpiry;
        private System.Windows.Forms.CheckBox        chkHasExpiry;
        private System.Windows.Forms.DateTimePicker  dtpExpiry;
        private System.Windows.Forms.Panel           pnlButtons;
        private System.Windows.Forms.Button          btnSave;
        private System.Windows.Forms.Button          btnCancel;
    }
}
