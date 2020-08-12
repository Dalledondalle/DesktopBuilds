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
    /// Interaction logic for EditMotherboard.xaml
    /// </summary>
    public partial class EditMotherboard : Window, INotifyPropertyChanged
    {
        private void OnPropertyChanged(string v)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private Motherboard Motherboard;
        private Motherboard Original;

        public string Manufacturer { get; set; }
        public string MotherboardName { get; set; }
        public string Socket { get; set; }
        public string PCICount { get; set; }
        public string PCIEx16Count { get; set; }
        public string PCIExCount { get; set; }
        public EditMotherboard(Motherboard motherboard)
        {
            Motherboard = motherboard;
            Original = new Motherboard()
            {
                Id = motherboard.Id,
                Name = motherboard.Name,
                Manufacturer = motherboard.Manufacturer,
                PCICount = motherboard.PCICount,
                PCIEx16Count = motherboard.PCIEx16Count,
                PCIExCount = motherboard.PCIExCount
            };
            Manufacturer = Motherboard.Manufacturer;
            MotherboardName = Motherboard.Name;
            Socket = Motherboard.Socket;
            PCICount = Motherboard.PCICount.ToString();
            PCIEx16Count = Motherboard.PCIEx16Count.ToString();
            PCIExCount = Motherboard.PCIExCount.ToString();
            InitializeComponent();
            DataContext = this;
        }
        private void Edit()
        {
            using (var context = new DesktopBuildsContext())
            {
                if (MotherboardName != Motherboard.Name) Motherboard.Name = MotherboardName;

                if (Manufacturer != Motherboard.Manufacturer) Motherboard.Manufacturer = Manufacturer;

                if (Socket != Motherboard.Socket) Motherboard.Socket = Socket;

                int c;
                if (int.TryParse(PCICount, out c) && Motherboard.PCICount != c) Motherboard.PCICount = c;

                int ex16;
                if (int.TryParse(PCIEx16Count, out ex16) && Motherboard.PCIEx16Count != ex16) Motherboard.PCIEx16Count = ex16;

                int ex;
                if (int.TryParse(PCIExCount, out ex) && Motherboard.PCIExCount != ex) Motherboard.PCIExCount = ex;

                if (Motherboard.Name != Original.Name ||
                    Motherboard.Manufacturer != Original.Manufacturer ||
                    Motherboard.Socket != Original.Socket ||
                    Motherboard.PCICount != Original.PCICount ||
                    Motherboard.PCIEx16Count != Original.PCIEx16Count ||
                    Motherboard.PCIExCount != Original.PCIExCount)
                {
                    context.Motherboards.Update(Motherboard);
                    context.SaveChanges();
                    Close();
                }
            }
        }
        private void EditMotherboard_Click(object sender, RoutedEventArgs e)
        {
            Edit();
        }
    }
}
