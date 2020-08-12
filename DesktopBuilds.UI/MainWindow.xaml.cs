using DesktopBuilds.Domain;
using DesktopBuilds.Data;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopBuilds.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EditComponent EditComponent;
        MakeCPU MakeCPU;
        MakeDesktop MakeDesktop;
        MakeGraphicCard MakeGraphicCard;
        MakeMotherboard MakeMotherboard;
        MakeRAM MakeRAM;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OpenCPUWindow()
        {
            MakeCPU = new MakeCPU();
            MakeCPU.Show();
        }
        private void OpenGraphicCardWindow()
        {
            MakeGraphicCard = new MakeGraphicCard();
            MakeGraphicCard.Show();
        }
        private void OpenMotherboardWindow()
        {
            MakeMotherboard = new MakeMotherboard();
            MakeMotherboard.Show();
        }
        private void OpenRAMWindow()
        {
            MakeRAM = new MakeRAM();
            MakeRAM.Show();
        }
        private void OpenDesktopWindow()
        {
            MakeDesktop = new MakeDesktop();
            MakeDesktop.Show();
        }
        private void OpenEditComponentWindow()
        {
            EditComponent = new EditComponent();
            EditComponent.Show();
        }
        private void NewCPU_Click(object sender, RoutedEventArgs e)
        {
            OpenCPUWindow();
        }
        private void NewGraphicCard_Click(object sender, RoutedEventArgs e)
        {
            OpenGraphicCardWindow();
        }
        private void NewMotherboard_Click(object sender, RoutedEventArgs e)
        {
            OpenMotherboardWindow();
        }
        private void NewRAM_Click(object sender, RoutedEventArgs e)
        {
            OpenRAMWindow();
        }
        private void NewDesktop_Click(object sender, RoutedEventArgs e)
        {
            OpenDesktopWindow();
        }
        private void EditComponent_Click(object sender, RoutedEventArgs e)
        {
            OpenEditComponentWindow();
        }        
    }
}
