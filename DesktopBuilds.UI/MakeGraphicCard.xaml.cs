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
    /// Interaction logic for MakeGraphicCard.xaml
    /// </summary>
    public partial class MakeGraphicCard : Window, INotifyPropertyChanged
    {
        public string GFXName
        { 
            get
            {
                return gfxName;
            }
            set
            {
                gfxName = value;
                OnPropertyChanged("GFXName");
            }
        }
        string gfxName;
        
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

        public string Memory 
        {
            get
            {
                return memory;
            }
            set
            {
                memory = value;
                OnPropertyChanged("Memory");
            }
        }
        string memory;

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

        private void OnPropertyChanged(string v)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public MakeGraphicCard()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void MakeNewGraphicCard(string name, string frequency, string memory, string manufacturer)
        {
            int _frequency;
            int _memory;
            if (!int.TryParse(frequency, out _frequency) || !int.TryParse(memory, out _memory)) return;

            GraphicCard graphicCard = new GraphicCard
            {
                Name = name,
                Manufacturer = manufacturer,
                Frequency = _frequency,
                Memory = _memory,
            };

            using (var context = new DesktopBuildsContext())
            {
                if (context.GraphicCards.Any(g => g.Name.ToLower() == graphicCard.Name.ToLower())) return;
                context.GraphicCards.Add(graphicCard);
                context.SaveChanges();
            }
        }

        private void AddNewGraphicCard_Click(object sender, RoutedEventArgs e)
        {
            MakeNewGraphicCard(GFXName, Frequency, Memory, Manufacturer);
        }
    }
}
