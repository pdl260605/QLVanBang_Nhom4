using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLVanBang_Nhom4
{
    public partial class FrmYeuCauChinhSua : Form
    {
        private DBConnection db = new DBConnection();

        public FrmYeuCauChinhSua()
        {
            InitializeComponent();
        }

        // ================= LOAD =================
        private void FrmYeuCauChinhSua_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadComboBox();
        }

        // ================= LOAD DATA =================
        private void LoadData()
        {
            try
            {
                db.OpenConnection();

                string query = "SELECT * FROM YEUCAUCAPLAI";
                SqlDataAdapter da = new SqlDataAdapter(query, db.GetConnection());
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvYeuCau.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        // ================= LOAD COMBO =================
        private void LoadComboBox()
        {
            try
            {
                db.OpenConnection();

                SqlDataAdapter da = new SqlDataAdapter("SELECT SoHieuVB FROM VB", db.GetConnection());
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbSoHieuVB.DataSource = dt;
                cbSoHieuVB.DisplayMember = "SoHieuVB";
                cbSoHieuVB.ValueMember = "SoHieuVB";

                // Loại yêu cầu
                cbLoaiYeuCau.Items.Clear();
                cbLoaiYeuCau.Items.Add("Cấp lại");
                cbLoaiYeuCau.Items.Add("Chỉnh sửa");

                // Trạng thái
                cbTrangThai.Items.Clear();
                cbTrangThai.Items.Add("Đang xử lý");
                cbTrangThai.Items.Add("Đã duyệt");
                cbTrangThai.Items.Add("Từ chối");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load combobox: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        // ================= CLICK GRID =================
        private void dgvYeuCau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvYeuCau.Rows[e.RowIndex];

                txtMaYC.Text = row.Cells["MaYC"].Value?.ToString();
                cbSoHieuVB.Text = row.Cells["SoHieuVB"].Value?.ToString();
                cbLoaiYeuCau.Text = row.Cells["LoaiYeuCau"].Value?.ToString();
                txtLyDo.Text = row.Cells["LiDo"].Value?.ToString();
                dtNgayYeuCau.Value = Convert.ToDateTime(row.Cells["NgayYeuCau"].Value);
                cbTrangThai.Text = row.Cells["TrangThai"].Value?.ToString();
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();
            }
        }

        // ================= THÊM =================
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                db.OpenConnection();

                string query = @"INSERT INTO YEUCAUCAPLAI
                                (MaYC, SoHieuVB, LoaiYeuCau, LiDo, NgayYeuCau, TrangThai, GhiChu)
                                VALUES (@MaYC, @SoHieuVB, @LoaiYeuCau, @LiDo, @Ngay, @TrangThai, @GhiChu)";

                SqlCommand cmd = new SqlCommand(query, db.GetConnection());

                cmd.Parameters.AddWithValue("@MaYC", txtMaYC.Text);
                cmd.Parameters.AddWithValue("@SoHieuVB", cbSoHieuVB.Text);
                cmd.Parameters.AddWithValue("@LoaiYeuCau", cbLoaiYeuCau.Text);
                cmd.Parameters.AddWithValue("@LiDo", txtLyDo.Text);
                cmd.Parameters.AddWithValue("@Ngay", dtNgayYeuCau.Value);
                cmd.Parameters.AddWithValue("@TrangThai", cbTrangThai.Text);
                cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm yêu cầu thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        // ================= SỬA =================
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                db.OpenConnection();

                string query = @"UPDATE YEUCAUCAPLAI
                                SET SoHieuVB=@SoHieuVB,
                                    LoaiYeuCau=@LoaiYeuCau,
                                    LiDo=@LiDo,
                                    NgayYeuCau=@Ngay,
                                    TrangThai=@TrangThai,
                                    GhiChu=@GhiChu
                                WHERE MaYC=@MaYC";

                SqlCommand cmd = new SqlCommand(query, db.GetConnection());

                cmd.Parameters.AddWithValue("@MaYC", txtMaYC.Text);
                cmd.Parameters.AddWithValue("@SoHieuVB", cbSoHieuVB.Text);
                cmd.Parameters.AddWithValue("@LoaiYeuCau", cbLoaiYeuCau.Text);
                cmd.Parameters.AddWithValue("@LiDo", txtLyDo.Text);
                cmd.Parameters.AddWithValue("@Ngay", dtNgayYeuCau.Value);
                cmd.Parameters.AddWithValue("@TrangThai", cbTrangThai.Text);
                cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Cập nhật thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        // ================= XÓA =================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa yêu cầu này?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            try
            {
                db.OpenConnection();

                string query = "DELETE FROM YEUCAUCAPLAI WHERE MaYC=@MaYC";

                SqlCommand cmd = new SqlCommand(query, db.GetConnection());
                cmd.Parameters.AddWithValue("@MaYC", txtMaYC.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Xóa thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        // ================= RELOAD =================
        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}