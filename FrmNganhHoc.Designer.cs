namespace QLVanBang_Nhom4
{
    partial class FrmNganhHoc
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FrmNganhHoc
            // 
            this.ClientSize = new System.Drawing.Size(847, 493);
            this.Name = "FrmNganhHoc";
            this.ResumeLayout(false);

        }

        private static void LF(System.Windows.Forms.Label lbl, string caption, System.Windows.Forms.TextBox txt,
            System.Windows.Forms.Panel p, ref int y, int w)
        {
            lbl.Text = caption; lbl.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold);
            lbl.ForeColor = UIHelper.TextSecondary; lbl.AutoSize = true;
            lbl.Location = new System.Drawing.Point(16, y); p.Controls.Add(lbl); y += 18;
            txt.Location = new System.Drawing.Point(16, y); txt.Width = w; txt.Height = 28;
            txt.Font = UIHelper.FontLabel; txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txt.BackColor = System.Drawing.Color.FromArgb(248, 250, 252); p.Controls.Add(txt); y += 34;
        }

        private static void SB(System.Windows.Forms.Button btn, string text, System.Drawing.Color color,
            System.Drawing.Point loc, int width)
        {
            btn.Text = text; btn.Font = UIHelper.FontButton; btn.BackColor = color;
            btn.ForeColor = System.Drawing.Color.White; btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0; btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.Location = loc; btn.Size = new System.Drawing.Size(width, 36);
        }
        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvNganhHoc;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.Label lblMaNH;
        private System.Windows.Forms.TextBox txtMaNH;
        private System.Windows.Forms.Label lblTenNH;
        private System.Windows.Forms.TextBox txtTenNH;
        private System.Windows.Forms.Label lblDonViCap;
        private System.Windows.Forms.ComboBox cboDonViCap;
        private System.Windows.Forms.Label lblTrinhDo;
        private System.Windows.Forms.ComboBox cboTrinhDo;
        private System.Windows.Forms.Label lblHinhThuc;
        private System.Windows.Forms.ComboBox cboHinhThuc;
        private System.Windows.Forms.Label lblThoiGian;
        private System.Windows.Forms.TextBox txtThoiGian;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
    }

}