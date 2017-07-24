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

		public static bool jfIsNull(this String str)
		{
			if (str == null || String.IsNullOrEmpty(str) || String.IsNullOrWhiteSpace(str)) {
				return true;
			}
			return false;
		}

		public static string ToDateAndTime(this DateTime dt)
		{
			return dt.ToString(@"M/dd/yyyy h:mm tt");
		}
	}
}
