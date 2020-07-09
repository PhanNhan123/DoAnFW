using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.Cmp;
using System.Linq;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.VisualBasic.CompilerServices;

namespace DoAnFW.Models
{
    public class StoreContext
    {
        public string ConnectionString { get; set; }
        public StoreContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public StoreContext()
        {
            this.ConnectionString = "";
        }
        public MySqlConnection GetConnection() //lấy connection 
        {
            return new MySqlConnection(ConnectionString);
        }
        //Nguoi dung
        public List<NguoiDung> GetNguoiDungs()
        {
            List<NguoiDung> list = new List<NguoiDung>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from nguoidung";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NguoiDung()
                        {
                            Ma = int.Parse(reader["Ma"].ToString()),
                            Ten = reader["Ten"].ToString(),
                            TaiKhoan = reader["TaiKhoan"].ToString(),
                            MatKhau = reader["MatKhau"].ToString()
                        });
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }
        public int InsertNguoiDung(NguoiDung nd)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into nguoidung values(@ma, @ten,@TK,@MK)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("ma", nd.Ma);
                cmd.Parameters.AddWithValue("ten", nd.Ten);
                cmd.Parameters.AddWithValue("TK", nd.TaiKhoan);
                cmd.Parameters.AddWithValue("MK", nd.MatKhau);
                return (cmd.ExecuteNonQuery());

            }
        }
        public int UpdateNguoiDung(NguoiDung nd)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "update nguoidung " +
                    "set Ten = @ten and TaiKhoan=@TK and MatKhau=@MK" +
                    " where Ma=@ma";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("ma", nd.Ma);
                cmd.Parameters.AddWithValue("ten", nd.Ten);
                cmd.Parameters.AddWithValue("TK", nd.TaiKhoan);
                cmd.Parameters.AddWithValue("MK", nd.MatKhau);
                return (cmd.ExecuteNonQuery());
            }
        }

        public int DeleteNguoiDung(string Id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "delete from nguoidung where Ma=@ma";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("ma", Id);
                return (cmd.ExecuteNonQuery());
            }
        }
        // Khách hàng
        public List<KhachHang> GetKhachHangs()
        {
            List<KhachHang> list = new List<KhachHang>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from khachhang";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new KhachHang()
                        {
                            MaKH = int.Parse(reader["MaKH"].ToString()),
                            TenKH = reader["TenKH"].ToString(),
                            SDT = reader["SĐT"].ToString(),
                            DiaChi = reader["DiaChi"].ToString()
                        });
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }
        public KhachHang GetKhachHangById(int id)
        {
            KhachHang a = new KhachHang();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string sql = "select * from khachhang where MaKH=@ma ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("ma", id);
                var result = cmd.ExecuteReader();
                while (result.Read())
                {
                    a.MaKH = id;
                    a.TenKH = result["TenKH"].ToString();
                    a.SDT = result["SĐT"].ToString();
                    a.DiaChi = result["DiaChi"].ToString();
                }
            }
            return a;
        }
        public int InsertKhachHang(KhachHang kh)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into khachhang(TenKH,SĐT,DiaChi) values(@ten,@SDT,@diachi)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("ten", kh.TenKH);
                cmd.Parameters.AddWithValue("SDT", kh.SDT);
                cmd.Parameters.AddWithValue("diachi", kh.DiaChi);
                return (cmd.ExecuteNonQuery());

            }
        }
        public int UpdateKhachHang(KhachHang kh)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "update khachhang " +
                    "set TenKH = @ten, SĐT=@sdt, DiaChi=@diachi" +
                    " where MaKH=" + kh.MaKH;
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("ten", kh.TenKH);
                cmd.Parameters.AddWithValue("sdt", kh.SDT);
                cmd.Parameters.AddWithValue("diachi", kh.DiaChi);
                return (cmd.ExecuteNonQuery());
            }
        }

        public int DeleteKhachHang(string Id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "delete from khachhang where MaKH=@ma";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("ma", Id);
                return (cmd.ExecuteNonQuery());
            }
        }
        //San Pham
        public int InsertSanPham(SanPham a)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string sql = "insert into SanPham (TenSP,MoTa,IMG,MaNH,Gia,TuongThich,Jack_cam,KichThuoc,CongNghe,TrongLuong) " +
                    "values (@ten,@mota,@IMG,@MaNH,@Gia,@TuongThich,@Jack,@Kthuoc,@CN,@TrongLuong)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("ten", a.TenSP);
                cmd.Parameters.AddWithValue("mota", a.MoTa);
                cmd.Parameters.AddWithValue("IMG", a.IMG);
                cmd.Parameters.AddWithValue("Gia", a.Gia);
                cmd.Parameters.AddWithValue("TuongThich", a.TuongThich);
                cmd.Parameters.AddWithValue("Jack", a.Jack_cam);
                cmd.Parameters.AddWithValue("Kthuoc", a.KichThuoc);
                cmd.Parameters.AddWithValue("CN", a.CongNghe);
                cmd.Parameters.AddWithValue("TrongLuong", a.TrongLuong);
                cmd.Parameters.AddWithValue("MaNH", a.MaNH);
                return (cmd.ExecuteNonQuery());
            }
        }
        public int UpdateSanPham(SanPham sp, string uniqueFileName)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = " update sanpham set TenSP=@ten, MoTa=@mota, IMG =@IMG, Gia=@Gia, TuongThich =@TuongThich, Jack_cam=@Jack_cam, KichThuoc =@Kthuoc and CongNghe=@CN, TrongLuong =@TrongLuong, MaNH =@MaNH where MaSP=" + sp.MaSP;
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("ten", sp.TenSP);
                cmd.Parameters.AddWithValue("mota", sp.MoTa);
                cmd.Parameters.AddWithValue("IMG", uniqueFileName);
                cmd.Parameters.AddWithValue("Gia", sp.Gia);
                cmd.Parameters.AddWithValue("TuongThich", sp.TuongThich);
                cmd.Parameters.AddWithValue("Jack_cam", sp.Jack_cam);
                cmd.Parameters.AddWithValue("Kthuoc", sp.KichThuoc);
                cmd.Parameters.AddWithValue("CN", sp.CongNghe);
                cmd.Parameters.AddWithValue("TrongLuong", sp.TrongLuong);
                cmd.Parameters.AddWithValue("MaNH", sp.MaNH);
                return (cmd.ExecuteNonQuery());
            }
        }

        public int DeleteSanPham(string Id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "delete from sanpham where MaSP=@ma";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("ma", Id);
                return (cmd.ExecuteNonQuery());
            }
        }

        public int GetIDSanPham(SanPham a)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string sql = "select MaSP " +
                    "from sanpham " +
                    "where TenSP=@ten " +
                    "and IMG =@IMG " +
                    "and Gia=@Gia " +
                    "and MaNH=@MaNH ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("ten", a.TenSP);
                cmd.Parameters.AddWithValue("IMG", a.IMG);
                cmd.Parameters.AddWithValue("Gia", a.Gia);
                cmd.Parameters.AddWithValue("MaNH", a.MaNH);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    return (int.Parse(reader["MaSP"].ToString()));
                }
            }
        }
        //TonKho
        public List<object> GetSPTonKho()
        {
            List<object> lt = new List<object>();
            using (MySqlConnection conn = GetConnection())
            {

                conn.Open();
                string str = "select * from tonkho, sanpham where tonkho.MaSP = sanpham.MaSP";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ob = new
                        {
                            IMG = reader["IMG"].ToString(),
                            MaSP = int.Parse(reader["MaSP"].ToString()),
                            TenSP = reader["TenSP"].ToString(),
                            MaKho = int.Parse(reader["MaKho"].ToString()),
                            SoLuongTon = int.Parse(reader["SoLuongTon"].ToString()),
                        };

                        lt.Add(ob);
                    }
                }

            }
            return lt;
        }
        public int InsertTonKho(int MaSP, int SoLuongTon)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into TonKho(MaSP,SoLuongTon) values(@MaSP,@SoLuongTon)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("MaSP", MaSP);
                cmd.Parameters.AddWithValue("SoLuongTon", SoLuongTon);

                return (cmd.ExecuteNonQuery());

            }
        }
        public int UpdateTonKHo(TonKho tk)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = " update tonkho set MaSP=@masp, SoLuongTon=@slton where MaKho=" + tk.MaKho;
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("masp", tk.MaSP);
                cmd.Parameters.AddWithValue("slton", tk.SoLuongTon);
                return (cmd.ExecuteNonQuery());
            }
        }
        public int DeleteSP_TonKho(string MaSP)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "delete from tonkho where MaSP=@ma";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("ma", MaSP);
                return (cmd.ExecuteNonQuery());
            }
        }
        // Hoa Don
        public List<HoaDon> GetHoaDons()
        {
            List<HoaDon> list = new List<HoaDon>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from hoadon";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new HoaDon()
                        {
                            MaHD = int.Parse(reader["MaHD"].ToString()),
                            MaNL = int.Parse(reader["MaNL"].ToString()),
                            MaKH = int.Parse(reader["MaKH"].ToString()),
                            NgayLap = Convert.ToDateTime(reader["NgayLap"].ToString()),
                            TongGia = float.Parse(reader["TongGia"].ToString()),
                            TrangThai = reader["TrangThai"].ToString()
                        });
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }
        public int InsertHoaDon(HoaDon hd)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into hoadon values(@mahd,@manl,@makh, @ngay,@Tong,@trangthai)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("mahd", hd.MaHD);
                cmd.Parameters.AddWithValue("manl", hd.MaNL);
                cmd.Parameters.AddWithValue("makh", hd.MaKH);
                cmd.Parameters.AddWithValue("ngay", hd.NgayLap);
                cmd.Parameters.AddWithValue("Tong", hd.TongGia);
                cmd.Parameters.AddWithValue("trangthai", hd.TrangThai);
                return (cmd.ExecuteNonQuery());

            }
        }
        public int UpdateHoaDon(HoaDon hd)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "update hoadon set MaNL = +@maNL , MaKH = @maKH, TongGia=@Tong, TrangThai =@trangthai where MaHD=" + hd.MaHD;
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("maNL", hd.MaNL);
                cmd.Parameters.AddWithValue("maKH", hd.MaKH);
                cmd.Parameters.AddWithValue("ngay", hd.NgayLap);
                cmd.Parameters.AddWithValue("Tong", hd.TongGia);
                cmd.Parameters.AddWithValue("trangthai", hd.TrangThai);
                return (cmd.ExecuteNonQuery());
            }
        }


        public int DeleteHoaDon(string Id)
        {

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "delete from hoadon where MaHD=" + Id;
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("ma", Id);
                return (cmd.ExecuteNonQuery());
            }
        }
        //Khuyen Mai
        public List<KhuyenMai> GetKhuyenMais()
        {
            List<KhuyenMai> list = new List<KhuyenMai>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from khuyenmai";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new KhuyenMai()
                        {
                            MaKM = int.Parse(reader["MaKM"].ToString()),
                            TenKM = reader["TenKM"].ToString(),
                            TiLe = float.Parse(reader["TiLe"].ToString()),
                            NgayBD = Convert.ToDateTime(reader["NgayBD"]),
                            NgayKT = Convert.ToDateTime(reader["NgayKT"]),
                        });
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;

        }
        public int InsertKhuyenMai(KhuyenMai km)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into khuyenmai(MaKH,TenKM,TiLe,NgayBD,NgayKT)values(@ma, @ten,@tl,@bd,@kt)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("ma", km.MaKM);
                cmd.Parameters.AddWithValue("ten", km.TenKM);
                cmd.Parameters.AddWithValue("tl", km.TiLe);
                cmd.Parameters.AddWithValue("bd", km.NgayBD);
                cmd.Parameters.AddWithValue("kt", km.NgayKT);
                return (cmd.ExecuteNonQuery());

            }
        }
        public int UpdateKhuyenMai(KhuyenMai km)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "update khuyenmai " +
                    "set TenKM = @ten " +
                    "and TiLe=@tl" +
                    "and NgayBD=@bd" +
                    "and NgayKT=@kt" +
                    " where Ma=@ma";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("ma", km.MaKM);
                cmd.Parameters.AddWithValue("ten", km.TenKM);
                cmd.Parameters.AddWithValue("tl", km.TiLe);
                cmd.Parameters.AddWithValue("bd", km.NgayBD);
                cmd.Parameters.AddWithValue("kt", km.NgayKT);
                return (cmd.ExecuteNonQuery());
            }
        }

        public int DeleteKhuyenMai(string Id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "delete from khuyenmai where Ma=@ma";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("ma", Id);
                return (cmd.ExecuteNonQuery());
            }
        }
        // Nhan Hieu
        public List<NhanHieu> GetNhanHieus()
        {
            List<NhanHieu> list = new List<NhanHieu>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from nhanhieu";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NhanHieu()
                        {
                            MaNH = reader["MaNH"].ToString(),
                            TenNH = reader["TenNH"].ToString(),
                            NoiSX = reader["NoiSX"].ToString(),
                        });
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }
        public int InsertNhanHieu(NhanHieu nh)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into nhanhieu values(@ma, @ten,@noi)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("ma", nh.MaNH);
                cmd.Parameters.AddWithValue("ten", nh.TenNH);
                cmd.Parameters.AddWithValue("noi", nh.NoiSX);
                return (cmd.ExecuteNonQuery());

            }
        }
        public int UpdateNhanHieu(NhanHieu nd)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "update nhanhieu " +
                    "set TenNH = @ten and NoiSX=@moi" +
                    " where Ma=@ma";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("ma", nd.MaNH);
                cmd.Parameters.AddWithValue("ten", nd.TenNH);
                cmd.Parameters.AddWithValue("noi", nd.NoiSX);
                return (cmd.ExecuteNonQuery());
            }
        }

        public int DeleteNhanHieu(string Id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "delete from nhanhieu where Ma=@ma";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("ma", Id);
                return (cmd.ExecuteNonQuery());
            }
        }
        //CTHD
        public List<CTHD> GetCTHDs()
        {
            List<CTHD> list = new List<CTHD>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from cthd";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new CTHD()
                        {
                            MaHD = int.Parse(reader["MaHD"].ToString()),
                            MaSP = int.Parse(reader["MaSP"].ToString()),
                            SoLuong = int.Parse(reader["SoLuong"].ToString()),
                            MaKM = int.Parse(reader["MaKM"].ToString()),
                            HTTT = reader["HTTT"].ToString()
                        });
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }
        public int InsertCTHD(CTHD hd)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into cthd(MaSP,MaHD,SoLuong,MaKH,HTTT) values(@masp,@mahd,@soluong, @MaKM,HTTT)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("masp", hd.MaSP);
                cmd.Parameters.AddWithValue("mahd", hd.MaHD);
                cmd.Parameters.AddWithValue("soluong", hd.SoLuong);
                cmd.Parameters.AddWithValue("MaKM", hd.MaKM);
                cmd.Parameters.AddWithValue("HTTT", hd.HTTT);
                return (cmd.ExecuteNonQuery());

            }
        }
        public int UpdateCTHD(CTHD hd)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "update cthd " +
                    "set SoLuong=@soluong and HTTT=@HTTT" +
                    " where MaHD=@mahd and MaSP=@masp and MaKM=@MaKM";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("masp", hd.MaSP);
                cmd.Parameters.AddWithValue("mahd", hd.MaHD);
                cmd.Parameters.AddWithValue("soluong", hd.SoLuong);
                cmd.Parameters.AddWithValue("MaKM", hd.MaKM);
                cmd.Parameters.AddWithValue("HTTT", hd.HTTT);
                return (cmd.ExecuteNonQuery());
            }
        }

        public int DeleteCTHD(CTHD ct)
        {

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "delete from cthd where MaHD=@ma and MaSP=@masp";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("ma", ct.MaHD);
                cmd.Parameters.AddWithValue("masp", ct.MaSP);
                return (cmd.ExecuteNonQuery());
            }
        }



        public List<SanPham> findAll()
        {
            List<SanPham> list = new List<SanPham>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from sanpham", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new SanPham()
                        {
                            MaSP = int.Parse(reader["MaSP"].ToString()),
                            TenSP = reader["TenSP"].ToString(),
                            MoTa = reader["Mota"].ToString(),
                            IMG = reader["IMG"].ToString(),
                            MaNH = reader["MaNH"].ToString(),
                            Gia = double.Parse(reader["Gia"].ToString()),
                            TuongThich = reader["TuongThich"].ToString(),
                            Jack_cam = reader["Jack_cam"].ToString(),
                            KichThuoc = reader["KichThuoc"].ToString(),
                            CongNghe = reader["CongNghe"].ToString(),
                            TrongLuong = reader["TrongLuong"].ToString()
                        });
                    }
                }


            }
            return list;
        }
        public SanPham find(int MaSP)
        {

            SanPham sp = new SanPham();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select * from sanpham where masp=" + MaSP;
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("ma", MaSP);
                using (var reader = cmd.ExecuteReader())
                {


                    reader.Read();

                    sp.TenSP = reader["TenSP"].ToString();
                    sp.MoTa = reader["Mota"].ToString();
                    sp.MaNH = reader["MaNH"].ToString();
                    sp.IMG = reader["IMG"].ToString();
                    sp.Gia = double.Parse(reader["Gia"].ToString());
                    sp.TuongThich = reader["TuongThich"].ToString();
                    sp.Jack_cam = reader["Jack_cam"].ToString();
                    sp.KichThuoc = reader["KichThuoc"].ToString();
                    sp.CongNghe = reader["CongNghe"].ToString();
                    sp.TrongLuong = reader["TrongLuong"].ToString();
                    sp.MaSP = int.Parse(reader["MaSP"].ToString());
                }
            }
            return (sp);
        }


        public List<SanPham> load_carousel()
        {
            List<SanPham> list = new List<SanPham>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT  * FROM `sanpham` ORDER BY MaSP DESC LIMIT 3 ", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new SanPham()
                        {
                            MaSP = int.Parse(reader["MaSP"].ToString()),
                            TenSP = reader["TenSP"].ToString(),
                            MoTa = reader["Mota"].ToString(),
                            IMG = reader["IMG"].ToString(),
                            MaNH = reader["MaNH"].ToString(),
                            Gia = double.Parse(reader["Gia"].ToString()),
                            TuongThich = reader["TuongThich"].ToString(),
                            Jack_cam = reader["Jack_cam"].ToString(),
                            KichThuoc = reader["KichThuoc"].ToString(),
                            CongNghe = reader["CongNghe"].ToString(),
                            TrongLuong = reader["TrongLuong"].ToString()
                        });
                    }
                }


            }
            return list;
        }










        //----------------------Admin Area----------------------

        //Login
        public NguoiDung Login(string user, string pass)
        {
            NguoiDung temp = new NguoiDung();
            temp.Ma = 0;
            MySqlConnection conn = GetConnection();
            conn.Open();
            string sql = "select Ma,Ten,TaiKhoan " +
                "from nguoidung " +
                "where TaiKhoan=@user and MatKhau=@pass " +
                "limit 1";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("user", user);
            cmd.Parameters.AddWithValue("pass", pass);
            var result = cmd.ExecuteReader();
            while (result.Read())
            {
                temp.Ma = int.Parse(result["Ma"].ToString());
                temp.TaiKhoan = result["TaiKhoan"].ToString();
                temp.Ten = result["Ten"].ToString();
                temp.MatKhau = null;
            }
            conn.Close();

            return temp;
        }



        //public string GetLastID(string tableName, string nameOfColumn)
        //{
        //    using (MySqlConnection conn = GetConnection())
        //    {
        //        string LastID;
        //        conn.Open();

        //        string sql = "select Max(@name) as Ma from " + tableName;
        //        MySqlCommand cmd = new MySqlCommand(sql, conn);
        //        cmd.Parameters.AddWithValue("name", nameOfColumn);
        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                LastID = reader["Ma"].ToString();
        //            }

        //        }
        //        return LastID;

        //    }
        //}
        public double Total()
        {
            double totalCost = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string sql = "select sum(TongGia) from HoaDon where TrangThai='đã thanh toán'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                totalCost = Convert.ToDouble(cmd.ExecuteScalar());
            }
            return totalCost;
        }

        public int Num_Customer()
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string sql = "select count(MaKH) from khachhang ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return count;
        }
        public double ExpectedCost()
        {
            double total = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string sql = "select sum(TongGia) from HoaDon";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                total = Convert.ToDouble(cmd.ExecuteScalar());
            }
            return total;
        }
        public int TotalSaleItem(int month, int year)
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                int n = month;
                conn.Open();
                string sql = "select sum(SoLuong) " +
                    "from hoadon, cthd " +
                    "where hoadon.MaHD =cthd.MaHD ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("month", month);
                cmd.Parameters.AddWithValue("year", year);
                object temp = cmd.ExecuteScalar();
                count = Convert.ToInt32(temp);
            }
            return count;
        }

        public List<object> GetBarChart()
        {
            List<ChartViewModel> list = new List<ChartViewModel>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                DateTime dt = DateTime.Now;
                int year = dt.Year;
                string sql = "SELECT month(NgayLap) as Month,sum(TongGia)as Sum " +
                "from hoadon " + " where year(NgayLap)= '" + year + "' " +
                "GROUP by month(NgayLap) ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //cmd.Parameters.AddWithValue("year", year);
                var result = cmd.ExecuteReader();
                while (result.Read())
                {
                    ChartViewModel chartViewModel = new ChartViewModel();
                    chartViewModel.Month = Convert.ToInt32(result["Month"]);
                    chartViewModel.Sum = Convert.ToDouble(result["Sum"]);
                    list.Add(chartViewModel);
                }
            }
            List<object> chartData = new List<object>();
            var lable = list.Select(p => p.Month).ToArray();
            var value = list.Select(p => p.Sum).ToArray();
            chartData.Add(lable);
            chartData.Add(value);
            return chartData;
        }
        public List<object> GetLineChart()
        {
            List<ChartViewModel> list = new List<ChartViewModel>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                DateTime dt = DateTime.Now;
                int month = dt.Month;
                int year = dt.Year;
                string sql = "SELECT day(NgayLap) as Day,sum(TongGia)as Sum " +
                "from hoadon " + " where month(NgayLap)= '" + month + "' and year(NgayLap)= '" + year + "' " +
                "GROUP by day(NgayLap)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //cmd.Parameters.AddWithValue("year", year);
                var result = cmd.ExecuteReader();
                while (result.Read())
                {
                    ChartViewModel chartViewModel = new ChartViewModel();
                    chartViewModel.Day = Convert.ToInt32(result["Day"]);
                    chartViewModel.Sum = Convert.ToDouble(result["Sum"]);
                    list.Add(chartViewModel);
                }
            }
            List<object> chartData = new List<object>();
            var lable = list.Select(p => p.Day).ToArray();
            var value = list.Select(p => p.Sum).ToArray();
            chartData.Add(lable);
            chartData.Add(value);
            return chartData;
        }

        public List<object> GetPieChart()
        {
            List<ChartViewModel> list = new List<ChartViewModel>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string sql = "SELECT sanpham.MaSP,TenSP,sum(cthd.SoLuong)as SL FROM sanpham,cthd where sanpham.MaSP=cthd.MaSP GROUP BY sanpham.MaSP,TenSP limit 5";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                var result = cmd.ExecuteReader();
                while (result.Read())
                {
                    ChartViewModel chartViewModel = new ChartViewModel();
                    chartViewModel.Name = result["TenSP"].ToString();
                    chartViewModel.Value = Convert.ToInt32(result["SL"]);
                    list.Add(chartViewModel);
                }
            }
            List<object> chartData = new List<object>();
            var lable = list.Select(p => p.Name).ToArray();
            var value = list.Select(p => p.Value).ToArray();
            chartData.Add(lable);
            chartData.Add(value);
            return chartData;
        }


        public List<object> GetQuarterChart()
        {
            List<ChartViewModel> list = new List<ChartViewModel>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string sql = "SELECT quarter(hoadon.NgayLap) as Quarter,sum(TongGia) as Tong from hoadon GROUP BY quarter(hoadon.NgayLap) ORDER BY quarter(hoadon.NgayLap) ASC";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                var result = cmd.ExecuteReader();
                while (result.Read())
                {
                    ChartViewModel chartViewModel = new ChartViewModel();
                    chartViewModel.Name = result["Quarter"].ToString();
                    chartViewModel.Value = Convert.ToInt32(result["Tong"]);
                    list.Add(chartViewModel);
                }
            }
            List<object> chartData = new List<object>();
            var lable = list.Select(p => p.Name).ToArray();
            var value = list.Select(p => p.Value).ToArray();
            chartData.Add(lable);
            chartData.Add(value);
            return chartData;
        }
        //San pham
        public List<object> GetListSPAdmin()
        {
            List<object> lt = new List<object>();
            using (MySqlConnection conn = GetConnection())
            {

                conn.Open();
                String sql = "select IMG, s.MaSP,TenSP,TenNH,Gia,SoLuongTon " +
                    "from sanpham s, tonkho t, nhanhieu h " +
                    "where s.MaSP=t.MaSP and h.MaNH=s.MaNH ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ob = new
                        {
                            IMG = reader["IMG"].ToString(),
                            MaSP = int.Parse(reader["MaSP"].ToString()),
                            TenSP = reader["TenSP"].ToString(),
                            TenNH = reader["TenNH"].ToString(),
                            Gia = double.Parse(reader["Gia"].ToString()),
                            SoLuongTon = int.Parse(reader["SoLuongTon"].ToString())
                        };

                        lt.Add(ob);
                    }
                }

            }
            return lt;
        }
        public HoaDon GetHoaDonById(int id)
        {

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string sql = "select * from hoadon where MAHD= @id limit 1";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id", id);
                var reader = cmd.ExecuteReader();
                HoaDon hd = new HoaDon();
                while (reader.Read())
                {
                    hd.MaHD = int.Parse(reader["MaHD"].ToString());
                    hd.MaNL = int.Parse(reader["MaNL"].ToString());
                    hd.MaKH = int.Parse(reader["MaKH"].ToString());
                    hd.NgayLap = Convert.ToDateTime(reader["NgayLap"].ToString());
                    hd.TongGia = float.Parse(reader["TongGia"].ToString());
                    hd.TrangThai = reader["TrangThai"].ToString();
                }
                return hd;
            }

        }

        public SanPham GetSanPhamById(int id)
        {

            using (MySqlConnection conn = GetConnection())
            {
                SanPham oj = new SanPham();
                conn.Open();
                string sql = "select * from sanpham where MaSP= @id limit 1 ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id", id);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    oj.MaSP = int.Parse(reader["MaSP"].ToString());
                    oj.TenSP = reader["TenSP"].ToString();
                    oj.MaNH = reader["MaNH"].ToString();
                    oj.MoTa = reader["MoTa"].ToString();
                    oj.IMG = reader["IMG"].ToString();
                    oj.Gia = double.Parse(reader["Gia"].ToString());
                    oj.TuongThich = reader["TuongThich"].ToString();
                    oj.Jack_cam = reader["Jack_cam"].ToString();
                    oj.KichThuoc = reader["KichThuoc"].ToString();
                    oj.CongNghe = reader["CongNghe"].ToString();
                    oj.TrongLuong = reader["TrongLuong"].ToString();
                }
                return oj;
            }

        }

        public TonKho GetTonKhoID(int id)
        {

            using (MySqlConnection conn = GetConnection())
            {
                TonKho tk = new TonKho();
                conn.Open();
                string sql = "select * from tonkho where MaSP= @id limit 1 ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id", id);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    tk.MaSP = int.Parse(reader["MaSP"].ToString());
                    tk.SoLuongTon = int.Parse(reader["SoLuongTon"].ToString());
                    tk.MaKho = int.Parse(reader["MaKho"].ToString());

                }
                return tk;
            }

        }

        //Nhan hieu

        public object GetNhanHieuById(int id)
        {

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string sql = "select * nhanhieu where MaNH=@ma";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                var reader = cmd.ExecuteReader();
                var oj = new
                {
                    MaNH = reader["MaNH"].ToString(),
                    TenNH = reader["TenNH"].ToString(),
                    NoiSX = reader["NoiSX"].ToString(),
                };
                return oj;
            }

        }

    }
}