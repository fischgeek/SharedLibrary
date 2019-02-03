using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public static class Extensions
    {
        //public static string RegexReplace(this string input, string pattern, RegexOptions options = RegexOptions.IgnoreCase)
        //{
        //    return Regex.Replace(input ?? "", pattern, "", options);
        //}
        public static string RegexReplace(this string input, string pattern, string replace, RegexOptions options = RegexOptions.IgnoreCase)
        {
            return Regex.Replace(input ?? "", pattern, replace, options);
        }

        public static int GetRandom(this Random random)
        {
            Random r = new Random();
            return r.Next(10);
        }

		public static bool JFIsNull(this string str)
		{
			if (string.IsNullOrEmpty(str)
				|| string.IsNullOrWhiteSpace(str)
				|| str.Equals(" ")
				|| str.ToLower().Equals("null")) {
				return true;
			}
			return false;
		}

		public static string JFNullToEmptyString(this string str)
		{
			if (str.JFIsNull()) {
				return "";
			}
			return str;
		}

		public static DateTime JFStringToDate(this string str)
		{
			DateTime dt;
			if (DateTime.TryParse(str, out dt)) {
				return dt;
			}
			throw new Exception($"Unable to parse string as a date: {str}");
		}

		public static DateTime? JFStringToDateAllowNull(this string str)
		{
			DateTime dt;
			if (DateTime.TryParse(str, out dt)) {
				return dt;
			}
			return null;
		}

		public static bool JFStringToBool(this string str) => str.JFStringToInt() > 0 ? true : false;

		public static int JFStringToInt(this string str)
		{
			int d;
			if (Int32.TryParse(str, out d)) {
				return d;
			}
			return 0;
		}

		public static string JFDigitsOnly(this string str)
		{
			return Regex.Replace(str.JFNullToEmptyString(), @"[^\d+]", "");
		}

		public static string ToDateAndTime(this DateTime dt)
		{
			return dt.ToString(@"M/dd/yyyy h:mm tt");
		}

		public static DateTime Sunday(this DateTime dt)
		{
			return GetDayOfWeek(dt, DayOfWeek.Sunday);
		}

		public static DateTime Monday(this DateTime dt)
		{
			return GetDayOfWeek(dt, DayOfWeek.Monday);
		}

		public static DateTime Tuesday(this DateTime dt)
		{
			return GetDayOfWeek(dt, DayOfWeek.Tuesday);
		}

		public static DateTime Wednesday(this DateTime dt)
		{
			return GetDayOfWeek(dt, DayOfWeek.Wednesday);
		}

		public static DateTime Thursday(this DateTime dt)
		{
			return GetDayOfWeek(dt, DayOfWeek.Thursday);
		}

		public static DateTime Friday(this DateTime dt)
		{
			return GetDayOfWeek(dt, DayOfWeek.Friday);
		}

		public static DateTime Saturday(this DateTime dt)
		{
			return GetDayOfWeek(dt, DayOfWeek.Saturday);
		}

		private static DateTime GetDayOfWeek(DateTime d, DayOfWeek dow)
		{
			int diff = d.DayOfWeek - dow;
			return d.AddDays(-diff);
		}
	}
}
