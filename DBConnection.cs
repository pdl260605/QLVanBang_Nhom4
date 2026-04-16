using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVanBang_Nhom4
{
    /// <summary>
    /// Lớp quản lý kết nối CSDL SQL Server.
    /// Chuỗi kết nối được lấy từ App.config (key = "conn").
    /// </summary>
    internal class DBConnection
    {
        private readonly SqlConnection _conn;
        //Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = QLVANBANG_NHOM4; Integrated Security = True
        public DBConnection()
        {
            string strConn = "Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = QLVANBANG_NHOM4; Integrated Security = True";
            _conn = new SqlConnection(strConn);
        }

        /// <summary>Trả về đối tượng SqlConnection.</summary>
        public SqlConnection GetConnection() => _conn;

        /// <summary>Mở kết nối nếu chưa mở.</summary>
        public void OpenConnection()
        {
            if (_conn.State == ConnectionState.Closed)
                _conn.Open();
        }

        /// <summary>Đóng kết nối nếu đang mở.</summary>
        public void CloseConnection()
        {
            if (_conn.State == ConnectionState.Open)
                _conn.Close();
        }
    }
}
