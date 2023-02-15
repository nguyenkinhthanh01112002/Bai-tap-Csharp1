namespace AssignmentGiaiDoan1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QuanLiSinhVien quanLiSinhVien = new QuanLiSinhVien();
            while(true)
            {
                Console.WriteLine("..............UNG DUNG QUAN LY SINH VIEN.................");
                Console.WriteLine("1.Nhap thong tin sinh vien");
                Console.WriteLine("2.Xuat danh sach sinh vien");
                Console.WriteLine("3.Tim kiem hoc vien theo khoang diem");
                Console.WriteLine("4.Tim kiem hoc vien theo hoc luc");
                Console.WriteLine("5.Tim kiem hoc vien theo ma so va cap nhat thong tin sinh vien");
                Console.WriteLine("6.Sap xep hoc vien theo diem");
                Console.WriteLine("7.Xuat 5 hoc vien co diem cao nhat");
                Console.WriteLine("8.Tinh diem trung binh cua lop");
                Console.WriteLine("9.Xuat danh sach hoc vien co diem tren diem diem trung binh cua lop");
                Console.WriteLine("10.Tong hop so hoc vien theo hoc luc");
                Console.WriteLine("0.Thoat chuong trinh");

                int button = Convert.ToInt32(Console.ReadLine());
                switch(button)
                {
                    case 1:
                        {
                            bool check;
                            lenh3:
                            Console.Write("nhap vao ten cua sinh vien: ");
                            string tenSinhVien = Convert.ToString(Console.ReadLine());
                            do
                            {
                                check = true;                              
                                Console.Write("nhap vao dia chi email cua sinh vien: ");
                                string email = Convert.ToString(Console.ReadLine());
                                try
                                {
                                    KiemTraNgoaiLeEmail kiemTra = new KiemTraNgoaiLeEmail();
                                    kiemTra.kiemTraNgoaiLeEmail(email);
                                    do
                                    {
                                        check = true;
                                        
                                        try
                                        {
                                            lenh:
                                            Console.Write("nhap vao ma so sinh vien: ");
                                            string maSinhVien = Convert.ToString(Console.ReadLine());
                                            KiemTraNgoaiLeMaSinhVien kiemTraNgoaiLeMaSinhVien = new KiemTraNgoaiLeMaSinhVien();
                                            kiemTraNgoaiLeMaSinhVien.kiemTraNgoaiLeMaSinhVien(maSinhVien);
                                            if(quanLiSinhVien.kiemTraMaSinhVien(maSinhVien)==true)
                                            {
                                                Console.WriteLine("ma sinh vien ban vua nhap da ton tai");
                                                goto lenh;
                                            }                                          
                                            
                                            do
                                            {
                                                check = true;
                                                Console.Write("nhap vao diem cua sinh vien: ");
                                                try
                                                {
                                                    string diem = Convert.ToString(Console.ReadLine());
                                                    KiemTraNgoaiLeDiem kiemTraNgoaiLeDiem = new KiemTraNgoaiLeDiem();
                                                    kiemTraNgoaiLeDiem.kiemTraNgoaiLeDiem(diem);
                                                    double diemHopLe = Convert.ToDouble(diem);
                                                    SinhVien sinhVien = new SinhVien(tenSinhVien, diemHopLe, email, maSinhVien);
                                                    quanLiSinhVien.themSinhVien(sinhVien);

                                                }
                                                catch (Exception ex)
                                                {
                                                    check = false;
                                                    Console.WriteLine(ex.Message);
                                                    Console.WriteLine("ban vui long nhap lai diem cua sinh vien!!!");
                                                }
                                            }
                                            while (check == false);
                                        }
                                        catch (Exception ex)
                                        {
                                            check = false;
                                            Console.WriteLine(ex.Message);
                                            Console.WriteLine("ban vui long nhap lai ma so sinh vien!!!");
                                        }
                                    }
                                    while (check == false);
                                }
                                catch (Exception ex)
                                {
                                    check = false;
                                    Console.WriteLine(ex.Message);

                                    Console.WriteLine("ban vui long nhap lai dia chi email!!!");
                                }
                                if(check== true)
                                {
                                    Console.Write("neu ban muon tiep tuc them sinh vien vui long bam yes nguoc lai bam no: ");
                                    string chon = Convert.ToString(Console.ReadLine());
                                    if (chon.ToLower().Equals("yes") == true)
                                    {
                                        goto lenh3;
                                    }
                                }                              
                            }
                            while (check == false);
                            Console.WriteLine();
                            break;
                        }
                    case 2:
                        {
                            quanLiSinhVien.xuatThongTinSinhVien();
                            Console.WriteLine();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("nhap vao khoang diem can tim kiem: ");
                            double diem1 = Convert.ToDouble(Console.ReadLine());
                            double diem2 = Convert.ToDouble(Console.ReadLine());
                            quanLiSinhVien.timKiemHocVienTheoKhoangDiem(Math.Min(diem1, diem2), Math.Max(diem1, diem2));
                            Console.WriteLine();
                            break;
                        }
                    case 4:
                        {
                            Console.Write("nhap vao hoc luc can tim: ");
                            string hocLucCanTim = Convert.ToString(Console.ReadLine());
                            quanLiSinhVien.timKiemSinhVienTheoHocLuc(hocLucCanTim);
                            Console.WriteLine();
                            break;
                        }
                    case 5:
                        {
                            Console.Write("nhap vao ma sinh vien can tim: ");
                            string maSinhVien = Convert.ToString(Console.ReadLine());
                            quanLiSinhVien.capNhatThongTinSinhVien(maSinhVien);
                            Console.WriteLine();
                            break;
                        }
                    case 6:
                        {
                            quanLiSinhVien.sapXepTheoDiemGiamDan();
                            quanLiSinhVien.xuatThongTinSinhVien();
                            Console.WriteLine();
                            break;
                        }
                    case 7:
                        {
                            quanLiSinhVien.xuatSinhVienDiemCao();
                            Console.WriteLine();
                            break;
                        }
                    case 8: 
                        {
                            Console.Write("diem trung binh cua lop la: "+ quanLiSinhVien.diemTrungBinh());
                            Console.WriteLine();
                            break;
                        }
                    case 9:
                        {
                            quanLiSinhVien.xuatSinhVienDiemTrenTrungBinh();
                            Console.WriteLine();
                            break;
                        }
                     case 10:
                        {
                            quanLiSinhVien.tongHopSoHocVienTheoHocLuc();
                            Console.WriteLine();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("du lieu khong hop le!!!");
                            continue;
                        }
                }
            }
        }
    }
}