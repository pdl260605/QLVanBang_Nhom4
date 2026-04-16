using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVanBang_Nhom4
{
    /// <summary>
    /// Form đăng nhập hệ thống Quản lý Văn bằng.
    /// Xác thực tài khoản thông qua stored procedure sp_DangNhap (SHA2_256).
    /// </summary>
    public partial class FrmLogin : Form
    {
        // ── Trường kéo form ─────────────────────────────────────────────
        private bool _isDragging;
        private Point _startPoint;

        public FrmLogin()
        {
            InitializeComponent();
        }

        // ==============================
        // LOAD FORM
        // ==============================
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // Cho phép nhấn Enter để đăng nhập
            this.AcceptButton = btnDangNhap;

            txtTaiKhoan.Text = string.Empty;
            txtMatKhau.Text = string.Empty;
            txtTaiKhoan.Focus();
        }

        // ==============================
        // ĐĂNG NHẬP
        // ==============================
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTaiKhoan.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                ShowError("Vui lòng nhập tài khoản và mật khẩu!");
                return;
            }

            try
            {
                DBConnection db = new DBConnection();
                db.OpenConnection();

                SqlCommand cmd = new SqlCommand("sp_DangNhap", db.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau", matKhau);
                Console.WriteLine($"DEBUG: Executing sp_DangNhap with TenDangNhap='{tenDangNhap}' and MatKhau='{matKhau }'");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                db.CloseConnection();

                if (dt.Rows.Count > 0)
                {
                    // Lưu thông tin phiên
                    NguoiDungHienTai.TenDangNhap = dt.Rows[0]["TenDangNhap"].ToString();
                    NguoiDungHienTai.HoTen = dt.Rows[0]["HoTen"].ToString();
                    NguoiDungHienTai.VaiTro = dt.Rows[0]["VaiTro"].ToString();

                    FrmMain frmMain = new FrmMain();
                    frmMain.Show();
                    this.Hide();
                }
                else
                {
                    ShowError("Tài khoản hoặc mật khẩu không đúng!");
                    txtMatKhau.Clear();
                    txtMatKhau.Focus();
                }
            }
            catch (Exception ex)
            {
                ShowError("Lỗi kết nối: " + ex.Message);
            }
        }

        // ==============================
        // THOÁT
        // ==============================
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // ==============================
        // HIỆN / ẨN MẬT KHẨU
        // ==============================
        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = chkHienMatKhau.Checked ? '\0' : '●';
        }

        // ==============================
        // KÉO FORM (borderless)
        // ==============================
        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            _isDragging = true;
            _startPoint = new Point(e.X, e.Y);
        }

        private void pnlHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isDragging) return;
            Point current = PointToScreen(new Point(e.X, e.Y));
            this.Location = new Point(current.X - _startPoint.X,
                                      current.Y - _startPoint.Y);
        }

        private void pnlHeader_MouseUp(object sender, MouseEventArgs e)
        {
            _isDragging = false;
        }

        // ==============================
        // HỖ TRỢ
        // ==============================
        private void ShowError(string msg)
        {
            lblThongBao.Text = msg;
            lblThongBao.ForeColor = UIHelper.AccentRed;
            lblThongBao.Visible = true;
        }
    }
}
