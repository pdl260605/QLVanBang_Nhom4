using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVanBang_Nhom4
{
    /// <summary>
    /// Form quản lý Người dùng (tài khoản đăng nhập). Chỉ dành cho Admin.
    /// Cho phép thêm, sửa, khoá/mở tài khoản và đặt lại mật khẩu.
    /// </summary>
    public partial class FrmNguoiDung : Form
    {
        private readonly DBConnection _db = new DBConnection();

        public FrmNguoiDung()
        {
            InitializeComponent();
        }

        private void FrmNguoiDung_Load(object sender, EventArgs e)
        {
            cboVaiTro.Items.Clear();
            cboVaiTro.Items.AddRange(new[] { "Admin", "NhanVien" });

            cboLocVaiTro.Items.Clear();
            cboLocVaiTro.Items.AddRange(new[] { "-- Tất cả --", "Admin", "NhanVien" });
            cboLocVaiTro.SelectedIndex = 0;

            LoadNguoiDung();
        }

        private void LoadNguoiDung(string keyword = "", string vaiTro = "")
        {
            try
            {
                string sql = @"SELECT TenDangNhap, HoTen, VaiTro, Email,
                                      CONVERT(VARCHAR,NgayTao,103) AS NgayTao,
                                      CASE TrangThai WHEN 1 THEN N'Hoạt động' ELSE N'Đã khoá' END AS TrangThai
                               FROM NGUOIDUNG WHERE 1=1";
                if (!string.IsNullOrEmpty(keyword))
                    sql += " AND (TenDangNhap LIKE @kw OR HoTen LIKE @kw OR Email LIKE @kw)";
                if (!string.IsNullOrEmpty(vaiTro) && vaiTro != "-- Tất cả --")
                    sql += " AND VaiTro = @vt";
                sql += " ORDER BY TenDangNhap";

                var da = new SqlDataAdapter(sql, _db.GetConnection());
                if (!string.IsNullOrEmpty(keyword))
                    da.SelectCommand.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                if (!string.IsNullOrEmpty(vaiTro) && vaiTro != "-- Tất cả --")
                    da.SelectCommand.Parameters.AddWithValue("@vt", vaiTro);

                var dt = new DataTable();
                da.Fill(dt);
                dgvNguoiDung.DataSource = dt;
                lblSoLuong.Text = $"Tổng: {dt.Rows.Count} tài khoản";

                if (dgvNguoiDung.Columns.Count > 0)
                {
                    dgvNguoiDung.Columns["TenDangNhap"].HeaderText = "Tài khoản";
                    dgvNguoiDung.Columns["HoTen"].HeaderText = "Họ và tên";
                    dgvNguoiDung.Columns["VaiTro"].HeaderText = "Vai trò";
                    dgvNguoiDung.Columns["Email"].HeaderText = "Email";
                    dgvNguoiDung.Columns["NgayTao"].HeaderText = "Ngày tạo";
                    dgvNguoiDung.Columns["TrangThai"].HeaderText = "Trạng thái";
                }
            }
            catch (Exception ex) { ShowError("Lỗi tải dữ liệu: " + ex.Message); }
        }

        private void dgvNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                DataGridViewRow row = dgvNguoiDung.Rows[e.RowIndex];
                txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value?.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
                cboVaiTro.Text = row.Cells["VaiTro"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                txtTenDangNhap.ReadOnly = true;
                txtMatKhau.Clear(); txtXacNhanMK.Clear();
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        // ==============================
        // THÊM TÀI KHOẢN
        // ==============================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(isNew: true)) return;
            try
            {
                _db.OpenConnection();
                var check = new SqlCommand("SELECT COUNT(*) FROM NGUOIDUNG WHERE TenDangNhap=@id", _db.GetConnection());
                check.Parameters.AddWithValue("@id", txtTenDangNhap.Text.Trim());
                if ((int)check.ExecuteScalar() > 0) { ShowError("Tài khoản đã tồn tại!"); return; }

                string sql = @"INSERT INTO NGUOIDUNG (TenDangNhap,MatKhau,HoTen,VaiTro,Email)
                               VALUES (@id, CONVERT(NVARCHAR(255),HASHBYTES('SHA2_256',@mk),2), @hn, @vt, @em)";
                var cmd = new SqlCommand(sql, _db.GetConnection());
                cmd.Parameters.AddWithValue("@id", txtTenDangNhap.Text.Trim());
                cmd.Parameters.AddWithValue("@mk", txtMatKhau.Text.Trim());
                cmd.Parameters.AddWithValue("@hn", txtHoTen.Text.Trim());
                cmd.Parameters.AddWithValue("@vt", cboVaiTro.Text.Trim());
                cmd.Parameters.AddWithValue("@em", txtEmail.Text.Trim());
                cmd.ExecuteNonQuery();
                ShowSuccess("Tạo tài khoản thành công!");
                LoadNguoiDung(); ClearForm();
            }
            catch (Exception ex) { ShowError("Lỗi thêm: " + ex.Message); }
            finally { _db.CloseConnection(); }
        }

        // ==============================
        // SỬA THÔNG TIN (không đổi mật khẩu)
        // ==============================
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDangNhap.Text)) { ShowError("Vui lòng chọn tài khoản cần sửa!"); return; }
            if (!ValidateInput(isNew: false)) return;
            try
            {
                _db.OpenConnection();
                string sql = "UPDATE NGUOIDUNG SET HoTen=@hn, VaiTro=@vt, Email=@em WHERE TenDangNhap=@id";
                var cmd = new SqlCommand(sql, _db.GetConnection());
                cmd.Parameters.AddWithValue("@id", txtTenDangNhap.Text.Trim());
                cmd.Parameters.AddWithValue("@hn", txtHoTen.Text.Trim());
                cmd.Parameters.AddWithValue("@vt", cboVaiTro.Text.Trim());
                cmd.Parameters.AddWithValue("@em", txtEmail.Text.Trim());
                cmd.ExecuteNonQuery();
                ShowSuccess("Cập nhật tài khoản thành công!");
                LoadNguoiDung(); ClearForm();
            }
            catch (Exception ex) { ShowError("Lỗi sửa: " + ex.Message); }
            finally { _db.CloseConnection(); }
        }

        // ==============================
        // ĐẶT LẠI MẬT KHẨU
        // ==============================
        private void btnDatLaiMK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDangNhap.Text)) { ShowError("Vui lòng chọn tài khoản!"); return; }
            if (string.IsNullOrEmpty(txtMatKhau.Text)) { ShowError("Vui lòng nhập mật khẩu mới!"); return; }
            if (txtMatKhau.Text != txtXacNhanMK.Text) { ShowError("Mật khẩu xác nhận không khớp!"); return; }
            if (txtMatKhau.Text.Length < 6) { ShowError("Mật khẩu phải có ít nhất 6 ký tự!"); return; }

            if (MessageBox.Show("Đặt lại mật khẩu cho tài khoản này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                _db.OpenConnection();
                string sql = "UPDATE NGUOIDUNG SET MatKhau=CONVERT(NVARCHAR(255),HASHBYTES('SHA2_256',@mk),2) WHERE TenDangNhap=@id";
                var cmd = new SqlCommand(sql, _db.GetConnection());
                cmd.Parameters.AddWithValue("@id", txtTenDangNhap.Text.Trim());
                cmd.Parameters.AddWithValue("@mk", txtMatKhau.Text.Trim());
                cmd.ExecuteNonQuery();
                ShowSuccess("Đặt lại mật khẩu thành công!");
                LoadNguoiDung(); ClearForm();
            }
            catch (Exception ex) { ShowError("Lỗi đặt lại mật khẩu: " + ex.Message); }
            finally { _db.CloseConnection(); }
        }

        // ==============================
        // KHOÁ / MỞ KHOÁ TÀI KHOẢN
        // ==============================
        private void btnKhoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDangNhap.Text)) { ShowError("Vui lòng chọn tài khoản!"); return; }
            if (txtTenDangNhap.Text == NguoiDungHienTai.TenDangNhap)
            { ShowError("Không thể khoá tài khoản đang đăng nhập!"); return; }

            if (MessageBox.Show($"Khoá / Mở khoá tài khoản [{txtTenDangNhap.Text}]?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                _db.OpenConnection();
                string sql = "UPDATE NGUOIDUNG SET TrangThai = 1 - TrangThai WHERE TenDangNhap=@id";
                var cmd = new SqlCommand(sql, _db.GetConnection());
                cmd.Parameters.AddWithValue("@id", txtTenDangNhap.Text.Trim());
                cmd.ExecuteNonQuery();
                ShowSuccess("Cập nhật trạng thái tài khoản thành công!");
                LoadNguoiDung(); ClearForm();
            }
            catch (Exception ex) { ShowError("Lỗi: " + ex.Message); }
            finally { _db.CloseConnection(); }
        }

        private void btnLamMoi_Click(object sender, EventArgs e) => ClearForm();

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
            => LoadNguoiDung(txtTimKiem.Text.Trim(), cboLocVaiTro.SelectedItem?.ToString());

        private void cboLocVaiTro_SelectedIndexChanged(object sender, EventArgs e)
            => LoadNguoiDung(txtTimKiem.Text.Trim(), cboLocVaiTro.SelectedItem?.ToString());

        private bool ValidateInput(bool isNew)
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text)) { ShowError("Tài khoản không được để trống!"); return false; }
            if (string.IsNullOrWhiteSpace(txtHoTen.Text)) { ShowError("Họ tên không được để trống!"); return false; }
            if (string.IsNullOrWhiteSpace(cboVaiTro.Text)) { ShowError("Vui lòng chọn vai trò!"); return false; }
            if (isNew)
            {
                if (string.IsNullOrWhiteSpace(txtMatKhau.Text)) { ShowError("Mật khẩu không được để trống!"); return false; }
                if (txtMatKhau.Text.Length < 6) { ShowError("Mật khẩu phải có ít nhất 6 ký tự!"); return false; }
                if (txtMatKhau.Text != txtXacNhanMK.Text) { ShowError("Mật khẩu xác nhận không khớp!"); return false; }
            }
            return true;
        }

        private void ClearForm()
        {
            txtTenDangNhap.Clear(); txtTenDangNhap.ReadOnly = false;
            txtHoTen.Clear(); txtEmail.Clear();
            txtMatKhau.Clear(); txtXacNhanMK.Clear(); txtTimKiem.Clear();
            cboVaiTro.SelectedIndex = -1;
            lblThongBao.Text = string.Empty;
            txtTenDangNhap.Focus();
        }

        private void ShowError(string msg) { lblThongBao.ForeColor = UIHelper.AccentRed; lblThongBao.Text = "⚠ " + msg; }
        private void ShowSuccess(string msg) { lblThongBao.ForeColor = UIHelper.AccentGreen; lblThongBao.Text = "✔ " + msg; }
    }

}
