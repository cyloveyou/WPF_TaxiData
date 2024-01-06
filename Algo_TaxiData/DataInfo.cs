using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_TaxiData
{
   

    public class DataInfo
    {
        public string TaxiID;
        public int TaxiStatus;
        public TimeSYS timeUTC;
        public double x, y;

        public double MJD;

        public DataInfo(string taxiID, int taxiStatus, TimeSYS timeUTC, double x, double y)
        {
            this.TaxiID = taxiID;
            this.TaxiStatus = taxiStatus;
            this.x = x;
            this.y = y;
            this.timeUTC = timeUTC;
            this.MJD = timeUTC.funMJD();
        }
    }
}
