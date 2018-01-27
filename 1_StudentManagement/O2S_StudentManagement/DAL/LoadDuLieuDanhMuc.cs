using O2S_StudentManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_StudentManagement.DAL
{
    public static class LoadDuLieuDanhMuc
    {
        public static List<DAL.DM_BANGCAP> Load_DMBangCap()
        {
            List<DAL.DM_BANGCAP> result = new List<DAL.DM_BANGCAP>();
            try
            {
                using (var db = new DAL.O2S_STUDENTMANAGEMENTEntities())
                {
                    result = db.DM_BANGCAP.Where(o => o.isremove == 0).ToList();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
            return result;
        }

        public static List<DAL.DM_CHUYENNGANH> Load_DMChuyenNganh()
        {
            List<DAL.DM_CHUYENNGANH> result = new List<DAL.DM_CHUYENNGANH>();
            try
            {
                using (var db = new DAL.O2S_STUDENTMANAGEMENTEntities())
                {
                    result = db.DM_CHUYENNGANH.Where(o => o.isremove == 0).ToList();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
            return result;
        }

        public static List<DAL.DM_DANTOC> Load_DMDanToc()
        {
            List<DAL.DM_DANTOC> result = new List<DAL.DM_DANTOC>();
            try
            {
                using (var db = new DAL.O2S_STUDENTMANAGEMENTEntities())
                {
                    result = db.DM_DANTOC.Where(o => o.ISREMOVE == 0).ToList();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
            return result;
        }

        public static List<DAL.DM_HUYEN> Load_DMHuyen()
        {
            List<DAL.DM_HUYEN> result = new List<DAL.DM_HUYEN>();
            try
            {
                using (var db = new DAL.O2S_STUDENTMANAGEMENTEntities())
                {
                    result = db.DM_HUYEN.Where(o => o.isremove == 0).ToList();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
            return result;
        }

        public static List<DAL.DM_NGHENGHIEP> Load_DMNgheNghiep()
        {
            List<DAL.DM_NGHENGHIEP> result = new List<DAL.DM_NGHENGHIEP>();
            try
            {
                using (var db = new DAL.O2S_STUDENTMANAGEMENTEntities())
                {
                    result = db.DM_NGHENGHIEP.Where(o => o.isremove == 0).ToList();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
            return result;
        }

        public static List<DAL.DM_QUOCGIA> Load_DMQuocGia()
        {
            List<DAL.DM_QUOCGIA> result = new List<DAL.DM_QUOCGIA>();
            try
            {
                using (var db = new DAL.O2S_STUDENTMANAGEMENTEntities())
                {
                    result = db.DM_QUOCGIA.Where(o => o.isremove == 0).ToList();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
            return result;
        }

        public static List<DAL.DM_TINH> Load_DMTinh()
        {
            List<DAL.DM_TINH> result = new List<DAL.DM_TINH>();
            try
            {
                using (var db = new DAL.O2S_STUDENTMANAGEMENTEntities())
                {
                    result = db.DM_TINH.Where(o => o.isremove == 0).ToList();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
            return result;
        }

        public static List<DAL.DM_XA> Load_DMXa()
        {
            List<DAL.DM_XA> result = new List<DAL.DM_XA>();
            try
            {
                using (var db = new DAL.O2S_STUDENTMANAGEMENTEntities())
                {
                    result = db.DM_XA.Where(o => o.isremove == 0).ToList();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
            return result;
        }

        public static List<DAL.DM_OTHERLIST> Load_DMOtherList(string _othertypelistcode)
        {
            List<DAL.DM_OTHERLIST> result = new List<DAL.DM_OTHERLIST>();
            try
            {
                using (var db = new DAL.O2S_STUDENTMANAGEMENTEntities())
                {
                   var _result = from o in db.DM_OTHERLIST
                             join ot in db.DM_OTHERTYPELIST on o.othertypelist_id equals ot.id
                             where ot.othertypelistcode==_othertypelistcode
                             select o;
                    result = _result.ToList();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
            return result;
        }




    }
}
