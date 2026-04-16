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
    /// Form quản lý Yêu cầu cấp lại / chỉnh sửa văn bằng.
    /// Cho phép thêm mới, cập nhật trạng thái (Đã duyệt / Từ chối), tìm kiếm.
    /// </summary>
    public partial class FrmYeuCauCapLai : Form
    {
        private readonly DBConnection _db = new DBConnection();

        public FrmYeuCauCapLai()
        {
            InitializeComponent();
        }

        private void FrmYeuCauCapLai_Load(object sender, EventArgs e)
        {
            LoadComboVanBang();

            cboLoaiYeuCau.Items.Clear();
            cboLoaiYeuCau.Items.AddRange(new[] { "Cấp lại", "Chỉnh sửa" });

            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new[] { "Đang xử lý", "Đã duyệt", "Từ chối" });

            cboLocTrangThai.Items.Clear();
            cboLocTrangThai.Items.AddRange(new[] { "-- Tất cả --", "Đang xử lý", "Đã duyệt", "Từ chối" });
            cboLocTrangThai.SelectedIndex = 0;

            LoadYeuCau();
        }

        private void LoadComboVanBang()
        {
            try
            {
                var da = new SqlDataAdapter(
                    "SELECT SoHieuVB, SoHieuVB + ' - ' + TenVB AS HienThi FROM VB ORDER BY SoHieuVB",
                    _db.GetConnection());
                var dt = new DataTable();
                da.Fill(dt);
                cboVanBang.DataSource = dt;
                cboVanBang.DisplayMember = "HienThi";
                cboVanBang.ValueMember = "SoHieuVB";
            }
            catch (Exception ex) { ShowError("Lỗi tải văn bằng: " + ex.Message); }
        }

        private void LoadYeuCau(string keyword = "", string trangThai = "")
        {
            try
            {
                string sql = @"SELECT y.MaYC, v.TenVB, y.LoaiYeuCau, y.LiDo,
                                      CONVERT(VARCHAR,y.NgayYeuCau,103) AS NgayYeuCau, y.TrangThai
                               FROM YEUCAUCAPLAI y INNER JOIN VB v ON y.SoHieuVB = v.SoHieuVB
                               WHERE 1=1";
                if (!string.IsNullOrEmpty(keyword))
                    sql += " AND (y.MaYC LIKE @kw OR v.TenVB LIKE @kw OR y.LiDo LIKE @kw)";
                if (!string.IsNullOrEmpty(trangThai) && trangThai != "-- Tất cả --")
                    sql += " AND y.TrangThai = @tt";
                sql += " ORDER BY y.NgayYeuCau DESC";

                var da = new SqlDataAdapter(sql, _db.GetConnection());
                if (!string.IsNullOrEmpty(keyword))
                    da.SelectCommand.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                if (!string.IsNullOrEmpty(trangThai) && trangThai != "-- Tất cả --")
                    da.SelectCommand.Parameters.AddWithValue("@tt", trangThai);

                var dt = new DataTable();
                da.Fill(dt);
                dgvYeuCau.DataSource = dt;
                lblSoLuong.Text = $"Tổng: {dt.Rows.Count} yêu cầu";

                if (dgvYeuCau.Columns.Count > 0)
                {
                    dgvYeuCau.Columns["MaYC"].HeaderText = "Mã YC";
                    dgvYeuCau.Columns["TenVB"].HeaderText = "Văn bằng";
                    dgvYeuCau.Columns["LoaiYeuCau"].HeaderText = "Loại";
                    dgvYeuCau.Columns["LiDo"].HeaderText = "Lý do";
                    dgvYeuCau.Columns["NgayYeuCau"].HeaderText = "Ngày yêu cầu";
                    dgvYeuCau.Columns["TrangThai"].HeaderText = "Trạng thái";
                }
            }
            catch (Exception ex) { ShowError("Lỗi tải dữ liệu: " + ex.Message); }
        }

        private void dgvYeuCau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                string maYC = dgvYeuCau.Rows[e.RowIndex].Cells["MaYC"].Value.ToString();
                var da = new SqlDataAdapter("SELECT * FROM YEUCAUCAPLAI WHERE MaYC=@id", _db.GetConnection());
                da.SelectCommand.Parameters.AddWithValue("@id", maYC);
                var dt = new DataTable(); da.Fill(dt);
                if (dt.Rows.Count == 0) return;
                DataRow row = dt.Rows[0];

                txtMaYC.Text = row["MaYC"].ToString();
                cboVanBang.Text = row["SoHieuVB"].ToString();
                cboLoaiYeuCau.Text = row["LoaiYeuCau"].ToString();
                txtLiDo.Text = row["LiDo"].ToString();
                txtGhiChu.Text = row["GhiChu"].ToString();
                cboTrangThai.Text = row["TrangThai"].ToString();
                txtMaYC.ReadOnly = true;
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            try
            {
                _db.OpenConnection();
                var check = new SqlCommand("SELECT COUNT(*) FROM YEUCAUCAPLAI WHERE MaYC=@id", _db.GetConnection());
                check.Parameters.AddWithValue("@id", txtMaYC.Text.Trim());
                if ((int)check.ExecuteScalar() > 0) { ShowError("Mã yêu cầu đã tồn tại!"); return; }

                string sql = @"INSERT INTO YEUCAUCAPLAI (MaYC,SoHieuVB,LoaiYeuCau,LiDo,NgayYeuCau,TrangThai,GhiChu)
                               VALUES (@id,@vb,@loai,@lido,GETDATE(),@tt,@gc)";
                BuildCommand(sql).ExecuteNonQuery();
                ShowSuccess("Thêm yêu cầu thành công!");
                LoadYeuCau(); ClearForm();
            }
            catch (Exception ex) { ShowError("Lỗi thêm: " + ex.Message); }
            finally { _db.CloseConnection(); }
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaYC.Text)) { ShowError("Vui lòng chọn yêu cầu cần cập nhật!"); return; }
            if (string.IsNullOrEmpty(cboTrangThai.Text)) { ShowError("Vui lòng chọn trạng thái!"); return; }

            if (MessageBox.Show($"Cập nhật trạng thái thành [{cboTrangThai.Text}]?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                _db.OpenConnection();
                string sql = "UPDATE YEUCAUCAPLAI SET TrangThai=@tt, GhiChu=@gc WHERE MaYC=@id";
                var cmd = new SqlCommand(sql, _db.GetConnection());
                cmd.Parameters.AddWithValue("@tt", cboTrangThai.Text.Trim());
                cmd.Parameters.AddWithValue("@gc", txtGhiChu.Text.Trim());
                cmd.Parameters.AddWithValue("@id", txtMaYC.Text.Trim());
                cmd.ExecuteNonQuery();
                ShowSuccess("Cập nhật trạng thái thành công!");
                LoadYeuCau(); ClearForm();
            }
            catch (Exception ex) { ShowError("Lỗi cập nhật: " + ex.Message); }
            finally { _db.CloseConnection(); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaYC.Text)) { ShowError("Vui lòng chọn yêu cầu cần xóa!"); return; }
            if (MessageBox.Show($"Xóa yêu cầu [{txtMaYC.Text}]?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                _db.OpenConnection();
                var cmd = new SqlCommand("DELETE FROM YEUCAUCAPLAI WHERE MaYC=@id", _db.GetConnection());
                cmd.Parameters.AddWithValue("@id", txtMaYC.Text.Trim());
                cmd.ExecuteNonQuery();
                ShowSuccess("Xóa thành công!");
                LoadYeuCau(); ClearForm();
            }
            catch (Exception ex) { ShowError("Lỗi xóa: " + ex.Message); }
            finally { _db.CloseConnection(); }
        }

        private void btnLamMoi_Click(object sender, EventArgs e) => ClearForm();

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
            => LoadYeuCau(txtTimKiem.Text.Trim(), cboLocTrangThai.SelectedItem?.ToString());

        private void cboLocTrangThai_SelectedIndexChanged(object sender, EventArgs e)
            => LoadYeuCau(txtTimKiem.Text.Trim(), cboLocTrangThai.SelectedItem?.ToString());

        private SqlCommand BuildCommand(string sql)
        {
            var cmd = new SqlCommand(sql, _db.GetConnection());
            cmd.Parameters.AddWithValue("@id", txtMaYC.Text.Trim());
            cmd.Parameters.AddWithValue("@vb", cboVanBang.SelectedValue ?? cboVanBang.Text);
            cmd.Parameters.AddWithValue("@loai", cboLoaiYeuCau.Text.Trim());
            cmd.Parameters.AddWithValue("@lido", txtLiDo.Text.Trim());
            cmd.Parameters.AddWithValue("@tt", cboTrangThai.Text.Trim());
            cmd.Parameters.AddWithValue("@gc", txtGhiChu.Text.Trim());
            return cmd;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaYC.Text)) { ShowError("Mã yêu cầu không được để trống!"); return false; }
            if (string.IsNullOrWhiteSpace(cboVanBang.Text)) { ShowError("Vui lòng chọn văn bằng!"); return false; }
            if (string.IsNullOrWhiteSpace(cboLoaiYeuCau.Text)) { ShowError("Vui lòng chọn loại yêu cầu!"); return false; }
            if (string.IsNullOrWhiteSpace(txtLiDo.Text)) { ShowError("Lý do không được để trống!"); return false; }
            return true;
        }

        private void ClearForm()
        {
            txtMaYC.Clear(); txtMaYC.ReadOnly = false;
            txtLiDo.Clear(); txtGhiChu.Clear(); txtTimKiem.Clear();
            cboVanBang.SelectedIndex = -1;
            cboLoaiYeuCau.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = -1;
            lblThongBao.Text = string.Empty;
            txtMaYC.Focus();
        }

        private void ShowError(string msg) { lblThongBao.ForeColor = UIHelper.AccentRed; lblThongBao.Text = "⚠ " + msg; }
        private void ShowSuccess(string msg) { lblThongBao.ForeColor = UIHelper.AccentGreen; lblThongBao.Text = "✔ " + msg; }
    }

}
