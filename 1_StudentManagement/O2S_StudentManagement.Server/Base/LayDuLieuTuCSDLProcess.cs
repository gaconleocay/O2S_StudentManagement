using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace O2S_StudentManagement.Server.Base
{
    public static class LayDuLieuTuCSDLProcess
    {
        private static Base.ConnectDatabase condb = new Base.ConnectDatabase();
        //internal static void Get_TheFileXML1()
        //{
        //    try
        //    {
        //        //Load danh muc The file XML1
        //        string sql_thehoso = "select thefilexmlid, stt, ma_the, ten_the, kieu_du_lieu, kt_toida, bat_buoc, dien_giai, ghi_chu from ie_thefile_xml1;";
        //        DataTable dataDMDV = condb.GetDataTable(sql_thehoso);
        //        GlobalStore.lstTheFileXML1Global = new List<Model.Models.TheFileXMLDTO>();
        //        if (dataDMDV != null && dataDMDV.Rows.Count > 0)
        //        {
        //            foreach (DataRow row in dataDMDV.Rows)
        //            {
        //                Model.Models.TheFileXMLDTO _thefileXml = new Model.Models.TheFileXMLDTO();
        //                _thefileXml.STT = Common.TypeConvert.TypeConvertParse.ToInt64(row["stt"].ToString());
        //                _thefileXml.MA_THE = row["ma_the"].ToString();
        //                _thefileXml.TEN_THE = row["ten_the"].ToString();
        //                _thefileXml.KIEU_DU_LIEU = row["kieu_du_lieu"].ToString();
        //                _thefileXml.KT_TOIDA = Common.TypeConvert.TypeConvertParse.ToInt64(row["kt_toida"].ToString());
        //                _thefileXml.BAT_BUOC = Common.TypeConvert.TypeConvertParse.ToInt16(row["bat_buoc"].ToString());
        //                _thefileXml.DIEN_GIAI = row["dien_giai"].ToString();
        //                _thefileXml.GHI_CHU = row["ghi_chu"].ToString();
        //                GlobalStore.lstTheFileXML1Global.Add(_thefileXml);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.Logging.LogSystem.Error(ex);
        //    }
        //}
        //internal static void Get_DanhSachDVKTPheDuyet()
        //{
        //    try
        //    {
        //        string sql_getdmdv = "SELECT danhmucdvktid, stt as STT, ma_dvkt, ma_ax, ten_dvkt, ten_ax, ma_gia, don_gia, gia_ax, quyet_dinh, cong_bo, ma_cosokcb, manhom_9324, hieuluc, ketqua, lydotuchoi, is_look FROM ie_danhmuc_dvkt;";
        //        DataTable dataDMDV = condb.GetDataTable(sql_getdmdv);
        //        GlobalStore.lstBenhVienPheDuyet_DVKT = new List<Model.Models.DanhMucDichVu_DVKTDTO>();
        //        if (dataDMDV != null && dataDMDV.Rows.Count > 0)
        //        {
        //            foreach (DataRow row in dataDMDV.Rows)
        //            {
        //                Model.Models.DanhMucDichVu_DVKTDTO dichVu = new Model.Models.DanhMucDichVu_DVKTDTO();
        //                dichVu.STT = Common.TypeConvert.TypeConvertParse.ToInt64(row["STT"].ToString());
        //                dichVu.MA_DVKT = row["MA_DVKT"].ToString();
        //                dichVu.MA_AX = row["MA_AX"].ToString();
        //                dichVu.TEN_DVKT = row["TEN_DVKT"].ToString();
        //                dichVu.TEN_AX = row["TEN_AX"].ToString();
        //                dichVu.MA_GIA = row["MA_GIA"].ToString();
        //                dichVu.DON_GIA = Common.TypeConvert.TypeConvertParse.ToDecimal(row["DON_GIA"].ToString());
        //                dichVu.GIA_AX = Common.TypeConvert.TypeConvertParse.ToDecimal(row["GIA_AX"].ToString());
        //                dichVu.QUYET_DINH = row["QUYET_DINH"].ToString();
        //                dichVu.CONG_BO = Common.TypeConvert.TypeConvertParse.ToInt64(row["CONG_BO"].ToString());
        //                dichVu.MA_COSOKCB = Common.TypeConvert.TypeConvertParse.ToInt64(row["MA_COSOKCB"].ToString());
        //                dichVu.MANHOM_9324 = Common.TypeConvert.TypeConvertParse.ToInt64(row["MANHOM_9324"].ToString());
        //                dichVu.HIEULUC = row["HIEULUC"].ToString();
        //                dichVu.KETQUA = row["KETQUA"].ToString();
        //                dichVu.LYDOTUCHOI = row["LYDOTUCHOI"].ToString();

        //                if (dichVu.HIEULUC.ToLower() == "có")
        //                {
        //                    dichVu.HIEULUC_ID = 1;
        //                }
        //                if (dichVu.KETQUA.ToLower() == "đã phê duyệt")
        //                {
        //                    dichVu.KETQUA_ID = 1;
        //                }

        //                GlobalStore.lstBenhVienPheDuyet_DVKT.Add(dichVu);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.Logging.LogSystem.Error(ex);
        //    }
        //}
        //internal static void Get_DanhSachThuocPheDuyet()
        //{
        //    try
        //    {
        //        string sql_getdmdv = "SELECT danhmucthuocid, stt, ma_hoat_chat, ma_ax, hoat_chat, hoatchat_ax, ma_duong_dung, ma_duongdung_ax, duong_dung, duongdung_ax, ham_luong, hamluong_ax, ten_thuoc, tenthuoc_ax, so_dang_ky, sodangky_ax, dong_goi, don_vi_tinh, don_gia, don_gia_tt, so_luong, ma_cskcb, hang_sx, nuoc_sx, nha_thau, quyet_dinh, cong_bo, ma_thuoc_bv, loai_thuoc, loai_thau, nhom_thau, manhom_9324, hieuluc_id, hieuluc, ketqua_id, ketqua, lydotuchoi, is_look FROM ie_danhmuc_thuoc;";
        //        DataTable dataDMDV = condb.GetDataTable(sql_getdmdv);
        //        GlobalStore.lstBenhVienPheDuyet_Thuoc = new List<Model.Models.DanhMucDichVu_ThuocDTO>();
        //        if (dataDMDV != null && dataDMDV.Rows.Count > 0)
        //        {
        //            foreach (DataRow row in dataDMDV.Rows)
        //            {
        //                Model.Models.DanhMucDichVu_ThuocDTO dichVu = new Model.Models.DanhMucDichVu_ThuocDTO();
        //                dichVu.STT = Common.TypeConvert.TypeConvertParse.ToInt64(row["STT"].ToString());
        //                dichVu.MA_HOAT_CHAT = row["MA_HOAT_CHAT"].ToString();
        //                dichVu.MA_AX = row["MA_AX"].ToString();
        //                dichVu.HOAT_CHAT = row["HOAT_CHAT"].ToString();
        //                dichVu.HOATCHAT_AX = row["HOATCHAT_AX"].ToString();
        //                dichVu.MA_DUONG_DUNG = row["MA_DUONG_DUNG"].ToString();
        //                dichVu.MA_DUONGDUNG_AX = row["MA_DUONGDUNG_AX"].ToString();
        //                dichVu.DUONG_DUNG = row["DUONG_DUNG"].ToString();
        //                dichVu.DUONGDUNG_AX = row["DUONGDUNG_AX"].ToString();
        //                dichVu.HAM_LUONG = row["HAM_LUONG"].ToString();
        //                dichVu.HAMLUONG_AX = row["HAMLUONG_AX"].ToString();
        //                dichVu.TEN_THUOC = row["TEN_THUOC"].ToString();
        //                dichVu.TENTHUOC_AX = row["TENTHUOC_AX"].ToString();
        //                dichVu.SO_DANG_KY = row["SO_DANG_KY"].ToString();
        //                dichVu.SODANGKY_AX = row["SODANGKY_AX"].ToString();
        //                dichVu.DONG_GOI = row["DONG_GOI"].ToString();
        //                dichVu.DON_VI_TINH = row["DON_VI_TINH"].ToString();
        //                dichVu.DON_GIA = Common.TypeConvert.TypeConvertParse.ToDecimal(row["DON_GIA"].ToString());
        //                dichVu.DON_GIA_TT = Common.TypeConvert.TypeConvertParse.ToDecimal(row["DON_GIA_TT"].ToString());
        //                dichVu.SO_LUONG = Common.TypeConvert.TypeConvertParse.ToDecimal(row["SO_LUONG"].ToString());
        //                dichVu.MA_CSKCB = Common.TypeConvert.TypeConvertParse.ToInt64(row["MA_CSKCB"].ToString());
        //                dichVu.HANG_SX = row["HANG_SX"].ToString();
        //                dichVu.NUOC_SX = row["NUOC_SX"].ToString();
        //                dichVu.NHA_THAU = row["NHA_THAU"].ToString();
        //                dichVu.QUYET_DINH = row["QUYET_DINH"].ToString();
        //                dichVu.CONG_BO = row["CONG_BO"].ToString();
        //                dichVu.MA_THUOC_BV = row["MA_THUOC_BV"].ToString();
        //                dichVu.LOAI_THUOC = Common.TypeConvert.TypeConvertParse.ToInt64(row["LOAI_THUOC"].ToString());
        //                dichVu.LOAI_THAU = Common.TypeConvert.TypeConvertParse.ToInt64(row["LOAI_THAU"].ToString());
        //                dichVu.NHOM_THAU = row["NHOM_THAU"].ToString();
        //                dichVu.MANHOM_9324 = Common.TypeConvert.TypeConvertParse.ToInt64(row["MANHOM_9324"].ToString());
        //                dichVu.HIEULUC = row["HIEULUC"].ToString();
        //                dichVu.KETQUA = row["KETQUA"].ToString();
        //                dichVu.LYDOTUCHOI = row["LYDOTUCHOI"].ToString();

        //                if (dichVu.HIEULUC.ToLower() == "có")
        //                {
        //                    dichVu.HIEULUC_ID = 1;
        //                }
        //                if (dichVu.KETQUA.ToLower() == "đã phê duyệt")
        //                {
        //                    dichVu.KETQUA_ID = 1;
        //                }

        //                GlobalStore.lstBenhVienPheDuyet_Thuoc.Add(dichVu);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.Logging.LogSystem.Error(ex);
        //    }
        //}
        //internal static void Get_DanhSachVatTuPheDuyet()
        //{
        //    try
        //    {
        //        string sql_getdmdv = "SELECT danhmucvattuid, stt, ma_nhom_vtyt, ma_nhom_ax, ten_nhom_vtyt, ten_nhom_ax, ma_hieu, ma_vtyt_bv, ten_vtyt_bv, quy_cach, nuoc_sx, hang_sx, don_vi_tinh, don_gia, don_gia_tt, nha_thau, quyet_dinh, cong_bo, dinh_muc, so_luong, ma_cskcb, loai_thau, manhom_9324, hieuluc_id, hieuluc, ketqua_id, ketqua, lydotuchoi, is_look FROM ie_danhmuc_vattu;";
        //        DataTable dataDMDV = condb.GetDataTable(sql_getdmdv);
        //        GlobalStore.lstBenhVienPheDuyet_VatTu = new List<Model.Models.DanhMucDichVu_VatTuDTO>();
        //        if (dataDMDV != null && dataDMDV.Rows.Count > 0)
        //        {
        //            foreach (DataRow row in dataDMDV.Rows)
        //            {
        //                Model.Models.DanhMucDichVu_VatTuDTO dichVu = new Model.Models.DanhMucDichVu_VatTuDTO();
        //                dichVu.STT = Common.TypeConvert.TypeConvertParse.ToInt64(row["STT"].ToString());
        //                dichVu.MA_NHOM_VTYT = row["MA_NHOM_VTYT"].ToString();
        //                dichVu.MA_NHOM_AX = row["MA_NHOM_AX"].ToString();
        //                dichVu.TEN_NHOM_VTYT = row["TEN_NHOM_VTYT"].ToString();
        //                dichVu.TEN_NHOM_AX = row["TEN_NHOM_AX"].ToString();
        //                dichVu.MA_HIEU = row["MA_HIEU"].ToString();
        //                dichVu.MA_VTYT_BV = row["MA_VTYT_BV"].ToString();
        //                dichVu.TEN_VTYT_BV = row["TEN_VTYT_BV"].ToString();
        //                dichVu.QUY_CACH = row["QUY_CACH"].ToString();
        //                dichVu.NUOC_SX = row["NUOC_SX"].ToString();
        //                dichVu.HANG_SX = row["HANG_SX"].ToString();
        //                dichVu.DON_VI_TINH = row["DON_VI_TINH"].ToString();
        //                dichVu.DON_GIA = Common.TypeConvert.TypeConvertParse.ToDecimal(row["DON_GIA"].ToString());
        //                dichVu.DON_GIA_TT = Common.TypeConvert.TypeConvertParse.ToDecimal(row["DON_GIA_TT"].ToString());
        //                dichVu.NHA_THAU = row["NHA_THAU"].ToString();
        //                dichVu.QUYET_DINH = row["QUYET_DINH"].ToString();
        //                dichVu.CONG_BO = Common.TypeConvert.TypeConvertParse.ToInt64(row["CONG_BO"].ToString());
        //                dichVu.DINH_MUC = Common.TypeConvert.TypeConvertParse.ToDecimal(row["DINH_MUC"].ToString());
        //                dichVu.SO_LUONG = Common.TypeConvert.TypeConvertParse.ToDecimal(row["SO_LUONG"].ToString());
        //                dichVu.MA_CSKCB = Common.TypeConvert.TypeConvertParse.ToInt64(row["MA_CSKCB"].ToString());
        //                dichVu.LOAI_THAU = Common.TypeConvert.TypeConvertParse.ToInt64(row["LOAI_THAU"].ToString());
        //                dichVu.MANHOM_9324 = Common.TypeConvert.TypeConvertParse.ToInt64(row["MANHOM_9324"].ToString());
        //                dichVu.HIEULUC = row["HIEULUC"].ToString();
        //                dichVu.KETQUA = row["KETQUA"].ToString();
        //                dichVu.LYDOTUCHOI = row["LYDOTUCHOI"].ToString();

        //                if (dichVu.HIEULUC.ToLower() == "có")
        //                {
        //                    dichVu.HIEULUC_ID = 1;
        //                }
        //                if (dichVu.KETQUA.ToLower() == "đã phê duyệt")
        //                {
        //                    dichVu.KETQUA_ID = 1;
        //                }

        //                GlobalStore.lstBenhVienPheDuyet_VatTu.Add(dichVu);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.Logging.LogSystem.Error(ex);
        //    }
        //}
        //internal static void Get_DanhSachGiuongPheDuyet()
        //{
        //    try
        //    {
        //        string sql_getdmdv = "SELECT danhmucgiuongid, stt as STT, ma_dvkt, ma_ax, ten_dvkt, ten_ax, ma_gia, don_gia, gia_ax, quyet_dinh, cong_bo, ma_cosokcb, manhom_9324, hieuluc, ketqua, lydotuchoi, is_look FROM ie_danhmuc_giuong order by stt;";
        //        DataTable dataDMDV = condb.GetDataTable(sql_getdmdv);
        //        GlobalStore.lstBenhVienPheDuyet_Giuong = new List<Model.Models.DanhMucDichVu_GiuongDTO>();
        //        if (dataDMDV != null && dataDMDV.Rows.Count > 0)
        //        {
        //            foreach (DataRow row in dataDMDV.Rows)
        //            {
        //                Model.Models.DanhMucDichVu_GiuongDTO dichVu = new Model.Models.DanhMucDichVu_GiuongDTO();
        //                dichVu.STT = Common.TypeConvert.TypeConvertParse.ToInt64(row["STT"].ToString());
        //                dichVu.MA_DVKT = row["MA_DVKT"].ToString();
        //                dichVu.MA_AX = row["MA_AX"].ToString();
        //                dichVu.TEN_DVKT = row["TEN_DVKT"].ToString();
        //                dichVu.TEN_AX = row["TEN_AX"].ToString();
        //                dichVu.MA_GIA = row["MA_GIA"].ToString();
        //                dichVu.DON_GIA = Common.TypeConvert.TypeConvertParse.ToDecimal(row["DON_GIA"].ToString());
        //                dichVu.GIA_AX = Common.TypeConvert.TypeConvertParse.ToDecimal(row["GIA_AX"].ToString());
        //                dichVu.QUYET_DINH = row["QUYET_DINH"].ToString();
        //                dichVu.CONG_BO = Common.TypeConvert.TypeConvertParse.ToInt64(row["CONG_BO"].ToString());
        //                dichVu.MA_COSOKCB = Common.TypeConvert.TypeConvertParse.ToInt64(row["MA_COSOKCB"].ToString());
        //                dichVu.MANHOM_9324 = Common.TypeConvert.TypeConvertParse.ToInt64(row["MANHOM_9324"].ToString());
        //                dichVu.HIEULUC = row["HIEULUC"].ToString();
        //                dichVu.KETQUA = row["KETQUA"].ToString();
        //                dichVu.LYDOTUCHOI = row["LYDOTUCHOI"].ToString();

        //                if (dichVu.HIEULUC.ToLower() == "có")
        //                {
        //                    dichVu.HIEULUC_ID = 1;
        //                }
        //                if (dichVu.KETQUA.ToLower() == "đã phê duyệt")
        //                {
        //                    dichVu.KETQUA_ID = 1;
        //                }

        //                GlobalStore.lstBenhVienPheDuyet_Giuong.Add(dichVu);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.Logging.LogSystem.Error(ex);
        //    }
        //}
        //internal static void GopDanhMucDVKTVaGiuong()
        //{
        //    try
        //    {
        //        GlobalStore.lstBenhVienPheDuyet_DVKTGiuong = new List<Model.Models.DanhMucDichVu_DVKTDTO>();

        //        if (GlobalStore.lstBenhVienPheDuyet_DVKT != null && GlobalStore.lstBenhVienPheDuyet_DVKT.Count > 0)
        //        {
        //            GlobalStore.lstBenhVienPheDuyet_DVKTGiuong.AddRange(GlobalStore.lstBenhVienPheDuyet_DVKT);
        //        }

        //        if (GlobalStore.lstBenhVienPheDuyet_Giuong != null && GlobalStore.lstBenhVienPheDuyet_Giuong.Count > 0)
        //        {
        //            foreach (var item_giuong in GlobalStore.lstBenhVienPheDuyet_Giuong)
        //            {
        //                Mapper.Initialize(cfg => cfg.CreateMap<Model.Models.DanhMucDichVu_GiuongDTO, Model.Models.DanhMucDichVu_DVKTDTO>());
        //                Model.Models.DanhMucDichVu_DVKTDTO _giuongDTO = AutoMapper.Mapper.Map<Model.Models.DanhMucDichVu_GiuongDTO, Model.Models.DanhMucDichVu_DVKTDTO>(item_giuong);
        //                GlobalStore.lstBenhVienPheDuyet_DVKTGiuong.Add(_giuongDTO);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.Logging.LogSystem.Error(ex);
        //    }
        //}
        //internal static void Get_QuyTacGiamDinh_HoSo()
        //{
        //    try
        //    {
        //        string sql_getdmdv = "select row_number () over (order by ma_quy_tac) as stt,ma_quy_tac as ma_ly_do,ten_quy_tac as ten_ly_do,ket_qua as loai_canh_bao,ly_do,loai_xml,0 as so_luong from ie_qtgd_hoso where coalesce(is_look,0)=0;";
        //        DataTable dataDMDV = condb.GetDataTable(sql_getdmdv);
        //        GlobalStore.lstGD_ThongKeViPham = new List<Model.Models.GDThongKeViPhamDTO>();
        //        if (dataDMDV != null && dataDMDV.Rows.Count > 0)
        //        {
        //            GlobalStore.lstGD_ThongKeViPham = Common.DataTables.ConvertDataTable.DataTableToList<Model.Models.GDThongKeViPhamDTO>(dataDMDV);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.Logging.LogSystem.Warn(ex);
        //    }
        //}
        internal static void Get_ThongTinVeTaiKhoan_QLGuiXe()
        {
            try
            {
                string sql_getThongTin = "select usercode, username, userpassword from SM_TBLUSER where usergnhom=0;";
                DataTable dataTaiKhoan = condb.GetDataTable(sql_getThongTin);
                if (dataTaiKhoan != null && dataTaiKhoan.Rows.Count > 0)
                {
                    GlobalStore.UserName_QLGuiXe = dataTaiKhoan.Rows[0]["usercode"].ToString();
                    GlobalStore.Password_QLGuiXe = dataTaiKhoan.Rows[0]["userpassword"].ToString();
                    GlobalStore.Password_QLGuiXe_MD5 = Common.EncryptAndDecrypt.EncryptAndDecrypt.CalculateMD5Hash(GlobalStore.Password_QLGuiXe);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Loi lay thong tin tai khoan ket noi PM quan ly gui xe " + ex.ToString());
            }
        }
        //internal static void Get_DuLieuDanhMucGiamDinhTT35()
        //{
        //    try
        //    {
        //        string sql_getdmdv = "SELECT danhmucgdtt35id, row_number () over (order by stt) as stt, ma_dvkt, ma_ax, ten_dvkt, ten_ax, ma_gia, don_gia, gia_ax, quyet_dinh, cong_bo, ma_cosokcb, manhom_9324, hieuluc, ketqua, lydotuchoi, solan, thoigian, ma_dvthoigian, ten_dvthoigian, is_look, lastuserupdated, lasttimeupdated, hieuluc_id, ketqua_id, '' as is_look_name FROM ie_danhmuc_gdtt35 where coalesce(is_look,0)=0;";
        //        DataTable dataDMDV = condb.GetDataTable(sql_getdmdv);
        //        GlobalStore.lstDMGDDVKT_TT35 = new List<Model.Models.DanhMucDichVuGD_TT35DTO>();
        //        if (dataDMDV != null && dataDMDV.Rows.Count > 0)
        //        {
        //            GlobalStore.lstDMGDDVKT_TT35 = Common.DataTables.ConvertDataTable.DataTableToList<Model.Models.DanhMucDichVuGD_TT35DTO>(dataDMDV);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.Logging.LogSystem.Warn(ex);
        //    }
        //}
        //internal static void Get_DuLieuDanhMucGiamDinhCV4262()
        //{
        //    try
        //    {
        //        string sql_getdmdv = "SELECT danhmucgdcv4262id, row_number () over (order by stt) as stt, ma_dvkt, ma_ax, ten_dvkt, ten_ax, ma_gia, don_gia, gia_ax, quyet_dinh, cong_bo, ma_cosokcb, manhom_9324, hieuluc, ketqua, lydotuchoi, danhmucgdcv4262id_master, is_look, lastuserupdated, lasttimeupdated, hieuluc_id, ketqua_id, '' as is_look_name, 0 as stt_master FROM ie_danhmuc_gdcv4262 where coalesce(is_look,0)=0;";
        //        DataTable dataDMDV = condb.GetDataTable(sql_getdmdv);
        //        GlobalStore.lstDMGDDVKT_CV4262 = new List<Model.Models.DanhMucDichVuGD_CV4262DTO>();
        //        if (dataDMDV != null && dataDMDV.Rows.Count > 0)
        //        {
        //            GlobalStore.lstDMGDDVKT_CV4262 = Common.DataTables.ConvertDataTable.DataTableToList<Model.Models.DanhMucDichVuGD_CV4262DTO>(dataDMDV);
        //            GlobalStore.lstDMGDDVKT_CV4262Parent = GlobalStore.lstDMGDDVKT_CV4262.Where(o => o.DANHMUCGDCV4262ID_MASTER == 0).ToList(); 
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.Logging.LogSystem.Warn(ex);
        //    }
        //}



    }
}