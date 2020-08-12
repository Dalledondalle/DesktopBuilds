using DesktopBuilds.Data;
using DesktopBuilds.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace DesktopBuilds.UI
{
    /// <summary>
    /// Interaction logic for MakeCPU.xaml
    /// </summary>
    public partial class MakeCPU : Window, INotifyPropertyChanged
    {
        
        public string CPUName 
        { 
            get
            {
                return cpuName;
            }
            set
            {
                cpuName = value;
                OnPropertyChanged("CPUName");
            }
        }
        string cpuName;

        public string Cache 
        { 
            get
            {
                return cache;
            }
            set
            {
                cache = value;
                OnPropertyChanged("Cache");
            }
        }
        string cache;

        public string DefaultFrequency 
        { 
            get
            {
                return defaultFrequency;
            }
            set
            {
                defaultFrequency = value;
                OnPropertyChanged("DefaultFrequency");
            }
        }
        string defaultFrequency;

        public string MaxFrequency 
        { 
            get
            {
                return maxFrequency;
            }
            set
            {
                maxFrequency = value;
                OnPropertyChanged("MaxFrequency");
            }
        }
        string maxFrequency;

        public string Manufacturer
        {
            get
            {
                return manufacturer;
            }
            set
            {
                manufacturer = value;
                OnPropertyChanged("Manufacturer");
            }
        }
        string manufacturer;
        public MakeCPU()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void OnPropertyChanged(string v)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void MakeNewCPU(string name, int cache, float defaultFrequency, float maxFrequency, string manufacturer)
        {
            CPU cpu = new CPU
            {
                Cache = cache,
                DefaultFrequency = defaultFrequency,
                MaxFrequency = maxFrequency,
                Manufacturer = manufacturer,
                Name = name
            };

            using (var context = new DesktopBuildsContext())
            {
                if (context.CPUs.Any(c => c.Name.ToLower() == cpu.Name.ToLower())) return;
                context.CPUs.Add(cpu);
                context.SaveChanges();
            }
        }

        private void ConvertInfo()
        {
            int _cache;
            float _defaultFrequency;
            float _maxFrequency;
            if (!int.TryParse(Cache, out _cache)) return;
            if (!float.TryParse(DefaultFrequency, out _defaultFrequency)) return;
            if (!float.TryParse(MaxFrequency, out _maxFrequency)) return;
            MakeNewCPU(CPUName, _cache, _defaultFrequency, _maxFrequency, Manufacturer);
        }

        private void AddNewCPU_Click(object sender, RoutedEventArgs e)
        {
            ConvertInfo();
        }
    }
}
