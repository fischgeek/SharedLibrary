using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public static class JFUtil
    {
        /// <summary>
        /// Gets a random number between 0 and 10 unless max is specified!
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int GetRandom(int max = 10)
        {
            Random r = new Random();
            return r.Next(max);
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="max"></param>
		/// <returns></returns>
        public static int GetRandomNeg(int max = 10)
        {
            Random r = new Random();
            return r.Next(max) * -1;
        }

        public static decimal GetRandomDecimal()
        {
            Random r = new Random();
            //var a = r.NextDouble() * (10^numOnLeft); //1.54894115  52.56465456465 151.18618316
            //var xx = Math.Round(a, numOnRight);
            string s = string.Format("{0}.{1}", GetRandom(), GetRandom(99));
            decimal d;
            if (decimal.TryParse(s, out d)) {
                return d;
            }
            return 0;
        }

		public class JSONResponse
		{
			public bool success = true;
			public string Status { get; set; }
			public string Message { get; set; }
			public object Data { get; set; }
		}

		public enum JSONResponseStatus
		{
			Success,
			Error,
			None
		}

		public static string getJSONResponseText(JSONResponseStatus enumStatus)
		{
			return enumStatus.ToString();
		}
	}
}
