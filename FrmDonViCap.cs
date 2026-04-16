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
    /// Form quản lý Đơn vị cấp: Thêm, Sửa, Xóa, Tìm kiếm.
    /// </summary>
    public partial class FrmDonViCap : Form
    {
        private readonly DBConnection _db = new DBConnection();

        public FrmDonViCap()
        {
            InitializeComponent();
        }

        private void FrmDonViCap_Load(object sender, EventArgs e)
        {
            LoadDonViCap();
        }

        // ==============================
        // LOAD DỮ LIỆU
        // ==============================
        private void LoadDonViCap(string keyword = "")
        {
            try
            {
                string sql = string.IsNullOrEmpty(keyword)
                    ? "SELECT MaDV, TenDV, DiaChi, SDT, Email, Website FROM DONVICAP ORDER BY MaDV"
                    : @"SELECT MaDV, TenDV, DiaChi, SDT, Email, Website FROM DONVICAP
                        WHERE MaDV LIKE @kw OR TenDV LIKE @kw OR DiaChi LIKE @kw
                        ORDER BY MaDV";

                var da = new SqlDataAdapter(sql, _db.GetConnection());
                if (!string.IsNullOrEmpty(keyword))
                    da.SelectCommand.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                var dt = new DataTable();
                da.Fill(dt);
                dgvDonViCap.DataSource = dt;
                lblSoLuong.Text = $"Tổng: {dt.Rows.Count} đơn vị";

                if (dgvDonViCap.Columns.Count > 0)
                {
                    dgvDonViCap.Columns["MaDV"].HeaderText = "Mã ĐV";
                    dgvDonViCap.Columns["TenDV"].HeaderText = "Tên đơn vị";
                    dgvDonViCap.Columns["DiaChi"].HeaderText = "Địa chỉ";
                    dgvDonViCap.Columns["SDT"].HeaderText = "Số điện thoại";
                    dgvDonViCap.Columns["Email"].HeaderText = "Email";
                    dgvDonViCap.Columns["Website"].HeaderText = "Website";
                }
            }
            catch (Exception ex) { ShowError("Lỗi tải dữ liệu: " + ex.Message); }
        }

        // ==============================
        // CHỌN DÒNG GRID
        // ==============================
        private void dgvDonViCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                DataGridViewRow row = dgvDonViCap.Rows[e.RowIndex];
                txtMaDV.Text = row.Cells["MaDV"].Value?.ToString();
                txtTenDV.Text = row.Cells["TenDV"].Value?.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
                txtSDT.Text = row.Cells["SDT"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                txtWebsite.Text = row.Cells["Website"].Value?.ToString();
                txtMaDV.ReadOnly = true;
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        // ==============================
        // THÊM
        // ==============================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            try
            {
                _db.OpenConnection();
                var check = new SqlCommand("SELECT COUNT(*) FROM DONVICAP WHERE MaDV=@id", _db.GetConnection());
                check.Parameters.AddWithValue("@id", txtMaDV.Text.Trim());
                if ((int)check.ExecuteScalar() > 0) { ShowError("Mã đơn vị đã tồn tại!"); return; }

                string sql = @"INSERT INTO DONVICAP (MaDV,TenDV,DiaChi,SDT,Email,Website)
                               VALUES (@id,@ten,@dc,@sdt,@em,@web)";
                BuildCommand(sql).ExecuteNonQuery();
                ShowSuccess("Thêm đơn vị cấp thành công!");
                LoadDonViCap(); ClearForm();
            }
            catch (Exception ex) { ShowError("Lỗi thêm: " + ex.Message); }
            finally { _db.CloseConnection(); }
        }

        // ==============================
        // SỬA
        // ==============================
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDV.Text)) { ShowError("Vui lòng chọn đơn vị cần sửa!"); return; }
            if (!ValidateInput()) return;
            if (MessageBox.Show("Cập nhật đơn vị này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                _db.OpenConnection();
                string sql = @"UPDATE DONVICAP SET TenDV=@ten,DiaChi=@dc,SDT=@sdt,Email=@em,Website=@web
                               WHERE MaDV=@id";
                BuildCommand(sql).ExecuteNonQuery();
                ShowSuccess("Cập nhật thành công!");
                LoadDonViCap(); ClearForm();
            }
            catch (Exception ex) { ShowError("Lỗi sửa: " + ex.Message); }
            finally { _db.CloseConnection(); }
        }

        // ==============================
        // XÓA
        // ==============================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDV.Text)) { ShowError("Vui lòng chọn đơn vị cần xóa!"); return; }
            if (MessageBox.Show($"Xóa đơn vị [{txtMaDV.Text}] - {txtTenDV.Text}?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                _db.OpenConnection();
                var cmd = new SqlCommand("DELETE FROM DONVICAP WHERE MaDV=@id", _db.GetConnection());
                cmd.Parameters.AddWithValue("@id", txtMaDV.Text.Trim());
                cmd.ExecuteNonQuery();
                ShowSuccess("Xóa thành công!");
                LoadDonViCap(); ClearForm();
            }
            catch (SqlException sex) when (sex.Number == 547)
            {
                ShowError("Không thể xóa vì đơn vị này đang có ngành học hoặc văn bằng liên kết!");
            }
            catch (Exception ex) { ShowError("Lỗi xóa: " + ex.Message); }
            finally { _db.CloseConnection(); }
        }

        private void btnLamMoi_Click(object sender, EventArgs e) => ClearForm();

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
            => LoadDonViCap(txtTimKiem.Text.Trim());

        // ==============================
        // HỖ TRỢ
        // ==============================
        private SqlCommand BuildCommand(string sql)
        {
            var cmd = new SqlCommand(sql, _db.GetConnection());
            cmd.Parameters.AddWithValue("@id", txtMaDV.Text.Trim());
            cmd.Parameters.AddWithValue("@ten", txtTenDV.Text.Trim());
            cmd.Parameters.AddWithValue("@dc", txtDiaChi.Text.Trim());
            cmd.Parameters.AddWithValue("@sdt", txtSDT.Text.Trim());
            cmd.Parameters.AddWithValue("@em", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@web", txtWebsite.Text.Trim());
            return cmd;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaDV.Text)) { ShowError("Mã đơn vị không được để trống!"); return false; }
            if (string.IsNullOrWhiteSpace(txtTenDV.Text)) { ShowError("Tên đơn vị không được để trống!"); return false; }
            return true;
        }

        private void ClearForm()
        {
            txtMaDV.Clear(); txtMaDV.ReadOnly = false;
            txtTenDV.Clear(); txtDiaChi.Clear(); txtSDT.Clear();
            txtEmail.Clear(); txtWebsite.Clear(); txtTimKiem.Clear();
            lblThongBao.Text = string.Empty;
            txtMaDV.Focus();
        }

        private void ShowError(string msg) { lblThongBao.ForeColor = UIHelper.AccentRed; lblThongBao.Text = "⚠ " + msg; }
        private void ShowSuccess(string msg) { lblThongBao.ForeColor = UIHelper.AccentGreen; lblThongBao.Text = "✔ " + msg; }
    }

}
