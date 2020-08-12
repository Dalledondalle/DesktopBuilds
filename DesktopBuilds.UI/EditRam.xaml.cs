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
    /// Interaction logic for EditRam.xaml
    /// </summary>
    public partial class EditRam : Window, INotifyPropertyChanged
    {
        private void OnPropertyChanged(string v)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private Ram Ram;
        private Ram Original;

        public string Manufacturer { get; set; }
        public string RAMName { get; set; }
        public string Capacity { get; set; }
        public string Frequency { get; set; }
        public string Generation { get; set; }

        public EditRam(Ram ram)
        {
            Ram = ram;
            Original = new Ram()
            {
                Id = ram.Id,
                Name = ram.Name,
                Manufacturer = ram.Manufacturer,
                Capacity = ram.Capacity,
                Frequency = ram.Frequency,
                Generation = ram.Generation
            };
            Manufacturer = ram.Manufacturer;
            RAMName = ram.Name;
            Capacity = ram.Capacity.ToString();
            Frequency = ram.Frequency.ToString();
            Generation = ram.Generation.ToString();
            InitializeComponent();
            DataContext = this;
        }

        private void EditRam_Click(object sender, RoutedEventArgs e)
        {
            Edit();
        }

        private void Edit()
        {
            if (RAMName != Ram.Name) Ram.Name = RAMName;

            if (Manufacturer != Ram.Manufacturer) Ram.Manufacturer = Manufacturer;

            int c;
            if (int.TryParse(Capacity, out c) && Ram.Capacity != c) Ram.Capacity = c;

            int f;
            if (int.TryParse(Frequency, out f) && Ram.Frequency != f) Ram.Frequency = f;

            if (Generation != Ram.Generation) Ram.Generation = Generation;

            if (Ram.Name != Original.Name ||
                Ram.Manufacturer != Original.Manufacturer ||
                Ram.Capacity != Original.Capacity ||
                Ram.Frequency != Original.Frequency ||
                Ram.Generation != Original.Generation)
            {
                using (var context = new DesktopBuildsContext())
                {
                    context.Rams.Update(Ram);
                    context.SaveChanges();
                    Close();
                }
            }
        }
    }
}
