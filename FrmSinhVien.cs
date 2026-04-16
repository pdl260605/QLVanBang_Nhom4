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
    /// Form quản lý thông tin Sinh viên: Thêm, Sửa, Xóa, Tìm kiếm.
    /// </summary>
    public partial class FrmSinhVien : Form
    {
        private readonly DBConnection _db = new DBConnection();

        public FrmSinhVien()
        {
            InitializeComponent();
        }

        // ==============================
        // LOAD FORM
        // ==============================
        private void FrmSinhVien_Load(object sender, EventArgs e)
        {
            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");
            LoadSinhVien();
        }

        // ==============================
        // LOAD DỮ LIỆU
        // ==============================
        private void LoadSinhVien(string keyword = "")
        {
            try
            {
                string sql = string.IsNullOrEmpty(keyword)
                    ? "SELECT MaSV, HoTen, NgaySinh, GioiTinh, CCCD, Email, SDT, DiaChi FROM SV ORDER BY MaSV"
                    : @"SELECT MaSV, HoTen, NgaySinh, GioiTinh, CCCD, Email, SDT, DiaChi
                        FROM SV
                        WHERE MaSV LIKE @kw OR HoTen LIKE @kw OR CCCD LIKE @kw OR Email LIKE @kw
                        ORDER BY MaSV";

                SqlDataAdapter da = new SqlDataAdapter(sql, _db.GetConnection());
                if (!string.IsNullOrEmpty(keyword))
                    da.SelectCommand.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvSinhVien.DataSource = dt;
                lblSoLuong.Text = $"Tổng: {dt.Rows.Count} sinh viên";

                // Đặt tiêu đề cột
                if (dgvSinhVien.Columns.Count > 0)
                {
                    dgvSinhVien.Columns["MaSV"].HeaderText = "Mã SV";
                    dgvSinhVien.Columns["HoTen"].HeaderText = "Họ và tên";
                    dgvSinhVien.Columns["NgaySinh"].HeaderText = "Ngày sinh";
                    dgvSinhVien.Columns["GioiTinh"].HeaderText = "Giới tính";
                    dgvSinhVien.Columns["CCCD"].HeaderText = "CCCD";
                    dgvSinhVien.Columns["Email"].HeaderText = "Email";
                    dgvSinhVien.Columns["SDT"].HeaderText = "Số điện thoại";
                    dgvSinhVien.Columns["DiaChi"].HeaderText = "Địa chỉ";
                }
            }
            catch (Exception ex)
            {
                ShowError("Lỗi tải dữ liệu sinh viên: " + ex.Message);
            }
        }

        // ==============================
        // CHỌN DÒNG GRID
        // ==============================
        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                DataGridViewRow row = dgvSinhVien.Rows[e.RowIndex];

                txtMaSV.Text = row.Cells["MaSV"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                txtCCCD.Text = row.Cells["CCCD"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                cboGioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();

                if (row.Cells["NgaySinh"].Value != DBNull.Value)
                    dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);

                txtMaSV.ReadOnly = true;  // Không cho sửa mã khi đang xem
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        // ==============================
        // THÊM SINH VIÊN
        // ==============================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                _db.OpenConnection();

                // Kiểm tra mã đã tồn tại
                var checkCmd = new SqlCommand("SELECT COUNT(*) FROM SV WHERE MaSV=@MaSV", _db.GetConnection());
                checkCmd.Parameters.AddWithValue("@MaSV", txtMaSV.Text.Trim());
                if ((int)checkCmd.ExecuteScalar() > 0)
                {
                    ShowError("Mã sinh viên đã tồn tại!");
                    _db.CloseConnection(); return;
                }

                string sql = @"INSERT INTO SV (MaSV,HoTen,NgaySinh,GioiTinh,CCCD,Email,SDT,DiaChi)
                               VALUES (@MaSV,@HoTen,@NgaySinh,@GioiTinh,@CCCD,@Email,@SDT,@DiaChi)";
                ExecuteCommand(sql);

                ShowSuccess("Thêm sinh viên thành công!");
                LoadSinhVien();
                ClearForm();
            }
            catch (Exception ex) { ShowError("Lỗi thêm sinh viên: " + ex.Message); }
            finally { _db.CloseConnection(); }
        }

        // ==============================
        // SỬA SINH VIÊN
        // ==============================
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSV.Text)) { ShowError("Vui lòng chọn sinh viên cần sửa!"); return; }
            if (!ValidateInput()) return;

            if (MessageBox.Show("Bạn có chắc muốn cập nhật sinh viên này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                _db.OpenConnection();
                string sql = @"UPDATE SV SET HoTen=@HoTen, NgaySinh=@NgaySinh, GioiTinh=@GioiTinh,
                               CCCD=@CCCD, Email=@Email, SDT=@SDT, DiaChi=@DiaChi WHERE MaSV=@MaSV";
                ExecuteCommand(sql);
                ShowSuccess("Cập nhật sinh viên thành công!");
                LoadSinhVien();
                ClearForm();
            }
            catch (Exception ex) { ShowError("Lỗi sửa sinh viên: " + ex.Message); }
            finally { _db.CloseConnection(); }
        }

        // ==============================
        // XÓA SINH VIÊN
        // ==============================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSV.Text)) { ShowError("Vui lòng chọn sinh viên cần xóa!"); return; }

            if (MessageBox.Show($"Bạn có chắc muốn xóa sinh viên [{txtMaSV.Text.Trim()}] - {txtHoTen.Text.Trim()}?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            try
            {
                _db.OpenConnection();
                var cmd = new SqlCommand("DELETE FROM SV WHERE MaSV=@MaSV", _db.GetConnection());
                cmd.Parameters.AddWithValue("@MaSV", txtMaSV.Text.Trim());
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0) { ShowSuccess("Xóa sinh viên thành công!"); LoadSinhVien(); ClearForm(); }
                else ShowError("Xóa thất bại!");
            }
            catch (SqlException sex) when (sex.Number == 547)
            {
                ShowError("Không thể xóa sinh viên này vì đang có liên kết với văn bằng hoặc lịch sử học tập!");
            }
            catch (Exception ex) { ShowError("Lỗi xóa: " + ex.Message); }
            finally { _db.CloseConnection(); }
        }

        // ==============================
        // LÀM MỚI
        // ==============================
        private void btnLamMoi_Click(object sender, EventArgs e) => ClearForm();

        // ==============================
        // TÌM KIẾM
        // ==============================
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
            => LoadSinhVien(txtTimKiem.Text.Trim());

        // ==============================
        // HỖ TRỢ
        // ==============================
        private void ExecuteCommand(string sql)
        {
            var cmd = new SqlCommand(sql, _db.GetConnection());
            cmd.Parameters.AddWithValue("@MaSV", txtMaSV.Text.Trim());
            cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text.Trim());
            cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value.Date);
            cmd.Parameters.AddWithValue("@GioiTinh", cboGioiTinh.Text.Trim());
            cmd.Parameters.AddWithValue("@CCCD", txtCCCD.Text.Trim());
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
            cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
            cmd.ExecuteNonQuery();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text)) { ShowError("Mã sinh viên không được để trống!"); return false; }
            if (string.IsNullOrWhiteSpace(txtHoTen.Text)) { ShowError("Họ tên không được để trống!"); return false; }
            if (string.IsNullOrWhiteSpace(cboGioiTinh.Text)) { ShowError("Vui lòng chọn giới tính!"); return false; }
            if (string.IsNullOrWhiteSpace(txtCCCD.Text)) { ShowError("CCCD không được để trống!"); return false; }
            if (string.IsNullOrWhiteSpace(txtEmail.Text)) { ShowError("Email không được để trống!"); return false; }
            if (string.IsNullOrWhiteSpace(txtSDT.Text)) { ShowError("Số điện thoại không được để trống!"); return false; }
            return true;
        }

        private void ClearForm()
        {
            txtMaSV.Clear(); txtMaSV.ReadOnly = false;
            txtHoTen.Clear(); txtCCCD.Clear(); txtEmail.Clear();
            txtSDT.Clear(); txtDiaChi.Clear(); txtTimKiem.Clear();
            cboGioiTinh.SelectedIndex = -1;
            dtpNgaySinh.Value = DateTime.Now.AddYears(-20);
            lblThongBao.Text = string.Empty;
            txtMaSV.Focus();
        }

        private void ShowError(string msg)
        {
            lblThongBao.ForeColor = UIHelper.AccentRed;
            lblThongBao.Text = "⚠ " + msg;
        }

        private void ShowSuccess(string msg)
        {
            lblThongBao.ForeColor = UIHelper.AccentGreen;
            lblThongBao.Text = "✔ " + msg;
        }
    }

}
