namespace QLVanBang_Nhom4
{
    partial class FrmYeuCauChinhSua
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.DataGridView dgvYeuCau;

        private System.Windows.Forms.TextBox txtMaYC;
        private System.Windows.Forms.ComboBox cbSoHieuVB;
        private System.Windows.Forms.ComboBox cbLoaiYeuCau;
        private System.Windows.Forms.TextBox txtLyDo;
        private System.Windows.Forms.DateTimePicker dtNgayYeuCau;
        private System.Windows.Forms.ComboBox cbTrangThai;
        private System.Windows.Forms.TextBox txtGhiChu;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnReload;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.dgvYeuCau = new System.Windows.Forms.DataGridView();

            this.txtMaYC = new System.Windows.Forms.TextBox();
            this.cbSoHieuVB = new System.Windows.Forms.ComboBox();
            this.cbLoaiYeuCau = new System.Windows.Forms.ComboBox();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.dtNgayYeuCau = new System.Windows.Forms.DateTimePicker();
            this.cbTrangThai = new System.Windows.Forms.ComboBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();

            this.btnThem = UIHelper.CreateButton("Thêm", UIHelper.PrimaryBlue);
            this.btnSua = UIHelper.CreateButton("Sửa", UIHelper.AccentOrange);
            this.btnXoa = UIHelper.CreateButton("Xóa", UIHelper.AccentRed);
            this.btnReload = UIHelper.CreateButton("Reload", UIHelper.AccentGreen);

            ((System.ComponentModel.ISupportInitialize)(this.dgvYeuCau)).BeginInit();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();

            // ================= FORM =================
            this.BackColor = UIHelper.BgPage;
            this.ClientSize = new System.Drawing.Size(1000, 580);
            this.Text = "Quản lý Yêu cầu chỉnh sửa / cấp lại";

            // ================= PANEL =================
            this.panelMain.BackColor = UIHelper.BgPanel;
            this.panelMain.Location = new System.Drawing.Point(20, 20);
            this.panelMain.Size = new System.Drawing.Size(950, 520);
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // ================= GRID =================
            this.dgvYeuCau.Location = new System.Drawing.Point(20, 20);
            this.dgvYeuCau.Size = new System.Drawing.Size(900, 250);
            this.dgvYeuCau.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvYeuCau_CellClick);

            UIHelper.StyleDataGridView(this.dgvYeuCau);

            // ================= INPUT =================
            int y1 = 300;
            int y2 = 340;
            int y3 = 380;

            this.txtMaYC.Location = new System.Drawing.Point(20, y1);
            this.txtMaYC.Width = 180;
            UIHelper.StyleTextBox(this.txtMaYC);

            this.cbSoHieuVB.Location = new System.Drawing.Point(20, y2);
            this.cbSoHieuVB.Width = 180;

            this.cbLoaiYeuCau.Location = new System.Drawing.Point(20, y3);
            this.cbLoaiYeuCau.Width = 180;

            this.dtNgayYeuCau.Location = new System.Drawing.Point(220, y1);

            this.cbTrangThai.Location = new System.Drawing.Point(220, y2);
            this.cbTrangThai.Width = 180;

            this.txtLyDo.Location = new System.Drawing.Point(420, y1);
            this.txtLyDo.Width = 200;
            UIHelper.StyleTextBox(this.txtLyDo);

            this.txtGhiChu.Location = new System.Drawing.Point(420, y2);
            this.txtGhiChu.Width = 200;
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
            this.panelMain.Controls.Add(this.dgvYeuCau);

            this.panelMain.Controls.Add(this.txtMaYC);
            this.panelMain.Controls.Add(this.cbSoHieuVB);
            this.panelMain.Controls.Add(this.cbLoaiYeuCau);
            this.panelMain.Controls.Add(this.dtNgayYeuCau);
            this.panelMain.Controls.Add(this.cbTrangThai);
            this.panelMain.Controls.Add(this.txtLyDo);
            this.panelMain.Controls.Add(this.txtGhiChu);

            this.panelMain.Controls.Add(this.btnThem);
            this.panelMain.Controls.Add(this.btnSua);
            this.panelMain.Controls.Add(this.btnXoa);
            this.panelMain.Controls.Add(this.btnReload);

            this.Controls.Add(this.panelMain);

            this.Load += new System.EventHandler(this.FrmYeuCauChinhSua_Load);

            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYeuCau)).EndInit();
            this.ResumeLayout(false);
        }
    }
}