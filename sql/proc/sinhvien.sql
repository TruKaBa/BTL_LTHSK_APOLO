-- Thủ tục lấy toàn bộ sinh viên
create proc selectsinhvien
as
select * from tblSinhVien


--	Tạo thủ tục thêm sinh viên
create proc insertsinhvien
@masv varchar(50), @ten nvarchar(50), @ngaysinh datetime, @diachi nvarchar(50), @gt nvarchar(10), @malop varchar(50), @sdt varchar(10)
as
insert into tblSinhVien (sMaSV, sTenSV, dNgaySinh, sDiaChi, sGioiTinh, sLopHC, sSDT)
values (@masv, @ten, @ngaysinh, @diachi, @gt, @malop, @sdt)



--	Tạo thủ tục sửa tên sinh viên theo mã sinh viên
create proc updatetensinhvien
@ma varchar(50), @ten nvarchar(50)
as
update tblSinhVien
set sTenSV = @ten
where sMaSV = @ma

 -- xóa sinh viên
create proc deletesinhvien
@ma varchar(50)
as
delete from tblSinhVien
where sMaSV = @ma

--	Sửa địa chỉ của sinh viên thong qua mã sinh viên truyền vào
create proc updatediachisinhvien
@ma varchar(50), @dc nvarchar(50)
as
update tblSinhVien
set sDiaChi = @dc
where sMaSV = @ma

 
--	Cho biết danh sách môn (tên môn) của sinh viên đã học, với mã sinh viên là tham số truyền vào
create proc selectmontichluy
@masv varchar(50)
as
select distinct sTenMon
from tblSinhVien, tblHoc, tblMonHoc
where tblSinhVien.sMaSV = tblHoc.sMaSV
and tblHoc.sMaMon = tblMonHoc.sMaMon
and tblSinhVien.sMaSV = @masv

-- Tìm kiếm sinh viên theo mã sinh viên
create proc selectsinhvientheoma
@masv varchar(50)
as
select *
from tblSinhVien
where sMaSV = @masv


/* -	Tạo thủ tục tính số tiền học phải đóng của sinh viên, 
với mã sinh viên là tham số truyền vào, số lượng tín chỉ của sinh viên đó là trả về. 
Biết 1 TC là 378.000 */
--CREATE PROC caltinhtienhoccuasinhvien
--@masv varchar(50)
--as
--begin
--	if exists (select * from tblSinhVien where sMaSV = @masv)
--	begin
--		select iSoTC * 378000
--		from tblSinhVien
--		where @masv = sMaSV
--	end
--	else
--	begin
--		print N'KHÔNG TÌM THẤY SINH VIÊN'
--		return
--	end
--end


