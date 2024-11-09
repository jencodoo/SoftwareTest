using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _40_Phong_KTPM_BTL_UTTC
{
    [TestClass]
    public class _40_Phong_ChucNang1_Login
    {
        private _40_Phong_PhuongThuc method_40_Phong = new _40_Phong_PhuongThuc();

        //TestCase 1: Đăng nhập thành công với username_40_Phong và password_40_Phong đúng
        [TestMethod]
        public void TC11_40_Phong_Login_Thanh_Cong()
        {
            // Đọc dữ liệu đầu vào
            string username_40_Phong = "NguyenPhong";
            string password_40_Phong = "230110.pX";

            //Thực hiện đăng nhập và tự động username, password vừa mới đọc
            method_40_Phong._40_Phong_LoginWithNoAds(username_40_Phong, password_40_Phong);

            //Lấy URL thực tế là URL sau khi click button Đăng nhập
            string actualurl_40_Phong = method_40_Phong.driver_40_Phong.Url;

            //Đặt URL kỳ vọng theo đặc tả
            string expectedurl_40_Phong = "https://casio.anhkhue.com/";

            //So sánh URL kỳ vọng so với URL thực thế
            Assert.AreEqual(expectedurl_40_Phong, actualurl_40_Phong);

            Thread.Sleep(2000);
            //Kiểm tra xem có tồn tại user tên là "Tài khoản" hay không?
            Assert.IsTrue(method_40_Phong._40_Phong_GetUser().Contains("Tài khoản"));

            //Dừng Chrome trong 3 giây
            Thread.Sleep(5000);
            //Đóng trình duyệt sau khi thực hiện xong TestCase
            method_40_Phong.driver_40_Phong.Quit();
        }
        //TestCase2: Đăng nhập không thành công do không nhập username_40_Phong
        [TestMethod]
        public void TC12_40_Phong_Login_That_Bai_Nhap_Thieu_UserName()
        {
            // Đọc dữ liệu đầu vào
            string username_40_Phong = "";
            string password_40_Phong = "230110.pX";

            //Thực hiện đăng nhập và tự động username, password vừa mới đọc
            method_40_Phong._40_Phong_LoginWithNoAds(username_40_Phong, password_40_Phong);
            //Cảnh báo thực tế: Cảnh báo khi nhấn Button Đăng nhập
            string actalert_40_Phong = method_40_Phong._40_Phong_GetWarningMessage();

            //Cảnh báo kỳ vọng
            string expectalert_40_Phong = "Trường này bắt buộc nhập";
            // So sánh cảnh báo kỳ vọng với cảnh báo thực tế
            Assert.AreEqual(expectalert_40_Phong, actalert_40_Phong);

            //Dừng Chrome trong 3 giây
            Thread.Sleep(3000);
            //Đóng trình duyệt sau khi thực hiện xong TestCase
            method_40_Phong.driver_40_Phong.Quit();
        }

        //TestCase3 : Đăng nhập không thành công do không nhập password_40_Phong
        [TestMethod]
        public void TC13_40_Phong_Login_That_Bai_Nhap_Thieu_Password()
        {
            // Đọc dữ liệu đầu vào
            string username_40_Phong = "NguyenPhong";
            string password_40_Phong = "";

            //Thực hiện đăng nhập và tự động username, password vừa mới đọc
            method_40_Phong._40_Phong_LoginWithNoAds(username_40_Phong, password_40_Phong);

            //Cảnh báo thực tế: Cảnh báo khi nhấn Button Đăng nhập
            string actalert_40_Phong = method_40_Phong._40_Phong_GetWarningMessage();

            //Cảnh báo kỳ vọng
            string expectalert_40_Phong = "Trường này bắt buộc nhập";

            // So sánh cảnh báo kỳ vọng với cảnh báo thực tế
            Assert.AreEqual(expectalert_40_Phong, actalert_40_Phong);

            //Dừng 3 giây rồi 
            Thread.Sleep(3000);
            //Đóng trình duyệt sau khi thực hiện xong test case
            method_40_Phong.driver_40_Phong.Quit();
        }

        //TestCase4 : Đăng nhập không thành công với Tài khoản chưa đăng ký
        [TestMethod]
        public void TC14_40_Phong_Login_That_Bai_Nhap_User_ChuaDangKy()
        {
            // Đọc dữ liệu đầu vào
            string username = "TaiKhoanChuaDangKy";
            string password = "230110.pX";

            ///Thực hiện đăng nhập và tự động username, password vừa mới đọc
            method_40_Phong._40_Phong_LoginWithNoAds(username, password);

            //Cảnh báo thực tế: Cảnh báo khi nhấn Button Đăng nhập
            string actalert = method_40_Phong._40_Phong_GetWarningMessage();

            //Cảnh báo kỳ vọng
            string expectalert = "Tài khoản này không tồn tại";

            // So sánh cảnh báo kỳ vọng với cảnh báo thực tế
            Assert.AreEqual(expectalert, actalert);

            //Dừng 3 giây rồi 
            Thread.Sleep(3000);
            //Đóng trình duyệt sau khi thực hiện xong test case
            method_40_Phong.driver_40_Phong.Quit();
        }

        //TestCase5 : Đăng nhập không thành công với password sai
        [TestMethod]
        public void TC15_40_Phong_Login_That_Bai_Nhap_Password_Wrong()
        {
            // Đọc dữ liệu đầu vào
            string username = "NguyenPhong";
            string password = "PassWordWrong";

            ///Thực hiện đăng nhập và tự động username, password vừa mới đọc
            method_40_Phong._40_Phong_LoginWithNoAds(username, password);

            //Cảnh báo thực tế: Cảnh báo khi nhấn Button Đăng nhập
            string actalert = method_40_Phong._40_Phong_GetWarningMessage();

            //Cảnh báo kỳ vọng
            string expectalert = "Mật khẩu không đúng hoặc chưa được kích hoạt";

            // So sánh cảnh báo kỳ vọng với cảnh báo thực tế
            Assert.AreEqual(expectalert, actalert);

            //Dừng 3 giây rồi 
            Thread.Sleep(3000);
            //Đóng trình duyệt sau khi thực hiện xong test case
            method_40_Phong.driver_40_Phong.Quit();
        }
    }
}
