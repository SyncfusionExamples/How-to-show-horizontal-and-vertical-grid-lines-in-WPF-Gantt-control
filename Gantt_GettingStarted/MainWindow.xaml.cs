using Syncfusion.Windows.Controls.Gantt;
using Syncfusion.Windows.Controls.Gantt.Chart;
using Syncfusion.Windows.Controls.Gantt.Schedule;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
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

namespace Gantt_GettingStarted
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GanttSchedule ganttSchedule;
        private GanttChart ganttChart;
        ViewModel model;
        public MainWindow()
        {
            InitializeComponent();
            model = this.DataContext as ViewModel;

        }

        private void Gantt_Loaded(object sender, RoutedEventArgs e)
        {
            Border border = VisualTreeHelper.GetChild(Gantt, 0) as Border;
            Grid grid = VisualTreeHelper.GetChild(border, 0) as Grid;
            ScrollViewer scrollViewer = VisualTreeHelper.GetChild(grid, 2) as ScrollViewer;
            Grid scrollGrid = scrollViewer.Content as Grid;
            ganttChart = VisualTreeHelper.GetChild(scrollGrid, 1) as GanttChart;
            ganttSchedule = VisualTreeHelper.GetChild(scrollGrid, 0) as GanttSchedule;

            List<StripLineInfo> stripCollection = new List<StripLineInfo>();
            var differenceTime = (this.ganttSchedule.EndTime - this.ganttSchedule.StartTime).Days;
            for (int i = 0; i < differenceTime; i++)
            {


                stripCollection.Add(new StripLineInfo()
                {
                    Type = StriplineType.Absolute,
                    Width = 2,
                    Height = this.ganttChart.ActualHeight,
                    Position = new Point(PositionCalculation(this.ganttSchedule.StartTime.AddDays(i)), 0),
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Background = new SolidColorBrush(Colors.Orange),
                });
            }
            model.StripCollection = stripCollection;
        }

        private double PositionCalculation(DateTime day)
        {
            DateTime date = ganttSchedule.StartTime;
            MethodInfo methodInfo = typeof(GanttChart).GetMethod(
    "GetStartPositionOfDate",
    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static,
    null,
    new Type[] { typeof(DateTime) },
    null);
            object[] dateObjects = new object[] { day };
            double extent =
                (double)
                methodInfo.Invoke(
                    this.ganttChart,
                    BindingFlags.Instance | BindingFlags.NonPublic,
                    null,
                    dateObjects,
                    CultureInfo.CurrentCulture);
            return extent;
        }
    }
}
