namespace QLVanBang_Nhom4
{
    partial class FrmVanBang
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
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvVanBang = new System.Windows.Forms.DataGridView();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.lblSoHieuVB = new System.Windows.Forms.Label();
            this.txtSoHieuVB = new System.Windows.Forms.TextBox();
            this.lblSinhVien = new System.Windows.Forms.Label();
            this.cboSinhVien = new System.Windows.Forms.ComboBox();
            this.lblNganhHoc = new System.Windows.Forms.Label();
            this.cboNganhHoc = new System.Windows.Forms.ComboBox();
            this.lblTenVB = new System.Windows.Forms.Label();
            this.txtTenVB = new System.Windows.Forms.TextBox();
            this.lblXepLoai = new System.Windows.Forms.Label();
            this.cboXepLoai = new System.Windows.Forms.ComboBox();
            this.lblCapDo = new System.Windows.Forms.Label();
            this.cboCapDo = new System.Windows.Forms.ComboBox();
            this.lblNgayCap = new System.Windows.Forms.Label();
            this.dtpNgayCap = new System.Windows.Forms.DateTimePicker();
            this.lblDonViCap = new System.Windows.Forms.Label();
            this.cboDonViCap = new System.Windows.Forms.ComboBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVanBang)).BeginInit();
            this.pnlDetail.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();

            // Form
            this.BackColor = UIHelper.BgPage;
            this.Name = "FrmVanBang";
            this.Text = "Quản lý Văn bằng";
            this.Load += new System.EventHandler(this.FrmVanBang_Load);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlTop);

            // pnlTop
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 60;
            this.pnlTop.BackColor = UIHelper.BgPanel;
            this.pnlTop.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.pnlTop.Controls.Add(this.lblSoLuong);
            this.pnlTop.Controls.Add(this.cboLocTrangThai);
            this.pnlTop.Controls.Add(this.txtTimKiem);
            this.pnlTop.Controls.Add(this.lblTieuDe);

            this.lblTieuDe.Text = "📋 Quản lý Văn bằng"; this.lblTieuDe.Font = UIHelper.FontTitle;
            this.lblTieuDe.ForeColor = UIHelper.TextPrimary; this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Location = new System.Drawing.Point(16, 14);

            this.txtTimKiem.Text = "🔍  Tìm theo số hiệu, sinh viên, tên văn bằng...";
            this.txtTimKiem.Font = UIHelper.FontLabel; this.txtTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimKiem.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.txtTimKiem.Size = new System.Drawing.Size(300, 28); this.txtTimKiem.Location = new System.Drawing.Point(300, 17);
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);

            this.cboLocTrangThai.Font = UIHelper.FontLabel; this.cboLocTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTrangThai.Size = new System.Drawing.Size(140, 28); this.cboLocTrangThai.Location = new System.Drawing.Point(612, 16);
            this.cboLocTrangThai.SelectedIndexChanged += new System.EventHandler(this.cboLocTrangThai_SelectedIndexChanged);

            this.lblSoLuong.Text = string.Empty; this.lblSoLuong.Font = UIHelper.FontSmall;
            this.lblSoLuong.ForeColor = UIHelper.TextSecondary; this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(770, 22);

            // pnlContent
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Padding = new System.Windows.Forms.Padding(12);
            this.pnlContent.Controls.Add(this.pnlDetail);
            this.pnlContent.Controls.Add(this.dgvVanBang);

            // dgvVanBang
            this.dgvVanBang.Dock = System.Windows.Forms.DockStyle.Fill;
            UIHelper.StyleDataGridView(this.dgvVanBang);
            this.dgvVanBang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVanBang_CellClick);

            // pnlDetail
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDetail.Width = 320; this.pnlDetail.BackColor = UIHelper.BgPanel;
            this.pnlDetail.Padding = new System.Windows.Forms.Padding(16);

            int y = 16; int w = 280;
            AddLbl(this.lblSoHieuVB, "SỐ HIỆU VĂN BẰNG", this.pnlDetail, ref y);
            AddTxt(this.txtSoHieuVB, this.pnlDetail, ref y, w);
            AddLbl(this.lblSinhVien, "SINH VIÊN", this.pnlDetail, ref y);
            AddCbo(this.cboSinhVien, this.pnlDetail, ref y, w);
            AddLbl(this.lblNganhHoc, "NGÀNH HỌC", this.pnlDetail, ref y);
            AddCbo(this.cboNganhHoc, this.pnlDetail, ref y, w);
            AddLbl(this.lblTenVB, "TÊN VĂN BẰNG", this.pnlDetail, ref y);
            AddTxt(this.txtTenVB, this.pnlDetail, ref y, w, multi: true);
            AddLbl(this.lblXepLoai, "XẾP LOẠI", this.pnlDetail, ref y);
            AddCbo(this.cboXepLoai, this.pnlDetail, ref y, w);
            AddLbl(this.lblCapDo, "CẤP ĐỘ", this.pnlDetail, ref y);
            AddCbo(this.cboCapDo, this.pnlDetail, ref y, w);
            AddLbl(this.lblNgayCap, "NGÀY CẤP", this.pnlDetail, ref y);
            this.dtpNgayCap.Location = new System.Drawing.Point(16, y); this.dtpNgayCap.Width = w;
            this.dtpNgayCap.Format = System.Windows.Forms.DateTimePickerFormat.Short; this.dtpNgayCap.Font = UIHelper.FontLabel;
            this.pnlDetail.Controls.Add(this.dtpNgayCap); y += 32;
            AddLbl(this.lblDonViCap, "ĐƠN VỊ CẤP", this.pnlDetail, ref y);
            AddCbo(this.cboDonViCap, this.pnlDetail, ref y, w);
            AddLbl(this.lblTrangThai, "TRẠNG THÁI", this.pnlDetail, ref y);
            AddCbo(this.cboTrangThai, this.pnlDetail, ref y, w);

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

            int bw = 66;
            SetBtn(this.btnThem, "Thêm", UIHelper.AccentGreen, new System.Drawing.Point(0, 0), bw);
            SetBtn(this.btnSua, "Sửa", UIHelper.PrimaryBlue, new System.Drawing.Point(70, 0), bw);
            SetBtn(this.btnXoa, "Xóa", UIHelper.AccentRed, new System.Drawing.Point(140, 0), bw);
            SetBtn(this.btnLamMoi, "Mới", System.Drawing.Color.FromArgb(100, 116, 139), new System.Drawing.Point(210, 0), bw);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            this.pnlTop.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVanBang)).EndInit();
            this.pnlDetail.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private static void AddLbl(System.Windows.Forms.Label lbl, string caption,
                                    System.Windows.Forms.Panel parent, ref int y)
        {
            lbl.Text = caption; lbl.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold);
            lbl.ForeColor = UIHelper.TextSecondary; lbl.AutoSize = true;
            lbl.Location = new System.Drawing.Point(16, y); parent.Controls.Add(lbl); y += 18;
        }

        private static void AddTxt(System.Windows.Forms.TextBox txt, System.Windows.Forms.Panel parent,
                                    ref int y, int w, bool multi = false)
        {
            txt.Location = new System.Drawing.Point(16, y); txt.Width = w;
            txt.Font = UIHelper.FontLabel; txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txt.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            if (multi) { txt.Multiline = true; txt.Height = 50; y += 56; }
            else { txt.Height = 28; y += 34; }
            parent.Controls.Add(txt);
        }

        private static void AddCbo(System.Windows.Forms.ComboBox cbo, System.Windows.Forms.Panel parent,
                                    ref int y, int w)
        {
            cbo.Location = new System.Drawing.Point(16, y); cbo.Width = w;
            cbo.Font = UIHelper.FontLabel;
            parent.Controls.Add(cbo); y += 32;
        }

        private static void SetBtn(System.Windows.Forms.Button btn, string text,
                                    System.Drawing.Color color, System.Drawing.Point loc, int width)
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
        private System.Windows.Forms.ComboBox cboLocTrangThai;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvVanBang;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.Label lblSoHieuVB;
        private System.Windows.Forms.TextBox txtSoHieuVB;
        private System.Windows.Forms.Label lblSinhVien;
        private System.Windows.Forms.ComboBox cboSinhVien;
        private System.Windows.Forms.Label lblNganhHoc;
        private System.Windows.Forms.ComboBox cboNganhHoc;
        private System.Windows.Forms.Label lblTenVB;
        private System.Windows.Forms.TextBox txtTenVB;
        private System.Windows.Forms.Label lblXepLoai;
        private System.Windows.Forms.ComboBox cboXepLoai;
        private System.Windows.Forms.Label lblCapDo;
        private System.Windows.Forms.ComboBox cboCapDo;
        private System.Windows.Forms.Label lblNgayCap;
        private System.Windows.Forms.DateTimePicker dtpNgayCap;
        private System.Windows.Forms.Label lblDonViCap;
        private System.Windows.Forms.ComboBox cboDonViCap;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
    }

}