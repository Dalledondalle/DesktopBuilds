using DesktopBuilds.Data;
using DesktopBuilds.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for MakeDesktop.xaml
    /// </summary>
    public partial class MakeDesktop : Window, INotifyPropertyChanged
    {
        private void OnPropertyChanged(string v)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public string DesktopName
        {
            get
            {
                return desktopName;
            }
            set
            {
                desktopName = value;
                OnPropertyChanged("DesktopName");
            }
        }
        string desktopName;

        public ObservableCollection<CPU> CPUs { get; set; }

        public CPU SelectedCPU
        {
            get
            {
                return selectedCPU;
            }
            set
            {
                selectedCPU = value;
                OnPropertyChanged("SelectedCPU");
            }
        }
        CPU selectedCPU;

        public ObservableCollection<Motherboard> Motherboards { get; set; }

        public Motherboard SelectedMotherboard
        {
            get
            {
                return selectedMotherboard;
            }
            set
            {
                selectedMotherboard = value;
                OnPropertyChanged("SelectedMotherboard");
            }
        }
        Motherboard selectedMotherboard;

        public ObservableCollection<Ram> Memories { get; set; }

        public Ram SelectedMemory
        {
            get
            {
                return selectedMemory;
            }
            set
            {
                selectedMemory = value;
                OnPropertyChanged("SelectedMemory");
            }
        }
        Ram selectedMemory;

        public ObservableCollection<GraphicCard> GraphicCards { get; set; }

        public GraphicCard SelectedGraphicCard
        {
            get
            {
                return selectedGraphicCard;
            }
            set
            {
                selectedGraphicCard = value;
                OnPropertyChanged("SelectedGraphicCard");
            }
        }
        GraphicCard selectedGraphicCard;
        public MakeDesktop()
        {
            InitializeComponent();
            DataContext = this;
            FillLists();
        }
        private void MakeNewDesktop()
        {
            return;
        }
        private void FillLists()
        {
            CPUs = new ObservableCollection<CPU>();
            Motherboards = new ObservableCollection<Motherboard>();
            Memories = new ObservableCollection<Ram>();
            GraphicCards = new ObservableCollection<GraphicCard>();
            using (var context = new DesktopBuildsContext())
            {
                var c = context.CPUs;
                var mo = context.Motherboards;
                var me = context.Rams;
                var g = context.GraphicCards;
                foreach (CPU cpu in c)
                {
                    CPUs.Add(cpu);
                }
                foreach (Motherboard m in mo)
                {
                    Motherboards.Add(m);
                }
                foreach (Ram m in me)
                {
                    Memories.Add(m);
                }
                foreach (GraphicCard graphicCard in g)
                {
                    GraphicCards.Add(graphicCard);
                }
            }
        }

        private void AddDesktop()
        {
            if (SelectedCPU == null ||
                SelectedGraphicCard == null ||
                SelectedMemory == null ||
                SelectedMemory == null ||
                DesktopName == null ||
                DesktopName.Length < 4) return;
            using (var context = new DesktopBuildsContext())
            {
            Desktop desktop = new Desktop()
            {
                CPU = context.CPUs.First(c => c.Name == selectedCPU.Name),
                GraphicCard = context.GraphicCards.First(g => g.Name == selectedGraphicCard.Name),
                Ram = context.Rams.First(m => m.Name == selectedMemory.Name),
                Motherboard = context.Motherboards.First(m => m.Name == selectedMotherboard.Name),
                Name = DesktopName
            };
            Debug.WriteLine(desktop.Name);
            Debug.WriteLine(desktop.CPU.Id);
            Debug.WriteLine(desktop.GraphicCard.Id);
            Debug.WriteLine(desktop.Ram.Id);
            Debug.WriteLine(desktop.Motherboard.Id);
            if (context.Desktops.Any(d => d.Name.ToLower() == desktop.Name.ToLower())) return;
            context.Desktops.Add(desktop);
            context.SaveChanges();
            }

        }

        private void AddNewDesktop_Click(object sender, RoutedEventArgs e)
        {
            AddDesktop();
        }
    }
}
