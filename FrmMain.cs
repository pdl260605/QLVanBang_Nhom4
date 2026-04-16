using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVanBang_Nhom4
{
    /// <summary>
    /// Form chính (MDI container) với sidebar điều hướng chuyên nghiệp.
    /// </summary>
    public partial class FrmMain : Form
    {
        private Form _currentChildForm;
        private Button _activeNavButton;

        public FrmMain()
        {
            InitializeComponent();
        }

        // ==============================
        // LOAD FORM CHÍNH
        // ==============================
        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
            this.Text = "Hệ thống Quản lý Văn bằng";

            // Hiển thị thông tin người dùng đăng nhập
            lblNguoiDung.Text = $"👤 {NguoiDungHienTai.HoTen}";
            lblVaiTro.Text = NguoiDungHienTai.VaiTro == "Admin" ? "Quản trị viên" : "Nhân viên";

            // Ẩn chức năng quản lý người dùng nếu không phải Admin
            btnNguoiDung.Visible = NguoiDungHienTai.IsAdmin;

            // Mở Dashboard mặc định
            OpenChildForm(new FrmDashboard(), btnDashboard);
        }

        // ==============================
        // MỞ FORM CON TRONG MDI
        // ==============================
        private void OpenChildForm(Form childForm, Button navBtn = null)
        {
            _currentChildForm?.Close();
            _currentChildForm = childForm;

            childForm.MdiParent = this;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.Show();
            childForm.BringToFront();

            // Đánh dấu nút điều hướng đang active
            if (navBtn != null) SetActiveNavButton(navBtn);
        }

        private void SetActiveNavButton(Button btn)
        {
            if (_activeNavButton != null)
            {
                _activeNavButton.BackColor = UIHelper.BgSidebar;
                _activeNavButton.ForeColor = Color.FromArgb(148, 163, 184);
            }
            _activeNavButton = btn;
            btn.BackColor = UIHelper.SidebarActive;
            btn.ForeColor = Color.White;
        }

        // ==============================
        // ĐIỀU HƯỚNG (SIDEBAR BUTTONS)
        // ==============================
        private void btnDashboard_Click(object sender, EventArgs e)
            => OpenChildForm(new FrmDashboard(), btnDashboard);

        private void btnSinhVien_Click(object sender, EventArgs e)
            => OpenChildForm(new FrmSinhVien(), btnSinhVien);

        private void btnVanBang_Click(object sender, EventArgs e)
            => OpenChildForm(new FrmVanBang(), btnVanBang);

        private void btnNganhHoc_Click(object sender, EventArgs e)
            => OpenChildForm(new FrmNganhHoc(), btnNganhHoc);

        private void btnDonViCap_Click(object sender, EventArgs e)
            => OpenChildForm(new FrmDonViCap(), btnDonViCap);

        private void btnYeuCauCapLai_Click(object sender, EventArgs e)
            => OpenChildForm(new FrmYeuCauCapLai(), btnYeuCauCapLai);

        private void btnLichSuChinhSua_Click(object sender, EventArgs e)
            => OpenChildForm(new FrmLichSuChinhSua(), btnLichSuChinhSua);

        private void btnNguoiDung_Click(object sender, EventArgs e)
            => OpenChildForm(new FrmNguoiDung(), btnNguoiDung);
        private void btnLichSuHocTap_Click(object sender, EventArgs e)
            => OpenChildForm(new FrmLichSuHocTap(), btnLichSuHocTap);

        private void btnYeuCauChinhSua_Click(object sender, EventArgs e)
            => OpenChildForm(new FrmYeuCauChinhSua(), btnYeuCauChinhSua);

        // ==============================
        // ĐĂNG XUẤT
        // ==============================
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show(
                "Bạn có chắc muốn đăng xuất?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                NguoiDungHienTai.DangXuat();
                FrmLogin frmLogin = new FrmLogin();
                frmLogin.Show();
                this.Close();
            }
        }
    }
}
