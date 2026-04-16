using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLVanBang_Nhom4
{
    public partial class FrmLichSuHocTap : Form
    {
        private DBConnection db = new DBConnection();

        public FrmLichSuHocTap()
        {
            InitializeComponent();
        }

        // ================= LOAD FORM =================
        private void FrmLichSuHocTap_Load(object sender, EventArgs e)
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

                string query = "SELECT * FROM LICHSUHOCTAP";
                SqlDataAdapter da = new SqlDataAdapter(query, db.GetConnection());
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvLSHT.DataSource = dt;
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

                // SoHieuVB
                SqlDataAdapter daVB = new SqlDataAdapter("SELECT SoHieuVB FROM VB", db.GetConnection());
                DataTable dtVB = new DataTable();
                daVB.Fill(dtVB);
                cbSoHieuVB.DataSource = dtVB;
                cbSoHieuVB.DisplayMember = "SoHieuVB";
                cbSoHieuVB.ValueMember = "SoHieuVB";

                // MaNH
                SqlDataAdapter daNH = new SqlDataAdapter("SELECT MaNH FROM NGANHHOC", db.GetConnection());
                DataTable dtNH = new DataTable();
                daNH.Fill(dtNH);
                cbMaNH.DataSource = dtNH;
                cbMaNH.DisplayMember = "MaNH";
                cbMaNH.ValueMember = "MaNH";
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
        private void dgvLSHT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLSHT.Rows[e.RowIndex];

                cbSoHieuVB.Text = row.Cells["SoHieuVB"].Value?.ToString();
                cbMaNH.Text = row.Cells["MaNH"].Value?.ToString();
                dtNgayNhap.Value = Convert.ToDateTime(row.Cells["NgayNhapHoc"].Value);
                dtNgayKetThuc.Value = Convert.ToDateTime(row.Cells["NgayKetThuc"].Value);
                txtDiem.Text = row.Cells["DiemTichLuy"].Value?.ToString();
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();
            }
        }

        // ================= THÊM =================
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                db.OpenConnection();

                string query = @"INSERT INTO LICHSUHOCTAP
                                (SoHieuVB, MaNH, NgayNhapHoc, NgayKetThuc, DiemTichLuy, GhiChu)
                                VALUES (@SoHieuVB, @MaNH, @NgayNhapHoc, @NgayKetThuc, @Diem, @GhiChu)";

                SqlCommand cmd = new SqlCommand(query, db.GetConnection());

                cmd.Parameters.AddWithValue("@SoHieuVB", cbSoHieuVB.Text);
                cmd.Parameters.AddWithValue("@MaNH", cbMaNH.Text);
                cmd.Parameters.AddWithValue("@NgayNhapHoc", dtNgayNhap.Value);
                cmd.Parameters.AddWithValue("@NgayKetThuc", dtNgayKetThuc.Value);
                cmd.Parameters.AddWithValue("@Diem", string.IsNullOrEmpty(txtDiem.Text) ? (object)DBNull.Value : txtDiem.Text);
                cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm thành công!");
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
            if (dgvLSHT.CurrentRow == null) return;

            try
            {
                db.OpenConnection();

                int id = Convert.ToInt32(dgvLSHT.CurrentRow.Cells["MaLSHT"].Value);

                string query = @"UPDATE LICHSUHOCTAP
                                SET SoHieuVB=@SoHieuVB,
                                    MaNH=@MaNH,
                                    NgayNhapHoc=@NgayNhapHoc,
                                    NgayKetThuc=@NgayKetThuc,
                                    DiemTichLuy=@Diem,
                                    GhiChu=@GhiChu
                                WHERE MaLSHT=@ID";

                SqlCommand cmd = new SqlCommand(query, db.GetConnection());

                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@SoHieuVB", cbSoHieuVB.Text);
                cmd.Parameters.AddWithValue("@MaNH", cbMaNH.Text);
                cmd.Parameters.AddWithValue("@NgayNhapHoc", dtNgayNhap.Value);
                cmd.Parameters.AddWithValue("@NgayKetThuc", dtNgayKetThuc.Value);
                cmd.Parameters.AddWithValue("@Diem", string.IsNullOrEmpty(txtDiem.Text) ? (object)DBNull.Value : txtDiem.Text);
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
            if (dgvLSHT.CurrentRow == null) return;

            if (MessageBox.Show("Xóa bản ghi?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            try
            {
                db.OpenConnection();

                int id = Convert.ToInt32(dgvLSHT.CurrentRow.Cells["MaLSHT"].Value);

                string query = "DELETE FROM LICHSUHOCTAP WHERE MaLSHT=@ID";

                SqlCommand cmd = new SqlCommand(query, db.GetConnection());
                cmd.Parameters.AddWithValue("@ID", id);

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