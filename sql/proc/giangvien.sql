
--	Tạo thủ tục chèn thêm 1 giáo viên mới(kiểm tra thỏa mãn điều kiện)
create proc insertgiangvien
@magv varchar(50), @ten nvarchar(50), @gioitinh nvarchar(10), @ngaysinh date, @mak varchar(50)
as
insert into tblGiangVien (sMaGV, sTenGV, sGioiTinh, dNgaySinh, sMaKhoa)
values (@magv, @ten, @gioitinh, @ngaysinh, @mak)


--	Tạo thủ tục cho danh sách các giáo viên nam thuộc khoa nào với tên khoa là tham số truyền vào
create proc selectdanhsachgiaoviennamthuockhoa
@tenk nvarchar(50)
as
select sTenGV, sGioiTinh
from tblGiangVien, tblKhoa
where tblGiangVien.sMaKhoa = tblKhoa.sMaKhoa
and sTenKhoa = @tenk
and sGioiTinh = N'Nam'

--	Tạo thủ tục cho danh sách các giáo viên sinh năm nào đó với năm là tham số truyền vào
create proc selectindanhsachgiaovientheonamsinh
@nam int
as
select sTenGV, dNgaySinh
from tblGiangVien
where year(dngaySinh) = @nam


	/*Tạo thủ tục, thay đổi cố vấn học tập(giảng viên chủ nhiệm) quản lý lớp hành chính,
với mã giảng viên, mã lớp là tham số truyền vào*/
CREATE proc updatecovanhoctap
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

--	Tạo thủ tục cho biết danh sách giảng viên trên số tuổi, với số tuổi là tham số truyền vào
create PROC selectgiangvientheotuoi
@tuoi int
as
select sTenGV, datediff(day, dNgaySinh, getdate())/365 as [Tuổi]
from tblGiangVien
where datediff(day, dNgaySinh, getdate())/365 > @tuoi

-- Tạo store proc cho bang giang vien
create proc selectgiangvientheoma
@magv varchar(50)
as
select *
from tblGiangVien
where sMaGV = @magv
