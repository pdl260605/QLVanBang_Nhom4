namespace QLVanBang_Nhom4
{
    partial class FrmLichSuChinhSua
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.cboLocThaoTac = new System.Windows.Forms.ComboBox();
            this.cboLocBang = new System.Windows.Forms.ComboBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.dgvLichSu = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblSoLuong);
            this.pnlTop.Controls.Add(this.btnXuatExcel);
            this.pnlTop.Controls.Add(this.cboLocThaoTac);
            this.pnlTop.Controls.Add(this.cboLocBang);
            this.pnlTop.Controls.Add(this.txtTimKiem);
            this.pnlTop.Controls.Add(this.lblTieuDe);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.pnlTop.Size = new System.Drawing.Size(1016, 70);
            this.pnlTop.TabIndex = 1;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblSoLuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSoLuong.Location = new System.Drawing.Point(640, 45);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(0, 19);
            this.lblSoLuong.TabIndex = 0;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(168)))), ((int)(((byte)(83)))));
            this.btnXuatExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatExcel.FlatAppearance.BorderSize = 0;
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(524, 37);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(100, 28);
            this.btnXuatExcel.TabIndex = 1;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // cboLocThaoTac
            // 
            this.cboLocThaoTac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocThaoTac.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboLocThaoTac.Location = new System.Drawing.Point(390, 37);
            this.cboLocThaoTac.Name = "cboLocThaoTac";
            this.cboLocThaoTac.Size = new System.Drawing.Size(120, 28);
            this.cboLocThaoTac.TabIndex = 2;
            this.cboLocThaoTac.SelectedIndexChanged += new System.EventHandler(this.cboLocThaoTac_SelectedIndexChanged);
            // 
            // cboLocBang
            // 
            this.cboLocBang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocBang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboLocBang.Location = new System.Drawing.Point(248, 37);
            this.cboLocBang.Name = "cboLocBang";
            this.cboLocBang.Size = new System.Drawing.Size(130, 28);
            this.cboLocBang.TabIndex = 3;
            this.cboLocBang.SelectedIndexChanged += new System.EventHandler(this.cboLocBang_SelectedIndexChanged);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimKiem.Location = new System.Drawing.Point(16, 38);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(220, 27);
            this.txtTimKiem.TabIndex = 4;
            this.txtTimKiem.Text = "🔍  Tìm người dùng, chi tiết...";
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTieuDe.Location = new System.Drawing.Point(16, 10);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(307, 41);
            this.lblTieuDe.TabIndex = 5;
            this.lblTieuDe.Text = "🕐 Lịch sử chỉnh sửa";
            // 
            // dgvLichSu
            // 
            this.dgvLichSu.ColumnHeadersHeight = 29;
            this.dgvLichSu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLichSu.Location = new System.Drawing.Point(0, 70);
            this.dgvLichSu.Margin = new System.Windows.Forms.Padding(12);
            this.dgvLichSu.Name = "dgvLichSu";
            this.dgvLichSu.RowHeadersWidth = 51;
            this.dgvLichSu.Size = new System.Drawing.Size(1016, 389);
            this.dgvLichSu.TabIndex = 0;
            // 
            // FrmLichSuChinhSua
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1016, 459);
            this.Controls.Add(this.dgvLichSu);
            this.Controls.Add(this.pnlTop);
            this.Name = "FrmLichSuChinhSua";
            this.Text = "Lịch sử chỉnh sửa";
            this.Load += new System.EventHandler(this.FrmLichSuChinhSua_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ComboBox cboLocBang;
        private System.Windows.Forms.ComboBox cboLocThaoTac;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.DataGridView dgvLichSu;
    }
}