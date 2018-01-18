using AutoMapper;
using O2S_StudentManagement.DAL;
using O2S_StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_StudentManagement.BUS
{
    public class LoadDataSystems
    {
        static O2S_StudentManagement.DAL.ConnectDatabase condb = new O2S_StudentManagement.DAL.ConnectDatabase();

        #region Load Data Phan Mem
        //public static void LoadCauHinhWebService()
        //{
        //    try
        //    {
        //        string sql_getdulieu = "SELECT urlfullserver FROM SM_VERSION WHERE app_type=0;";
        //        DataTable dt_CauHinh = condb.GetDataTable(sql_getdulieu);
        //        if (dt_CauHinh != null && dt_CauHinh.Rows.Count > 0)
        //        {
        //            Base.SessionLogin.UrlFullServer = dt_CauHinh.Rows[0]["urlfullserver"].ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.Logging.LogSystem.Warn(ex);
        //    }
        //}
        internal static void LoadDataOption()
        {
            try
            {
                using (var db = new O2S_STUDENTMANAGEMENTEntities())
                {
                    List<SM_OPTION> lstOption = db.SM_OPTION.Where(o => o.optionlook == 0).ToList();
                    if (lstOption != null && lstOption.Count > 0)
                    {
                        foreach (var item_Op in lstOption)
                        {
                            Mapper.Initialize(cfg => cfg.CreateMap<SM_OPTION, OptionDTO>());
                            OptionDTO _option = AutoMapper.Mapper.Map<SM_OPTION, OptionDTO>(item_Op);
                            GlobalStore.lstOption.Add(_option);
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
