using Microsoft.Win32;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace TextContentSearcher
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.ValidateNames = false;
            fileDialog.FileName = "Select Directory";
            if (fileDialog.ShowDialog() == true)
            {
                SearchPath.Content = System.IO.Path.GetDirectoryName(fileDialog.FileName);
            }
            //FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            //folderBrowserDialog.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string path = SearchPath.Content as string;
            if (String.IsNullOrEmpty(path))
            {
                MessageBox.Show("未选择目录！");
                return;
            }
            if (String.IsNullOrEmpty(SearchKey.Text))
            {
                MessageBox.Show("搜索的关键字为空！");
                return;
            }
            ResultContent.Text = "";
            string searchKey = SearchKey.Text;
            string[] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            //CancellationToken cancellationToken = new CancellationToken();
            //Task.Run(() =>
            //{
            string txt;
            foreach (var item in files)
            {
                txt = File.ReadAllText(item);
                if (txt.Contains(searchKey))
                    ResultContent.Text += item + "\n";
            }
            ResultContent.Text += $"搜索完毕！共搜索{files.Length}个文件。";
            //}, cancellationToken);
        }


    }
}
