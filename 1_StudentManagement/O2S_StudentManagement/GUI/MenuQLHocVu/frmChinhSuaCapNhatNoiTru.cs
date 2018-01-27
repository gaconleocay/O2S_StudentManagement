using AutoMapper;
using DevExpress.XtraSplashScreen;
using O2S_StudentManagement.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O2S_StudentManagement.GUI.MenuThongKe
{
    public partial class frmChinhSuaCapNhatNoiTru : Form
    {
        #region Khai bao     
        private DAL.ConnectDatabase condb = new DAL.ConnectDatabase();
        private ThongTinBenhNhanDTO TTBenhNhan_CapNhat { get; set; }
        private ThongTinVeXeDTO TTVeXe_CapNhat { get; set; }
        private string benhnhanthexeid { get; set; }
        private string sqlInsertUpdateLog { get; set; }
        #endregion
        public frmChinhSuaCapNhatNoiTru()
        {
            InitializeComponent();
        }

        #region Load
        public frmChinhSuaCapNhatNoiTru(string _benhnhanthexeid)
        {
            InitializeComponent();
            this.benhnhanthexeid = _benhnhanthexeid;
            LoadDuLieuLenForm(this.benhnhanthexeid);
        }
        private void LoadDuLieuLenForm(string _benhnhanthexeid)
        {
            try
            {
                string _sqlgetdata = "SELECT row_number () over (order by createdate) as stt, benhnhanthexeid, patientid, patientcode, vienphiid, hosobenhanid, patientname, to_char(vienphidate,'HH24:MI dd/MM/yyyy') as vienphidate, to_char(vienphidate,'yyyyMMddHH24MIss') as vienphidate_long, to_char(vienphidate_noitru,'HH24:MI dd/MM/yyyy') as vienphidate_noitru, to_char(vienphidate_noitru,'yyyyMMddHH24MIss') as vienphidate_noitru_long, (case when vienphidate_ravien<>'0001-01-01 00:00:00' then to_char(vienphidate_ravien,'HH24:MI dd/MM/yyyy') end) as vienphidate_ravien, (case when vienphidate_ravien<>'0001-01-01 00:00:00' then to_char(vienphidate_ravien,'yyyyMMddHH24MIss') else '0' end) as vienphidate_ravien_long, bhytcode, gioitinhname, to_char(namsinh,'dd/MM/yyyy') as namsinh, diachi, (case when vienphistatus=0 then 'Đang điều trị' else 'Đã ra viện' end) as vienphistatus_name, (case loaivienphiid when 0 then 'Nội trú' when 1 then 'Ngoại trú' when 2 then 'Điều trị ngoại trú' end) as loaivienphi_name, (departmentgroupname || ' - ' || departmentname) as khoaphong, mathexe, biensoxe, loaixe, (case when thoigianvao<>'0001-01-01 00:00:00' then to_char(thoigianvao,'HH24:MI dd/MM/yyyy') end) as thoigianvao, (case when thoigianvao<>'0001-01-01 00:00:00' then to_char(thoigianvao,'yyyyMMddHH24MIss') else '0' end) as thoigianvao_long, to_char(createdate,'HH24:MI:ss dd/MM/yyyy') as createdate, (createusercode || ' - ' || createusername) as nguoicapnhat, (case when ketthuc_status=1 then 'Đã kết thúc' end) as ketthuc_status_name, (case when ketthuc_status=1 then to_char(ketthuc_date,'HH24:MI dd/MM/yyyy') end) as ketthuc_date, (case when ketthuc_status=1 then (ketthuc_usercode || ' - ' || ketthuc_username) end) as nguoiketthuc, bhytid, vienphistatus, loaivienphiid, departmentgroupid, departmentgroupname, departmentid, departmentname, createusercode, createusername, ketthuc_status, ketthuc_usercode, ketthuc_username, updatedate, updateusercode, updateusername, cardeventid, sothexe FROM cp_benhnhanthexe WHERE benhnhanthexeid='" + this.benhnhanthexeid + "';";
                DataTable _dataCapNhat = condb.GetDataTable(_sqlgetdata);
                if (_dataCapNhat != null && _dataCapNhat.Rows.Count > 0)
                {
                    List<BenhNhanTheXeDTO> benhnhanthexe = Common.DataTables.ConvertDataTable.DataTableToList<BenhNhanTheXeDTO>(_dataCapNhat);
                    //hien thi thong tin len form
                    txtBN_PatientCode.Text = benhnhanthexe[0].patientcode;
                    txtBN_VienphiId.Text = benhnhanthexe[0].vienphiid.ToString();
                    txtBN_BhytCode.Text = benhnhanthexe[0].bhytcode;
                    txtBN_PatientName.Text = benhnhanthexe[0].patientname;
                    txtBN_NamSinh.Text = benhnhanthexe[0].namsinh.ToString();
                    txtBN_GioiTinh.Text = benhnhanthexe[0].gioitinhname;
                    txtBN_DiaChi.Text = benhnhanthexe[0].diachi;
                    txtBN_TrangThai.Text = benhnhanthexe[0].vienphistatus_name;
                    txtBN_LoaiBenhAn.Text = benhnhanthexe[0].loaivienphi_name;
                    txtBN_TGVaoVien.Text = benhnhanthexe[0].vienphidate.ToString();
                    if (benhnhanthexe[0].vienphidate_noitru != null)
                    {
                        txtBN_TGVaoNoiTru.Text = benhnhanthexe[0].vienphidate_noitru.ToString();
                    }
                    if (benhnhanthexe[0].vienphidate_ravien != null)
                    {
                        txtBN_TGRaVien.Text = benhnhanthexe[0].vienphidate_ravien.ToString();
                    }
                    txtBN_KhoaPhong.Text = benhnhanthexe[0].khoaphong;

                    txtXe_MaTheXe.Text = benhnhanthexe[0].mathexe;
                    txtXe_SoTheXe.Text = benhnhanthexe[0].sothexe;
                    txtXe_BienSoXe.Text = benhnhanthexe[0].biensoxe;
                    txtXe_LoaiXe.Text = benhnhanthexe[0].loaixe;
                    if (benhnhanthexe[0].thoigianvao != null && benhnhanthexe[0].thoigianvao.ToString() != "")
                    {
                        txtXe_ThoiGianVao.Text = benhnhanthexe[0].thoigianvao.ToString();
                    }
                    LoadAnhXeVaoRa(benhnhanthexe[0].cardeventid);
                    //mapping 
                    this.TTBenhNhan_CapNhat = new ThongTinBenhNhanDTO();
                    Mapper.Initialize(cfg => cfg.CreateMap<BenhNhanTheXeDTO, ThongTinBenhNhanDTO>());
                    this.TTBenhNhan_CapNhat = AutoMapper.Mapper.Map<BenhNhanTheXeDTO, ThongTinBenhNhanDTO>(benhnhanthexe[0]);
                    this.TTVeXe_CapNhat = new ThongTinVeXeDTO();
                    Mapper.Initialize(cfg => cfg.CreateMap<BenhNhanTheXeDTO, ThongTinVeXeDTO>());
                    this.TTVeXe_CapNhat = AutoMapper.Mapper.Map<BenhNhanTheXeDTO, ThongTinVeXeDTO>(benhnhanthexe[0]);

                    //Lay Du lieu luu lai Log
                    string _thoigianvao = "0001-01-01 00:00:00";
                    if (benhnhanthexe[0].thoigianvao_long != 0)
                    {
                        _thoigianvao = DateTime.ParseExact(benhnhanthexe[0].thoigianvao_long.ToString(), "yyyyMMddHHmmss", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    string _createdate = "0001-01-01 00:00:00";
                    if (benhnhanthexe[0].createdate != null && benhnhanthexe[0].createdate.ToString() != "0")
                    {
                        _createdate = DateTime.ParseExact(benhnhanthexe[0].createdate.ToString(), "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    this.sqlInsertUpdateLog = "INSERT INTO cp_updatenoitrulog(benhnhanthexeid, patientid, patientcode, vienphiid, hosobenhanid, patientname, cardeventid, sothexe, mathexe, biensoxe, loaixe, thoigianvao, createdate, createusercode, createusername) VALUES ('" + this.benhnhanthexeid + "', '" + benhnhanthexe[0].patientid + "', '" + benhnhanthexe[0].patientcode + "', '" + benhnhanthexe[0].vienphiid + "', '" + benhnhanthexe[0].hosobenhanid + "', '" + benhnhanthexe[0].patientname + "', '" + benhnhanthexe[0].cardeventid + "', '" + benhnhanthexe[0].sothexe + "', '" + benhnhanthexe[0].mathexe + "', '" + benhnhanthexe[0].biensoxe + "', '" + benhnhanthexe[0].loaixe + "', '" + _thoigianvao + "', '" + _createdate + "', '" + benhnhanthexe[0].createusercode + "', '" + benhnhanthexe[0].createusername + "'); ";
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadAnhXeVaoRa(string _cardeventid)
        {
            try
            {
                string _sqlLayAnh = "SELECT PicDirIn,PicDirOut FROM [MPARKINGEVENT].[dbo].[tblCardEvent] WHERE Id='" + _cardeventid + "';";
                DataTable _dataAnhXe = condb.GetDataTable_BGX(_sqlLayAnh, 1);
                if (_dataAnhXe != null && _dataAnhXe.Rows.Count > 0)
                {
                    string _pathAnhXeVao = _dataAnhXe.Rows[0]["PicDirIn"].ToString();
                    if (_pathAnhXeVao != null && _pathAnhXeVao != "")
                    {
                        pictureAnhXeVao_PLATEIN.Image = Image.FromFile(_pathAnhXeVao);
                        pictureAnhXeVao_OVERVIEWIN.Image = Image.FromFile(_pathAnhXeVao.Replace("PLATEIN", "OVERVIEWIN"));
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        #region Events
        private void btnBN_TimKiem_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
            try
            {
                this.TTBenhNhan_CapNhat = new ThongTinBenhNhanDTO();
                if (txtTK_MaBenhNhan.Text != "")
                {
                    ResetThongTinBenhNhan();
                    long _mabenhnhan = Common.TypeConvert.TypeConvertParse.ToInt64(txtTK_MaBenhNhan.Text.ToUpper().Replace("BN", ""));

                    string _sqlTKBN = "SELECT hsba.patientcode, vp.patientid, vp.vienphiid, hsba.hosobenhanid, hsba.patientname, bh.bhytid, bh.bhytcode, hsba.gioitinhname, (case when hsba.birthday_year<>0 then cast(hsba.birthday_year as text) else to_char(hsba.birthday,'dd/MM/yyyy') end) as namsinh, ((case when hsba.hc_sonha<>'' then hsba.hc_sonha || ', ' else '' end) || (case when hsba.hc_thon<>'' then hsba.hc_thon || ' - ' else '' end) || (case when hsba.hc_xacode<>'00' then hsba.hc_xaname || ' - ' else '' end) || (case when hsba.hc_huyencode<>'00' then hsba.hc_huyenname || ' - ' else '' end) || (case when hsba.hc_tinhcode<>'00' then hsba.hc_tinhname else '' end)) as diachi, vp.vienphistatus, (case when vp.vienphistatus=0 then 'Đang điều trị' else 'Đã ra viện' end) as vienphistatus_name, vp.loaivienphiid, (case vp.loaivienphiid when 0 then 'Nội trú' when 1 then 'Ngoại trú' when 2 then 'Điều trị ngoại trú' end) as loaivienphi_name, to_char(vp.vienphidate,'HH24:MI dd/MM/yyyy') as vienphidate, to_char(vp.vienphidate,'yyyyMMddHH24MIss') as vienphidate_long, (case when vp.vienphidate_ravien<>'0001-01-01 00:00:00' then to_char(vp.vienphidate_ravien,'HH24:MI dd/MM/yyyy') end) as vienphidate_ravien, to_char(mrd.thoigianvaovien,'HH24:MI dd/MM/yyyy') as vienphidate_noitru, to_char(mrd.thoigianvaovien,'yyyyMMddHH24MIss') as vienphidate_noitru_long, (case when vp.vienphidate_ravien<>'0001-01-01 00:00:00' then to_char(vp.vienphidate_ravien,'yyyyMMddHH24MIss') else '0' end) as vienphidate_ravien_long, (case when vp.vienphidate_ravien<>'0001-01-01 00:00:00' then to_char(vp.vienphidate_ravien,'yyyyMMdd') else '0' end) as vienphidate_ravien_day_long, (degp.departmentgroupname || ' - ' || de.departmentname) as khoaphong, vp.departmentgroupid, degp.departmentgroupname, vp.departmentid, de.departmentname FROM (select vienphiid,vienphicode,hosobenhanid,patientid,bhytid,vienphistatus,loaivienphiid,vienphidate,vienphidate_noitru,vienphidate_ravien,departmentgroupid,departmentid from vienphi where patientid=" + _mabenhnhan + ") vp left join (select hosobenhanid,departmentgroupid,thoigianvaovien from medicalrecord where hinhthucvaovienid=2 and patientid=" + _mabenhnhan + ") mrd on mrd.hosobenhanid=vp.hosobenhanid inner join (select hosobenhanid,patientcode,patientname,gioitinhname,birthday,birthday_year,hc_sonha,hc_thon,hc_xacode,hc_xaname,hc_huyencode,hc_huyenname,hc_tinhcode,hc_tinhname from hosobenhan where patientid=" + _mabenhnhan + ") hsba on hsba.hosobenhanid=vp.hosobenhanid inner join (select bhytid,bhytcode from bhyt where patientid=" + _mabenhnhan + ") bh on bh.bhytid=vp.bhytid left join (select departmentgroupid,departmentgroupname from departmentgroup) degp on degp.departmentgroupid=vp.departmentgroupid left join (select departmentid,departmentname from department) de on de.departmentid=vp.departmentid ORDER BY vp.vienphidate desc;";

                    DataTable _dataTKBN = condb.GetDataTable(_sqlTKBN);
                    if (_dataTKBN != null && _dataTKBN.Rows.Count > 0)
                    {
                        List<ThongTinBenhNhanDTO> lstTKBN = Common.DataTables.ConvertDataTable.DataTableToList<ThongTinBenhNhanDTO>(_dataTKBN);
                        if (lstTKBN != null && lstTKBN.Count > 0)
                        {
                            this.TTBenhNhan_CapNhat = lstTKBN[0];
                            HienThiThongTinVeBenhNhan(this.TTBenhNhan_CapNhat);
                        }
                    }
                    else
                    {
                        lblKetQua.Text = "Bệnh nhân " + txtTK_MaBenhNhan.Text + " không tìm thấy hoặc không phải là bệnh nhân nội trú!";
                        lblKetQua.ForeColor = Color.Red;
                    }
                }
                else
                {
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CHUA_NHAP_MA_BENH_NHAN);
                    frmthongbao.Show();
                }
                txtTK_MaBenhNhan.SelectAll();
                txtTK_MaBenhNhan.Focus();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            SplashScreenManager.CloseForm();
        }

        private void btnXe_TimKiem_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
            try
            {
                this.TTVeXe_CapNhat = new ThongTinVeXeDTO();
                if (txtTK_SoTheXe.Text != "")
                {
                    //string _mathexeHEX = Common.TypeConvert.TypeConvertParse.ToUInt64(txtTK_MaTheXe.Text).ToString("X");
                    ResetThongTinVeXe();
                    string _sqlTKVeXe = "SELECT CAST(even.Id AS VARCHAR(36)) as cardeventid, even.CardNumber as mathexe, even.PlateIn as biensoxevao, even.PlateOut as biensoxera, even.CardNo as sothexe, (convert(varchar, even.DatetimeIn, 108) +' '+ convert(varchar, even.DatetimeIn, 103)) as thoigianvao, REPLACE(REPLACE(REPLACE(CAST(CONVERT(VARCHAR(19), even.DatetimeIn, 120) AS VARCHAR(20)),'-',''),':',''),' ','') as thoigianvao_long, cgrp.CardGroupName as nhomthexe, even.PicDirIn, even.PicDirOut FROM [MPARKINGEVENT].[dbo].[tblCardEvent] even left join [MPARKING].[dbo].[tblCardGroup] cgrp on cgrp.CardGroupID=even.CardGroupID WHERE even.DateTimeOut IS NULL and even.CardNo='" + txtTK_SoTheXe.Text.PadLeft(6, '0') + "' ORDER BY even.DatetimeIn desc;";

                    DataTable _dataTKVeXe = condb.GetDataTable_BGX(_sqlTKVeXe, 1);
                    if (_dataTKVeXe != null && _dataTKVeXe.Rows.Count > 0)
                    {
                        List<ThongTinVeXeDTO> lstTKVeXe = Common.DataTables.ConvertDataTable.DataTableToList<ThongTinVeXeDTO>(_dataTKVeXe);
                        if (lstTKVeXe != null && lstTKVeXe.Count > 0)
                        {
                            this.TTVeXe_CapNhat = lstTKVeXe[0];
                            HienThiThongTinVeXe(this.TTVeXe_CapNhat);
                            LoadAnhXeVaoRa_Path(this.TTVeXe_CapNhat.PicDirIn);
                        }
                    }
                    else
                    {
                        string _sqlTKVeXe_ketthuc = "SELECT even.Id, even.CardNumber as mathexe, even.PlateIn as biensoxevao, even.PlateOut as biensoxera FROM [MPARKINGEVENT].[dbo].[tblCardEvent] even WHERE even.DateTimeOut IS NOT NULL and even.CardNo='" + txtTK_SoTheXe.Text + "';";
                        DataTable _dataTKVeXe_KetThuc = condb.GetDataTable_BGX(_sqlTKVeXe_ketthuc, 1);
                        if (_dataTKVeXe != null && _dataTKVeXe.Rows.Count > 0)
                        {
                            lblKetQua.Text = "Xe đã kết thúc!";
                            lblKetQua.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblKetQua.Text = "Không tìm thấy thông tin về thẻ xe trên!";
                            lblKetQua.ForeColor = Color.Red;
                        }
                    }
                }
                else
                {
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CHUA_TAG_THE_GUI_XE);
                    frmthongbao.Show();
                }
                txtTK_SoTheXe.SelectAll();
                txtTK_SoTheXe.Focus();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            SplashScreenManager.CloseForm();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.TTBenhNhan_CapNhat.patientcode != null && this.TTVeXe_CapNhat.mathexe != null)
                {
                    string _namsinh = "0001-01-01 00:00:00";
                    if (this.TTBenhNhan_CapNhat.namsinh.Length == 4)
                    {
                        _namsinh = this.TTBenhNhan_CapNhat.namsinh + "-01-01 00:00:00";
                    }
                    else
                    {
                        _namsinh = DateTime.ParseExact(this.TTBenhNhan_CapNhat.namsinh, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    string _vienphidate = DateTime.ParseExact(this.TTBenhNhan_CapNhat.vienphidate_long.ToString(), "yyyyMMddHHmmss", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                    string _vienphidate_ravien = "0001-01-01 00:00:00";
                    if (this.TTBenhNhan_CapNhat.vienphidate_ravien_long != 0)
                    {
                        _vienphidate_ravien = DateTime.ParseExact(this.TTBenhNhan_CapNhat.vienphidate_ravien_long.ToString(), "yyyyMMddHHmmss", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    string _vienphidate_noitru = "0001-01-01 00:00:00";
                    if (this.TTBenhNhan_CapNhat.vienphidate_noitru_long != 0)
                    {
                        _vienphidate_noitru = DateTime.ParseExact(this.TTBenhNhan_CapNhat.vienphidate_noitru_long.ToString(), "yyyyMMddHHmmss", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    string _thoigianvao = "0001-01-01 00:00:00";
                    if (this.TTVeXe_CapNhat.thoigianvao_long != null && this.TTVeXe_CapNhat.thoigianvao_long.ToString() != "0")
                    {
                        _thoigianvao = DateTime.ParseExact(this.TTVeXe_CapNhat.thoigianvao_long.ToString(), "yyyyMMddHHmmss", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                    }

                    string _sqlupdate = " UPDATE cp_benhnhanthexe SET patientid='" + TTBenhNhan_CapNhat.patientid + "', patientcode='" + TTBenhNhan_CapNhat.patientcode + "', vienphiid='" + TTBenhNhan_CapNhat.vienphiid + "', hosobenhanid='" + TTBenhNhan_CapNhat.hosobenhanid + "', patientname='" + TTBenhNhan_CapNhat.patientname + "', vienphidate='" + _vienphidate + "', vienphidate_noitru='" + _vienphidate_noitru + "', vienphidate_ravien='" + _vienphidate_ravien + "', bhytid='" + TTBenhNhan_CapNhat.bhytid + "', bhytcode='" + TTBenhNhan_CapNhat.bhytcode + "', gioitinhname='" + TTBenhNhan_CapNhat.gioitinhname + "', namsinh='" + _namsinh + "', diachi='" + TTBenhNhan_CapNhat.diachi + "', vienphistatus='" + TTBenhNhan_CapNhat.vienphistatus + "', loaivienphiid='" + TTBenhNhan_CapNhat.loaivienphiid + "', departmentgroupid='" + TTBenhNhan_CapNhat.departmentgroupid + "', departmentgroupname='" + TTBenhNhan_CapNhat.departmentgroupname + "', departmentid='" + TTBenhNhan_CapNhat.departmentid + "', departmentname='" + TTBenhNhan_CapNhat.departmentname + "', mathexe='" + TTVeXe_CapNhat.mathexe + "', biensoxe='" + TTVeXe_CapNhat.biensoxevao + "', loaixe='', thoigianvao='" + _thoigianvao + "', updatedate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', updateusercode='" + Base.SessionLogin.SessionUsercode + "', updateusername='" + Base.SessionLogin.SessionUsername + "', ketthuc_status='0', sothexe='" + this.TTVeXe_CapNhat.sothexe + "', cardeventid='" + this.TTVeXe_CapNhat.cardeventid + "' WHERE benhnhanthexeid='" + this.benhnhanthexeid + "';";

                    if (condb.ExecuteNonQuery_HSBA(_sqlupdate))
                    {
                        lblKetQua.Text = "Cập nhật nội trú thành công mã bệnh nhân: " + TTBenhNhan_CapNhat.patientcode;
                        lblKetQua.ForeColor = Color.Blue;
                        condb.ExecuteNonQuery_HSBA(this.sqlInsertUpdateLog);
                    }
                    else
                    {
                        Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CO_LOI_XAY_RA);
                        frmthongbao.Show();
                    }
                }
                else
                {
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CAP_NHAT_THAT_BAI);
                    frmthongbao.Show();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void ResetThongTinBenhNhan()
        {
            try
            {
                txtBN_PatientCode.Text = "";
                txtBN_VienphiId.Text = "";
                txtBN_BhytCode.Text = "";
                txtBN_PatientName.Text = "";
                txtBN_NamSinh.Text = "";
                txtBN_GioiTinh.Text = "";
                txtBN_DiaChi.Text = "";
                txtBN_TrangThai.Text = "";
                txtBN_LoaiBenhAn.Text = "";
                txtBN_TGVaoVien.Text = "";
                txtBN_TGVaoNoiTru.Text = "";
                txtBN_TGRaVien.Text = "";
                txtBN_KhoaPhong.Text = "";
                lblKetQua.Text = "";
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void ResetThongTinVeXe()
        {
            try
            {
                txtXe_MaTheXe.Text = "";
                txtXe_SoTheXe.Text = "";
                txtXe_BienSoXe.Text = "";
                txtXe_LoaiXe.Text = "";
                txtXe_ThoiGianVao.Text = "";
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void HienThiThongTinVeBenhNhan(ThongTinBenhNhanDTO _BNCapNhat)
        {
            try
            {
                txtBN_PatientCode.Text = _BNCapNhat.patientcode;
                txtBN_VienphiId.Text = _BNCapNhat.vienphiid.ToString();
                txtBN_BhytCode.Text = _BNCapNhat.bhytcode;
                txtBN_PatientName.Text = _BNCapNhat.patientname;
                txtBN_NamSinh.Text = _BNCapNhat.namsinh;
                txtBN_GioiTinh.Text = _BNCapNhat.gioitinhname;
                txtBN_DiaChi.Text = _BNCapNhat.diachi;
                txtBN_TrangThai.Text = _BNCapNhat.vienphistatus_name;
                txtBN_LoaiBenhAn.Text = _BNCapNhat.loaivienphi_name;
                txtBN_TGVaoVien.Text = _BNCapNhat.vienphidate.ToString();
                if (_BNCapNhat.vienphidate_noitru != null)
                {
                    txtBN_TGVaoNoiTru.Text = _BNCapNhat.vienphidate_noitru.ToString();
                }
                if (_BNCapNhat.vienphidate_ravien != null)
                {
                    txtBN_TGRaVien.Text = _BNCapNhat.vienphidate_ravien.ToString();
                }
                txtBN_KhoaPhong.Text = _BNCapNhat.khoaphong;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void HienThiThongTinVeXe(ThongTinVeXeDTO _XeCapNhat)
        {
            try
            {
                txtXe_MaTheXe.Text = _XeCapNhat.mathexe;
                txtXe_BienSoXe.Text = _XeCapNhat.biensoxevao;
                txtXe_SoTheXe.Text = _XeCapNhat.sothexe;
                txtXe_LoaiXe.Text = _XeCapNhat.nhomthexe;
                txtXe_ThoiGianVao.Text = _XeCapNhat.thoigianvao.ToString();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadAnhXeVaoRa_Path(string PicDirIn)
        {
            try
            {
                if (PicDirIn != null && PicDirIn != "")
                {
                    pictureAnhXeVao_PLATEIN.Image = Image.FromFile(PicDirIn);
                    pictureAnhXeVao_OVERVIEWIN.Image = Image.FromFile(PicDirIn.Replace("PLATEIN", "OVERVIEWIN"));
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }




        #endregion

        #region Custom
        private void txtTK_MaBenhNhan_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnBN_TimKiem.PerformClick();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void txtTK_MaTheXe_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnXe_TimKiem.PerformClick();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void txtTK_MaBenhNhan_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtTK_MaBenhNhan.Text = txtTK_MaBenhNhan.Text.ToUpper();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void txtTK_SoTheXe_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion


        #region Shortcut
        private void barButtonbtnCapNhat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                btnCapNhat.PerformClick();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion


    }
}
