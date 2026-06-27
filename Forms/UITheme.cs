using System.Drawing;

namespace SmartMedPharmacy.Forms
{
    /// <summary>
    /// Central theme constants for SmartMed Pharmacy UI.
    /// Reference all colors, fonts, and sizes from here — never hardcode in Designer files.
    /// </summary>
    public static class UITheme
    {
        // ── Palette ──────────────────────────────────────────────────────────────
        public static readonly Color Sidebar        = Color.FromArgb(30,  42,  56);   // #1E2A38 deep navy
        public static readonly Color SidebarActive  = Color.FromArgb(0,  178, 169);   // #00B2A9 teal highlight
        public static readonly Color SidebarText    = Color.FromArgb(200, 215, 225);  // muted silver
        public static readonly Color SidebarTextActive = Color.White;

        public static readonly Color Background     = Color.FromArgb(245, 247, 250);  // #F5F7FA near-white
        public static readonly Color Surface        = Color.White;
        public static readonly Color Border         = Color.FromArgb(220, 228, 236);

        public static readonly Color Accent         = Color.FromArgb(0,  178, 169);   // #00B2A9 teal
        public static readonly Color AccentDark     = Color.FromArgb(0,  148, 140);
        public static readonly Color AccentText     = Color.White;

        public static readonly Color TextPrimary    = Color.FromArgb(30,  42,  56);
        public static readonly Color TextSecondary  = Color.FromArgb(100, 116, 139);
        public static readonly Color TextMuted      = Color.FromArgb(148, 163, 184);

        public static readonly Color StatusPending   = Color.FromArgb(254, 243, 199); // amber-50
        public static readonly Color StatusPendingFg = Color.FromArgb(146,  64,  14);
        public static readonly Color StatusDone      = Color.FromArgb(209, 250, 229); // green-50
        public static readonly Color StatusDoneFg    = Color.FromArgb( 6,  95,  70);
        public static readonly Color StatusShipped   = Color.FromArgb(219, 234, 254); // blue-50
        public static readonly Color StatusShippedFg = Color.FromArgb(29,  78, 216);

        public static readonly Color StatCardBg     = Color.White;
        public static readonly Color StatCardBorder = Color.FromArgb(226, 232, 240);

        // ── Typography ───────────────────────────────────────────────────────────
        public static readonly Font FontLogo        = new Font("Segoe UI", 13f, FontStyle.Bold);
        public static readonly Font FontHeading     = new Font("Segoe UI", 18f, FontStyle.Bold);
        public static readonly Font FontSubHeading  = new Font("Segoe UI", 11f, FontStyle.Bold);
        public static readonly Font FontBody        = new Font("Segoe UI",  9f, FontStyle.Regular);
        public static readonly Font FontBodyBold    = new Font("Segoe UI",  9f, FontStyle.Bold);
        public static readonly Font FontSmall       = new Font("Segoe UI",  8f, FontStyle.Regular);
        public static readonly Font FontSidebarItem = new Font("Segoe UI",  9.5f, FontStyle.Regular);
        public static readonly Font FontStat        = new Font("Segoe UI", 20f, FontStyle.Bold);
        public static readonly Font FontStatLabel   = new Font("Segoe UI",  8f, FontStyle.Regular);
        public static readonly Font FontTableHeader = new Font("Segoe UI",  8.5f, FontStyle.Bold);
        public static readonly Font FontButton      = new Font("Segoe UI",  9f, FontStyle.Bold);

        // ── Dimensions ───────────────────────────────────────────────────────────
        public const int SidebarWidth       = 200;
        public const int SidebarItemHeight  = 44;
        public const int ContentPadding     = 24;
        public const int CardRadius         = 10;
        public const int ButtonRadius       = 6;
        public const int StatCardWidth      = 145;
        public const int StatCardHeight     = 90;
    }
}
