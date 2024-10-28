using projet_de_combat_2;
using System.Windows;

namespace projet_de_combat_2
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        
        
        // Gestion de la sélection du Guerrier
        private void SelectDamager(object sender, RoutedEventArgs e)
        {
            // Ouvre la fenêtre principale avec le Guerrier comme personnage sélectionné
            MainWindow gameWindow = new MainWindow("Damager");
            gameWindow.Show();
            this.Close();
        }

        // Gestion de la sélection du Mage
        private void SelectHealer(object sender, RoutedEventArgs e)
        {
            MainWindow gameWindow = new MainWindow("Healer");
            gameWindow.Show();
            this.Close();
        }

        // Gestion de la sélection de l'Archer
        private void SelectTank(object sender, RoutedEventArgs e)
        {
            MainWindow gameWindow = new MainWindow("Tank");
            gameWindow.Show();
            this.Close();
        }

        // Gestion de la sélection de l'Assassin
        private void SelectPierre(object sender, RoutedEventArgs e)
        {
            MainWindow gameWindow = new MainWindow("Pierre");
            gameWindow.Show();
            this.Close();
        }
    }
}