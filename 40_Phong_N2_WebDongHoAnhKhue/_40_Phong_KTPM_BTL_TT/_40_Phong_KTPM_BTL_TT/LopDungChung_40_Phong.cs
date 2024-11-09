using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _40_Phong_KTPM_BTL_TT
{
    public class LopDungChung_40_Phong
    {
        // Hàm tính ước chung lớn nhất (GCD)
        public int GCD_40_Phong(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
