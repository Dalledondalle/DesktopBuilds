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
    /// Interaction logic for MakeMotherboard.xaml
    /// </summary>
    public partial class MakeMotherboard : Window, INotifyPropertyChanged
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
        public string MotherboardName
        {
            get
            {
                return motherboardName;
            }
            set
            {
                motherboardName = value;
                OnPropertyChanged("MotherboardName");
            }
        }
        string motherboardName;

        public string Socket
        {
            get
            {
                return socket;
            }
            set
            {
                socket = value;
                OnPropertyChanged("Socket");
            }
        }
        string socket;

        public string PCICount
        {
            get
            {
                return pciCount;
            } 
            set
            {
                pciCount = value;
                OnPropertyChanged("PCICount");
            }
        }
        string pciCount;

        public string PCIEx16Count
        {
            get
            {
                return pciEx16Count;
            }
            set
            {
                pciEx16Count = value;
                OnPropertyChanged("PCIEx16Count");
            }
        }
        string pciEx16Count;

        public string PCIExCount
        {
            get
            {
                return pciExCount;
            }
            set
            {
                pciExCount = value;
                OnPropertyChanged("PCIExCount");
            }
        }
        string pciExCount;

        private void OnPropertyChanged(string v)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public MakeMotherboard()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void MakeNewMotherboard(string name, string socket, string PCICount, string PCIEx16Count, string PCIExCount, string manufacturer)
        {
            int _PCICount;
            int _PCIEx16Count;
            int _PCIExCount;
            if (!int.TryParse(PCICount, out _PCICount) || !int.TryParse(PCIEx16Count, out _PCIEx16Count) || !int.TryParse(PCIExCount, out _PCIExCount)) return;
            Motherboard motherboard = new Motherboard
            {
                Socket = socket,
                Manufacturer = manufacturer,
                PCICount = _PCICount,
                PCIEx16Count = _PCIEx16Count,
                PCIExCount = _PCIExCount,
                Name = name
            };

            using (var context = new DesktopBuildsContext())
            {
                if (context.Motherboards.Any(m => m.Name.ToLower() == motherboard.Name.ToLower())) return;
                context.Motherboards.Add(motherboard);
                context.SaveChanges();
            }
        }

        private void AddNewMotherboard_Click(object sender, RoutedEventArgs e)
        {
            MakeNewMotherboard(MotherboardName, Socket, PCICount, PCIEx16Count, PCIExCount, Manufacturer);
        }
    }
}
