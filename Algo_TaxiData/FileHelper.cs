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
        public static (List<DataInfo>, string FileContent) ReadFile(string ID,string filePath)
        {
            List<DataInfo> dataInfos = new List<DataInfo>();
            string FileContent = "";
            //FileStream fs=new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            using (StreamReader sr = new StreamReader((System.IO.Stream)File.OpenRead(filePath),Encoding.Default))
            {
                string[] items = null;
                FileContent += $"{sr.ReadLine()}\n";
                while (!sr.EndOfStream)
                {
                    string buffer = sr.ReadLine();

                    buffer = buffer.Trim();     //去除文件首尾空格
                    if (buffer == null) continue;    //空行就跳过

                    items = buffer.Split(new char[] { ',' });   //按照逗号隔开
                    if (items.Length != 5 || !(items[0].Equals(ID))) continue;

                    FileContent += $"{buffer}\n";
                    TimeSYS timeSYS = TimeSYS.CreateFromBJStr(items[2]);
                    dataInfos.Add(new DataInfo(items[0], int.Parse(items[1]), timeSYS,
                        double.Parse(items[3]), double.Parse(items[4])));
                }

                return (dataInfos, FileContent);
            }
        }
    }
}
