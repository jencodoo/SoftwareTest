using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _40_Phong_KTPM_BTL_UTTC
{
    [TestClass]
    public class _40_Phong_ChucNang2_ForgotPassWord
    {
        private _40_Phong_PhuongThuc method_40_Phong = new _40_Phong_PhuongThuc();
        
        //TestCase 1 : Khôi phục mật khẩu thành công nhập email đúng
        [TestMethod]
        public void TC21_40_Phong_Khoi_Phuc_Mat_Khau_Thanh_Cong()
        {
            // Đọc dữ liệu đầu vào
            string email_40_Phong = "2151050326phong@ou.edu.vn";

            ///Thực hiện đăng nhập và tự động email vừa mới đọc
            method_40_Phong._40_Phong_ForgotPassWord(email_40_Phong);

            //URL thực tế: URL khi nhấn Button Lấy lại mật khẩu
            string actualurl_40_Phong = method_40_Phong.driver_40_Phong.Url;

            //URL kỳ vọng
            string expectedurl_40_Phong = "https://casio.anhkhue.com/forgot";

            /// So sánh URL kỳ vọng với URL thực tế
            Assert.AreEqual(expectedurl_40_Phong, actualurl_40_Phong);

            Thread.Sleep(2000);
            //Kiểm tra xem có tồn tại user tên là "Tài khoản" hay không?
            Assert.IsTrue(method_40_Phong._40_Phong_GetMessage().Contains("Đã gửi yêu cầu tạo mới mật khẩu vào hộp thư 2151050326phong@ou.edu.vn"));

            //Dừng 3 giây rồi đóng Chrome
            Thread.Sleep(3000);
            //Đóng trình duyệt sau khi thực hiện xong TestCase
            method_40_Phong.driver_40_Phong.Quit();
        }

        //TestCase 2 : Khôi phục mật khẩu không thành công vì không nhập email 
        [TestMethod]
        public void TC22_40_Phong_Khoi_Phuc_Mat_Khau_Khong_Nhap_Email()
        {
            // Đọc dữ liệu đầu vào
            string email_40_Phong = "";

            ///Thực hiện đăng nhập và tự động email vừa mới đọc
            method_40_Phong._40_Phong_ForgotPassWord(email_40_Phong);

            string actalert_40_Phong = method_40_Phong._40_Phong_GetWarningMessage();

            //Cảnh báo kỳ vọng
            string expectalert_40_Phong = "username or email là bắt buộc.";
            // So sánh cảnh báo kỳ vọng với cảnh báo thực tế
            Assert.AreEqual(expectalert_40_Phong, actalert_40_Phong);

            //Dừng 3 giây rồi đóng Chrome
            Thread.Sleep(3000);
            //Đóng trình duyệt sau khi thực hiện xong TestCase
            method_40_Phong.driver_40_Phong.Quit();
        }

        //TestCase 3 : Khôi phục mật khẩu không thành công vì email không đúng
        [TestMethod]
        public void TC23_40_Phong_Khoi_Phuc_Tai_Khoan_That_Bai_Vi_Sai_Email()
        {
            // Đọc dữ liệu đầu vào
            string email_40_Phong = "emailchuadangky@ou.edu.vn";
           
            ///Thực hiện đăng nhập và tự động email vừa mới đọc
            method_40_Phong._40_Phong_ForgotPassWord(email_40_Phong);
           
            string actalert_40_Phong = method_40_Phong._40_Phong_GetMessage2();

            //Cảnh báo kỳ vọng
            string expectalert_40_Phong = "Điền thông tin để cung cấp lại mật khẩu";

            // So sánh URL kỳ vọng với URL thực tế
            Assert.AreEqual(expectalert_40_Phong, actalert_40_Phong);

            //Dừng 3 giây rồi đóng Chrome
            Thread.Sleep(3000);
            //Đóng trình duyệt sau khi thực hiện xong TestCase
            method_40_Phong.driver_40_Phong.Quit();
        }
    }
}
