using O2S_License.PasswordKey;
using O2S_StudentManagement.Base;
using O2S_StudentManagement.DAL;
using O2S_StudentManagement.Model.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O2S_StudentManagement.Base
{
    public static class CheckPermission
    {
        static DAL.ConnectDatabase condb = new DAL.ConnectDatabase();
        public static bool ChkPerModule(string percode)
        {
            bool result = false;
            try
            {
                if (SessionLogin.SessionUsercode == KeyTrongPhanMem.AdminUser_key)
                {
                    result = true;
                }
                else
                {
                    var checkPhanQuyen = SessionLogin.SessionLstPhanQuyenNguoiDung.Where(s => s.permissioncode.Contains(percode)).ToList();
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
                if (SessionLogin.SessionUsercode == KeyTrongPhanMem.AdminUser_key)
                {
                    lstPhanQuyen = Base.listChucNang.getDanhSachChucNang();
                    foreach (var item in lstPhanQuyen)
                    {
                        item.permissioncheck = true;
                    }
                }
                else
                {
                    using (var db = new O2S_STUDENTMANAGEMENTEntities())
                    {
                        string en_usercode = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(SessionLogin.SessionUsercode, true);
                        List<SM_TBLUSER_PERMISSION> lstUserPer = db.SM_TBLUSER_PERMISSION.Where(o => o.usercode == en_usercode && o.permissioncheck == true).ToList();
                        if (lstUserPer != null && lstUserPer.Count > 0)
                        {
                            foreach (var item_Per in lstUserPer)
                            {
                                classPermission itemPer = new classPermission();
                                itemPer.permissioncode = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(item_Per.permissioncode, true);
                                itemPer.permissionname = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(item_Per.permissionname, true);
                                itemPer.en_permissioncode = item_Per.permissioncode;
                                itemPer.en_permissionname = item_Per.permissionname;
                                itemPer.permissioncheck = item_Per.permissioncheck ?? false;
                                lstPhanQuyen.Add(itemPer);
                            }
                            foreach (var item_chucnang in lstPhanQuyen)
                            {
                                var chucnang = Base.listChucNang.getDanhSachChucNang().Where(o => o.permissioncode == item_chucnang.permissioncode).SingleOrDefault();
                                if (chucnang != null)
                                {
                                    item_chucnang.permissiontype = chucnang.permissiontype;
                                    item_chucnang.tabMenuId = chucnang.tabMenuId;
                                    item_chucnang.permissionnote = chucnang.permissionnote;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return lstPhanQuyen;
        }

        //public static List<DTO.classUserDepartment> GetPhanQuyen_KhoaPhong()
        //{
        //    List<DTO.classUserDepartment> lstPhanQuyenKhoaPhong = new List<DTO.classUserDepartment>();
        //    try
        //    {
        //        DataView dataDepartment = new DataView();
        //        if (SessionLogin.SessionUsercode == Base.KeyTrongPhanMem.AdminUser_key)
        //        {
        //            string sqlper_his = "SELECT degp.departmentgroupid, degp.departmentgroupcode, degp.departmentgroupname, degp.departmentgrouptype, de.departmentid, de.departmentcode, de.departmentname, de.departmenttype FROM department de inner join departmentgroup degp on degp.departmentgroupid=de.departmentgroupid and degp.departmentgrouptype in (1,4,9,10,11) WHERE de.departmenttype in (2,3,6,7,9) ORDER BY degp.departmentgroupname, de.departmentname, de.departmenttype;";
        //            dataDepartment = new DataView(condb.GetDataTable(sqlper_his));
        //        }
        //        else
        //        {
        //            string en_usercode = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(SessionLogin.SessionUsercode, true);
        //            string sqlper_mel = "SELECT ude.departmentgroupid, degp.departmentgroupcode, degp.departmentgroupname, degp.departmentgrouptype, ude.departmentid, de.departmentcode, de.departmentname, ude.departmenttype, ude.usercode FROM SM_TBLUSER_departmentgroup ude inner join dblink('myconn','SELECT departmentid, departmentcode, departmentname, departmenttype FROM department') AS de(departmentid integer, departmentcode text, departmentname text, departmenttype integer) on de.departmentid=ude.departmentid inner join dblink('myconn','SELECT departmentgroupid, departmentgroupcode, departmentgroupname, departmentgrouptype FROM departmentgroup') AS degp(departmentgroupid integer, departmentgroupcode text, departmentgroupname text, departmentgrouptype integer) on degp.departmentgroupid=ude.departmentgroupid WHERE usercode = '" + en_usercode + "' ORDER BY degp.departmentgroupname,de.departmentname,ude.departmenttype;";
        //            dataDepartment = new DataView(condb.GetDataTable_Dblink(sqlper_mel));
        //        }
        //        if (dataDepartment.Count > 0)
        //        {
        //            for (int i = 0; i < dataDepartment.Count; i++)
        //            {
        //                DTO.classUserDepartment itemUdepart = new DTO.classUserDepartment();
        //                itemUdepart.departmentgroupid = Common.TypeConvert.TypeConvertParse.ToInt32(dataDepartment[i]["departmentgroupid"].ToString());
        //                itemUdepart.departmentgroupcode = dataDepartment[i]["departmentgroupcode"].ToString();
        //                itemUdepart.departmentgroupname = dataDepartment[i]["departmentgroupname"].ToString();
        //                itemUdepart.departmentgrouptype = Common.TypeConvert.TypeConvertParse.ToInt32(dataDepartment[i]["departmentgrouptype"].ToString());
        //                itemUdepart.departmentid = Common.TypeConvert.TypeConvertParse.ToInt32(dataDepartment[i]["departmentid"].ToString());
        //                itemUdepart.departmentcode = dataDepartment[i]["departmentcode"].ToString();
        //                itemUdepart.departmentname = dataDepartment[i]["departmentname"].ToString();
        //                itemUdepart.departmenttype = Common.TypeConvert.TypeConvertParse.ToInt32(dataDepartment[i]["departmenttype"].ToString());
        //                lstPhanQuyenKhoaPhong.Add(itemUdepart);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //     Common.Logging.LogSystem.Error(ex);
        //    }
        //    return lstPhanQuyenKhoaPhong;
        //}

    }
}
