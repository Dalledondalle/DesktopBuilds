using DesktopBuilds.Domain;
using DesktopBuilds.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuild.UI
{
    class Program
    {
        static Ram ram;
        static CPU cpu;
        static Motherboard motherboard;
        static GraphicCard graphicCard;
        static Desktop desktop;
        static void Main(string[] args)
        {
            MakeNewCPU();
            MakeNewMemory();
            MakeNewMotherboard();
            MakeNewGraphicCard();
            MakeNewDesktop();
            SaveAll();
        }

        private static void MakeNewMemory()
        {
            ram = new Ram
            {
                Name = "SuperRam3000",
                Capacity = 8,
                Frequency = 2333,
                Generation = "ddr3",
                Manufacturer = "Corsair"
            };            
        }
        private static void MakeNewCPU()
        {
            cpu = new CPU
            {
                Cache = 8,
                DefaultFrequency = 3.4f,
                MaxFrequency = 5.0f,
                Manufacturer = "Intel",
                Name = "9900k"
            };
        }
        private static void MakeNewMotherboard()
        {
            motherboard = new Motherboard
            {
                Socket = "LGA1241",
                Manufacturer = "Asus",
                PCICount = 1,
                PCIEx16Count = 3,
                PCIExCount = 1,
                Name = "GamingRoxSuper"
            };
        }
        private static void MakeNewGraphicCard()
        {
            graphicCard = new GraphicCard
            {
                Name = "GTX1080",
                Manufacturer = "Nvidia",
                Frequency = 2100,
                Memory = 8,
            };
        }
        private static void MakeNewDesktop()
        {
            desktop = new Desktop
            {
                Ram = ram,
                CPU = cpu,
                Motherboard = motherboard,
                GraphicCard = graphicCard,
            };
        }
        private static void SaveAll()
        {
            using (var context = new DesktopBuildsContext())
            {
                context.Rams.Add(ram);
                context.CPUs.Add(cpu);
                context.Motherboards.Add(motherboard);
                context.GraphicCards.Add(graphicCard);
                context.Desktops.Add(desktop);
                context.SaveChanges();
            }
        }
    }
}
