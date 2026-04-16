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
    /// Form quản lý Ngành học: Thêm, Sửa, Xóa, Tìm kiếm.
    /// </summary>
    public partial class FrmNganhHoc : Form
    {
        private readonly DBConnection _db = new DBConnection();

        public FrmNganhHoc()
        {
            InitializeComponent();
        }

        private void FrmNganhHoc_Load(object sender, EventArgs e)
        {
            LoadComboDonViCap();

            cboTrinhDo.Items.Clear();
            cboTrinhDo.Items.AddRange(new[] { "", "Đại học", "Cao học", "Cao đẳng", "Trung cấp", "Chứng chỉ" });

            cboHinhThuc.Items.Clear();
            cboHinhThuc.Items.AddRange(new[] { "Chính quy", "Tại chức", "Từ xa", "Liên thông" });

            LoadNganhHoc();
        }

        private void LoadComboDonViCap()
        {
            try
            {
                var da = new SqlDataAdapter(
                    "SELECT MaDV, MaDV + ' - ' + TenDV AS HienThi FROM DONVICAP ORDER BY MaDV",
                    _db.GetConnection());
                var dt = new DataTable();
                da.Fill(dt);
                cboDonViCap.DataSource = dt;
                cboDonViCap.DisplayMember = "HienThi";
                cboDonViCap.ValueMember = "MaDV";
            }
            catch (Exception ex) { ShowError("Lỗi tải đơn vị: " + ex.Message); }
        }

        private void LoadNganhHoc(string keyword = "")
        {
            try
            {
                string sql = string.IsNullOrEmpty(keyword)
                    ? @"SELECT n.MaNH, n.TenNH, d.TenDV, n.TrinhDo, n.HinhThucDaoTao, n.ThoiGianDaoTao
                        FROM NGANHHOC n INNER JOIN DONVICAP d ON n.MaDV = d.MaDV ORDER BY n.MaNH"
                    : @"SELECT n.MaNH, n.TenNH, d.TenDV, n.TrinhDo, n.HinhThucDaoTao, n.ThoiGianDaoTao
                        FROM NGANHHOC n INNER JOIN DONVICAP d ON n.MaDV = d.MaDV
                        WHERE n.MaNH LIKE @kw OR n.TenNH LIKE @kw OR d.TenDV LIKE @kw
                        ORDER BY n.MaNH";

                var da = new SqlDataAdapter(sql, _db.GetConnection());
                if (!string.IsNullOrEmpty(keyword))
                    da.SelectCommand.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                var dt = new DataTable();
                da.Fill(dt);
                dgvNganhHoc.DataSource = dt;
                lblSoLuong.Text = $"Tổng: {dt.Rows.Count} ngành học";

                if (dgvNganhHoc.Columns.Count > 0)
                {
                    dgvNganhHoc.Columns["MaNH"].HeaderText = "Mã ngành";
                    dgvNganhHoc.Columns["TenNH"].HeaderText = "Tên ngành";
                    dgvNganhHoc.Columns["TenDV"].HeaderText = "Đơn vị cấp";
                    dgvNganhHoc.Columns["TrinhDo"].HeaderText = "Trình độ";
                    dgvNganhHoc.Columns["HinhThucDaoTao"].HeaderText = "Hình thức ĐT";
                    dgvNganhHoc.Columns["ThoiGianDaoTao"].HeaderText = "Thời gian ĐT";
                }
            }
            catch (Exception ex) { ShowError("Lỗi tải dữ liệu: " + ex.Message); }
        }

        private void dgvNganhHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                string maNH = dgvNganhHoc.Rows[e.RowIndex].Cells["MaNH"].Value.ToString();
                var da = new SqlDataAdapter("SELECT * FROM NGANHHOC WHERE MaNH=@maNH", _db.GetConnection());
                da.SelectCommand.Parameters.AddWithValue("@maNH", maNH);
                var dt = new DataTable(); da.Fill(dt);
                if (dt.Rows.Count == 0) return;
                DataRow row = dt.Rows[0];

                txtMaNH.Text = row["MaNH"].ToString();
                txtTenNH.Text = row["TenNH"].ToString();
                cboDonViCap.Text = row["MaDV"].ToString();
                cboTrinhDo.Text = row["TrinhDo"].ToString();
                cboHinhThuc.Text = row["HinhThucDaoTao"].ToString();
                txtThoiGian.Text = row["ThoiGianDaoTao"].ToString();
                txtMaNH.ReadOnly = true;
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            try
            {
                _db.OpenConnection();
                var check = new SqlCommand("SELECT COUNT(*) FROM NGANHHOC WHERE MaNH=@id", _db.GetConnection());
                check.Parameters.AddWithValue("@id", txtMaNH.Text.Trim());
                if ((int)check.ExecuteScalar() > 0) { ShowError("Mã ngành đã tồn tại!"); return; }

                string sql = @"INSERT INTO NGANHHOC (MaNH,TenNH,MaDV,TrinhDo,HinhThucDaoTao,ThoiGianDaoTao)
                               VALUES (@id,@ten,@dv,@td,@ht,@tg)";
                BuildCommand(sql).ExecuteNonQuery();
                ShowSuccess("Thêm ngành học thành công!");
                LoadNganhHoc(); ClearForm();
            }
            catch (Exception ex) { ShowError("Lỗi thêm: " + ex.Message); }
            finally { _db.CloseConnection(); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNH.Text)) { ShowError("Vui lòng chọn ngành học cần sửa!"); return; }
            if (!ValidateInput()) return;
            if (MessageBox.Show("Cập nhật ngành học này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                _db.OpenConnection();
                string sql = @"UPDATE NGANHHOC SET TenNH=@ten,MaDV=@dv,TrinhDo=@td,
                               HinhThucDaoTao=@ht,ThoiGianDaoTao=@tg WHERE MaNH=@id";
                BuildCommand(sql).ExecuteNonQuery();
                ShowSuccess("Cập nhật thành công!");
                LoadNganhHoc(); ClearForm();
            }
            catch (Exception ex) { ShowError("Lỗi sửa: " + ex.Message); }
            finally { _db.CloseConnection(); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNH.Text)) { ShowError("Vui lòng chọn ngành học cần xóa!"); return; }
            if (MessageBox.Show($"Xóa ngành [{txtMaNH.Text}] - {txtTenNH.Text}?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                _db.OpenConnection();
                var cmd = new SqlCommand("DELETE FROM NGANHHOC WHERE MaNH=@id", _db.GetConnection());
                cmd.Parameters.AddWithValue("@id", txtMaNH.Text.Trim());
                cmd.ExecuteNonQuery();
                ShowSuccess("Xóa thành công!");
                LoadNganhHoc(); ClearForm();
            }
            catch (SqlException sex) when (sex.Number == 547)
            {
                ShowError("Không thể xóa ngành học này vì đang có văn bằng hoặc lịch sử học tập liên kết!");
            }
            catch (Exception ex) { ShowError("Lỗi xóa: " + ex.Message); }
            finally { _db.CloseConnection(); }
        }

        private void btnLamMoi_Click(object sender, EventArgs e) => ClearForm();

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
            => LoadNganhHoc(txtTimKiem.Text.Trim());

        private SqlCommand BuildCommand(string sql)
        {
            var cmd = new SqlCommand(sql, _db.GetConnection());
            cmd.Parameters.AddWithValue("@id", txtMaNH.Text.Trim());
            cmd.Parameters.AddWithValue("@ten", txtTenNH.Text.Trim());
            cmd.Parameters.AddWithValue("@dv", cboDonViCap.SelectedValue ?? cboDonViCap.Text);
            cmd.Parameters.AddWithValue("@td", cboTrinhDo.Text.Trim());
            cmd.Parameters.AddWithValue("@ht", cboHinhThuc.Text.Trim());
            cmd.Parameters.AddWithValue("@tg", txtThoiGian.Text.Trim());
            return cmd;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaNH.Text)) { ShowError("Mã ngành không được để trống!"); return false; }
            if (string.IsNullOrWhiteSpace(txtTenNH.Text)) { ShowError("Tên ngành không được để trống!"); return false; }
            if (string.IsNullOrWhiteSpace(cboDonViCap.Text)) { ShowError("Vui lòng chọn đơn vị cấp!"); return false; }
            return true;
        }

        private void ClearForm()
        {
            txtMaNH.Clear(); txtMaNH.ReadOnly = false;
            txtTenNH.Clear(); txtThoiGian.Clear(); txtTimKiem.Clear();
            cboDonViCap.SelectedIndex = -1;
            cboTrinhDo.SelectedIndex = -1;
            cboHinhThuc.SelectedIndex = -1;
            lblThongBao.Text = string.Empty;
            txtMaNH.Focus();
        }

        private void ShowError(string msg) { lblThongBao.ForeColor = UIHelper.AccentRed; lblThongBao.Text = "⚠ " + msg; }
        private void ShowSuccess(string msg) { lblThongBao.ForeColor = UIHelper.AccentGreen; lblThongBao.Text = "✔ " + msg; }
    }

}
