using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentGiaiDoan1
{
    internal class SinhVien
    {
        private string tenSinhVien;
        private double diemSinhVien;
        private string email;
        private string maSinhVien;
        public SinhVien(string tenSinhVien, double diemSinhVien, string email, string maSinhVien)
        {
            this.tenSinhVien = tenSinhVien;
            this.diemSinhVien = diemSinhVien;
            this.email = email;
            this.maSinhVien = maSinhVien;
        }
        public void setMaSinhVien(string maSinhVien)
        {
            this.maSinhVien = maSinhVien;
        }
        public string getMaSinhVien()
        {
            return this.maSinhVien;
        }
        public void setTenSinhVien(string tenSinhVien)
        {
            this.tenSinhVien = tenSinhVien;
            
        }
        public string getTenSinhVien()
        {
            return this.tenSinhVien;
        }
        public void setEmail(string email)
        {
            this.email = email;
        }
        public string getEmail()
        {
            return this.email;
        }
        public void setDiemSinhVien(double diemSinhVien)
        {
            this.diemSinhVien = diemSinhVien;
        }
        public double getDiemSinhVien()
        {
            return this.diemSinhVien;
        }
        public string getHocLuc()
        {
            if(this.diemSinhVien<3)
            {
                return "kem";
            }
            else if(this.diemSinhVien<5)
            {
                return "yeu";
            }
            else if(this.diemSinhVien<6.5)
            {
                return "trung binh";
            }
            else if(this.diemSinhVien<7.5)
            {
                return "kha";
            }
            else if(this.diemSinhVien<9)
            {
                return "gioi";
            }
            else
            {
                return "xuat sac";
            }
        }
        public override string? ToString()
        {
            return "Ho va ten: "+tenSinhVien+"\nMa Sinh Vien: "+maSinhVien+"\nEmail: "+email+"\nDiem: "+diemSinhVien+"\nXepLoai: "+getHocLuc();
        }
        
    }
}
