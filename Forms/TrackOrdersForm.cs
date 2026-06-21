using System;
using System.Windows.Forms;
using SmartMedPharmacy.DAL;
using SmartMedPharmacy.Models;

namespace SmartMedPharmacy.Forms
{
    public partial class TrackOrdersForm : Form
    {
        private readonly OrderDAL _orderDal = new OrderDAL();
        private readonly Customer _currentCustomer;

        public TrackOrdersForm(Customer customer)
        {
            InitializeComponent();
            _currentCustomer = customer;
            LoadOrders();
        }

        private void LoadOrders()
        {
            try
            {
                var orders = _orderDal.GetOrdersByCustomer(_currentCustomer.Id);
                BindGrid(orders);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load your orders.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindGrid(System.Collections.Generic.List<Order> orders)
        {
            dgvOrders.DataSource = null;
            dgvOrders.DataSource = orders;

            if (dgvOrders.Columns["OrderId"] != null)
                dgvOrders.Columns["OrderId"].HeaderText = "Order #";
            if (dgvOrders.Columns["OrderDate"] != null)
                dgvOrders.Columns["OrderDate"].HeaderText = "Date";
            if (dgvOrders.Columns["Status"] != null)
                dgvOrders.Columns["Status"].HeaderText = "Status";
            if (dgvOrders.Columns["TotalAmount"] != null)
                dgvOrders.Columns["TotalAmount"].HeaderText = "Total (Rs.)";
            if (dgvOrders.Columns["CustomerId"] != null)
                dgvOrders.Columns["CustomerId"].Visible = false;
            if (dgvOrders.Columns["CustomerName"] != null)
                dgvOrders.Columns["CustomerName"].Visible = false;
            if (dgvOrders.Columns["Items"] != null)
                dgvOrders.Columns["Items"].Visible = false;
        }

        private void btnViewItems_Click(object sender, EventArgs e)
        {
            ShowSelectedOrderItems();
        }

        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ShowSelectedOrderItems();
            }
        }

        private void ShowSelectedOrderItems()
        {
            if (dgvOrders.CurrentRow == null)
            {
                MessageBox.Show("Please select an order to view.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Order selected = dgvOrders.CurrentRow.DataBoundItem as Order;
            if (selected == null) return;

            // Reuse a read-only version: build a simple summary message rather
            // than a full popup, since the customer doesn't need status-change buttons
            string itemSummary = "Order #" + selected.OrderId + " - " + selected.Status + "\n";
            itemSummary += "Placed: " + selected.OrderDate.ToString("dd MMM yyyy, hh:mm tt") + "\n\n";

            foreach (var item in selected.Items)
            {
                itemSummary += item.MedicineName + "  x" + item.Quantity +
                                "  @ Rs. " + item.UnitPrice.ToString("N2") +
                                "  = Rs. " + item.LineTotal.ToString("N2") + "\n";
            }

            itemSummary += "\nTotal: Rs. " + selected.TotalAmount.ToString("N2");

            MessageBox.Show(itemSummary, "Order Details",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }
    }
}
