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
using System.Windows.Threading;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private DateTime _now;

        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            var myTextBlock = (Label)this.FindName("currentTime");
            myTextBlock.Content = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void numberOfClasses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cmb = sender as ComboBox;
            var examDetailsGrid = (Grid)this.FindName("examDetailsGrid");

            examDetailsGrid.Children.Clear();
            examDetailsGrid.ColumnDefinitions.Clear();
            for (int i=0;i<= cmb.SelectedIndex; i++)
            {
                var columnDefinition = new ColumnDefinition();
                examDetailsGrid.ColumnDefinitions.Add(columnDefinition);
                var examTimes = new ExamTimes();
                Grid.SetRow(examTimes, 0);
                Grid.SetColumn(examTimes, i);
                examDetailsGrid.Children.Add(examTimes);
            }
            
        }
    }
}
