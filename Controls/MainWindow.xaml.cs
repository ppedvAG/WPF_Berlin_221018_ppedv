using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
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

namespace Controls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Event-Handler für das Click-Event des Buttons
        private void Btn_KlickMich_Click(object sender, RoutedEventArgs e)
        {
            //Neuzuweisung der Content-Eigenschaft des Labels mit dem ausgewählten Inhalt der ComboBox
            Lbl_Output.Content = (Cbb_Auswahl.SelectedItem as ComboBoxItem)?.Content;

            //Änderung der Hintergrundfarbe des Fensters
            this.Background = new SolidColorBrush(Colors.Blue);

            //MessageBox mit dem Inhalt der TextBox
            MessageBox.Show(Tbx_Input.Text);

            //Prüfung, ob die Checkbox abgehakt ist
            if (Cbx_Haken.IsChecked == true)
                //Anzeige einer MessageBox mit Inhalt der TextBox und Auswahl der ComboBox
                MessageBox.Show(Tbx_Input.Text + "\n" + Cbb_Auswahl.Text);
        }

        private void Schließen_Click(object sender, RoutedEventArgs e)
        {
            if
                (
                    MessageBox.Show
                    (
                       "Soll das Fanster wirklich geschlossen werden?",
                       "Fenster schließen",
                       MessageBoxButton.YesNo,
                       MessageBoxImage.Warning
                    ) == MessageBoxResult.Yes
                )
            {
                //Schließen des Fensters
                this.Close();

                //oder Beenden der Applikation
                Application.Current.Shutdown();
            }
        }

        private void Neu_Click(object sender, RoutedEventArgs e)
        {
            Window window = new MainWindow();

            window.Title = "Neues Fenster";

            //Öffen eines neuen Fensters als gleichberechtigtes Fenster
            window.Show();
        }

        private void Dialog_Click(object sender, RoutedEventArgs e)
        {
            Window window = new MainWindow();

            window.Title = "Neues Dialog-Fenster";

            //Öffnen eines neuen Fensters als Dialogfenster mit Rückgabe des DialogResults
            if (window.ShowDialog() == true)
                Lbl_Output.Content = "TRUE";
        }

        private void Btn_OK_Click(object sender, RoutedEventArgs e)
        {
            //Setzen des Dialog-Results
            this.DialogResult = true;
        }
    }
}
