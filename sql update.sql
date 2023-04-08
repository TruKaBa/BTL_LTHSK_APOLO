use QUANLYGIANGDAY2;
go;


/****** Object:  StoredProcedure [dbo].[updateMon]    Script Date: 4/6/2023 8:11:52 PM ******/
DROP PROCEDURE [dbo].[updateMon]
GO


create proc [dbo].[updateMon]
@Mamon varchar(20),@MaKhoa varchar(30),@TenMon nvarchar(30), @Tc int
as
begin
update tblMonHoc
set 
	sMaKhoa=@MaKhoa,
	sTenMon=@TenMon,
	iSoTC=@Tc
	where sMaMon=@Mamon
end
GO

DROP PROCEDURE [dbo].[deleteMon]
GO


create proc [dbo].[deleteMon]
@Mamon varchar(20)
as
begin
delete from tblMonHoc where sMaMon=@Mamon
end
GO


CREATE proc [dbo].[getAllSubject]
  as
  begin
	select sMaMon,sTenKhoa,tblMonHoc.sMaKhoa,sTenMon,iSoTC
	from tblMonHoc inner join tblKhoa
	on tblMonHoc.sMaKhoa=tblKhoa.sMaKhoa;
  end
GO


create proc [dbo].[checkPrimaryKeySubject] @id varchar(20)
  as
  begin
	select sMaMon
	from tblMonHoc 
	where @id=sMaMon;
  end

go


create proc [dbo].[selectMon]
as select * from tblMonHoc;
GO



create proc Select_GV_MonHoc @maMon varchar(50)
as
begin
	
	select tblGiangVien.sTenGV,tblGiangVien.sMaGV,tblKhoa.sTenKhoa,tblMonHoc.sMaMon,tblMonHoc.sTenMon

	from tblGiangVien join tblHoc on tblGiangVien.sMaGV= tblHoc.sMaGV
	join tblMonHoc on tblHoc.sMaMon=tblMonHoc.sMaMon
	join tblKhoa on tblGiangVien.sMaKhoa=tblKhoa.sMaKhoa
	
	where tblMonHoc.sMaMon=@maMon
	
	group by tblGiangVien.sTenGV,tblGiangVien.sMaGV,tblKhoa.sTenKhoa,tblMonHoc.sMaMon,tblMonHoc.sTenMon
end
go


create proc select_subject_name @maMon varchar(50)
as
begin
	select sMaMon,sTenMon
	from tblMonHoc
end
go