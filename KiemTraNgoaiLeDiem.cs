using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentGiaiDoan1
{
    internal class KiemTraNgoaiLeDiem
    {
        public void kiemTraNgoaiLeDiem(string diem)
        {
            double diemHopLe;
            if(double.TryParse(diem,out diemHopLe))
            {
                if(diemHopLe<0||diemHopLe>10)
                {
                    throw new ThongBaoNgoaiLe("diem ban vua nhap khong hop le");
                }    
            }
            else
            {
                throw new ThongBaoNgoaiLe("diem ban vua nhap khong hop le");
            }
        }
    }
}
