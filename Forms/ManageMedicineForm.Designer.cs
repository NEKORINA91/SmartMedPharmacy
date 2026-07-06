namespace SmartMedPharmacy.Forms
{
    partial class ManageMedicineForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle       = new System.Windows.Forms.Label();
            this.pnlLegend      = new System.Windows.Forms.Panel();
            this.lblLegendExpired = new System.Windows.Forms.Label();
            this.lblLegendSoon  = new System.Windows.Forms.Label();
            this.pnlSearchBar   = new System.Windows.Forms.Panel();
            this.lblSearchName  = new System.Windows.Forms.Label();
            this.txtSearchName  = new System.Windows.Forms.TextBox();
            this.lblCategory    = new System.Windows.Forms.Label();
            this.cmbCategory    = new System.Windows.Forms.ComboBox();
            this.lblMinPrice    = new System.Windows.Forms.Label();
            this.txtMinPrice    = new System.Windows.Forms.TextBox();
            this.lblMaxPrice    = new System.Windows.Forms.Label();
            this.txtMaxPrice    = new System.Windows.Forms.TextBox();
            this.btnSearch      = new System.Windows.Forms.Button();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.dgvMedicines   = new System.Windows.Forms.DataGridView();
            this.pnlActions     = new System.Windows.Forms.Panel();
            this.btnAdd         = new System.Windows.Forms.Button();
            this.btnEdit        = new System.Windows.Forms.Button();
            this.btnDelete      = new System.Windows.Forms.Button();

            this.pnlLegend.SuspendLayout();
            this.pnlSearchBar.SuspendLayout();
            this.pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).BeginInit();
            this.SuspendLayout();

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = UITheme.Background;
            this.ClientSize          = new System.Drawing.Size(800, 580);
            this.Font                = UITheme.FontBody;
            this.Name                = "ManageMedicineForm";
            this.Text                = "Manage Medicines";
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlLegend);
            this.Controls.Add(this.pnlSearchBar);
            this.Controls.Add(this.dgvMedicines);
            this.Controls.Add(this.pnlActions);

            // Title
            this.lblTitle.AutoSize  = true;
            this.lblTitle.Font      = UITheme.FontHeading;
            this.lblTitle.ForeColor = UITheme.TextPrimary;
            this.lblTitle.Location  = new System.Drawing.Point(0, 0);
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Text      = "Manage Medicines";

            // Legend
            this.pnlLegend.BackColor = System.Drawing.Color.Transparent;
            this.pnlLegend.Location  = new System.Drawing.Point(0, 38);
            this.pnlLegend.Name      = "pnlLegend";
            this.pnlLegend.Size      = new System.Drawing.Size(800, 22);
            this.pnlLegend.Controls.Add(this.lblLegendExpired);
            this.pnlLegend.Controls.Add(this.lblLegendSoon);

            this.lblLegendExpired.AutoSize  = true;
            this.lblLegendExpired.Font      = UITheme.FontSmall;
            this.lblLegendExpired.BackColor = System.Drawing.Color.FromArgb(254, 226, 226);
            this.lblLegendExpired.ForeColor = System.Drawing.Color.FromArgb(153, 27, 27);
            this.lblLegendExpired.Location  = new System.Drawing.Point(0, 3);
            this.lblLegendExpired.Name      = "lblLegendExpired";
            this.lblLegendExpired.Padding   = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lblLegendExpired.Text      = "  ● Expired  ";

            this.lblLegendSoon.AutoSize  = true;
            this.lblLegendSoon.Font      = UITheme.FontSmall;
            this.lblLegendSoon.BackColor = System.Drawing.Color.FromArgb(254, 243, 199);
            this.lblLegendSoon.ForeColor = System.Drawing.Color.FromArgb(120, 53, 15);
            this.lblLegendSoon.Location  = new System.Drawing.Point(90, 3);
            this.lblLegendSoon.Name      = "lblLegendSoon";
            this.lblLegendSoon.Padding   = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lblLegendSoon.Text      = "  ● Expiring within 30 days  ";

            // Search bar
            this.pnlSearchBar.BackColor = UITheme.Surface;
            this.pnlSearchBar.Location  = new System.Drawing.Point(0, 68);
            this.pnlSearchBar.Name      = "pnlSearchBar";
            this.pnlSearchBar.Size      = new System.Drawing.Size(800, 52);
            this.pnlSearchBar.Controls.Add(this.lblSearchName);
            this.pnlSearchBar.Controls.Add(this.txtSearchName);
            this.pnlSearchBar.Controls.Add(this.lblCategory);
            this.pnlSearchBar.Controls.Add(this.cmbCategory);
            this.pnlSearchBar.Controls.Add(this.lblMinPrice);
            this.pnlSearchBar.Controls.Add(this.txtMinPrice);
            this.pnlSearchBar.Controls.Add(this.lblMaxPrice);
            this.pnlSearchBar.Controls.Add(this.txtMaxPrice);
            this.pnlSearchBar.Controls.Add(this.btnSearch);
            this.pnlSearchBar.Controls.Add(this.btnClearSearch);

            this.lblSearchName.AutoSize  = true; this.lblSearchName.Font = UITheme.FontSmall; this.lblSearchName.ForeColor = UITheme.TextSecondary;
            this.lblSearchName.Location  = new System.Drawing.Point(8, 6); this.lblSearchName.Name = "lblSearchName"; this.lblSearchName.Text = "Name";
            this.txtSearchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchName.Location  = new System.Drawing.Point(8, 22); this.txtSearchName.Name = "txtSearchName"; this.txtSearchName.Size = new System.Drawing.Size(140, 23);

            this.lblCategory.AutoSize = true; this.lblCategory.Font = UITheme.FontSmall; this.lblCategory.ForeColor = UITheme.TextSecondary;
            this.lblCategory.Location = new System.Drawing.Point(158, 6); this.lblCategory.Name = "lblCategory"; this.lblCategory.Text = "Category";
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Location = new System.Drawing.Point(158, 22); this.cmbCategory.Name = "cmbCategory"; this.cmbCategory.Size = new System.Drawing.Size(150, 23);

            this.lblMinPrice.AutoSize = true; this.lblMinPrice.Font = UITheme.FontSmall; this.lblMinPrice.ForeColor = UITheme.TextSecondary;
            this.lblMinPrice.Location = new System.Drawing.Point(318, 6); this.lblMinPrice.Name = "lblMinPrice"; this.lblMinPrice.Text = "Min Price";
            this.txtMinPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinPrice.Location = new System.Drawing.Point(318, 22); this.txtMinPrice.Name = "txtMinPrice"; this.txtMinPrice.Size = new System.Drawing.Size(80, 23);

            this.lblMaxPrice.AutoSize = true; this.lblMaxPrice.Font = UITheme.FontSmall; this.lblMaxPrice.ForeColor = UITheme.TextSecondary;
            this.lblMaxPrice.Location = new System.Drawing.Point(408, 6); this.lblMaxPrice.Name = "lblMaxPrice"; this.lblMaxPrice.Text = "Max Price";
            this.txtMaxPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaxPrice.Location = new System.Drawing.Point(408, 22); this.txtMaxPrice.Name = "txtMaxPrice"; this.txtMaxPrice.Size = new System.Drawing.Size(80, 23);

            this.btnSearch.BackColor = UITheme.Accent; this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0; this.btnSearch.Font = UITheme.FontButton; this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(500, 20); this.btnSearch.Name = "btnSearch"; this.btnSearch.Size = new System.Drawing.Size(80, 26);
            this.btnSearch.Text = "Search"; this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand; this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            this.btnClearSearch.BackColor = System.Drawing.Color.FromArgb(226, 232, 240); this.btnClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSearch.FlatAppearance.BorderSize = 0; this.btnClearSearch.Font = UITheme.FontButton; this.btnClearSearch.ForeColor = UITheme.TextPrimary;
            this.btnClearSearch.Location = new System.Drawing.Point(588, 20); this.btnClearSearch.Name = "btnClearSearch"; this.btnClearSearch.Size = new System.Drawing.Size(70, 26);
            this.btnClearSearch.Text = "Clear"; this.btnClearSearch.Cursor = System.Windows.Forms.Cursors.Hand; this.btnClearSearch.UseVisualStyleBackColor = false;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);

            // Grid
            this.dgvMedicines.AllowUserToAddRows    = false;
            this.dgvMedicines.AllowUserToDeleteRows = false;
            this.dgvMedicines.ReadOnly              = true;
            this.dgvMedicines.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedicines.MultiSelect            = false;
            this.dgvMedicines.RowHeadersVisible      = false;
            this.dgvMedicines.BorderStyle            = System.Windows.Forms.BorderStyle.None;
            this.dgvMedicines.CellBorderStyle        = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMedicines.BackgroundColor        = UITheme.Surface;
            this.dgvMedicines.GridColor              = UITheme.Border;
            this.dgvMedicines.Font                   = UITheme.FontBody;
            this.dgvMedicines.AutoSizeColumnsMode    = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMedicines.Location               = new System.Drawing.Point(0, 130);
            this.dgvMedicines.Name                   = "dgvMedicines";
            this.dgvMedicines.Size                   = new System.Drawing.Size(800, 396);
            this.dgvMedicines.Anchor                 = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom;
            this.dgvMedicines.EnableHeadersVisualStyles   = false;
            this.dgvMedicines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicines.ColumnHeadersDefaultCellStyle.BackColor          = UITheme.Background;
            this.dgvMedicines.ColumnHeadersDefaultCellStyle.ForeColor          = UITheme.TextSecondary;
            this.dgvMedicines.ColumnHeadersDefaultCellStyle.Font               = UITheme.FontTableHeader;
            this.dgvMedicines.ColumnHeadersDefaultCellStyle.SelectionBackColor = UITheme.Background;
            this.dgvMedicines.ColumnHeadersDefaultCellStyle.SelectionForeColor = UITheme.TextSecondary;
            this.dgvMedicines.DefaultCellStyle.BackColor          = UITheme.Surface;
            this.dgvMedicines.DefaultCellStyle.ForeColor          = UITheme.TextPrimary;
            this.dgvMedicines.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(224, 247, 246);
            this.dgvMedicines.DefaultCellStyle.SelectionForeColor = UITheme.TextPrimary;
            this.dgvMedicines.DefaultCellStyle.Padding            = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dgvMedicines.RowTemplate.Height                   = 34;

            // Action bar
            this.pnlActions.BackColor = UITheme.Background;
            this.pnlActions.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Name      = "pnlActions";
            this.pnlActions.Size      = new System.Drawing.Size(800, 48);
            this.pnlActions.Controls.Add(this.btnAdd);
            this.pnlActions.Controls.Add(this.btnEdit);
            this.pnlActions.Controls.Add(this.btnDelete);

            this.btnAdd.BackColor = UITheme.Accent; this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0; this.btnAdd.Font = UITheme.FontButton; this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(0, 9); this.btnAdd.Name = "btnAdd"; this.btnAdd.Size = new System.Drawing.Size(110, 30);
            this.btnAdd.Text = "+ Add New"; this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand; this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(226, 232, 240); this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.FlatAppearance.BorderSize = 0; this.btnEdit.Font = UITheme.FontButton; this.btnEdit.ForeColor = UITheme.TextPrimary;
            this.btnEdit.Location = new System.Drawing.Point(118, 9); this.btnEdit.Name = "btnEdit"; this.btnEdit.Size = new System.Drawing.Size(110, 30);
            this.btnEdit.Text = "Edit Selected"; this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand; this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(254, 226, 226); this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0; this.btnDelete.Font = UITheme.FontButton; this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.btnDelete.Location = new System.Drawing.Point(236, 9); this.btnDelete.Name = "btnDelete"; this.btnDelete.Size = new System.Drawing.Size(120, 30);
            this.btnDelete.Text = "Delete Selected"; this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand; this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // Resume
            this.pnlLegend.ResumeLayout(false);    this.pnlLegend.PerformLayout();
            this.pnlSearchBar.ResumeLayout(false);  this.pnlSearchBar.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label          lblTitle;
        private System.Windows.Forms.Panel          pnlLegend;
        private System.Windows.Forms.Label          lblLegendExpired;
        private System.Windows.Forms.Label          lblLegendSoon;
        private System.Windows.Forms.Panel          pnlSearchBar;
        private System.Windows.Forms.Label          lblSearchName;
        private System.Windows.Forms.TextBox        txtSearchName;
        private System.Windows.Forms.Label          lblCategory;
        private System.Windows.Forms.ComboBox       cmbCategory;
        private System.Windows.Forms.Label          lblMinPrice;
        private System.Windows.Forms.TextBox        txtMinPrice;
        private System.Windows.Forms.Label          lblMaxPrice;
        private System.Windows.Forms.TextBox        txtMaxPrice;
        private System.Windows.Forms.Button         btnSearch;
        private System.Windows.Forms.Button         btnClearSearch;
        private System.Windows.Forms.DataGridView   dgvMedicines;
        private System.Windows.Forms.Panel          pnlActions;
        private System.Windows.Forms.Button         btnAdd;
        private System.Windows.Forms.Button         btnEdit;
        private System.Windows.Forms.Button         btnDelete;
    }
}
