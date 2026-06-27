namespace SmartMedPharmacy.Forms
{
    partial class ManageOrdersForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle     = new System.Windows.Forms.Label();
            this.dgvOrders    = new System.Windows.Forms.DataGridView();
            this.pnlActions   = new System.Windows.Forms.Panel();
            this.btnViewOrder = new System.Windows.Forms.Button();
            this.btnRefresh   = new System.Windows.Forms.Button();

            this.pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = UITheme.Background;
            this.ClientSize          = new System.Drawing.Size(760, 520);
            this.Font                = UITheme.FontBody;
            this.Name                = "ManageOrdersForm";
            this.Text                = "Manage Orders";
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.pnlActions);

            // Title
            this.lblTitle.AutoSize  = true;
            this.lblTitle.Font      = UITheme.FontHeading;
            this.lblTitle.ForeColor = UITheme.TextPrimary;
            this.lblTitle.Location  = new System.Drawing.Point(0, 0);
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Text      = "Manage Orders";

            // Grid
            this.dgvOrders.AllowUserToAddRows    = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.ReadOnly              = true;
            this.dgvOrders.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.MultiSelect            = false;
            this.dgvOrders.RowHeadersVisible      = false;
            this.dgvOrders.BorderStyle            = System.Windows.Forms.BorderStyle.None;
            this.dgvOrders.CellBorderStyle        = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvOrders.BackgroundColor        = UITheme.Surface;
            this.dgvOrders.GridColor              = UITheme.Border;
            this.dgvOrders.Font                   = UITheme.FontBody;
            this.dgvOrders.AutoSizeColumnsMode    = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.Location               = new System.Drawing.Point(0, 44);
            this.dgvOrders.Name                   = "dgvOrders";
            this.dgvOrders.Size                   = new System.Drawing.Size(760, 424);
            this.dgvOrders.Anchor                 = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom;
            this.dgvOrders.EnableHeadersVisualStyles   = false;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgvOrders.ColumnHeadersDefaultCellStyle.BackColor          = UITheme.Background;
            this.dgvOrders.ColumnHeadersDefaultCellStyle.ForeColor          = UITheme.TextSecondary;
            this.dgvOrders.ColumnHeadersDefaultCellStyle.Font               = UITheme.FontTableHeader;
            this.dgvOrders.ColumnHeadersDefaultCellStyle.SelectionBackColor = UITheme.Background;
            this.dgvOrders.ColumnHeadersDefaultCellStyle.SelectionForeColor = UITheme.TextSecondary;
            this.dgvOrders.DefaultCellStyle.BackColor          = UITheme.Surface;
            this.dgvOrders.DefaultCellStyle.ForeColor          = UITheme.TextPrimary;
            this.dgvOrders.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(224, 247, 246);
            this.dgvOrders.DefaultCellStyle.SelectionForeColor = UITheme.TextPrimary;
            this.dgvOrders.DefaultCellStyle.Padding            = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dgvOrders.RowTemplate.Height                   = 36;
            this.dgvOrders.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.dgvOrders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellDoubleClick);

            // Action bar
            this.pnlActions.BackColor = UITheme.Background;
            this.pnlActions.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Name      = "pnlActions";
            this.pnlActions.Size      = new System.Drawing.Size(760, 48);
            this.pnlActions.Controls.Add(this.btnViewOrder);
            this.pnlActions.Controls.Add(this.btnRefresh);

            this.btnViewOrder.BackColor = UITheme.Accent;
            this.btnViewOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewOrder.FlatAppearance.BorderSize = 0;
            this.btnViewOrder.Font      = UITheme.FontButton;
            this.btnViewOrder.ForeColor = System.Drawing.Color.White;
            this.btnViewOrder.Location  = new System.Drawing.Point(0, 9);
            this.btnViewOrder.Name      = "btnViewOrder";
            this.btnViewOrder.Size      = new System.Drawing.Size(160, 30);
            this.btnViewOrder.Text      = "View / Update Status";
            this.btnViewOrder.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnViewOrder.UseVisualStyleBackColor = false;
            this.btnViewOrder.Click    += new System.EventHandler(this.btnViewOrder_Click);

            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Font      = UITheme.FontButton;
            this.btnRefresh.ForeColor = UITheme.TextPrimary;
            this.btnRefresh.Location  = new System.Drawing.Point(168, 9);
            this.btnRefresh.Name      = "btnRefresh";
            this.btnRefresh.Size      = new System.Drawing.Size(90, 30);
            this.btnRefresh.Text      = "Refresh";
            this.btnRefresh.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click    += new System.EventHandler(this.btnRefresh_Click);

            // Resume
            this.pnlActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label          lblTitle;
        private System.Windows.Forms.DataGridView   dgvOrders;
        private System.Windows.Forms.Panel          pnlActions;
        private System.Windows.Forms.Button         btnViewOrder;
        private System.Windows.Forms.Button         btnRefresh;
    }
}
