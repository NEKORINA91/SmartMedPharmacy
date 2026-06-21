namespace SmartMedPharmacy.Forms
{
    partial class MedicineDialogForm
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblDosage = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtDosage = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblName
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(30, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 15);
            this.lblName.Text = "Name:";

            // txtName
            this.txtName.Location = new System.Drawing.Point(160, 27);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(220, 23);

            // lblCategory
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(30, 65);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(60, 15);
            this.lblCategory.Text = "Category:";

            // txtCategory
            this.txtCategory.Location = new System.Drawing.Point(160, 62);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(220, 23);

            // lblDosage
            this.lblDosage.AutoSize = true;
            this.lblDosage.Location = new System.Drawing.Point(30, 100);
            this.lblDosage.Name = "lblDosage";
            this.lblDosage.Size = new System.Drawing.Size(52, 15);
            this.lblDosage.Text = "Dosage:";

            // txtDosage
            this.txtDosage.Location = new System.Drawing.Point(160, 97);
            this.txtDosage.Name = "txtDosage";
            this.txtDosage.Size = new System.Drawing.Size(220, 23);

            // lblPrice
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(30, 135);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(70, 15);
            this.lblPrice.Text = "Price (Rs.):";

            // txtPrice
            this.txtPrice.Location = new System.Drawing.Point(160, 132);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(220, 23);

            // lblStock
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(30, 170);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(85, 15);
            this.lblStock.Text = "Stock Quantity:";

            // txtStock
            this.txtStock.Location = new System.Drawing.Point(160, 167);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(220, 23);

            // lblSupplier
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(30, 205);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(58, 15);
            this.lblSupplier.Text = "Supplier:";

            // txtSupplier
            this.txtSupplier.Location = new System.Drawing.Point(160, 202);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(220, 23);

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(160, 250);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(280, 250);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // MedicineDialogForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 310);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSupplier);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtDosage);
            this.Controls.Add(this.lblDosage);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MedicineDialogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Medicine";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblDosage;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtDosage;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
