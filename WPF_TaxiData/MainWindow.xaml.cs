using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Algo_TaxiData;


namespace WPF_TaxiData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        #region 私有变量
        private List<DataInfo> _data = new List<DataInfo>();
        #endregion



        #region 属性变量
        private string showText = "请打开一个数据文件~";
        public string ShowText
        {
            get => showText;
            set
            {
                this.showText = value;
                if (this.PropertyChanged != null)
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(ShowText)));
            }
        }


        private string fileName = "";
        public string FileName
        {
            get => fileName;
            set
            {
                this.fileName = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(FileName)));
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(titleText)));
                }

            }
        }


        public string titleText
        {
            get => $"出租车轨迹数据计算(Version 2024©){(FileName == string.Empty ? "" : "-")}{FileName}";
        }


        private string statusLabel = "准备就绪";

        public string StatusLabel
        {
            get => this.statusLabel;
            set
            {
                this.statusLabel = value;
                if (this.PropertyChanged != null)
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(StatusLabel)));
            }
        }

        private bool isCal = false;
        public bool IsCal
        {
            get => isCal;
            set
            {
                this.isCal = value;
                if (this.PropertyChanged != null)
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(IsCal)));
            }
        }

        #endregion

        #region 按钮事件

        private void BtOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择出租车数据文件路径";
            ofd.DefaultExt = ".txt";
            ofd.Filter = "出租车数据文件|*.txt";
            if (ofd.ShowDialog() != true) { return; }

            this.FileName = ofd.FileName;
            if (File.Exists(this.FileName))
            {
                List<DataInfo> dataInfos = new List<DataInfo>();
                string Content = "";
                (dataInfos, Content) = FileHelper.ReadFile("T2", this.FileName);
                _data = dataInfos;
                this.ShowText = Content;
                this.isCal = false;
                this.StatusLabel = "数据文件打开成功！";
            }
        }

        private void BtCal_Click(object sender, RoutedEventArgs e)
        {
            double SumLength = 0;
            string CalResult = "------------速度和方位角计算结果----------\n";

            for (int i = 0; i < this._data.Count - 1; i++)
            {
                MainAlgo mainAlgo = new MainAlgo(i, this._data[i], this._data[i + 1]);
                CalResult += $"{mainAlgo.ToString()}\n";
                SumLength += mainAlgo.CalLength();
            }

            CalResult += "------------距离计算结果-----------------\n";
            CalResult += $"累积距离：{SumLength:F3} (km)\n";
            CalResult += $"首尾直线距离： {new MainAlgo(_data.Count, _data[0], _data[^1]).CalLength()} (km)";

            this.ShowText = CalResult;
            this.IsCal = true;
            this.StatusLabel = "计算成功！";
        }

        private void BtSaveFile_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd= new SaveFileDialog();
            sfd.Title = "请选择保存路径";
            sfd.Filter = "txt 文本|*.txt";
            sfd.AddExtension= true;
            sfd.DefaultExt = ".txt";
            if (sfd.ShowDialog() != true) return;

            using (StreamWriter sw = new StreamWriter(sfd.FileName))
            {
                sw.Write(this.showText);
                this.StatusLabel = "保存成功！";
            }
        }

        private void BtHelp_Click(object sender, RoutedEventArgs e)
        {
            this.IsCal = false;
            this.ShowText = "@Time    :2024/01/06\n" +
                "@Author  :小 y 同 学\n" +
                "@公众号   :小y只会写bug\n" +
                "@CSDN    :https://blog.csdn.net/weixin_64989228?type=blog";
        }

        #endregion
    }
}
