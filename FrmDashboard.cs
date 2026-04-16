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
    /// Form Tổng quan — hiển thị các thẻ thống kê và bảng danh sách văn bằng gần đây.
    /// </summary>
    public partial class FrmDashboard : Form
    {
        private readonly DBConnection _db = new DBConnection();

        public FrmDashboard()
        {
            InitializeComponent();
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            LoadThongKe();
            LoadVanBangGanDay();
        }

        // ==============================
        // LOAD THỐNG KÊ (4 thẻ KPI)
        // ==============================
        private void LoadThongKe()
        {
            try
            {
                int soSV = GetCount("SELECT COUNT(*) FROM SV");
                int soVB = GetCount("SELECT COUNT(*) FROM VB");
                int soYC = GetCount("SELECT COUNT(*) FROM YEUCAUCAPLAI WHERE TrangThai = N'Đang xử lý'");
                int soDV = GetCount("SELECT COUNT(*) FROM DONVICAP");

                lblSoSinhVien.Text = soSV.ToString();
                lblSoVanBang.Text = soVB.ToString();
                lblSoYeuCau.Text = soYC.ToString();
                lblSoDonViCap.Text = soDV.ToString();

                // Thống kê trạng thái văn bằng
                LoadThongKeTrangThai();
            }
            catch (Exception ex)
            {
                lblSoSinhVien.Text = lblSoVanBang.Text = lblSoYeuCau.Text = lblSoDonViCap.Text = "—";
            }
        }

        private int GetCount(string sql)
        {
            var cmd = new SqlCommand(sql, _db.GetConnection());
            _db.OpenConnection();
            int val = (int)cmd.ExecuteScalar();
            _db.CloseConnection();
            return val;
        }

        private void LoadThongKeTrangThai()
        {
            try
            {
                string sql = "SELECT TrangThai, COUNT(*) AS SoLuong FROM VB GROUP BY TrangThai";
                var da = new SqlDataAdapter(sql, _db.GetConnection());
                var dt = new DataTable();
                da.Fill(dt);

                int dacap = 0, dangxuly = 0, thuhoi = 0, mat = 0;
                foreach (DataRow row in dt.Rows)
                {
                    switch (row["TrangThai"].ToString())
                    {
                        case "Đã cấp": dacap = Convert.ToInt32(row["SoLuong"]); break;
                        case "Đang xử lý": dangxuly = Convert.ToInt32(row["SoLuong"]); break;
                        case "Thu hồi": thuhoi = Convert.ToInt32(row["SoLuong"]); break;
                        case "Mất": mat = Convert.ToInt32(row["SoLuong"]); break;
                    }
                }

                lblDaCap.Text = $"Đã cấp: {dacap}";
                lblDangXuLy.Text = $"Đang xử lý: {dangxuly}";
                lblThuHoi.Text = $"Thu hồi: {thuhoi}";
                lblMat.Text = $"Mất: {mat}";
            }
            catch { }
        }

        // ==============================
        // VĂN BẰNG GẦN ĐÂY
        // ==============================
        private void LoadVanBangGanDay()
        {
            try
            {
                string sql = @"SELECT TOP 10 v.SoHieuVB, s.HoTen, v.TenVB, v.CapDo,
                                      CONVERT(VARCHAR,v.NgayCap,103) AS NgayCap,
                                      d.TenDV, v.TrangThai
                               FROM VB v
                               INNER JOIN SV s        ON v.MaSV = s.MaSV
                               INNER JOIN DONVICAP d  ON v.MaDV = d.MaDV
                               ORDER BY v.NgayCap DESC";

                var da = new SqlDataAdapter(sql, _db.GetConnection());
                var dt = new DataTable();
                da.Fill(dt);
                dgvGanDay.DataSource = dt;

                if (dgvGanDay.Columns.Count > 0)
                {
                    dgvGanDay.Columns["SoHieuVB"].HeaderText = "Số hiệu";
                    dgvGanDay.Columns["HoTen"].HeaderText = "Sinh viên";
                    dgvGanDay.Columns["TenVB"].HeaderText = "Tên văn bằng";
                    dgvGanDay.Columns["CapDo"].HeaderText = "Cấp độ";
                    dgvGanDay.Columns["NgayCap"].HeaderText = "Ngày cấp";
                    dgvGanDay.Columns["TenDV"].HeaderText = "Đơn vị cấp";
                    dgvGanDay.Columns["TrangThai"].HeaderText = "Trạng thái";
                }
            }
            catch (Exception ex) { /* ẩn lỗi trên dashboard */ }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadThongKe();
            LoadVanBangGanDay();
        }
    }
}
