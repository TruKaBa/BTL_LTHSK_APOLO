-- 
Create proc selecthoc
as
select * from tblHoc

--	Tạo thủ tục trích ra các sinh viên học @maMon, @maMon là tham số tuyền vào
create proc selectsinhvienhocmon
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

--	Tạo thủ tục thêm mới một môn học
create proc insertmonhoc
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

--Tạo thủ tục Thống kê sinh viên đã từng phải học lại ít nhất 2 lần theo môn, với mã môn là tham số truyền vào
CREATE PROC selectdanhsachhoclaitheomon @maMon varchar(50) AS
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

--Tạo thử tục select tất cả môn học
create proc getAllSubject
as
	select sMaMon, sTenMon, iSoTC, sTenKhoa  
	from tblMonHoc as mon, tblKhoa as khoa
	where mon.sMaKhoa = khoa.sMaKhoa

--Tao store pro cho bang mon hoc
create proc selectmonhoctheoma
@mamon varchar(50)
as
select *
from tblMonHoc
where sMaMon = @mamon


