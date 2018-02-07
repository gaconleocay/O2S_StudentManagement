-- Bảng tiếp nhận học viên
- Thêm cột: Loại học viên; ngày tiếp nhận; địa chỉ
- Tìm kiếm: Từ ngày - đến ngày theo ngày tiếp nhận
- Thêm trường ngày tiếp nhận ??

-- Bảng lập phiếu ghi danh:
- Tìm kiếm học viên thêm cột: loại học viên, ngày tiếp nhận, địa chỉ, sđt, email
- DS phiếu ghi danh thêm cột: khóa học, học phí, 

-- Bảng quản lý điểm
- Thêm cột: địa chỉ, sđt, email





--QUYDINH
Alter table QUYDINH add IsRemoveid int;
Alter table QUYDINH add CreatedDate datetime default sysdatetime() ;
Alter table QUYDINH add CreatedBy nvarchar(255);
Alter table QUYDINH add CreatedLog nvarchar(255);
Alter table QUYDINH add ModifiedDate datetime default sysdatetime() ;
Alter table QUYDINH add ModifiedBy nvarchar(255);
Alter table QUYDINH add ModifiedLog nvarchar(255);

--TAIKHOAN
Alter table TAIKHOAN add IsRemoveid int;
Alter table TAIKHOAN add CreatedDate datetime default sysdatetime() ;
Alter table TAIKHOAN add CreatedBy nvarchar(255);
Alter table TAIKHOAN add CreatedLog nvarchar(255);
Alter table TAIKHOAN add ModifiedDate datetime default sysdatetime() ;
Alter table TAIKHOAN add ModifiedBy nvarchar(255);
Alter table TAIKHOAN add ModifiedLog nvarchar(255);


--NHANVIEN
Alter table NHANVIEN add NgaySinh datetime;
Alter table NHANVIEN add DiaChi nvarchar(1000);
Alter table NHANVIEN add IsRemoveid int;
Alter table NHANVIEN add CreatedDate datetime default sysdatetime() ;
Alter table NHANVIEN add CreatedBy nvarchar(255);
Alter table NHANVIEN add CreatedLog nvarchar(255);
Alter table NHANVIEN add ModifiedDate datetime default sysdatetime() ;
Alter table NHANVIEN add ModifiedBy nvarchar(255);
Alter table NHANVIEN add ModifiedLog nvarchar(255);

--LOPHOC
Alter table LOPHOC add IsRemoveid int;
Alter table LOPHOC add CreatedDate datetime default sysdatetime() ;
Alter table LOPHOC add CreatedBy nvarchar(255);
Alter table LOPHOC add CreatedLog nvarchar(255);
Alter table LOPHOC add ModifiedDate datetime default sysdatetime() ;
Alter table LOPHOC add ModifiedBy nvarchar(255);
Alter table LOPHOC add ModifiedLog nvarchar(255);


--LOAINV
Alter table LOAINV add IsRemoveid int;
Alter table LOAINV add CreatedDate datetime default sysdatetime() ;
Alter table LOAINV add CreatedBy nvarchar(255);
Alter table LOAINV add CreatedLog nvarchar(255);
Alter table LOAINV add ModifiedDate datetime default sysdatetime() ;
Alter table LOAINV add ModifiedBy nvarchar(255);
Alter table LOAINV add ModifiedLog nvarchar(255);


--LOAIHV
Alter table LOAIHV add IsRemoveid int;
Alter table LOAIHV add CreatedDate datetime default sysdatetime() ;
Alter table LOAIHV add CreatedBy nvarchar(255);
Alter table LOAIHV add CreatedLog nvarchar(255);
Alter table LOAIHV add ModifiedDate datetime default sysdatetime() ;
Alter table LOAIHV add ModifiedBy nvarchar(255);
Alter table LOAIHV add ModifiedLog nvarchar(255);


--KHOAHOC
Alter table KHOAHOC add IsRemoveid int;
Alter table KHOAHOC add CreatedDate datetime default sysdatetime() ;
Alter table KHOAHOC add CreatedBy nvarchar(255);
Alter table KHOAHOC add CreatedLog nvarchar(255);
Alter table KHOAHOC add ModifiedDate datetime default sysdatetime() ;
Alter table KHOAHOC add ModifiedBy nvarchar(255);
Alter table KHOAHOC add ModifiedLog nvarchar(255);


--HOCVIEN
Alter table HOCVIEN add IsRemoveid int;
Alter table HOCVIEN add CreatedDate datetime default sysdatetime() ;
Alter table HOCVIEN add CreatedBy nvarchar(255);
Alter table HOCVIEN add CreatedLog nvarchar(255);
Alter table HOCVIEN add ModifiedDate datetime default sysdatetime() ;
Alter table HOCVIEN add ModifiedBy nvarchar(255);
Alter table HOCVIEN add ModifiedLog nvarchar(255);


--GIANGVIEN
Alter table GIANGVIEN add NgaySinh datetime;
Alter table GIANGVIEN add DiaChi nvarchar(1000);
Alter table GIANGVIEN add IsRemoveid int;
Alter table GIANGVIEN add CreatedDate datetime default sysdatetime() ;
Alter table GIANGVIEN add CreatedBy nvarchar(255);
Alter table GIANGVIEN add CreatedLog nvarchar(255);
Alter table GIANGVIEN add ModifiedDate datetime default sysdatetime() ;
Alter table GIANGVIEN add ModifiedBy nvarchar(255);
Alter table GIANGVIEN add ModifiedLog nvarchar(255);


--GIANGDAY
Alter table GIANGDAY add IsRemoveid int;
Alter table GIANGDAY add CreatedDate datetime default sysdatetime() ;
Alter table GIANGDAY add CreatedBy nvarchar(255);
Alter table GIANGDAY add CreatedLog nvarchar(255);
Alter table GIANGDAY add ModifiedDate datetime default sysdatetime() ;
Alter table GIANGDAY add ModifiedBy nvarchar(255);
Alter table GIANGDAY add ModifiedLog nvarchar(255);


--DANGKY
Alter table DANGKY add IsRemoveid int;
Alter table DANGKY add CreatedDate datetime default sysdatetime() ;
Alter table DANGKY add CreatedBy nvarchar(255);
Alter table DANGKY add CreatedLog nvarchar(255);
Alter table DANGKY add ModifiedDate datetime default sysdatetime() ;
Alter table DANGKY add ModifiedBy nvarchar(255);
Alter table DANGKY add ModifiedLog nvarchar(255);


--BANGDIEM
Alter table BANGDIEM add IsRemoveid int;
Alter table BANGDIEM add CreatedDate datetime default sysdatetime() ;
Alter table BANGDIEM add CreatedBy nvarchar(255);
Alter table BANGDIEM add CreatedLog nvarchar(255);
Alter table BANGDIEM add ModifiedDate datetime default sysdatetime() ;
Alter table BANGDIEM add ModifiedBy nvarchar(255);
Alter table BANGDIEM add ModifiedLog nvarchar(255);


--PHIEUGHIDANH
Alter table PHIEUGHIDANH add IsRemoveid int;
Alter table PHIEUGHIDANH add CreatedDate datetime default sysdatetime() ;
Alter table PHIEUGHIDANH add CreatedBy nvarchar(255);
Alter table PHIEUGHIDANH add CreatedLog nvarchar(255);
Alter table PHIEUGHIDANH add ModifiedDate datetime default sysdatetime() ;
Alter table PHIEUGHIDANH add ModifiedBy nvarchar(255);
Alter table PHIEUGHIDANH add ModifiedLog nvarchar(255);

--===================================================Table: PHIEUTHU
CREATE TABLE PHIEUTHU
(
	ID int IDENTITY(1,1),
	MaPhieuThu int,
	SoThuID int,
	PhieuGhiDanhID int,
	MaHocVien nvarchar(6),
	LoaiPhieuThuID int,
	SoTien numeric(18, 0),
	GhiChu nvarchar(255),
    IsRemove int default 0,
	CreatedDate datetime default sysdatetime() ,
	CreatedBy nvarchar(255),
	CreatedLog nvarchar(255),
	ModifiedDate datetime default sysdatetime() ,
	ModifiedBy nvarchar(255),
	ModifiedLog nvarchar(255),
  CONSTRAINT PHIEUTHU_pkey PRIMARY KEY (id)
);
CREATE INDEX PHIEUTHU_MaHocVien_idx ON PHIEUTHU (MaHocVien);



--=================================================== table LICENSE
CREATE TABLE LICENSE
(
  ID int IDENTITY(1,1),
  DataKey nvarchar(255),
  LicenseKey nvarchar(255),
  CONSTRAINT LICENSE_pkey PRIMARY KEY (ID)
);


--=================================================== -- Table: VERSION
CREATE TABLE VERSION
(
  ID int IDENTITY(1,1),
  AppVersion nvarchar(50),
  AppLink nvarchar(255),
  AppType int,
  AppResults varbinary(MAX),
  AppMD5Hash nvarchar(255),
  SqlVersion nvarchar(50),
  SqlResults varbinary,
  CONSTRAINT VERSION_pkey PRIMARY KEY (ID)
);
CREATE INDEX VERSION_AppType_idx ON VERSION (AppType);






