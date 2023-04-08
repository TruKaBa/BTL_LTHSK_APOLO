--	Tạo thủ tục cho biết tổng số lượng giảng viên nữ của 1 khoa với khoa là tham số truyền vào
create proc selectdemsogiaoviennu
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



--	Tạo thủ tục thêm 1 khoa
create proc insertkhoa
@mak varchar(50), @tenk nvarchar(50), @dc nvarchar(50)
as
insert into tblKhoa (sMaKhoa, sTenKhoa, sDiaChi)
values (@mak, @tenk, @dc)


--	Tạo thủ tục sửa mã khoa của 1 môn theo mã môn được truyền vào
create proc updatedoimakhoacungcap
@mam varchar(50), @mak varchar(50)
as
update tblMonHoc
set sMaKhoa = @mak
where sMaMon = @mam
-- create proc cho khoa
create proc selectkhoa
as
select * from tblKhoa

--thủ tục lấy ra mã khoa
create proc selectmakhoa 
@tenkhoa nvarchar(50)
as
select sMaKhoa from tblKhoa
where sTenKhoa = @tenkhoa

--	Tạo thủ tục trích ra các sinh viên là sinh viên của @maKhoa, @maKhoa là tham số tuyền vào
create proc selectthongkesinhvienthuockhoa
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


--	Tạo thủ tục lấy số lượng sinh viên nam và nữ trong 1 khoa, với mã khoa là tham số truyền vào, số lượng là tham số output
create proc caldemsoluongsinhviennamnu
@mak varchar(50), @nam int output, @nu int output
as
begin
	if exists (select * from tblKhoa where sMaKhoa = @mak)
	begin
		set @nam = 0
		set @nu = 0
		select @nam = count(*)
		from tblSinhVien, tblLopHC, tblKhoa
		where tblSinhVien.sLopHC = tblLopHC.sMaLop
		and tblKhoa.sMaKhoa = tblLopHC.sMaKhoa
		and sGioiTinh = N'Nam'
		and tblKhoa.sMaKhoa = @mak;
		select @nu = count(*)
		from tblSinhVien, tblLopHC, tblKhoa
		where tblSinhVien.sLopHC = tblLopHC.sMaLop
		and tblKhoa.sMaKhoa = tblLopHC.sMaKhoa
		and sGioiTinh = N'Nữ'
		and tblKhoa.sMaKhoa = @mak;
	end
	else
	begin
		print N'KHÔNG TÌM THẤY KHOA'
		return
	end
end
