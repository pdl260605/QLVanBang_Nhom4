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
    /// Form xem Lịch sử chỉnh sửa (Audit log). Chỉ đọc — không cho phép sửa/xóa.
    /// </summary>
    public partial class FrmLichSuChinhSua : Form
    {
        private readonly DBConnection _db = new DBConnection();

        public FrmLichSuChinhSua()
        {
            InitializeComponent();
        }

        private void FrmLichSuChinhSua_Load(object sender, EventArgs e)
        {
            cboLocBang.Items.Clear();
            cboLocBang.Items.AddRange(new[] { "-- Tất cả --", "SV", "VB", "DONVICAP", "NGANHHOC", "YEUCAUCAPLAI" });
            cboLocBang.SelectedIndex = 0;

            cboLocThaoTac.Items.Clear();
            cboLocThaoTac.Items.AddRange(new[] { "-- Tất cả --", "Thêm", "Sửa", "Xóa" });
            cboLocThaoTac.SelectedIndex = 0;

            LoadLichSu();
        }

        private void LoadLichSu(string keyword = "", string bang = "", string thaoTac = "")
        {
            try
            {
                string sql = @"SELECT CONVERT(VARCHAR(36), MaLS) AS MaLS,
                                      TenDangNhap, CONVERT(VARCHAR,ThoiGian,120) AS ThoiGian,
                                      BangBiTacDong, ThaoTac, ChiTiet
                               FROM LICHSUCHINHSUA WHERE 1=1";

                if (!string.IsNullOrEmpty(keyword))
                    sql += " AND (TenDangNhap LIKE @kw OR ChiTiet LIKE @kw)";
                if (!string.IsNullOrEmpty(bang) && bang != "-- Tất cả --")
                    sql += " AND BangBiTacDong = @bang";
                if (!string.IsNullOrEmpty(thaoTac) && thaoTac != "-- Tất cả --")
                    sql += " AND ThaoTac = @thao";
                sql += " ORDER BY ThoiGian DESC";

                var da = new SqlDataAdapter(sql, _db.GetConnection());
                if (!string.IsNullOrEmpty(keyword))
                    da.SelectCommand.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                if (!string.IsNullOrEmpty(bang) && bang != "-- Tất cả --")
                    da.SelectCommand.Parameters.AddWithValue("@bang", bang);
                if (!string.IsNullOrEmpty(thaoTac) && thaoTac != "-- Tất cả --")
                    da.SelectCommand.Parameters.AddWithValue("@thao", thaoTac);

                var dt = new DataTable();
                da.Fill(dt);
                dgvLichSu.DataSource = dt;
                lblSoLuong.Text = $"Tổng: {dt.Rows.Count} bản ghi";

                if (dgvLichSu.Columns.Count > 0)
                {
                    dgvLichSu.Columns["MaLS"].HeaderText = "Mã LS";
                    dgvLichSu.Columns["TenDangNhap"].HeaderText = "Người dùng";
                    dgvLichSu.Columns["ThoiGian"].HeaderText = "Thời gian";
                    dgvLichSu.Columns["BangBiTacDong"].HeaderText = "Bảng tác động";
                    dgvLichSu.Columns["ThaoTac"].HeaderText = "Thao tác";
                    dgvLichSu.Columns["ChiTiet"].HeaderText = "Chi tiết";

                    dgvLichSu.Columns["MaLS"].Width = 80;
                    dgvLichSu.Columns["TenDangNhap"].Width = 100;
                    dgvLichSu.Columns["ThoiGian"].Width = 130;
                    dgvLichSu.Columns["BangBiTacDong"].Width = 110;
                    dgvLichSu.Columns["ThaoTac"].Width = 70;
                    dgvLichSu.Columns["ChiTiet"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                lblSoLuong.Text = "Lỗi: " + ex.Message;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e) => ApplyFilter();
        private void cboLocBang_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilter();
        private void cboLocThaoTac_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilter();

        private void ApplyFilter()
            => LoadLichSu(txtTimKiem.Text.Trim(),
                          cboLocBang.SelectedItem?.ToString(),
                          cboLocThaoTac.SelectedItem?.ToString());

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng xuất Excel sẽ được tích hợp trong phiên bản tiếp theo.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

}
