using O2S_QuanLyHocVien.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.Utilities.Prints
{
    public static class PrintPreview
    {
        #region Them thong tin
        private static List<O2S_Common.DataObjects.reportExcelDTO> ThemThongTin()
        {
            List<O2S_Common.DataObjects.reportExcelDTO> result = new List<O2S_Common.DataObjects.reportExcelDTO>();
            try
            {
                O2S_Common.DataObjects.reportExcelDTO _CURRENTUSER = new O2S_Common.DataObjects.reportExcelDTO()
                {
                    name = "CURRENTUSER",
                    value = GlobalSettings.UserName,
                };

                O2S_Common.DataObjects.reportExcelDTO _TENTRUNGTAM = new O2S_Common.DataObjects.reportExcelDTO()
                {
                    name = "TENTRUNGTAM",
                    value = GlobalSettings.CoSo_Ten,
                };
                O2S_Common.DataObjects.reportExcelDTO _DIACHITRUNGTAM = new O2S_Common.DataObjects.reportExcelDTO()
                {
                    name = "DIACHITRUNGTAM",
                    value = GlobalSettings.TrungTam_DiaChi,
                };
                O2S_Common.DataObjects.reportExcelDTO _TENCOSO = new O2S_Common.DataObjects.reportExcelDTO()
                {
                    name = "TENCOSO",
                    value = GlobalSettings.CoSo_Ten,
                };
                O2S_Common.DataObjects.reportExcelDTO _DIACHICOSO = new O2S_Common.DataObjects.reportExcelDTO()
                {
                    name = "DIACHICOSO",
                    value = GlobalSettings.CoSo_DiaChi,
                };
                O2S_Common.DataObjects.reportExcelDTO _SDTCOSO = new O2S_Common.DataObjects.reportExcelDTO()
                {
                    name = "SDTCOSO",
                    value = GlobalSettings.CoSo_Sdt,
                };



                result.Add(_CURRENTUSER);
                result.Add(_TENTRUNGTAM);
                result.Add(_DIACHITRUNGTAM);
                result.Add(_TENCOSO);
                result.Add(_DIACHICOSO);
                result.Add(_SDTCOSO);

            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        #endregion

        public static void ShowPrintPreview_UsingExcelTemplate(string fileNameTemplate, List<O2S_Common.DataObjects.reportExcelDTO> thongTinThem, DataTable dataTable)
        {
            try
            {
                thongTinThem.AddRange(ThemThongTin());//them thong tin

                O2S_Common.PrintPreview.ExcelFileTemplate.ShowPrintPreview_UsingExcelTemplate(fileNameTemplate, thongTinThem, dataTable);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static void ShowPrintPreview_UsingExcelTemplate(string fileNameTemplate, List<O2S_Common.DataObjects.reportExcelDTO> thongTinThem)
        {
            try
            {
                thongTinThem.AddRange(ThemThongTin());//them thong tin

                O2S_Common.PrintPreview.ExcelFileTemplate.ShowPrintPreview_UsingExcelTemplate(fileNameTemplate, thongTinThem);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static void ShowPrintPreview_UsingExcelTemplate(string fileNameTemplate, List<O2S_Common.DataObjects.reportExcelDTO> thongTinThem, List<DataTable> lstDataTable)
        {
            try
            {
                thongTinThem.AddRange(ThemThongTin());//them thong tin

                O2S_Common.PrintPreview.ExcelFileTemplate.ShowPrintPreview_UsingExcelTemplate(fileNameTemplate, thongTinThem, lstDataTable);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
