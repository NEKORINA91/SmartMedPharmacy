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
            dgvOrders.CellFormatting += DgvOrders_CellFormatting;
            LoadOrders();
        }

        private void LoadOrders()
        {
            try
            {
                BindGrid(_orderDal.GetOrdersByCustomer(_currentCustomer.Id));
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

            if (dgvOrders.Columns["OrderId"] != null)       dgvOrders.Columns["OrderId"].HeaderText = "Order #";
            if (dgvOrders.Columns["OrderDate"] != null)     dgvOrders.Columns["OrderDate"].HeaderText = "Date";
            if (dgvOrders.Columns["Status"] != null)        dgvOrders.Columns["Status"].HeaderText = "Status";
            if (dgvOrders.Columns["TotalAmount"] != null)   dgvOrders.Columns["TotalAmount"].HeaderText = "Total (Rs.)";
            if (dgvOrders.Columns["CustomerId"] != null)    dgvOrders.Columns["CustomerId"].Visible = false;
            if (dgvOrders.Columns["CustomerName"] != null)  dgvOrders.Columns["CustomerName"].Visible = false;
            if (dgvOrders.Columns["Items"] != null)         dgvOrders.Columns["Items"].Visible = false;
        }

        private void btnViewItems_Click(object sender, EventArgs e)
        {
            ShowSelectedOrderDetails();
        }

        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) ShowSelectedOrderDetails();
        }

        private void ShowSelectedOrderDetails()
        {
            if (dgvOrders.CurrentRow == null)
            {
                MessageBox.Show("Please select an order to view.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Order selected = dgvOrders.CurrentRow.DataBoundItem as Order;
            if (selected == null) return;

            
            var detailsForm = new OrderDetailsForm(selected, isAdmin: false);
            detailsForm.ShowDialog(this);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void DgvOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvOrders.Columns["Status"] == null) return;
            if (e.ColumnIndex != dgvOrders.Columns["Status"].Index || e.Value == null) return;

            switch (e.Value.ToString().ToLower())
            {
                case "pending":
                    e.CellStyle.BackColor = UITheme.StatusPending;
                    e.CellStyle.ForeColor = UITheme.StatusPendingFg;
                    break;
                case "completed":
                case "delivered":
                    e.CellStyle.BackColor = UITheme.StatusDone;
                    e.CellStyle.ForeColor = UITheme.StatusDoneFg;
                    break;
                case "shipped":
                case "ready for pickup":
                    e.CellStyle.BackColor = UITheme.StatusShipped;
                    e.CellStyle.ForeColor = UITheme.StatusShippedFg;
                    break;
            }
            e.CellStyle.Font      = UITheme.FontSmall;
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

      
    }
}
