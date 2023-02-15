using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AssignmentGiaiDoan1
{
    internal class KiemTraNgoaiLeMaSinhVien
    {
        public void kiemTraNgoaiLeMaSinhVien(string maSinhVien)
        {
            string maSinhVienHopLe = "^pd[0-9]{5}$";
            bool check = Regex.IsMatch(maSinhVien,maSinhVienHopLe,RegexOptions.IgnoreCase);
            if (check==false) 
            {
                throw new ThongBaoNgoaiLe("ma sinh vien ban vua nhap khong hop le");
            }
        }
    }
}
