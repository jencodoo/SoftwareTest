using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using _40_Phong_KTPM_BTL_TT;

namespace _40_Phong_KTPM_BTL_UCLN
{
    
    [TestClass]
    public class _40_Phong_ChucNang_01_UnitTest_UCLN
    {
        public TestContext TestContext { get; set; }
        public LopDungChung_40_Phong method_40_Phong = new LopDungChung_40_Phong();

        // Trường hợp 1 : Tìm UCLN của 2 số nguyên dương a và b khi a > b
        [TestMethod]
        public void TC01_40_Phong_GCD_SoALonHonSoB()
        {
            // Arrange
            int SoA_40_Phong = 20;
            int SoB_40_Phong = 5;
            int expected_40_Phong = 5;

            // Act
            int actual_40_Phong = method_40_Phong.GCD_40_Phong(SoA_40_Phong, SoB_40_Phong);

            // Assert
            Assert.AreEqual(expected_40_Phong, actual_40_Phong);
        }

        // Trường hợp 2 : Tìm UCLN của 2 số nguyên dương a và b khi a < b
        [TestMethod]
        public void TC02_40_Phong_GCD_SoANhoHonSoB()
        {
            // Arrange
            int SoA_40_Phong = 12;
            int SoB_40_Phong = 18;
            int expected_40_Phong = 6;

            // Act
            int actual_40_Phong = method_40_Phong.GCD_40_Phong(SoA_40_Phong, SoB_40_Phong);

            // Assert
            Assert.AreEqual(expected_40_Phong, actual_40_Phong);
        }

        // Trường hợp 3 : Tìm UCLN của 2 số nguyên dương a và b khi a = b
        [TestMethod]
        public void TC03_40_Phong_GCD_HaiSoBangNhau()
        {
            // Arrange
            int SoA_40_Phong = 24;
            int SoB_40_Phong = 24;
            int expected_40_Phong = 23;

            // Act
            int actual_40_Phong = method_40_Phong.GCD_40_Phong(SoA_40_Phong, SoB_40_Phong);

            // Assert
            Assert.AreEqual(expected_40_Phong, actual_40_Phong);
        }

        // Trường hợp 4: Tìm ước chung lớn nhất của 2 số nguyên dương a và b với bộ dữ liệu UCLN tạo sẵn
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\_40_Phong_DataUCLN\UCLN_40_Phong.csv",
            "UCLN_40_Phong#csv", DataAccessMethod.Sequential)]
        public void TC04_40_Phong_GCD_TongHop()
        {
            // Arrange
            int SoA_40_Phong = Convert.ToInt32(TestContext.DataRow[0]);
            int SoB_40_Phong = Convert.ToInt32(TestContext.DataRow[1]);
            int expected_40_Phong = Convert.ToInt32(TestContext.DataRow[2]);
            string result_40_Phong = TestContext.DataRow[3].ToString();

            // Act
            int actual_40_Phong = method_40_Phong.GCD_40_Phong(SoA_40_Phong, SoB_40_Phong);

            // Assert
            if (result_40_Phong == "Passed")
            {
                Assert.AreEqual(expected_40_Phong, actual_40_Phong);
            }
            else if (result_40_Phong == "Failed")
            {
                // Ghi lại kết quả thực tế và dự kiến
                Console.WriteLine($"Expected: {expected_40_Phong}, Actual: {actual_40_Phong}");

                // Assert.AreNotEqual để xác nhận rằng kết quả thực tế và kết quả kỳ vọng không giống nhau
                Assert.AreNotEqual(expected_40_Phong, actual_40_Phong,
                    $"Test case failed, but actual result ({actual_40_Phong}) " +
                    $"matches the expected result ({expected_40_Phong})");
            }
            else
            {
                Assert.Fail("Invalid value for Result");
            }
        }

    }
}
