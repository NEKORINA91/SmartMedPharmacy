namespace SmartMedPharmacy.Forms
{
    partial class OrderDetailsForm
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
            this.lblOrderId = new System.Windows.Forms.Label();
            this.lblOrderIdValue = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblCustomerValue = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDateValue = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatusValue = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.btnMarkReady = new System.Windows.Forms.Button();
            this.btnMarkDelivered = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();

            // lblOrderId
            this.lblOrderId.AutoSize = true;
            this.lblOrderId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblOrderId.Location = new System.Drawing.Point(20, 15);
            this.lblOrderId.Name = "lblOrderId";
            this.lblOrderId.Size = new System.Drawing.Size(70, 21);
            this.lblOrderId.Text = "Order:";

            // lblOrderIdValue
            this.lblOrderIdValue.AutoSize = true;
            this.lblOrderIdValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblOrderIdValue.Location = new System.Drawing.Point(90, 15);
            this.lblOrderIdValue.Name = "lblOrderIdValue";
            this.lblOrderIdValue.Size = new System.Drawing.Size(40, 21);
            this.lblOrderIdValue.Text = "#0";

            // lblCustomer
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(20, 50);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(60, 15);
            this.lblCustomer.Text = "Customer:";

            // lblCustomerValue
            this.lblCustomerValue.AutoSize = true;
            this.lblCustomerValue.Location = new System.Drawing.Point(150, 50);
            this.lblCustomerValue.Name = "lblCustomerValue";
            this.lblCustomerValue.Size = new System.Drawing.Size(60, 15);
            this.lblCustomerValue.Text = "-";

            // lblDate
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(20, 75);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(75, 15);
            this.lblDate.Text = "Order Date:";

            // lblDateValue
            this.lblDateValue.AutoSize = true;
            this.lblDateValue.Location = new System.Drawing.Point(150, 75);
            this.lblDateValue.Name = "lblDateValue";
            this.lblDateValue.Size = new System.Drawing.Size(60, 15);
            this.lblDateValue.Text = "-";

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 100);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(45, 15);
            this.lblStatus.Text = "Status:";

            // lblStatusValue
            this.lblStatusValue.AutoSize = true;
            this.lblStatusValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatusValue.Location = new System.Drawing.Point(150, 100);
            this.lblStatusValue.Name = "lblStatusValue";
            this.lblStatusValue.Size = new System.Drawing.Size(60, 15);
            this.lblStatusValue.Text = "-";

            // dgvItems
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.ReadOnly = true;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.MultiSelect = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.Location = new System.Drawing.Point(20, 135);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.Size = new System.Drawing.Size(520, 200);

            // lblTotal
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(20, 350);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(90, 20);
            this.lblTotal.Text = "Order Total:";

            // lblTotalValue
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalValue.Location = new System.Drawing.Point(150, 350);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(80, 20);
            this.lblTotalValue.Text = "Rs. 0.00";

            // btnMarkReady
            this.btnMarkReady.Location = new System.Drawing.Point(20, 390);
            this.btnMarkReady.Name = "btnMarkReady";
            this.btnMarkReady.Size = new System.Drawing.Size(160, 32);
            this.btnMarkReady.Text = "Mark Ready for Pickup";
            this.btnMarkReady.UseVisualStyleBackColor = true;
            this.btnMarkReady.Click += new System.EventHandler(this.btnMarkReady_Click);

            // btnMarkDelivered
            this.btnMarkDelivered.Location = new System.Drawing.Point(190, 390);
            this.btnMarkDelivered.Name = "btnMarkDelivered";
            this.btnMarkDelivered.Size = new System.Drawing.Size(140, 32);
            this.btnMarkDelivered.Text = "Mark Delivered";
            this.btnMarkDelivered.UseVisualStyleBackColor = true;
            this.btnMarkDelivered.Click += new System.EventHandler(this.btnMarkDelivered_Click);

            // btnClose
            this.btnClose.Location = new System.Drawing.Point(460, 390);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 32);
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // OrderDetailsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 445);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMarkDelivered);
            this.Controls.Add(this.btnMarkReady);
            this.Controls.Add(this.lblTotalValue);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.lblStatusValue);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblDateValue);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblCustomerValue);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lblOrderIdValue);
            this.Controls.Add(this.lblOrderId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Order Details";
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.Label lblOrderIdValue;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblCustomerValue;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDateValue;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblStatusValue;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Button btnMarkReady;
        private System.Windows.Forms.Button btnMarkDelivered;
        private System.Windows.Forms.Button btnClose;
    }
}
