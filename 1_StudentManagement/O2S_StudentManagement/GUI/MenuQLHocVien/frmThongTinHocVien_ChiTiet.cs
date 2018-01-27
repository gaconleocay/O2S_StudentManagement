using O2S_StudentManagement.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O2S_StudentManagement.GUI.MenuQLHocVien
{
    public partial class frmThongTinHocVien_ChiTiet : Form
    {
        #region Khai bao
        private long hocvienId { get; set; }
        #endregion

        public frmThongTinHocVien_ChiTiet()
        {
            InitializeComponent();
        }
        public frmThongTinHocVien_ChiTiet(long _hocvienId)
        {
            InitializeComponent();
            this.hocvienId = _hocvienId;
        }

        #region Load
        private void frmThongTinHocVien_ChiTiet_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDuLieuMacDinh_TTHV();
                LoadDuLieuMacDinh_GiaDinh();
                LoadDuLieuMacDinh_QuaTrinhHT();

                LoadThongTinHocVien();          
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadDuLieuMacDinh_TTHV()
        {
            try
            {
                //Gioi tinh
                cbogioitinh.Properties.DataSource = DAL.LoadDuLieuDanhMuc.Load_DMOtherList("GIOITINH");
                cbogioitinh.Properties.DisplayMember = "otherlistname";
                cbogioitinh.Properties.ValueMember = "id";
                //Dan toc
                cbodantoc.Properties.DataSource = DAL.LoadDuLieuDanhMuc.Load_DMDanToc();
                cbodantoc.Properties.DisplayMember = "name_vn";
                cbodantoc.Properties.ValueMember = "id";
                //Tinh
                cbotinh.Properties.DataSource = DAL.LoadDuLieuDanhMuc.Load_DMTinh();
                cbotinh.Properties.DisplayMember = "name_vn";
                cbotinh.Properties.ValueMember = "id";
                //Huyen
                cbohuyen.Properties.DataSource = DAL.LoadDuLieuDanhMuc.Load_DMHuyen();
                cbohuyen.Properties.DisplayMember = "name_vn";
                cbohuyen.Properties.ValueMember = "id";
                //Xa
                cboxa.Properties.DataSource = DAL.LoadDuLieuDanhMuc.Load_DMXa();
                cboxa.Properties.DisplayMember = "name_vn";
                cboxa.Properties.ValueMember = "id";
                //Nghe nghiep
                cbonghenghiep.Properties.DataSource = DAL.LoadDuLieuDanhMuc.Load_DMNgheNghiep();
                cbonghenghiep.Properties.DisplayMember = "name_vn";
                cbonghenghiep.Properties.ValueMember = "id";
                //Chuyen nganh
                cbochuyennganh.Properties.DataSource = DAL.LoadDuLieuDanhMuc.Load_DMChuyenNganh();
                cbochuyennganh.Properties.DisplayMember = "name_vn";
                cbochuyennganh.Properties.ValueMember = "id";
                //Bang cap
                cbobangcap.Properties.DataSource = DAL.LoadDuLieuDanhMuc.Load_DMBangCap();
                cbobangcap.Properties.DisplayMember = "name_vn";
                cbobangcap.Properties.ValueMember = "id";
                //trang thai
                cbotrangthai.Properties.DataSource = DAL.LoadDuLieuDanhMuc.Load_DMOtherList("STUDENT_TRANGTHAI");
                cbotrangthai.Properties.DisplayMember = "otherlistname";
                cbotrangthai.Properties.ValueMember = "id";
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadDuLieuMacDinh_GiaDinh()
        {
            try
            {
                //Tinh
                cboGD_tinh.Properties.DataSource = DAL.LoadDuLieuDanhMuc.Load_DMTinh();
                cboGD_tinh.Properties.DisplayMember = "name_vn";
                cboGD_tinh.Properties.ValueMember = "id";
                //Huyen
                cboGD_huyen.Properties.DataSource = DAL.LoadDuLieuDanhMuc.Load_DMHuyen();
                cboGD_huyen.Properties.DisplayMember = "name_vn";
                cboGD_huyen.Properties.ValueMember = "id";
                //Xa
                cboGD_xa.Properties.DataSource = DAL.LoadDuLieuDanhMuc.Load_DMXa();
                cboGD_xa.Properties.DisplayMember = "name_vn";
                cboGD_xa.Properties.ValueMember = "id";
                //Nghe nghiep
                cboGD_nghenghiep.Properties.DataSource = DAL.LoadDuLieuDanhMuc.Load_DMNgheNghiep();
                cboGD_nghenghiep.Properties.DisplayMember = "name_vn";
                cboGD_nghenghiep.Properties.ValueMember = "id";
                //moi quan he
                cbotrangthai.Properties.DataSource = DAL.LoadDuLieuDanhMuc.Load_DMOtherList("STUDENT_QUANHE");
                cbotrangthai.Properties.DisplayMember = "otherlistname";
                cbotrangthai.Properties.ValueMember = "id";
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadDuLieuMacDinh_QuaTrinhHT()
        {
            try
            {
                //Gioi tinh
                cbogioitinh.Properties.DataSource = DAL.LoadDuLieuDanhMuc.Load_DMOtherList("GIOITINH");
                cbogioitinh.Properties.DisplayMember = "otherlistname";
                cbogioitinh.Properties.ValueMember = "id";
                //Dan toc
                cbodantoc.Properties.DataSource = DAL.LoadDuLieuDanhMuc.Load_DMDanToc();
                cbodantoc.Properties.DisplayMember = "name_vn";
                cbodantoc.Properties.ValueMember = "id";
                //Tinh
                cbotinh.Properties.DataSource = DAL.LoadDuLieuDanhMuc.Load_DMTinh();
                cbotinh.Properties.DisplayMember = "name_vn";
                cbotinh.Properties.ValueMember = "id";
                //Huyen
                cbohuyen.Properties.DataSource = DAL.LoadDuLieuDanhMuc.Load_DMHuyen();
                cbohuyen.Properties.DisplayMember = "name_vn";
                cbohuyen.Properties.ValueMember = "id";
                //Xa
                cboxa.Properties.DataSource = DAL.LoadDuLieuDanhMuc.Load_DMXa();
                cboxa.Properties.DisplayMember = "name_vn";
                cboxa.Properties.ValueMember = "id";
                //Nghe nghiep
                cbonghenghiep.Properties.DataSource = DAL.LoadDuLieuDanhMuc.Load_DMNgheNghiep();
                cbonghenghiep.Properties.DisplayMember = "name_vn";
                cbonghenghiep.Properties.ValueMember = "id";
                //Chuyen nganh
                cbochuyennganh.Properties.DataSource = DAL.LoadDuLieuDanhMuc.Load_DMChuyenNganh();
                cbochuyennganh.Properties.DisplayMember = "name_vn";
                cbochuyennganh.Properties.ValueMember = "id";
                //Bang cap
                cbobangcap.Properties.DataSource = DAL.LoadDuLieuDanhMuc.Load_DMBangCap();
                cbobangcap.Properties.DisplayMember = "name_vn";
                cbobangcap.Properties.ValueMember = "id";
                //trang thai
                cbotrangthai.Properties.DataSource = DAL.LoadDuLieuDanhMuc.Load_DMOtherList("STUDENT_TRANGTHAI");
                cbotrangthai.Properties.DisplayMember = "otherlistname";
                cbotrangthai.Properties.ValueMember = "id";
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void LoadThongTinHocVien()
        {
            try
            {
                if (this.hocvienId != 0)
                {
                    using (var db = new DAL.O2S_STUDENTMANAGEMENTEntities())
                    {
                        SM_STUDENT _student = db.SM_STUDENT.Where(o => o.id == this.hocvienId).FirstOrDefault();
                        if (_student == null)
                        {
                            txtstudentcode.Text = _student.studentcode;
                            txtfirst_name.Text = _student.first_name;
                            txtlast_name.Text = _student.last_name;
                            cbogioitinh.EditValue = _student.gioitinh_id;
                            if (_student.ngaysinh != null)
                            {
                                dtngaysinh.DateTime = _student.ngaysinh ?? DateTime.MinValue;
                            }
                            cbodantoc.EditValue = _student.dantoc_id;
                            cbotinh.EditValue = _student.tinh_id;
                            cbohuyen.EditValue = _student.huyen_id;
                            cboxa.EditValue = _student.xa_id;
                            txtthonxom.Text = _student.thonxom;
                            txtcmtnd.Text = _student.cmtnd;
                            txtsodienthoai.Text = _student.sodienthoai;
                            txtemail.Text = _student.email;
                            cbonghenghiep.EditValue = _student.nghenghiep_id;
                            cbochuyennganh.EditValue = _student.chuyennganh_id;
                            cbobangcap.EditValue = _student.bangcap_id;
                            if (_student.ngayvao != null)
                            {
                                dtngayvao.DateTime = _student.ngayvao ?? DateTime.MinValue;
                            }
                            cbotrangthai.EditValue = _student.trangthai_id;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }


        #endregion

    }
}
