use[QL_SuDungThietBi]

---
create procedure Pro_ThietBiThanhLy
as
begin
	select * from THIETBITHANHLY
end 

---

create procedure Pro_ThietBi
as
begin
	select * from THIETBI
end 

---

create procedure Pro_LoaiThietBi
as
begin
	Select MA_LOAI, TEN_LOAI From LOAITHIETBI
end

---

create procedure Pro_Insert_THIETBITHANHLY
		@MaTB nvarchar(15),
		@MaCanBo nvarchar(5),
		@TinhTrang nvarchar(20),
		@GhiChu nvarchar(50)
as
begin
	Insert Into THIETBITHANHLY 
	Values(@MaTB, @MaCanBo, @TinhTrang, GETDATE(), @GhiChu)
end  

---

exec Pro_Insert_THIETBITHANHLY 'CASTLE01', '10', 'Moi', '123456'

---

create procedure Pro_Delete_THIETBITHANHLY
		@MaTB nvarchar(15)
as
begin
	Delete THIETBITHANHLY where MA_TB = @MaTB
end  

---

exec Pro_Delete_THIETBITHANHLY '16801230001'
