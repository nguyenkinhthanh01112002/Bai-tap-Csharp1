using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentGiaiDoan1
{
    internal class QuanLiSinhVien
    {
        private List<SinhVien> listSinhVien;
        public QuanLiSinhVien()
        {
            this.listSinhVien = new List<SinhVien>();
        }
        //them sinh vien vao danh sach can quan li
        public void themSinhVien(SinhVien sinhVien)
        {
            listSinhVien.Add(sinhVien);
        }
        //xuat thong tin sinh vien
        public void xuatThongTinSinhVien()
        {

            if (listSinhVien != null && listSinhVien.Count() > 0)
            {
                foreach(SinhVien sinhVien in listSinhVien)
                {
                    Console.WriteLine("" + sinhVien.ToString());
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("du lieu ban tim kiem khong ton tai");

            }

        }
        //tim kiem sinh vien theo khoang diem nhap tu ban phim
        public void timKiemHocVienTheoKhoangDiem(double diemMin, double diemMax)
        {
            bool check = false;
            if (listSinhVien != null && listSinhVien.Count > 0)
            {
                foreach (SinhVien sinhVien in listSinhVien)
                {
                    if (sinhVien.getDiemSinhVien() >= diemMin && sinhVien.getDiemSinhVien() <= diemMax)
                    {
                        check = true;
                        Console.WriteLine(sinhVien.ToString());
                        Console.WriteLine();
                        
                    }
                }
                if(check==false)
                {
                    Console.WriteLine("du lieu ban tim khong ton tai");
                }
            }
            else
            {
                Console.WriteLine("du lieu ban tim khong ton tai");
                return;
            }                                  
            
        }
        //tim kiem sinh vien theo hoc luc
        public void timKiemSinhVienTheoHocLuc(string hocLucCanTim)
        {
            if(listSinhVien!=null&&listSinhVien.Count>0)
            {
                foreach (SinhVien sinhVien in listSinhVien)
                {
                    if (sinhVien.getHocLuc().ToLower().Equals(hocLucCanTim.ToLower()) == true)
                    {
                        Console.WriteLine(sinhVien.ToString());
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("du lieu khong ton tai");
            }
           
        }
        //kiem tra ma sinh vien la duy nhat
        public bool kiemTraMaSinhVien(string maSinhVien)
        {           
            if (listSinhVien!=null&&listSinhVien.Count()>0)
            {
                foreach(SinhVien sinhVien in listSinhVien)
                {
                    if(sinhVien.getMaSinhVien().ToLower().Equals(maSinhVien.ToLower()) == true)
                    {
                        return true;
                    }
                }             
            }
            return false;
            
        }
        //cap nhat thong tin sinh vien
        public void capNhatThongTinSinhVien(string maSinhVien)
        {
            //kiem tra co sinh vien nao can tim ton tai trong listSinhVien
            int count = 0;
            if(listSinhVien!=null&&listSinhVien.Count> 0)
            {
                foreach (SinhVien sinhVien in listSinhVien)
                {
                    if (sinhVien.getMaSinhVien().ToLower().Equals(maSinhVien.ToLower()))
                    {
                        count++;
                    }
                }
            }
            else
            {
                Console.WriteLine("du lieu danh sach sinh vien rong");
                return;
            }          
            if (count!=0)
            {
                foreach (SinhVien sinhVien in listSinhVien)
                {
                    if (sinhVien.getMaSinhVien().ToUpper().Equals(maSinhVien.ToUpper()))
                    {
                        Console.Write("nhap vao ho va ten cua sinh vien: ");
                        string name = Convert.ToString(Console.ReadLine());
                        if (name != null && name.Length > 0)
                        {
                            sinhVien.setTenSinhVien(name);
                        }
                        bool check;

                    //kiem tra ngoai le
                    lenh2:
                        check = true;
                        Console.Write("nhap vao dia chi email cua sinh vien: ");
                        string email = Convert.ToString(Console.ReadLine());
                        if(email!=null&&email.Length>0)
                        {
                            do
                            {
                              
                                if(check==false)
                                {
                                    goto lenh2;
                                }
                                try
                                {

                                    KiemTraNgoaiLeEmail kiemTraNgoaiLeEmail = new KiemTraNgoaiLeEmail();
                                    kiemTraNgoaiLeEmail.kiemTraNgoaiLeEmail(email);
                                    sinhVien.setEmail(email);


                                }
                                catch (Exception ex)
                                {
                                    check = false;
                                    Console.WriteLine(ex.Message);

                                }
                            }
                            while (check == false);
                        }

                    lenh1:
                        check = true;
                        Console.Write("nhap vao diem cua sinh vien: ");
                        string diemSinhVien = Convert.ToString(Console.ReadLine());
                        if(diemSinhVien!=null&&diemSinhVien.Length>0)
                        {
                            do
                            {                          
                                if(check == false)
                                {
                                    goto lenh1;
                                }
                                try
                                {
                                    KiemTraNgoaiLeDiem kiemTraNgoaiLeDiem = new KiemTraNgoaiLeDiem();
                                    kiemTraNgoaiLeDiem.kiemTraNgoaiLeDiem(diemSinhVien);
                                    sinhVien.setDiemSinhVien(Convert.ToDouble(diemSinhVien));
                                }
                                catch (Exception ex)
                                {
                                    check = false;
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            while (check == false);
                        }
                              
                    }
                }

            }
            else
            {
                Console.WriteLine("khong ton tai du lieu ma so sinh vien ban can tim");
            }
            Console.WriteLine("...........DANH SACH SINH VIEN SAU KHI CAP NHAT...........");
            xuatThongTinSinhVien();
        }
        public void sapXepTheoDiemGiamDan()
        {
            listSinhVien.Sort(delegate (SinhVien sinhVien1,SinhVien sinhVien2)
            {
               if(sinhVien1.getDiemSinhVien()>sinhVien2.getDiemSinhVien())
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            });
           
        }
        public void xuatSinhVienDiemCao()
        {
            sapXepTheoDiemGiamDan();
            if(listSinhVien.Count>=5)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(listSinhVien[i].ToString());
                }
            }
            else
            {
                for(int i=0;i<listSinhVien.Count;i++)
                {
                    Console.WriteLine(listSinhVien[i].ToString());
                    Console.WriteLine();
                }
            }
        }
        public double diemTrungBinh()
        {
            double sum = 0;
            for(int i=0;i<listSinhVien.Count;i++)
            {
                sum += listSinhVien[i].getDiemSinhVien();
            }
            return sum/listSinhVien.Count;
        }
        public void xuatSinhVienDiemTrenTrungBinh()
        {
            int count = 0;
            foreach(SinhVien sinhVien in listSinhVien)
            {
                
                if(sinhVien.getDiemSinhVien()>=diemTrungBinh())
                {
                    count++;
                   Console.WriteLine(sinhVien.ToString());
                  
                }               
            }
            if(count==0)
            {
                Console.WriteLine("khong ton tai sinh vien nao co diem tren trung binh");
            }
        }
        public void tongHopSoHocVienTheoHocLuc()
        {

            int countYeu = 0;
            int countTB = 0;
            int countKha = 0;
            int countGioi = 0;
            int countXS = 0;
            Console.WriteLine(".......THONG KE SINH VIEN CO HOC LUC YEU...........");
            foreach (SinhVien sinhVien in listSinhVien)
            {
                if (sinhVien.getHocLuc().ToLower().Equals("yeu") == true)
                {
                    countYeu++;
                    Console.WriteLine(sinhVien.ToString());
                }
            }
            if(countYeu==0)
            {
                Console.WriteLine("Sinh vien co hoc luc yeu: " + countYeu);
            }
            Console.WriteLine(".......THONG KE SINH VIEN CO HOC LUC TRUNG BINH...........");
            foreach (SinhVien sinhVien in listSinhVien)
            {
                if (sinhVien.getHocLuc().ToLower().Equals("trung binh") == true)
                {
                    countTB++;
                    Console.WriteLine(sinhVien.ToString());
                }
            }
            if (countTB == 0)
            {
                Console.WriteLine("Sinh vien co hoc luc trung binh: " + countTB);
            }
            Console.WriteLine(".......THONG KE SINH VIEN CO HOC LUC KHA...........");
            foreach (SinhVien sinhVien in listSinhVien)
            {
                if (sinhVien.getHocLuc().ToLower().Equals("kha") == true)
                {
                    countKha++;
                    Console.WriteLine(sinhVien.ToString());
                }
            }
            if(countKha==0)
            {
                Console.WriteLine("Sinh vien co hoc luc kha: " + countKha);
            }
            Console.WriteLine(".......THONG KE SINH VIEN CO HOC LUC GIOI...........");
            foreach (SinhVien sinhVien in listSinhVien)
            {
                if (sinhVien.getHocLuc().ToLower().Equals("gioi") == true)
                {
                    countGioi++;
                    Console.WriteLine(sinhVien.ToString());
                }
            }
            if(countGioi==0)
            {
                Console.WriteLine("Sinh vien co hoc luc gioi: " + countGioi);
            }
            Console.WriteLine(".......THONG KE SINH VIEN CO HOC LUC XUAT SAC...........");
            foreach (SinhVien sinhVien in listSinhVien)
            {
                if (sinhVien.getHocLuc().ToLower().Equals("xuat sac") == true)
                {
                    countXS++;
                    Console.WriteLine(sinhVien.ToString());
                }
            }
            if(countXS==0)
            {
                Console.WriteLine("Sinh vien co hoc luc xuat sac: " + countXS);
            }
        }
    }
   
}
