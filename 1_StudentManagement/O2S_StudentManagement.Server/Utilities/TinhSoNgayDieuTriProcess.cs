using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace O2S_CarParking.Server.Utilities.QuyTacGiamDinhProcess
{
    public static class TinhSoNgayDieuTriProcess
    {
        //public static decimal TinhSoNgayDieuTri(long thoiGianVaoVien, long thoiGianRaVien)
        //{
        //    decimal result = 0;
        //    try
        //    {
        //        System.DateTime timeIn = TimeNumberToSystemDateTime(thoiGianVaoVien).Value;
        //        System.DateTime timeOut = TimeNumberToSystemDateTime(thoiGianRaVien).Value;

        //        System.DateTime dateIn = TimeNumberToSystemDateTime(thoiGianVaoVien).Value.Date;
        //        System.DateTime dateOut = TimeNumberToSystemDateTime(thoiGianRaVien).Value.Date;
        //        if (dateIn != null && dateOut != null)
        //        {
        //            long difference_Hour = (timeOut - timeIn).Ticks / 36000000000;
        //            if (difference_Hour < 4)
        //                result = 0;
        //            else if (difference_Hour >= 4 && difference_Hour < 8)
        //                result = 1 / 2;
        //            else if (difference_Hour >= 8 && difference_Hour <= 24)
        //                result = 1;
        //            else
        //                result = (dateOut - dateIn).Ticks / 864000000000 + 1;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.Logging.LogSystem.Error(ex);
        //        result = 0;
        //    }
        //    return result;
        //}

        /// <summary>
        /// Ngày điều trị: Cách tính theo Thông tư 28/2014/TT-BYT ngày 14/ 08/2014 của Bộ Y tế 
        /// </summary>
        /// <param name="timeIn"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static decimal TinhSoNgayDieuTri_V2(long thoiGianVaoVien, long thoiGianRaVien)
        {
            decimal result = -1;
            try
            {
                System.DateTime? dateBefore = TimeNumberToSystemDateTime(thoiGianVaoVien);
                System.DateTime? dateAfter = TimeNumberToSystemDateTime(thoiGianRaVien);
                if (dateBefore != null && dateAfter != null)
                {
                    TimeSpan difference = dateAfter.Value - dateBefore.Value;
                    int difference_Hour = (int)difference.TotalHours;

                    if (difference_Hour < 4)
                        result = 0;
                    else if (difference_Hour >= 4 && difference_Hour < 8)
                        result = 1 / 2;
                    else if (difference_Hour >= 8 && difference_Hour <= 24)
                        result = 1;
                    else
                        result = Math.Round((decimal)difference.TotalDays, 0) + 1;
                }
            }
            catch (Exception ex)
            {
                result = -1;
            }
            return result;
        }


        private static System.DateTime? TimeNumberToSystemDateTime(long time)
        {
            System.DateTime? result = null;
            try
            {
                if (time > 0)
                {
                    result = System.DateTime.ParseExact(time.ToString() + "00", "yyyyMMddHHmmss",
                                       System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
                result = null;
            }
            return result;
        }
    }
}