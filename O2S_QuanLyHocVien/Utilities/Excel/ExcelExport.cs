using DevExpress.XtraGrid.Views.Grid;
using O2S_Common.DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.Utilities.Excel
{
    public static class ExcelExport
    {
        public static void ExportDataGridViewToFile(DevExpress.XtraGrid.GridControl gridControlData, GridView gridViewData)
        {
            try
            {
                O2S_Common.Excel.ExcelExport.ExportDataGridViewToFile(gridControlData, gridViewData);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        public static void ExportExcelNotTemplate(string _tenBaoCao, DataTable dataTable)
        {
            try
            {
                O2S_Common.Excel.ExcelExport.ExportExcelNotTemplate(_tenBaoCao, dataTable);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        public static void ExportExcelTemplate(string pv_sErr, string fileNameTemplate, List<reportExcelDTO> thongTinThem, DataTable dataTable)
        {
            try
            {
                thongTinThem.AddRange(ThemThongTinTemplate.ThemThongTin());//them thong tin

                O2S_Common.Excel.ExcelExport.ExportExcelTemplate(pv_sErr, fileNameTemplate, thongTinThem, dataTable);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        public static MemoryStream ExportExcelTemplate_ToStream(string pv_sErr, string fileNameTemplate, List<reportExcelDTO> thongTinThem)
        {
            try
            {
                thongTinThem.AddRange(ThemThongTinTemplate.ThemThongTin());//them thong tin

                return O2S_Common.Excel.ExcelExport.ExportExcelTemplate_ToStream(pv_sErr, fileNameTemplate, thongTinThem);
            }
            catch (Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        public static MemoryStream ExportExcelTemplate_ToStream(string pv_sErr, string fileNameTemplate, List<reportExcelDTO> thongTinThem, DataTable dataTable)
        {
            try
            {
                thongTinThem.AddRange(ThemThongTinTemplate.ThemThongTin());//them thong tin

                return O2S_Common.Excel.ExcelExport.ExportExcelTemplate_ToStream(pv_sErr, fileNameTemplate, thongTinThem, dataTable);
            }
            catch (Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        public static MemoryStream ExportExcelTemplate_ToStream(string pv_sErr, string fileNameTemplate, List<reportExcelDTO> thongTinThem, List<DataTable> lstDataTable)
        {
            try
            {
                thongTinThem.AddRange(ThemThongTinTemplate.ThemThongTin());//them thong tin

                return O2S_Common.Excel.ExcelExport.ExportExcelTemplate_ToStream(pv_sErr, fileNameTemplate, thongTinThem, lstDataTable);
            }
            catch (Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }


    }
}
