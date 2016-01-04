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
        }

        private void AddProcess_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            SimulatorFactory simulatorFactory = new SimulatorFactory();
            ISimulator simulator = simulatorFactory.getSimulator((SchedulingAlgorithm)SelectedSchedulingAlgorithm.SelectedItem, (bool)IsPreemtive.IsChecked);
            List<VirtualProcess> p  = Processes.ToList();
            simulator.Simulate(p);
            Processes = new ObservableCollection<VirtualProcess>(p);
        }
    }
}
