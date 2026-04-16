namespace QLVanBang_Nhom4
{
    partial class FrmLichSuHocTap
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvLSHT;
        private System.Windows.Forms.ComboBox cbSoHieuVB;
        private System.Windows.Forms.ComboBox cbMaNH;
        private System.Windows.Forms.TextBox txtDiem;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.DateTimePicker dtNgayNhap;
        private System.Windows.Forms.DateTimePicker dtNgayKetThuc;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnReload;

        private System.Windows.Forms.Panel panelMain;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.dgvLSHT = new System.Windows.Forms.DataGridView();

            this.cbSoHieuVB = new System.Windows.Forms.ComboBox();
            this.cbMaNH = new System.Windows.Forms.ComboBox();
            this.txtDiem = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.dtNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.dtNgayKetThuc = new System.Windows.Forms.DateTimePicker();

            this.btnThem = UIHelper.CreateButton("Thêm", UIHelper.PrimaryBlue);
            this.btnSua = UIHelper.CreateButton("Sửa", UIHelper.AccentOrange);
            this.btnXoa = UIHelper.CreateButton("Xóa", UIHelper.AccentRed);
            this.btnReload = UIHelper.CreateButton("Reload", UIHelper.AccentGreen);

            ((System.ComponentModel.ISupportInitialize)(this.dgvLSHT)).BeginInit();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();

            // ================= FORM =================
            this.BackColor = UIHelper.BgPage;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Text = "Quản lý Lịch sử học tập";

            // ================= PANEL =================
            this.panelMain.BackColor = UIHelper.BgPanel;
            this.panelMain.Location = new System.Drawing.Point(20, 20);
            this.panelMain.Size = new System.Drawing.Size(950, 500);
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // ================= GRID =================
            this.dgvLSHT.Location = new System.Drawing.Point(20, 20);
            this.dgvLSHT.Size = new System.Drawing.Size(900, 250);
            this.dgvLSHT.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLSHT_CellClick);

            // Apply style
            UIHelper.StyleDataGridView(this.dgvLSHT);

            // ================= INPUT =================
            int y1 = 300;
            int y2 = 340;

            this.cbSoHieuVB.Location = new System.Drawing.Point(20, y1);
            this.cbSoHieuVB.Width = 180;

            this.cbMaNH.Location = new System.Drawing.Point(20, y2);
            this.cbMaNH.Width = 180;

            this.dtNgayNhap.Location = new System.Drawing.Point(220, y1);
            this.dtNgayKetThuc.Location = new System.Drawing.Point(220, y2);

            this.txtDiem.Location = new System.Drawing.Point(420, y1);
            this.txtGhiChu.Location = new System.Drawing.Point(420, y2);

            UIHelper.StyleTextBox(this.txtDiem);
            UIHelper.StyleTextBox(this.txtGhiChu);

            // ================= BUTTON =================
            this.btnThem.Location = new System.Drawing.Point(650, 300);
            this.btnSua.Location = new System.Drawing.Point(650, 340);
            this.btnXoa.Location = new System.Drawing.Point(750, 300);
            this.btnReload.Location = new System.Drawing.Point(750, 340);

            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);

            // ================= ADD CONTROL =================
            this.panelMain.Controls.Add(this.dgvLSHT);

            this.panelMain.Controls.Add(this.cbSoHieuVB);
            this.panelMain.Controls.Add(this.cbMaNH);
            this.panelMain.Controls.Add(this.dtNgayNhap);
            this.panelMain.Controls.Add(this.dtNgayKetThuc);
            this.panelMain.Controls.Add(this.txtDiem);
            this.panelMain.Controls.Add(this.txtGhiChu);

            this.panelMain.Controls.Add(this.btnThem);
            this.panelMain.Controls.Add(this.btnSua);
            this.panelMain.Controls.Add(this.btnXoa);
            this.panelMain.Controls.Add(this.btnReload);

            this.Controls.Add(this.panelMain);

            this.Load += new System.EventHandler(this.FrmLichSuHocTap_Load);

            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLSHT)).EndInit();
            this.ResumeLayout(false);
        }
    }
}