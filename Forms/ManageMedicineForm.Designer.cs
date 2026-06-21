namespace SmartMedPharmacy.Forms
{
    partial class ManageMedicineForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSearchName = new System.Windows.Forms.Label();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblMinPrice = new System.Windows.Forms.Label();
            this.txtMinPrice = new System.Windows.Forms.TextBox();
            this.lblMaxPrice = new System.Windows.Forms.Label();
            this.txtMaxPrice = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.dgvMedicines = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(220, 25);
            this.lblTitle.Text = "Manage Medicine";

            // lblSearchName
            this.lblSearchName.AutoSize = true;
            this.lblSearchName.Location = new System.Drawing.Point(0, 45);
            this.lblSearchName.Name = "lblSearchName";
            this.lblSearchName.Size = new System.Drawing.Size(45, 15);
            this.lblSearchName.Text = "Name:";

            // txtSearchName
            this.txtSearchName.Location = new System.Drawing.Point(0, 63);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(150, 23);

            // lblCategory
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(165, 45);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(60, 15);
            this.lblCategory.Text = "Category:";

            // cmbCategory
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Location = new System.Drawing.Point(165, 63);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(150, 23);

            // lblMinPrice
            this.lblMinPrice.AutoSize = true;
            this.lblMinPrice.Location = new System.Drawing.Point(330, 45);
            this.lblMinPrice.Name = "lblMinPrice";
            this.lblMinPrice.Size = new System.Drawing.Size(60, 15);
            this.lblMinPrice.Text = "Min Price:";

            // txtMinPrice
            this.txtMinPrice.Location = new System.Drawing.Point(330, 63);
            this.txtMinPrice.Name = "txtMinPrice";
            this.txtMinPrice.Size = new System.Drawing.Size(90, 23);

            // lblMaxPrice
            this.lblMaxPrice.AutoSize = true;
            this.lblMaxPrice.Location = new System.Drawing.Point(435, 45);
            this.lblMaxPrice.Name = "lblMaxPrice";
            this.lblMaxPrice.Size = new System.Drawing.Size(63, 15);
            this.lblMaxPrice.Text = "Max Price:";

            // txtMaxPrice
            this.txtMaxPrice.Location = new System.Drawing.Point(435, 63);
            this.txtMaxPrice.Name = "txtMaxPrice";
            this.txtMaxPrice.Size = new System.Drawing.Size(90, 23);

            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(540, 62);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 25);
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // btnClearSearch
            this.btnClearSearch.Location = new System.Drawing.Point(630, 62);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(80, 25);
            this.btnClearSearch.Text = "Clear";
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);

            // dgvMedicines
            this.dgvMedicines.AllowUserToAddRows = false;
            this.dgvMedicines.AllowUserToDeleteRows = false;
            this.dgvMedicines.ReadOnly = true;
            this.dgvMedicines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedicines.MultiSelect = false;
            this.dgvMedicines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMedicines.Location = new System.Drawing.Point(0, 100);
            this.dgvMedicines.Name = "dgvMedicines";
            this.dgvMedicines.RowHeadersVisible = false;
            this.dgvMedicines.Size = new System.Drawing.Size(720, 320);

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(0, 435);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.Text = "Add New";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnEdit
            this.btnEdit.Location = new System.Drawing.Point(110, 435);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 30);
            this.btnEdit.Text = "Edit Selected";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(220, 435);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 30);
            this.btnDelete.Text = "Delete Selected";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // ManageMedicineForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 480);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvMedicines);
            this.Controls.Add(this.btnClearSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtMaxPrice);
            this.Controls.Add(this.lblMaxPrice);
            this.Controls.Add(this.txtMinPrice);
            this.Controls.Add(this.lblMinPrice);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtSearchName);
            this.Controls.Add(this.lblSearchName);
            this.Controls.Add(this.lblTitle);
            this.Name = "ManageMedicineForm";
            this.Text = "ManageMedicineForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSearchName;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblMinPrice;
        private System.Windows.Forms.TextBox txtMinPrice;
        private System.Windows.Forms.Label lblMaxPrice;
        private System.Windows.Forms.TextBox txtMaxPrice;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.DataGridView dgvMedicines;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
    }
}
