using LiveCharts;
using LiveCharts.Wpf;
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

namespace LiveChartApp
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
            SeriesCollection series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "深圳",
                    Values = new ChartValues<double> { 4, 6, 5, 2 ,7 }
                },
                new LineSeries
                {
                    Title = "广州",
                    Values = new ChartValues<double> { 6, 7, 3, 4 ,6 }
                }
            };

            //x轴
            string[] Labels = new[] { "2011", "2012", "2013", "2014", "2015" };
            s1.Series = series;
            s1x.Labels = Labels;
            s1y.Separator.Step = 1;
            s1y.LabelFormatter = new Func<double, string>((value) =>
              {
                  return value.ToString();
              });
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SeriesCollection SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "深圳",
                    Values = new ChartValues<double> { 10, 50, 39, 50 }
                },
                new ColumnSeries
            {
                Title = "广州",
                Values = new ChartValues<double> { 11, 56, 42 }
            }
            };

            string[] Labels = new[] { "2011", "2012", "2013", "2014", "2015" };
            s2.Series = SeriesCollection;
            s2x.Labels = Labels;
            s2y.Separator.Step = 1;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SeriesCollection SeriesCollection = new SeriesCollection();

            SeriesCollection.Add(new PieSeries()
            {
                Title = "高一(1)班",
                Values = new ChartValues<int>() { 30 },
                DataLabels = true,
                LabelPoint = new Func<ChartPoint, string>((chartPoint) =>
                {
                    return string.Format("{0}{1} ({2:P})", chartPoint.SeriesView.Title, chartPoint.Y, chartPoint.Participation);
                })
            });
            SeriesCollection.Add(new PieSeries()
            {
                Title = "高一(2)班",
                Values = new ChartValues<int>() { 50 },
                DataLabels = true,
                LabelPoint = new Func<ChartPoint, string>((chartPoint) =>
                {
                    return string.Format("{0}{1} ({2:P})", chartPoint.SeriesView.Title, chartPoint.Y, chartPoint.Participation);
                })
            });
            SeriesCollection.Add(new PieSeries()
            {
                Title = "高一(3)班",
                Values = new ChartValues<int>() { 20 },
                DataLabels = true,
                LabelPoint = new Func<ChartPoint, string>((chartPoint) =>
                {
                    return string.Format("{0}{1} ({2:P})", chartPoint.SeriesView.Title, chartPoint.Y, chartPoint.Participation);
                })
            });

            s3.Series = SeriesCollection;
        }
    }
}
