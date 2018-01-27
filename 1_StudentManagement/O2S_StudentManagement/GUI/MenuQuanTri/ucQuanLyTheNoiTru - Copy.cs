using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.Globalization;
using O2S_CarParking.Model.Models;
using DevExpress.XtraSplashScreen;

namespace O2S_CarParking.GUI.MenuQuanTri
{
    public partial class ucQuanLyTheNoiTru : UserControl
    {
        #region Khai bao
        private DAL.ConnectDatabase condb = new DAL.ConnectDatabase();
        private List<LichSuXeBenhNhanDTO> lstLichSuXeBenhNhan { get; set; }
        private LichSuXeBenhNhanDTO LSXeBenhNhanClick { get; set; }
        #endregion
        public ucQuanLyTheNoiTru()
        {
            InitializeComponent();
        }

        #region Load
        private void ucQuanLyTheNoiTru_Load(object sender, EventArgs e)
        {
            try
            {
                dateTuNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00");
                dateDenNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
                // ResetDataConTrol();
                LoadDanhSachBenhNhanGuiXe();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void ResetDataConTrol()
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
                txtBN_TGRaVien.Text = "";
                txtBN_KhoaPhong.Text = "";
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        #region Tim kiem
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
            try
            {
                ResetDataConTrol();
                LoadDanhSachBenhNhanGuiXe();
                if (gridViewDSBNGuiXe.RowCount == 1)
                {
                    gridViewDSBNGuiXe.FocusedRowHandle = 0;
                    gridControlDSBNGuiXe_Click(null, null);
                }
                if (txtTK_MaBenhNhan.Text.Trim() != "")
                {
                    txtTK_MaBenhNhan.SelectAll();
                    txtTK_MaBenhNhan.Focus();
                }
                if (txtTK_SoTheXe.Text.Trim() != "")
                {
                    txtTK_SoTheXe.SelectAll();
                    txtTK_SoTheXe.Focus();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            SplashScreenManager.CloseForm();
        }

        #region Tim Kiem Process
        private void LoadDanhSachBenhNhanGuiXe()
        {
            try
            {
                string _tblCardEventFilter = "";
                string _CPBenhNhanTheXeFilter = "";

                string _tieuchiTimKiem = "";
                string _CardNo = "";
                string _TrangThaiXe = "";
                string _TrangThaiKiemTra = "";
                string _LoaiBenhAn = "";
                string _TrangThaiKetThuc = "";

                if (txtTK_MaBenhNhan.Text != "" && txtTK_SoTheXe.Text == "")
                {
                    long _mabenhnhan = Common.TypeConvert.TypeConvertParse.ToInt64(txtTK_MaBenhNhan.Text.ToUpper().Replace("BN", ""));
                    _tieuchiTimKiem = " and patientid='" + _mabenhnhan + "' ";
                    if (_mabenhnhan > 2147483647)
                    {
                        gridControlDSBNGuiXe.DataSource = null;
                        return;
                    }
                }
                else if (txtTK_MaBenhNhan.Text == "" && txtTK_SoTheXe.Text != "")
                {
                    _tieuchiTimKiem = " and sothexe='" + txtTK_SoTheXe.Text.Trim() + "' ";
                    _CardNo = " and CardNo='" + txtTK_SoTheXe.Text.Trim() + "' ";
                }
                string tungay = DateTime.ParseExact(dateTuNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                string denngay = DateTime.ParseExact(dateDenNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");

                if (cboTrangThaiXe.Text == "Chưa lấy xe")
                {
                    _TrangThaiXe = " and even.DateTimeOut is NULL ";
                }
                else if (cboTrangThaiXe.Text == "Đã lấy xe")
                {
                    _TrangThaiXe = " and even.DateTimeOut is NOT NULL ";
                }

                if (cboTrangThaiKiemTra.Text == "Miễn phí")
                {
                    _TrangThaiKiemTra = " and even.IsFree=1 ";
                }
                else if (cboTrangThaiKiemTra.Text == "Thu phí")
                {
                    _TrangThaiKiemTra = " and even.IsFree=0 ";
                }

                if (cboLoaiBenhAn.Text == "Ngoại trú")
                {
                    _LoaiBenhAn = " ";
                }
                else if (cboLoaiBenhAn.Text == "Nội trú")
                {
                    _LoaiBenhAn = " ";
                }

                if (cboTrangThaiKetThuc.Text == "Chưa kết thúc")
                {
                    _TrangThaiKetThuc = " COALESCE(ketthuc_status,0)=0 ";
                }
                else if (cboTrangThaiKetThuc.Text == "Đã kết thúc")
                {
                    _TrangThaiKetThuc = " ketthuc_status=1 ";
                }

                //filter
                _tblCardEventFilter = " even.DatetimeIn between '" + tungay + "' and '" + denngay + "' " + _TrangThaiXe + _TrangThaiKiemTra;
                _CPBenhNhanTheXeFilter = "";

                this.lstLichSuXeBenhNhan = new List<LichSuXeBenhNhanDTO>();
                this.LSXeBenhNhanClick = new LichSuXeBenhNhanDTO();

                //Insert thong tin xe ra/vao tblCardEvents
                string _createdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                InsertThongTinXeRaVao(_tblCardEventFilter, _createdate);



                ////Load tblCardEvent
                //List<tblCardEventDTO> lstCardEvent = GetCardEvent(_tblCardEventFilter);
                ////Load CPBenhNhanTheXe
                //List<CPBenhNhanTheXeDTO> lstBenhNhanTheXe = GetBenhNhanTheXe(_CPBenhNhanTheXeFilter);
                ////Mapping
                //this.lstLichSuXeBenhNhan = MapPingCardEventVaBenhNhan(lstCardEvent, lstBenhNhanTheXe);
                if (this.lstLichSuXeBenhNhan != null && this.lstLichSuXeBenhNhan.Count > 0)
                {
                    gridControlDSBNGuiXe.DataSource = this.lstLichSuXeBenhNhan;
                }
                else
                {
                    gridControlDSBNGuiXe.DataSource = null;
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.KHONG_CO_DU_LIEU);
                    frmthongbao.Show();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void InsertThongTinXeRaVao(string _tblCardEventFilter, string _createdate)
        {
            try
            {
                string _sqlGetXeVaoRa = " SELECT even.Id as CardEventID, even.CardNo, even.CardNumber, even.PlateIn, even.PlateOut, CONVERT(VARCHAR(19), even.DatetimeIn, 20) as DatetimeIn, REPLACE(REPLACE(REPLACE(CAST(CONVERT(VARCHAR(19), even.DatetimeIn, 120) AS VARCHAR(20)),'-',''),':',''),' ','') as DatetimeIn_long, (case when even.DateTimeOut is not null then CONVERT(VARCHAR(19), even.DateTimeOut, 20) else '0001-01-01 00:00:00' end) as DateTimeOut, (case when even.DateTimeOut is not null then REPLACE(REPLACE(REPLACE(CAST(CONVERT(VARCHAR(19), even.DateTimeOut, 120) AS VARCHAR(20)),'-',''),':',''),' ','') else '0' end) as DateTimeOut_long, uvao.FullName as UserIn, ura.FullName as UserOut, lan_in.LaneName as LaneIn, lan_out.LaneName as LaneOut, even.PicDirIn, even.PicDirOut, (case when even.IsFree=0 then even.Moneys else 0 end) as Moneys, cgrp.CardGroupName, even.CustomerName, even.IsFree FROM [MPARKINGEVENT].[dbo].[tblCardEvent] even left join [MPARKING].[dbo].[tblUser] uvao on uvao.UserID=even.UserIDIn left join [MPARKING].[dbo].[tblUser] ura on convert(nvarchar(50),ura.UserID)=convert(nvarchar(50),even.UserIDOut) left join [MPARKING].[dbo].[tblLane] lan_in on convert(nvarchar(50),lan_in.LaneID)=convert(nvarchar(50),even.LaneIDIn) left join [MPARKING].[dbo].[tblLane] lan_out on convert(nvarchar(50),lan_out.LaneID)=convert(nvarchar(50),even.LaneIDOut) left join [MPARKING].[dbo].[tblCardGroup] cgrp on cgrp.CardGroupID=even.CardGroupID WHERE " + _tblCardEventFilter + "; ";
                DataTable _dataXeVaoRa = condb.GetDataTable_BGX(_sqlGetXeVaoRa, 1);
                if (_dataXeVaoRa != null && _dataXeVaoRa.Rows.Count > 0)
                {
                    string _sqlInsert = "";
                    for (int i = 0; i < _dataXeVaoRa.Rows.Count; i++)
                    {
                        _sqlInsert += "INSERT INTO cp_cardevent_tmp(cardeventid, cardnumber, datetimein, datetimein_long, datetimeout, datetimeout_long, picdirin, picdirout, lanein, laneout, userin, userout, platein, plateout, moneys, cardgroupname, customername, isfree, cardno, createdate, createusercode) VALUES ('" + _dataXeVaoRa.Rows[i]["cardeventid"].ToString() + "', '" + _dataXeVaoRa.Rows[i]["cardnumber"].ToString() + "', '" + _dataXeVaoRa.Rows[i]["datetimein"].ToString() + "', '" + _dataXeVaoRa.Rows[i]["datetimein_long"].ToString() + "', '" + _dataXeVaoRa.Rows[i]["datetimeout"].ToString() + "', '" + _dataXeVaoRa.Rows[i]["datetimeout_long"].ToString() + "', '" + _dataXeVaoRa.Rows[i]["picdirin"].ToString() + "', '" + _dataXeVaoRa.Rows[i]["picdirout"].ToString() + "', '" + _dataXeVaoRa.Rows[i]["lanein"].ToString() + "', '" + _dataXeVaoRa.Rows[i]["laneout"].ToString() + "', '" + _dataXeVaoRa.Rows[i]["userin"].ToString() + "', '" + _dataXeVaoRa.Rows[i]["userout"].ToString() + "', '" + _dataXeVaoRa.Rows[i]["platein"].ToString() + "', '" + _dataXeVaoRa.Rows[i]["plateout"].ToString() + "', '" + _dataXeVaoRa.Rows[i]["moneys"].ToString() + "', '" + _dataXeVaoRa.Rows[i]["cardgroupname"].ToString() + "', '" + _dataXeVaoRa.Rows[i]["customername"].ToString() + "', '" + _dataXeVaoRa.Rows[i]["isfree"].ToString() + "', '" + _dataXeVaoRa.Rows[i]["cardno"].ToString() + "', '" + _createdate + "', '" + Base.SessionLogin.SessionUsercode + "'); ";
                    }
                    condb.ExecuteNonQuery_HSBA(_sqlInsert);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        /*
        private List<tblCardEventDTO> GetCardEvent(string _tblCardEventFilter)
        {
            List<tblCardEventDTO> result = new List<tblCardEventDTO>();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }
        private List<CPBenhNhanTheXeDTO> GetBenhNhanTheXe(string _CPBenhNhanTheXeFilter)
        {
            List<CPBenhNhanTheXeDTO> result = new List<CPBenhNhanTheXeDTO>();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }
        private List<LichSuXeBenhNhanDTO> MapPingCardEventVaBenhNhan(List<tblCardEventDTO> lstCardEvent, List<CPBenhNhanTheXeDTO> lstBenhNhanTheXe)
        {
            List<LichSuXeBenhNhanDTO> result = new List<LichSuXeBenhNhanDTO>();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }
        */
        #endregion
        #endregion

        #region Events

        #region Row Benh nhan click
        private void gridControlDSBNGuiXe_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewDSBNGuiXe.RowCount > 0)
                {
                    var rowHandle = gridViewDSBNGuiXe.FocusedRowHandle;
                    long _benhnhanthexeid = Common.TypeConvert.TypeConvertParse.ToInt64(gridViewDSBNGuiXe.GetRowCellValue(rowHandle, "benhnhanthexeid").ToString());
                    if (this.lstLichSuXeBenhNhan != null && this.lstLichSuXeBenhNhan.Count > 0)
                    {
                        this.LSXeBenhNhanClick = this.lstLichSuXeBenhNhan.Where(o => o.benhnhanthexeid == _benhnhanthexeid).FirstOrDefault();
                        if (this.LSXeBenhNhanClick != null)
                        {
                            Row_LayThongTinBenhNhan(this.LSXeBenhNhanClick);
                            Row_LayThongTinPhieuThu(this.LSXeBenhNhanClick);
                            Row_HienThiNutChucNang(this.LSXeBenhNhanClick);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void Row_LayThongTinBenhNhan(LichSuXeBenhNhanDTO _TTBenhNhan)
        {
            try
            {
                txtBN_PatientCode.Text = _TTBenhNhan.patientcode;
                txtBN_VienphiId.Text = _TTBenhNhan.vienphiid.ToString();
                txtBN_BhytCode.Text = _TTBenhNhan.bhytcode;
                txtBN_PatientName.Text = _TTBenhNhan.patientname;
                txtBN_NamSinh.Text = _TTBenhNhan.namsinh.ToString();
                txtBN_GioiTinh.Text = _TTBenhNhan.gioitinhname;
                txtBN_DiaChi.Text = _TTBenhNhan.diachi;
                txtBN_TrangThai.Text = _TTBenhNhan.vienphistatus_name;
                txtBN_LoaiBenhAn.Text = _TTBenhNhan.loaivienphi_name;
                txtBN_TGVaoVien.Text = _TTBenhNhan.vienphidate.ToString();
                if (_TTBenhNhan.vienphidate_ravien != null)
                {
                    txtBN_TGRaVien.Text = _TTBenhNhan.vienphidate_ravien.ToString();
                }
                txtBN_KhoaPhong.Text = _TTBenhNhan.khoaphong;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void Row_LayThongTinPhieuThu(LichSuXeBenhNhanDTO _TTBenhNhan)
        {
            try
            {
                string _sqlDSPhieuThu = " ";
                DataTable _dtDSPhieuThu = condb.GetDataTable_HSBA(_sqlDSPhieuThu);
                if (_dtDSPhieuThu != null && _dtDSPhieuThu.Rows.Count > 0)
                {
                    List<BillDTO> lstBillBN = Common.DataTables.ConvertDataTable.DataTableToList<BillDTO>(_dtDSPhieuThu);
                    HienThiTongSoTien(lstBillBN.Where(o => o.dahuyphieu == 0).ToList());
                }
                else
                {
                    HienThiTongSoTien(null);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void Row_HienThiNutChucNang(LichSuXeBenhNhanDTO _TTBenhNhan)
        {
            try
            {
                if (_TTBenhNhan.ketthuc_status != 1)
                {
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void HienThiTongSoTien(List<BillDTO> _lstBillBN)
        {
            try
            {
                if (_lstBillBN != null)
                {
                    decimal _tongTamUng = 0;
                    decimal _tongHoanUng = 0;
                    decimal _tongTienThu = 0;
                    decimal _tongNopThem = 0;
                    foreach (var item in _lstBillBN)
                    {
                        if (item.loaiphieuthuid == 0)
                        {
                            _tongTamUng += item.sotien;
                        }
                        else if (item.loaiphieuthuid == 1)
                        {
                            _tongHoanUng += item.sotien;
                        }
                        else if (item.loaiphieuthuid == 2)
                        {
                            _tongTienThu += item.sotien;
                        }
                    }
                    _tongNopThem = _tongHoanUng - (_tongTamUng + _tongTienThu);
                    lblTienTamUng.Text = Common.Number.NumberConvert.NumberToString(_tongTamUng, 0);
                    lblTienHoanUng.Text = Common.Number.NumberConvert.NumberToString(_tongHoanUng, 0);
                    lblTienDaNop.Text = Common.Number.NumberConvert.NumberToString(_tongTienThu, 0);
                    lblTienNopThem.Text = Common.Number.NumberConvert.NumberToString(_tongNopThem, 0);
                    if (_tongNopThem > 0)//thieu tien
                    {
                        lblTienNopThem.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblTienNopThem.ForeColor = Color.Blue;
                    }
                }
                else
                {
                    lblTienTamUng.Text = "0";
                    lblTienHoanUng.Text = "0";
                    lblTienDaNop.Text = "0";
                    lblTienNopThem.Text = "0";
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion


        private void repositoryItemButton_Xoa_Click(object sender, EventArgs e)
        {

        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.LSXeBenhNhanClick.ketthuc_status != 1) //ket thuc
                {
                    //kiểm tra lại đã thanh toán hết tiền chưa?
                    if (lblTienNopThem.Text != "0")
                    {
                        MessageBox.Show("Số tiền nộp thêm = " + lblTienNopThem.Text + "\nKhông thể kết thúc gửi xe được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn kết thúc?", "Thông báo !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string _ketthuc_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        string _sqlUpdateKT = "UPDATE cp_benhnhanthexe SET ketthuc_status=1, ketthuc_date='" + _ketthuc_date + "', ketthuc_usercode='" + Base.SessionLogin.SessionUsercode + "', ketthuc_username='" + Base.SessionLogin.SessionUsername + "' WHERE vienphiid='" + this.LSXeBenhNhanClick.vienphiid + "';";
                        if (condb.ExecuteNonQuery_HSBA(_sqlUpdateKT))
                        {
                            Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THAO_TAC_THANH_CONG);
                            frmthongbao.Show();
                            //btnKetThuc.Text = "Hủy kết thúc\n(" + Base.SessionLogin.SessionUsername + ")\n" + DateTime.ParseExact(_ketthuc_date, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");
                            foreach (var item in this.lstLichSuXeBenhNhan)
                            {
                                if (item.vienphiid == this.LSXeBenhNhanClick.vienphiid)
                                {
                                    item.ketthuc_status = 1;
                                }
                            }
                            gridControlDSBNGuiXe.DataSource = this.lstLichSuXeBenhNhan;
                        }
                        else
                        {
                            Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THAO_TAC_THAT_BAI);
                            frmthongbao.Show();
                        }
                    }
                }
                else //Go ket thuc
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn gỡ kết thúc?", "Thông báo !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string _sqlUpdateKT = "UPDATE cp_benhnhanthexe SET ketthuc_status=0, ketthuc_date='0001-01-01 00:00:00', ketthuc_usercode='', ketthuc_username='', updatedate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', updateusercode='" + Base.SessionLogin.SessionUsercode + "', updateusername='" + Base.SessionLogin.SessionUsername + "' WHERE vienphiid='" + this.LSXeBenhNhanClick.vienphiid + "';";
                        if (condb.ExecuteNonQuery_HSBA(_sqlUpdateKT))
                        {
                            Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THAO_TAC_THANH_CONG);
                            frmthongbao.Show();
                            foreach (var item in this.lstLichSuXeBenhNhan)
                            {
                                if (item.vienphiid == this.LSXeBenhNhanClick.vienphiid)
                                {
                                    item.ketthuc_status = 0;
                                }
                            }
                            gridControlDSBNGuiXe.DataSource = this.lstLichSuXeBenhNhan;
                        }
                        else
                        {
                            Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THAO_TAC_THAT_BAI);
                            frmthongbao.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }


        #endregion

        #region Custom
        private void gridViewDSHoaDon_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (e.RowHandle == view.FocusedRowHandle)
                {
                    e.Appearance.BackColor = Color.LightGreen;
                    e.Appearance.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void txtTK_MaBenhNhan_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnTimKiem.PerformClick();
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
                    btnTimKiem.PerformClick();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void gridViewDSBNGuiXe_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "status_img")
                {
                    string val = Convert.ToString(gridViewDSBNGuiXe.GetRowCellValue(e.RowHandle, "ketthuc_status"));
                    if (val == "1")
                    {
                        e.Handled = true;
                        Point pos = Utilities.GUIGridView.Util_GUIGridView.CalcPosition(e, imageListstatus.Images[1]);
                        e.Graphics.DrawImage(imageListstatus.Images[1], pos);
                    }
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
                if (txtTK_MaBenhNhan.Text != "")
                {
                    //txtTK_MaBenhNhan.SelectAll();
                    //txtTK_MaBenhNhan.Focus();
                    txtTK_SoTheXe.Text = "";
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void txtTK_MaTheXe_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTK_SoTheXe.Text.Trim().Length == 10)
                {
                    txtTK_SoTheXe.Text = Common.TypeConvert.TypeConvertParse.ToUInt64(txtTK_SoTheXe.Text).ToString("X");
                    //txtTK_MaTheXe.SelectAll();
                    //txtTK_MaTheXe.Focus();
                    txtTK_MaBenhNhan.Text = "";
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        #endregion

        #region Process



        #endregion

        #region Click Picture
        private void pictureAnhXeVao_PLATEIN_Click(object sender, EventArgs e)
        {

        }

        private void pictureAnhXeVao_OVERVIEWIN_Click(object sender, EventArgs e)
        {

        }

        private void pictureAnhXeRa_PLATEOUT_Click(object sender, EventArgs e)
        {

        }

        private void pictureAnhXeVao_OVERVIEWOUT_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
