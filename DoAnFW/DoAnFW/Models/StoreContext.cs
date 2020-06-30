using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
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
        public int InsertKhachHang(KhachHang kh)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into khachhang values(@ma, @ten,@SDT,@diachi)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("ma", kh.MaKH);
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
                    "set TenKH = @ten and SĐT=@sdt and DiaChi=@diachi" +
                    " where MaKH=@ma";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("ma", kh.MaKH);
                cmd.Parameters.AddWithValue("ten", kh.TenKH);
                cmd.Parameters.AddWithValue("TK", kh.SDT);
                cmd.Parameters.AddWithValue("MK", kh.DiaChi);
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
                var str = "update hoadon " +
                    "TongGia=@Tong" +
                    "TrangThai =@trangthai" +
                    " where MaHD=@mahd and MaNL=@manl and MaKH=@makh";
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

        public int DeleteHoaDon(string Id)
        {

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "delete from hoadon where MaHD=@ma";
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
        //----------------------Admin Area----------------------





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



        //San pham
        public List<object> GetListSPAdmin()
        {
            List<object> lt = new List<object>();
            using (MySqlConnection conn = GetConnection())
            {

                conn.Open();
                String sql = "select s.MaSP,TenSP,TenNH,Gia,SoLuongTon " +
                    "from sanpham s, tonkho t, nhanhieu h " +
                    "where s.MaSP=t.MaSP and h.MaNH=s.MaNH ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ob = new
                        {
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

        public object GetSanPhamById(int id)
        {

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string sql = "select * sanpham where MaSP=@ma";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                var reader = cmd.ExecuteReader();
                var oj = new
                {
                    MaSP = int.Parse(reader["MaSP"].ToString()),
                    TenSP = reader["TenSP"].ToString(),
                    MaNH = reader["MaNH"].ToString(),
                    IMG = reader["IMG"].ToString(),
                    Gia = double.Parse(reader["Gia"].ToString()),
                    TuongThich = reader["TuongThich"].ToString(),
                    Jack_cam = reader["Jack_cam"].ToString(),
                    KichThuoc = reader["KichThuoc"].ToString(),
                    CongNghe = reader["CongNghe"].ToString(),
                    TrongLuong = reader["TrongLuong"].ToString()
                };
                return oj;
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