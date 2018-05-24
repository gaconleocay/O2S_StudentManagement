--frmBaoCaoThuTien_TongHop


--ngay 19/5/2018

SELECT 
	 row_number () over (order by FORMAT(pt.ThoiGianThu,'dd/MM/yyyy')) as stt,
	 FORMAT(pt.ThoiGianThu,'dd/MM/yyyy') as ThoiGianThu,
	 nv.TenNhanVien as TenNguoiThu,
	 sum(pt.SoTien) as SoTien
FROM 
	(select * from PHIEUTHU where CoSoId='" + GlobalSettings.CoSoId + "' and ThoiGianThu between '" + datetungay + "' and '" + datedenngay + "' ) pt
	inner join (select TenDangNhap,TaiKhoanId from TAIKHOAN) tk on tk.TenDangNhap=pt.CreatedBy
	inner join (select TaiKhoanId,TenNhanVien from NHANVIEN) nv on nv.TaiKhoanId=tk.TaiKhoanId 
GROUP BY FORMAT(pt.ThoiGianThu, 'dd/MM/yyyy'),nv.TenNhanVien;