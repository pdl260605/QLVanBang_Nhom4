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
    /// Form quản lý Văn bằng / Chứng chỉ: Thêm, Sửa, Xóa, Tìm kiếm, lọc theo trạng thái.
    /// </summary>
    public partial class FrmVanBang : Form
    {
        private readonly DBConnection _db = new DBConnection();

        public FrmVanBang()
        {
            InitializeComponent();
        }

        // ==============================
        // LOAD FORM
        // ==============================
        private void FrmVanBang_Load(object sender, EventArgs e)
        {
            LoadComboSinhVien();
            LoadComboNganhHoc();
            LoadComboDonViCap();

            cboXepLoai.Items.Clear();
            cboXepLoai.Items.AddRange(new[] { "", "Xuất sắc", "Giỏi", "Khá", "Trung bình" });

            cboCapDo.Items.Clear();
            cboCapDo.Items.AddRange(new[] { "Đại học", "Cao học", "Cao đẳng", "Trung cấp", "Chứng chỉ" });

            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new[] { "Đang xử lý", "Đã cấp", "Thu hồi", "Mất" });

            cboLocTrangThai.Items.Clear();
            cboLocTrangThai.Items.AddRange(new[] { "-- Tất cả --", "Đang xử lý", "Đã cấp", "Thu hồi", "Mất" });
            cboLocTrangThai.SelectedIndex = 0;

            LoadVanBang();
        }

        private void LoadComboSinhVien()
        {
            LoadCombo("SELECT MaSV, MaSV + ' - ' + HoTen AS HienThi FROM SV ORDER BY MaSV",
                      cboSinhVien, "HienThi", "MaSV");
        }

        private void LoadComboNganhHoc()
        {
            LoadCombo("SELECT MaNH, MaNH + ' - ' + TenNH AS HienThi FROM NGANHHOC ORDER BY MaNH",
                      cboNganhHoc, "HienThi", "MaNH");
        }

        private void LoadComboDonViCap()
        {
            LoadCombo("SELECT MaDV, MaDV + ' - ' + TenDV AS HienThi FROM DONVICAP ORDER BY MaDV",
                      cboDonViCap, "HienThi", "MaDV");
        }

        private void LoadCombo(string sql, ComboBox cbo, string display, string value)
        {
            try
            {
                var da = new SqlDataAdapter(sql, _db.GetConnection());
                var dt = new DataTable();
                da.Fill(dt);
                cbo.DataSource = dt;
                cbo.DisplayMember = display;
                cbo.ValueMember = value;
            }
            catch (Exception ex) { ShowError("Lỗi tải combo: " + ex.Message); }
        }

        // ==============================
        // LOAD DỮ LIỆU VĂN BẰNG
        // ==============================
        private void LoadVanBang(string keyword = "", string trangThai = "")
        {
            try
            {
                string sql = @"SELECT v.SoHieuVB, s.HoTen, v.TenVB, v.XepLoaiVB, v.CapDo,
                                      v.NgayCap, d.TenDV, v.TrangThai
                               FROM VB v
                               INNER JOIN SV s        ON v.MaSV = s.MaSV
                               INNER JOIN NGANHHOC n  ON v.MaNH = n.MaNH
                               INNER JOIN DONVICAP d  ON v.MaDV = d.MaDV
                               WHERE 1=1";

                if (!string.IsNullOrEmpty(keyword))
                    sql += " AND (v.SoHieuVB LIKE @kw OR s.HoTen LIKE @kw OR v.TenVB LIKE @kw)";
                if (!string.IsNullOrEmpty(trangThai) && trangThai != "-- Tất cả --")
                    sql += " AND v.TrangThai = @tt";
                sql += " ORDER BY v.NgayCap DESC";

                var da = new SqlDataAdapter(sql, _db.GetConnection());
                if (!string.IsNullOrEmpty(keyword)) da.SelectCommand.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                if (!string.IsNullOrEmpty(trangThai) && trangThai != "-- Tất cả --")
                    da.SelectCommand.Parameters.AddWithValue("@tt", trangThai);

                var dt = new DataTable();
                da.Fill(dt);
                dgvVanBang.DataSource = dt;
                lblSoLuong.Text = $"Tổng: {dt.Rows.Count} văn bằng";

                if (dgvVanBang.Columns.Count > 0)
                {
                    dgvVanBang.Columns["SoHieuVB"].HeaderText = "Số hiệu VB";
                    dgvVanBang.Columns["HoTen"].HeaderText = "Sinh viên";
                    dgvVanBang.Columns["TenVB"].HeaderText = "Tên văn bằng";
                    dgvVanBang.Columns["XepLoaiVB"].HeaderText = "Xếp loại";
                    dgvVanBang.Columns["CapDo"].HeaderText = "Cấp độ";
                    dgvVanBang.Columns["NgayCap"].HeaderText = "Ngày cấp";
                    dgvVanBang.Columns["TenDV"].HeaderText = "Đơn vị cấp";
                    dgvVanBang.Columns["TrangThai"].HeaderText = "Trạng thái";
                }
            }
            catch (Exception ex) { ShowError("Lỗi tải văn bằng: " + ex.Message); }
        }

        // ==============================
        // CHỌN DÒNG GRID
        // ==============================
        private void dgvVanBang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                string soHieu = dgvVanBang.Rows[e.RowIndex].Cells["SoHieuVB"].Value.ToString();
                string sqlDetail = "SELECT * FROM VB WHERE SoHieuVB = @sh";
                var da = new SqlDataAdapter(sqlDetail, _db.GetConnection());
                da.SelectCommand.Parameters.AddWithValue("@sh", soHieu);
                var dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0) return;

                DataRow row = dt.Rows[0];
                txtSoHieuVB.Text = row["SoHieuVB"].ToString();
                cboSinhVien.Text = row["MaSV"].ToString();
                cboNganhHoc.Text = row["MaNH"].ToString();
                txtTenVB.Text = row["TenVB"].ToString();
                cboXepLoai.Text = row["XepLoaiVB"].ToString();
                cboCapDo.Text = row["CapDo"].ToString();
                cboDonViCap.Text = row["MaDV"].ToString();
                cboTrangThai.Text = row["TrangThai"].ToString();
                if (row["NgayCap"] != DBNull.Value)
                    dtpNgayCap.Value = Convert.ToDateTime(row["NgayCap"]);
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        // ==============================
        // THÊM / SỬA / XÓA
        // ==============================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            try
            {
                _db.OpenConnection();
                string sql = @"INSERT INTO VB (SoHieuVB,MaSV,MaNH,TenVB,XepLoaiVB,CapDo,NgayCap,MaDV,TrangThai)
                               VALUES (@sh,@sv,@nh,@ten,@xl,@cd,@nc,@dv,@tt)";
                BuildCommand(sql).ExecuteNonQuery();
                ShowSuccess("Thêm văn bằng thành công!");
                LoadVanBang(); ClearForm();
            }
            catch (Exception ex) { ShowError("Lỗi thêm: " + ex.Message); }
            finally { _db.CloseConnection(); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoHieuVB.Text)) { ShowError("Vui lòng chọn văn bằng cần sửa!"); return; }
            if (!ValidateInput()) return;
            if (MessageBox.Show("Cập nhật văn bằng này?", "Xác nhận", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                _db.OpenConnection();
                string sql = @"UPDATE VB SET MaSV=@sv,MaNH=@nh,TenVB=@ten,XepLoaiVB=@xl,
                               CapDo=@cd,NgayCap=@nc,MaDV=@dv,TrangThai=@tt WHERE SoHieuVB=@sh";
                BuildCommand(sql).ExecuteNonQuery();
                ShowSuccess("Cập nhật văn bằng thành công!");
                LoadVanBang(); ClearForm();
            }
            catch (Exception ex) { ShowError("Lỗi sửa: " + ex.Message); }
            finally { _db.CloseConnection(); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoHieuVB.Text)) { ShowError("Vui lòng chọn văn bằng cần xóa!"); return; }
            if (MessageBox.Show($"Xóa văn bằng [{txtSoHieuVB.Text}]?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                _db.OpenConnection();
                var cmd = new SqlCommand("DELETE FROM VB WHERE SoHieuVB=@sh", _db.GetConnection());
                cmd.Parameters.AddWithValue("@sh", txtSoHieuVB.Text.Trim());
                cmd.ExecuteNonQuery();
                ShowSuccess("Xóa văn bằng thành công!");
                LoadVanBang(); ClearForm();
            }
            catch (Exception ex) { ShowError("Lỗi xóa: " + ex.Message); }
            finally { _db.CloseConnection(); }
        }

        private void btnLamMoi_Click(object sender, EventArgs e) => ClearForm();

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
            => LoadVanBang(txtTimKiem.Text.Trim(), cboLocTrangThai.SelectedItem?.ToString());

        private void cboLocTrangThai_SelectedIndexChanged(object sender, EventArgs e)
            => LoadVanBang(txtTimKiem.Text.Trim(), cboLocTrangThai.SelectedItem?.ToString());

        // ==============================
        // HỖ TRỢ
        // ==============================
        private SqlCommand BuildCommand(string sql)
        {
            var cmd = new SqlCommand(sql, _db.GetConnection());
            cmd.Parameters.AddWithValue("@sh", txtSoHieuVB.Text.Trim());
            cmd.Parameters.AddWithValue("@sv", cboSinhVien.SelectedValue ?? cboSinhVien.Text);
            cmd.Parameters.AddWithValue("@nh", cboNganhHoc.SelectedValue ?? cboNganhHoc.Text);
            cmd.Parameters.AddWithValue("@ten", txtTenVB.Text.Trim());
            cmd.Parameters.AddWithValue("@xl", cboXepLoai.Text.Trim());
            cmd.Parameters.AddWithValue("@cd", cboCapDo.Text.Trim());
            cmd.Parameters.AddWithValue("@nc", dtpNgayCap.Value.Date);
            cmd.Parameters.AddWithValue("@dv", cboDonViCap.SelectedValue ?? cboDonViCap.Text);
            cmd.Parameters.AddWithValue("@tt", cboTrangThai.Text.Trim());
            return cmd;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtSoHieuVB.Text)) { ShowError("Số hiệu VB không được để trống!"); return false; }
            if (string.IsNullOrWhiteSpace(txtTenVB.Text)) { ShowError("Tên văn bằng không được để trống!"); return false; }
            if (string.IsNullOrWhiteSpace(cboCapDo.Text)) { ShowError("Vui lòng chọn cấp độ!"); return false; }
            if (string.IsNullOrWhiteSpace(cboTrangThai.Text)) { ShowError("Vui lòng chọn trạng thái!"); return false; }
            return true;
        }

        private void ClearForm()
        {
            txtSoHieuVB.Clear(); txtTenVB.Clear(); txtTimKiem.Clear();
            cboSinhVien.SelectedIndex = -1; cboNganhHoc.SelectedIndex = -1;
            cboXepLoai.SelectedIndex = -1; cboCapDo.SelectedIndex = -1;
            cboDonViCap.SelectedIndex = -1; cboTrangThai.SelectedIndex = -1;
            dtpNgayCap.Value = DateTime.Now;
            lblThongBao.Text = string.Empty;
            txtSoHieuVB.Focus();
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
