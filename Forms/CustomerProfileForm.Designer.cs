namespace SmartMedPharmacy.Forms
{
    partial class CustomerProfileForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader      = new System.Windows.Forms.Panel();
            this.lblTitle       = new System.Windows.Forms.Label();
            this.pnlBody        = new System.Windows.Forms.Panel();
            this.lblFullName    = new System.Windows.Forms.Label();
            this.txtFullName    = new System.Windows.Forms.TextBox();
            this.lblEmail       = new System.Windows.Forms.Label();
            this.txtEmail       = new System.Windows.Forms.TextBox();
            this.lblPhone       = new System.Windows.Forms.Label();
            this.txtPhone       = new System.Windows.Forms.TextBox();
            this.lblAddress     = new System.Windows.Forms.Label();
            this.txtAddress     = new System.Windows.Forms.TextBox();
            this.pnlFooter      = new System.Windows.Forms.Panel();
            this.btnSave        = new System.Windows.Forms.Button();
            this.btnCancel      = new System.Windows.Forms.Button();

            // ── pnlHeader ──────────────────────────────────────────────
            this.pnlHeader.BackColor  = System.Drawing.Color.FromArgb(31, 41, 55);
            this.pnlHeader.Dock       = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height     = 60;
            this.pnlHeader.Controls.Add(this.lblTitle);

            this.lblTitle.AutoSize  = false;
            this.lblTitle.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Text      = "Edit My Profile";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Padding   = new System.Windows.Forms.Padding(16, 0, 0, 0);

            // ── pnlBody ────────────────────────────────────────────────
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.pnlBody.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Padding   = new System.Windows.Forms.Padding(32, 24, 32, 0);

            // Shared field dimensions
            int labelWidth  = 110;
            int fieldWidth  = 320;
            int fieldHeight = 34;
            int rowSpacing  = 56;
            int startY      = 24;
            int labelX      = 0;
            int fieldX      = labelWidth + 8;

            // ── Full Name ──
            this.lblFullName.AutoSize  = false;
            this.lblFullName.Size      = new System.Drawing.Size(labelWidth, fieldHeight);
            this.lblFullName.Location  = new System.Drawing.Point(labelX, startY + 5);
            this.lblFullName.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFullName.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblFullName.Text      = "Full Name *";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.txtFullName.Size      = new System.Drawing.Size(fieldWidth, fieldHeight);
            this.txtFullName.Location  = new System.Drawing.Point(fieldX, startY);
            this.txtFullName.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFullName.MaxLength = 100;
            this.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFullName.BackColor = System.Drawing.Color.White;

            // ── Email ──
            this.lblEmail.AutoSize  = false;
            this.lblEmail.Size      = new System.Drawing.Size(labelWidth, fieldHeight);
            this.lblEmail.Location  = new System.Drawing.Point(labelX, startY + rowSpacing + 5);
            this.lblEmail.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblEmail.Text      = "Email *";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.txtEmail.Size      = new System.Drawing.Size(fieldWidth, fieldHeight);
            this.txtEmail.Location  = new System.Drawing.Point(fieldX, startY + rowSpacing);
            this.txtEmail.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.MaxLength = 150;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.BackColor = System.Drawing.Color.White;

            // ── Phone ──
            this.lblPhone.AutoSize  = false;
            this.lblPhone.Size      = new System.Drawing.Size(labelWidth, fieldHeight);
            this.lblPhone.Location  = new System.Drawing.Point(labelX, startY + rowSpacing * 2 + 5);
            this.lblPhone.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblPhone.Text      = "Phone *";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.txtPhone.Size      = new System.Drawing.Size(fieldWidth, fieldHeight);
            this.txtPhone.Location  = new System.Drawing.Point(fieldX, startY + rowSpacing * 2);
            this.txtPhone.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPhone.MaxLength = 20;
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.BackColor = System.Drawing.Color.White;

            // ── Address ──
            this.lblAddress.AutoSize  = false;
            this.lblAddress.Size      = new System.Drawing.Size(labelWidth, fieldHeight);
            this.lblAddress.Location  = new System.Drawing.Point(labelX, startY + rowSpacing * 3 + 5);
            this.lblAddress.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblAddress.Text      = "Address";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.txtAddress.Size        = new System.Drawing.Size(fieldWidth, 72);
            this.txtAddress.Location    = new System.Drawing.Point(fieldX, startY + rowSpacing * 3);
            this.txtAddress.Font        = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAddress.MaxLength   = 300;
            this.txtAddress.Multiline   = true;
            this.txtAddress.ScrollBars  = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.BackColor   = System.Drawing.Color.White;

            this.pnlBody.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.lblFullName, this.txtFullName,
                this.lblEmail,    this.txtEmail,
                this.lblPhone,    this.txtPhone,
                this.lblAddress,  this.txtAddress
            });

            // ── pnlFooter ──────────────────────────────────────────────
            this.pnlFooter.BackColor  = System.Drawing.Color.FromArgb(243, 244, 246);
            this.pnlFooter.Dock       = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height     = 60;
            this.pnlFooter.Padding    = new System.Windows.Forms.Padding(0, 10, 20, 0);
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnSave);

            // ── btnSave ──
            this.btnSave.Size      = new System.Drawing.Size(110, 36);
            this.btnSave.Anchor    = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.Location  = new System.Drawing.Point(this.pnlFooter.Width - 130, 12);
            this.btnSave.Text      = "Save Changes";
            this.btnSave.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Click    += new System.EventHandler(this.btnSave_Click);

            // ── btnCancel ──
            this.btnCancel.Size      = new System.Drawing.Size(90, 36);
            this.btnCancel.Anchor    = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top;
            this.btnCancel.Location  = new System.Drawing.Point(this.pnlFooter.Width - 230, 12);
            this.btnCancel.Text      = "Cancel";
            this.btnCancel.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Click    += new System.EventHandler(this.btnCancel_Click);

            // ── Form ───────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(500, 420);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox         = false;
            this.MinimizeBox         = false;
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text                = "My Profile — SmartMed Pharmacy";
            this.BackColor           = System.Drawing.Color.FromArgb(249, 250, 251);

            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
        }

        #endregion

        private System.Windows.Forms.Panel   pnlHeader;
        private System.Windows.Forms.Label   lblTitle;
        private System.Windows.Forms.Panel   pnlBody;
        private System.Windows.Forms.Label   lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label   lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label   lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label   lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Panel   pnlFooter;
        private System.Windows.Forms.Button  btnSave;
        private System.Windows.Forms.Button  btnCancel;
    }
}
