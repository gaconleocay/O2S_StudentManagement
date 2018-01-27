SELECT row_number () over (order by stu.last_name) as stt,
	stu.id,
	stu.studentcode,
	stu.full_name,
	(case stu.gioitinh_id when 1 then 'Nam'
		when 2 then 'Nữ' end) as gioitinh_name,
	stu.ngaysinh,
	dto.name_vn as dantoc_name,
	nng.name_vn as nghenghiep_name,
	(stu.thonxom + ', ' + xa.name_vn + ', ' + huy.name_vn + ', ' + tin.name_vn) as diachi,
	stu.cmtnd,
	stu.sodienthoai,
	stu.email,
	stu.ngayvao,
	(case stu.trangthai_id when 0 then 'Tiếp nhận hồ sơ'
		when 1 then 'Đang học' end) as trangthai_name,	
	chn.name_vn as chuyennganh_name,
	ban.name_vn as bangcap_name	
FROM SM_STUDENT stu 
	LEFT JOIN DM_TINH tin on tin.id=stu.tinh_id
	LEFT JOIN DM_HUYEN huy on huy.id=stu.huyen_id
	LEFT JOIN DM_XA xa on xa.id=stu.xa_id
	LEFT JOIN DM_DANTOC dto on dto.id=stu.dantoc_id
	LEFT JOIN DM_NGHENGHIEP nng on nng.id=stu.nghenghiep_id
	LEFT JOIN DM_CHUYENNGANH chn on chn.id=stu.chuyennganh_id
	LEFT JOIN DM_BANGCAP ban on ban.id=stu.bangcap_id
WHERE created_date between '"+_tungay+"' and '"+_denngay+"' "+ _trangthai + " and isremoveid=0;
