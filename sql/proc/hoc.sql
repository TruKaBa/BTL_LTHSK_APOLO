-- cho biết những lớp học mà sinh viên đã học
create proc selecthoctheomamonmasinhvien
@mamon varchar(50), @masv varchar(50)
as
select * from tblHoc
where sMaMon = @mamon and sMaSV = @masv

create proc inserthoc
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

-- xóa học
create proc deletehoc
@magv varchar(50), @mamon varchar(50), @masv varchar(50)
as
delete from tblHoc
where sMaGV = @magv and sMaMon = @mamon and sMaSV = @masv

--update 
create proc updatediemthanhphan
@magv varchar(50), @mamon varchar(50), @masv varchar(50), @diemcc float, @diemgk float, @diemthi float
as
update tblHoc
set fDiemCC = @diemcc, fDiemGK = @diemgk, fDiemThi = @diemthi, fDiemKTHP = @diemcc * 0.1 + @diemgk * 0.2 + @diemthi * 0.3
where sMaGV = @magv and sMaMon = @mamon and sMaSV = @masv

