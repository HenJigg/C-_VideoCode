using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Npoi_Sample
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> stuLists = new List<Student>();
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 50; i++)
            {
                stuLists.Add(new Student()
                {
                    Id = i.ToString(),
                    Name = "A" + i,
                    Address = $"朝阳路{i}号",
                    Sex = "男",
                    Tel = "110"
                });
            }
            gd.ItemsSource = stuLists;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel表格(*.xls)|*.xls";
            if (dialog.ShowDialog() == true)
            {
                ExcelHelper<Student>.SaveXlsChangeds(dialog.FileName, stuLists);
            }
        }
    }

    public class Student
    {
        [Description("序号")]
        public string Id { get; set; }

        [Description("姓名")]
        public string Name { get; set; }

        [Description("性别")]
        public string Sex { get; set; }

        [Description("地址")]
        public string Address { get; set; }

        [Description("电话")]
        public string Tel { get; set; }
    }
}
