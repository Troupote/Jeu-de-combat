
using System.Windows;

namespace projet_de_combat_2
{
    public partial class StartWindow : Window
    {

        public StartWindow()
        {
            InitializeComponent();
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            Window1 selectionWindow = new Window1();
            selectionWindow.Show();
            this.Close();
        }

        private void QuitGame(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}



