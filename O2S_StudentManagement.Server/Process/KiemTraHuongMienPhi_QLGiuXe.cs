using AutoMapper;
using O2S_StudentManagement.Model.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;

namespace O2S_StudentManagement.Server.Process
{
    public class KiemTraHuongMienPhi_QLGiuXe
    {
        #region Khai bao
        private static Base.ConnectDatabase condb = new Base.ConnectDatabase();

        #endregion

        #region Giam dinh Mien phi
        public KTMienPhiKetQua_PlusDTO QuyTacGiamDinhProcess_MienPhi(KTMienPhiFilterDTO _filterKiemTra)
        {
            KTMienPhiKetQua_PlusDTO result = new KTMienPhiKetQua_PlusDTO();
            try
            {
                //kiem tra Input
                if (_filterKiemTra.maBenhNhan != null && _filterKiemTra.maBenhNhan != "")
                {
                    string _mabenhnhan = _filterKiemTra.maBenhNhan.ToUpper().Replace("BN", "");
                    _filterKiemTra.maBenhNhanId = Common.TypeConvert.TypeConvertParse.ToInt64(_mabenhnhan);
                    if (_filterKiemTra.thoiGianTagTheRa == 0)
                    {
                        _filterKiemTra.thoiGianTagTheRa = Common.TypeConvert.TypeConvertParse.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                    }
                    _filterKiemTra.thoiGianTagTheRa_Day = Common.TypeConvert.TypeConvertParse.ToInt64(_filterKiemTra.thoiGianTagTheRa.ToString().Substring(0, 8));

                    //kiem tra Giam dinh Mien phi
                    string _sqlHoSoBenhAn = "SELECT hsba.patientcode, vp.patientid, vp.vienphiid, hsba.hosobenhanid, hsba.patientname, bh.bhytid, bh.bhytcode, hsba.gioitinhname, (case when hsba.birthday_year<>0 then cast(hsba.birthday_year as text) else to_char(hsba.birthday,'dd/MM/yyyy') end) as namsinh, ((case when hsba.hc_sonha<>'' then hsba.hc_sonha || ', ' else '' end) || (case when hsba.hc_thon<>'' then hsba.hc_thon || ' - ' else '' end) || (case when hsba.hc_xacode<>'00' then hsba.hc_xaname || ' - ' else '' end) || (case when hsba.hc_huyencode<>'00' then hsba.hc_huyenname || ' - ' else '' end) || (case when hsba.hc_tinhcode<>'00' then hsba.hc_tinhname else '' end)) as diachi, vp.vienphistatus, (case when vp.vienphistatus=0 then 'Đang điều trị' else 'Đã ra viện' end) as vienphistatus_name, vp.loaivienphiid, (case vp.loaivienphiid when 0 then 'Nội trú' when 1 then 'Ngoại trú' when 2 then 'Điều trị ngoại trú' end) as loaivienphi_name, to_char(vp.vienphidate,'HH24:MI dd/MM/yyyy') as vienphidate, to_char(vp.vienphidate,'yyyyMMddHH24MIss') as vienphidate_long, (case when vp.vienphidate_ravien<>'0001-01-01 00:00:00' then to_char(vp.vienphidate_ravien,'HH24:MI dd/MM/yyyy') end) as vienphidate_ravien, to_char(mrd.thoigianvaovien,'HH24:MI dd/MM/yyyy') as vienphidate_noitru, to_char(mrd.thoigianvaovien,'yyyyMMddHH24MIss') as vienphidate_noitru_long, (case when vp.vienphidate_ravien<>'0001-01-01 00:00:00' then to_char(vp.vienphidate_ravien,'yyyyMMddHH24MIss') else '0' end) as vienphidate_ravien_long, (case when vp.vienphidate_ravien<>'0001-01-01 00:00:00' then to_char(vp.vienphidate_ravien,'yyyyMMdd') else '0' end) as vienphidate_ravien_day_long, (degp.departmentgroupname || ' - ' || de.departmentname) as khoaphong, vp.departmentgroupid, degp.departmentgroupname, vp.departmentid, de.departmentname FROM (select vienphiid,vienphicode,hosobenhanid,patientid,bhytid,vienphistatus,loaivienphiid,vienphidate,vienphidate_noitru,vienphidate_ravien,departmentgroupid,departmentid from vienphi where patientid=" + _filterKiemTra.maBenhNhanId + ") vp left join (select hosobenhanid,departmentgroupid,thoigianvaovien from medicalrecord where hinhthucvaovienid=2 and patientid=" + _filterKiemTra.maBenhNhanId + ") mrd on mrd.hosobenhanid=vp.hosobenhanid inner join (select hosobenhanid,patientcode,patientname,gioitinhname,birthday,birthday_year,hc_sonha,hc_thon,hc_xacode,hc_xaname,hc_huyencode,hc_huyenname,hc_tinhcode,hc_tinhname from hosobenhan where patientid=" + _filterKiemTra.maBenhNhanId + ") hsba on hsba.hosobenhanid=vp.hosobenhanid inner join (select bhytid,bhytcode from bhyt where patientid=" + _filterKiemTra.maBenhNhanId + ") bh on bh.bhytid=vp.bhytid left join (select departmentgroupid,departmentgroupname from departmentgroup) degp on degp.departmentgroupid=vp.departmentgroupid left join (select departmentid,departmentname from department) de on de.departmentid=vp.departmentid ORDER BY vp.vienphidate desc;";
                    DataTable _dataHoSoBenhAn = condb.GetDataTable(_sqlHoSoBenhAn);
                    if (_dataHoSoBenhAn != null && _dataHoSoBenhAn.Rows.Count > 0)
                    {
                        List<ThongTinBenhNhanDTO> lstHoSoBenhAn = Common.DataTables.ConvertDataTable.DataTableToList<ThongTinBenhNhanDTO>(_dataHoSoBenhAn);

                        //list Ho So Benh An đang điều trị
                        List<ThongTinBenhNhanDTO> lstHSBA_DangDieuTri = lstHoSoBenhAn.Where(o => o.vienphistatus == 0 || o.vienphidate_ravien_day_long >= _filterKiemTra.thoiGianTagTheRa_Day).ToList();
                        if (lstHSBA_DangDieuTri != null && lstHSBA_DangDieuTri.Count > 0)
                        {
                            foreach (var item_ddt in lstHSBA_DangDieuTri)
                            {
                                Mapper.Initialize(cfg => cfg.CreateMap<ThongTinBenhNhanDTO, KTMienPhiKetQua_PlusDTO>());
                                result = AutoMapper.Mapper.Map<ThongTinBenhNhanDTO, KTMienPhiKetQua_PlusDTO>(item_ddt);

                                if (item_ddt.loaivienphiid == 0)//noi tru
                                {
                                    result.maKetQua = 1;
                                    result.tenKetQua = "Mã bệnh nhân " + result.patientcode + " miễn phí!";
                                    if (item_ddt.vienphistatus != 0)
                                    {
                                        result.thuHoiThe = 1;
                                    }
                                    else
                                    {
                                        result.thuHoiThe = 0;
                                    }
                                    result.ghiChu = "Đang điều trị NT";
                                    return result;
                                }
                                else//ngoai tru
                                {
                                    KTMienPhiKetQuaDTO _resultNgoaiTru = GiamDinhMienPhiNgoaiTru(_filterKiemTra);
                                    if (_resultNgoaiTru.maKetQua == 1)
                                    {
                                        result.maKetQua = _resultNgoaiTru.maKetQua;
                                        result.tenKetQua = "Mã bệnh nhân " + result.patientcode + " miễn phí!";
                                        result.thuHoiThe = _resultNgoaiTru.thuHoiThe;
                                        result.ghiChu = _resultNgoaiTru.ghiChu;
                                        return result;
                                    }
                                    //else
                                    //{
                                    //    result.tenKetQua = "Mã bệnh nhân " + result.patientcode + " phải trả phí!";
                                    //}
                                }
                            }
                        }

                        //list Ho So Benh An Nội trú đã kết thúc điều trị
                        List<ThongTinBenhNhanDTO> lstHSBA_KetThucDieuTri = lstHoSoBenhAn.Where(o => o.vienphistatus != 0 || o.loaivienphiid == 0).ToList();
                        if (lstHSBA_KetThucDieuTri != null && lstHSBA_KetThucDieuTri.Count > 0)
                        {
                            Mapper.Initialize(cfg => cfg.CreateMap<ThongTinBenhNhanDTO, KTMienPhiKetQua_PlusDTO>());
                            result = AutoMapper.Mapper.Map<ThongTinBenhNhanDTO, KTMienPhiKetQua_PlusDTO>(lstHSBA_KetThucDieuTri[0]);

                            KTMienPhiKetQuaDTO _resultNoiTru = GiamDinhMienPhiNoiTru(_filterKiemTra);
                            if (_resultNoiTru.maKetQua == 1)
                            {
                                result.maKetQua = _resultNoiTru.maKetQua;
                                result.tenKetQua = "Mã bệnh nhân " + result.patientcode + " miễn phí!";
                                result.thuHoiThe = _resultNoiTru.thuHoiThe;
                                result.ghiChu = _resultNoiTru.ghiChu;
                                return result;
                            }
                        }

                        //Phải trả phí - kết quả cuối cùng
                        Mapper.Initialize(cfg => cfg.CreateMap<ThongTinBenhNhanDTO, KTMienPhiKetQua_PlusDTO>());
                        result = AutoMapper.Mapper.Map<ThongTinBenhNhanDTO, KTMienPhiKetQua_PlusDTO>(lstHoSoBenhAn[0]);
                        result.maKetQua = 0;
                        result.tenKetQua = "Mã bệnh nhân " + result.patientcode + " phải trả phí!";
                        result.thuHoiThe = 1;
                        result.ghiChu = "Không có giao dịch";
                    }
                    else
                    {
                        result.maKetQua = 0;
                        result.tenKetQua = "Không tìm thấy bệnh nhân mã " + _filterKiemTra.maBenhNhan;
                        result.thuHoiThe = 1;
                        result.ghiChu = "Sai mã BN";
                    }
                }
                else
                {
                    result.maKetQua = 0;
                    result.tenKetQua = "Chưa nhập mã bệnh nhân hoặc bệnh nhân Nội trú chưa tạm ứng tiền!";
                    result.thuHoiThe = 1;
                    result.ghiChu = "Chưa nhập mã BN hoặc BN Nội trú chưa tạm ứng";
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Loi quy tac giam dinh" + ex.ToString());
            }
            return result;
        }

        private KTMienPhiKetQuaDTO GiamDinhMienPhiNgoaiTru(KTMienPhiFilterDTO _filterKiemTra)
        {
            KTMienPhiKetQuaDTO result = new KTMienPhiKetQuaDTO();
            try
            {
                string _sqlChiDinhDV = "SELECT maubenhphamid FROM maubenhpham WHERE patientid=" + _filterKiemTra.maBenhNhanId + " and to_char(maubenhphamdate,'yyyyMMdd')='" + _filterKiemTra.thoiGianTagTheRa_Day + "';";
                string _sqlTraKetQua = "SELECT maubenhphamid FROM maubenhpham WHERE patientid=" + _filterKiemTra.maBenhNhanId + " and (to_char(maubenhphamfinishdate,'yyyyMMdd')='" + _filterKiemTra.thoiGianTagTheRa_Day + "' or to_char(maubenhphamdate_thuchien,'yyyyMMdd')='" + _filterKiemTra.thoiGianTagTheRa_Day + "');";
                string _sqlGiaoDichTaiChinh = "SELECT billid FROM bill WHERE patientid=" + _filterKiemTra.maBenhNhanId + " and dahuyphieu=0 and to_char(billdate,'yyyyMMdd')='" + _filterKiemTra.thoiGianTagTheRa_Day + "';";
                string _sqlKetThucBenhAn = "SELECT vienphiid FROM vienphi WHERE patientid=" + _filterKiemTra.maBenhNhanId + " and to_char(vienphidate_ravien,'yyyyMMdd')='" + _filterKiemTra.thoiGianTagTheRa_Day + "';";

                DataTable _dataChiDinhDV = condb.GetDataTable(_sqlChiDinhDV);
                if (_dataChiDinhDV != null && _dataChiDinhDV.Rows.Count > 0)
                {
                    result.maKetQua = 1;
                    result.thuHoiThe = 1;
                    result.ghiChu = "Có giao dịch";
                    return result;
                }
                DataTable _dataTraKetQua = condb.GetDataTable(_sqlTraKetQua);
                if (_dataTraKetQua != null && _dataTraKetQua.Rows.Count > 0)
                {
                    result.maKetQua = 1;
                    result.thuHoiThe = 1;
                    result.ghiChu = "BN trả kết quả";
                    return result;
                }
                DataTable _dataGiaoDichTaiChinh = condb.GetDataTable(_sqlGiaoDichTaiChinh);
                if (_dataGiaoDichTaiChinh != null && _dataGiaoDichTaiChinh.Rows.Count > 0)
                {
                    result.maKetQua = 1;
                    result.thuHoiThe = 1;
                    result.ghiChu = "Thanh toán viện phí";
                    return result;
                }
                DataTable _dataKetThucBenhAn = condb.GetDataTable(_sqlKetThucBenhAn);
                if (_dataKetThucBenhAn != null && _dataKetThucBenhAn.Rows.Count > 0)
                {
                    result.maKetQua = 1;
                    result.thuHoiThe = 1;
                    result.ghiChu = "BN ra viện";
                    return result;
                }

                // Tra phi
                result.maKetQua = 0;
                result.thuHoiThe = 1;
                result.ghiChu = "Không có giao dịch";
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        private KTMienPhiKetQuaDTO GiamDinhMienPhiNoiTru(KTMienPhiFilterDTO _filterKiemTra)
        {
            KTMienPhiKetQuaDTO result = new KTMienPhiKetQuaDTO();
            try
            {
                string _sqlDuyetVienPhi = "SELECT vienphiid FROM vienphi WHERE patientid=" + _filterKiemTra.maBenhNhanId + " and to_char(duyet_ngayduyet_vp,'yyyyMMdd')='" + _filterKiemTra.thoiGianTagTheRa_Day + "';";

                DataTable _dataDuyetVienPhi = condb.GetDataTable(_sqlDuyetVienPhi);
                if (_dataDuyetVienPhi != null && _dataDuyetVienPhi.Rows.Count > 0)
                {
                    result.maKetQua = 1;
                    result.thuHoiThe = 1;
                    result.ghiChu = "Thanh toán viện phí";
                    return result;
                }

                // Tra phi
                result.maKetQua = 0;
                result.thuHoiThe = 1;
                result.ghiChu = "Không có giao dịch";
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }


        #endregion

        #region Luu lai CSDL
        internal void LuuLaiVaoCoSoDuLieu(KTMienPhiFilterDTO _filterKiemTra, KTMienPhiKetQua_PlusDTO result)
        {
            try
            {
                string _sqlInsertCheck = "";
                string _checkdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string _vienphidate = DateTime.ParseExact(result.vienphidate_long.ToString(), "yyyyMMddHHmmss", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                string _vienphidate_ravien = "0001-01-01 00:00:00";
                if (result.vienphidate_ravien_long != 0)
                {
                    _vienphidate_ravien = DateTime.ParseExact(result.vienphidate_ravien_long.ToString(), "yyyyMMddHHmmss", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                }
                string _namsinh = "0001-01-01 00:00:00";
                if (result.namsinh.Length == 4)
                {
                    _namsinh = result.namsinh + "-01-01 00:00:00";
                }
                else
                {
                    _namsinh = DateTime.ParseExact(result.namsinh, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                }

                //lay thong tin ve xe
                if (_filterKiemTra.maTheGuiXe != null && _filterKiemTra.maTheGuiXe != "")
                {
                    ThongTinVeXeDTO _thongTinXe = LayThongTinVeTheXe(_filterKiemTra.maTheGuiXe);
                    string _thoigianxevao = "0001-01-01 00:00:00";
                    if (_thongTinXe.thoigianvao_long != null && _thongTinXe.thoigianvao_long != "")
                    {
                        _thoigianxevao = DateTime.ParseExact(_thongTinXe.thoigianvao_long, "yyyyMMddHHmmss", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    _sqlInsertCheck = "INSERT INTO cp_checkxera(patientid, patientcode, vienphiid, hosobenhanid, patientname, checkstatus, checkdate, checknote, checkusercode, checkusername, vienphidate, vienphidate_ravien, bhytid, bhytcode, gioitinhname, namsinh, diachi, vienphistatus, loaivienphiid, departmentgroupid, departmentgroupname, departmentid, departmentname, thuhoithe, mathexe, sothexe, biensoxe, loaixe, thoigianvao, cardeventid) VALUES ('" + result.patientid + "', '" + result.patientcode + "', '" + result.vienphiid + "', '" + result.hosobenhanid + "', '" + result.patientname + "', '" + result.maKetQua + "', '" + _checkdate + "', '" + result.ghiChu + "', '" + _filterKiemTra.checkusercode + "', '" + _filterKiemTra.checkusername + "', '" + _vienphidate + "', '" + _vienphidate_ravien + "', '" + result.bhytid + "', '" + result.bhytcode + "', '" + result.gioitinhname + "', '" + _namsinh + "', '" + result.diachi + "', '" + result.vienphistatus + "', '" + result.loaivienphiid + "', '" + result.departmentgroupid + "', '" + result.departmentgroupname + "', '" + result.departmentid + "', '" + result.departmentname + "', '" + result.thuHoiThe + "', '" + _filterKiemTra.maTheGuiXe + "', '" + _thongTinXe.sothexe + "', '" + _thongTinXe.biensoxevao + "', '" + _thongTinXe.nhomthexe + "', '" + _thoigianxevao + "', '" + _thongTinXe.cardeventid + "'); ";
                }
                else
                {
                    _sqlInsertCheck = "INSERT INTO cp_checkxera(patientid, patientcode, vienphiid, hosobenhanid, patientname, checkstatus, checkdate, checknote, checkusercode, checkusername, vienphidate, vienphidate_ravien, bhytid, bhytcode, gioitinhname, namsinh, diachi, vienphistatus, loaivienphiid, departmentgroupid, departmentgroupname, departmentid, departmentname, thuhoithe) VALUES ('" + result.patientid + "', '" + result.patientcode + "', '" + result.vienphiid + "', '" + result.hosobenhanid + "', '" + result.patientname + "', '" + result.maKetQua + "', '" + _checkdate + "', '" + result.ghiChu + "', '" + _filterKiemTra.checkusercode + "', '" + _filterKiemTra.checkusername + "', '" + _vienphidate + "', '" + _vienphidate_ravien + "', '" + result.bhytid + "', '" + result.bhytcode + "', '" + result.gioitinhname + "', '" + _namsinh + "', '" + result.diachi + "', '" + result.vienphistatus + "', '" + result.loaivienphiid + "', '" + result.departmentgroupid + "', '" + result.departmentgroupname + "', '" + result.departmentid + "', '" + result.departmentname + "', '" + result.thuHoiThe + "'); ";
                }

                condb.ExecuteNonQuery_HSBA(_sqlInsertCheck);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        #endregion

        #region Lay mot vai thong tin (Benh nhan; Thong tin xe)
        internal string LayMaBenhNhan(string _maTheGuiXe)
        {
            string result = "";
            try
            {
                string _sqllayBN = "SELECT patientcode,patientid FROM cp_benhnhanthexe WHERE mathexe='" + _maTheGuiXe + "' and COALESCE(ketthuc_status,0)=0; ";
                DataTable _dataBN = condb.GetDataTable(_sqllayBN);
                if (_dataBN != null && _dataBN.Rows.Count > 0)
                {
                    result = _dataBN.Rows[0]["patientcode"].ToString();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }
        private ThongTinVeXeDTO LayThongTinVeTheXe(string _maTheGuiXe)
        {
            ThongTinVeXeDTO result = new ThongTinVeXeDTO();
            try
            {
                string _sqlTKVeXe = "SELECT CAST(even.Id AS VARCHAR(36)) as cardeventid, even.CardNumber as mathexe, even.PlateIn as biensoxevao, even.PlateOut as biensoxera, even.CardNo as sothexe, (convert(varchar, even.DatetimeIn, 108) +' '+ convert(varchar, even.DatetimeIn, 103)) as thoigianvao, REPLACE(REPLACE(REPLACE(CAST(CONVERT(VARCHAR(19), even.DatetimeIn, 120) AS VARCHAR(20)),'-',''),':',''),' ','') as thoigianvao_long, cgrp.CardGroupName as nhomthexe, even.PicDirIn, even.PicDirOut FROM [MPARKINGEVENT].[dbo].[tblCardEvent] even left join [MPARKING].[dbo].[tblCardGroup] cgrp on cgrp.CardGroupID=even.CardGroupID WHERE even.CardNumber='" + _maTheGuiXe + "' ORDER BY even.DateTimeOut desc;";

                DataTable _dataTKVeXe = condb.GetDataTable_BGX(_sqlTKVeXe, 1);
                if (_dataTKVeXe != null && _dataTKVeXe.Rows.Count > 0)
                {
                    List<ThongTinVeXeDTO> lstTKVeXe = Common.DataTables.ConvertDataTable.DataTableToList<ThongTinVeXeDTO>(_dataTKVeXe);
                    if (lstTKVeXe != null && lstTKVeXe.Count > 0)
                    {
                        result = lstTKVeXe[0];
                    }
                    else
                    {
                        result.biensoxevao = "";
                        result.cardeventid = "";
                        result.nhomthexe = "";
                        result.sothexe = "";
                        result.thoigianvao_long = "00010101000000";
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }
        #endregion




    }
}
