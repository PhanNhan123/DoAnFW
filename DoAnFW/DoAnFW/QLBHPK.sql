-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Jun 03, 2020 at 05:06 PM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.4.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `QLBHPK`
--

-- --------------------------------------------------------

--
-- Table structure for table `CTHD`
--

CREATE TABLE `CTHD` (
  `MaSP` int(11) NOT NULL,
  `MaHD` int(11) NOT NULL,
  `SoLuong` int(11) NOT NULL,
  `MaKM` int(11) NOT NULL,
  `HTTT` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `HoaDon`
--

CREATE TABLE `HoaDon` (
  `MaHD` int(11) NOT NULL,
  `MaNL` int(11) NOT NULL,
  `MaKH` int(11) NOT NULL,
  `NgayLap` datetime NOT NULL,
  `TongGia` double DEFAULT NULL,
  `TrangThai` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `KhachHang`
--

CREATE TABLE `KhachHang` (
  `MaKH` int(11) NOT NULL,
  `TenKH` varchar(255) NOT NULL,
  `SĐT` varchar(12) NOT NULL,
  `DiaChi` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `KhuyenMai`
--

CREATE TABLE `KhuyenMai` (
  `MaKM` int(11) NOT NULL,
  `TenKM` varchar(255) DEFAULT NULL,
  `TiLe` float DEFAULT NULL,
  `NgayBD` datetime DEFAULT NULL,
  `NgayKT` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `NguoiDung`
--

CREATE TABLE `NguoiDung` (
  `Ma` int(11) NOT NULL,
  `Ten` varchar(255) NOT NULL,
  `TaiKhoan` varchar(255) NOT NULL,
  `MatKhau` varchar(255) DEFAULT '123456'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `NhanHieu`
--

CREATE TABLE `NhanHieu` (
  `MaNH` varchar(20) NOT NULL,
  `TenNH` varchar(20) NOT NULL,
  `NoiSX` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `SanPham`
--

CREATE TABLE `SanPham` (
  `MaSP` int(11) NOT NULL,
  `TenSP` varchar(255) NOT NULL,
  `MaNH` varchar(20) NOT NULL,
  `Gia` double DEFAULT NULL,
  `TuongThich` varchar(255) DEFAULT NULL,
  `Jack_cam` varchar(255) DEFAULT NULL,
  `KichThuoc` varchar(255) DEFAULT NULL,
  `CongNghe` varchar(255) DEFAULT NULL,
  `TrongLuong` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `TonKho`
--

CREATE TABLE `TonKho` (
  `MaKho` int(11) NOT NULL,
  `MaSP` int(11) DEFAULT NULL,
  `SoLuongTon` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `CTHD`
--
ALTER TABLE `CTHD`
  ADD KEY `MaHD` (`MaHD`),
  ADD KEY `MaSP` (`MaSP`),
  ADD KEY `MaKM` (`MaKM`);

--
-- Indexes for table `HoaDon`
--
ALTER TABLE `HoaDon`
  ADD PRIMARY KEY (`MaHD`),
  ADD KEY `MaNL` (`MaNL`),
  ADD KEY `MaKH` (`MaKH`);

--
-- Indexes for table `KhachHang`
--
ALTER TABLE `KhachHang`
  ADD PRIMARY KEY (`MaKH`),
  ADD UNIQUE KEY `SĐT` (`SĐT`);

--
-- Indexes for table `KhuyenMai`
--
ALTER TABLE `KhuyenMai`
  ADD PRIMARY KEY (`MaKM`);

--
-- Indexes for table `NguoiDung`
--
ALTER TABLE `NguoiDung`
  ADD PRIMARY KEY (`Ma`);

--
-- Indexes for table `NhanHieu`
--
ALTER TABLE `NhanHieu`
  ADD PRIMARY KEY (`MaNH`);

--
-- Indexes for table `SanPham`
--
ALTER TABLE `SanPham`
  ADD PRIMARY KEY (`MaSP`),
  ADD KEY `MaNH` (`MaNH`);

--
-- Indexes for table `TonKho`
--
ALTER TABLE `TonKho`
  ADD PRIMARY KEY (`MaKho`),
  ADD KEY `MaSP` (`MaSP`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `HoaDon`
--
ALTER TABLE `HoaDon`
  MODIFY `MaHD` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `KhachHang`
--
ALTER TABLE `KhachHang`
  MODIFY `MaKH` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `SanPham`
--
ALTER TABLE `SanPham`
  MODIFY `MaSP` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `TonKho`
--
ALTER TABLE `TonKho`
  MODIFY `MaKho` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `CTHD`
--
ALTER TABLE `CTHD`
  ADD CONSTRAINT `cthd_ibfk_1` FOREIGN KEY (`MaHD`) REFERENCES `HoaDon` (`MaHD`),
  ADD CONSTRAINT `cthd_ibfk_2` FOREIGN KEY (`MaSP`) REFERENCES `SanPham` (`MaSP`),
  ADD CONSTRAINT `cthd_ibfk_3` FOREIGN KEY (`MaKM`) REFERENCES `KhuyenMai` (`MaKM`);

--
-- Constraints for table `HoaDon`
--
ALTER TABLE `HoaDon`
  ADD CONSTRAINT `hoadon_ibfk_1` FOREIGN KEY (`MaNL`) REFERENCES `NguoiDung` (`Ma`),
  ADD CONSTRAINT `hoadon_ibfk_2` FOREIGN KEY (`MaKH`) REFERENCES `KhachHang` (`MaKH`);

--
-- Constraints for table `SanPham`
--
ALTER TABLE `SanPham`
  ADD CONSTRAINT `sanpham_ibfk_1` FOREIGN KEY (`MaNH`) REFERENCES `NhanHieu` (`MaNH`);

--
-- Constraints for table `TonKho`
--
ALTER TABLE `TonKho`
  ADD CONSTRAINT `tonkho_ibfk_1` FOREIGN KEY (`MaSP`) REFERENCES `SanPham` (`MaSP`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
