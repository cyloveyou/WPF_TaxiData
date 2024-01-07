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
        public double mjd;

        private TimeSYS(DateTime dt)
        {
            this.dtUTC = dt;
            this.mjd = funMJD();
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
            DateTime dtBJ = DateTime.ParseExact(BJStr.Trim(), "yyyyMMddHHmmss",
                System.Globalization.CultureInfo.CurrentCulture);
            DateTime dtUTC = dtBJ.AddHours(-8);     //将北京时间转为UTC

            return new TimeSYS(dtUTC);
        }

        public double funMJD()
        {
            int t1 = (int)((this.dtUTC.Month + 9.0) / 12.0);
            int t2 = (int)(7.0 / 4.0 * (this.dtUTC.Year + t1));
            int t3 = (int)(275.0 * this.dtUTC.Month / 9.0);

            double mjd = -678987.0 + 367.0 * this.dtUTC.Year * 1.0
                - t2 + t3
                + this.dtUTC.Day
                + this.dtUTC.Hour / 24.0
                + this.dtUTC.Minute / 1440.0
                + this.dtUTC.Second / 86400.0;
            return mjd;
        }

        public static double  deltaUTC(TimeSYS lastTime, TimeSYS nowTime)
        {
            return (nowTime.dtUTC - lastTime.dtUTC).TotalSeconds;
        }
    }
}
