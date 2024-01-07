using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_TaxiData
{
    public class CalResult
    {
        int timeId;
        double sTime, eTime;

        double speed;
        double azimuth;
        public CalResult(int timeId, double sTime, double eTime, double speed, double azimuth)
        {
            this.timeId = timeId;
            this.sTime = sTime;
            this.eTime = eTime;
            this.speed = speed;
            this.azimuth = azimuth;
        }


    }

    public class MainAlgo
    {
        public DataInfo d1, d2;
        public int timeId;

        public MainAlgo(int timeId, DataInfo d1, DataInfo d2)
        {
            this.d1 = d1;
            this.d2 = d2;
            this.timeId = timeId;
        }

        /// <summary>
        /// 计算时段的方位角，返回度单位
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public double Azimuth()
        {
            double dx = d2.x - d1.x;
            double dy = d2.y - d1.y;

            return (Math.Atan2(dy, dx) + (dy < 0 ? 1 : 0) * 2*Math.PI)
                * 180 / Math.PI;    //转成角度，测量坐标系
        }

        /// <summary>
        /// 计算两个时段的距离，返回km单位
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public double CalLength()
        {
            double dx = d2.x - d1.x;
            double dy = d2.y - d1.y;
            double ds = Math.Sqrt(dx * dx + dy * dy);

            return ds * 0.001;
        }

        /// <summary>
        /// 计算两个时段的平均速度，返回km/h单位
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public double CalSpeed()
        {
            double ds = this.CalLength();
            double ts = TimeSYS.deltaUTC(d1.timeUTC, d2.timeUTC);

            return ds / (ts / 3600.0);
        }

        public override string ToString()
        {
            return $"{timeId:00}, {d1.timeUTC.mjd:F5}-{d2.timeUTC.mjd:F5}, {CalSpeed():F3}, {Azimuth():F3}";
        }
    }
}
