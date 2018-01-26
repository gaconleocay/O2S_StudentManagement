﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.Common.DateTimes
{
    public class Convert
    {
        private const string DATE_SEPARATE = "Ngày     tháng     năm       ";
        private const string MONTH_SEPARATE = "Tháng     năm       ";

        public static string TimeNumberToMonthString(long time)
        {
            string result = null;
            try
            {
                string temp = time.ToString();
                if (temp != null && temp.Length >= 8)
                {
                    result = new StringBuilder().Append(temp.Substring(4, 2)).Append("/").Append(temp.Substring(0, 4)).ToString();
                }
            }
            catch (Exception ex)
            {
                result = null;
            }
            return result;
        }

        public static string TimeNumberToDateString(long time)
        {
            string result = null;
            try
            {
                string temp = time.ToString();
                if (temp != null && temp.Length >= 8)
                {
                    result = new StringBuilder().Append(temp.Substring(6, 2)).Append("/").Append(temp.Substring(4, 2)).Append("/").Append(temp.Substring(0, 4)).ToString();
                }
            }
            catch (Exception ex)
            {
                result = null;
            }
            return result;
        }

        public static string TimeNumberToTimeString(long time)
        {
            string result = null;
            try
            {
                string temp = time.ToString();
                if (temp != null && temp.Length >= 14)
                {
                    result = new StringBuilder().Append(temp.Substring(6, 2)).Append("/").Append(temp.Substring(4, 2)).Append("/").Append(temp.Substring(0, 4)).Append(" ").Append(temp.Substring(8, 2)).Append(":").Append(temp.Substring(10, 2)).Append(":").Append(temp.Substring(12, 2)).ToString();
                }
            }
            catch (Exception ex)
            {
                result = null;
            }
            return result;
        }

        public static string SystemDateTimeToDateString(System.DateTime? dateTime)
        {
            string result = null;
            try
            {
                if (dateTime.HasValue)
                {
                    long? time = SystemDateTimeToTimeNumber(dateTime);
                    if (time.HasValue)
                    {
                        result = TimeNumberToDateString(time.Value);
                    }
                }
                else
                {
                    result = DATE_SEPARATE;
                }
            }
            catch (Exception ex)
            {
                result = DATE_SEPARATE;
            }
            return result;
        }

        public static string SystemDateTimeToDateSeparateString(System.DateTime? dateTime)
        {
            string result = DATE_SEPARATE;
            try
            {
                if (dateTime.HasValue)
                {
                    result = new StringBuilder().Append("Ngày ").Append(dateTime.Value.Day).Append(" tháng ").Append(dateTime.Value.Month).Append(" năm ").Append(dateTime.Value.Year).ToString();
                }
                else
                {
                    result = DATE_SEPARATE;
                }
            }
            catch (Exception ex)
            {
                result = DATE_SEPARATE;
            }
            return result;
        }

        public static string SystemDateTimeToMonthSeparateString(System.DateTime? dateTime)
        {
            string result = MONTH_SEPARATE;
            try
            {
                if (dateTime.HasValue)
                {
                    result = new StringBuilder().Append("Tháng ").Append(dateTime.Value.Month).Append(" năm ").Append(dateTime.Value.Year).ToString();
                }
                else
                {
                    result = MONTH_SEPARATE;
                }
            }
            catch (Exception ex)
            {
                result = MONTH_SEPARATE;
            }
            return result;
        }

        public static long? SystemDateTimeToTimeNumber(System.DateTime? dateTime)
        {
            long? result = null;
            try
            {
                if (dateTime.HasValue)
                {
                    result = long.Parse(dateTime.Value.ToString("yyyyMMddHHmmss"));
                }
            }
            catch (Exception ex)
            {
                result = null;
            }
            return result;
        }

        public static System.DateTime? TimeNumberToSystemDateTime(long time)
        {
            System.DateTime? result = null;
            try
            {
                if (time > 0)
                {
                    result = System.DateTime.ParseExact(time.ToString(), "yyyyMMddHHmmss",
                                       System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                result = null;
            }
            return result;
        }
    }
}
