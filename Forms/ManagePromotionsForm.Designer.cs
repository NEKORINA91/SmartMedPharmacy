namespace SmartMedPharmacy.Forms
{
    partial class ManagePromotionsForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.lblTitle      = new System.Windows.Forms.Label();
            this.lblLegend     = new System.Windows.Forms.Label();
            this.dgvPromos     = new System.Windows.Forms.DataGridView();
            this.pnlActions    = new System.Windows.Forms.Panel();
            this.btnAdd        = new System.Windows.Forms.Button();
            this.btnEdit       = new System.Windows.Forms.Button();
            this.btnToggleActive = new System.Windows.Forms.Button();
            this.btnDelete     = new System.Windows.Forms.Button();

            this.pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromos)).BeginInit();
            this.SuspendLayout();

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor     = UITheme.Background;
            this.ClientSize    = new System.Drawing.Size(800, 560);
            this.Font          = UITheme.FontBody;
            this.Name          = "ManagePromotionsForm";
            this.Text          = "Manage Promotions";
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblLegend);
            this.Controls.Add(this.dgvPromos);
            this.Controls.Add(this.pnlActions);

            this.lblTitle.AutoSize  = true;
            this.lblTitle.Font      = UITheme.FontHeading;
            this.lblTitle.ForeColor = UITheme.TextPrimary;
            this.lblTitle.Location  = new System.Drawing.Point(0, 0);
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Text      = "Manage Promotions";

            this.lblLegend.AutoSize  = true;
            this.lblLegend.Font      = UITheme.FontSmall;
            this.lblLegend.ForeColor = UITheme.TextSecondary;
            this.lblLegend.Location  = new System.Drawing.Point(0, 40);
            this.lblLegend.Name      = "lblLegend";
            this.lblLegend.Text      = "  🟢 Active    ⬜ Expired / Inactive";

            // Grid
            this.dgvPromos.AllowUserToAddRows    = false;
            this.dgvPromos.AllowUserToDeleteRows = false;
            this.dgvPromos.ReadOnly              = true;
            this.dgvPromos.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPromos.MultiSelect            = false;
            this.dgvPromos.RowHeadersVisible      = false;
            this.dgvPromos.BorderStyle            = System.Windows.Forms.BorderStyle.None;
            this.dgvPromos.CellBorderStyle        = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPromos.BackgroundColor        = UITheme.Surface;
            this.dgvPromos.GridColor              = UITheme.Border;
            this.dgvPromos.Font                   = UITheme.FontBody;
            this.dgvPromos.AutoSizeColumnsMode    = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPromos.Location               = new System.Drawing.Point(0, 62);
            this.dgvPromos.Name                   = "dgvPromos";
            this.dgvPromos.Size                   = new System.Drawing.Size(800, 444);
            this.dgvPromos.Anchor                 = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom;
            this.dgvPromos.EnableHeadersVisualStyles   = false;
            this.dgvPromos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPromos.ColumnHeadersDefaultCellStyle.BackColor          = UITheme.Background;
            this.dgvPromos.ColumnHeadersDefaultCellStyle.ForeColor          = UITheme.TextSecondary;
            this.dgvPromos.ColumnHeadersDefaultCellStyle.Font               = UITheme.FontTableHeader;
            this.dgvPromos.ColumnHeadersDefaultCellStyle.SelectionBackColor = UITheme.Background;
            this.dgvPromos.ColumnHeadersDefaultCellStyle.SelectionForeColor = UITheme.TextSecondary;
            this.dgvPromos.DefaultCellStyle.BackColor          = UITheme.Surface;
            this.dgvPromos.DefaultCellStyle.ForeColor          = UITheme.TextPrimary;
            this.dgvPromos.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(224, 247, 246);
            this.dgvPromos.DefaultCellStyle.SelectionForeColor = UITheme.TextPrimary;
            this.dgvPromos.DefaultCellStyle.Padding            = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dgvPromos.RowTemplate.Height                   = 36;

            // Action bar
            this.pnlActions.BackColor = UITheme.Background;
            this.pnlActions.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Name      = "pnlActions";
            this.pnlActions.Size      = new System.Drawing.Size(800, 48);
            this.pnlActions.Controls.Add(this.btnAdd);
            this.pnlActions.Controls.Add(this.btnEdit);
            this.pnlActions.Controls.Add(this.btnToggleActive);
            this.pnlActions.Controls.Add(this.btnDelete);

            // btn helper
            System.Action<System.Windows.Forms.Button, string, System.Drawing.Color, System.Drawing.Color, int, int> sb =
                (btn, text, bg, fg, left, width) =>
                {
                    btn.BackColor = bg; btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0; btn.Font = UITheme.FontButton; btn.ForeColor = fg;
                    btn.Location = new System.Drawing.Point(left, 9); btn.Size = new System.Drawing.Size(width, 30);
                    btn.Text = text; btn.Cursor = System.Windows.Forms.Cursors.Hand;
                    btn.UseVisualStyleBackColor = false;
                };

            this.btnAdd.Name = "btnAdd";
            sb(this.btnAdd, "+ Add Promo", UITheme.Accent, System.Drawing.Color.White, 0, 120);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnEdit.Name = "btnEdit";
            sb(this.btnEdit, "Edit", System.Drawing.Color.FromArgb(226, 232, 240), UITheme.TextPrimary, 128, 90);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            this.btnToggleActive.Name = "btnToggleActive";
            sb(this.btnToggleActive, "Enable / Disable", System.Drawing.Color.FromArgb(219, 234, 254), System.Drawing.Color.FromArgb(29, 78, 216), 226, 140);
            this.btnToggleActive.Click += new System.EventHandler(this.btnToggleActive_Click);

            this.btnDelete.Name = "btnDelete";
            sb(this.btnDelete, "Delete", System.Drawing.Color.FromArgb(254, 226, 226), System.Drawing.Color.FromArgb(185, 28, 28), 374, 90);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.pnlActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label          lblTitle;
        private System.Windows.Forms.Label          lblLegend;
        private System.Windows.Forms.DataGridView   dgvPromos;
        private System.Windows.Forms.Panel          pnlActions;
        private System.Windows.Forms.Button         btnAdd;
        private System.Windows.Forms.Button         btnEdit;
        private System.Windows.Forms.Button         btnToggleActive;
        private System.Windows.Forms.Button         btnDelete;
    }
}
