using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

namespace WPF_TaxiData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        public MainWindow()
        {
            InitializeComponent();
        }


        private string showText = "请打开一个数据文件~";
        public string ShowText
        {
            get=> showText;
            set=>
        }

        private string FileName="";
        private string titleText = $"出租车轨迹数据计算(Version 2024©)-{FileName}";
        private string statusLabel = "准备就绪";

        
    }
}
