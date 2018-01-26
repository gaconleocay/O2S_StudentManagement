--This is sample data for QuanLyHocVien

go
create database QLHVTTEC
go
use QLHVTTEC
set dateformat dmy

-- Tạo Bảng Khóa Học
create table KHOAHOC
(
 MaKH  varchar(4) Not Null primary key,
 TenKH nvarchar(30),
 HocPhi Money,
 HeSoNghe int,
 HeSoNoi int ,
 HeSoDoc int,
 HeSoViet int,
)
--Tạo Bảng Lớp Học
create table LOPHOC
(
 MaLop varchar(9) Not Null primary key,
 TenLop nvarchar(30),
 NgayBD smalldatetime,
 NgayKT smalldatetime,
 SiSo int,
 MaKH varchar(4),
 DangMo bit,
 constraint FK_LOP_KH foreign key (MaKH) references KHOAHOC(MaKH)
)
--Tạo Bảng Tài Khoản
create table TAIKHOAN
(
 TenDangNhap varchar(20) Not Null primary key,
 MatKhau varchar(20),
)
--Tạo Bảng Loại Học Viên
create table LOAIHV
(
 MaLoaiHV varchar(5) Not Null primary key,
 TenLoaiHV nvarchar(30),
)

--Tạo Bảng Học Viên
create table HOCVIEN
(
 MaHV varchar(10) Not Null primary key,
 TenHV nvarchar(30),
 GioiTinhHV nvarchar(3),
 NgaySinh datetime,
 DiaChi nvarchar(30),
 SdtHV varchar(12),
 EmailHV varchar(50),
 MaLoaiHV varchar(5),
 NgayTiepNhan datetime,
 TenDangNhap varchar(20),
 constraint FK_HV_LHV foreign key (MaLoaiHV) references LOAIHV(MaLoaiHV),
 constraint FK_HV_TK foreign key (TenDangNhap) references TAIKHOAN(TenDangNhap),
)
--Tạo Bảng Mã Loại Nhân Viên
create table LOAINV
(
 MaLoaiNV varchar(5) Not Null primary key,
 TenLoaiNV nvarchar(30),
)
--Tạo Bảng Nhân Viên
create table NHANVIEN
(
 MaNV varchar(6)Not Null primary key,
 TenNV nvarchar(30),
 SdtNV varchar(12),
 EmailNV varchar(50),
 MaLoaiNV varchar(5),
 TenDangNhap varchar(20),
  constraint FK_NV_TK foreign key (TenDangNhap) references TAIKHOAN(TenDangNhap),
  constraint FK_NV_LNV foreign key (MaLoaiNV) references LOAINV(MaLoaiNV),
)
--Tạo Bảng Phiếu Ghi Danh
create table PHIEUGHIDANH
(
 MaPhieu varchar(10) Not Null primary key,
 NgayGhiDanh smalldatetime,
 DaDong Money,
 ConNo Money,
 MaNV varchar(6),
 constraint FK_PGD_NV foreign key (MaNV) references NHANVIEN(MaNV),
)
--Tạo Bảng Đang Ký 
create table DANGKY
(
 MaHV varchar(10),
 MaKH varchar(4),
 MaPhieu varchar(10),
 constraint PKDK primary key(MaHV,MaKH,MaPhieu),
 constraint FK_DK_HV foreign key (MaHV) references HOCVIEN(MaHV),
 constraint FK_DK_KH foreign key (MaKH) references KHOAHOC(MaKH),
 constraint FK_DK_PGD foreign key (MaPhieu) references PHIEUGHIDANH(MaPhieu),
)
--Tạo Bảng Giảng Viên
create table GIANGVIEN
(
 MaGV varchar(6) Not Null primary key,
 TenGV nvarchar(30),
 GioiTinhGV nvarchar(3),
 SdtGV varchar(12),
 EmailGV varchar(50),
 TenDangNhap varchar(20),
 constraint FK_GV_TK foreign key (TenDangNhap) references TAIKHOAN(TenDangNhap),
 )
--Tạo Bảng Giảng Dạy
create table GIANGDAY
(
 MaGV varchar(6) ,
 MaLop varchar(9),
 constraint PKGD primary key(MaGV,MaLop),
 constraint FK_GD_GV foreign key (MaGV) references GIANGVIEN(MaGV),
 constraint FK_GD_L foreign key (MaLop) references LOPHOC(MaLop),
)
--Tạo Bảng Bảng Điểm
create table BANGDIEM
(
 MaHV varchar(10),
 MaLop varchar(9),
 MaPhieu varchar(10),
 DiemNghe int,
 DiemNoi int,
 DiemDoc int,
 DiemViet int,
 constraint PKBD primary key (MaHV,MaLop),
 constraint FK_BD_HV foreign key (MaHV) references HOCVIEN(MaHV),
 constraint FK_BD_L foreign key (MaLop) references LOPHOC(MaLop),
 constraint FK_BD_PGD foreign key (MaPhieu) references PHIEUGHIDANH(MaPhieu),
)
--Tạo Bảng Quy Định
create table QUYDINH
(
 MaQD varchar(6) Not Null primary key,
 TenQD nvarchar(100),
 GiaTri int,
)
--Tạo Bảng Chi Tiết Trung Tâm
create table CHITIETTRUNGTAM
(
 TenTT nvarchar(30) Not Null primary key,
 DiaChiTT nvarchar(50),
 SdtTT varchar(12),
 Website varchar(50),
 EmailTT varchar(50),
)
--Khóa Học
Insert into KHOAHOC values ('KH00', N'Anh văn Giao tiếp',3000000,50,50,0,0)
Insert into KHOAHOC values ('KH01' , N'Anh văn Tổng quát' ,2000000,20,30,30,20 )
Insert into KHOAHOC values ('KH02' , N'Luyện thi TOEIC',2500000,50,0,50,0)
Insert into KHOAHOC values ('KH03' , N'Luyện thi IELTS',7600000,25,25,25,25)

--Bảng Lớp Học 
insert into LOPHOC values ('LH1509021',N'Anh văn Giao tiếp 1','02/09/2015','02/12/2015',20,'KH00',1)
insert into LOPHOC values ('LH1509032',N'Anh văn Tổng quát 1','03/09/2015','02/12/2015',20,'KH01',1)
insert into LOPHOC values ('LH1505023',N'Luyện thi TOEIC 1','15/05/2015','20/08/2015',20,'KH02',1)
insert into LOPHOC values ('LH1502204',N'Luyện thi IELTS 1','20/02/2015','20/05/2015',20,'KH03',1)

--Bảng Tài Khoản
--NHÂN VIÊN
Insert into TAIKHOAN values('tuannlh','tuan')
Insert into TAIKHOAN values('vuongvx','vuong')
Insert into TAIKHOAN values('tiendt','tien')
Insert into TAIKHOAN values('phonght','phong')
Insert into TAIKHOAN values('admin','123321')
Insert into TAIKHOAN values('hoanghtk','hoang')
Insert into TAIKHOAN values('toanhda','toan')
Insert into TAIKHOAN values('linhnd','linh')
--TÀI KHOẢN
Insert into TAIKHOAN values('HV15080101','2503')
Insert into TAIKHOAN values('HV15080202','0508')
Insert into TAIKHOAN values('HV15080303','0307')
Insert into TAIKHOAN values('HV15090404','0203')
Insert into TAIKHOAN values('HV15080505','2103')
Insert into TAIKHOAN values('HV15080606','2512')
Insert into TAIKHOAN values('HV15080707','1003')
Insert into TAIKHOAN values('HV15080808','2703')
Insert into TAIKHOAN values('HV15080909','2307')
Insert into TAIKHOAN values('HV15081010','0112')
Insert into TAIKHOAN values('HV15081111','0312')
Insert into TAIKHOAN values('HV15081212','1111')
Insert into TAIKHOAN values('HV15081313','2505')
Insert into TAIKHOAN values('HV15081214','0203')
Insert into TAIKHOAN values('HV15081215','2503')
Insert into TAIKHOAN values('HV15081316','0303')
Insert into TAIKHOAN values('HV15081417','2503')
Insert into TAIKHOAN values('HV15081518','0603')
Insert into TAIKHOAN values('HV15081419','0812')
Insert into TAIKHOAN values('HV15081620','2107')
Insert into TAIKHOAN values('HV15080121','3001')
Insert into TAIKHOAN values('HV15080222','0202')
Insert into TAIKHOAN values('HV15080323','3004')
Insert into TAIKHOAN values('HV15080424','2512')
Insert into TAIKHOAN values('HV15080525','2505')
Insert into TAIKHOAN values('HV15080626','2503')
Insert into TAIKHOAN values('HV15080727','2503')
Insert into TAIKHOAN values('HV15080828','2503')
Insert into TAIKHOAN values('HV15080929','2503')
Insert into TAIKHOAN values('HV15081030','2503')
Insert into TAIKHOAN values('HV15081131','1806')
Insert into TAIKHOAN values('HV15081232','2202')
Insert into TAIKHOAN values('HV15081333','1212')
Insert into TAIKHOAN values('HV15081534','1701')
Insert into TAIKHOAN values('HV15081535','0910')
Insert into TAIKHOAN values('HV15081636','0503')
Insert into TAIKHOAN values('HV15081737','0305')
Insert into TAIKHOAN values('HV15091838','2603')
Insert into TAIKHOAN values('HV15081939','0603')
Insert into TAIKHOAN values('HV15082040','1508')
Insert into TAIKHOAN values('HV15040141','0203')
Insert into TAIKHOAN values('HV15040242','0203')
Insert into TAIKHOAN values('HV15040343','1505')
Insert into TAIKHOAN values('HV15040444','0803')
Insert into TAIKHOAN values('HV15040545','0901')
Insert into TAIKHOAN values('HV15040646','0711')
Insert into TAIKHOAN values('HV15040747','0906')
Insert into TAIKHOAN values('HV15040848','0812')
Insert into TAIKHOAN values('HV15040949','0806')
Insert into TAIKHOAN values('HV15041050','0806')
Insert into TAIKHOAN values('HV15041151','2212')
Insert into TAIKHOAN values('HV15041252','2603')
Insert into TAIKHOAN values('HV15041353','2306')
Insert into TAIKHOAN values('HV15041454','1212')
Insert into TAIKHOAN values('HV15041555','1510')
Insert into TAIKHOAN values('HV15041656','1203')
Insert into TAIKHOAN values('HV15041757','0209')
Insert into TAIKHOAN values('HV15041858','2103')
Insert into TAIKHOAN values('HV15041959','1203')
Insert into TAIKHOAN values('HV15042060','2303')
Insert into TAIKHOAN values('HV15010161','2503')
Insert into TAIKHOAN values('HV15011362','0508')
Insert into TAIKHOAN values('HV15011463','0307')
Insert into TAIKHOAN values('HV15011364','0203')
Insert into TAIKHOAN values('HV15011265','2103')
Insert into TAIKHOAN values('HV15011366','2512')
Insert into TAIKHOAN values('HV15011467','1003')
Insert into TAIKHOAN values('HV15011568','2703')
Insert into TAIKHOAN values('HV15010969','2307')
Insert into TAIKHOAN values('HV15011070','0112')
Insert into TAIKHOAN values('HV15011171','0312')
Insert into TAIKHOAN values('HV15011272','1111')
Insert into TAIKHOAN values('HV15011373','2505')
Insert into TAIKHOAN values('HV15011474','0203')
Insert into TAIKHOAN values('HV15011575','2503')
Insert into TAIKHOAN values('HV15011676','0303')
Insert into TAIKHOAN values('HV15011777','2503')
Insert into TAIKHOAN values('HV15011878','0603')
Insert into TAIKHOAN values('HV15011979','0812')
Insert into TAIKHOAN values('HV15012080','2107')
--GIẢNG VIÊN
Insert into TAIKHOAN values('tuanba','tuanba')
Insert into TAIKHOAN values('trampth','trampth')
Insert into TAIKHOAN values('tungs','tungs')
Insert into TAIKHOAN values('hahn','hahn')
Insert into TAIKHOAN values('hungvd','hungvd')
Insert into TAIKHOAN values('huonghq','huonghq')
Insert into TAIKHOAN values('annd','annd')
Insert into TAIKHOAN values('thonglv','thonglv')
Insert into TAIKHOAN values('loclp','loclp')
Insert into TAIKHOAN values('phongnt','phongnt')

--Loại Học viên
insert into LOAIHV values ('LHV00',N'Học viên tiềm năng')
insert into LOAIHV values ('LHV01',N'Học viên chính thức')

--Học viên
--Giao tiếp
 INSERT INTO HOCVIEN VALUES('HV15080101',N'Trần Thị Dung',N'Nữ','25/03/2015',N'Quận 1, Thành phố Hồ ChíMinh','0123422332','liti_2003@gmail.com','LHV01','01/08/2015','HV15080101');
 INSERT INTO HOCVIEN VALUES('HV15080202',N'Nguyễn Hoàng Dũng',N'Nam','5/08/1996',N'49 Hoàng Diệu','0974527591','nguyenhoang@gmail.com', 'LHV01','02/08/2015','HV15080202');
 INSERT INTO HOCVIEN VALUES('HV15080303',N'Trần Thị Hoàng Dung',N'Nữ','3/07/1996',N'43Nguyễn Kiệm','0992213432','dungtran@gmail.com','LHV01','03/08/2015', 'HV15080303');
 INSERT INTO HOCVIEN VALUES('HV15080404',N'Trần Thị Thanh Dung',N'Nữ','2/03/1998',N'10 Đinh Bộ Lĩnh','01224453376','doremon@gmail.com','LHV01','04/08/2015','HV15090404');
 INSERT INTO HOCVIEN VALUES('HV15080505',N'Trịnh Thị ThAnh Thuý',N'Nữ','21/03/1995',N'90 Nguyễn Thị Nhỏ','0987667890','thuy@gmail.com','LHV01','05/08/2015','HV15080505');
 INSERT INTO HOCVIEN VALUES('HV15080606',N'Trịnh Đăng Dũng',N'Nam','25/12/1994',N'43/5/19 Kha Vạn Cân','01234432101','mimi@gmail.com','LHV01','06/08/2015','HV15080606');
 INSERT INTO HOCVIEN VALUES('HV15080707',N'Nguyễn Minh Kha',N'Nam','10/3/1996',N'11 Âu Cơ','0996031012','nobita@gmail.com', 'LHV01','07/08/2015','HV15080707');
 INSERT INTO HOCVIEN VALUES('HV15080808',N'Nguyễn Văn Nam',N'Nam','27/3/1995',N'89Hoa Hùng','093795317','nam88@gmail.com','LHV01','08/08/2015','HV15080808');
 INSERT INTO HOCVIEN VALUES('HV15080909',N'Hoàng Thị Chính',N'Nữ','23/7/1993',N'14/19 Hùng Phú','01239902131','lili@gmail.com','LHV01', '09/08/2015','HV15080909');
 INSERT INTO HOCVIEN VALUES('HV15081010',N'Lưu Nguyễn Kỳ Đỗ',N'Nam','1/12/1998',N'45/19 Lạc Long Quân','09199791201','doky@gmail.com','LHV01', '10/08/2015','HV15081010');
 INSERT INTO HOCVIEN VALUES('HV15081111',N'Nguyễn Thị Tuyết Mai',N'Nữ','3/12/1993',N'19 Hoàng Diệu','01234931203','tuyetmai@gmail.com','LHV01','11/08/2015','HV15081111');
 INSERT INTO HOCVIEN VALUES('HV15081212',N'Trần Chính Nghĩa',N'Nam','11/11/1996',N'251 Âu Cơ','0925161111','nghia88@gmail.com','LHV01','12/08/2015','HV15081212');
 INSERT INTO HOCVIEN VALUES('HV15081313',N'Lê Quang Trung',N'Nam','25/5/1993',N'44 Nam Kỳ Khởi Nghĩa','0944930925','trung_2003@gmail.com','LHV01','13/08/2015','HV15081313');
 INSERT INTO HOCVIEN VALUES('HV15081214',N'Phạm Thị Hồng',N'Nữ','2/3/1995',N'79 Âu Cơ','012799523','hong_2003@gmail.com','LHV01','14/08/2015','HV15081214');
 INSERT INTO HOCVIEN VALUES('HV15081215',N'Hoàng Anh Tuấn' ,N'Nam','25/3/1995',N'359 Âu Cơ','0123550325','tuan_com@gmail.com','LHV01','12/08/2015', 'HV15081215');
 INSERT INTO HOCVIEN VALUES('HV15081316',N'Nguyễn Nhất Sinh',N'Nam','3/3/1994',N'41 Hoàng Diệu','0941940303','sinh_2003@gmail.com','LHV01','13/08/2015','HV15081316');
 INSERT INTO HOCVIEN VALUES('HV15081417',N'Mai Thị Lưu',N'Nữ','25/3/1995',N'33 CMT8','0933950325','luumai@gmail.com','LHV01','14/08/2015' ,'HV15081417');
 INSERT INTO HOCVIEN VALUES('HV15081518',N'Nguyễn Nam Cường',N'Nam','6/3/1993',N'50 Nguyễn Duy','0950930306','namcuong@gmail.com','LHV01', '15/08/2015','HV15081518');
 INSERT INTO HOCVIEN VALUES('HV15081419',N'Trần Nam Lương',N'Nam','8/12/1996',N'62 Ngô Kỳ Lan','0962961208','namluong@gmail.com','LHV01', '14/08/2015','HV15081419');
 INSERT INTO HOCVIEN VALUES('HV15081620',N'Trần Nam Kha',N'Nam','21/7/1997',N'43/5 CMT8','0943570721','kha@gmail.com','LHV01', '16/08/2015','HV15081620');
 ---tổng quát-----
 INSERT INTO HOCVIEN VALUES('HV15080121',N'Lê Đình Hoàng',N'Nam','30/1/1995',N'5/19 Ngô Quyền','0919595130','mon_2003@gmail.com','LHV01','01/08/2015', 'HV15080121');
 INSERT INTO HOCVIEN VALUES('HV15080222',N'Chu An',N'Nữ','2/2/1991',N'32 Ngô Quyền','0932910202','chu_an@gmail.com','LHV01','02/08/2015','HV15080222');
 INSERT INTO HOCVIEN VALUES('HV15080323',N'Huỳnh Nhất Tân',N'Nam','30/4/1992',N'7 Lê Lợi','0979920230','tan_2003@gmail.com','LHV01','03/08/2015','HV15080323');
 INSERT INTO HOCVIEN VALUES('HV15080424',N'Nguyễn Minh Trí',N'Nam','25/12/1993',N'62 Lê Lợi','0962931225','tri_2003@gmail.com','LHV01','04/08/2015','HV15080424');
 INSERT INTO HOCVIEN VALUES('HV15080525',N'Lê Hoài Nhỏ',N'Nam','25/5/1994',N'601 BaĐình','0960194525','nho@gmail.com','LHV01','05/08/2015','HV15080525');
 INSERT INTO HOCVIEN VALUES('HV15080626',N'Nguyễn Quang Sang',N'Nam','25/3/1995',N'43/5/19 Phan Đình Phùng','0915345235','sang@gmail.com','LHV01', '06/08/2015','HV15080626');
 INSERT INTO HOCVIEN VALUES('HV15080727',N'Phạm Nguyễn Anh Thu',N'Nữ','25/3/1996',N'43/5/19 Phan Đình Phùng','0943516325','anhthu@gmail.com','LHV01','07/08/2015','HV15080727');
 INSERT INTO HOCVIEN VALUES('HV15080828',N'Nguyễn Trọng Trí',N'Nam','25/3/1997',N'43/5/19 Ngô Đình Tuý','0970325435','trongtri@gmail.com','LHV01', '08/08/2015','HV15080828');
 INSERT INTO HOCVIEN VALUES('HV15080929',N'Lê Quốc Bảo',N'Nam','25/3/1998',N'43/5/18 Hoàng Diệu','0918534253','quocbao@gmail.com','LHV01', '09/08/2015','HV15080929');
 INSERT INTO HOCVIEN VALUES('HV15081030',N'Trần Chí Bảo',N'Nam','25/3/1997',N'43/5/19 Hoàng Diệu','0934519753','chibao@gmail.com','LHV01','10/08/2015','HV15081030');
 INSERT INTO HOCVIEN VALUES('HV15081131',N'Trần Gia Bảo',N'Nam','18/6/1996',N'43/5/19 Phạm Văn Đồng','0918696359','giabao@gmail.com','LHV01','11/08/2015', 'HV15081131');
 INSERT INTO HOCVIEN VALUES('HV15081232',N'Nguyễn Anh Chí',N'Nữ','22/2/1995',N'43/5/19','0922219954','anhchi@gmail.com','LHV01','12/08/2015','HV15081232');
 INSERT INTO HOCVIEN VALUES('HV15081333',N'Trịnh Kim Chí',N'Nữ','12/12/1994',N'43/5/19','0912121994','kimchi@gmail.com','LHV01','13/08/2015','HV15081333');
 INSERT INTO HOCVIEN VALUES('HV15081534',N'Nguyễn Thị Bảo Chí',N'Nữ','17/1/1993',N'43/5/19','0917119931','chi@gmail.com','LHV01','14/08/2015','HV15081534');
 INSERT INTO HOCVIEN VALUES('HV15081535',N'Bùi Quốc An',N'Nam','9/10/1992',N'43/5/19','09091019923','an@gmail.com','LHV01','15/08/2015','HV15081535');
 INSERT INTO HOCVIEN VALUES('HV15081636',N'Trần Thị Bảo Chính',N'Nữ','5/3/1993',N'43/5/19','0950319931','chinh@gmail.com','LHV01','16/08/2015','HV15081636');
 INSERT INTO HOCVIEN VALUES('HV15081737',N'Lê Thuỳ Dương',N'Nữ','3/5/1994',N'42 Ba Đình','09030519942','duong@gmail.com','LHV01', '17/08/2015','HV15081737');
 INSERT INTO HOCVIEN VALUES('HV15091838',N'Trịnh Phát Đạt',N'Nam','26/3/1995',N'43/5 Ba Đình','0926319951','patdat@gmail.com','LHV01','18/09/2015','HV15091838');
 INSERT INTO HOCVIEN VALUES('HV15081939',N'Bùi Quốc Đạt',N'Nam','6/3/1996',N'45 BaĐình','09060319961','dat@gmail.com','LHV01','19/08/2015','HV15081939');
 INSERT INTO HOCVIEN VALUES('HV15082040',N'Đào Kim Thu',N'Nữ','15/8/1997',N'43 BaĐình','0915081997','thu@gmail.com','LHV01','10/08/2015','HV15082040');
 ---toeic
 INSERT INTO HOCVIEN VALUES('HV15040141',N'ĐìnhBảo Lam',N'Nữ','2/3/1998',N'3 Lê Lợi','0902031199','baolam@gmail.com','LHV01','01/04/2015','HV15040141');
 INSERT INTO HOCVIEN VALUES('HV15040242',N'ĐìnhBảo Linh',N'Nữ','2/3/1997',N'210 Lê Lợi','09020319971','baolinh@gmail.com','LHV01','02/04/2015','HV15040242');
 INSERT INTO HOCVIEN VALUES('HV15040343',N'Trần Bảo Lê',N'Nữ','15/5/1996',N'46 Lê Lợi','0915051996','baole@gmail.com','LHV01','03/04/2015','HV15040343');
 INSERT INTO HOCVIEN VALUES('HV15040444',N'ĐìnhThị Yến Oanh',N'Nữ','8/3/1995',N'90 Lê Lợi','0908031995','oanh@gmail.com','LHV01','04/04/2015','HV15040444');
 INSERT INTO HOCVIEN VALUES('HV15040545',N'ĐìnhThị Yến Phương',N'Nữ','9/1/1994',N'88 Lê Lợi','0990011994','phuong@gmail.com','LHV01','05/04/2015','HV15040545');
 INSERT INTO HOCVIEN VALUES('HV15040646',N'Nguyễn Kim Oanh',N'Nữ','7/11/1993',N'80 BaĐình','0970111993','kimoanh@gmail.com','LHV01','06/04/2015','HV15040646');
 INSERT INTO HOCVIEN VALUES('HV15040747',N'Trần Duy Lý',N'Nam','9/6/1994',N'120 BaĐình','0912009694','ly@gmail.com','LHV01','07/04/2015','HV15040747');
 INSERT INTO HOCVIEN VALUES('HV15040848',N'Nguyễn Thị Hồng Hoa',N'Nữ','8/12/1995',N'460 Ba Đình','0946081295','honghoa@gmail.com','LHV01','08/04/2015','HV15040848');
 INSERT INTO HOCVIEN VALUES('HV15040949',N'Trần Kim Hoa',N'Nữ','8/6/1996',N'70 BaĐình','0907960608','kimhoa@gmail.com','LHV01','09/04/2015','HV15040949');
 INSERT INTO HOCVIEN VALUES('HV15041050',N'ĐìnhBảo Hoa',N'Nữ','9/3/1997','124 Nguyễn Thị Nhỏ','0912409397','baohoa@gmail.com','LHV01','10/04/2015','HV15041050');
 INSERT INTO HOCVIEN VALUES('HV15041151',N'Nguyễn Thị Hải Triều',N'Nữ','22/12/1998',N'90 Nguyễn Thị Nhỏ','0909221298','trieu@gmail.com','LHV01','11/04/2015','HV15041151');
 INSERT INTO HOCVIEN VALUES('HV15041252',N'Lê Ngôc Linh ',N'Nam','26/3/1997',N'30 Nguyễn Thị Nhỏ','0930970326','linh@gmail.com','LHV01','12/04/2015','HV15041252');
 INSERT INTO HOCVIEN VALUES('HV15041353',N'Lê Thành Công',N'Nam','23/6/1996',N'96 Nguyễn Thị Nhỏ','0996120696','cong@gmail.com','LHV01','13/04/2015','HV15041353');
 INSERT INTO HOCVIEN VALUES('HV15041454',N'Nguyễn Việt Nam',N'Nam','12/12/1995',N'540 Nguyễn Thị Nhỏ','0905411995','nam@gmail.com','LHV01','14/04/2015','HV15041454');
 INSERT INTO HOCVIEN VALUES('HV15041555',N'Lê Bảo Lan',N'Nữ','15/10/1994',N'88Nguyễn Thị Nhỏ','0988881210','lan@gmail.com','LHV01','15/04/2015','HV15041555');
 INSERT INTO HOCVIEN VALUES('HV15041656',N'Nguyễn Thị Ngôc Lan',N'Nữ','12/3/1993',N'13 Đình Bộ Linh','0913120393','ngoclan@gmail.com','LHV01','16/04/2015','HV15041656');
 INSERT INTO HOCVIEN VALUES('HV15041757',N'Trần Hồng Minh',N'Nam','2/9/1994',N'450 Đình BộLinh','0945002994','minh@gmail.com','LHV01','17/04/2015','HV15041757');
 INSERT INTO HOCVIEN VALUES('HV15041858',N'Trần Minh Kha',N'Nam','21/3/1995',N'65 Đình Bộ Linh','0965210395','kha@gmail.com','LHV01','18/04/2015','HV15041858');
 INSERT INTO HOCVIEN VALUES('HV15041959',N'Nguyễn Minh Khoa',N'Nam','12/3/1996',N'61 Đình Bộ Linh','0961960312','khoa@gmail.com','LHV01','19/04/2015','HV15041959');
 INSERT INTO HOCVIEN VALUES('HV15042060',N'Nguyễn Bảo Khoa',N'Nam','23/3/1997',N'73 Đình Bộ Linh','0973230397','baokhoa@gmail.com','LHV01','20/04/2015','HV15042060'); 
 ---ielst
 INSERT INTO HOCVIEN VALUES('HV15010161',N'Trần Hoàng',N'Nữ','25/3/1998',N'43/5/19','0934519253','liti_20031@gmail.com','LHV01','01/01/2015','HV15010161');
 INSERT INTO HOCVIEN VALUES('HV15011362',N'Nguyễn Hoàng',N'Nam',N'5/8/1997',N'49 Hoàng Diệu','0905081997','nguyenhoang@gmail.com','LHV01','13/01/2015', 'HV15011362');
 INSERT INTO HOCVIEN VALUES('HV15011463',N'Trần Thị',N'Nữ',N'3/7/1996',N'43 Nguyễn Kiệm','0943893074','thitran@gmail.com','LHV01', '14/01/2015','HV15011463');
 INSERT INTO HOCVIEN VALUES('HV15011364',N'Trần Thị Thanh',N'Nữ','2/3/1995','10 Đình BộLinh','0910020395','doremon@gmail.com','LHV01','13/01/2015', 'HV15011364');
 INSERT INTO HOCVIEN VALUES('HV15011265',N'Trịnh Thị Thuy',N'Nữ','21/3/1994',N'90 Nguyễn Thị Nhỏ','0909321312','thuy_com@gmail.com','LHV01','12/01/2015' ,'HV15011265');
 INSERT INTO HOCVIEN VALUES('HV15011366',N'Trịnh Đăng',N'Nam','25/12/1993',N'43/5/19','0993912312','mimi@gmail.com','LHV01', '13/01/2015','HV15011366');
 INSERT INTO HOCVIEN VALUES('HV15011467',N'Nguyễn Minh',N'Nam','10/3/1994',N'11 Âu Cơ','0919941003','tabino@gmail.com','LHV01','14/01/2015','HV15011467');
 INSERT INTO HOCVIEN VALUES('HV15011568',N'Nguyễn Văn',N'Nam','27/3/1995',N'89 Hoa Hùng','0989270395','van88@gmail.com','LHV01','15/01/2015','HV15011568');
 INSERT INTO HOCVIEN VALUES('HV15010969',N'Hoàng Chính',N'Nữ','23/7/1996',N'14/19 Hùng Phú','0919142396','lili@gmail.com','LHV01','09/01/2015','HV15010969');
 INSERT INTO HOCVIEN VALUES('HV15011070',N'Lưu Nguyễn Kỳ Đỗ',N'Nam','1/12/1997',N'45/19 Lạc Long Quân','0945179712','doky@gmail.com','LHV01','10/01/2015', 'HV15011070');
 INSERT INTO HOCVIEN VALUES('HV15011171',N'Nguyễn Thị Tuyết',N'Nữ',N'3/12/1998',N'19 Hoàng Diệu','0919981203','tuyetmai@gmail.com','LHV01','11/01/2015','HV15011171');
 INSERT INTO HOCVIEN VALUES('HV15011272',N'Trần Nghĩa',N'Nam','11/11/1997',N'251 Âu Cơ','0925111111','nghia88@gmail.com','LHV01','12/01/2015','HV15011272');
 INSERT INTO HOCVIEN VALUES('HV15011373',N'Lê Quang',N'Nam','25/5/1996',N'44 Nam Kỳ Khởi Nghĩa','0944199605','trung_2003@gmail.com','LHV01','13/01/2015','HV15011373');
 INSERT INTO HOCVIEN VALUES('HV15011474',N'Phạm Hồng',N'Nữ','2/3/1995',N'79 Âu Cơ','0979199502','hong_2003@gmail.com','LHV01','14/01/2015','HV15011474');
 INSERT INTO HOCVIEN VALUES('HV15011575',N'Hoàng Anh' ,N'Nam','25/3/1994',N'359 Âu Cơ','0925919963','tuan_cu@gmail.com','LHV01','15/01/2015','HV15011575');
 INSERT INTO HOCVIEN VALUES('HV15011676',N'Nguyễn Sinh',N'Nam',N'3/3/1993',N'41 Hoàng Diệu','091419931','sinh_2003@gmail.com','LHV01','16/01/2015','HV15011676');
 INSERT INTO HOCVIEN VALUES('HV15011777',N'Mai Lưu',N'Nữ','25/3/1994',N'33 CMT8','093319942','luumai@gmail.com','LHV01','17/01/2015','HV15011777');
 INSERT INTO HOCVIEN VALUES('HV15011878',N'Nguyễn Cường',N'Nam',N'6/3/1993',N'50 Nguyễn Duy','0950199312','namcuong@gmail.com','LHV01','18/01/2015','HV15011878');
 INSERT INTO HOCVIEN VALUES('HV15011979',N'Trần Lương',N'Nam',N'8/12/1994',N'62 Ngô Kỳ Lan','0962199211','namluong@gmail.com','LHV01','19/01/2015','HV15011979');
 INSERT INTO HOCVIEN VALUES('HV15012080',N'Trần Nam Kha',N'Nam','21/7/1993',N'43/5 CMT8','0983199321','kha@gmail.com','LHV01','20/01/2015','HV15012080');
 ---Tiềm năng
 INSERT INTO HOCVIEN VALUES('HV15010181',N'Lê Đình ',N'Nam',N'30/1/1994',N'5/19 Ngô Quyền','0919594130','mom_2003@gmail.com','LHV00','01/01/2015',Null);
 INSERT INTO HOCVIEN VALUES('HV15010182',N'Chu An Hoàng',N'Nữ','2/2/1995',N'32 Ngô Quyền','0932950202','chu_an@gmail.com','LHV00','01/01/2015',null);
 INSERT INTO HOCVIEN VALUES('HV15010183',N'Huỳnh Tân',N'Nam',N'30/4/1996',N'7 Lê Lợi','0977960430','tan_2003@gmail.com','LHV00','01/01/2015',null);
 INSERT INTO HOCVIEN VALUES('HV15010184',N'Nguyễn Tân Minh Trí',N'Nam','25/12/1997',N'62 Lê Lợi','0926122589','tri_2003@gmail.com','LHV00','01/01/2015',Null);
 INSERT INTO HOCVIEN VALUES('HV15010585',N'Bùi Kim Thanh',N'Nữ',N'9/7/1998',N'621 Thủ Đức','0962189791','buithannh1991@gmail.com','LHV00','01/01/2015',null); 
 INSERT INTO HOCVIEN VALUES('HV15010586',N'Đình Lam',N'Nữ','2/3/1997',N'3 Lê Lợi','0923131999','baolam@gmail.com','LHV00','05/01/2015',null);
 INSERT INTO HOCVIEN VALUES('HV15010587',N'Đình Linh',N'Nữ','2/3/1996',N'210 Lê Lợi','0902102031','baolinh@gmail.com','LHV00','05/01/2015',null);
 INSERT INTO HOCVIEN VALUES('HV15010588',N'Trần Bảo',N'Nữ','15/5/1995',N'46 Lê Lợi','0946150589','baole@gmail.com','LHV00','05/01/2015',null);
 INSERT INTO HOCVIEN VALUES('HV15010589',N'Đình Yến Oanh',N'Nữ',N'8/3/1994',N'90 Lê Lợi','0909030889','oanh@gmail.com','LHV00','05/01/2015',null);
 INSERT INTO HOCVIEN VALUES('HV15010690',N'Đình Yến Phượng',N'Nữ','1/1/1993',N'88 Lê Lợi','0988890109','phuong@gmail.com','LHV00','06/01/2015',null);
 INSERT INTO HOCVIEN VALUES('HV15010691',N'Nguyễn Oanh',N'Nữ',N'7/11/1994',N'80 BaĐình','0908071189','kimoanh@gmail.com','LHV00','06/01/2015',null);
 INSERT INTO HOCVIEN VALUES('HV15010692',N'Trần Duy',N'Nam',N'9/6/1995',N'120 BaĐình','0912096891','ly@gmail.com','LHV00','06/01/2015',null);
 INSERT INTO HOCVIEN VALUES('HV15010693',N'Nguyễn Hồng Hoa',N'Nữ',N'8/12/1996',N'460 Ba Đình','0946000001','honghoa@gmail.com','LHV00','06/01/2015',null);
 INSERT INTO HOCVIEN VALUES('HV15010694',N'Trần Hoa',N'Nữ',N'8/6/1997',N'70 Ba Đình','0946000002','kimhoa@gmail.com','LHV00','06/01/2015',null);
 INSERT INTO HOCVIEN VALUES('HV15010695',N'ĐìnhBảoHoa',N'Nữ',N'9/3/1998',N'124 Nguyễn Thị Nhỏ','0946000003','baohoa@gmail.com','LHV00','06/01/2015',null);
 INSERT INTO HOCVIEN VALUES('HV15010696',N'Nguyễn Thị Hải',N'Nữ','22/12/1997',N'90 Nguyễn Thị Nhỏ','0946000004','trieu@gmail.com','LHV00','06/01/2015',null);
 INSERT INTO HOCVIEN VALUES('HV15010797',N'Lê Linh',N'Nam','26/3/1996',N'30 Nguyễn Thị Nhỏ','0946000005','linh@gmail.com','LHV00','07/01/2015',null);
 INSERT INTO HOCVIEN VALUES('HV15010798',N'Lê Thanh Hoàng Công',N'Nam','23/6/1995',N'96 Nguyễn Thị Nhỏ','0946000006','cong@gmail.com','LHV00','07/01/2015',null);
 INSERT INTO HOCVIEN VALUES('HV15010799',N'Nguyễn Cường Việt Nam',N'Nam','12/12/1994',N'540 Nguyễn Thị Nhỏ','0946000007','nam@gmail.com','LHV00','07/01/2015',null);
 INSERT INTO HOCVIEN VALUES('HV15010700',N'Lê Bảo Thanh Lan',N'Nữ','15/10/1993',N'88 Nguyễn Thị Nhỏ','0946000008','lan@gmail.com','LHV00','07/01/2015',null);

 --Bảng Loại Nhân Viên
Insert into LOAINV values ('LNV00' , N'Quản trị viên')
Insert into LOAINV values ('LNV01' , N'Nhân viên ghi danh')
Insert into LOAINV values ('LNV02' , N'Nhân viên học vụ')
Insert into LOAINV values ('LNV03' , N'Nhân viên kế toán')

--Bảng Nhân Viên
Insert into NHANVIEN values('NV0000' , N'Administrator' ,'0987456365','admin@gmail.com', 'LNV00','admin')
Insert into NHANVIEN values('NV0001' , N'Nguyễn Lê Hoàng Tuấn' ,'0987465577','tuannlh@gmail.com', 'LNV00','tuannlh')
Insert into NHANVIEN values('NV0002' , N'Võ Xuân Vương' ,'01693849495','vuongvx@gmail.com', 'LNV00','vuongvx')
Insert into NHANVIEN values('NV0003' , N'Đậu Thế Tiến' ,'0937645484','tiendt@gmail.com', 'LNV00','tiendt')
Insert into NHANVIEN values('NV0004' , N'Hà Thanh Phong' ,'09693847534','phonght@gmail.com', 'LNV00','phonght')
Insert into NHANVIEN values('NV0005' , N'Hồ Thị Kim Hoàng' ,'0123456789','hoanghtk@gmail.com', 'LNV01','hoanghtk')
Insert into NHANVIEN values('NV0006' , N'Huỳnh Duy Anh Toàn' ,'0127564839','toanhda@gmail.com', 'LNV02','toanhda')
Insert into NHANVIEN values('NV0007' , N'Nguyễn Duy Linh' ,'01627345632','linhnd@gmail.com', 'LNV03','linhnd')

 --------PHIEUGHIDANH---
INSERT  INTO   PHIEUGHIDANH
VALUES ('PG15083001','30/08/2015',2000000 ,0 ,'NV0005')
INSERT  INTO   PHIEUGHIDANH
VALUES ('PG15083002','30/08/2015',1500000 ,500000 , 'NV0005' )
INSERT  INTO   PHIEUGHIDANH
VALUES ('PG15083003','30/08/2015',1000000 ,1000000 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083004','30/08/2015',2000000 ,0 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083005','30/08/2015',2000000 ,0 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083006','30/08/2015',1500000 ,500000 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083007','30/08/2015',2000000 ,0 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083008','30/08/2015',1700000 ,300000 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083009','30/08/2015',1000000 ,1000000 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083010','30/08/2015',2000000 ,0 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083011','30/08/2015',2000000 ,0 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083012','30/08/2015',1500000 ,500000 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083013','30/08/2015',2000000 ,0 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083014','30/08/2015',1000000 ,1000000 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083015','30/08/2015',1400000 ,600000 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083016','30/08/2015',1200000 ,800000 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083017','30/08/2015',1500000 ,500000 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083018','30/08/2015',2000000 ,0 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083019','30/08/2015',2000000 ,0 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083020','30/08/2015',2000000 ,0 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083121','31/08/2015',2000000 ,0 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083122','31/08/2015',1500000 ,150000 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083123','31/08/2015',1000000 ,1000000 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083124','31/08/2015',1000000 ,1000000 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083125','31/08/2015',2000000 ,0 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083126','31/08/2015',2000000 ,0 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083127','31/08/2015',2000000 ,0 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083128','31/08/2015',1000000 ,1000000 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083129','31/08/2015',2000000 ,0 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083130','31/08/2015',1500000 ,500000 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083131','31/08/2015',2000000 ,0 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083132','31/08/2015',2000000 ,0 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083133','31/08/2015',1500000 ,500000 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083134','31/08/2015',2000000,0 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083135','31/08/2015',1500000 ,500000 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083136','31/08/2015',2000000,0 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083137','31/08/2015',2000000,0 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083138','31/08/2015',2000000,0 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083139','31/08/2015',1000000 ,1000000 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15083140','31/08/2015',1500000 ,500000 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15042141','21/04/2015',2500000 ,0 , 'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15042142','21/04/2015',2500000 ,0 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15042143','21/04/2015',2000000,500000 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15042144','21/04/2015',1500000 ,1000000 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15042145','21/04/2015',2500000 ,0 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15042146','21/04/2015',2000000,0 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15042147','21/04/2015',2500000 ,0 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15042148','21/04/2015',2500000 ,0 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15042149','21/04/2015',2000000,500000 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15042150','21/04/2015',1500000 ,1000000 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15042251','22/04/2015',2500000 ,0 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15042252','22/04/2015',1500000 ,1000000 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15042253','22/04/2015',2500000 ,0 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15042254','22/04/2015',2000000,1000000 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15042255','22/04/2015',2000000,1000000 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15042256','22/04/2015',2500000 ,0 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15042257','22/04/2015',2500000 ,0 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15042258','22/04/2015',2500000 ,0 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15042259','22/04/2015',1500000 ,1000000 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15042260','22/04/2015',1500000 ,1000000 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15012661','26/01/2015',7600000 ,0 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15012662','26/01/2015',7600000 ,0 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15012663','26/01/2015',5000000 ,2600000 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15012664','26/01/2015',6000000 ,1600000 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15012665','26/01/2015',7600000 ,0 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15012666','26/01/2015',5000000 ,2600000 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15012667','26/01/2015',7600000 ,0 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15012668','26/01/2015',7600000 ,0 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15012669','26/01/2015',6000000 ,1600000 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15012670','26/01/2015',5000000 ,2600000 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15012771','27/01/2015',7600000 ,0 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15012772','27/01/2015',7600000 ,0 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15012773','27/01/2015',6000000 ,1600000 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15012774','27/01/2015',7600000 ,0 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15012775','27/01/2015',6000000 ,1600000 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15012776','27/01/2015',5000000 ,2600000 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15012777','27/01/2015',7600000 ,0 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15012778','27/01/2015',7600000 ,0 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15012779','27/01/2015',6000000 ,1600000 ,'NV0005')
INSERT INTO  PHIEUGHIDANH
VALUES ('PG15012780','27/01/2015',5000000 ,2600000 ,'NV0005')

-----GIẢNG VIÊN----
INSERT INTO GIANGVIEN VALUES ('GV0001',N'Bùi Anh Tuấn',N'Nam', '0913303312','tuanba@gmail.com','tuanba')	
INSERT INTO GIANGVIEN VALUES ('GV0002',N'Phạm Thị Hương Tràm',N'Nữ', '01675432213','trampth@gmail.com','trampth')
INSERT INTO GIANGVIEN VALUES ('GV0003',N'Sơn Tùng',N'Nam', '0938723723','tungs@gmail.com','tungs')
INSERT INTO GIANGVIEN VALUES ('GV0004',N'Hồ Ngọc Hà',N'Nữ', '01635425567','hahn@gmail.com','hahn')
INSERT INTO GIANGVIEN VALUES ('GV0005',N'Đàm Vĩnh Hưng',N'Nam', '0987653345','hungvd@gmail.com','hungvd')
INSERT INTO GIANGVIEN VALUES ('GV0006',N'Hồ Quỳnh Hương',N'Nữ', '01678872237','huonghq@gmail.com','huonghq')
INSERT INTO GIANGVIEN VALUES ('GV0007',N'Ngô Duy Ân',N'Nam', '09389971234','annd@gmail.com','annd')
INSERT INTO GIANGVIEN VALUES ('GV0008',N'Lê Văn Thống',N'Nam', '01684446754','thonglv@gmail.com','thonglv')
INSERT INTO GIANGVIEN VALUES ('GV0009',N'Lê Phước Lộc',N'Nam', '0962225467','loclp@gmail.com','loclp')
INSERT INTO GIANGVIEN VALUES ('GV0010',N'Nguyễn Thanh Phong',N'Nam','01698754767','phongnt@gmail.com','phongnt')

--GIẢNG DẠY
insert into GIANGDAY values('GV0001','LH1509021')
insert into GIANGDAY values('GV0002','LH1509032')
insert into GIANGDAY values('GV0003','LH1502204')
insert into GIANGDAY values('GV0004','LH1505023')
insert into GIANGDAY values('GV0005','LH1509032')
insert into GIANGDAY values('GV0006','LH1509021')
insert into GIANGDAY values('GV0007','LH1509032')
insert into GIANGDAY values('GV0008','LH1505023')
insert into GIANGDAY values('GV0009','LH1502204')
insert into GIANGDAY values('GV0010','LH1509021')

--Bảng Quy Định
Insert into QUYDINH values ('QD0000',N'Sĩ số học viên tối đa',20)
Insert into QUYDINH values ('QD0001',N'Số tiền tối thiểu phải đóng khi ghi danh',500000)

--Bảng Thông tin trung tâm
Insert into CHITIETTRUNGTAM values('English Center', N'103, KP6, P. Linh Trung, Q. Thủ Đức, TP. HCM','0943834934','ec.edu.com','support@ec.edu.com')

--Bảng điểm
Insert into BANGDIEM values('HV15080101','LH1509021','PG15083001',60,70,0,0)
Insert into BANGDIEM values('HV15080202','LH1509021','PG15083002',67,72,0,0)
Insert into BANGDIEM values('HV15080303','LH1509021','PG15083003',55,65,0,0)
Insert into BANGDIEM values('HV15080404','LH1509021','PG15083004',87,90,0,0)
Insert into BANGDIEM values('HV15080505','LH1509021','PG15083005',77,75,0,0)
Insert into BANGDIEM values('HV15080606','LH1509021','PG15083006',43,47,0,0)
Insert into BANGDIEM values('HV15080707','LH1509021','PG15083007',70,79,0,0)
Insert into BANGDIEM values('HV15080808','LH1509021','PG15083008',69,73,0,0)
Insert into BANGDIEM values('HV15080909','LH1509021','PG15083009',77,79,0,0)
Insert into BANGDIEM values('HV15081010','LH1509021','PG15083010',90,86,0,0)
Insert into BANGDIEM values('HV15081111','LH1509021','PG15083011',57,45,0,0)
Insert into BANGDIEM values('HV15081212','LH1509021','PG15083012',88,70,0,0)
Insert into BANGDIEM values('HV15081313','LH1509021','PG15083013',69,78,0,0)
Insert into BANGDIEM values('HV15081214','LH1509021','PG15083014',89,88,0,0)
Insert into BANGDIEM values('HV15081215','LH1509021','PG15083015',77,85,0,0)
Insert into BANGDIEM values('HV15081316','LH1509021','PG15083016',79,83,0,0)
Insert into BANGDIEM values('HV15081417','LH1509021','PG15083017',58,63,0,0)
Insert into BANGDIEM values('HV15081518','LH1509021','PG15083018',84,86,0,0)
Insert into BANGDIEM values('HV15081419','LH1509021','PG15083019',48,59,0,0)
Insert into BANGDIEM values('HV15081620','LH1509021','PG15083020',60,72,0,0)
Insert into BANGDIEM values('HV15080121','LH1509032','PG15083121',50,65,58,43)
Insert into BANGDIEM values('HV15080222','LH1509032','PG15083122',76,74,78,81)
Insert into BANGDIEM values('HV15080323','LH1509032','PG15083123',85,84,89,79)
Insert into BANGDIEM values('HV15080424','LH1509032','PG15083124',90,93,94,95)
Insert into BANGDIEM values('HV15080525','LH1509032','PG15083125',37,67,56,73)
Insert into BANGDIEM values('HV15080626','LH1509032','PG15083126',77,85,68,70)
Insert into BANGDIEM values('HV15080727','LH1509032','PG15083127',87,89,86,83)
Insert into BANGDIEM values('HV15080828','LH1509032','PG15083128',76,73,71,73)
Insert into BANGDIEM values('HV15080929','LH1509032','PG15083129',75,73,78,77)
Insert into BANGDIEM values('HV15081030','LH1509032','PG15083130',56,54,57,51)
Insert into BANGDIEM values('HV15081131','LH1509032','PG15083131',95,95,93,95)
Insert into BANGDIEM values('HV15081232','LH1509032','PG15083132',70,79,75,83)
Insert into BANGDIEM values('HV15081333','LH1509032','PG15083133',59,68,57,58)
Insert into BANGDIEM values('HV15081534','LH1509032','PG15083134',67,71,60,72)
Insert into BANGDIEM values('HV15081535','LH1509032','PG15083135',86,84,80,78)
Insert into BANGDIEM values('HV15081636','LH1509032','PG15083136',50,59,59,58)
Insert into BANGDIEM values('HV15081737','LH1509032','PG15083137',40,49,53,48)
Insert into BANGDIEM values('HV15091838','LH1509032','PG15083138',75,79,84,82)
Insert into BANGDIEM values('HV15081939','LH1509032','PG15083139',68,64,60,66)
Insert into BANGDIEM values('HV15082040','LH1509032','PG15083140',83,84,81,88)
Insert into BANGDIEM values('HV15040141','LH1505023','PG15042141',60,0,57,0)
Insert into BANGDIEM values('HV15040242','LH1505023','PG15042142',65,0,74,0)
Insert into BANGDIEM values('HV15040343','LH1505023','PG15042143',77,0,79,0)
Insert into BANGDIEM values('HV15040444','LH1505023','PG15042144',88,0,79,0)
Insert into BANGDIEM values('HV15040545','LH1505023','PG15042145',58,0,60,0)
Insert into BANGDIEM values('HV15040646','LH1505023','PG15042146',69,0,67,0)
Insert into BANGDIEM values('HV15040747','LH1505023','PG15042147',78,0,79,0)
Insert into BANGDIEM values('HV15040848','LH1505023','PG15042148',69,0,74,0)
Insert into BANGDIEM values('HV15040949','LH1505023','PG15042149',78,0,87,0)
Insert into BANGDIEM values('HV15041050','LH1505023','PG15042150',87,0,85,0)
Insert into BANGDIEM values('HV15041151','LH1505023','PG15042251',76,0,75,0)
Insert into BANGDIEM values('HV15041252','LH1505023','PG15042252',76,0,69,0)
Insert into BANGDIEM values('HV15041353','LH1505023','PG15042253',77,0,73,0)
Insert into BANGDIEM values('HV15041454','LH1505023','PG15042254',87,0,88,0)
Insert into BANGDIEM values('HV15041555','LH1505023','PG15042255',88,0,83,0)
Insert into BANGDIEM values('HV15041656','LH1505023','PG15042256',77,0,79,0)
Insert into BANGDIEM values('HV15041757','LH1505023','PG15042257',68,0,67,0)
Insert into BANGDIEM values('HV15041858','LH1505023','PG15042258',87,0,88,0)
Insert into BANGDIEM values('HV15041959','LH1505023','PG15042259',67,0,56,0)
Insert into BANGDIEM values('HV15042060','LH1505023','PG15042260',77,0,78,0)
Insert into BANGDIEM values('HV15010161','LH1502204','PG15012661',97,98,93,94)
Insert into BANGDIEM values('HV15011362','LH1502204','PG15012662',87,86,84,81)
Insert into BANGDIEM values('HV15011463','LH1502204','PG15012663',65,64,77,78)
Insert into BANGDIEM values('HV15011364','LH1502204','PG15012664',67,68,69,66)
Insert into BANGDIEM values('HV15011265','LH1502204','PG15012665',74,72,75,74)
Insert into BANGDIEM values('HV15011366','LH1502204','PG15012666',77,78,74,70)
Insert into BANGDIEM values('HV15011467','LH1502204','PG15012667',87,79,91,87)
Insert into BANGDIEM values('HV15011568','LH1502204','PG15012668',72,71,79,70)
Insert into BANGDIEM values('HV15010969','LH1502204','PG15012669',54,53,63,63)
Insert into BANGDIEM values('HV15011070','LH1502204','PG15012670',67,68,65,60)
Insert into BANGDIEM values('HV15011171','LH1502204','PG15012771',75,76,79,70)
Insert into BANGDIEM values('HV15011272','LH1502204','PG15012772',88,76,86,88)
Insert into BANGDIEM values('HV15011373','LH1502204','PG15012773',75,79,70,78)
Insert into BANGDIEM values('HV15011474','LH1502204','PG15012774',67,87,67,77)
Insert into BANGDIEM values('HV15011575','LH1502204','PG15012775',76,69,74,79)
Insert into BANGDIEM values('HV15011676','LH1502204','PG15012776',45,56,57,58)
Insert into BANGDIEM values('HV15011777','LH1502204','PG15012777',87,84,88,89)
Insert into BANGDIEM values('HV15011878','LH1502204','PG15012778',78,76,70,77)
Insert into BANGDIEM values('HV15011979','LH1502204','PG15012779',67,68,65,70)
Insert into BANGDIEM values('HV15012080','LH1502204','PG15012780',70,77,79,75)

--Đăng ký
--KH00
 insert into DANGKY values('HV15080101','KH00 ','PG15083001')
 insert into DANGKY values('HV15080202','KH00 ','PG15083002')
 insert into DANGKY values('HV15080303','KH00 ','PG15083003')
 insert into DANGKY values('HV15080404','KH00 ','PG15083004')
 insert into DANGKY values('HV15080505','KH00 ','PG15083005')
 insert into DANGKY values('HV15080606','KH00 ','PG15083006')
 insert into DANGKY values('HV15080707','KH00 ','PG15083007')
 insert into DANGKY values('HV15080808','KH00 ','PG15083008')
 insert into DANGKY values('HV15080909','KH00 ','PG15083009')
 insert into DANGKY values('HV15081010','KH00 ','PG15083010')
 insert into DANGKY values('HV15081111','KH00 ','PG15083011')
 insert into DANGKY values('HV15081212','KH00 ','PG15083012')
 insert into DANGKY values('HV15081313','KH00 ','PG15083013')
 insert into DANGKY values('HV15081214','KH00 ','PG15083014')
 insert into DANGKY values('HV15081215','KH00 ','PG15083015')
 insert into DANGKY values('HV15081316','KH00 ','PG15083016')
 insert into DANGKY values('HV15081417','KH00 ','PG15083017')
 insert into DANGKY values('HV15081518','KH00 ','PG15083018')
 insert into DANGKY values('HV15081419','KH00 ','PG15083019')
 insert into DANGKY values('HV15081620','KH00 ','PG15083020')
 --KH01
 insert into DANGKY values('HV15080121','KH01 ','PG15083121')
 insert into DANGKY values('HV15080222','KH01 ','PG15083122')
 insert into DANGKY values('HV15080323','KH01 ','PG15083123')
 insert into DANGKY values('HV15080424','KH01 ','PG15083124')
 insert into DANGKY values('HV15080525','KH01 ','PG15083125')
 insert into DANGKY values('HV15080626','KH01 ','PG15083126')
 insert into DANGKY values('HV15080727','KH01 ','PG15083127')
 insert into DANGKY values('HV15080828','KH01 ','PG15083128')
 insert into DANGKY values('HV15080929','KH01 ','PG15083129')
 insert into DANGKY values('HV15081030','KH01 ','PG15083130')
 insert into DANGKY values('HV15081131','KH01 ','PG15083131')
 insert into DANGKY values('HV15081232','KH01 ','PG15083132')
 insert into DANGKY values('HV15081333','KH01 ','PG15083133')
 insert into DANGKY values('HV15081534','KH01 ','PG15083134')
 insert into DANGKY values('HV15081535','KH01 ','PG15083135')
 insert into DANGKY values('HV15081636','KH01 ','PG15083136')
 insert into DANGKY values('HV15081737','KH01 ','PG15083137')
 insert into DANGKY values('HV15091838','KH01 ','PG15083138')
 insert into DANGKY values('HV15081939','KH01 ','PG15083139')
 insert into DANGKY values('HV15082040','KH01 ','PG15083140')
 --KH02
 insert into DANGKY values('HV15040141','KH02 ','PG15042141')
 insert into DANGKY values('HV15040242','KH02 ','PG15042142')
 insert into DANGKY values('HV15040343','KH02 ','PG15042143')
 insert into DANGKY values('HV15040444','KH02 ','PG15042144')
 insert into DANGKY values('HV15040545','KH02 ','PG15042145')
 insert into DANGKY values('HV15040646','KH02 ','PG15042146')
 insert into DANGKY values('HV15040747','KH02 ','PG15042147')
 insert into DANGKY values('HV15040848','KH02 ','PG15042148')
 insert into DANGKY values('HV15040949','KH02 ','PG15042149')
 insert into DANGKY values('HV15041050','KH02 ','PG15042150')
 insert into DANGKY values('HV15041151','KH02 ','PG15042251')
 insert into DANGKY values('HV15041252','KH02 ','PG15042252')
 insert into DANGKY values('HV15041353','KH02 ','PG15042253')
 insert into DANGKY values('HV15041454','KH02 ','PG15042254')
 insert into DANGKY values('HV15041555','KH02 ','PG15042255')
 insert into DANGKY values('HV15041656','KH02 ','PG15042256')
 insert into DANGKY values('HV15041757','KH02 ','PG15042257')
 insert into DANGKY values('HV15041858','KH02 ','PG15042258')
 insert into DANGKY values('HV15041959','KH02 ','PG15042259')
 insert into DANGKY values('HV15042060','KH02 ','PG15042260')
 --KH03
 insert into DANGKY values('HV15010161','KH03','PG15012661')
 insert into DANGKY values('HV15011362','KH03','PG15012662')
 insert into DANGKY values('HV15011463','KH03','PG15012663')
 insert into DANGKY values('HV15011364','KH03','PG15012664')
 insert into DANGKY values('HV15011265','KH03','PG15012665')
 insert into DANGKY values('HV15011366','KH03','PG15012666')
 insert into DANGKY values('HV15011467','KH03','PG15012667')
 insert into DANGKY values('HV15011568','KH03','PG15012668')
 insert into DANGKY values('HV15010969','KH03','PG15012669')
 insert into DANGKY values('HV15011070','KH03','PG15012670')
 insert into DANGKY values('HV15011171','KH03','PG15012771')
 insert into DANGKY values('HV15011272','KH03','PG15012772')
 insert into DANGKY values('HV15011373','KH03','PG15012773')
 insert into DANGKY values('HV15011474','KH03','PG15012774')
 insert into DANGKY values('HV15011575','KH03','PG15012775')
 insert into DANGKY values('HV15011676','KH03','PG15012776')
 insert into DANGKY values('HV15011777','KH03','PG15012777')
 insert into DANGKY values('HV15011878','KH03','PG15012778')
 insert into DANGKY values('HV15011979','KH03','PG15012779')
 insert into DANGKY values('HV15012080','KH03','PG15012780')