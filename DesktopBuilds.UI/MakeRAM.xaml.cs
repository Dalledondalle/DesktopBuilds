using DesktopBuilds.Data;
using DesktopBuilds.Domain;
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
using System.Windows.Shapes;

namespace DesktopBuilds.UI
{
    /// <summary>
    /// Interaction logic for MakeRAM.xaml
    /// </summary>
    public partial class MakeRAM : Window, INotifyPropertyChanged
    {
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

        public string RAMName
        {
            get
            {
                return ramName;
            }
            set
            {
                ramName = value;
                OnPropertyChanged("RAMName");
            }
        }
        string ramName;

        public string Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                capacity = value;
                OnPropertyChanged("Capacity");
            }
        }
        string capacity;

        public string Frequency
        {
            get
            {
                return frequency;
            }
            set
            {
                frequency = value;
                OnPropertyChanged("Frequency");
            }
        }
        string frequency;

        public string Generation
        {
            get
            {
                return generation;
            }
            set
            {
                generation = value;
                OnPropertyChanged("Generation");
            }
        }
        string generation;

        private void OnPropertyChanged(string v)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public MakeRAM()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void MakeNewMemory(string name, string capacity, string frequency, string generation, string manufacturer)
        {
            int _capacity;
            int _frequency;
            if (!int.TryParse(capacity, out _capacity) || !int.TryParse(frequency, out _frequency)) return;
            Ram memory = new Ram
            {
                Name = name,
                Capacity = _capacity,
                Frequency = _frequency,
                Generation = generation,
                Manufacturer = manufacturer
            };

            using (var context = new DesktopBuildsContext())
            {
                if (context.Rams.Any(m => m.Name.ToLower() == memory.Name.ToLower())) return;
                context.Rams.Add(memory);
                context.SaveChanges();
            }
        }

        private void AddRAM_Click(object sender, RoutedEventArgs e)
        {
            MakeNewMemory(RAMName, Capacity, Frequency, Generation, Manufacturer);
        }
    }
}
