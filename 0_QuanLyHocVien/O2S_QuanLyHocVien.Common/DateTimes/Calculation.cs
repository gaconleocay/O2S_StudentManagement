using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.Common.DateTimes
{
    public class Calculation
    {
        public static int DifferenceMonth(long timeBefore, long timeAfter)
        {
            int result = -1;
            try
            {
                System.DateTime? dateBefore = Convert.TimeNumberToSystemDateTime(timeBefore);
                System.DateTime? dateAfter = Convert.TimeNumberToSystemDateTime(timeAfter);
                if (dateBefore != null && dateAfter != null)
                {
                    result = ((dateAfter.Value.Year - dateBefore.Value.Year) * 12) + dateAfter.Value.Month - dateBefore.Value.Month;
                }
            }
            catch (Exception ex)
            {
                result = -1;
            }
            return result;
        }

        public static int DifferenceDate(long timeBefore, long timeAfter)
        {
            int result = -1;
            try
            {
                System.DateTime? dateBefore = Convert.TimeNumberToSystemDateTime(timeBefore);
                System.DateTime? dateAfter = Convert.TimeNumberToSystemDateTime(timeAfter);
                if (dateBefore != null && dateAfter != null)
                {
                    TimeSpan difference = dateAfter.Value - dateBefore.Value;
                    result = (int)difference.TotalDays;
                }
            }
            catch (Exception ex)
            {
                result = -1;
            }
            return result;
        }

        public enum UnitDifferenceTime
        {
            DAY,
            HOUR,
            MINUTE,
            SECOND,
            MILISECOND,
        }

        public static int DifferenceTime(long timeBefore, long timeAfter, UnitDifferenceTime unit)
        {
            int result = -1;
            try
            {
                System.DateTime? dateBefore = Convert.TimeNumberToSystemDateTime(timeBefore);
                System.DateTime? dateAfter = Convert.TimeNumberToSystemDateTime(timeAfter);
                if (dateBefore != null && dateAfter != null)
                {
                    TimeSpan difference = dateAfter.Value - dateBefore.Value;
                    switch (unit)
                    {
                        case UnitDifferenceTime.DAY:
                            result = (int)difference.TotalDays;
                            break;
                        case UnitDifferenceTime.HOUR:
                            result = (int)difference.TotalHours;
                            break;
                        case UnitDifferenceTime.MINUTE:
                            result = (int)difference.TotalMinutes;
                            break;
                        case UnitDifferenceTime.SECOND:
                            result = (int)difference.TotalSeconds;
                            break;
                        case UnitDifferenceTime.MILISECOND:
                            result = (int)difference.TotalMilliseconds;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                result = -1;
            }
            return result;
        }

        public static int Age(long dob)
        {
            int result = -1;
            try
            {
                System.DateTime? sysDob = Convert.TimeNumberToSystemDateTime(dob);
                if (sysDob != null)
                {
                    System.DateTime today = System.DateTime.Today;
                    result = today.Year - sysDob.Value.Year;
                    if (today < sysDob.Value.AddYears(result))
                    {
                        result--;
                    }
                }
            }
            catch (Exception ex)
            {
                result = -1;
            }
            return result;
        }

        public static long? Add(long time, double value, UnitDifferenceTime unit)
        {
            long? result = null;
            try
            {
                System.DateTime? sysDateTime = Convert.TimeNumberToSystemDateTime(time);
                if (sysDateTime != null)
                {
                    switch (unit)
                    {
                        case UnitDifferenceTime.DAY:
                            sysDateTime = sysDateTime.Value.AddDays(value);
                            break;
                        case UnitDifferenceTime.HOUR:
                            sysDateTime = sysDateTime.Value.AddHours(value);
                            break;
                        case UnitDifferenceTime.MINUTE:
                            sysDateTime = sysDateTime.Value.AddMinutes(value);
                            break;
                        case UnitDifferenceTime.SECOND:
                            sysDateTime = sysDateTime.Value.AddSeconds(value);
                            break;
                        case UnitDifferenceTime.MILISECOND:
                            sysDateTime = sysDateTime.Value.AddMilliseconds(value);
                            break;
                        default:
                            break;
                    }
                    result = Convert.SystemDateTimeToTimeNumber(sysDateTime.Value);
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
