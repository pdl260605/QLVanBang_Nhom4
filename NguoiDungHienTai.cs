using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVanBang_Nhom4
{
    /// <summary>
    /// Lưu thông tin người dùng đang đăng nhập trong phiên làm việc hiện tại.
    /// </summary>
    internal static class NguoiDungHienTai
    {
        public static string TenDangNhap { get; set; } = string.Empty;
        public static string HoTen { get; set; } = string.Empty;
        public static string VaiTro { get; set; } = string.Empty;

        public static bool IsAdmin => VaiTro == "Admin";

        public static void DangXuat()
        {
            TenDangNhap = string.Empty;
            HoTen = string.Empty;
            VaiTro = string.Empty;
        }
    }
}
