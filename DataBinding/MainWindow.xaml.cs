using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Person> Personenliste { get; set; } = new ObservableCollection<Person>()
        {
            new Person(){Vorname="Anna", Nachname="Nass", Alter=35},
            new Person(){Vorname="Rainer", Nachname="Zufall", Alter=41},
        };

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        private void Btn_Show_Click(object sender, RoutedEventArgs e)
        {
            Person person = Spl_DataContextBsp.DataContext as Person;

            MessageBox.Show($"{person.Vorname} {person.Nachname} ({person.Alter})");
        }

        private void Btn_Altern_Click(object sender, RoutedEventArgs e)
        {
            Person person = Spl_DataContextBsp.DataContext as Person;

            person.Alter++;
        }

        private void Btn_New_Click(object sender, RoutedEventArgs e)
        {
            Personenliste.Add(new Person() { Vorname = "Maria", Nachname = "Meier", Alter = 21 });
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Lbx_Personen.SelectedItem != null)
                Personenliste.Remove(Lbx_Personen.SelectedItem as Person);
        }
    }
}
