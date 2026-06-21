using System;
using System.Windows.Forms;
using SmartMedPharmacy.DAL;
using SmartMedPharmacy.Models;

namespace SmartMedPharmacy.Forms
{
    public partial class OrderDetailsForm : Form
    {
        private readonly OrderDAL _orderDal = new OrderDAL();
        private Order _order;

        /// <summary>
        /// True if the status was changed, so the caller knows to refresh its list.
        /// </summary>
        public bool StatusChanged { get; private set; } = false;

        public OrderDetailsForm(Order order)
        {
            InitializeComponent();
            _order = order;
            PopulateDetails();
        }

        private void PopulateDetails()
        {
            lblOrderIdValue.Text = "#" + _order.OrderId;
            lblCustomerValue.Text = _order.CustomerName;
            lblDateValue.Text = _order.OrderDate.ToString("dd MMM yyyy, hh:mm tt");
            lblStatusValue.Text = _order.Status;
            lblTotalValue.Text = "Rs. " + _order.TotalAmount.ToString("N2");

            dgvItems.DataSource = null;
            dgvItems.DataSource = _order.Items;

            if (dgvItems.Columns["MedicineName"] != null)
                dgvItems.Columns["MedicineName"].HeaderText = "Medicine";
            if (dgvItems.Columns["Quantity"] != null)
                dgvItems.Columns["Quantity"].HeaderText = "Qty";
            if (dgvItems.Columns["UnitPrice"] != null)
                dgvItems.Columns["UnitPrice"].HeaderText = "Unit Price";
            if (dgvItems.Columns["LineTotal"] != null)
                dgvItems.Columns["LineTotal"].HeaderText = "Line Total";
            if (dgvItems.Columns["OrderItemId"] != null)
                dgvItems.Columns["OrderItemId"].Visible = false;
            if (dgvItems.Columns["OrderId"] != null)
                dgvItems.Columns["OrderId"].Visible = false;
            if (dgvItems.Columns["MedicineId"] != null)
                dgvItems.Columns["MedicineId"].Visible = false;

            UpdateButtonStates();
        }

        /// <summary>
        /// Enables/disables the status buttons based on the current status,
        /// so an admin can't skip steps or move an order backwards.
        /// </summary>
        private void UpdateButtonStates()
        {
            btnMarkReady.Enabled = (_order.Status == "Pending");
            btnMarkDelivered.Enabled = (_order.Status == "Ready for Pickup");
        }

        private void btnMarkReady_Click(object sender, EventArgs e)
        {
            UpdateStatus("Ready for Pickup");
        }

        private void btnMarkDelivered_Click(object sender, EventArgs e)
        {
            UpdateStatus("Delivered");
        }

        private void UpdateStatus(string newStatus)
        {
            try
            {
                bool success = _orderDal.UpdateStatus(_order.OrderId, newStatus);
                if (success)
                {
                    _order.Status = newStatus;
                    StatusChanged = true;
                    lblStatusValue.Text = _order.Status;
                    UpdateButtonStates();
                    MessageBox.Show("Order status updated to \"" + newStatus + "\".",
                        "Status Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Could not update the order status. Please try again.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = StatusChanged ? DialogResult.OK : DialogResult.Cancel;
            this.Close();
        }
    }
}
