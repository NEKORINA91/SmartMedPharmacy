using System;
using System.Windows.Forms;
using SmartMedPharmacy.DAL;
using SmartMedPharmacy.Models;

namespace SmartMedPharmacy.Forms
{
    public partial class ManageOrdersForm : Form
    {
        private readonly OrderDAL _orderDal = new OrderDAL();

        public ManageOrdersForm()
        {
            InitializeComponent();
            LoadOrders();
        }

        private void LoadOrders()
        {
            try
            {
                var orders = _orderDal.GetAllOrders();
                BindGrid(orders);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load orders.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindGrid(System.Collections.Generic.List<Order> orders)
        {
            dgvOrders.DataSource = null;
            dgvOrders.DataSource = orders;

            if (dgvOrders.Columns["OrderId"] != null)
                dgvOrders.Columns["OrderId"].HeaderText = "Order #";
            if (dgvOrders.Columns["CustomerName"] != null)
                dgvOrders.Columns["CustomerName"].HeaderText = "Customer";
            if (dgvOrders.Columns["OrderDate"] != null)
                dgvOrders.Columns["OrderDate"].HeaderText = "Date";
            if (dgvOrders.Columns["Status"] != null)
                dgvOrders.Columns["Status"].HeaderText = "Status";
            if (dgvOrders.Columns["TotalAmount"] != null)
                dgvOrders.Columns["TotalAmount"].HeaderText = "Total (Rs.)";
            if (dgvOrders.Columns["CustomerId"] != null)
                dgvOrders.Columns["CustomerId"].Visible = false;
            if (dgvOrders.Columns["Items"] != null)
                dgvOrders.Columns["Items"].Visible = false;
        }

        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            OpenSelectedOrder();
        }

        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                OpenSelectedOrder();
            }
        }

        private void OpenSelectedOrder()
        {
            Order selected = GetSelectedOrder();
            if (selected == null)
            {
                MessageBox.Show("Please select an order to view.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            OrderDetailsForm dialog = new OrderDetailsForm(selected);
            dialog.ShowDialog();

            if (dialog.StatusChanged)
            {
                LoadOrders();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private Order GetSelectedOrder()
        {
            if (dgvOrders.CurrentRow == null)
                return null;

            return dgvOrders.CurrentRow.DataBoundItem as Order;
        }
    }
}
