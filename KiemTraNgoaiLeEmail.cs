using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AssignmentGiaiDoan1
{
    internal class KiemTraNgoaiLeEmail
    {
        public void kiemTraNgoaiLeEmail(string email) 
        {
            if (email == null)
            {
                throw new ArgumentNullException("ban chua nhap dia chi email");
            }
            string emailHopLe = "^([a-z0-9_\\.-]+)@([\\da-z\\.-]+)\\.([a-z\\.]{2,6})$";
            bool check = Regex.IsMatch(email, emailHopLe);
            if (check==false) 
            {
                throw new ThongBaoNgoaiLe("dia chi email ban vua nhap khong hop le");
            }
        }
    }
}
