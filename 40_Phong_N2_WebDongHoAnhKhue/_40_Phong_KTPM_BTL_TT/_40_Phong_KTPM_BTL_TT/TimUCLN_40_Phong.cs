using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _40_Phong_KTPM_BTL_TT
{
    public partial class TimUCLN_40_Phong : Form
    {
        public LopDungChung_40_Phong method_40_Phong = new LopDungChung_40_Phong();
        public TimUCLN_40_Phong()
        {
            InitializeComponent();
        }

        private void btnCompute_40_Phong_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã nhập vào cả hai số hay chưa
            if (!int.TryParse(txtSoA_40_Phong.Text, out int a) || !int.TryParse(txtSoB_40_Phong.Text, out int b))
            {
                MessageBox.Show("Vui lòng nhập vào hai số nguyên dương.");
                return;
            }
            if (a <= 0 || b <= 0)
            {
                MessageBox.Show("Vui lòng nhập vào hai số nguyên dương.");
                return;
            }
            // Tính ước chung lớn nhất
            int gcd_ab_40_Phong = method_40_Phong.GCD_40_Phong(a, b);

            // Hiển thị kết quả
            lbKqUCLN_40_Phong.Text = "Ước chung lớn nhất: " + gcd_ab_40_Phong.ToString();

        }
    }
}

