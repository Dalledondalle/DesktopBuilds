using DesktopBuilds.Data;
using DesktopBuilds.Domain;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;


namespace DesktopBuilds.UI
{
    public partial class EditDesktop : Window, INotifyPropertyChanged
    {
        private void OnPropertyChanged(string v)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private Desktop Desktop { get; set; }
        public string NameTxtBox
        {
            get
            {
                return nameTxtBox;
            }
            set
            {
                nameTxtBox = value;
                OnPropertyChanged("NameTxtBox");
            }
        }
        string nameTxtBox;

        public ObservableCollection<CPU> CPUs
        {
            get
            {
                return cpus;
            }
            set
            {
                cpus = value;
                OnPropertyChanged("CPUs");
            }
        }
        ObservableCollection<CPU> cpus;
        public int SelectedCPU { get; set; }

        public ObservableCollection<Ram> Rams { get; set; }
        public int SelectedRam { get; set; }

        public ObservableCollection<Motherboard> Motherboards { get; set; }
        public int SelectedMotherboard { get; set; }

        public ObservableCollection<GraphicCard> GraphicsCards { get; set; }
        public int SelectedGraphicsCard { get; set; }

        public EditDesktop(Desktop _desktop)
        {
            Desktop = _desktop;
            FillLists();
            NameTxtBox = Desktop.Name;
            SelectedCPU = GetCPUIndex(Desktop.CPU);
            SelectedRam = GetRamIndex(Desktop.Ram);
            SelectedMotherboard = GetMotherboardIndex(Desktop.Motherboard);
            SelectedGraphicsCard = GetGraphicsCardIndex(Desktop.GraphicCard);
            InitializeComponent();
            DataContext = this;
        }
        private void EditName()
        {
            using (var context = new DesktopBuildsContext())
            {
                if(Desktop.Name != NameTxtBox) Desktop.Name = NameTxtBox;
                if(Desktop.CPU.Id != CPUs[SelectedCPU].Id) Desktop.CPU = CPUs[SelectedCPU];
                if(Desktop.Ram.Id != Rams[SelectedRam].Id) Desktop.Ram = Rams[SelectedRam];
                if(Desktop.Motherboard.Id != Motherboards[SelectedMotherboard].Id) Desktop.Motherboard = Motherboards[SelectedMotherboard];
                if(Desktop.GraphicCard.Id != GraphicsCards[SelectedGraphicsCard].Id) Desktop.GraphicCard = GraphicsCards[SelectedGraphicsCard];
                context.Desktops.Update(Desktop);
                context.SaveChanges();
            }
        }
        private int GetCPUIndex(CPU cpu)
        {
            foreach(CPU c in CPUs) if (c.Id == cpu.Id) return CPUs.IndexOf(c);
            return -1;
        }
        private int GetRamIndex(Ram ram)
        {
            foreach (Ram r in Rams) if (r.Id == ram.Id) return Rams.IndexOf(r);
            return -1;
        }
        private int GetMotherboardIndex(Motherboard motherboard)
        {
            foreach (Motherboard m in Motherboards) if (m.Id == motherboard.Id) return Motherboards.IndexOf(m);
            return -1;
        }
        private int GetGraphicsCardIndex(GraphicCard graphicCard)
        {
            foreach (GraphicCard g in GraphicsCards) if (g.Id == graphicCard.Id) return GraphicsCards.IndexOf(g);
            return -1;
        }
        private void FillLists()
        {
            using (var context = new DesktopBuildsContext())
            {
                CPUs = new ObservableCollection<CPU>();
                foreach (CPU c in context.CPUs) CPUs.Add(c);
                Rams = new ObservableCollection<Ram>();
                foreach (Ram r in context.Rams) Rams.Add(r);
                Motherboards = new ObservableCollection<Motherboard>();
                foreach (Motherboard m in context.Motherboards) Motherboards.Add(m);
                GraphicsCards = new ObservableCollection<GraphicCard>();
                foreach (GraphicCard g in context.GraphicCards) GraphicsCards.Add(g);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            EditName();
        }
    }
}
