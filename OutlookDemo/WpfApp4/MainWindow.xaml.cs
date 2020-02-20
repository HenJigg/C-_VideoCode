using System;
using System.Collections.Generic;
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

namespace WpfApp4
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


        private void Button_TouchMove(object sender, TouchEventArgs e)
        {
            var stackPanel = sender as StackPanel;
            var points = e.GetIntermediateTouchPoints(stackPanel);
            if (points.Count < 2) return;
            var frist_point = points.First();
            var last_point = points.Last();
            if (frist_point.Position.X == last_point.Position.X) return;
            var stackLength = stackPanel.Width;
            var length = frist_point.Position.X - last_point.Position.X;
            if (length > 0)//向左
            {
                var newrb_length = lb.Width - length;
                lb.Width = newrb_length > 0 ? newrb_length : 0;

                if (lb.Width == 0)
                    rb.Width += length;
            }
            else //向右
            {
                var newrb_length = rb.Width + length;
                rb.Width = newrb_length > 0 ? newrb_length : 0;

                if (rb.Width == 0)
                    lb.Width -= length;
            }
            element.Width = stackLength - rb.Width;

            if (rb.Width / stackLength > 0.4)
            {
                MessageBox.Show("已删除");
            }
            else if (lb.Width / stackLength > 0.4)
            {
                MessageBox.Show("已收藏");
            }
        }

        private void StackPanel_TouchLeave(object sender, TouchEventArgs e)
        {
            var stackPanel = sender as StackPanel;
            rb.Width = 0;
            lb.Width = 0;
            element.Width = stackPanel.Width;
        }
        
    }
}
