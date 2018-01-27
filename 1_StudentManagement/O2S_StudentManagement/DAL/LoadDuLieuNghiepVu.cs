using O2S_StudentManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_StudentManagement.DAL
{
    public static class LoadDuLieuNghiepVu
    {
        public static DAL.SM_STUDENT Student(long _studentId)
        {
            DAL.SM_STUDENT result = new SM_STUDENT();
            try
            {
                using (var db = new DAL.O2S_STUDENTMANAGEMENTEntities())
                {
                    result = db.SM_STUDENT.Where(o => o.id == _studentId).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
            return result;
        }
        public static List<DTO.SM_STUDENT_Plus> ListStudents(DateTime _ngayvaoTu, DateTime _ngayvaoDen)
        {
            List<DTO.SM_STUDENT_Plus> result = new List<DTO.SM_STUDENT_Plus>();
            try
            {
                using (var db = new DAL.O2S_STUDENTMANAGEMENTEntities())
                {
                  var  _result = from st in db.SM_STUDENT
                             where st.isremoveid == 0 && st.ngayvao >= _ngayvaoTu && st.ngayvao <= _ngayvaoDen
                             select new DTO.SM_STUDENT_Plus
                             {
                                 id=st.id
                                 //todo
                             };
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
                                  where ot.othertypelistcode == _othertypelistcode
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
