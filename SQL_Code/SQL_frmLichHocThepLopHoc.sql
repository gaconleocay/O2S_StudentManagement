
STUFF((SELECT '; ' + (case when t2.LopHocId=" + item_lh.LopHocId + " then t2.TenCaHocFull end) from XEPLICHHOC t2 where t1.ThoiGianHoc = t2.ThoiGianHoc order by t2.TenCaHocFull FOR XML PATH(''), TYPE).value('.','NVARCHAR(MAX)'),1,LEN('; '),'') as TenCaHocFull_" + item_lh.LopHocId + ", 
STUFF((SELECT '; ' + (case when t2.LopHocId=" + item_lh.LopHocId + " then t2.TenGiaoVien_Chinh end) from XEPLICHHOC t2 where t1.ThoiGianHoc = t2.ThoiGianHoc order by t2.TenCaHocFull FOR XML PATH(''), TYPE).value('.','NVARCHAR(MAX)'),1,LEN('; '),'') as TenGiaoVien_Chinh_" + item_lh.LopHocId + "




SELECT row_number () over (order by hv.TenHocVien) as stt, hv.MaHocVien, hv.TenHocVien,
	STUFF((SELECT '; ' + (case when FORMAT(t2.ThoiGianHoc,'yyyyMMdd')='20180407' then t2.TenCaHocFull end) 
	from XEPLICHHOC t2 
		inner join (select * from BANGDIEM where LopHocId=1) bd1 on bd1.LopHocId=t2.LopHocId
		inner join HOCVIEN hv1 on hv1.HocVienId=bd1.HocVienId
	where hv1.MaHocVien = hv.MaHocVien 
	order by t2.TenCaHocFull FOR XML PATH(''), TYPE).value('.','NVARCHAR(MAX)'),1,LEN('; '),'') as TenCaHocFull_1,
	'' as GhiChu_1
FROM (select * from XEPLICHHOC where LopHocId=1) xlh
	inner join (select * from BANGDIEM where LopHocId=1) bd on bd.LopHocId=xlh.LopHocId
	inner join HOCVIEN hv on hv.HocVienId=bd.HocVienId
GROUP BY hv.MaHocVien, hv.TenHocVien


SELECT row_number () over (order by hv.TenHocVien) as stt, hv.MaHocVien, hv.TenHocVien,
FROM (select * from XEPLICHHOC where LopHocId=1) xlh
	inner join (select * from BANGDIEM where LopHocId=1) bd on bd.LopHocId=xlh.LopHocId
	inner join HOCVIEN hv on hv.HocVienId=bd.HocVienId
GROUP BY hv.MaHocVien, hv.TenHocVien