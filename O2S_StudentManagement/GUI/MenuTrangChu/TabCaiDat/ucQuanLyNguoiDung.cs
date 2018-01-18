using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;
using System.Configuration;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Menu;
using O2S_StudentManagement.Base;
using O2S_StudentManagement.Model.Models;

namespace O2S_StudentManagement.GUI.MenuTrangChu
{
    public partial class ucQuanLyNguoiDung : UserControl
    {
        private O2S_StudentManagement.DAL.ConnectDatabase condb = new O2S_StudentManagement.DAL.ConnectDatabase();
        private string currentUserCode;
        private List<classPermission> lstPer { get; set; }
        private List<classUserDepartment> lstUserDepartment { get; set; }
        private List<classPermission> lstPerBaoCao { get; set; }

        public ucQuanLyNguoiDung()
        {
            InitializeComponent();
        }

        #region Load
        private void ucQuanLyNguoiDung_Load(object sender, EventArgs e)
        {
            try
            {
                currentUserCode = null;
                EnableAndDisableControl(false);
                LoadDanhSachNguoiDung();
                LoadDanhSachChucNang();
                //LoadDanhSachKhoaPhong();
                LoadDanhSachBaoCao();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadDanhSachNguoiDung()
        {
            try
            {
                string sql = "select usercode, username, userpassword, case usergnhom when '0' then 'Admin' when '1' then 'Quản trị hệ thống' when 2 then 'Nhân viên' end as usergnhom from SM_TBLUSER where usergnhom in (1,2) order by usercode";
                DataView dv = new DataView(condb.GetDataTable(sql));

                if (dv.Count > 0)
                {
                    //Giải mã hiển thị lên Gridview
                    for (int i = 0; i < dv.Count; i++)
                    {
                        string usercode_de = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(dv[i]["usercode"].ToString(), true);
                        string username_de = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(dv[i]["username"].ToString(), true);
                        dv[i]["usercode"] = usercode_de;
                        dv[i]["username"] = username_de;
                    }
                    gridControlDSUser.DataSource = dv;
                }
                else
                {
                    O2S_StudentManagement.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_StudentManagement.Utilities.ThongBao.frmThongBao(O2S_StudentManagement.Base.ThongBaoLable.KHONG_CO_DU_LIEU);
                    frmthongbao.Show();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadDanhSachChucNang()
        {
            try
            {
                lstPer = new List<classPermission>();
                lstPer = O2S_StudentManagement.Base.listChucNang.getDanhSachChucNang().Where(o => o.permissiontype != 10).ToList();
                gridControlChucNang.DataSource = lstPer;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        //private void LoadDanhSachKhoaPhong()
        //{
        //    try
        //    {
        //        string sql = "SELECT degp.departmentgroupid, degp.departmentgroupname, de.departmentid, de.departmentcode, de.departmentname, de.departmenttype, (case de.departmenttype when 2 then 'Phòng khám' when 3 then 'Buồng điều trị' when 6 then 'Phòng xét nghiệm' when 7 then 'Phòng CĐHA' when 9 then 'BĐT ngoại trú' else '' end) as departmenttypename FROM department de inner join departmentgroup degp on de.departmentgroupid=degp.departmentgroupid WHERE degp.departmentgrouptype in (1,4,10,11) and de.departmenttype in (2,3,7,9) ORDER BY degp.departmentgroupid,de.departmenttype, de.departmentname; ";
        //        DataView dataPhong = new DataView(condb.GetDataTable(sql));
        //        lstUserDepartment = new List<classUserDepartment>();
        //        for (int i = 0; i < dataPhong.Count; i++)
        //        {
        //            classUserDepartment userDepartment = new classUserDepartment();
        //            userDepartment.departmentcheck = false;
        //            userDepartment.departmentgroupid = Common.TypeConvert.TypeConvertParse.ToInt32(dataPhong[i]["departmentgroupid"].ToString());
        //            userDepartment.departmentgroupname = dataPhong[i]["departmentgroupname"].ToString();
        //            userDepartment.departmentid = Common.TypeConvert.TypeConvertParse.ToInt32(dataPhong[i]["departmentid"].ToString());
        //            userDepartment.departmentcode = dataPhong[i]["departmentcode"].ToString();
        //            userDepartment.departmentname = dataPhong[i]["departmentname"].ToString();
        //            userDepartment.departmenttype = Common.TypeConvert.TypeConvertParse.ToInt32(dataPhong[i]["departmenttype"].ToString());
        //            userDepartment.departmenttypename = dataPhong[i]["departmenttypename"].ToString();
        //            lstUserDepartment.Add(userDepartment);
        //        }
        //        gridControlKhoaPhong.DataSource = lstUserDepartment;
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.Logging.LogSystem.Warn(ex);
        //    }
        //}
        private void LoadDanhSachBaoCao()
        {
            try
            {
                lstPerBaoCao = new List<classPermission>();
                lstPerBaoCao = O2S_StudentManagement.Base.listChucNang.getDanhSachChucNang().Where(o => o.permissiontype == 10).ToList();
                gridControlBaoCao.DataSource = lstPerBaoCao;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        #region Grid Click
        private void gridControlDSUser_Click(object sender, EventArgs e)
        {
            var rowHandle = gridViewDSUser.FocusedRowHandle;
            try
            {
                EnableAndDisableControl(true);
                txtUserID.ReadOnly = true;
                currentUserCode = gridViewDSUser.GetRowCellValue(rowHandle, "usercode").ToString();
                txtUserID.Text = currentUserCode;
                txtUsername.Text = gridViewDSUser.GetRowCellValue(rowHandle, "username").ToString(); ;
                txtUserPassword.Text = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(gridViewDSUser.GetRowCellValue(rowHandle, "userpassword").ToString(), true);
                cbbUserNhom.Text = gridViewDSUser.GetRowCellValue(rowHandle, "usergnhom").ToString();

                gridControlChucNang.DataSource = null;
                gridControlKhoaPhong.DataSource = null;
                gridControlBaoCao.DataSource = null;

                LoadDanhSachChucNang();
                //LoadDanhSachKhoaPhong();
                LoadDanhSachBaoCao();

                LoadPhanQuyenChucNang();
                //LoadPhanQuyenKhoaPhong();
                LoadPhanQuyenBaoCao();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void EnableAndDisableControl(bool value)
        {
            try
            {
                btnUserOK.Enabled = value;
                txtUserID.Enabled = value;
                txtUsername.Enabled = value;
                txtUserPassword.Enabled = value;
                cbbUserNhom.Enabled = value;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadPhanQuyenChucNang()
        {
            try
            {
                gridControlChucNang.DataSource = null;
                string sqlquerry_per = "SELECT permissioncode, permissionname, permissioncheck FROM SM_TBLUSER_PERMISSION WHERE usercode='" + Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(currentUserCode, true).ToString() + "';";
                DataView dv = new DataView(condb.GetDataTable(sqlquerry_per));
                //Load dữ liệu list phân quyền + tích quyền của use đang chọn lấy trong DB
                if (dv != null && dv.Count > 0)
                {
                    for (int i = 0; i < lstPer.Count; i++)
                    {
                        for (int j = 0; j < dv.Count; j++)
                        {
                            if (lstPer[i].permissioncode.ToString() == Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(dv[j]["permissioncode"].ToString(), true))
                            {
                                lstPer[i].permissioncheck = Convert.ToBoolean(dv[j]["permissioncheck"]);
                            }
                        }
                    }
                }
                gridControlChucNang.DataSource = lstPer;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        //private void LoadPhanQuyenKhoaPhong()
        //{
        //    try
        //    {
        //        gridControlKhoaPhong.DataSource = null;
        //        string sqlquerry_khoaphong = "SELECT userdepgid,departmentgroupid,departmentid,departmenttype,usercode FROM SM_TBLUSER_departmentgroup WHERE usercode='" + Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(currentUserCode, true).ToString() + "';";
        //        DataView dv_khoaphong = new DataView(condb.GetDataTable(sqlquerry_khoaphong));
        //        if (dv_khoaphong != null && dv_khoaphong.Count > 0)
        //        {
        //            for (int i = 0; i < lstUserDepartment.Count; i++)
        //            {
        //                for (int j = 0; j < dv_khoaphong.Count; j++)
        //                {
        //                    if (lstUserDepartment[i].departmentid.ToString() == dv_khoaphong[j]["departmentid"].ToString())
        //                    {
        //                        lstUserDepartment[i].departmentcheck = true;
        //                    }
        //                }
        //            }
        //        }
        //        gridControlKhoaPhong.DataSource = lstUserDepartment;
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.Logging.LogSystem.Warn(ex);
        //    }
        //}
        private void LoadPhanQuyenBaoCao()
        {
            try
            {
                gridControlBaoCao.DataSource = null;
                string sqlquerry_per = "SELECT permissioncode, permissionname, permissioncheck FROM SM_TBLUSER_PERMISSION WHERE usercode='" + Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(currentUserCode, true).ToString() + "' and ghichu='BAOCAO';";
                DataView dv = new DataView(condb.GetDataTable(sqlquerry_per));
                //Load dữ liệu list phân quyền + tích quyền của use đang chọn lấy trong DB
                if (dv != null && dv.Count > 0)
                {
                    for (int i = 0; i < lstPerBaoCao.Count; i++)
                    {
                        for (int j = 0; j < dv.Count; j++)
                        {
                            if (lstPerBaoCao[i].permissioncode.ToString() == Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(dv[j]["permissioncode"].ToString(), true))
                            {
                                lstPerBaoCao[i].permissioncheck = Convert.ToBoolean(dv[j]["permissioncheck"]);
                            }
                        }
                    }
                }
                gridControlBaoCao.DataSource = lstPerBaoCao;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion

        #region Tạo sự kiện khi kích OK
        private void btnUserOK_Click(object sender, EventArgs e)
        {
            // Mã hóa tài khoản
            string en_txtUserID = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(txtUserID.Text.Trim().ToLower(), true);
            string en_txtUsername = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(txtUsername.Text.Trim(), true);
            string en_txtUserPassword = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(txtUserPassword.Text.Trim(), true);
            try
            {
                if (currentUserCode == null)//them moi
                {
                    CreateNewUser(en_txtUserID, en_txtUsername, en_txtUserPassword);
                    CreateNewUserPermission(en_txtUserID);
                    //CreateNewUserDepartment(en_txtUserID);
                    CreateNewUserBaoCao(en_txtUserID);
                    O2S_StudentManagement.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_StudentManagement.Utilities.ThongBao.frmThongBao(O2S_StudentManagement.Base.ThongBaoLable.THEM_MOI_THANH_CONG);
                    frmthongbao.Show();
                    //LoadDanhSachNguoiDung();
                    ucQuanLyNguoiDung_Load(null, null);
                }
                else //Update 
                {
                    UpdateUser(en_txtUserID, en_txtUsername, en_txtUserPassword);
                    UpdateUserPermission(en_txtUserID);
                    //UpdateUserDepartment(en_txtUserID);
                    UpdateUserBaoCao(en_txtUserID);
                    O2S_StudentManagement.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_StudentManagement.Utilities.ThongBao.frmThongBao(O2S_StudentManagement.Base.ThongBaoLable.CAP_NHAT_THANH_CONG);
                    frmthongbao.Show();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void CreateNewUser(string en_txtUserID, string en_txtUsername, string en_txtUserPassword)
        {
            try
            {
                string sqlinsert_user = "";
                // usergnhom=1: Quan tri he thong
                // usergnhom=2: User
                if (cbbUserNhom.Text == "Quản trị hệ thống")
                {
                    sqlinsert_user = "INSERT INTO SM_TBLUSER(usercode, username, userpassword, userstatus, usergnhom, usernote) VALUES ('" + en_txtUserID + "','" + en_txtUsername + "','" + en_txtUserPassword + "','0','1','');";
                }
                else
                {
                    sqlinsert_user = "INSERT INTO SM_TBLUSER(usercode, username, userpassword, userstatus, usergnhom, usernote) VALUES ('" + en_txtUserID + "','" + en_txtUsername + "','" + en_txtUserPassword + "','0','2','Nhân viên');";
                }
                condb.ExecuteNonQuery(sqlinsert_user);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void CreateNewUserPermission(string en_txtUserID)
        {
            try
            {
                string sqlinsert_per = "";
                for (int i = 0; i < lstPer.Count; i++)
                {
                    sqlinsert_per = "";
                    string en_permissioncode = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(lstPer[i].permissioncode.ToString(), true);
                    string en_permissionname = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(lstPer[i].permissionname.ToString(), true);
                    if (lstPer[i].permissioncheck == true)
                    {
                        sqlinsert_per = "INSERT INTO SM_TBLUSER_PERMISSION(permissioncode, permissionname, usercode, permissioncheck, ghichu) VALUES ('" + en_permissioncode + "', '" + en_permissionname + "', '" + en_txtUserID + "', '1', '');";
                        condb.ExecuteNonQuery(sqlinsert_per);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        //private void CreateNewUserDepartment(string en_txtUserID)
        //{
        //    try
        //    {
        //        string sqlinsert_userdepartment = "";
        //        for (int i = 0; i < lstUserDepartment.Count; i++)
        //        {
        //            sqlinsert_userdepartment = "";
        //            if (lstUserDepartment[i].departmentcheck == true)
        //            {
        //                sqlinsert_userdepartment = "INSERT INTO SM_TBLUSER_departmentgroup(departmentgroupid, departmentid, departmenttype, usercode, userdepgidnote) VALUES ('" + lstUserDepartment[i].departmentgroupid + "','" + lstUserDepartment[i].departmentid + "','" + lstUserDepartment[i].departmenttype + "','" + en_txtUserID + "','');";
        //                condb.ExecuteNonQuery(sqlinsert_userdepartment);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.Logging.LogSystem.Error(ex);
        //    }
        //}
        private void CreateNewUserBaoCao(string en_txtUserID)
        {
            try
            {
                string sqlinsert_per = "";
                for (int i = 0; i < lstPerBaoCao.Count; i++)
                {
                    sqlinsert_per = "";
                    string en_permissioncode = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(lstPerBaoCao[i].permissioncode.ToString(), true);
                    string en_permissionname = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(lstPerBaoCao[i].permissionname.ToString(), true);
                    if (lstPerBaoCao[i].permissioncheck == true)
                    {
                        sqlinsert_per = "INSERT INTO SM_TBLUSER_PERMISSION(permissioncode, permissionname, usercode, permissioncheck, ghichu) VALUES ('" + en_permissioncode + "', '" + en_permissionname + "', '" + en_txtUserID + "', '1', 'BAOCAO');";
                        condb.ExecuteNonQuery(sqlinsert_per);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void UpdateUser(string en_txtUserID, string en_txtUsername, string en_txtUserPassword)
        {
            try
            {
                string sqlupdate_user = "";
                if (cbbUserNhom.Text == "Quản trị hệ thống")
                {
                    sqlupdate_user = "UPDATE SM_TBLUSER SET usercode='" + en_txtUserID + "', username='" + en_txtUsername + "', userpassword='" + en_txtUserPassword + "', userstatus='0', usergnhom='1', usernote='' WHERE usercode='" + en_txtUserID + "';";
                }
                else
                {
                    sqlupdate_user = "UPDATE SM_TBLUSER SET usercode='" + en_txtUserID + "', username='" + en_txtUsername + "', userpassword='" + en_txtUserPassword + "', userstatus='0', usergnhom='2', usernote='Nhân viên' WHERE usercode='" + en_txtUserID + "';";
                }
                condb.ExecuteNonQuery(sqlupdate_user);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void UpdateUserPermission(string en_txtUserID)
        {
            try
            {
                string sqlupdate_per = "";
                for (int i = 0; i < lstPer.Count; i++)
                {
                    sqlupdate_per = "";
                    string en_permissioncode = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(lstPer[i].permissioncode, true);
                    string sqlkiemtratontai = "SELECT * FROM SM_TBLUSER_PERMISSION WHERE usercode='" + en_txtUserID + "' and permissioncode='" + en_permissioncode + "' ;";
                    DataView dvkt = new DataView(condb.GetDataTable(sqlkiemtratontai));
                    if (dvkt.Count > 0) //Nếu có quyền đó rồi thì Update
                    {
                        if (lstPer[i].permissioncheck == false)
                        {
                            sqlupdate_per = "DELETE FROM SM_TBLUSER_PERMISSION WHERE usercode='" + en_txtUserID + "' and permissioncode='" + en_permissioncode + "' ;";
                            condb.ExecuteNonQuery(sqlupdate_per);
                        }
                    }
                    else //nếu không có quyền đó thì Insert
                    {
                        if (lstPer[i].permissioncheck == true)
                        {
                            string en_permissionname = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(lstPer[i].permissionname.ToString(), true);
                            sqlupdate_per = "INSERT INTO SM_TBLUSER_PERMISSION(permissioncode, permissionname, usercode, permissioncheck, ghichu) VALUES ('" + en_permissioncode + "', '" + en_permissionname + "', '" + en_txtUserID + "', '1', '');";
                            condb.ExecuteNonQuery(sqlupdate_per);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        //private void UpdateUserDepartment(string en_txtUserID)
        //{
        //    try
        //    {
        //        string sqlupdate_userdepartment = "";
        //        for (int i = 0; i < lstUserDepartment.Count; i++)
        //        {
        //            sqlupdate_userdepartment = "";
        //            string sqlkiemtratontai = "SELECT * FROM SM_TBLUSER_departmentgroup WHERE usercode='" + en_txtUserID + "' and departmentid='" + lstUserDepartment[i].departmentid + "' ;";
        //            DataView dvkt = new DataView(condb.GetDataTable(sqlkiemtratontai));
        //            if (dvkt.Count > 0) //Nếu có quyền đó rồi thì Update
        //            {
        //                if (lstUserDepartment[i].departmentcheck == false) //xoa
        //                {
        //                    sqlupdate_userdepartment = "DELETE FROM SM_TBLUSER_departmentgroup WHERE usercode='" + en_txtUserID + "' and departmentid='" + lstUserDepartment[i].departmentid + "' ;";
        //                    condb.ExecuteNonQuery(sqlupdate_userdepartment);
        //                }
        //            }
        //            else //nếu không có quyền đó thì Insert
        //            {
        //                if (lstUserDepartment[i].departmentcheck == true)
        //                {
        //                    sqlupdate_userdepartment = "INSERT INTO SM_TBLUSER_departmentgroup(departmentgroupid, departmentid, departmenttype, usercode, userdepgidnote) VALUES ('" + lstUserDepartment[i].departmentgroupid + "','" + lstUserDepartment[i].departmentid + "','" + lstUserDepartment[i].departmenttype + "','" + en_txtUserID + "','');";
        //                    condb.ExecuteNonQuery(sqlupdate_userdepartment);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.Logging.LogSystem.Error(ex);
        //    }
        //}
        private void UpdateUserBaoCao(string en_txtUserID)
        {
            try
            {
                string sqlupdate_per = "";
                for (int i = 0; i < lstPerBaoCao.Count; i++)
                {
                    sqlupdate_per = "";
                    string en_permissioncode = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(lstPerBaoCao[i].permissioncode, true);
                    string sqlkiemtratontai = "SELECT * FROM SM_TBLUSER_PERMISSION WHERE usercode='" + en_txtUserID + "' and permissioncode='" + en_permissioncode + "' ;";
                    DataView dvkt = new DataView(condb.GetDataTable(sqlkiemtratontai));
                    if (dvkt.Count > 0) //Nếu có quyền đó rồi thì Update
                    {
                        if (lstPerBaoCao[i].permissioncheck == false)
                        {
                            sqlupdate_per = "DELETE FROM SM_TBLUSER_PERMISSION WHERE usercode='" + en_txtUserID + "' and permissioncode='" + en_permissioncode + "' ;";
                            condb.ExecuteNonQuery(sqlupdate_per);
                        }
                    }
                    else //nếu không có quyền đó thì Insert
                    {
                        if (lstPerBaoCao[i].permissioncheck == true)
                        {
                            string en_permissionname = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(lstPerBaoCao[i].permissionname.ToString(), true);
                            sqlupdate_per = "INSERT INTO SM_TBLUSER_PERMISSION(permissioncode, permissionname, usercode, permissioncheck, ghichu) VALUES ('" + en_permissioncode + "', '" + en_permissionname + "', '" + en_txtUserID + "', '1', 'BAOCAO');";
                            condb.ExecuteNonQuery(sqlupdate_per);
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

        #region Custome
        private void txtUserID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUsername.Focus();
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUserPassword.Focus();
            }
        }

        private void txtUserPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnUserOK.PerformClick();
        }

        #endregion

        #region Events
        private void btnUserThem_Click(object sender, EventArgs e)
        {
            currentUserCode = null;

            txtUserID.ResetText();
            txtUsername.ResetText();
            txtUserPassword.ResetText();
            EnableAndDisableControl(true);
            cbbUserNhom.Text = "Nhân viên";
            txtUserID.ReadOnly = false;
            txtUserID.Focus();
            btnUserOK.Enabled = true;

            gridControlChucNang.DataSource = null;
            gridControlKhoaPhong.DataSource = null;
            gridControlBaoCao.DataSource = null;
            //gridControlKhoThuoc.DataSource = null;
            //gridControlPhongLuu.DataSource = null;

            LoadDanhSachChucNang();
            //LoadDanhSachKhoaPhong();
            LoadDanhSachBaoCao();
        }

        private void gridViewDSUser_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Row)
            {
                e.Menu.Items.Clear();
                DXMenuItem itemXoaNguoiDung = new DXMenuItem("Xóa tài khoản");
                itemXoaNguoiDung.Image = imMenu.Images["Xoa.png"];
                itemXoaNguoiDung.Click += new EventHandler(itemXoaNguoiDung_Click);
                e.Menu.Items.Add(itemXoaNguoiDung);
            }
        }

        void itemXoaNguoiDung_Click(object sender, EventArgs e)
        {
            if (currentUserCode == null)
            {
                return;
            }
            String datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản: " + currentUserCode + " không?", "Thông báo !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    string sqlxoatk = "DELETE FROM SM_TBLUSER WHERE usercode='" + Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(currentUserCode.ToString(), true) + "';";
                    string sqlxoatk_chucnang = "DELETE FROM SM_TBLUSER_PERMISSION WHERE usercode='" + Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(currentUserCode.ToString(), true) + "';";
                    string sqlxoatk_khoaphong = "DELETE FROM SM_TBLUSER_departmentgroup WHERE usercode='" + Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(currentUserCode.ToString(), true) + "';";
                    string sqlxoatk_khothuoc = "DELETE FROM SM_TBLUSER_medicinestore WHERE usercode='" + Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(currentUserCode.ToString(), true) + "';";
                    string sqlxoatk_phongluu = "DELETE FROM SM_TBLUSER_medicinephongluu WHERE usercode='" + Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(currentUserCode.ToString(), true) + "';";
                    string sqlinsert_log = "INSERT INTO SM_TBLLOG(loguser, logvalue, ipaddress, computername, softversion, logtime, logtype) VALUES ('" + SessionLogin.SessionUsercode + "', 'Xóa tài khoản: " + currentUserCode + "','" + SessionLogin.SessionMyIP + "', '" + SessionLogin.SessionMachineName + "', '" + SessionLogin.SessionVersion + "', '" + datetime + "', '5');";

                    condb.ExecuteNonQuery(sqlxoatk);
                    condb.ExecuteNonQuery(sqlxoatk_chucnang);
                    condb.ExecuteNonQuery(sqlxoatk_khoaphong);
                    condb.ExecuteNonQuery(sqlxoatk_khothuoc);
                    condb.ExecuteNonQuery(sqlxoatk_phongluu);
                    condb.ExecuteNonQuery(sqlinsert_log);

                    O2S_StudentManagement.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_StudentManagement.Utilities.ThongBao.frmThongBao("Đã xóa bỏ tài khoản: " + currentUserCode);
                    frmthongbao.Show();
                    gridControlDSUser.DataSource = null;
                    ucQuanLyNguoiDung_Load(null, null);
                }
                catch (Exception ex)
                {
                    Common.Logging.LogSystem.Error(ex);
                }
            }
        }

        #endregion

        #region GridView Design
        private void gridViewChucNang_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.LightGreen;
                e.Appearance.ForeColor = Color.Black;
            }
        }
        private void gridViewDSUser_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.LightGreen;
                e.Appearance.ForeColor = Color.Black;
            }
        }
        private void gridViewBaoCao_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.LightGreen;
                e.Appearance.ForeColor = Color.Black;
            }
        }
        private void gridViewKhoThuoc_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.LightGreen;
                e.Appearance.ForeColor = Color.Black;
            }
        }
        private void gridViewChucNang_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
        private void gridViewDSUser_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
        private void gridViewBaoCao_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
        private void gridViewKhoThuoc_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
        private void gridViewPhongLuu_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        #endregion










    }
}
