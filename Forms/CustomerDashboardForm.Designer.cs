namespace SmartMedPharmacy.Forms
{
    partial class CustomerDashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlSidebar       = new System.Windows.Forms.Panel();
            this.pnlLogoArea      = new System.Windows.Forms.Panel();
            this.lblLogoSmart     = new System.Windows.Forms.Label();
            this.lblLogoMed       = new System.Windows.Forms.Label();
            this.btnHome          = new System.Windows.Forms.Button();
            this.btnMyOrders      = new System.Windows.Forms.Button();
            this.btnSearchMedicines = new System.Windows.Forms.Button();
            this.btnProfile       = new System.Windows.Forms.Button();
            this.btnLogout        = new System.Windows.Forms.Button();
            this.pnlLogout        = new System.Windows.Forms.Panel();
            this.panelContent     = new System.Windows.Forms.Panel();
            this.panelHome        = new System.Windows.Forms.Panel();
            this.lblWelcome       = new System.Windows.Forms.Label();
            this.lblQuickActions  = new System.Windows.Forms.Label();
            this.pnlCards         = new System.Windows.Forms.Panel();
            this.cardBrowse       = new System.Windows.Forms.Panel();
            this.lblBrowseIcon    = new System.Windows.Forms.Label();
            this.lblBrowseTitle   = new System.Windows.Forms.Label();
            this.btnFindNow       = new System.Windows.Forms.Button();
            this.cardTrack        = new System.Windows.Forms.Panel();
            this.lblTrackIcon     = new System.Windows.Forms.Label();
            this.lblTrackTitle    = new System.Windows.Forms.Label();
            this.lblActiveCount   = new System.Windows.Forms.Label();
            this.cardHistory      = new System.Windows.Forms.Panel();
            this.lblHistoryIcon   = new System.Windows.Forms.Label();
            this.lblHistoryTitle  = new System.Windows.Forms.Label();
            this.lblRecentPurchases = new System.Windows.Forms.Label();
            this.dgvOrders        = new System.Windows.Forms.DataGridView();
            this.colOrderID       = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate          = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus        = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlLogout.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlLogoArea.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelHome.SuspendLayout();
            this.pnlCards.SuspendLayout();
            this.cardBrowse.SuspendLayout();
            this.cardTrack.SuspendLayout();
            this.cardHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = UITheme.Background;
            this.ClientSize          = new System.Drawing.Size(960, 660);
            this.Font                = UITheme.FontBody;
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize         = new System.Drawing.Size(800, 560);
            this.Name                = "CustomerDashboardForm";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "SmartMed Customer Dashboard";
            this.FormClosed         += new System.Windows.Forms.FormClosedEventHandler(this.CustomerDashboardForm_FormClosed);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.pnlSidebar);

            // Sidebar
            this.pnlSidebar.BackColor = UITheme.Sidebar;
            this.pnlSidebar.Dock      = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Name      = "pnlSidebar";
            this.pnlSidebar.Width     = UITheme.SidebarWidth;
            this.pnlSidebar.Controls.Add(this.pnlLogoArea);
            this.pnlSidebar.Controls.Add(this.btnHome);
            this.pnlSidebar.Controls.Add(this.btnMyOrders);
            this.pnlSidebar.Controls.Add(this.btnSearchMedicines);
            this.pnlSidebar.Controls.Add(this.btnProfile);
            this.pnlSidebar.Controls.Add(this.pnlLogout);

            this.pnlLogoArea.BackColor = UITheme.Sidebar;
            this.pnlLogoArea.Location  = new System.Drawing.Point(0, 0);
            this.pnlLogoArea.Name      = "pnlLogoArea";
            this.pnlLogoArea.Size      = new System.Drawing.Size(UITheme.SidebarWidth, 72);
            this.pnlLogoArea.Controls.Add(this.lblLogoSmart);
            this.pnlLogoArea.Controls.Add(this.lblLogoMed);

            this.lblLogoSmart.AutoSize  = true;
            this.lblLogoSmart.BackColor = System.Drawing.Color.Transparent;
            this.lblLogoSmart.Font      = UITheme.FontLogo;
            this.lblLogoSmart.ForeColor = System.Drawing.Color.White;
            this.lblLogoSmart.Location  = new System.Drawing.Point(16, 22);
            this.lblLogoSmart.Name      = "lblLogoSmart";
            this.lblLogoSmart.Text      = "SMART";

            this.lblLogoMed.AutoSize    = true;
            this.lblLogoMed.BackColor   = System.Drawing.Color.Transparent;
            this.lblLogoMed.Font        = UITheme.FontLogo;
            this.lblLogoMed.ForeColor   = UITheme.Accent;
            this.lblLogoMed.Location    = new System.Drawing.Point(86, 22);
            this.lblLogoMed.Name        = "lblLogoMed";
            this.lblLogoMed.Text        = "MED";

            System.Action<System.Windows.Forms.Button, string, int, bool> nav =
                (btn, text, top, active) =>
                {
                    btn.BackColor = active ? UITheme.SidebarActive : UITheme.Sidebar;
                    btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize         = 0;
                    btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(45, 58, 74);
                    btn.FlatAppearance.MouseDownBackColor = UITheme.AccentDark;
                    btn.Font      = UITheme.FontSidebarItem;
                    btn.ForeColor = active ? System.Drawing.Color.White : UITheme.SidebarText;
                    btn.Location  = new System.Drawing.Point(0, top);
                    btn.Size      = new System.Drawing.Size(UITheme.SidebarWidth, UITheme.SidebarItemHeight);
                    btn.TabStop   = false;
                    btn.Text      = "   " + text;
                    btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    btn.Cursor    = System.Windows.Forms.Cursors.Hand;
                    btn.UseVisualStyleBackColor = false;
                };

            this.btnHome.Name = "btnHome";
            nav(this.btnHome, "Dashboard", 80, true);
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);

            this.btnMyOrders.Name = "btnMyOrders";
            nav(this.btnMyOrders, "My Orders", 124, false);
            this.btnMyOrders.Click += new System.EventHandler(this.btnMyOrders_Click);

            this.btnSearchMedicines.Name = "btnSearchMedicines";
            nav(this.btnSearchMedicines, "Search Medicines", 168, false);
            this.btnSearchMedicines.Click += new System.EventHandler(this.btnSearchMedicines_Click);

            this.btnProfile.Name = "btnProfile";
            nav(this.btnProfile, "My Profile", 212, false);
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);

            // pnlLogout — docked to bottom of sidebar so it always shows
            this.pnlLogout.BackColor = UITheme.Sidebar;
            this.pnlLogout.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLogout.Name      = "pnlLogout";
            this.pnlLogout.Size      = new System.Drawing.Size(UITheme.SidebarWidth, UITheme.SidebarItemHeight);
            this.pnlLogout.Controls.Add(this.btnLogout);

            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize         = 0;
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(45, 58, 74);
            this.btnLogout.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.btnLogout.Font      = UITheme.FontSidebarItem;
            this.btnLogout.ForeColor = UITheme.SidebarText;
            this.btnLogout.Name      = "btnLogout";
            this.btnLogout.TabStop   = false;
            this.btnLogout.Text      = "   Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // panelContent
            this.panelContent.BackColor = UITheme.Background;
            this.panelContent.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Name      = "panelContent";
            this.panelContent.Controls.Add(this.panelHome);

            // panelHome
            this.panelHome.BackColor = UITheme.Background;
            this.panelHome.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.panelHome.Name      = "panelHome";
            this.panelHome.Padding   = new System.Windows.Forms.Padding(UITheme.ContentPadding);
            this.panelHome.Controls.Add(this.lblWelcome);
            this.panelHome.Controls.Add(this.lblQuickActions);
            this.panelHome.Controls.Add(this.pnlCards);
            this.panelHome.Controls.Add(this.lblRecentPurchases);
            this.panelHome.Controls.Add(this.dgvOrders);

            this.lblWelcome.AutoSize  = true;
            this.lblWelcome.Font      = UITheme.FontHeading;
            this.lblWelcome.ForeColor = UITheme.Accent;
            this.lblWelcome.Location  = new System.Drawing.Point(UITheme.ContentPadding, UITheme.ContentPadding);
            this.lblWelcome.Name      = "lblWelcome";
            this.lblWelcome.Text      = "Welcome, ";

            this.lblQuickActions.AutoSize  = true;
            this.lblQuickActions.Font      = UITheme.FontSubHeading;
            this.lblQuickActions.ForeColor = UITheme.TextPrimary;
            this.lblQuickActions.Location  = new System.Drawing.Point(UITheme.ContentPadding, 68);
            this.lblQuickActions.Name      = "lblQuickActions";
            this.lblQuickActions.Text      = "Quick Action Cards";

            // Cards row
            this.pnlCards.BackColor = System.Drawing.Color.Transparent;
            this.pnlCards.Location  = new System.Drawing.Point(UITheme.ContentPadding, 94);
            this.pnlCards.Name      = "pnlCards";
            this.pnlCards.Size      = new System.Drawing.Size(660, 148);
            this.pnlCards.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.pnlCards.Controls.Add(this.cardBrowse);
            this.pnlCards.Controls.Add(this.cardTrack);
            this.pnlCards.Controls.Add(this.cardHistory);

            System.Action<System.Windows.Forms.Panel, int> placeCard =
                (card, col) =>
                {
                    card.BackColor   = UITheme.StatCardBg;
                    card.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    card.Location    = new System.Drawing.Point(col * 214, 0);
                    card.Size        = new System.Drawing.Size(200, 148);
                };

            placeCard(this.cardBrowse,  0);
            placeCard(this.cardTrack,   1);
            placeCard(this.cardHistory, 2);

            // Browse card
            this.cardBrowse.Name = "cardBrowse";
            this.cardBrowse.Controls.Add(this.lblBrowseIcon);
            this.cardBrowse.Controls.Add(this.lblBrowseTitle);
            this.cardBrowse.Controls.Add(this.btnFindNow);

            this.lblBrowseIcon.AutoSize  = false;
            this.lblBrowseIcon.Font      = new System.Drawing.Font("Segoe UI", 26f);
            this.lblBrowseIcon.ForeColor = UITheme.Accent;
            this.lblBrowseIcon.Location  = new System.Drawing.Point(0, 10);
            this.lblBrowseIcon.Name      = "lblBrowseIcon";
            this.lblBrowseIcon.Size      = new System.Drawing.Size(200, 44);
            this.lblBrowseIcon.Text      = "💊";
            this.lblBrowseIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblBrowseTitle.AutoSize  = false;
            this.lblBrowseTitle.Font      = UITheme.FontBodyBold;
            this.lblBrowseTitle.ForeColor = UITheme.TextPrimary;
            this.lblBrowseTitle.Location  = new System.Drawing.Point(0, 58);
            this.lblBrowseTitle.Name      = "lblBrowseTitle";
            this.lblBrowseTitle.Size      = new System.Drawing.Size(200, 36);
            this.lblBrowseTitle.Text      = "Browse Medicines";
            this.lblBrowseTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.btnFindNow.BackColor             = UITheme.Accent;
            this.btnFindNow.FlatStyle             = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindNow.FlatAppearance.BorderSize         = 0;
            this.btnFindNow.FlatAppearance.MouseOverBackColor = UITheme.AccentDark;
            this.btnFindNow.Font                  = UITheme.FontButton;
            this.btnFindNow.ForeColor             = System.Drawing.Color.White;
            this.btnFindNow.Location              = new System.Drawing.Point(24, 106);
            this.btnFindNow.Name                  = "btnFindNow";
            this.btnFindNow.Size                  = new System.Drawing.Size(152, 30);
            this.btnFindNow.TabIndex              = 0;
            this.btnFindNow.Text                  = "Find Now";
            this.btnFindNow.Cursor                = System.Windows.Forms.Cursors.Hand;
            this.btnFindNow.UseVisualStyleBackColor = false;
            this.btnFindNow.Click += new System.EventHandler(this.btnSearchMedicines_Click);

            // Track card
            this.cardTrack.Name = "cardTrack";
            this.cardTrack.Controls.Add(this.lblTrackIcon);
            this.cardTrack.Controls.Add(this.lblTrackTitle);
            this.cardTrack.Controls.Add(this.lblActiveCount);

            this.lblTrackIcon.AutoSize  = false;
            this.lblTrackIcon.Font      = new System.Drawing.Font("Segoe UI", 26f);
            this.lblTrackIcon.ForeColor = UITheme.Accent;
            this.lblTrackIcon.Location  = new System.Drawing.Point(0, 10);
            this.lblTrackIcon.Name      = "lblTrackIcon";
            this.lblTrackIcon.Size      = new System.Drawing.Size(200, 44);
            this.lblTrackIcon.Text      = "🚚";
            this.lblTrackIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblTrackTitle.AutoSize  = false;
            this.lblTrackTitle.Font      = UITheme.FontBodyBold;
            this.lblTrackTitle.ForeColor = UITheme.TextPrimary;
            this.lblTrackTitle.Location  = new System.Drawing.Point(0, 58);
            this.lblTrackTitle.Name      = "lblTrackTitle";
            this.lblTrackTitle.Size      = new System.Drawing.Size(200, 36);
            this.lblTrackTitle.Text      = "Track Active Orders";
            this.lblTrackTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblActiveCount.AutoSize  = false;
            this.lblActiveCount.Font      = UITheme.FontSmall;
            this.lblActiveCount.ForeColor = UITheme.TextSecondary;
            this.lblActiveCount.Location  = new System.Drawing.Point(0, 106);
            this.lblActiveCount.Name      = "lblActiveCount";
            this.lblActiveCount.Size      = new System.Drawing.Size(200, 24);
            this.lblActiveCount.Text      = "0 Active";
            this.lblActiveCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // History card
            this.cardHistory.Name = "cardHistory";
            this.cardHistory.Controls.Add(this.lblHistoryIcon);
            this.cardHistory.Controls.Add(this.lblHistoryTitle);

            this.lblHistoryIcon.AutoSize  = false;
            this.lblHistoryIcon.Font      = new System.Drawing.Font("Segoe UI", 26f);
            this.lblHistoryIcon.ForeColor = UITheme.Accent;
            this.lblHistoryIcon.Location  = new System.Drawing.Point(0, 10);
            this.lblHistoryIcon.Name      = "lblHistoryIcon";
            this.lblHistoryIcon.Size      = new System.Drawing.Size(200, 44);
            this.lblHistoryIcon.Text      = "📁";
            this.lblHistoryIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblHistoryTitle.AutoSize  = false;
            this.lblHistoryTitle.Font      = UITheme.FontBodyBold;
            this.lblHistoryTitle.ForeColor = UITheme.TextPrimary;
            this.lblHistoryTitle.Location  = new System.Drawing.Point(0, 58);
            this.lblHistoryTitle.Name      = "lblHistoryTitle";
            this.lblHistoryTitle.Size      = new System.Drawing.Size(200, 36);
            this.lblHistoryTitle.Text      = "Order History";
            this.lblHistoryTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Recent Purchases label
            this.lblRecentPurchases.AutoSize  = true;
            this.lblRecentPurchases.Font      = UITheme.FontSubHeading;
            this.lblRecentPurchases.ForeColor = UITheme.TextPrimary;
            this.lblRecentPurchases.Location  = new System.Drawing.Point(UITheme.ContentPadding, 260);
            this.lblRecentPurchases.Name      = "lblRecentPurchases";
            this.lblRecentPurchases.Text      = "Your Recent Purchases";

            // dgvOrders
            this.dgvOrders.AllowUserToAddRows    = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AllowUserToResizeRows = false;
            this.dgvOrders.ReadOnly              = true;
            this.dgvOrders.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.MultiSelect           = false;
            this.dgvOrders.RowHeadersVisible     = false;
            this.dgvOrders.BorderStyle           = System.Windows.Forms.BorderStyle.None;
            this.dgvOrders.CellBorderStyle       = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvOrders.BackgroundColor       = UITheme.Surface;
            this.dgvOrders.GridColor             = UITheme.Border;
            this.dgvOrders.Font                  = UITheme.FontBody;
            this.dgvOrders.Location              = new System.Drawing.Point(UITheme.ContentPadding, 288);
            this.dgvOrders.Name                  = "dgvOrders";
            this.dgvOrders.Size                  = new System.Drawing.Size(660, 300);
            this.dgvOrders.Anchor                = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom;
            this.dgvOrders.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.EnableHeadersVisualStyles   = false;

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
            this.dgvOrders.RowTemplate.Height                  = 36;
            this.dgvOrders.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);

            this.colOrderID.HeaderText = "Order ID"; this.colOrderID.DataPropertyName = "OrderID"; this.colOrderID.FillWeight = 80; this.colOrderID.Name = "colOrderID";
            this.colDate.HeaderText = "Date"; this.colDate.DataPropertyName = "OrderDate"; this.colDate.FillWeight = 200; this.colDate.Name = "colDate";
            this.colStatus.HeaderText = "Status"; this.colStatus.DataPropertyName = "Status"; this.colStatus.FillWeight = 120; this.colStatus.Name = "colStatus";
            this.dgvOrders.Columns.AddRange(this.colOrderID, this.colDate, this.colStatus);

            this.cardBrowse.ResumeLayout(false);   this.cardBrowse.PerformLayout();
            this.cardTrack.ResumeLayout(false);    this.cardTrack.PerformLayout();
            this.cardHistory.ResumeLayout(false);  this.cardHistory.PerformLayout();
            this.pnlCards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.panelHome.ResumeLayout(false);    this.panelHome.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.pnlLogoArea.ResumeLayout(false);  this.pnlLogoArea.PerformLayout();
            this.pnlLogout.ResumeLayout(false);
            this.pnlSidebar.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel          pnlSidebar;
        private System.Windows.Forms.Panel          pnlLogoArea;
        private System.Windows.Forms.Label          lblLogoSmart;
        private System.Windows.Forms.Label          lblLogoMed;
        private System.Windows.Forms.Button         btnHome;
        private System.Windows.Forms.Button         btnMyOrders;
        private System.Windows.Forms.Button         btnSearchMedicines;
        private System.Windows.Forms.Button         btnProfile;
        private System.Windows.Forms.Button         btnLogout;
        private System.Windows.Forms.Panel          pnlLogout;
        private System.Windows.Forms.Panel          panelContent;
        private System.Windows.Forms.Panel          panelHome;
        private System.Windows.Forms.Label          lblWelcome;
        private System.Windows.Forms.Label          lblQuickActions;
        private System.Windows.Forms.Panel          pnlCards;
        private System.Windows.Forms.Panel          cardBrowse;
        private System.Windows.Forms.Label          lblBrowseIcon;
        private System.Windows.Forms.Label          lblBrowseTitle;
        private System.Windows.Forms.Button         btnFindNow;
        private System.Windows.Forms.Panel          cardTrack;
        private System.Windows.Forms.Label          lblTrackIcon;
        private System.Windows.Forms.Label          lblTrackTitle;
        private System.Windows.Forms.Label          lblActiveCount;
        private System.Windows.Forms.Panel          cardHistory;
        private System.Windows.Forms.Label          lblHistoryIcon;
        private System.Windows.Forms.Label          lblHistoryTitle;
        private System.Windows.Forms.Label          lblRecentPurchases;
        private System.Windows.Forms.DataGridView   dgvOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}
