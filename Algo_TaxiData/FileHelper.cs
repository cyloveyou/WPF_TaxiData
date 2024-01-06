using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algo_TaxiData;

namespace Algo_TaxiData
{
    public class FileHelper
    {
        public static List<DataInfo> ReadFile(string filePath)
        {
            List<DataInfo> dataInfos = new List<DataInfo>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                string[] items = null;

                while (true)
                {
                    string buffer = sr.ReadLine();
                    if (buffer == null) break;  //最后一行就退出

                    buffer = buffer.Trim();     //去除文件首尾空格

                    if (buffer == null || buffer.Contains("车辆标识")) continue;    //空行或者首行就跳过

                    items = buffer.Split(new char[] { ',' });   //按照逗号隔开
                    if (items.Length != 5) continue;

                    TimeSYS timeSYS = TimeSYS.CreateFromBJStr(items[2]);

                    dataInfos.Add(new DataInfo(items[0], int.Parse(items[1]), timeSYS,
                        double.Parse(items[3]), double.Parse(items[4])));
                }

                return dataInfos;
            }
        }
    }
}
