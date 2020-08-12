using DesktopBuilds.Data;
using DesktopBuilds.Domain;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;

using System.Windows;


namespace DesktopBuilds.UI
{
    public partial class EditComponent : Window, INotifyPropertyChanged
    {
        private void OnPropertyChanged(string v)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<object> ItemsToEdit
        {
            get
            {
                return itemsToEdit;
            }
            set
            {
                itemsToEdit = value;
                OnPropertyChanged("ItemsToEdit");
            }
        }
        ObservableCollection<object> itemsToEdit = new ObservableCollection<object>();

        public object SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                if (selectedItem != null) SelectedType = selectedItem.GetType().ToString();
                else selectedType = "";
                OnPropertyChanged("SelectedItem");
            }
        }
        object selectedItem;

        public string SelectedType
        {
            get
            {
                return selectedType;
            }
            set
            {
                string[] s = value.Split('.');
                selectedType = s[s.Length - 1];
                OnPropertyChanged("SelectedType");
            }
        }
        string selectedType;


        public EditComponent()
        {
            InitializeComponent();
            DataContext = this;
            FillList();
        }

        private void FillList()
        {
            int index;
            if (SelectedItem == null) index = 0;
            else index = ItemsToEdit.IndexOf(SelectedItem);

            ItemsToEdit.Clear();
            using (var context = new DesktopBuildsContext())
            {
                var c = context.CPUs;
                var mo = context.Motherboards;
                var me = context.Rams;
                var g = context.GraphicCards;
                var d = context.Desktops;
                foreach (CPU cpu in c)
                {
                    ItemsToEdit.Add(cpu);
                }
                foreach (Motherboard m in mo)
                {
                    ItemsToEdit.Add(m);
                }
                foreach (Ram m in me)
                {
                    ItemsToEdit.Add(m);
                }
                foreach (GraphicCard graphicCard in g)
                {
                    ItemsToEdit.Add(graphicCard);
                }
                foreach (Desktop desktop in d)
                {
                    ItemsToEdit.Add(desktop);
                }
                SelectedItem = ItemsToEdit[index];
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedItem();
        }

        private void EditSelectedItem()
        {
            Window edit = null;
            if (SelectedItem.GetType() == typeof(Desktop)) edit = new EditDesktop(SelectedItem as Desktop);
                
            if (SelectedItem.GetType() == typeof(CPU)) edit = new EditCPU(SelectedItem as CPU);

            if (SelectedItem.GetType() == typeof(Ram)) edit = new EditRam(SelectedItem as Ram);

            if (SelectedItem.GetType() == typeof(Motherboard)) edit = new EditMotherboard(SelectedItem as Motherboard);

            if (SelectedItem.GetType() == typeof(GraphicCard)) edit = new EditGraphicCard(SelectedItem as GraphicCard);

            if (edit != null)
            {
                edit.Closed += Window_Closed;
                edit.Show();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedItem();
        }

        private void DeleteSelectedItem()
        {
            using (var context = new DesktopBuildsContext())
            {
                try
                {
                    if (selectedItem.GetType() == typeof(Desktop)) context.Desktops.Remove(selectedItem as Desktop);
                    else if (selectedItem.GetType() == typeof(GraphicCard)) context.GraphicCards.Remove(selectedItem as GraphicCard);
                    else if (selectedItem.GetType() == typeof(Motherboard)) context.Motherboards.Remove(selectedItem as Motherboard);
                    else if (selectedItem.GetType() == typeof(CPU)) context.CPUs.Remove(selectedItem as CPU);
                    else if (selectedItem.GetType() == typeof(Ram)) context.Rams.Remove(selectedItem as Ram);
                    context.SaveChanges();
                    FillList();
                }
                catch
                {
                    Debug.WriteLine("Item was a part of current desktop");
                }
            }
            return;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            FillList();
        }
    }
}
