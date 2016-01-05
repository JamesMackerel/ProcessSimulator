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

using System.Data;
using System.Data.SqlClient;

using System.Collections.ObjectModel;

namespace ProcessSimulator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<SchedulingAlgorithm> supportedAlgorithm;
        private ObservableCollection<VirtualProcess> processes;

        public ObservableCollection<SchedulingAlgorithm> SupportedAlgorithm
        {
            get
            {
                return supportedAlgorithm;
            }

            set
            {
                supportedAlgorithm = value;
            }
        }

        internal ObservableCollection<VirtualProcess> Processes
        {
            get
            {
                return processes;
            }

            set
            {
                processes = value;
            }
        }

        public MainWindow()
        {
            //get supported algorithms from factory
            supportedAlgorithm = new ObservableCollection<SchedulingAlgorithm>(SimulatorFactory.SupportedAlgorithm);
            //initialize the process collection
            processes = new ObservableCollection<VirtualProcess>();

            InitializeComponent();
            DataContext = this;

#if DEBUG
            ProcessList.Items.Add(new VirtualProcess(1, 3, TimeSpan.Parse("3"), DateTime.Parse("2:00")));
#endif
        }

        private void AddProcess_Click(object sender, RoutedEventArgs e)
        {
            int Pid;
            int Priority;
            TimeSpan Duration;
            DateTime ArriveTime;

            try
            {
                Pid = int.Parse(tbPid.Text);
                Priority = int.Parse(tbPriority.Text);
                Duration = TimeSpan.Parse(tbDuration.Text);
                ArriveTime = DateTime.Parse(tbArriveTime.Text);

                ProcessList.Items.Add(new VirtualProcess(Pid, Priority, Duration, ArriveTime));
            }
            catch(FormatException exception)
            {
                string ExceptionMessage = string.Format("{0}:{1}", exception.Source, exception.Message);
                MessageBox.Show(ExceptionMessage);
            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ProcessList.SelectedItem != null)
            {
                ProcessList.Items.Remove(ProcessList.SelectedItem);
            }
            else
            {
                MessageBox.Show("Please choose a process to delete.");
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            //get a simulator
            SimulatorFactory simulatorFactory = new SimulatorFactory();
            ISimulator simulator = simulatorFactory.getSimulator((SchedulingAlgorithm)SelectedSchedulingAlgorithm.SelectedItem, (bool)IsPreemtive.IsChecked);
            //use the simulator
            List<VirtualProcess> p  = Processes.ToList();
            simulator.Simulate(p);
            Processes = new ObservableCollection<VirtualProcess>(p);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}
