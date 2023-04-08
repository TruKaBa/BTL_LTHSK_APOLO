

-- CREATE PROC LOPHC
create proc selectlophanhchinh
as
select sMaLop, sTenGV, iSiSo, sTenLop, l.sMaGV, l.sMaKhoa, sTenKhoa
from tblLopHC as l, tblGiangVien as gv, tblKhoa as k
where l.sMaKhoa = k.sMaKhoa and gv.sMaGV = l.sMaGV


--	Sửa tên lớp hc của sinh viên để chuyên sang lớp khác thông qua mã sinh viên, mã lớp được truyền vào
create proc updatechuyenLop
@masv varchar(50), @malop varchar(50)
as
update tblSinhVien
set sLopHC = @malop
where sMaSV = @masv

--Thủ tục tìm lớp hành chính theo mã
create proc selectlophanhchinhtheoma
@malop varchar(50)
as
	select sMaLop, sTenGV, iSiSo, sTenLop, l.sMaGV, l.sMaKhoa, sTenKhoa, sMaSV, sTenSV, sv.dNgaySinh, sv.sDiaChi, sv.sGioiTinh, sSDT, iTcTichLuy 
	from tblLopHC as l, tblGiangVien as gv, tblKhoa as k, tblSinhVien as sv
	where l.sMaKhoa = k.sMaKhoa and gv.sMaGV = l.sMaGV and @malop = l.sMaLop and l.sMaLop = sv.sLopHC

--	Tạo thủ tục cho biết tên giáo viên quản lí lớp hành chính với lớp hành chính là tham số truyền vào
create proc selectquanlylop
@mal varchar(50)
as
select tblGiangVien.sMaGV, sTenGV
from tblGiangVien, tblLopHC
where tblGiangVien.sMaGV = tblLopHC.sMaGV
and sMaLop = @mal

-- Tạo thủ tục thêm lớp hành chính
create proc insertlophanhchinh
@mal varchar(50), @tenlop nvarchar(50), @magv varchar(50), @makhoa varchar(50)
as
begin
		insert into tblLopHC (sMaLop, sTenLop, sMaGV, sMaKhoa, iSiSo)
		values
		(@mal, @tenlop, @magv, @makhoa, 0)
end
