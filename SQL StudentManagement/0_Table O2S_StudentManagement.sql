--O2S_STUDENTMANAGEMENT

SELECT * FROM sys.master_files mf
file_guid:8BBF3A4E-98C7-48A8-806B-788F346020C4

 select * from sys.databases
service_broker_guid: 5E420DFE-CF84-43B0-AF33-D5BBD2DBBC38


--=================================================== table SM_LICENSE
CREATE TABLE SM_LICENSE
(
  licenseid int,
  datakey nvarchar(256),
  licensekey nvarchar(256),
  CONSTRAINT sm_license_pkey PRIMARY KEY (licenseid)
);


--=================================================== -- Table: SM_VERSION
CREATE TABLE SM_VERSION
(
  versionid int,
  appversion nvarchar(50),
  app_link nvarchar(256),
  app_type int,
  updateapp varbinary,
  appsize int,
  sqlversion nvarchar,
  updatesql varbinary,
  sqlsize int,
  sync_flag int,
  update_flag int,
  urlfullserver nvarchar(256),
  CONSTRAINT sm_version_pkey PRIMARY KEY (versionid)
);
CREATE INDEX SM_VERSION_app_type_idx ON SM_VERSION (app_type);

--=================================================== Table: SM_TBLUSER
-- DROP TABLE SM_TBLUSER;
CREATE TABLE SM_TBLUSER
(
  userid int,
  usercode nvarchar(50),
  username nvarchar(256),
  userpassword nvarchar(256),
  userstatus int,
  usergnhom int,
  usernote nvarchar(256),
  CONSTRAINT sm_tbluser_pkey PRIMARY KEY (userid)
);
CREATE INDEX SM_TBLUSER_usercode_idx ON SM_TBLUSER (usercode);
CREATE INDEX SM_TBLUSER_userstatus_idx ON SM_TBLUSER (userstatus);
CREATE INDEX SM_TBLUSER_usergnhom_idx ON SM_TBLUSER (usergnhom);



--===================================================Table: SM_TBLUSER_PERMISSION
-- DROP TABLE SM_TBLUSER_PERMISSION;
CREATE TABLE SM_TBLUSER_PERMISSION
(
  userpermissionid int,
  permissionid int,
  permissioncode nvarchar(50),
  permissionname nvarchar(256),
  userid int,
  usercode nvarchar(50),
  permissioncheck bit,
  userpermissionnote nvarchar(256),
  CONSTRAINT userpermissionid_pkey PRIMARY KEY (userpermissionid)
);
CREATE INDEX SM_UPERMISSION_userid_idx ON SM_TBLUSER_PERMISSION (userid);
CREATE INDEX SM_UPERMISSION_usercode_idx ON SM_TBLUSER_PERMISSION (usercode);
CREATE INDEX SM_UPERMISSION_permissioncode_idx ON SM_TBLUSER_PERMISSION (permissioncode);


--===================================================Table: SM_TBLLOG
CREATE TABLE SM_TBLLOG
(
  logid int,
  logusercode nvarchar(50),
  logvalue nvarchar,
  ipaddress nvarchar(256),
  computername nvarchar(256),
  softversion nvarchar(50),
  logtime datetime,
  logtypecode nvarchar(50), 
  CONSTRAINT sm_tbllog_pkey PRIMARY KEY (logid)
);
CREATE INDEX SM_TBLLOG_logusercode_idx ON SM_TBLLOG (logusercode);
CREATE INDEX SM_TBLLOG_logtypecode_idx ON SM_TBLLOG (logtypecode);
CREATE INDEX SM_TBLLOG_logtime_idx ON SM_TBLLOG (logtime);
--=================================================== Table: SM_OTHERLIST
CREATE TABLE SM_OTHERLIST
(
  otherlistid int,
  othertypelistid int,
  otherlistcode nvarchar(256),
  otherlistname nvarchar,
  otherlistvalue nvarchar,
  otherliststatus int,
  otherlistnote nvarchar,
  CONSTRAINT sm_otherlist_pkey PRIMARY KEY (otherlistid)
);
CREATE INDEX SM_OTHERLIST_othertypelistid_idx ON SM_OTHERLIST (othertypelistid);
CREATE INDEX SM_OTHERLIST_otherlistcode_idx ON SM_OTHERLIST (otherlistcode);


--=================================================== Table: SM_OTHERTYPELIST
CREATE TABLE SM_OTHERTYPELIST
(
  othertypelistid int,
  othertypelistcode nvarchar(256),
  othertypelistname nvarchar,
  othertypeliststatus int,
  othertypelistnote nvarchar,
  CONSTRAINT sm_othertypelist_pkey PRIMARY KEY (othertypelistid)
);
CREATE INDEX SM_OTHERTYPELIST_othertypelistcode_idx ON SM_OTHERTYPELIST (othertypelistcode);

--===================================================Table: SM_OPTION
CREATE TABLE SM_OPTION
(
  optionid int,
  optioncode nvarchar(256),
  optionname nvarchar,
  optionvalue nvarchar,
  optionnote nvarchar,
  optionlook int,
  optiondate datetime,
  optioncreateuser nvarchar,
  CONSTRAINT sm_option_pkey PRIMARY KEY (optionid)
);
CREATE INDEX SM_OPTION_optioncode_idx ON SM_OPTION (optioncode);











