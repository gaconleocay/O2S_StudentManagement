
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/17/2018 15:30:43
-- Generated from EDMX file: C:\PROJECT\O2S_StudentManagement\trunk\O2S_StudentManagement\DAL\DatabaseModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [O2S_STUDENTMANAGEMENT];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[DM_DANTOC]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DM_DANTOC];
GO
IF OBJECT_ID(N'[dbo].[DM_HUYEN]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DM_HUYEN];
GO
IF OBJECT_ID(N'[dbo].[DM_QUOCGIA]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DM_QUOCGIA];
GO
IF OBJECT_ID(N'[dbo].[DM_TINH]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DM_TINH];
GO
IF OBJECT_ID(N'[dbo].[DM_XA]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DM_XA];
GO
IF OBJECT_ID(N'[dbo].[SM_KTDAUVAO]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SM_KTDAUVAO];
GO
IF OBJECT_ID(N'[dbo].[SM_LICENSE]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SM_LICENSE];
GO
IF OBJECT_ID(N'[dbo].[SM_LICHHOC]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SM_LICHHOC];
GO
IF OBJECT_ID(N'[dbo].[SM_LOPHOC]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SM_LOPHOC];
GO
IF OBJECT_ID(N'[dbo].[SM_NGUOITHAN]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SM_NGUOITHAN];
GO
IF OBJECT_ID(N'[dbo].[SM_OPTION]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SM_OPTION];
GO
IF OBJECT_ID(N'[dbo].[SM_OTHERLIST]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SM_OTHERLIST];
GO
IF OBJECT_ID(N'[dbo].[SM_OTHERTYPELIST]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SM_OTHERTYPELIST];
GO
IF OBJECT_ID(N'[dbo].[SM_QTHOCTAP]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SM_QTHOCTAP];
GO
IF OBJECT_ID(N'[dbo].[SM_STUDENT]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SM_STUDENT];
GO
IF OBJECT_ID(N'[dbo].[SM_TBLLOG]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SM_TBLLOG];
GO
IF OBJECT_ID(N'[dbo].[SM_TBLUSER]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SM_TBLUSER];
GO
IF OBJECT_ID(N'[dbo].[SM_TBLUSER_PERMISSION]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SM_TBLUSER_PERMISSION];
GO
IF OBJECT_ID(N'[dbo].[SM_VERSION]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SM_VERSION];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'SM_LICENSE'
CREATE TABLE [dbo].[SM_LICENSE] (
    [licenseid] int  NOT NULL,
    [datakey] nvarchar(255)  NULL,
    [licensekey] nvarchar(255)  NULL,
    [id] int  NOT NULL
);
GO

-- Creating table 'SM_OPTION'
CREATE TABLE [dbo].[SM_OPTION] (
    [optionid] int  NOT NULL,
    [optioncode] nvarchar(255)  NULL,
    [optionname] nvarchar(1)  NULL,
    [optionvalue] nvarchar(1)  NULL,
    [optionnote] nvarchar(1)  NULL,
    [optionlook] int  NULL,
    [optiondate] datetime  NULL,
    [optioncreateuser] nvarchar(1)  NULL,
    [id] int  NOT NULL,
    [isremove] int  NULL,
    [created_date] datetime  NULL,
    [created_by] nvarchar(255)  NULL,
    [created_log] nvarchar(255)  NULL,
    [modified_date] datetime  NULL,
    [modified_by] nvarchar(255)  NULL,
    [modified_log] nvarchar(255)  NULL
);
GO

-- Creating table 'SM_OTHERLIST'
CREATE TABLE [dbo].[SM_OTHERLIST] (
    [otherlistid] int  NOT NULL,
    [othertypelistid] int  NULL,
    [otherlistcode] nvarchar(255)  NULL,
    [otherlistname] nvarchar(1)  NULL,
    [otherlistvalue] nvarchar(1)  NULL,
    [otherliststatus] int  NULL,
    [otherlistnote] nvarchar(1)  NULL,
    [id] int  NOT NULL,
    [othertypelist_id] int  NULL,
    [isremove] int  NULL,
    [created_date] datetime  NULL,
    [created_by] nvarchar(255)  NULL,
    [created_log] nvarchar(255)  NULL,
    [modified_date] datetime  NULL,
    [modified_by] nvarchar(255)  NULL,
    [modified_log] nvarchar(255)  NULL
);
GO

-- Creating table 'SM_OTHERTYPELIST'
CREATE TABLE [dbo].[SM_OTHERTYPELIST] (
    [othertypelistid] int  NOT NULL,
    [othertypelistcode] nvarchar(255)  NULL,
    [othertypelistname] nvarchar(1)  NULL,
    [othertypeliststatus] int  NULL,
    [othertypelistnote] nvarchar(1)  NULL,
    [id] int  NOT NULL,
    [isremove] int  NULL,
    [created_date] datetime  NULL,
    [created_by] nvarchar(255)  NULL,
    [created_log] nvarchar(255)  NULL,
    [modified_date] datetime  NULL,
    [modified_by] nvarchar(255)  NULL,
    [modified_log] nvarchar(255)  NULL
);
GO

-- Creating table 'SM_TBLLOG'
CREATE TABLE [dbo].[SM_TBLLOG] (
    [logid] int  NOT NULL,
    [logusercode] nvarchar(50)  NULL,
    [logvalue] nvarchar(1)  NULL,
    [ipaddress] nvarchar(255)  NULL,
    [computername] nvarchar(255)  NULL,
    [softversion] nvarchar(50)  NULL,
    [logtime] datetime  NULL,
    [logtypecode] nvarchar(50)  NULL,
    [id] int  NOT NULL
);
GO

-- Creating table 'SM_TBLUSER'
CREATE TABLE [dbo].[SM_TBLUSER] (
    [userid] int  NOT NULL,
    [usercode] nvarchar(50)  NULL,
    [username] nvarchar(255)  NULL,
    [userpassword] nvarchar(255)  NULL,
    [userstatus] int  NULL,
    [usergnhom] int  NULL,
    [usernote] nvarchar(255)  NULL,
    [id] int  NOT NULL,
    [isremove] int  NULL,
    [created_date] datetime  NULL,
    [created_by] nvarchar(255)  NULL,
    [created_log] nvarchar(255)  NULL,
    [modified_date] datetime  NULL,
    [modified_by] nvarchar(255)  NULL,
    [modified_log] nvarchar(255)  NULL
);
GO

-- Creating table 'SM_TBLUSER_PERMISSION'
CREATE TABLE [dbo].[SM_TBLUSER_PERMISSION] (
    [userpermissionid] int  NOT NULL,
    [permissionid] int  NULL,
    [permissioncode] nvarchar(50)  NULL,
    [permissionname] nvarchar(255)  NULL,
    [userid] int  NULL,
    [usercode] nvarchar(50)  NULL,
    [permissioncheck] bit  NULL,
    [userpermissionnote] nvarchar(256)  NULL,
    [id] int  NOT NULL,
    [user_id] int  NULL,
    [ghichu] nvarchar(255)  NULL,
    [isremove] int  NULL,
    [created_date] datetime  NULL,
    [created_by] nvarchar(255)  NULL,
    [created_log] nvarchar(255)  NULL,
    [modified_date] datetime  NULL,
    [modified_by] nvarchar(255)  NULL,
    [modified_log] nvarchar(255)  NULL
);
GO

-- Creating table 'SM_VERSION'
CREATE TABLE [dbo].[SM_VERSION] (
    [versionid] int  NOT NULL,
    [appversion] nvarchar(50)  NULL,
    [app_link] nvarchar(255)  NULL,
    [app_type] int  NULL,
    [updateapp] varbinary(1)  NULL,
    [appsize] int  NULL,
    [sqlversion] nvarchar(1)  NULL,
    [updatesql] varbinary(1)  NULL,
    [sqlsize] int  NULL,
    [sync_flag] int  NULL,
    [update_flag] int  NULL,
    [urlfullserver] nvarchar(255)  NULL,
    [id] int  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'DM_DANTOC'
CREATE TABLE [dbo].[DM_DANTOC] (
    [id] int  NOT NULL,
    [name_en] nvarchar(255)  NULL,
    [name_vn] nvarchar(255)  NULL,
    [code] nvarchar(255)  NULL,
    [name_other] nvarchar(1)  NULL,
    [ISREMOVE] int  NULL,
    [created_date] datetime  NULL,
    [created_by] nvarchar(255)  NULL,
    [created_log] nvarchar(255)  NULL,
    [modified_date] datetime  NULL,
    [modified_by] nvarchar(255)  NULL,
    [modified_log] nvarchar(255)  NULL
);
GO

-- Creating table 'DM_HUYEN'
CREATE TABLE [dbo].[DM_HUYEN] (
    [id] int  NOT NULL,
    [name_en] nvarchar(255)  NULL,
    [name_vn] nvarchar(255)  NULL,
    [code] nvarchar(255)  NULL,
    [tinh_id] int  NULL,
    [caphuyen_id] int  NULL,
    [isremove] int  NULL,
    [created_date] datetime  NULL,
    [created_by] nvarchar(255)  NULL,
    [created_log] nvarchar(255)  NULL,
    [modified_date] datetime  NULL,
    [modified_by] nvarchar(255)  NULL,
    [modified_log] nvarchar(255)  NULL
);
GO

-- Creating table 'DM_QUOCGIA'
CREATE TABLE [dbo].[DM_QUOCGIA] (
    [id] int  NOT NULL,
    [name_en] nvarchar(255)  NULL,
    [name_vn] nvarchar(255)  NULL,
    [code] nvarchar(255)  NULL,
    [isremove] int  NULL,
    [created_date] datetime  NULL,
    [created_by] nvarchar(255)  NULL,
    [created_log] nvarchar(255)  NULL,
    [modified_date] datetime  NULL,
    [modified_by] nvarchar(255)  NULL,
    [modified_log] nvarchar(255)  NULL
);
GO

-- Creating table 'DM_TINH'
CREATE TABLE [dbo].[DM_TINH] (
    [id] int  NOT NULL,
    [name_en] nvarchar(255)  NULL,
    [name_vn] nvarchar(255)  NULL,
    [code] nvarchar(255)  NULL,
    [quocgia_id] int  NULL,
    [captinh_id] int  NULL,
    [isremove] int  NULL,
    [created_date] datetime  NULL,
    [created_by] nvarchar(255)  NULL,
    [created_log] nvarchar(255)  NULL,
    [modified_date] datetime  NULL,
    [modified_by] nvarchar(255)  NULL,
    [modified_log] nvarchar(255)  NULL
);
GO

-- Creating table 'DM_XA'
CREATE TABLE [dbo].[DM_XA] (
    [id] int  NOT NULL,
    [name_en] nvarchar(255)  NULL,
    [name_vn] nvarchar(255)  NULL,
    [code] nvarchar(255)  NULL,
    [huyen_id] int  NULL,
    [capxa_id] int  NULL,
    [isremove] int  NULL,
    [created_date] datetime  NULL,
    [created_by] nvarchar(255)  NULL,
    [created_log] nvarchar(255)  NULL,
    [modified_date] datetime  NULL,
    [modified_by] nvarchar(255)  NULL,
    [modified_log] nvarchar(255)  NULL
);
GO

-- Creating table 'SM_KTDAUVAO'
CREATE TABLE [dbo].[SM_KTDAUVAO] (
    [id] int  NOT NULL,
    [student_id] int  NULL,
    [kynangnghe_id] int  NULL,
    [kynangnoi_id] int  NULL,
    [kynangviet_id] int  NULL,
    [ghichu] nvarchar(1)  NULL,
    [isremove] int  NULL,
    [created_date] datetime  NULL,
    [created_by] nvarchar(255)  NULL,
    [created_log] nvarchar(255)  NULL,
    [modified_date] datetime  NULL,
    [modified_by] nvarchar(255)  NULL,
    [modified_log] nvarchar(255)  NULL
);
GO

-- Creating table 'SM_LICHHOC'
CREATE TABLE [dbo].[SM_LICHHOC] (
    [id] int  NOT NULL,
    [lophoccode] nvarchar(50)  NULL,
    [lophocten] nvarchar(255)  NULL,
    [soluong] int  NULL,
    [ngaydukien] datetime  NULL,
    [ngaybatdau] datetime  NULL,
    [sotiethoc] decimal(18,1)  NULL,
    [ghichu] nvarchar(1)  NULL,
    [isremove] int  NULL,
    [created_date] datetime  NULL,
    [created_by] nvarchar(255)  NULL,
    [created_log] nvarchar(255)  NULL,
    [modified_date] datetime  NULL,
    [modified_by] nvarchar(255)  NULL,
    [modified_log] nvarchar(255)  NULL
);
GO

-- Creating table 'SM_LOPHOC'
CREATE TABLE [dbo].[SM_LOPHOC] (
    [id] int  NOT NULL,
    [lophoccode] nvarchar(50)  NULL,
    [lophocten] nvarchar(255)  NULL,
    [soluong] int  NULL,
    [ngaydukien] datetime  NULL,
    [ngaybatdau] datetime  NULL,
    [sotiethoc] decimal(18,1)  NULL,
    [ghichu] nvarchar(1)  NULL,
    [isremove] int  NULL,
    [created_date] datetime  NULL,
    [created_by] nvarchar(255)  NULL,
    [created_log] nvarchar(255)  NULL,
    [modified_date] datetime  NULL,
    [modified_by] nvarchar(255)  NULL,
    [modified_log] nvarchar(255)  NULL
);
GO

-- Creating table 'SM_NGUOITHAN'
CREATE TABLE [dbo].[SM_NGUOITHAN] (
    [id] int  NOT NULL,
    [student_id] int  NULL,
    [quanhe_id] int  NULL,
    [hoten] nvarchar(500)  NULL,
    [ngaysinh] datetime  NULL,
    [nghenghiep_id] int  NULL,
    [tinh_id] int  NULL,
    [huyen_id] int  NULL,
    [xa_id] int  NULL,
    [thonxom] nvarchar(1)  NULL,
    [ghichu] nvarchar(1)  NULL,
    [isremove] int  NULL,
    [created_date] datetime  NULL,
    [created_by] nvarchar(255)  NULL,
    [created_log] nvarchar(255)  NULL,
    [modified_date] datetime  NULL,
    [modified_by] nvarchar(255)  NULL,
    [modified_log] nvarchar(255)  NULL
);
GO

-- Creating table 'SM_QTHOCTAP'
CREATE TABLE [dbo].[SM_QTHOCTAP] (
    [id] int  NOT NULL,
    [student_id] int  NULL,
    [truonghoc_id] int  NULL,
    [truonghocten] nvarchar(1)  NULL,
    [chuyennganh_id] int  NULL,
    [noidung] nvarchar(1)  NULL,
    [diachi] nvarchar(1)  NULL,
    [thoigianhoctu] datetime  NULL,
    [thoigianhocden] datetime  NULL,
    [hocphi] decimal(18,0)  NULL,
    [ketqua_id] int  NULL,
    [bangcap_id] int  NULL,
    [ghichu] nvarchar(1)  NULL,
    [isremove] int  NULL,
    [created_date] datetime  NULL,
    [created_by] nvarchar(255)  NULL,
    [created_log] nvarchar(255)  NULL,
    [modified_date] datetime  NULL,
    [modified_by] nvarchar(255)  NULL,
    [modified_log] nvarchar(255)  NULL
);
GO

-- Creating table 'SM_STUDENT'
CREATE TABLE [dbo].[SM_STUDENT] (
    [id] int  NOT NULL,
    [studentcode] nvarchar(255)  NULL,
    [first_name] nvarchar(255)  NULL,
    [last_name] nvarchar(255)  NULL,
    [full_name] nvarchar(500)  NULL,
    [gioitinh_id] int  NULL,
    [ngaysinh] datetime  NULL,
    [dantoc_id] int  NULL,
    [nghenghiep_id] int  NULL,
    [tinh_id] int  NULL,
    [huyen_id] int  NULL,
    [xa_id] int  NULL,
    [thonxom] nvarchar(1)  NULL,
    [cmtnd] nvarchar(25)  NULL,
    [cmtnd_ngaycap] datetime  NULL,
    [sodienthoai] nvarchar(15)  NULL,
    [email] nvarchar(255)  NULL,
    [ngayvao] datetime  NULL,
    [trangthai_id] int  NULL,
    [chuyennganh_id] int  NULL,
    [bangcap_id] int  NULL,
    [isremoveid] int  NULL,
    [created_date] datetime  NULL,
    [created_by] nvarchar(255)  NULL,
    [created_log] nvarchar(255)  NULL,
    [modified_date] datetime  NULL,
    [modified_by] nvarchar(255)  NULL,
    [modified_log] nvarchar(255)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [licenseid], [id] in table 'SM_LICENSE'
ALTER TABLE [dbo].[SM_LICENSE]
ADD CONSTRAINT [PK_SM_LICENSE]
    PRIMARY KEY CLUSTERED ([licenseid], [id] ASC);
GO

-- Creating primary key on [optionid], [id] in table 'SM_OPTION'
ALTER TABLE [dbo].[SM_OPTION]
ADD CONSTRAINT [PK_SM_OPTION]
    PRIMARY KEY CLUSTERED ([optionid], [id] ASC);
GO

-- Creating primary key on [otherlistid], [id] in table 'SM_OTHERLIST'
ALTER TABLE [dbo].[SM_OTHERLIST]
ADD CONSTRAINT [PK_SM_OTHERLIST]
    PRIMARY KEY CLUSTERED ([otherlistid], [id] ASC);
GO

-- Creating primary key on [othertypelistid], [id] in table 'SM_OTHERTYPELIST'
ALTER TABLE [dbo].[SM_OTHERTYPELIST]
ADD CONSTRAINT [PK_SM_OTHERTYPELIST]
    PRIMARY KEY CLUSTERED ([othertypelistid], [id] ASC);
GO

-- Creating primary key on [logid], [id] in table 'SM_TBLLOG'
ALTER TABLE [dbo].[SM_TBLLOG]
ADD CONSTRAINT [PK_SM_TBLLOG]
    PRIMARY KEY CLUSTERED ([logid], [id] ASC);
GO

-- Creating primary key on [userid], [id] in table 'SM_TBLUSER'
ALTER TABLE [dbo].[SM_TBLUSER]
ADD CONSTRAINT [PK_SM_TBLUSER]
    PRIMARY KEY CLUSTERED ([userid], [id] ASC);
GO

-- Creating primary key on [userpermissionid], [id] in table 'SM_TBLUSER_PERMISSION'
ALTER TABLE [dbo].[SM_TBLUSER_PERMISSION]
ADD CONSTRAINT [PK_SM_TBLUSER_PERMISSION]
    PRIMARY KEY CLUSTERED ([userpermissionid], [id] ASC);
GO

-- Creating primary key on [versionid], [id] in table 'SM_VERSION'
ALTER TABLE [dbo].[SM_VERSION]
ADD CONSTRAINT [PK_SM_VERSION]
    PRIMARY KEY CLUSTERED ([versionid], [id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [id] in table 'DM_DANTOC'
ALTER TABLE [dbo].[DM_DANTOC]
ADD CONSTRAINT [PK_DM_DANTOC]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'DM_HUYEN'
ALTER TABLE [dbo].[DM_HUYEN]
ADD CONSTRAINT [PK_DM_HUYEN]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'DM_QUOCGIA'
ALTER TABLE [dbo].[DM_QUOCGIA]
ADD CONSTRAINT [PK_DM_QUOCGIA]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'DM_TINH'
ALTER TABLE [dbo].[DM_TINH]
ADD CONSTRAINT [PK_DM_TINH]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'DM_XA'
ALTER TABLE [dbo].[DM_XA]
ADD CONSTRAINT [PK_DM_XA]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'SM_KTDAUVAO'
ALTER TABLE [dbo].[SM_KTDAUVAO]
ADD CONSTRAINT [PK_SM_KTDAUVAO]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'SM_LICHHOC'
ALTER TABLE [dbo].[SM_LICHHOC]
ADD CONSTRAINT [PK_SM_LICHHOC]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'SM_LOPHOC'
ALTER TABLE [dbo].[SM_LOPHOC]
ADD CONSTRAINT [PK_SM_LOPHOC]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'SM_NGUOITHAN'
ALTER TABLE [dbo].[SM_NGUOITHAN]
ADD CONSTRAINT [PK_SM_NGUOITHAN]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'SM_QTHOCTAP'
ALTER TABLE [dbo].[SM_QTHOCTAP]
ADD CONSTRAINT [PK_SM_QTHOCTAP]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'SM_STUDENT'
ALTER TABLE [dbo].[SM_STUDENT]
ADD CONSTRAINT [PK_SM_STUDENT]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------