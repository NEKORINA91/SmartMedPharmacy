namespace SmartMedPharmacy.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader      = new System.Windows.Forms.Panel();
            this.lblLogoSmart   = new System.Windows.Forms.Label();
            this.lblLogoMed     = new System.Windows.Forms.Label();
            this.lblSubtitle    = new System.Windows.Forms.Label();
            this.pnlCard        = new System.Windows.Forms.Panel();
            this.lblTitle       = new System.Windows.Forms.Label();
            this.lblUsername    = new System.Windows.Forms.Label();
            this.txtUsername    = new System.Windows.Forms.TextBox();
            this.lblPassword    = new System.Windows.Forms.Label();
            this.txtPassword    = new System.Windows.Forms.TextBox();
            this.chkLoginAsAdmin = new System.Windows.Forms.CheckBox();
            this.btnLogin       = new System.Windows.Forms.Button();
            this.btnRegister    = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlCard.SuspendLayout();
            this.SuspendLayout();

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = UITheme.Background;
            this.ClientSize          = new System.Drawing.Size(400, 480);
            this.Font                = UITheme.FontBody;
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox         = false;
            this.Name                = "LoginForm";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Login - SmartMed Pharmacy";
            this.FormClosed         += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlCard);

            // ── Teal header band ─────────────────────────────────────────────────
            this.pnlHeader.BackColor = UITheme.Sidebar;
            this.pnlHeader.Location  = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name      = "pnlHeader";
            this.pnlHeader.Size      = new System.Drawing.Size(400, 120);
            this.pnlHeader.Controls.Add(this.lblLogoSmart);
            this.pnlHeader.Controls.Add(this.lblLogoMed);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            this.lblLogoSmart.AutoSize  = true;
            this.lblLogoSmart.BackColor = System.Drawing.Color.Transparent;
            this.lblLogoSmart.Font      = new System.Drawing.Font("Segoe UI", 22f, System.Drawing.FontStyle.Bold);
            this.lblLogoSmart.ForeColor = System.Drawing.Color.White;
            this.lblLogoSmart.Location  = new System.Drawing.Point(80, 28);
            this.lblLogoSmart.Name      = "lblLogoSmart";
            this.lblLogoSmart.Text      = "SMART";

            this.lblLogoMed.AutoSize    = true;
            this.lblLogoMed.BackColor   = System.Drawing.Color.Transparent;
            this.lblLogoMed.Font        = new System.Drawing.Font("Segoe UI", 22f, System.Drawing.FontStyle.Bold);
            this.lblLogoMed.ForeColor   = UITheme.Accent;
            this.lblLogoMed.Location    = new System.Drawing.Point(212, 28);
            this.lblLogoMed.Name        = "lblLogoMed";
            this.lblLogoMed.Text        = "MED";

            this.lblSubtitle.AutoSize   = true;
            this.lblSubtitle.BackColor  = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font       = UITheme.FontSmall;
            this.lblSubtitle.ForeColor  = System.Drawing.Color.FromArgb(180, 210, 220);
            this.lblSubtitle.Location   = new System.Drawing.Point(118, 72);
            this.lblSubtitle.Name       = "lblSubtitle";
            this.lblSubtitle.Text       = "Pharmacy Management System";

            // ── White card ───────────────────────────────────────────────────────
            this.pnlCard.BackColor = UITheme.Surface;
            this.pnlCard.Location  = new System.Drawing.Point(30, 140);
            this.pnlCard.Name      = "pnlCard";
            this.pnlCard.Size      = new System.Drawing.Size(340, 310);
            this.pnlCard.Controls.Add(this.lblTitle);
            this.pnlCard.Controls.Add(this.lblUsername);
            this.pnlCard.Controls.Add(this.txtUsername);
            this.pnlCard.Controls.Add(this.lblPassword);
            this.pnlCard.Controls.Add(this.txtPassword);
            this.pnlCard.Controls.Add(this.chkLoginAsAdmin);
            this.pnlCard.Controls.Add(this.btnLogin);
            this.pnlCard.Controls.Add(this.btnRegister);

            // Welcome label
            this.lblTitle.AutoSize  = true;
            this.lblTitle.Font      = UITheme.FontSubHeading;
            this.lblTitle.ForeColor = UITheme.TextPrimary;
            this.lblTitle.Location  = new System.Drawing.Point(24, 22);
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Text      = "Welcome back";

            // Username
            this.lblUsername.AutoSize  = true;
            this.lblUsername.Font      = UITheme.FontSmall;
            this.lblUsername.ForeColor = UITheme.TextSecondary;
            this.lblUsername.Location  = new System.Drawing.Point(24, 60);
            this.lblUsername.Name      = "lblUsername";
            this.lblUsername.Text      = "USERNAME";

            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font        = UITheme.FontBody;
            this.txtUsername.Location    = new System.Drawing.Point(24, 78);
            this.txtUsername.Name        = "txtUsername";
            this.txtUsername.Size        = new System.Drawing.Size(292, 23);

            // Password
            this.lblPassword.AutoSize  = true;
            this.lblPassword.Font      = UITheme.FontSmall;
            this.lblPassword.ForeColor = UITheme.TextSecondary;
            this.lblPassword.Location  = new System.Drawing.Point(24, 114);
            this.lblPassword.Name      = "lblPassword";
            this.lblPassword.Text      = "PASSWORD";

            this.txtPassword.BorderStyle          = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font                 = UITheme.FontBody;
            this.txtPassword.Location             = new System.Drawing.Point(24, 132);
            this.txtPassword.Name                 = "txtPassword";
            this.txtPassword.Size                 = new System.Drawing.Size(292, 23);
            this.txtPassword.UseSystemPasswordChar = true;

            // Admin checkbox
            this.chkLoginAsAdmin.AutoSize  = true;
            this.chkLoginAsAdmin.Font      = UITheme.FontBody;
            this.chkLoginAsAdmin.ForeColor = UITheme.TextSecondary;
            this.chkLoginAsAdmin.Location  = new System.Drawing.Point(24, 170);
            this.chkLoginAsAdmin.Name      = "chkLoginAsAdmin";
            this.chkLoginAsAdmin.Text      = "Login as Admin";
            this.chkLoginAsAdmin.UseVisualStyleBackColor = true;

            // Login button
            this.btnLogin.BackColor = UITheme.Accent;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.Font      = UITheme.FontButton;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location  = new System.Drawing.Point(24, 206);
            this.btnLogin.Name      = "btnLogin";
            this.btnLogin.Size      = new System.Drawing.Size(292, 36);
            this.btnLogin.Text      = "Login";
            this.btnLogin.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click    += new System.EventHandler(this.btnLogin_Click);

            // Register link-style button
            this.btnRegister.BackColor = System.Drawing.Color.Transparent;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.FlatAppearance.BorderSize         = 0;
            this.btnRegister.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(240, 253, 252);
            this.btnRegister.Font      = UITheme.FontSmall;
            this.btnRegister.ForeColor = UITheme.Accent;
            this.btnRegister.Location  = new System.Drawing.Point(24, 258);
            this.btnRegister.Name      = "btnRegister";
            this.btnRegister.Size      = new System.Drawing.Size(292, 24);
            this.btnRegister.Text      = "New here? Create a Customer Account";
            this.btnRegister.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click    += new System.EventHandler(this.btnRegister_Click);

            // Resume
            this.pnlHeader.ResumeLayout(false); this.pnlHeader.PerformLayout();
            this.pnlCard.ResumeLayout(false);   this.pnlCard.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel     pnlHeader;
        private System.Windows.Forms.Label     lblLogoSmart;
        private System.Windows.Forms.Label     lblLogoMed;
        private System.Windows.Forms.Label     lblSubtitle;
        private System.Windows.Forms.Panel     pnlCard;
        private System.Windows.Forms.Label     lblTitle;
        private System.Windows.Forms.Label     lblUsername;
        private System.Windows.Forms.TextBox   txtUsername;
        private System.Windows.Forms.Label     lblPassword;
        private System.Windows.Forms.TextBox   txtPassword;
        private System.Windows.Forms.CheckBox  chkLoginAsAdmin;
        private System.Windows.Forms.Button    btnLogin;
        private System.Windows.Forms.Button    btnRegister;
    }
}
