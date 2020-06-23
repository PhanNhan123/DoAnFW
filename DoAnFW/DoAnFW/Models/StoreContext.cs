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
        private MySqlConnection GetConnection() //lấy connection 
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
                            TaiKhoan=reader["TaiKhoan"].ToString(),
                            MatKhau= reader["MatKhau"].ToString()
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
        // Hoa Don
        //Khuyen Mai
        // Nhan Hieu
        //CTHD

    }
} 