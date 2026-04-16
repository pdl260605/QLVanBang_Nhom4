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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvNganhHoc = new System.Windows.Forms.DataGridView();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.lblMaNH = new System.Windows.Forms.Label();
            this.txtMaNH = new System.Windows.Forms.TextBox();
            this.lblTenNH = new System.Windows.Forms.Label();
            this.txtTenNH = new System.Windows.Forms.TextBox();
            this.lblDonViCap = new System.Windows.Forms.Label();
            this.cboDonViCap = new System.Windows.Forms.ComboBox();
            this.lblTrinhDo = new System.Windows.Forms.Label();
            this.cboTrinhDo = new System.Windows.Forms.ComboBox();
            this.lblHinhThuc = new System.Windows.Forms.Label();
            this.cboHinhThuc = new System.Windows.Forms.ComboBox();
            this.lblThoiGian = new System.Windows.Forms.Label();
            this.txtThoiGian = new System.Windows.Forms.TextBox();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNganhHoc)).BeginInit();
            this.pnlDetail.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();

            this.BackColor = UIHelper.BgPage;
            this.Name = "FrmNganhHoc"; this.Text = "Quản lý Ngành học";
            this.Load += new System.EventHandler(this.FrmNganhHoc_Load);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlTop);

            // pnlTop
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top; this.pnlTop.Height = 60;
            this.pnlTop.BackColor = UIHelper.BgPanel; this.pnlTop.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.pnlTop.Controls.Add(this.lblSoLuong);
            this.pnlTop.Controls.Add(this.txtTimKiem);
            this.pnlTop.Controls.Add(this.lblTieuDe);

            this.lblTieuDe.Text = "🎓 Quản lý Ngành học"; this.lblTieuDe.Font = UIHelper.FontTitle;
            this.lblTieuDe.ForeColor = UIHelper.TextPrimary; this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Location = new System.Drawing.Point(16, 14);

            this.txtTimKiem.Text = "🔍  Tìm theo mã ngành, tên ngành, đơn vị cấp...";
            this.txtTimKiem.Font = UIHelper.FontLabel; this.txtTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimKiem.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.txtTimKiem.Size = new System.Drawing.Size(300, 28); this.txtTimKiem.Location = new System.Drawing.Point(300, 17);
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);

            this.lblSoLuong.Text = string.Empty; this.lblSoLuong.Font = UIHelper.FontSmall;
            this.lblSoLuong.ForeColor = UIHelper.TextSecondary; this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(620, 22);

            // pnlContent
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Padding = new System.Windows.Forms.Padding(12);
            this.pnlContent.Controls.Add(this.pnlDetail);
            this.pnlContent.Controls.Add(this.dgvNganhHoc);

            this.dgvNganhHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            UIHelper.StyleDataGridView(this.dgvNganhHoc);
            this.dgvNganhHoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNganhHoc_CellClick);

            // pnlDetail
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Right; this.pnlDetail.Width = 320;
            this.pnlDetail.BackColor = UIHelper.BgPanel; this.pnlDetail.Padding = new System.Windows.Forms.Padding(16);

            int y = 16; int w = 280;
            LF(this.lblMaNH, "MÃ NGÀNH HỌC", this.txtMaNH, this.pnlDetail, ref y, w);
            LF(this.lblTenNH, "TÊN NGÀNH HỌC", this.txtTenNH, this.pnlDetail, ref y, w);

            // ComboBox DonViCap
            this.lblDonViCap.Text = "ĐƠN VỊ CẤP"; this.lblDonViCap.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold);
            this.lblDonViCap.ForeColor = UIHelper.TextSecondary; this.lblDonViCap.AutoSize = true;
            this.lblDonViCap.Location = new System.Drawing.Point(16, y); this.pnlDetail.Controls.Add(this.lblDonViCap); y += 18;
            this.cboDonViCap.Location = new System.Drawing.Point(16, y); this.cboDonViCap.Width = w;
            this.cboDonViCap.Font = UIHelper.FontLabel;
            this.pnlDetail.Controls.Add(this.cboDonViCap); y += 32;

            // Trinh do
            this.lblTrinhDo.Text = "TRÌNH ĐỘ"; this.lblTrinhDo.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold);
            this.lblTrinhDo.ForeColor = UIHelper.TextSecondary; this.lblTrinhDo.AutoSize = true;
            this.lblTrinhDo.Location = new System.Drawing.Point(16, y); this.pnlDetail.Controls.Add(this.lblTrinhDo); y += 18;
            this.cboTrinhDo.Location = new System.Drawing.Point(16, y); this.cboTrinhDo.Width = w;
            this.cboTrinhDo.Font = UIHelper.FontLabel;
            this.pnlDetail.Controls.Add(this.cboTrinhDo); y += 32;

            // Hinh thuc
            this.lblHinhThuc.Text = "HÌNH THỨC ĐÀO TẠO"; this.lblHinhThuc.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold);
            this.lblHinhThuc.ForeColor = UIHelper.TextSecondary; this.lblHinhThuc.AutoSize = true;
            this.lblHinhThuc.Location = new System.Drawing.Point(16, y); this.pnlDetail.Controls.Add(this.lblHinhThuc); y += 18;
            this.cboHinhThuc.Location = new System.Drawing.Point(16, y); this.cboHinhThuc.Width = w;
            this.cboHinhThuc.Font = UIHelper.FontLabel;
            this.pnlDetail.Controls.Add(this.cboHinhThuc); y += 32;

            LF(this.lblThoiGian, "THỜI GIAN ĐÀO TẠO", this.txtThoiGian, this.pnlDetail, ref y, w);

            this.lblThongBao.Location = new System.Drawing.Point(16, y);
            this.lblThongBao.Size = new System.Drawing.Size(w, 18);
            this.lblThongBao.Font = UIHelper.FontSmall; this.lblThongBao.Text = string.Empty;
            this.pnlDetail.Controls.Add(this.lblThongBao); y += 24;

            this.pnlButtons.Location = new System.Drawing.Point(16, y);
            this.pnlButtons.Size = new System.Drawing.Size(w, 40);
            this.pnlButtons.BackColor = UIHelper.BgPanel;
            this.pnlDetail.Controls.Add(this.pnlButtons);
            this.pnlButtons.Controls.Add(this.btnLamMoi);
            this.pnlButtons.Controls.Add(this.btnXoa);
            this.pnlButtons.Controls.Add(this.btnSua);
            this.pnlButtons.Controls.Add(this.btnThem);

            SB(this.btnThem, "Thêm", UIHelper.AccentGreen, new System.Drawing.Point(0, 0), 66);
            SB(this.btnSua, "Sửa", UIHelper.PrimaryBlue, new System.Drawing.Point(70, 0), 66);
            SB(this.btnXoa, "Xóa", UIHelper.AccentRed, new System.Drawing.Point(140, 0), 66);
            SB(this.btnLamMoi, "Mới", System.Drawing.Color.FromArgb(100, 116, 139), new System.Drawing.Point(210, 0), 66);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            this.pnlTop.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNganhHoc)).EndInit();
            this.pnlDetail.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
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