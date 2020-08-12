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
    /// Interaction logic for EditGraphicCard.xaml
    /// </summary>
    public partial class EditGraphicCard : Window, INotifyPropertyChanged
    {
        private void OnPropertyChanged(string v)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private GraphicCard GraphicCard;
        private GraphicCard Original;

        public string Manufacturer { get; set; }
        public string GFXName { get; set; }
        public string Frequency { get; set; }
        public string Memory { get; set; }

        public EditGraphicCard(GraphicCard graphicCard)
        {
            GraphicCard = graphicCard;
            Original = new GraphicCard()
            {
                Id = graphicCard.Id,
                Name = graphicCard.Name,
                Manufacturer = graphicCard.Manufacturer,
                Frequency = graphicCard.Frequency,
                Memory = graphicCard.Memory
            };
            Manufacturer = GraphicCard.Manufacturer;
            GFXName = GraphicCard.Name;
            Frequency = GraphicCard.Frequency.ToString();
            Memory = GraphicCard.Memory.ToString();
            InitializeComponent();
            DataContext = this;
        }

        private void EditGraphicsCard_Click(object sender, RoutedEventArgs e)
        {
            Edit();
            Debug.WriteLine("Changed Frequency: " + GraphicCard.Frequency.ToString());
            Debug.WriteLine("Original Frequency: " + Original.Frequency.ToString());
        }

        private void Edit()
        {
            using (var context = new DesktopBuildsContext())
            {
                if (GFXName != GraphicCard.Name) GraphicCard.Name = GFXName;

                if (Manufacturer != GraphicCard.Manufacturer) GraphicCard.Manufacturer = Manufacturer;

                int f;
                if (int.TryParse(Frequency, out f) && GraphicCard.Frequency != f) GraphicCard.Frequency = f;

                int m;
                if (int.TryParse(Memory, out m) && GraphicCard.Memory != m) GraphicCard.Memory = m;

                if (GraphicCard.Name != Original.Name ||
                    GraphicCard.Manufacturer != Original.Manufacturer ||
                    GraphicCard.Frequency != Original.Frequency ||
                    GraphicCard.Memory != Original.Memory)
                {
                    context.GraphicCards.Update(GraphicCard);
                    context.SaveChanges();
                    Close();
                }
            }
        }
    }
}
