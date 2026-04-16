namespace QLVanBang_Nhom4
{
    partial class FrmDashboard
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblNguoiDung = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlKPI = new System.Windows.Forms.Panel();
            this.cardSV = new System.Windows.Forms.Panel();
            this.lblSoSinhVien = new System.Windows.Forms.Label();
            this.lblCapSV = new System.Windows.Forms.Label();
            this.cardVB = new System.Windows.Forms.Panel();
            this.lblSoVanBang = new System.Windows.Forms.Label();
            this.lblCapVB = new System.Windows.Forms.Label();
            this.cardYC = new System.Windows.Forms.Panel();
            this.lblSoYeuCau = new System.Windows.Forms.Label();
            this.lblCapYC = new System.Windows.Forms.Label();
            this.cardDV = new System.Windows.Forms.Panel();
            this.lblSoDonViCap = new System.Windows.Forms.Label();
            this.lblCapDV = new System.Windows.Forms.Label();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblTitleStatus = new System.Windows.Forms.Label();
            this.lblDaCap = new System.Windows.Forms.Label();
            this.lblDangXuLy = new System.Windows.Forms.Label();
            this.lblThuHoi = new System.Windows.Forms.Label();
            this.lblMat = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.lblTitleGrid = new System.Windows.Forms.Label();
            this.dgvGanDay = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlKPI.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGanDay)).BeginInit();
            this.SuspendLayout();

            this.BackColor = UIHelper.BgPage;
            this.Name = "FrmDashboard"; this.Text = "Tổng quan";
            this.Load += new System.EventHandler(this.FrmDashboard_Load);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlTop);

            // ── pnlTop ────────────────────────────────────────────────────
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top; this.pnlTop.Height = 70;
            this.pnlTop.BackColor = UIHelper.BgPanel;
            this.pnlTop.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.pnlTop.Controls.Add(this.btnLamMoi);
            this.pnlTop.Controls.Add(this.lblNguoiDung);
            this.pnlTop.Controls.Add(this.lblTieuDe);

            this.lblTieuDe.Text = "🏠 Tổng quan hệ thống"; this.lblTieuDe.Font = UIHelper.FontTitle;
            this.lblTieuDe.ForeColor = UIHelper.TextPrimary; this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Location = new System.Drawing.Point(20, 18);

            this.lblNguoiDung.Text = $"Xin chào, {NguoiDungHienTai.HoTen}";
            this.lblNguoiDung.Font = UIHelper.FontSubtitle; this.lblNguoiDung.ForeColor = UIHelper.TextSecondary;
            this.lblNguoiDung.AutoSize = true; this.lblNguoiDung.Location = new System.Drawing.Point(380, 24);

            this.btnLamMoi.Text = "↻ Làm mới"; this.btnLamMoi.Font = UIHelper.FontButton;
            this.btnLamMoi.BackColor = UIHelper.PrimaryBlue; this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.Size = new System.Drawing.Size(100, 32); this.btnLamMoi.Location = new System.Drawing.Point(700, 18);
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // ── pnlBody ───────────────────────────────────────────────────
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Padding = new System.Windows.Forms.Padding(16);
            this.pnlBody.Controls.Add(this.pnlGrid);
            this.pnlBody.Controls.Add(this.pnlStatus);
            this.pnlBody.Controls.Add(this.pnlKPI);

            // ── pnlKPI (4 thẻ ngang) ──────────────────────────────────────
            this.pnlKPI.Dock = System.Windows.Forms.DockStyle.Top; this.pnlKPI.Height = 110;
            this.pnlKPI.BackColor = UIHelper.BgPage;
            this.pnlKPI.Controls.Add(this.cardDV);
            this.pnlKPI.Controls.Add(this.cardYC);
            this.pnlKPI.Controls.Add(this.cardVB);
            this.pnlKPI.Controls.Add(this.cardSV);

            MakeCard(this.cardSV, this.lblSoSinhVien, this.lblCapSV, "Sinh viên", UIHelper.PrimaryBlue, 0);
            MakeCard(this.cardVB, this.lblSoVanBang, this.lblCapVB, "Văn bằng", UIHelper.AccentGreen, 1);
            MakeCard(this.cardYC, this.lblSoYeuCau, this.lblCapYC, "YC đang xử lý", UIHelper.AccentOrange, 2);
            MakeCard(this.cardDV, this.lblSoDonViCap, this.lblCapDV, "Đơn vị cấp", UIHelper.AccentRed, 3);

            // ── pnlStatus ─────────────────────────────────────────────────
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Top; this.pnlStatus.Height = 70;
            this.pnlStatus.BackColor = UIHelper.BgPanel;
            this.pnlStatus.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.pnlStatus.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.pnlStatus.Controls.Add(this.lblMat);
            this.pnlStatus.Controls.Add(this.lblThuHoi);
            this.pnlStatus.Controls.Add(this.lblDangXuLy);
            this.pnlStatus.Controls.Add(this.lblDaCap);
            this.pnlStatus.Controls.Add(this.lblTitleStatus);

            this.lblTitleStatus.Text = "Trạng thái văn bằng:";
            this.lblTitleStatus.Font = UIHelper.FontBold; this.lblTitleStatus.ForeColor = UIHelper.TextPrimary;
            this.lblTitleStatus.AutoSize = true; this.lblTitleStatus.Location = new System.Drawing.Point(16, 22);

            MakeStatusLbl(this.lblDaCap, UIHelper.AccentGreen, new System.Drawing.Point(160, 22));
            MakeStatusLbl(this.lblDangXuLy, UIHelper.PrimaryBlue, new System.Drawing.Point(310, 22));
            MakeStatusLbl(this.lblThuHoi, UIHelper.AccentOrange, new System.Drawing.Point(460, 22));
            MakeStatusLbl(this.lblMat, UIHelper.AccentRed, new System.Drawing.Point(600, 22));

            // ── pnlGrid ───────────────────────────────────────────────────
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.BackColor = UIHelper.BgPanel;
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.pnlGrid.Controls.Add(this.dgvGanDay);
            this.pnlGrid.Controls.Add(this.lblTitleGrid);

            this.lblTitleGrid.Text = "📋 10 văn bằng gần đây nhất";
            this.lblTitleGrid.Font = UIHelper.FontBold; this.lblTitleGrid.ForeColor = UIHelper.TextPrimary;
            this.lblTitleGrid.Dock = System.Windows.Forms.DockStyle.Top; this.lblTitleGrid.Height = 32;
            this.lblTitleGrid.Padding = new System.Windows.Forms.Padding(12, 8, 0, 0);

            this.dgvGanDay.Dock = System.Windows.Forms.DockStyle.Fill;
            UIHelper.StyleDataGridView(this.dgvGanDay);

            this.pnlTop.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlKPI.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGanDay)).EndInit();
            this.ResumeLayout(false);
        }

        private static void MakeCard(System.Windows.Forms.Panel card,
            System.Windows.Forms.Label lblNum, System.Windows.Forms.Label lblCap,
            string caption, System.Drawing.Color color, int index)
        {
            card.BackColor = color;
            card.Dock = System.Windows.Forms.DockStyle.Left;
            card.Width = 200;
            card.Padding = new System.Windows.Forms.Padding(16);
            card.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);

            lblNum.Text = "—";
            lblNum.Font = new System.Drawing.Font("Segoe UI", 28f, System.Drawing.FontStyle.Bold);
            lblNum.ForeColor = System.Drawing.Color.White;
            lblNum.AutoSize = true;
            lblNum.Location = new System.Drawing.Point(16, 14);

            lblCap.Text = caption;
            lblCap.Font = UIHelper.FontSubtitle;
            lblCap.ForeColor = System.Drawing.Color.FromArgb(220, 255, 255, 255);
            lblCap.AutoSize = true;
            lblCap.Location = new System.Drawing.Point(16, 56);

            card.Controls.Add(lblNum);
            card.Controls.Add(lblCap);
        }

        private static void MakeStatusLbl(System.Windows.Forms.Label lbl,
            System.Drawing.Color color, System.Drawing.Point loc)
        {
            lbl.Text = string.Empty;
            lbl.Font = UIHelper.FontBold;
            lbl.ForeColor = color;
            lbl.AutoSize = true;
            lbl.Location = loc;
        }
        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblNguoiDung;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlKPI;
        private System.Windows.Forms.Panel cardSV;
        private System.Windows.Forms.Label lblSoSinhVien;
        private System.Windows.Forms.Label lblCapSV;
        private System.Windows.Forms.Panel cardVB;
        private System.Windows.Forms.Label lblSoVanBang;
        private System.Windows.Forms.Label lblCapVB;
        private System.Windows.Forms.Panel cardYC;
        private System.Windows.Forms.Label lblSoYeuCau;
        private System.Windows.Forms.Label lblCapYC;
        private System.Windows.Forms.Panel cardDV;
        private System.Windows.Forms.Label lblSoDonViCap;
        private System.Windows.Forms.Label lblCapDV;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblTitleStatus;
        private System.Windows.Forms.Label lblDaCap;
        private System.Windows.Forms.Label lblDangXuLy;
        private System.Windows.Forms.Label lblThuHoi;
        private System.Windows.Forms.Label lblMat;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label lblTitleGrid;
        private System.Windows.Forms.DataGridView dgvGanDay;
    }
}