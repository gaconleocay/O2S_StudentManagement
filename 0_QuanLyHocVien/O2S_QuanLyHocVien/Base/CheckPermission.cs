using O2S_License.PasswordKey;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.Model.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O2S_QuanLyHocVien.Base
{
    public static class CheckPermission
    {
        //static DAL.ConnectDatabase condb = new DAL.ConnectDatabase();
        public static bool ChkPerModule(string percode)
        {
            bool result = false;
            try
            {
                if (GlobalSettings.UserCode == KeyTrongPhanMem.AdminUser_key)
                {
                    result = true;
                }
                else
                {
                    var checkPhanQuyen = GlobalSettings.SessionLstPhanQuyenNguoiDung.Where(s => s.permissioncode.Contains(percode)).ToList();
                    if (checkPhanQuyen != null && checkPhanQuyen.Count > 0)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }
        public static List<classPermission> GetListPhanQuyenNguoiDung()
        {
            List<classPermission> lstPhanQuyen = new List<classPermission>();
            try
            {
                if (GlobalSettings.UserCode == KeyTrongPhanMem.AdminUser_key)
                {
                    lstPhanQuyen = Base.listChucNang.getDanhSachChucNang();
                    foreach (var item in lstPhanQuyen)
                    {
                        item.permissioncheck = true;
                    }
                }
                else
                {
                    //TODO
                    //using (var db = new O2S_QuanLyHocVienEntities())
                    //{
                    //    string en_usercode = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(GlobalSettings.SessionUsercode, true);
                    //    List<SM_TBLUSER_PERMISSION> lstUserPer = db.SM_TBLUSER_PERMISSION.Where(o => o.usercode == en_usercode && o.permissioncheck == true).ToList();
                    //    if (lstUserPer != null && lstUserPer.Count > 0)
                    //    {
                    //        foreach (var item_Per in lstUserPer)
                    //        {
                    //            classPermission itemPer = new classPermission();
                    //            itemPer.permissioncode = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(item_Per.permissioncode, true);
                    //            itemPer.permissionname = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(item_Per.permissionname, true);
                    //            itemPer.en_permissioncode = item_Per.permissioncode;
                    //            itemPer.en_permissionname = item_Per.permissionname;
                    //            itemPer.permissioncheck = item_Per.permissioncheck ?? false;
                    //            lstPhanQuyen.Add(itemPer);
                    //        }
                    //        foreach (var item_chucnang in lstPhanQuyen)
                    //        {
                    //            var chucnang = Base.listChucNang.getDanhSachChucNang().Where(o => o.permissioncode == item_chucnang.permissioncode).SingleOrDefault();
                    //            if (chucnang != null)
                    //            {
                    //                item_chucnang.permissiontype = chucnang.permissiontype;
                    //                item_chucnang.tabMenuId = chucnang.tabMenuId;
                    //                item_chucnang.permissionnote = chucnang.permissionnote;
                    //            }
                    //        }
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return lstPhanQuyen;
        }

    }
}
