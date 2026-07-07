using System;
using System.Windows.Forms;
using SmartMedPharmacy.DAL;
using SmartMedPharmacy.Models;

namespace SmartMedPharmacy.Forms
{
    public partial class PromoDialogForm : Form
    {
        private readonly PromotionDAL _promoDal = new PromotionDAL();
        private readonly Promotion _editing;
        public bool SaveSucceeded { get; private set; } = false;

        public PromoDialogForm()
        {
            InitializeComponent();
            _editing  = null;
            this.Text = "Add Promotion";
        }

        public PromoDialogForm(Promotion promo)
        {
            InitializeComponent();
            _editing  = promo;
            this.Text = "Edit Promotion";
            PopulateFields();
        }

        private void PopulateFields()
        {
            txtCode.Text        = _editing.Code;
            txtDescription.Text = _editing.Description;
            txtMinOrder.Text    = _editing.MinOrderAmount.ToString("0.00");
            txtDiscount.Text    = _editing.DiscountAmount.ToString("0.00");
            dtpExpiry.Value     = _editing.ExpiryDate;
            chkActive.Checked   = _editing.IsActive;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            { MessageBox.Show("Promo code is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtCode.Focus(); return; }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            { MessageBox.Show("Description is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtDescription.Focus(); return; }

            if (!decimal.TryParse(txtMinOrder.Text, out decimal minOrder) || minOrder < 0)
            { MessageBox.Show("Enter a valid minimum order amount.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtMinOrder.Focus(); return; }

            if (!decimal.TryParse(txtDiscount.Text, out decimal discount) || discount <= 0)
            { MessageBox.Show("Enter a valid discount amount.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtDiscount.Focus(); return; }

            try
            {
                var promo = _editing ?? new Promotion();
                promo.Code           = txtCode.Text.Trim().ToUpper();
                promo.Description    = txtDescription.Text.Trim();
                promo.MinOrderAmount = minOrder;
                promo.DiscountAmount = discount;
                promo.ExpiryDate     = dtpExpiry.Value.Date;
                promo.IsActive       = chkActive.Checked;

                bool success = _editing == null ? _promoDal.Add(promo) : _promoDal.Update(promo);
                if (success)
                {
                    SaveSucceeded     = true;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                    MessageBox.Show("Could not save promotion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
