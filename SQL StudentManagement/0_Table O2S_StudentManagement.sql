--O2S_STUDENTMANAGEMENT
/*
SELECT * FROM sys.master_files mf
file_guid:8BBF3A4E-98C7-48A8-806B-788F346020C4

 select * from sys.databases
service_broker_guid: 5E420DFE-CF84-43B0-AF33-D5BBD2DBBC38
*/

--=================================================== table SM_LICENSE
CREATE TABLE SM_LICENSE
(
  id int IDENTITY(1,1),
  datakey nvarchar(255),
  licensekey nvarchar(255),
  CONSTRAINT SM_LICENSE_pkey PRIMARY KEY (id)
);


--=================================================== -- Table: SM_VERSION
CREATE TABLE SM_VERSION
(
  id int IDENTITY(1,1),
  appversion nvarchar(50),
  app_link nvarchar(255),
  app_type int,
  updateapp varbinary,
  appsize int,
  sqlversion nvarchar,
  updatesql varbinary,
  sqlsize int,
  sync_flag int,
  update_flag int,
  urlfullserver nvarchar(255),
  CONSTRAINT sm_version_pkey PRIMARY KEY (id)
);
CREATE INDEX SM_VERSION_app_type_idx ON SM_VERSION (app_type);

--=================================================== Table: SM_TBLUSER
-- DROP TABLE SM_TBLUSER;
CREATE TABLE SM_TBLUSER
(
  id int IDENTITY(1,1),
  usercode nvarchar(50),
  username nvarchar(255),
  userpassword nvarchar(255),
  userstatus int,
  usergnhom int,
  usernote nvarchar(255),
      isremove int default 0,
	created_date datetime,
	created_by nvarchar(255),
	created_log nvarchar(255),
	modified_date datetime,
	modified_by nvarchar(255),
	modified_log nvarchar(255),
  CONSTRAINT sm_tbluser_pkey PRIMARY KEY (id)
);
CREATE INDEX SM_TBLUSER_usercode_idx ON SM_TBLUSER (usercode);
CREATE INDEX SM_TBLUSER_userstatus_idx ON SM_TBLUSER (userstatus);
CREATE INDEX SM_TBLUSER_usergnhom_idx ON SM_TBLUSER (usergnhom);



--===================================================Table: SM_TBLUSER_PERMISSION
-- DROP TABLE SM_TBLUSER_PERMISSION;
CREATE TABLE SM_TBLUSER_PERMISSION
(
  id int IDENTITY(1,1),
  permissioncode nvarchar(50),
  permissionname nvarchar(255),
  user_id int,
  usercode nvarchar(50),
  permissioncheck bit,
  ghichu nvarchar(255),
  
      isremove int default 0,
	created_date datetime,
	created_by nvarchar(255),
	created_log nvarchar(255),
	modified_date datetime,
	modified_by nvarchar(255),
	modified_log nvarchar(255),
  CONSTRAINT userpermissionid_pkey PRIMARY KEY (id)
);
CREATE INDEX SM_UPERMISSION_userid_idx ON SM_TBLUSER_PERMISSION (user_id);
CREATE INDEX SM_UPERMISSION_usercode_idx ON SM_TBLUSER_PERMISSION (usercode);
CREATE INDEX SM_UPERMISSION_permissioncode_idx ON SM_TBLUSER_PERMISSION (permissioncode);


--===================================================Table: SM_TBLLOG
CREATE TABLE SM_TBLLOG
(
  id int IDENTITY(1,1),
  logusercode nvarchar(50),
  logvalue nvarchar,
  ipaddress nvarchar(255),
  computername nvarchar(255),
  softversion nvarchar(50),
  logtime datetime,
  logtypecode nvarchar(50), 
  CONSTRAINT sm_tbllog_pkey PRIMARY KEY (id)
);
CREATE INDEX SM_TBLLOG_logusercode_idx ON SM_TBLLOG (logusercode);
CREATE INDEX SM_TBLLOG_logtypecode_idx ON SM_TBLLOG (logtypecode);
CREATE INDEX SM_TBLLOG_logtime_idx ON SM_TBLLOG (logtime);

--=================================================== Table: SM_OTHERLIST
CREATE TABLE SM_OTHERLIST
(
  id int IDENTITY(1,1),
  othertypelist_id int,
  otherlistcode nvarchar(255),
  otherlistname nvarchar,
  otherlistvalue nvarchar,
  otherliststatus int,
  otherlistnote nvarchar,
      isremove int default 0,
	created_date datetime,
	created_by nvarchar(255),
	created_log nvarchar(255),
	modified_date datetime,
	modified_by nvarchar(255),
	modified_log nvarchar(255),
  CONSTRAINT sm_otherlist_pkey PRIMARY KEY (id)
);
CREATE INDEX SM_OTHERLIST_othertypelistid_idx ON SM_OTHERLIST (othertypelist_id);
CREATE INDEX SM_OTHERLIST_otherlistcode_idx ON SM_OTHERLIST (otherlistcode);


--=================================================== Table: SM_OTHERTYPELIST
CREATE TABLE SM_OTHERTYPELIST
(
  id int IDENTITY(1,1),
  othertypelistcode nvarchar(255),
  othertypelistname nvarchar,
  othertypeliststatus int,
  othertypelistnote nvarchar,
      isremove int default 0,
	created_date datetime,
	created_by nvarchar(255),
	created_log nvarchar(255),
	modified_date datetime,
	modified_by nvarchar(255),
	modified_log nvarchar(255),
  CONSTRAINT sm_othertypelist_pkey PRIMARY KEY (id)
);
CREATE INDEX SM_OTHERTYPELIST_othertypelistcode_idx ON SM_OTHERTYPELIST (othertypelistcode);

--===================================================Table: SM_OPTION
CREATE TABLE SM_OPTION
(
  id int IDENTITY(1,1),
  optioncode nvarchar(255),
  optionname nvarchar,
  optionvalue nvarchar,
  optionnote nvarchar,
  optionlook int,
      isremove int default 0,
	created_date datetime,
	created_by nvarchar(255),
	created_log nvarchar(255),
	modified_date datetime,
	modified_by nvarchar(255),
	modified_log nvarchar(255),
  CONSTRAINT sm_option_pkey PRIMARY KEY (id)
);
CREATE INDEX SM_OPTION_optioncode_idx ON SM_OPTION (optioncode);








--===================================================Table: SM_STUDENT
CREATE TABLE SM_STUDENT
(
  id int IDENTITY(1,1),
  studentcode nvarchar(255),
  first_name nvarchar(255),
  last_name nvarchar(255),
  full_name nvarchar(500),
  gioitinh_id int,
  ngaysinh datetime,
  dantoc_id int,
  nghenghiep_id int,
  tinh_id int,
  huyen_id int,
  xa_id int,
  thonxom nvarchar,
  cmtnd nvarchar(25),
  cmtnd_ngaycap datetime,
  sodienthoai nvarchar(15),
  email nvarchar(255),
  ngayvao datetime,
  trangthai_id int,
  chuyennganh_id int,
  bangcap_id int,
  
  isremoveid int,
	created_date datetime,
	created_by nvarchar(255),
	created_log nvarchar(255),
	modified_date datetime,
	modified_by nvarchar(255),
	modified_log nvarchar(255),
  CONSTRAINT sm_student_pkey PRIMARY KEY (id)
);
CREATE INDEX SM_STUDENT_studentcode_idx ON SM_STUDENT (studentcode);
CREATE INDEX SM_STUDENT_gioitinhid_idx ON SM_STUDENT (gioitinh_id);
CREATE INDEX SM_STUDENT_dantocid_idx ON SM_STUDENT (dantoc_id);
CREATE INDEX SM_STUDENT_nghenghiepid_idx ON SM_STUDENT (nghenghiep_id);
CREATE INDEX SM_STUDENT_tinhid_idx ON SM_STUDENT (tinh_id);
CREATE INDEX SM_STUDENT_huyenid_idx ON SM_STUDENT (huyen_id);
CREATE INDEX SM_STUDENT_xaid_idx ON SM_STUDENT (xa_id);
CREATE INDEX SM_STUDENT_chuyennganhid_idx ON SM_STUDENT (chuyennganh_id);


--===================================================Table: SM_NGUOITHAN
CREATE TABLE SM_NGUOITHAN
(
  id int IDENTITY(1,1),
  student_id int,
  quanhe_id int,
  hoten nvarchar(500),
  ngaysinh datetime,
  nghenghiep_id int,
  tinh_id int,
  huyen_id int,
  xa_id int,
  thonxom nvarchar,
  ghichu nvarchar,
  
    isremove int default 0,
	created_date datetime,
	created_by nvarchar(255),
	created_log nvarchar(255),
	modified_date datetime,
	modified_by nvarchar(255),
	modified_log nvarchar(255),
  CONSTRAINT sm_nguoithan_pkey PRIMARY KEY (id)
);
CREATE INDEX SM_NGUOITHAN_studentid_idx ON SM_NGUOITHAN (student_id);
CREATE INDEX SM_NGUOITHAN_quanheid_idx ON SM_NGUOITHAN (quanhe_id);
CREATE INDEX SM_NGUOITHAN_nghenghiepid_idx ON SM_NGUOITHAN (nghenghiep_id);
CREATE INDEX SM_NGUOITHAN_tinhid_idx ON SM_NGUOITHAN (tinh_id);
CREATE INDEX SM_NGUOITHAN_huyenid_idx ON SM_NGUOITHAN (huyen_id);
CREATE INDEX SM_NGUOITHAN_xaid_idx ON SM_NGUOITHAN (xa_id);


--===================================================Table: SM_QTHOCTAP
CREATE TABLE SM_QTHOCTAP
(
  id int IDENTITY(1,1),
  student_id int,
  truonghoc_id int,
  truonghocten nvarchar,
  chuyennganh_id int,
  noidung nvarchar,
  diachi nvarchar,
  thoigianhoctu datetime,
  thoigianhocden datetime,
  hocphi decimal(18, 0),
  ketqua_id int, 
  bangcap_id int,
  ghichu nvarchar,

    isremove int default 0,
	created_date datetime,
	created_by nvarchar(255),
	created_log nvarchar(255),
	modified_date datetime,
	modified_by nvarchar(255),
	modified_log nvarchar(255),
  CONSTRAINT sm_qthoctap_pkey PRIMARY KEY (id)
);
CREATE INDEX SM_QTHOCTAP_studentid_idx ON SM_QTHOCTAP (student_id);
CREATE INDEX SM_QTHOCTAP_truonghocid_idx ON SM_QTHOCTAP (truonghoc_id);
CREATE INDEX SM_QTHOCTAP_chuyennganhid_idx ON SM_QTHOCTAP (chuyennganh_id);
CREATE INDEX SM_QTHOCTAP_ketquaid_idx ON SM_QTHOCTAP (ketqua_id);
CREATE INDEX SM_QTHOCTAP_bangcapid_idx ON SM_QTHOCTAP (bangcap_id);




--===================================================Table: SM_KTDAUVAO
CREATE TABLE SM_KTDAUVAO
(
  id int IDENTITY(1,1),
  student_id int,
  kynangnghe_id int,
  kynangnoi_id int,
  kynangviet_id int,
  ghichu nvarchar,

    isremove int default 0,
	created_date datetime,
	created_by nvarchar(255),
	created_log nvarchar(255),
	modified_date datetime,
	modified_by nvarchar(255),
	modified_log nvarchar(255),
  CONSTRAINT sm_ktdauvao_pkey PRIMARY KEY (id)
);
CREATE INDEX SM_KTDAUVAO_studentid_idx ON SM_KTDAUVAO (student_id);
CREATE INDEX SM_KTDAUVAO_kynang_ngheid_idx ON SM_KTDAUVAO (kynangnghe_id);
CREATE INDEX SM_KTDAUVAO_kynang_noiid_idx ON SM_KTDAUVAO (kynangnoi_id);
CREATE INDEX SM_KTDAUVAO_kynang_vietid_idx ON SM_KTDAUVAO (kynangviet_id);


--//QUẢN LÝ HỌC VỤ
--===================================================Table: SM_LOPHOC
CREATE TABLE SM_LOPHOC
(
  id int IDENTITY(1,1),
  lophoccode nvarchar(50),
  lophocten nvarchar(255),
  soluong int,
  ngaydukien datetime,
  ngaybatdau datetime,
  sotiethoc decimal(18,1),
  ghichu nvarchar,

    isremove int default 0,
	created_date datetime,
	created_by nvarchar(255),
	created_log nvarchar(255),
	modified_date datetime,
	modified_by nvarchar(255),
	modified_log nvarchar(255),
  CONSTRAINT sm_lophoc_pkey PRIMARY KEY (id)
);
CREATE INDEX SM_LOPHOC_lophoccode_idx ON SM_LOPHOC (lophoccode);



--===================================================Table: SM_LICHHOC
CREATE TABLE SM_LICHHOC
(
  id int IDENTITY(1,1),
  
  lophoccode nvarchar(50),
  lophocten nvarchar(255),
  soluong int,
  ngaydukien datetime,
  ngaybatdau datetime,
  sotiethoc decimal(18,1),
  ghichu nvarchar,

    isremove int default 0,
	created_date datetime,
	created_by nvarchar(255),
	created_log nvarchar(255),
	modified_date datetime,
	modified_by nvarchar(255),
	modified_log nvarchar(255),
  CONSTRAINT SM_LICHHOC_pkey PRIMARY KEY (id)
);
CREATE INDEX SM_LICHHOC_lophoccode_idx ON SM_LICHHOC (lophoccode);

--===================================================Table: DM_QUOCGIA
CREATE TABLE DM_QUOCGIA
(
  id int IDENTITY(1,1),
	name_en nvarchar(255),
	name_vn nvarchar(255),
	code nvarchar(255),
    isremove int default 0,
	created_date datetime,
	created_by nvarchar(255),
	created_log nvarchar(255),
	modified_date datetime,
	modified_by nvarchar(255),
	modified_log nvarchar(255),
  CONSTRAINT DM_QUOCGIA_pkey PRIMARY KEY (id)
);
CREATE INDEX DM_QUOCGIA_code_idx ON DM_QUOCGIA (code);

--===================================================Table: DM_TINH
CREATE TABLE DM_TINH
(
  id int IDENTITY(1,1),
	name_en nvarchar(255),
	name_vn nvarchar(255),
	code nvarchar(255),
	quocgia_id int,
	captinh_id int,
    isremove int default 0,
	created_date datetime,
	created_by nvarchar(255),
	created_log nvarchar(255),
	modified_date datetime,
	modified_by nvarchar(255),
	modified_log nvarchar(255),
  CONSTRAINT DM_TINH_pkey PRIMARY KEY (id)
);
CREATE INDEX DM_TINH_code_idx ON DM_TINH (code);
CREATE INDEX DM_TINH_quocgia_id_idx ON DM_TINH (quocgia_id);
CREATE INDEX DM_TINH_captinh_id_idx ON DM_TINH (captinh_id);

--===================================================Table: DM_HUYEN
CREATE TABLE DM_HUYEN
(
  id int IDENTITY(1,1),
	name_en nvarchar(255),
	name_vn nvarchar(255),
	code nvarchar(255),
	tinh_id int,
	caphuyen_id int,
    isremove int default 0,
	created_date datetime,
	created_by nvarchar(255),
	created_log nvarchar(255),
	modified_date datetime,
	modified_by nvarchar(255),
	modified_log nvarchar(255),
  CONSTRAINT DM_HUYEN_pkey PRIMARY KEY (id)
);
CREATE INDEX DM_HUYEN_code_idx ON DM_HUYEN (code);
CREATE INDEX DM_HUYEN_tinh_id_idx ON DM_HUYEN (tinh_id);
CREATE INDEX DM_HUYEN_caphuyen_id_idx ON DM_HUYEN (caphuyen_id);


--===================================================Table: DM_XA
CREATE TABLE DM_XA
(
  id int IDENTITY(1,1),
	name_en nvarchar(255),
	name_vn nvarchar(255),
	code nvarchar(255),
	huyen_id int,
	capxa_id int,
    isremove int default 0,
	created_date datetime,
	created_by nvarchar(255),
	created_log nvarchar(255),
	modified_date datetime,
	modified_by nvarchar(255),
	modified_log nvarchar(255),
  CONSTRAINT DM_XA_pkey PRIMARY KEY (id)
);
CREATE INDEX DM_XA_code_idx ON DM_XA (code);
CREATE INDEX DM_XA_huyen_id_idx ON DM_XA (huyen_id);
CREATE INDEX DM_XA_capxa_id_idx ON DM_XA (capxa_id);


--===================================================Table: DM_DANTOC
CREATE TABLE DM_DANTOC
(
  id int IDENTITY(1,1),
	name_en nvarchar(255),
	name_vn nvarchar(255),
	code nvarchar(255),
	name_other nvarchar,
    isremove int default 0,
	created_date datetime,
	created_by nvarchar(255),
	created_log nvarchar(255),
	modified_date datetime,
	modified_by nvarchar(255),
	modified_log nvarchar(255),
  CONSTRAINT DM_DANTOC_pkey PRIMARY KEY (id)
);
CREATE INDEX DM_DANTOC_code_idx ON DM_DANTOC (code);


--===================================================Table: DM_NGHENGHIEP
CREATE TABLE DM_NGHENGHIEP
(
  id int IDENTITY(1,1),
	name_en nvarchar(255),
	name_vn nvarchar(255),
	code nvarchar(255),
	name_other nvarchar,
    isremove int default 0,
	created_date datetime,
	created_by nvarchar(255),
	created_log nvarchar(255),
	modified_date datetime,
	modified_by nvarchar(255),
	modified_log nvarchar(255),
  CONSTRAINT DM_NGHENGHIEP_pkey PRIMARY KEY (id)
);
CREATE INDEX DM_NGHENGHIEP_code_idx ON DM_NGHENGHIEP (code);


--===================================================Table: DM_CHUYENNGANH
CREATE TABLE DM_CHUYENNGANH
(
  id int IDENTITY(1,1),
	name_en nvarchar(255),
	name_vn nvarchar(255),
	code nvarchar(255),
	name_other nvarchar,
    isremove int default 0,
	created_date datetime,
	created_by nvarchar(255),
	created_log nvarchar(255),
	modified_date datetime,
	modified_by nvarchar(255),
	modified_log nvarchar(255),
  CONSTRAINT DM_CHUYENNGANH_pkey PRIMARY KEY (id)
);
CREATE INDEX DM_CHUYENNGANH_code_idx ON DM_CHUYENNGANH (code);


--===================================================Table: DM_BANGCAP
CREATE TABLE DM_BANGCAP
(
  id int IDENTITY(1,1),
	name_en nvarchar(255),
	name_vn nvarchar(255),
	code nvarchar(255),
	name_other nvarchar,
    isremove int default 0,
	created_date datetime,
	created_by nvarchar(255),
	created_log nvarchar(255),
	modified_date datetime,
	modified_by nvarchar(255),
	modified_log nvarchar(255),
  CONSTRAINT DM_BANGCAP_pkey PRIMARY KEY (id)
);
CREATE INDEX DM_BANGCAP_code_idx ON DM_BANGCAP (code);











