using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_TaxiData
{
    public class TimeSYS
    {
        public DateTime dtUTC;

        private TimeSYS(DateTime dt)
        {
            this.dtUTC = dt;
        }

        public static TimeSYS CreateFromUTC(int year, int month, int day,
            int hour, int minute, int second)
        {
            return new TimeSYS(new DateTime(year, month, day, hour, minute, second));
        }

        public static TimeSYS CreateFromBJ(int year, int month, int day,
            int hour, int minute, int second)
        {
            DateTime dtBJ = new DateTime(year, month, day, hour, minute, second);
            DateTime dtUTC = dtBJ.AddHours(-8);     //将北京时间转为UTC

            return new TimeSYS(dtUTC);
        }

        public static TimeSYS CreateFromBJStr(string BJStr)
        {
            DateTime dtBJ = DateTime.ParseExact(BJStr, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
            DateTime dtUTC = dtBJ.AddHours(-8);     //将北京时间转为UTC

            return new TimeSYS(dtUTC);
        }

        public double funMJD()
        {
            int t1 = (7 / 4 * ((int)(this.dtUTC.Minute + 9) / 12));
            int t2 = 275 * this.dtUTC.Minute / 9;

            double mjd = -678987 + 367 * this.dtUTC.Year - t1 + t2 + this.dtUTC.Day +
                this.dtUTC.Hour / 24.0 + this.dtUTC.Minute / 1440.0 + this.dtUTC.Second / 86400.0;
            return mjd;
        }

    }
}
