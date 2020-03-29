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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAnimationTest
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

        private void benStart(object sender, RoutedEventArgs e)
        {
            Storyboard sb = new Storyboard();
            sb.Children.Add(CreateDoubleAnimation(sample1, false, new RepeatBehavior(1), "Width", 30)); //播放1次  宽度
            sb.Children.Add(CreateDoubleAnimation(sample2, false, new RepeatBehavior(5), "Height", 30)); //播放5次 高度
            sb.Children.Add(CreateDoubleAnimation(sample3, true, RepeatBehavior.Forever, "Width", 30)); //宽度无限次播放
            sb.Children.Add(CreateDoubleAnimation(sample4, true, RepeatBehavior.Forever, "Height", 30));//高度无限次播放
            sb.Begin();
        }

        private Timeline CreateDoubleAnimation(UIElement element, bool autoReverse, RepeatBehavior repeat, string propertyPath, double by)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0; //动画得起始值
            //da.To = 100;  //动画得结束值
            da.By = by; //代表动画得基础上增加得一个范围
            da.Duration = TimeSpan.FromSeconds(1);
            da.RepeatBehavior = repeat; //动画无限次播放
            da.AutoReverse = autoReverse; //倒序播放
            Storyboard.SetTarget(da, element);
            Storyboard.SetTargetProperty(da, new PropertyPath(propertyPath));
            return da;
        }

        private void benStart1(object sender, RoutedEventArgs e)
        {
            Storyboard sb = new Storyboard();
            sb.Children.Add(CreateDoubleAnimation(sample2_1, false, new RepeatBehavior(1), "(UIElement.RenderTransform).(TranslateTransform.X)", 30));
            sb.Children.Add(CreateDoubleAnimation(sample2_2, false, new RepeatBehavior(5), "(UIElement.RenderTransform).(TranslateTransform.Y)", 30));
            sb.Children.Add(CreateDoubleAnimation(sample2_3, true, RepeatBehavior.Forever, "(UIElement.RenderTransform).(RotateTransform.Angle)", 360));
            sb.Children.Add(CreateDoubleAnimation(sample2_4, true, RepeatBehavior.Forever, "(UIElement.RenderTransform).(TranslateTransform.X)", 60));
            sb.Begin();
        }

        private void benStart2(object sender, RoutedEventArgs e)
        {
            Storyboard sb = new Storyboard();
            sb.Children.Add(CreateDoubleAnimation(sample3_1, false, new RepeatBehavior(1), "Opacity", 1)); 
            sb.Children.Add(CreateDoubleAnimation(sample3_2, false, new RepeatBehavior(5), "Opacity", 1)); 
            sb.Children.Add(CreateDoubleAnimation(sample3_3, true, RepeatBehavior.Forever, "Opacity", 1)); 
            sb.Children.Add(CreateDoubleAnimation(sample3_4, true, RepeatBehavior.Forever, "Opacity", 1));
            sb.Begin();
        }
    }
}
