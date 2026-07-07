namespace SmartMedPharmacy.Forms
{
    partial class PromoDialogForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.lblCode        = new System.Windows.Forms.Label();
            this.txtCode        = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblMinOrder    = new System.Windows.Forms.Label();
            this.txtMinOrder    = new System.Windows.Forms.TextBox();
            this.lblDiscount    = new System.Windows.Forms.Label();
            this.txtDiscount    = new System.Windows.Forms.TextBox();
            this.lblExpiry      = new System.Windows.Forms.Label();
            this.dtpExpiry      = new System.Windows.Forms.DateTimePicker();
            this.chkActive      = new System.Windows.Forms.CheckBox();
            this.pnlButtons     = new System.Windows.Forms.Panel();
            this.btnSave        = new System.Windows.Forms.Button();
            this.btnCancel      = new System.Windows.Forms.Button();

            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = UITheme.Background;
            this.ClientSize          = new System.Drawing.Size(440, 380);
            this.Font                = UITheme.FontBody;
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox         = false; this.MinimizeBox = false;
            this.Name                = "PromoDialogForm";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text                = "Add Promotion";
            this.Controls.Add(this.lblCode);        this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblDescription); this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblMinOrder);    this.Controls.Add(this.txtMinOrder);
            this.Controls.Add(this.lblDiscount);    this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.lblExpiry);      this.Controls.Add(this.dtpExpiry);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.pnlButtons);

            System.Action<System.Windows.Forms.Label, string, int> lbl =
                (l, text, top) => { l.AutoSize = true; l.Font = UITheme.FontSmall; l.ForeColor = UITheme.TextSecondary; l.Location = new System.Drawing.Point(30, top); l.Text = text; };
            System.Action<System.Windows.Forms.TextBox, int> txb =
                (t, top) => { t.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; t.Font = UITheme.FontBody; t.Location = new System.Drawing.Point(170, top - 2); t.Size = new System.Drawing.Size(240, 23); };

            lbl(this.lblCode, "PROMO CODE", 28);        this.lblCode.Name = "lblCode";
            txb(this.txtCode, 28);                       this.txtCode.Name = "txtCode"; this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;

            lbl(this.lblDescription, "DESCRIPTION", 66); this.lblDescription.Name = "lblDescription";
            txb(this.txtDescription, 66);                 this.txtDescription.Name = "txtDescription";

            lbl(this.lblMinOrder, "MIN ORDER (RS.)", 104); this.lblMinOrder.Name = "lblMinOrder";
            txb(this.txtMinOrder, 104);                     this.txtMinOrder.Name = "txtMinOrder";

            lbl(this.lblDiscount, "DISCOUNT (RS.)", 142); this.lblDiscount.Name = "lblDiscount";
            txb(this.txtDiscount, 142);                    this.txtDiscount.Name = "txtDiscount";

            lbl(this.lblExpiry, "EXPIRY DATE", 180); this.lblExpiry.Name = "lblExpiry";
            this.dtpExpiry.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpiry.Location = new System.Drawing.Point(170, 178);
            this.dtpExpiry.MinDate  = System.DateTime.Today;
            this.dtpExpiry.Name     = "dtpExpiry";
            this.dtpExpiry.Size     = new System.Drawing.Size(160, 23);
            this.dtpExpiry.Value    = System.DateTime.Today.AddMonths(3);

            this.chkActive.AutoSize  = true;
            this.chkActive.Checked   = true;
            this.chkActive.Font      = UITheme.FontBody;
            this.chkActive.ForeColor = UITheme.TextPrimary;
            this.chkActive.Location  = new System.Drawing.Point(170, 216);
            this.chkActive.Name      = "chkActive";
            this.chkActive.Text      = "Active (visible to customers)";

            // Buttons
            this.pnlButtons.BackColor = UITheme.Background;
            this.pnlButtons.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Name      = "pnlButtons";
            this.pnlButtons.Size      = new System.Drawing.Size(440, 56);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnCancel);

            this.btnSave.BackColor = UITheme.Accent; this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0; this.btnSave.Font = UITheme.FontButton; this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(200, 12); this.btnSave.Name = "btnSave"; this.btnSave.Size = new System.Drawing.Size(100, 32);
            this.btnSave.Text = "Save"; this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand; this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(226, 232, 240); this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0; this.btnCancel.Font = UITheme.FontButton; this.btnCancel.ForeColor = UITheme.TextPrimary;
            this.btnCancel.Location = new System.Drawing.Point(310, 12); this.btnCancel.Name = "btnCancel"; this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.Text = "Cancel"; this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand; this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label          lblCode;
        private System.Windows.Forms.TextBox        txtCode;
        private System.Windows.Forms.Label          lblDescription;
        private System.Windows.Forms.TextBox        txtDescription;
        private System.Windows.Forms.Label          lblMinOrder;
        private System.Windows.Forms.TextBox        txtMinOrder;
        private System.Windows.Forms.Label          lblDiscount;
        private System.Windows.Forms.TextBox        txtDiscount;
        private System.Windows.Forms.Label          lblExpiry;
        private System.Windows.Forms.DateTimePicker dtpExpiry;
        private System.Windows.Forms.CheckBox       chkActive;
        private System.Windows.Forms.Panel          pnlButtons;
        private System.Windows.Forms.Button         btnSave;
        private System.Windows.Forms.Button         btnCancel;
    }
}
