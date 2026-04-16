using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVanBang_Nhom4
{
    /// <summary>
    /// Lớp tiện ích định nghĩa màu sắc, font chữ và hàm hỗ trợ giao diện chung.
    /// </summary>
    public static class UIHelper
    {
        // ── Bảng màu chính ─────────────────────────────────────────────
        public static readonly Color PrimaryBlue = Color.FromArgb(26, 115, 232);
        public static readonly Color PrimaryDark = Color.FromArgb(10, 76, 162);
        public static readonly Color AccentGreen = Color.FromArgb(52, 168, 83);
        public static readonly Color AccentRed = Color.FromArgb(234, 67, 53);
        public static readonly Color AccentOrange = Color.FromArgb(251, 188, 5);
        public static readonly Color BgPage = Color.FromArgb(245, 247, 250);
        public static readonly Color BgPanel = Color.White;
        public static readonly Color BgSidebar = Color.FromArgb(30, 41, 59);
        public static readonly Color SidebarHover = Color.FromArgb(51, 65, 85);
        public static readonly Color SidebarActive = Color.FromArgb(26, 115, 232);
        public static readonly Color TextPrimary = Color.FromArgb(30, 41, 59);
        public static readonly Color TextSecondary = Color.FromArgb(100, 116, 139);
        public static readonly Color BorderColor = Color.FromArgb(226, 232, 240);

        // ── Font ────────────────────────────────────────────────────────
        public static readonly Font FontTitle = new Font("Segoe UI", 18f, FontStyle.Bold);
        public static readonly Font FontSubtitle = new Font("Segoe UI", 11f, FontStyle.Regular);
        public static readonly Font FontLabel = new Font("Segoe UI", 9f, FontStyle.Regular);
        public static readonly Font FontBold = new Font("Segoe UI", 9f, FontStyle.Bold);
        public static readonly Font FontButton = new Font("Segoe UI", 9f, FontStyle.Bold);
        public static readonly Font FontSmall = new Font("Segoe UI", 8f, FontStyle.Regular);

        // ── Áp dụng style cho DataGridView ─────────────────────────────
        public static void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = BgPanel;
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = BorderColor;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.EnableHeadersVisualStyles = false;

            // Header style
            dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryBlue;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = FontBold;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Row style
            dgv.DefaultCellStyle.Font = FontLabel;
            dgv.DefaultCellStyle.ForeColor = TextPrimary;
            dgv.DefaultCellStyle.BackColor = BgPanel;
            dgv.DefaultCellStyle.Padding = new Padding(6, 0, 0, 0);
            dgv.RowTemplate.Height = 36;

            // Alternate row
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);

            // Selection
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgv.DefaultCellStyle.SelectionForeColor = TextPrimary;
        }

        // ── Tạo nút bấm đẹp ────────────────────────────────────────────
        public static Button CreateButton(string text, Color backColor, Color foreColor = default)
        {
            if (foreColor == default) foreColor = Color.White;
            var btn = new Button
            {
                Text = text,
                Font = FontButton,
                BackColor = backColor,
                ForeColor = foreColor,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Height = 36,
                Padding = new Padding(0)
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        // ── Áp dụng style cho TextBox ───────────────────────────────────
        public static void StyleTextBox(TextBox txt)
        {
            txt.Font = FontLabel;
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor = BgPanel;
            txt.ForeColor = TextPrimary;
            txt.Height = 28;
        }

        // ── Tạo Label nhãn trường ───────────────────────────────────────
        public static Label CreateLabel(string text)
        {
            return new Label
            {
                Text = text,
                Font = FontLabel,
                ForeColor = TextSecondary,
                AutoSize = true
            };
        }
    }
}
