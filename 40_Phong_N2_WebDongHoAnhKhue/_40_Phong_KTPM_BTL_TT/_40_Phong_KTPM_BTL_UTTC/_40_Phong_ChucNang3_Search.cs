using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _40_Phong_KTPM_BTL_UTTC
{
    [TestClass]
    public class _40_Phong_ChucNang3_Search
    {
        public _40_Phong_PhuongThuc method_40_Phong = new _40_Phong_PhuongThuc();

        //Trường hợp 1: Tìm kiếm thành công từ khóa và có sản phẩm
        [TestMethod]
        public void TC31_40_Phong_Tim_Kiem_Thanh_Cong()
        {
            // Đọc dữ liệu đầu vào
            string keywords_40_Phong = "DW";

            ///Thực hiện tìm kiếm và tự động từ khóa vừa mới đọc
            ///Tìm kiếm đồng hồ : DW
            method_40_Phong._40_Phong_SearchClock(keywords_40_Phong);

            string resultactual_40_Phong = method_40_Phong._40_Phong_FindClockName();
            string resultexpected_40_Phong = "(203 Sản phẩm)";

            Assert.AreEqual(resultexpected_40_Phong, resultactual_40_Phong);

            //Dừng Chrome trong 3 giay
            Thread.Sleep(3000);
            //Đóng trình duyệt sau khi thực hiện xong test case
            method_40_Phong.driver_40_Phong.Quit();
        }

        ///Trường hợp 2:Tìm kiếm thành công từ khóa nhưng không tìm thấy sản phẩm
        [TestMethod]
        public void TC32_40_Phong_Tim_Kiem_That_Bai_Khong_Ton_Tai()
        {
            // Đọc dữ liệu đầu vào
            string keywords_40_Phong = "DongHoCat";

            ///Thực hiện tìm kiếm và tự động từ khóa vừa mới đọc
            /// Tìm đồng hồ : DongHoCat
            method_40_Phong._40_Phong_SearchClock(keywords_40_Phong);

            string resultactual_40_Phong = method_40_Phong._40_Phong_FindClockName();
            string resultexpected_40_Phong = "(0 Sản phẩm)";

            Assert.AreEqual(resultexpected_40_Phong, resultactual_40_Phong);

            //Dừng Chrome trong 3 giay
            Thread.Sleep(3000);
            //Đóng trình duyệt sau khi thực hiện xong test case
           method_40_Phong.driver_40_Phong.Quit();
        }

        ///Trường hợp 3: Tìm kiếm thành công từ khóa nhưng không tìm thấy 
        [TestMethod]
        public void TC33_40_Phong_Tim_Kiem_Trang_Can_Tim_Không_Tim_Thay()
        {
            // Đọc dữ liệu đầu vào
            string keywords_40_Phong = "";

            ///Thực hiện tìm kiếm và tự động từ khóa vừa mới đọc
            /// Tìm đồng hồ : DongHoCat
            method_40_Phong._40_Phong_SearchClock(keywords_40_Phong);

            string resultactual_40_Phong = method_40_Phong._40_Phong_GetWarningMessage();
            string resultexpected_40_Phong = "KHÔNG TÌM THẤY";

            Assert.AreEqual(resultexpected_40_Phong, resultactual_40_Phong);

            //Dừng Chrome trong 3 giay
            Thread.Sleep(3000);
            //Đóng trình duyệt sau khi thực hiện xong test case
            method_40_Phong.driver_40_Phong.Quit();
        }
    }
}
