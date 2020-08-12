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
    /// Interaction logic for EditCPU.xaml
    /// </summary>
    public partial class EditCPU : Window, INotifyPropertyChanged
    {
        private void OnPropertyChanged(string v)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private CPU CPU;

        public string Manufacturer { get; set; }
        public string CPUName { get; set; }
        public string DefaultFrequency { get; set; }
        public string MaxFrequency { get; set; }
        public string Cache { get; set; }
        public EditCPU(CPU cpu)
        {
            CPU = cpu;
            Manufacturer = CPU.Manufacturer;
            CPUName = CPU.Name;
            DefaultFrequency = CPU.DefaultFrequency.ToString();
            MaxFrequency = CPU.MaxFrequency.ToString();
            Cache = CPU.Cache.ToString();
            InitializeComponent();
            DataContext = this;
        }

        private void EditCPU_Click(object sender, RoutedEventArgs e)
        {
            Edit();
        }
        private void Edit()
        {
            using (var context = new DesktopBuildsContext())
            {
                bool changed = false;
                if (Manufacturer != CPU.Manufacturer)
                {
                    CPU.Manufacturer = Manufacturer;
                    changed = true;
                }
                if (CPUName != CPU.Name)
                {
                    CPU.Name = CPUName;
                    changed = true;
                }
                float df;
                if (float.TryParse(DefaultFrequency, out df) && df != CPU.DefaultFrequency)
                {
                    CPU.DefaultFrequency = df;
                    changed = true;
                }
                float mf;
                if (float.TryParse(MaxFrequency, out mf) && mf != CPU.MaxFrequency)
                {
                    CPU.MaxFrequency = mf;
                    changed = true;
                }
                int c;
                if (int.TryParse(Cache, out c) && c != CPU.Cache)
                {
                    CPU.Cache = c;
                    changed = true;
                }
                if (changed)
                {
                    context.CPUs.Update(CPU);
                    context.SaveChanges();
                    
                    Close();
                }
            }
        }
    }
}
