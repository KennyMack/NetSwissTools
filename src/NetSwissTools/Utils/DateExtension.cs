using System;

namespace NetSwissTools.Utils
{
    public static class DateExtension
    {
        #region Week number
        /// <summary>
        /// Return the week number of the date indicated,
        /// </summary>
        /// <param name="date">Date to check week number</param>
        /// <returns>System.int</returns>
        public static int MonthWeekNumber(this DateTime date)
        {
            var numSemana = 1;
            var numDias = DateTime.DaysInMonth(date.Year, date.Month);
            var diaSemana = (int)date.DayOfWeek;

            for (int i = 0; i < numDias; i++)
            {
                if (i == date.Day)
                {
                    break;
                }

                diaSemana++;

                if (diaSemana > 7)
                {
                    numSemana++;
                    diaSemana = 1;
                }
            }

            return numSemana;
        }
        #endregion

        #region First Day of Month
        /// <summary>
        /// Returns the first day of the month
        /// </summary>
        /// <param name="date">The date</param>
        /// <returns>System.DateTime</returns>
        public static DateTime FirstDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1, date.Hour, date.Minute, date.Second, date.Millisecond);
        }
        #endregion

        #region Last Day of month
        /// <summary>
        /// Returns the last day of month
        /// </summary>
        /// <param name="date">the date</param>
        /// <returns>System.DateTime</returns>
        public static DateTime LastDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month,
                        DateTime.DaysInMonth(date.Year, date.Month),
                       date.Hour, date.Minute, date.Second, date.Millisecond);
        }
        #endregion

        #region Last hour of day
        /// <summary>
        /// Returns the last hour of day
        /// </summary>
        /// <param name="date">data</param>
        /// <returns>System.DateTime</returns>
        public static DateTime LastHour(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day,
                       23, 59, 59, 59);
        }
        #endregion

        #region First Hour of day
        /// <summary>
        /// Returns the first hour of day
        /// </summary>
        /// <param name="date">date</param>
        /// <returns>System.DateTime</returns>
        public static DateTime FirstHour(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day,
                        0, 0, 0, 0);
        }
        #endregion

        #region Is Weekend
        /// <summary>
        /// Returns if date is weekend
        /// </summary>
        /// <param name="date">data</param>
        /// <returns>Returns true if day of week is Sunday or Saturday</returns>
        public static bool IsWeekend(this DateTime date) =>
            date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;

        /// <summary>
        /// Returns if date is weekend
        /// </summary>
        /// <param name="date">data</param>
        /// <returns>Returns true if day of week is Sunday or Saturday</returns>
        public static bool IsWeekend(this DateTimeOffset date) =>
            IsWeekend(date.DateTime);
        #endregion

        #region Get next working day
        /// <summary>
        /// Returns the next working day from date informed.
        /// </summary>
        /// <param name="date">the date</param>
        /// <returns>System.DateTime</returns>
        /// <exception cref="NetToolException">Error processing the next working day</exception>
        public static DateTime GetNextWorkingDay(this DateTime date)
        {
            try
            {
                while (true)
                {
                    if (date.DayOfWeek == DayOfWeek.Saturday)
                        date = date.AddDays(2);
                    else if (date.DayOfWeek == DayOfWeek.Sunday)
                        date = date.AddDays(1);

                    return date;
                }
            }
            catch (Exception E)
            {
                throw new Exception("Error processing the next working day", E);
            }
        }
        #endregion

        #region Convert String to Int
        /// <summary>
        /// Convert string "HH:MM" to integer
        /// </summary>
        /// <param name="hour">hour formated HH:MM</param>
        /// <returns>ushort</returns>
        public static ushort HourToInt16(this string hour)
        {
            if (!string.IsNullOrEmpty(hour) &&
                !string.IsNullOrWhiteSpace(hour) &&
                hour.IndexOf(':') > -1)
            {
                string[] phora = hour.Split(':');
                var Hora = (ushort)(Convert.ToInt16(phora[0]) * 60);
                var Minuto = Convert.ToInt16(phora[1]);
                return (ushort)(Minuto + Hora);
            }
            else
                return 0;
        }
        #endregion

        #region Convert Int to Hour
        /// <summary>
        /// Convert string integer to "HH:MM"
        /// </summary>
        /// <param name="hour"></param>
        /// <returns>String</returns>
        public static String Int16ToHour(this ushort hour)
        {
            decimal dhour = hour;
            var hora = Math.Truncate(dhour / 60);
            var minutos = Math.Round(Math.Abs(hora - (dhour / 60)) * 60, 0);
            return string.Concat(hora.ToString().PadLeft(2, '0'), ":", minutos.ToString().PadLeft(2, '0'));
        }
        #endregion

        #region As UTC
        /// <summary>
        /// Ensures that local times are converted to UTC times.  Unspecified kinds are recast to UTC with no conversion.
        /// </summary>
        /// <param name="value">The date-time to convert.</param>
        /// <returns>The date-time in UTC time.</returns>
        public static DateTime AsUtc(this DateTime value)
        {
            return value.Kind == DateTimeKind.Unspecified ?
                new DateTime(value.Ticks, DateTimeKind.Utc) :
                value.ToUniversalTime();
        }

        /// <summary>
        /// Ensures that local times are converted to UTC times.  Unspecified kinds are recast to UTC with no conversion.
        /// </summary>
        /// <param name="value">The nullable date-time to convert.</param>
        /// <returns>The nullable date-time in UTC time.</returns>
        public static DateTime? AsUtc(this DateTime? value)
        {
            if (!value.HasValue) 
                return null;

            return value.Value.Kind == DateTimeKind.Unspecified ?
                new DateTime(value.Value.Ticks, DateTimeKind.Utc) :
                value.Value.ToUniversalTime();
        }
        #endregion

        #region Unix date
        /// <summary>
        /// Convert a unix timestamp to the corresponding datetime.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime FromUnixTime(double value)
        {
            var unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return unixStart.AddSeconds(value);
        }
        /// <summary>
        /// Convert a datetime to its corresponding unix timestamp value.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static long ToUnixTime(DateTime date)
        {
            var unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var timespan = date - unixStart;
            return (long)Math.Floor(timespan.TotalSeconds);
        }
        #endregion
    }
}
