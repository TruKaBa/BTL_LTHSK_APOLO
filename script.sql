USE [master]
GO
/****** Object:  Database [QUANLYGIANGDAY]    Script Date: 4/25/2023 8:50:05 PM ******/
CREATE DATABASE [QUANLYGIANGDAY]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QUANLYGIANGDAY', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QUANLYGIANGDAY.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QUANLYGIANGDAY_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QUANLYGIANGDAY_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [QUANLYGIANGDAY] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QUANLYGIANGDAY].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QUANLYGIANGDAY] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QUANLYGIANGDAY] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QUANLYGIANGDAY] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QUANLYGIANGDAY] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QUANLYGIANGDAY] SET ARITHABORT OFF 
GO
ALTER DATABASE [QUANLYGIANGDAY] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QUANLYGIANGDAY] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QUANLYGIANGDAY] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QUANLYGIANGDAY] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QUANLYGIANGDAY] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QUANLYGIANGDAY] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QUANLYGIANGDAY] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QUANLYGIANGDAY] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QUANLYGIANGDAY] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QUANLYGIANGDAY] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QUANLYGIANGDAY] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QUANLYGIANGDAY] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QUANLYGIANGDAY] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QUANLYGIANGDAY] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QUANLYGIANGDAY] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QUANLYGIANGDAY] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QUANLYGIANGDAY] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QUANLYGIANGDAY] SET RECOVERY FULL 
GO
ALTER DATABASE [QUANLYGIANGDAY] SET  MULTI_USER 
GO
ALTER DATABASE [QUANLYGIANGDAY] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QUANLYGIANGDAY] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QUANLYGIANGDAY] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QUANLYGIANGDAY] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QUANLYGIANGDAY] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QUANLYGIANGDAY] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QUANLYGIANGDAY', N'ON'
GO
ALTER DATABASE [QUANLYGIANGDAY] SET QUERY_STORE = ON
GO
ALTER DATABASE [QUANLYGIANGDAY] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QUANLYGIANGDAY]
GO
/****** Object:  Table [dbo].[tblSinhVien]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSinhVien](
	[sMaSV] [varchar](50) NOT NULL,
	[sTenSV] [nvarchar](50) NULL,
	[dNgaySinh] [date] NULL,
	[sGioiTinh] [nvarchar](10) NULL,
	[sLopHC] [varchar](50) NULL,
	[sSDT] [varchar](20) NULL,
	[sDiaChi] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[sMaSV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblHoc]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHoc](
	[sMaGV] [varchar](50) NOT NULL,
	[sMaMon] [varchar](50) NOT NULL,
	[sMaSV] [varchar](50) NOT NULL,
	[fDiemCC] [float] NULL,
	[fDiemGK] [float] NULL,
	[fDiemThi] [float] NULL,
 CONSTRAINT [PK_tblHoc] PRIMARY KEY CLUSTERED 
(
	[sMaGV] ASC,
	[sMaMon] ASC,
	[sMaSV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[v_tongsomonhoccuatungsinhvien]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_tongsomonhoccuatungsinhvien]
as
select tblHoc.sMaSV, sTenSV, count(distinct sMaMon) as [Số lượng môn đã học]
from tblHoc
left join tblSinhVien
on tblSinhVien.sMaSV = tblHoc.sMaSV
group by tblHoc.sMaSV, sTenSV
GO
/****** Object:  Table [dbo].[tblMonHoc]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMonHoc](
	[sMaMon] [varchar](50) NOT NULL,
	[sMaKhoa] [varchar](50) NOT NULL,
	[sTenMon] [nvarchar](50) NULL,
	[iSoTC] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[sMaMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[v_sosinhviennamcuatungmon]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_sosinhviennamcuatungmon]
as
select tblHoc.sMaMon, sTenMon, count(distinct tblHoc.sMaSV) as [Số lượng sinh viên nam học]
from tblMonHoc, tblHoc, tblSinhVien
where tblMonHoc.sMaMon = tblHoc.sMaMon
and tblSinhVien.sMaSV = tblHoc.sMaSV
and sGioiTinh = N'Nam'
group by tblHoc.sMaMon, sTenMon
GO
/****** Object:  View [dbo].[v_top3sinhviencodiemmaxcuamon]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_top3sinhviencodiemmaxcuamon]
as
select top 3 tblHoc.sMaSV, sTenSV, fDiemKTHP
from tblSinhVien
inner join tblHoc
on tblSinhVien.smasv = tblHoc.smasv
inner join tblMonHoc
on tblMonHoc.sMaMon = tblHoc.sMaMon
where tblHoc.smamon = tblMonHoc.smamon
and sTenMon = N'Cơ sở dữ liệu'
order by fDiemKTHP desc
GO
/****** Object:  View [dbo].[v_dtbTungMonHoc]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_dtbTungMonHoc]
as
select tblMonHoc.sMaMon, sTenMon, avg(fDiemKTHP) as [Trung bình điểm môn]
from tblMonHoc, tblHoc
where tblMonHoc.sMaMon = tblHoc.sMaMon
group by tblMonHoc.sMaMon, sTenMon
GO
/****** Object:  View [dbo].[v_thongkemhsotclonhon3]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_thongkemhsotclonhon3]
as
select *
from tblMonHoc
where isotc > 3
GO
/****** Object:  Table [dbo].[tblKhoa]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblKhoa](
	[sMaKhoa] [varchar](50) NOT NULL,
	[sTenKhoa] [nvarchar](50) NULL,
	[sDiaChi] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[sMaKhoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblGiangVien]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblGiangVien](
	[sMaGV] [varchar](50) NOT NULL,
	[sTenGV] [nvarchar](50) NULL,
	[sGioiTinh] [nvarchar](10) NULL,
	[dNgaySinh] [date] NULL,
	[sMaKhoa] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[sMaGV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[v_dsgvnucuakhoacntt]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_dsgvnucuakhoacntt]
as
select sMaGV, sTenGV, sGioiTinh, dNgaySinh
from tblGiangVien, tblKhoa
where tblGiangVien.smakhoa = tblKhoa.sMaKhoa
and stenkhoa = N'CNTT'
and sgioitinh = N'Nữ'
GO
/****** Object:  View [dbo].[v_tuoitbtatcagiangvien]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_tuoitbtatcagiangvien]
as
select avg(datediff(day, dNgaySinh, getdate())/365) as [Tuổi TB của Giảng Viên]
from tblGiangVien
GO
/****** Object:  View [dbo].[v_tuoimax]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_tuoimax]
as
select top 1 with ties sTenGV, datediff(day, dNgaySinh, getdate())/365 as [Tuổi]
from tblGiangVien
order by datediff(day, dNgaySinh, getdate())/365 desc
GO
/****** Object:  View [dbo].[v_thongkegiangviennamtren50tuoi]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_thongkegiangviennamtren50tuoi]
as
select count(smagv) as [Số lượng giảng viên nam > 50 tuổi]
from tblGiangVien
where datediff(day, dNgaySinh, getdate())/365 > 50
and sgioitinh = N'Nam'
GO
/****** Object:  View [dbo].[v_sogiangviendaytren5mon]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_sogiangviendaytren5mon]
as
select tblGiangvien.sMaGV, sTenGV, count(distinct sMaMon) as [Số môn dạy]
from tblGiangVien, tblHoc
where tblGiangvien.sMaGV = tblHOc.smagv
group by tblGiangvien.sMaGV, sTenGV
having count(distinct sMaMon) > 2
GO
/****** Object:  View [dbo].[v_somonkhoaquanly]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_somonkhoaquanly]
as
select tblKhoa.sMaKhoa, sTenKhoa, count(sMaMon) as [Cung cấp số môn]
from tblKhoa, tblMonHoc
where tblKhoa.sMaKhoa = tblMonHoc.sMaKhoa
group by tblKhoa.sMaKhoa, sTenKhoa
GO
/****** Object:  View [dbo].[v_khoangoainguquanlymon]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_khoangoainguquanlymon]
as
select sTenMon
from tblKhoa, tblMonHoc
where tblKhoa.smakhoa = tblMonHoc.smakhoa
and sTenKhoa = N'Ngoại Ngữ'
group by sTenMon, sMaMon
GO
/****** Object:  View [dbo].[v_monenglishcosokhoacungcap]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_monenglishcosokhoacungcap]
as
select sTenMon, count(tblMonHoc.sMakhoa) as [Số khoa cung cấp]
from tblMonHoc, tblKhoa
where tblMonHoc.sMakhoa = tblkhoa.smakhoa
and sTenMon = N'English Basic'
group by stenmon
GO
/****** Object:  View [dbo].[v_sotccuatungkhoacungcap]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_sotccuatungkhoacungcap]
as
select sTenkhoa, sum(isotc) as [Cung cấp số tín chỉ]
from tblKhoa, tblMonHoc
where tblKhoa.sMakhoa = tblMonHoc.sMaKhoa
group by sTenKhoa
GO
/****** Object:  View [dbo].[v_truyvangiangvien]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_truyvangiangvien]
as
select distinct tblGiangVien.sMaGV, sTenGV, sTenMon as [Dạy môn], sTenKhoa as [Thuộc khoa]
from tblGiangVien, tblKhoa, tblMonHoc, tblHoc
where tblGiangVien.sMaGV = tblHoc.sMaGV
and tblHoc.sMaMon = tblMonHoc.sMaMon
and tblGiangVien.sMakhoa = tblKhoa.sMakhoa
and tblMonHoc.sMaKhoa = tblKhoa.sMakhoa
and sTenMon = N'English basic'
and sTenKhoa = N'Điện tử thông tin'
GO
/****** Object:  Table [dbo].[tblLopHC]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLopHC](
	[sMaLop] [varchar](50) NOT NULL,
	[sTenLop] [varchar](50) NULL,
	[sMaKhoa] [varchar](50) NULL,
	[sMaGV] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[sMaLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[sTenLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[v_thongkesoluongsvcuatunglophc]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_thongkesoluongsvcuatunglophc]
as
select sTenLop, count(sMaSV) as[Sĩ số]
from tblLopHC, tblSinhVien
where tblLopHC.sMaLop = tblSinhVien.sLopHC
group by tblSinhVien.sLopHC, stenlop
GO
/****** Object:  View [dbo].[v_thongkesvhoclai]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_thongkesvhoclai]
as
select tblSinhVien.sMaSV, count(tblMonHoc.sMaMon) as [Số lần học lại]
from tblSinhVien
inner join tblHoc
on tblSinhVien.sMaSV = tblHoc.sMaSV
inner join tblMonHoc
on tblHoc.sMaMon = tblMonHoc.sMaMon
group by tblMonHoc.sMaMon, tblSinhVien.sMaSV, sTenMon
having count(tblMonHoc.sMaMon) > 1
GO
/****** Object:  View [dbo].[v_thongkesvcodiachiBN]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_thongkesvcodiachiBN]
as
select sTenSV, sDiaChi
from tblSinhVien
where sDiaChi = N'Bắc Ninh'
GO
/****** Object:  View [dbo].[v_dssvcodiemlonhon9]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_dssvcodiemlonhon9]
as
select sTenSV, fDiemKTHP
from tblSinhVien, tblHoc, tblMonHoc
where tblSinhVien.sMaSV = tblHoc.sMaSV
and tblHoc.sMaMon = tblMonHoc.sMaMon
and fDiemKTHP > 9
and sTenMon = N'Cơ sở dữ liệu'
GO
/****** Object:  View [dbo].[v_sv_gvchunhiem]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_sv_gvchunhiem]
as
select sMaSV, sTenSV
from tblSinhVien, tblGiangVien, tblLopHC
where tblSinhVien.sLopHC = tblLopHC.sMaLop
and  tblGiangVien.sMaGV = tblLopHC.sMaGV
and sTenGV = N'Trịnh Thị Xuân'
GO
/****** Object:  View [dbo].[v_svnam2002]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_svnam2002]
as
select count(sMaSV) as [Số lượng sv năm 2002]
from tblSinhVien
where year(dNgaySinh) = 2002
GO
/****** Object:  View [dbo].[v_svkhoa19]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_svkhoa19]
as
select *
from tblSinhVien
where sMaSV like '%19%'
GO
/****** Object:  View [dbo].[v_dssv_khoacntt]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_dssv_khoacntt]
as
select tblSinhVien.sMaSV, sTenSV
from tblSinhVien, tblLopHC, tblKhoa
where tblSinhVien.sLopHC = tblLopHC.sMaLop
and tblLopHC.sMaKhoa = tblKhoa.sMaKhoa
and sTenKhoa = N'CNTT'
and sMaLop = 'lp2'
GO
/****** Object:  View [dbo].[v_sosvlophc]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_sosvlophc]
as
select tblLopHC.sMaLop, sTenLop, count(sMaSV) as [Số lượng sinh viên]
from tblLopHC, tblSinhVien
where sMaLop = sLopHC
group by tblLopHC.sMaLop, sTenLop
GO
/****** Object:  View [dbo].[v_xemmon]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_xemmon]
as
select distinct tblMonHoc.sMaMon, sMaSV, iSoTC
from tblHoc, tblMonHoc
where tblHoc.smamon = tblMonHoc.sMaMon
GO
/****** Object:  Table [dbo].[tblTaiKhoan]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTaiKhoan](
	[iMaTK] [int] IDENTITY(1,1) NOT NULL,
	[sUsername] [varchar](50) NOT NULL,
	[sPassword] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[iMaTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[sUsername] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblGiangVien]  WITH CHECK ADD FOREIGN KEY([sMaKhoa])
REFERENCES [dbo].[tblKhoa] ([sMaKhoa])
GO
ALTER TABLE [dbo].[tblHoc]  WITH CHECK ADD  CONSTRAINT [FK_giangvien] FOREIGN KEY([sMaGV])
REFERENCES [dbo].[tblGiangVien] ([sMaGV])
GO
ALTER TABLE [dbo].[tblHoc] CHECK CONSTRAINT [FK_giangvien]
GO
ALTER TABLE [dbo].[tblHoc]  WITH CHECK ADD  CONSTRAINT [FK_Mon] FOREIGN KEY([sMaMon])
REFERENCES [dbo].[tblMonHoc] ([sMaMon])
GO
ALTER TABLE [dbo].[tblHoc] CHECK CONSTRAINT [FK_Mon]
GO
ALTER TABLE [dbo].[tblHoc]  WITH CHECK ADD  CONSTRAINT [FK_SV] FOREIGN KEY([sMaSV])
REFERENCES [dbo].[tblSinhVien] ([sMaSV])
GO
ALTER TABLE [dbo].[tblHoc] CHECK CONSTRAINT [FK_SV]
GO
ALTER TABLE [dbo].[tblLopHC]  WITH CHECK ADD FOREIGN KEY([sMaGV])
REFERENCES [dbo].[tblGiangVien] ([sMaGV])
GO
ALTER TABLE [dbo].[tblLopHC]  WITH CHECK ADD FOREIGN KEY([sMaKhoa])
REFERENCES [dbo].[tblKhoa] ([sMaKhoa])
GO
ALTER TABLE [dbo].[tblMonHoc]  WITH CHECK ADD FOREIGN KEY([sMaKhoa])
REFERENCES [dbo].[tblKhoa] ([sMaKhoa])
GO
ALTER TABLE [dbo].[tblSinhVien]  WITH CHECK ADD FOREIGN KEY([sLopHC])
REFERENCES [dbo].[tblLopHC] ([sMaLop])
GO
ALTER TABLE [dbo].[tblGiangVien]  WITH CHECK ADD  CONSTRAINT [CK_GiangVien_gioitinh] CHECK  (([sGioiTinh]=N'Nam' OR [sGioiTinh]=N'Nữ'))
GO
ALTER TABLE [dbo].[tblGiangVien] CHECK CONSTRAINT [CK_GiangVien_gioitinh]
GO
ALTER TABLE [dbo].[tblHoc]  WITH CHECK ADD  CONSTRAINT [CK_Hoc_DiemCC] CHECK  (([fDiemCC]>=(0) AND [fDiemCC]<=(10)))
GO
ALTER TABLE [dbo].[tblHoc] CHECK CONSTRAINT [CK_Hoc_DiemCC]
GO
ALTER TABLE [dbo].[tblHoc]  WITH CHECK ADD  CONSTRAINT [CK_Hoc_DiemGK] CHECK  (([fDiemGK]>=(0) AND [fDiemGK]<=(10)))
GO
ALTER TABLE [dbo].[tblHoc] CHECK CONSTRAINT [CK_Hoc_DiemGK]
GO
ALTER TABLE [dbo].[tblHoc]  WITH CHECK ADD  CONSTRAINT [CK_Hoc_DiemThi] CHECK  (([fDiemThi]>=(0) AND [fDiemThi]<=(10)))
GO
ALTER TABLE [dbo].[tblHoc] CHECK CONSTRAINT [CK_Hoc_DiemThi]
GO
ALTER TABLE [dbo].[tblSinhVien]  WITH CHECK ADD  CONSTRAINT [CK_SinhVien_gioitinh] CHECK  (([sGioiTinh]=N'Nam' OR [sGioiTinh]=N'Nữ'))
GO
ALTER TABLE [dbo].[tblSinhVien] CHECK CONSTRAINT [CK_SinhVien_gioitinh]
GO
/****** Object:  StoredProcedure [dbo].[checkPrimaryKeySubject]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[checkPrimaryKeySubject] @id varchar(20)
  as
  begin
	select sMaMon
	from tblMonHoc 
	where @id=sMaMon;
  end

GO
/****** Object:  StoredProcedure [dbo].[deletehoc]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[deletehoc]
@magv varchar(50), @mamon varchar(50), @masv varchar(50)
as
delete from tblHoc
where sMaGV = @magv and sMaMon = @mamon and sMaSV = @masv
GO
/****** Object:  StoredProcedure [dbo].[deletesinhvien]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[deletesinhvien]
@ma varchar(50)
as
delete from tblSinhVien
where sMaSV = @ma
GO
/****** Object:  StoredProcedure [dbo].[getAllSubject]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getAllSubject]
as
	select sMaMon, sTenMon, iSoTC, sTenKhoa  
	from tblMonHoc as mon, tblKhoa as khoa
	where mon.sMaKhoa = khoa.sMaKhoa
GO
/****** Object:  StoredProcedure [dbo].[insertgiangvien]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertgiangvien]
@magv varchar(50), @ten nvarchar(50), @gioitinh nvarchar(10), @ngaysinh date, @mak varchar(50)
as
insert into tblGiangVien (sMaGV, sTenGV, sGioiTinh, dNgaySinh, sMaKhoa)
values (@magv, @ten, @gioitinh, @ngaysinh, @mak)
GO
/****** Object:  StoredProcedure [dbo].[inserthoc]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[inserthoc]
@magv varchar(50),
@mamon varchar(50),
@masv varchar(50),
@madonvi varchar(50),
@diemcc float,
@diemgk float,
@diemthi float
as
insert into tblHoc
values(@magv, @mamon, @masv, @madonvi, @diemcc, @diemgk, @diemthi, @diemcc * 0.1 + @diemgk * 0.2 + @diemthi * 0.3)
GO
/****** Object:  StoredProcedure [dbo].[insertkhoa]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertkhoa]
@mak varchar(50), @tenk nvarchar(50), @dc nvarchar(50)
as
insert into tblKhoa (sMaKhoa, sTenKhoa, sDiaChi)
values (@mak, @tenk, @dc)
GO
/****** Object:  StoredProcedure [dbo].[insertlophanhchinh]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertlophanhchinh]
@mal varchar(50), @tenlop nvarchar(50), @magv varchar(50), @makhoa varchar(50)
as
begin
		insert into tblLopHC (sMaLop, sTenLop, sMaGV, sMaKhoa, iSiSo)
		values
		(@mal, @tenlop, @magv, @makhoa, 0)
end
GO
/****** Object:  StoredProcedure [dbo].[insertmonhoc]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertmonhoc]
@ma varchar(50), @mak varchar(50), @tenm nvarchar(50), @sotc int
as
begin
	if exists (select * from tblMonHoc where sMaMon = @ma)
	begin
		print N'MÃ MÔN ĐÃ TỒN TẠI'
		return;
	end
	else
	begin
		insert into tblMonHoc (sMaMon, sMaKhoa, sTenMon, iSoTC)
		values (@ma, @mak, @tenm, @sotc)
	end
end
GO
/****** Object:  StoredProcedure [dbo].[insertsinhvien]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertsinhvien]
@masv varchar(50), @ten nvarchar(50), @ngaysinh datetime, @diachi nvarchar(50), @gt nvarchar(10), @malop varchar(50), @sdt varchar(10)
as
insert into tblSinhVien (sMaSV, sTenSV, dNgaySinh, sDiaChi, sGioiTinh, sLopHC, sSDT)
values (@masv, @ten, @ngaysinh, @diachi, @gt, @malop, @sdt)
GO
/****** Object:  StoredProcedure [dbo].[Proc_CapNhatGiangVienChoMonHoc]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_CapNhatGiangVienChoMonHoc]
@magvien varchar(50), @magvtampthoi varchar(50)
as
	update tblHoc
	set sMaGV = @magvien
	where sMaGV =  @magvtampthoi
GO
/****** Object:  StoredProcedure [dbo].[Proc_CapNhatKetQuaHocTap]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_CapNhatKetQuaHocTap]
@masv varchar(50), @magv varchar(50), @mamon varchar(50), @diemcc float, @diemgk float, @diemthi float
as
	update tblHoc
	set fDiemCC = @diemcc, fDiemGK = @diemgk, fDiemThi = @diemthi
	where sMaSV = @masv and sMaGV = @magv and sMaMon = @mamon
GO
/****** Object:  StoredProcedure [dbo].[Proc_CapNhatLopChoSinhVien]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_CapNhatLopChoSinhVien]
@malop varchar(50)
as 
	update tblSinhVien
	set sLopHC = @malop
	where sLopHC IS NULL
GO
/****** Object:  StoredProcedure [dbo].[Proc_CapNhattblGiangVien]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_CapNhattblGiangVien]
@magv varchar(50), @tengv nvarchar(50), @gioitinh nvarchar(10), @ngaysinh date, @makhoa varchar(50)
as
	update tblGiangVien
	set	sTenGV = @tengv, sGioiTinh= @gioitinh, dNgaySinh = @ngaysinh, sMaKhoa = @makhoa
	where sMaGV = @magv
GO
/****** Object:  StoredProcedure [dbo].[Proc_CapNhattblLopHC]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_CapNhattblLopHC]
@malop varchar(50), @tenlop varchar(50), @magv varchar(50), @makhoa varchar(50)
as
	update tblLopHC
	set sTenLop = @tenlop, sMaGV = @magv, sMaKhoa = @makhoa
	where sMaLop = @malop
GO
/****** Object:  StoredProcedure [dbo].[Proc_CapNhattblMonHoc]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_CapNhattblMonHoc]
@mamon varchar(50), @tenmon nvarchar(50), @makhoa varchar(50), @sotinchi int
as
	update tblMonHoc
	set sTenMon = @tenmon, sMaKhoa = @makhoa, iSoTC = @sotinchi
	where sMaMon = @mamon
GO
/****** Object:  StoredProcedure [dbo].[Proc_CapNhattblSinhVien]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_CapNhattblSinhVien]
@masv varchar(50), @tensv nvarchar(50),@ngaysinh date,  @gioitinh nvarchar(10), @diachi nvarchar(50), @sdt varchar(20), @malop varchar(50)
as 
	update tblSinhVien
	set	sTenSV = @tensv, sGioiTinh = @gioitinh, dNgaySinh = @ngaysinh, sDiaChi = @diachi, sSDT = @sdt, sLopHC = @malop
	where sMaSV = @masv
GO
/****** Object:  StoredProcedure [dbo].[Proc_ChenKetQuaHocTap]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_ChenKetQuaHocTap]
@masv varchar(50), @magv varchar(50), @mamon varchar(50), @diemcc float, @diemgk float, @diemthi float
as 
	insert into tblHoc(sMaGV, sMaSV, sMaMon, fDiemCC, fDiemGK, fDiemThi)
	values (@magv, @masv, @mamon, @diemcc, @diemgk, @diemthi)
GO
/****** Object:  StoredProcedure [dbo].[Proc_ChenThemGiangVien]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[Proc_ChenThemGiangVien]
@magv varchar(50), @tengv nvarchar(50), @gioitinh nvarchar(10), @ngaysinh date, @makhoa varchar(50)
as
	Insert into tblGiangVien(sMaGV, sTenGV, sGioiTinh, dNgaySinh, sMaKhoa)
	values (@magv, @tengv, @gioitinh, @ngaysinh, @makhoa)
GO
/****** Object:  StoredProcedure [dbo].[Proc_ChenThemLop]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_ChenThemLop]
@malop varchar(50), @tenlop varchar(50), @magv varchar(50), @makhoa varchar(50)
as
	Insert into tblLopHC (sMaLop, sTenLop, sMaGV, sMaKhoa)
	values (@malop, @tenlop, @magv, @makhoa)
GO
/****** Object:  StoredProcedure [dbo].[Proc_ChenThemMonHoc]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_ChenThemMonHoc]
@mamon varchar(50), @tenmon nvarchar(50), @makhoa varchar(50), @sotinchi int
as
	insert into tblMonHoc(sMaMon, sTenMon, sMaKhoa, iSoTC)
	values (@mamon, @tenmon, @makhoa, @sotinchi)
GO
/****** Object:  StoredProcedure [dbo].[Proc_ChenThemSinhVien]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_ChenThemSinhVien]
@masv varchar(50), @tensv nvarchar(50),@ngaysinh date,  @gioitinh nvarchar(10), @diachi nvarchar(50), @sdt varchar(20), @malop varchar(50)
as
	insert into tblSinhVien (sMaSV, sTenSV, dNgaySinh, sDiaChi, sGioiTinh, sLopHC, sSDT)
	values (@masv, @tensv, @ngaysinh, @diachi, @gioitinh, @malop, @sdt)
GO
/****** Object:  StoredProcedure [dbo].[Proc_ChiTietGiangVien]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_ChiTietGiangVien]
@magv varchar(50)
as
begin
	select gv.sMaGV, gv.sTenGV, gv.sGioiTinh, gv.dNgaySinh, gv.sMaKhoa, k.sTenKhoa, lp.sTenLop, mh.sMaMon, mh.sTenMon
	from (((tblGiangVien gv
	inner join tblKhoa k on gv.sMaKhoa = k.sMaKhoa)
	inner join tblLopHC lp on gv.sMaGV = lp.sMaGV)
	inner join tblHoc h on gv.sMaGV = h.sMaGV)
	inner join tblMonHoc mh on h.sMaMon = mh.sMaMon
	where gv.sMaGV = @magv
end
GO
/****** Object:  StoredProcedure [dbo].[Proc_ChiTietLopHC]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_ChiTietLopHC] 
@malop varchar(50)
as
	select hc.sMaLop, hc.sTenLop, hc.sMaGV, hc.sMaKhoa, gv.sTenGV, k.sTenKhoa, sv.sMaSV, sv.sTenSV
	from ((tblLopHC hc
	inner join tblGiangVien gv
	on hc.sMaGV = gv.sMaGV)
	inner join tblKhoa k
	on hc.sMaKhoa = k.sMaKhoa)
	inner join tblSinhVien sv on hc.sMaLop = sv.sLopHC
	where hc.sMaLop = @malop
GO
/****** Object:  StoredProcedure [dbo].[Proc_ChiTietMonHoc]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_ChiTietMonHoc]
@mamon varchar(50)
as
begin
	select mh.sMaMon, mh.sTenMon, mh.sMaKhoa, mh.iSoTC, h.sMaGV, gv.sTenGV, k.sTenKhoa, h.sMaSV, sv.sTenSV, lp.sTenLop
	from ((((tblMonHoc mh
	inner join tblHoc h on mh.sMaMon = h.sMaMon)
	inner join tblGiangVien gv on h.sMaGV = gv.sMaGV)
	inner join tblKhoa k on mh.sMaKhoa = k.sMaKhoa)
	inner join tblSinhVien sv on h.sMaSV = sv.sMaSV)
	inner join tblLopHC lp on sv.sLopHC = lp.sMaLop
	where mh.sMaMon = @mamon
end
GO
/****** Object:  StoredProcedure [dbo].[Proc_ChiTietSinhVien]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_ChiTietSinhVien]
@masv varchar(50)
as
	select sv.sMaSV, sv.sTenSV, sv.sGioiTinh, sv.dNgaySinh, sv.sDiaChi, sv.sSDT, sv.sLopHC, h.fDiemCC, h.fDiemGK, h.fDiemThi, mh.sTenMon, h.sMaMon, lp.sTenLop
	from ((tblSinhVien sv
	inner join tblHoc h on sv.sMaSV = h.sMaSV)
	inner join tblMonHoc mh on h.sMaMon = mh.sMaMon)
	inner join tblLopHC lp on sv.sLopHC = lp.sMaLop
	where sv.sMaSV =@masv
GO
/****** Object:  StoredProcedure [dbo].[Proc_ChonGiangVienDauTien]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_ChonGiangVienDauTien]
@giangvien varchar(50) output
as
begin
	select @giangvien = (SELECT TOP 1 sMaGV FROM tblGiangVien ORDER BY sMaGV DESC)
end
GO
/****** Object:  StoredProcedure [dbo].[Proc_DoiMatKhau]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_DoiMatKhau]
@matk int, @mkmoi varchar(50)
as
	update tblTaiKhoan
	set sPassword = @mkmoi
	where iMaTK = @matk
GO
/****** Object:  StoredProcedure [dbo].[Proc_KiemTraDangNhap]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_KiemTraDangNhap]
@username varchar(50), @password varchar(50)
as
	select *
	from tblTaiKhoan t
	where t.sUsername = @username AND t.sPassword = @password
GO
/****** Object:  StoredProcedure [dbo].[Proc_KiemTraGiangVien]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_KiemTraGiangVien]
@magv varchar(50)
as
	select *
	from tblGiangVien
	where sMaGV = @magv
GO
/****** Object:  StoredProcedure [dbo].[Proc_KiemTraMaLop]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_KiemTraMaLop]
@malop varchar(50)
as
	select *
	from tblLopHC
	where sMaLop = @malop
GO
/****** Object:  StoredProcedure [dbo].[Proc_KiemTraMonHoc]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_KiemTraMonHoc]
@mamon varchar(50)
as
	select *
	from tblMonHoc
	where sMaMon = @mamon
GO
/****** Object:  StoredProcedure [dbo].[Proc_KiemTraSinhVien]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_KiemTraSinhVien]
@masv varchar(50)
as
	select * 
	from tblSinhVien
	where sMaSV = @masv
GO
/****** Object:  StoredProcedure [dbo].[Proc_LayGiangVienKhongBiXoa]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_LayGiangVienKhongBiXoa]
@magiangvien varchar(50), @output varchar(50) output
as
begin
	select @output = (select top 1 sMaGV
	from tblGiangVien
	where NOT sMaGV = @magiangvien);
end
GO
/****** Object:  StoredProcedure [dbo].[Proc_LopHCTheoKhoa]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_LopHCTheoKhoa]
as
	select hc.sMaLop, hc.sTenLop, hc.sMaGV, hc.sMaKhoa, gv.sTenGV, k.sTenKhoa
	from (tblLopHC hc
	inner join tblGiangVien gv
	on hc.sMaGV = gv.sMaGV)
	inner join tblKhoa k
	on hc.sMaKhoa = k.sMaKhoa
GO
/****** Object:  StoredProcedure [dbo].[Proc_SelectAlltblGiangVien]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_SelectAlltblGiangVien]
as
	select * 
	from tblGiangVien
GO
/****** Object:  StoredProcedure [dbo].[Proc_SelectAlltblHoc]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_SelectAlltblHoc]
as
	select * from tblHoc
GO
/****** Object:  StoredProcedure [dbo].[Proc_SelectAlltblLopHC]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_SelectAlltblLopHC]
as
	select *
	from tblLopHC
GO
/****** Object:  StoredProcedure [dbo].[Proc_SelectAlltblMonHoc]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_SelectAlltblMonHoc]
as
select * from tblMonHoc
GO
/****** Object:  StoredProcedure [dbo].[Proc_SelectAlltblSinhVien]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_SelectAlltblSinhVien]
as
	select * from tblSinhVien
GO
/****** Object:  StoredProcedure [dbo].[Proc_tbLopHCvoiTenGiaoVienVaTenKhoa]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_tbLopHCvoiTenGiaoVienVaTenKhoa]
as
	select hc.sMaLop, hc.sTenLop, hc.sMaKhoa, hc.sMaGV, gv.sTenGV, k.sTenKhoa
	from (tblLopHC hc 
	inner join tblGiangVien gv on hc.sMaGV = gv.sMaGV)
	inner join tblKhoa k on hc.sMaKhoa = k.sMaKhoa;
GO
/****** Object:  StoredProcedure [dbo].[Proc_ThongKeGiangVien]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_ThongKeGiangVien]
as
begin
	select gv.sMaGV, gv.sTenGV, gv.sGioiTinh, gv.dNgaySinh, gv.sMaKhoa, k.sTenKhoa, lp.sTenLop, mh.sMaMon, mh.sTenMon
	from (((tblGiangVien gv
	inner join tblKhoa k on gv.sMaKhoa = k.sMaKhoa)
	inner join tblLopHC lp on gv.sMaGV = lp.sMaGV)
	inner join tblHoc h on gv.sMaGV = h.sMaGV)
	inner join tblMonHoc mh on h.sMaMon = mh.sMaMon
end
GO
/****** Object:  StoredProcedure [dbo].[Proc_ThongKeMonHoc]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_ThongKeMonHoc]
as
	select mh.sMaMon, mh.sTenMon, mh.sMaKhoa, mh.iSoTC, k.sTenKhoa
	from tblMonHoc mh
	inner join tblKhoa k on mh.sMaKhoa = k.sMaKhoa
GO
/****** Object:  StoredProcedure [dbo].[Proc_ThongKeSinhVien]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_ThongKeSinhVien]
as
	select sv.sMaSV, sv.sTenSV, sv.dNgaySinh, sv.sGioiTinh, sv.sLopHC, sv.sSDT, sv.sDiaChi, lp.sTenLop
	from tblSinhVien sv
	inner join tblLopHC lp
	on sv.sLopHC = lp.sMaLop
GO
/****** Object:  StoredProcedure [dbo].[Proc_XoaGiangVien]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_XoaGiangVien]
@magv varchar(50)
as
	delete from tblGiangVien
	where sMaGV = @magv
GO
/****** Object:  StoredProcedure [dbo].[Proc_XoaGiangVienVaCapNhatGiangVienMonHoc]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_XoaGiangVienVaCapNhatGiangVienMonHoc]
@magv varchar(50)
as
begin
	declare @result varchar(50);
	declare @gv varchar(50);

	update tblHoc
	set sMaGV = 'gv9999'
	where sMaGV = @magv;

	update tblLopHC
	set sMaGV = 'gv9999'
	where sMaGV = @magv;

	delete from tblGiangVien
	where sMaGV = @magv;

	exec Proc_ChonGiangVienDauTien @giangvien = @gv output;

	update tblHoc
	set sMaGV = @gv
	where sMaGV = 'gv9999';

	update tblLopHC
	set sMaGV = @gv
	where sMaGV = 'gv9999';
	
end
GO
/****** Object:  StoredProcedure [dbo].[Proc_XoaKetQuaHocTap]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_XoaKetQuaHocTap]
@masv varchar(50), @magv varchar(50), @mamon varchar(50)
as
	delete from tblHoc
	where sMaSV = @masv and sMaGV = @magv and sMaMon = @mamon
GO
/****** Object:  StoredProcedure [dbo].[Proc_XoaLop]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_XoaLop]
@malop varchar(50)
as
	delete from tblLopHC
	where sMaLop = @malop
GO
/****** Object:  StoredProcedure [dbo].[Proc_XoaLopSinhVien]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_XoaLopSinhVien]
@malop varchar(50)
as
	update tblSinhVien
	set sLopHC = null
	where sLopHC = @malop
GO
/****** Object:  StoredProcedure [dbo].[Proc_XoaMonHocVaCapNhatMonHocChoSinhVien]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_XoaMonHocVaCapNhatMonHocChoSinhVien]
@mamon varchar(50)
as
begin
	update tblHoc
	set sMaMon = 'm9999'
	where sMaMon = @mamon

	delete from tblMonHoc
	where sMaMon = @mamon

	update tblHoc
	set sMaMon = (select top 1 sMaMon from tblMonHoc order by sMaMon)
	where sMaMon = 'm9999'
end
GO
/****** Object:  StoredProcedure [dbo].[Proc_XoaSinhVien]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_XoaSinhVien]
@masv varchar(50)
as
begin
	delete from tblHoc
	where sMaSV = @masv

	delete from tblSinhVien
	where sMaSV = @masv
end
GO
/****** Object:  StoredProcedure [dbo].[Select_GV_MonHoc]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Select_GV_MonHoc] @maMon varchar(50)
as
begin
	
	select tblGiangVien.sTenGV,tblGiangVien.sMaGV,tblKhoa.sTenKhoa,tblMonHoc.sMaMon,tblMonHoc.sTenMon

	from tblGiangVien join tblHoc on tblGiangVien.sMaGV= tblHoc.sMaGV
	join tblMonHoc on tblHoc.sMaMon=tblMonHoc.sMaMon
	join tblKhoa on tblGiangVien.sMaKhoa=tblKhoa.sMaKhoa
	
	where tblMonHoc.sMaMon=@maMon
	
	group by tblGiangVien.sTenGV,tblGiangVien.sMaGV,tblKhoa.sTenKhoa,tblMonHoc.sMaMon,tblMonHoc.sTenMon
end
GO
/****** Object:  StoredProcedure [dbo].[select_subject_name]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[select_subject_name] @maMon varchar(50)
as
begin
	select sMaMon,sTenMon
	from tblMonHoc
end
GO
/****** Object:  StoredProcedure [dbo].[selectdanhsachgiaoviennamthuockhoa]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[selectdanhsachgiaoviennamthuockhoa]
@tenk nvarchar(50)
as
select sTenGV, sGioiTinh
from tblGiangVien, tblKhoa
where tblGiangVien.sMaKhoa = tblKhoa.sMaKhoa
and sTenKhoa = @tenk
and sGioiTinh = N'Nam'
GO
/****** Object:  StoredProcedure [dbo].[selectdanhsachhoclaitheomon]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[selectdanhsachhoclaitheomon] @maMon varchar(50) AS
BEGIN
	IF exists (SELECT tblMonHoc.sMaMon FROM tblMonHoc where @maMon = tblMonHoc.sMaMon)
		BEGIN
			SELECT sv.sMaSV AS sMaSv, sv.sTenSV as sTensv
			FROM tblSinhVien as sv, tblHoc as hoc
			WHERE @maMon = hoc.sMaMon AND
				  sv.sMaSV = hoc.sMaSV 	
			GROUP BY sv.sMaSV, sv.sTenSV
			HAVING COUNT(hoc.sMaMon) >= 2
		END
END
GO
/****** Object:  StoredProcedure [dbo].[selectdemsogiaoviennu]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[selectdemsogiaoviennu]
@mak varchar(50)
as
begin
	if exists (select * from tblKhoa where sMaKhoa = @mak)
	begin
		select count(sMaGV) as [Số lượng giảng viên nữ]
		from tblGiangVien
		where sGioiTinh = N'Nữ' and sMaKhoa = @mak
	end
	else
	begin
		print N'MÃ KHOA KHÔNG TỒN TẠI'
		return
	end
end
GO
/****** Object:  StoredProcedure [dbo].[selectgiangvientheoma]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[selectgiangvientheoma]
@magv varchar(50)
as
select *
from tblGiangVien
where sMaGV = @magv
GO
/****** Object:  StoredProcedure [dbo].[selectgiangvientheotuoi]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[selectgiangvientheotuoi]
@tuoi int
as
select sTenGV, datediff(day, dNgaySinh, getdate())/365 as [Tuổi]
from tblGiangVien
where datediff(day, dNgaySinh, getdate())/365 > @tuoi
GO
/****** Object:  StoredProcedure [dbo].[selecthoc]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[selecthoc]
as
select * from tblHoc
GO
/****** Object:  StoredProcedure [dbo].[selecthoctheomamonmasinhvien]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[selecthoctheomamonmasinhvien]
@mamon varchar(50), @masv varchar(50)
as
select * from tblHoc
where sMaMon = @mamon and sMaSV = @masv
GO
/****** Object:  StoredProcedure [dbo].[selectindanhsachgiaovientheonamsinh]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[selectindanhsachgiaovientheonamsinh]
@nam int
as
select sTenGV, dNgaySinh
from tblGiangVien
where year(dngaySinh) = @nam
GO
/****** Object:  StoredProcedure [dbo].[selectkhoa]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[selectkhoa]
as
select * from tblKhoa
GO
/****** Object:  StoredProcedure [dbo].[selectlophanhchinh]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[selectlophanhchinh]
as
select sMaLop, sTenGV, iSiSo, sTenLop, l.sMaGV, l.sMaKhoa, sTenKhoa
from tblLopHC as l, tblGiangVien as gv, tblKhoa as k
where l.sMaKhoa = k.sMaKhoa and gv.sMaGV = l.sMaGV
GO
/****** Object:  StoredProcedure [dbo].[selectlophanhchinhtheoma]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[selectlophanhchinhtheoma]
@malop varchar(50)
as
	select sMaLop, sTenGV, iSiSo, sTenLop, l.sMaGV, l.sMaKhoa, sTenKhoa, sMaSV, sTenSV, sv.dNgaySinh, sv.sDiaChi, sv.sGioiTinh, sSDT
	from tblLopHC as l, tblGiangVien as gv, tblKhoa as k, tblSinhVien as sv
	where l.sMaKhoa = k.sMaKhoa and gv.sMaGV = l.sMaGV and @malop = l.sMaLop and l.sMaLop = sv.sLopHC
GO
/****** Object:  StoredProcedure [dbo].[selectmakhoa]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[selectmakhoa] 
@tenkhoa nvarchar(50)
as
select sMaKhoa from tblKhoa
where sTenKhoa = @tenkhoa
GO
/****** Object:  StoredProcedure [dbo].[selectMon]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[selectMon]
as select * from tblMonHoc;
GO
/****** Object:  StoredProcedure [dbo].[selectmonhoctheoma]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[selectmonhoctheoma]
@mamon varchar(50)
as
select *
from tblMonHoc
where sMaMon = @mamon
GO
/****** Object:  StoredProcedure [dbo].[selectmontichluy]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[selectmontichluy]
@masv varchar(50)
as
select distinct sTenMon
from tblSinhVien, tblHoc, tblMonHoc
where tblSinhVien.sMaSV = tblHoc.sMaSV
and tblHoc.sMaMon = tblMonHoc.sMaMon
and tblSinhVien.sMaSV = @masv
GO
/****** Object:  StoredProcedure [dbo].[selectquanlylop]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[selectquanlylop]
@mal varchar(50)
as
select tblGiangVien.sMaGV, sTenGV
from tblGiangVien, tblLopHC
where tblGiangVien.sMaGV = tblLopHC.sMaGV
and sMaLop = @mal
GO
/****** Object:  StoredProcedure [dbo].[selectsinhvien]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[selectsinhvien]
as
select * from tblSinhVien
GO
/****** Object:  StoredProcedure [dbo].[selectsinhvienhocmon]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[selectsinhvienhocmon]
@maM varchar(50)
as
begin
	if exists (select * from tblMonHoc where sMaMon = @maM)
	begin
		select distinct sTenSV
		from tblSinhVien, tblHoc
		where tblSinhVien.sMaSV = tblHoc.sMaSV
		and sMaMon = @maM
	end
	else
	begin
		print N'MÃ MÔN KHÔNG TỒN TẠI'
		return
	end
end
GO
/****** Object:  StoredProcedure [dbo].[selectsinhvientheoma]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[selectsinhvientheoma]
@masv varchar(50)
as
select *
from tblSinhVien
where sMaSV = @masv
GO
/****** Object:  StoredProcedure [dbo].[selectthongkesinhvienthuockhoa]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[selectthongkesinhvienthuockhoa]
@mak varchar(50)
as
begin
	if exists (select * from tblKhoa where sMaKhoa = @mak)
	begin
		select sTenSV
		from tblSinhVien, tblLopHC, tblKhoa
		where tblSinhVien.sLopHC = tblLopHC.sMaLop
		and tblLopHC.sMaKhoa = tblKhoa.sMaKhoa
		and tblKhoa.sMaKhoa = @mak
	end
	else
	begin
		print N'MÃ KHOA KHÔNG TỒN TẠI'
		return;
	end
end
GO
/****** Object:  StoredProcedure [dbo].[updatechuyenLop]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updatechuyenLop]
@masv varchar(50), @malop varchar(50)
as
update tblSinhVien
set sLopHC = @malop
where sMaSV = @masv
GO
/****** Object:  StoredProcedure [dbo].[updatecovanhoctap]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[updatecovanhoctap]
@mal varchar(50), @magv varchar(50)
as
begin
	if exists (select * from tblLopHC where sMaLop = @mal)
	begin
		if exists (select * from tblGiangVien where sMaGV = @magv)
		begin
			update tblLopHC
			set sMaGV = @magv
			where sMaLop = @mal

			print N'CẬP NHẬT THÀNH CÔNG'
		end
		else
		begin
			print N'MÃ GIẢNG VIÊN KHÔNG TỒN TẠI'
			return;
		end
	end
	else
	begin
		print N'MÃ LỚP KHÔNG TỒN TẠI'
		return;
	end
end
GO
/****** Object:  StoredProcedure [dbo].[updatediachisinhvien]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updatediachisinhvien]
@ma varchar(50), @dc nvarchar(50)
as
update tblSinhVien
set sDiaChi = @dc
where sMaSV = @ma
GO
/****** Object:  StoredProcedure [dbo].[updatediemthanhphan]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updatediemthanhphan]
@magv varchar(50), @mamon varchar(50), @masv varchar(50), @diemcc float, @diemgk float, @diemthi float
as
update tblHoc
set fDiemCC = @diemcc, fDiemGK = @diemgk, fDiemThi = @diemthi, fDiemKTHP = @diemcc * 0.1 + @diemgk * 0.2 + @diemthi * 0.3
where sMaGV = @magv and sMaMon = @mamon and sMaSV = @masv
GO
/****** Object:  StoredProcedure [dbo].[updatedoimakhoacungcap]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updatedoimakhoacungcap]
@mam varchar(50), @mak varchar(50)
as
update tblMonHoc
set sMaKhoa = @mak
where sMaMon = @mam
GO
/****** Object:  StoredProcedure [dbo].[updatetensinhvien]    Script Date: 4/25/2023 8:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updatetensinhvien]
@ma varchar(50), @ten nvarchar(50)
as
update tblSinhVien
set sTenSV = @ten
where sMaSV = @ma
GO
USE [master]
GO
ALTER DATABASE [QUANLYGIANGDAY] SET  READ_WRITE 
GO
