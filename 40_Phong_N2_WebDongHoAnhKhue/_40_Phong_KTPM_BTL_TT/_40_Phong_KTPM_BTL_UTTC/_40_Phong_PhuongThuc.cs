using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace _40_Phong_KTPM_BTL_UTTC
{
    public class _40_Phong_PhuongThuc
    {
        public IWebDriver driver_40_Phong = new ChromeDriver();
        public _40_Phong_PhuongThuc() { }

        // Phương thức truy cập vào trang chủ casio.anhkhue.com
        public void _40_Phong_LoginHome()
        {
            driver_40_Phong.Navigate().GoToUrl("https://casio.anhkhue.com/");
        }

        // Phương thức truy cập vào trang login và thực hiện đăng nhập khi đang ở trang chủ
        public void _40_Phong_Login(string username_40_Phong, string password_40_Phong)
        {
            //Truy cập vào trang chủ
            _40_Phong_LoginHome();

            //Truy cập vào bảng đăng nhập
            IWebElement p_login = driver_40_Phong.FindElement(By.CssSelector("#infor > div > ul > li.list-inline-item.mx-0.ml-4.hover-orange.account > a"));
            p_login.Click();

            //Nhập username
            IWebElement p_user1 = driver_40_Phong.FindElement(By.Id("username"));
            p_user1.SendKeys(username_40_Phong);

            //Nhập password
            IWebElement p_pass = driver_40_Phong.FindElement(By.Name("password"));
            p_pass.SendKeys(password_40_Phong);
            
            //Click vào button đăng nhập
            IWebElement loginButton = driver_40_Phong.FindElement(By.XPath("//*[@id=\"js-form-login\"]/div/div[2]/div/form/div[2]/button"));
            loginButton.Click();
        }
        // Phương thức truy cập vào bảng đăng nhập và thực hiện đăng nhập khi đang ở trang chủ và reload nếu có quảng cáo
        public void _40_Phong_LoginWithNoAds(string user, string pass)
        {
            try
            {
                _40_Phong_Login(user, pass);
            }
            catch (NoSuchDriverException)
            {
                _40_Phong_Login(user, pass);
            }
        }
        //Phương thức 
        public string _40_Phong_GetUser()
        {
            IWebElement p_user = driver_40_Phong.FindElement(By.XPath("//*[@id=\"infor\"]/div/ul/li[3]/a"));
            string user = p_user.Text;
            return user;
        }
        // Phương thức 
        public string _40_Phong_GetWarningMessage()
        {
            IWebElement p_alertmess = driver_40_Phong.FindElement(By.ClassName("text-warning"));
            return p_alertmess.Text;
        }
        
        // Phương thức tự động truy cập chức năng Quên mật khẩu và tự động điền Email
        public void _40_Phong_ForgotPassWord(String username_40_Phong)
        {

            //Truy cập trang đăng nhập 
            driver_40_Phong.Navigate().GoToUrl("https://casio.anhkhue.com/login?action=login");

            //Truy cập vào mục Quên mật khẩu
            IWebElement p_forgotpass = driver_40_Phong.FindElement(By.CssSelector("#js-form-login > div > div.justify-content-center > div > form > div.form-group > p.mt-3.mb-0.d-lg-flex.justify-content-center > a"));
            p_forgotpass.Click();

            //Nhập email khôi phục
            IWebElement p_username = driver_40_Phong.FindElement(By.Name("usernameOrEmail"));
            p_username.SendKeys(username_40_Phong);

            //Click nút Lấy lại mật khẩu
            IWebElement p_submitbtn = driver_40_Phong.FindElement(By.CssSelector("#js-form-login > div > div.no-gutters.justify-content-center > div > form > div.form-group > button"));
            p_submitbtn.Click();
        }

        // Phương thức xử lý quảng cáo của ForgotPassWord
        public void _40_Phong_ForgotPassWithNoAds(string email_40_Phong)
        {
            try
            {
                _40_Phong_ForgotPassWord(email_40_Phong);
            }
            catch (ElementClickInterceptedException)
            {
                _40_Phong_ForgotPassWord(email_40_Phong);
            }
        }
        // Phương thức 
        public string _40_Phong_GetMessage()
        {
            IWebElement p_alertmess1 = driver_40_Phong.FindElement(By.CssSelector("#js-form-login > div > " +
                "div.no-gutters.justify-content-center > div > div > h3"));
            return p_alertmess1.Text;
        }
 

        public string _40_Phong_GetMessage2()
        {
            IWebElement p_alertmess2 = driver_40_Phong.FindElement(By.CssSelector("#js-form-login > div > " +
                "div.no-gutters.justify-content-center > div > form > div.py-3.pb-1 > div > label"));
            return p_alertmess2.Text;
        }

        //Phương thức tìm kiếm đồng hồ 
        public void _40_Phong_SearchClock(string keywords)
        {
            //Truy cập vào trang chủ
            _40_Phong_LoginHome();

            //Tại ô tìm kiếm, nhập vào đồng hồ cần tìm kiếm và nhấn Enter
            IWebElement p_searchbox = driver_40_Phong.FindElement(By.Id("js-timKiem"));

            //Điền vào từ khóa
            p_searchbox.SendKeys(keywords);

            IWebElement p_timkiem = driver_40_Phong.FindElement(By.CssSelector("#search-bar > div.input-group-append > button"));
            p_timkiem.Click();
        }

        public string _40_Phong_FindClockName()
        {
            // Tìm phần tử <p> chứa văn bản "Sản phẩm" trong phần tử có ID là "productlist"
            string p_productCountText = driver_40_Phong.FindElement(By.CssSelector("#productlist > p")).Text;
            // In ra văn bản của phần tử <p> tìm được
            return p_productCountText;
        }
    }
}
