namespace QLVanBang_Nhom4
{
    partial class FrmDonViCap
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
            this.dgvDonViCap = new System.Windows.Forms.DataGridView();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.lblMaDV = new System.Windows.Forms.Label();
            this.txtMaDV = new System.Windows.Forms.TextBox();
            this.lblTenDV = new System.Windows.Forms.Label();
            this.txtTenDV = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblWebsite = new System.Windows.Forms.Label();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonViCap)).BeginInit();
            this.pnlDetail.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();

            this.BackColor = UIHelper.BgPage;
            this.Name = "FrmDonViCap"; this.Text = "Quản lý Đơn vị cấp";
            this.Load += new System.EventHandler(this.FrmDonViCap_Load);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlTop);

            // pnlTop
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top; this.pnlTop.Height = 60;
            this.pnlTop.BackColor = UIHelper.BgPanel; this.pnlTop.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.pnlTop.Controls.Add(this.lblSoLuong);
            this.pnlTop.Controls.Add(this.txtTimKiem);
            this.pnlTop.Controls.Add(this.lblTieuDe);

            this.lblTieuDe.Text = "🏛 Quản lý Đơn vị cấp"; this.lblTieuDe.Font = UIHelper.FontTitle;
            this.lblTieuDe.ForeColor = UIHelper.TextPrimary; this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Location = new System.Drawing.Point(16, 14);

            this.txtTimKiem.Text = "🔍  Tìm theo mã, tên, địa chỉ...";
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
            this.pnlContent.Controls.Add(this.dgvDonViCap);

            // dgvDonViCap
            this.dgvDonViCap.Dock = System.Windows.Forms.DockStyle.Fill;
            UIHelper.StyleDataGridView(this.dgvDonViCap);
            this.dgvDonViCap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDonViCap_CellClick);

            // pnlDetail
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Right; this.pnlDetail.Width = 320;
            this.pnlDetail.BackColor = UIHelper.BgPanel; this.pnlDetail.Padding = new System.Windows.Forms.Padding(16);

            int y = 16; int w = 280;
            LayoutField(this.lblMaDV, "MÃ ĐƠN VỊ", this.txtMaDV, this.pnlDetail, ref y, w);
            LayoutField(this.lblTenDV, "TÊN ĐƠN VỊ", this.txtTenDV, this.pnlDetail, ref y, w);
            LayoutMulti(this.lblDiaChi, "ĐỊA CHỈ", this.txtDiaChi, this.pnlDetail, ref y, w);
            LayoutField(this.lblSDT, "SỐ ĐIỆN THOẠI", this.txtSDT, this.pnlDetail, ref y, w);
            LayoutField(this.lblEmail, "EMAIL", this.txtEmail, this.pnlDetail, ref y, w);
            LayoutField(this.lblWebsite, "WEBSITE", this.txtWebsite, this.pnlDetail, ref y, w);

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

            SetBtn(this.btnThem, "Thêm", UIHelper.AccentGreen, new System.Drawing.Point(0, 0), 66);
            SetBtn(this.btnSua, "Sửa", UIHelper.PrimaryBlue, new System.Drawing.Point(70, 0), 66);
            SetBtn(this.btnXoa, "Xóa", UIHelper.AccentRed, new System.Drawing.Point(140, 0), 66);
            SetBtn(this.btnLamMoi, "Mới", System.Drawing.Color.FromArgb(100, 116, 139), new System.Drawing.Point(210, 0), 66);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            this.pnlTop.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonViCap)).EndInit();
            this.pnlDetail.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private static void LayoutField(System.Windows.Forms.Label lbl, string caption,
            System.Windows.Forms.TextBox txt, System.Windows.Forms.Panel parent, ref int y, int w)
        {
            lbl.Text = caption; lbl.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold);
            lbl.ForeColor = UIHelper.TextSecondary; lbl.AutoSize = true;
            lbl.Location = new System.Drawing.Point(16, y); parent.Controls.Add(lbl); y += 18;
            txt.Location = new System.Drawing.Point(16, y); txt.Width = w; txt.Height = 28;
            txt.Font = UIHelper.FontLabel; txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txt.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            parent.Controls.Add(txt); y += 34;
        }

        private static void LayoutMulti(System.Windows.Forms.Label lbl, string caption,
            System.Windows.Forms.TextBox txt, System.Windows.Forms.Panel parent, ref int y, int w)
        {
            lbl.Text = caption; lbl.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold);
            lbl.ForeColor = UIHelper.TextSecondary; lbl.AutoSize = true;
            lbl.Location = new System.Drawing.Point(16, y); parent.Controls.Add(lbl); y += 18;
            txt.Location = new System.Drawing.Point(16, y); txt.Width = w; txt.Height = 52;
            txt.Multiline = true; txt.Font = UIHelper.FontLabel;
            txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txt.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            parent.Controls.Add(txt); y += 58;
        }

        private static void SetBtn(System.Windows.Forms.Button btn, string text, System.Drawing.Color color,
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
        private System.Windows.Forms.DataGridView dgvDonViCap;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.Label lblMaDV;
        private System.Windows.Forms.TextBox txtMaDV;
        private System.Windows.Forms.Label lblTenDV;
        private System.Windows.Forms.TextBox txtTenDV;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblWebsite;
        private System.Windows.Forms.TextBox txtWebsite;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
    }
}