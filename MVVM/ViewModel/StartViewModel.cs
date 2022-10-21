using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM.ViewModel
{
    internal class StartViewModel : INotifyPropertyChanged
    {
        public int AnzahlPerson { get { return Model.Person.Personenliste.Count; } }

        public CustomCommand LadeDbCmd { get; set; }

        public CustomCommand ÖffneDbCmd { get; set; }

        public StartViewModel()
        {
            LadeDbCmd = new CustomCommand
                (
                    p =>
                    {
                        Model.Person.GetPersonsFromDb();
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AnzahlPerson)));
                    },
                    p => AnzahlPerson == 0
                );

            ÖffneDbCmd = new CustomCommand
                (
                    p =>
                    {
                        //TODO: Nächstes Fenster öffnen

                        (p as Window).Close();
                    },
                    p => AnzahlPerson > 0
                );
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
