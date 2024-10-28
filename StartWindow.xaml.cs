using System.Runtime.CompilerServices;
using System.Security.Cryptography.Pkcs;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace projet_de_combat_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //player + perso affichage
        int PlayerDommage;
        int PlayerHealt;
        int PlayerHealtTot;
        private string selectedCharacter;

        //spell damager
        int PlayerRage = 0;
        int IaRage = 0;

        //image
        Image characterImage = new Image();
        Image iaCharacterImage = new Image();

        string imagePath = "";
        string iaImagePath = "";

        //Pierre Player
        int easterEggHealt = new Random().Next(1, 8);
        int easterEggDamage = new Random().Next(1, 8);

        //Pierre Ia
        int iaEasterEggHealt = new Random().Next(1, 8);
        int iaEasterEggDamage = new Random().Next(1, 8);

        //Ia
        public int IaChoice = new Random().Next(1, 5);
        int IaHealt;
        int IaHealtTot;
        int IaDommage;
        int OldHealt = 0;

        //défense
        bool PlayerDefense = false;
        int OldPlayerDommage = 0;

        public MainWindow(string choixPerso)
        {
            InitializeComponent();
            selectedCharacter = choixPerso;
            SetupCharacter();
        }

        // Méthode pour initialiser le personnage en fonction du choix de l'utilisateur
        // Méthode pour initialiser le personnage en fonction du choix de l'utilisateur
        private void SetupCharacter()
        {
            if (selectedCharacter == "Tank")
            {
                PlayerHealt = 5;
                PlayerHealtTot = 5;
                PlayerDommage = 1;
                UserHealthBar.Maximum = PlayerHealtTot;
                UserHealthBar.Value = PlayerHealt;
                UserHealthText.Text = $"Points de Vie : {PlayerHealt}";
            }
            else if (selectedCharacter == "Damager")
            {
                PlayerDommage = 2;
                PlayerHealt = 3;
                PlayerHealtTot = 3;
                UserHealthBar.Maximum = PlayerHealtTot;
                UserHealthBar.Value = PlayerHealt;
                UserHealthText.Text = $"Points de Vie : {PlayerHealt}";
            }
            else if (selectedCharacter == "Healer")
            {
                PlayerHealtTot = 4;
                PlayerHealt = 4;
                PlayerDommage = 1;
                UserHealthBar.Maximum = PlayerHealtTot;
                UserHealthBar.Value = PlayerHealt;
                UserHealthText.Text = $"Points de Vie : {PlayerHealt}";
            }
            else if (selectedCharacter == "Pierre")
            {
                PlayerHealtTot = easterEggHealt;
                PlayerHealt = easterEggHealt;
                PlayerDommage = easterEggDamage;
                UserHealthBar.Maximum = PlayerHealtTot;
                UserHealthBar.Value = PlayerHealt;
                UserHealthText.Text = $"Points de Vie : {PlayerHealt}";
            }

            switch (selectedCharacter)
            {
                case "Tank":
                    imagePath = "/Personnage/Bran.png";
                    break;
                case "Damager":
                    imagePath = "/Personnage/DamagerCharacter.png";
                    break;
                case "Healer":
                    imagePath = "/Personnage/Elyndra.png";
                    break;
                case "Pierre":
                    imagePath = "/Personnage/pierre.png";
                    break;
                default:
                    MessageBox.Show("Personnage inconnu");
                    return;
            }

            switch (IaChoice)
            {
                case 1:
                    iaImagePath = "/Personnage/Bran.png";
                    IaHealt = 5;
                    IaHealtTot = 5;
                    IaDommage = 1;
                    EnemyHealthBar.Maximum = IaHealtTot;
                    EnemyHealthBar.Value = IaHealt;
                    EnemyHealthText.Text = $"Points de Vie : {IaHealt}";
                    break;
                case 2:
                    iaImagePath = "/Personnage/DamagerCharacter.png";
                    IaDommage = 2;
                    IaHealt = 3;
                    IaHealtTot = 3;
                    EnemyHealthBar.Maximum = IaHealtTot;
                    EnemyHealthBar.Value = IaHealt;
                    EnemyHealthText.Text = $"Points de Vie : {IaHealt}";

                    break;
                case 3:
                    iaImagePath = "/Personnage/Elyndra.png";
                    IaHealt = 4;
                    IaHealtTot = 4;
                    IaDommage = 1;
                    EnemyHealthBar.Maximum = IaHealtTot;
                    EnemyHealthBar.Value = IaHealt;
                    EnemyHealthText.Text = $"Points de Vie : {IaHealt}";
                    break;
                case 4:
                    iaImagePath = "/Personnage/pierre.png";
                    IaDommage = iaEasterEggDamage;
                    IaHealt = iaEasterEggHealt;
                    IaHealtTot = iaEasterEggHealt;
                    EnemyHealthBar.Maximum = IaHealtTot;
                    EnemyHealthBar.Value = IaHealt;
                    EnemyHealthText.Text = $"Points de Vie : {IaHealt}";
                    break;
                default:
                    MessageBox.Show("Personnage inconnu");
                    return;
            }

            // Charger l'image depuis le chemin spécifié
            characterImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            iaCharacterImage.Source = new BitmapImage(new Uri(iaImagePath, UriKind.Relative));

            // Définir la taille de l'image si nécessaire
            characterImage.Width = 275; // Ajuste la largeur
            characterImage.Height = 275; // Ajuste la hauteur

            // pour Scale -1
            // Appliquer la transformation d'échelle pour faire un effet miroir (inverser sur l'axe X)
            ScaleTransform flipTransform = new ScaleTransform();
            flipTransform.ScaleX = -1;  // Inverser l'image horizontalement
            flipTransform.ScaleY = 1;   // Ne pas inverser verticalement

            if (iaImagePath == "/Personnage/Bran.png")
            {
                //sens de l'image
                iaCharacterImage.RenderTransform = flipTransform;

                flipTransform.ScaleX = -1;
                //taille image Ia
                iaCharacterImage.Width = 275; // Ajuste la largeur
                iaCharacterImage.Height = 275; // Ajuste la hauteur

                Canvas.SetLeft(iaCharacterImage, 60); // Position X
                Canvas.SetTop(iaCharacterImage, -20); // Position Y
            }
            else if (iaImagePath == "/Personnage/DamagerCharacter.png")
            {
                //taille image Ia
                iaCharacterImage.Width = 300; // Ajuste la largeur
                iaCharacterImage.Height = 300; // Ajuste la hauteur

                Canvas.SetLeft(iaCharacterImage, -50); // Position X
                Canvas.SetTop(iaCharacterImage, 0); // Position Y
            }
            else if (iaImagePath == "/Personnage/Elyndra.png")
            {
                //taille image Ia
                iaCharacterImage.Width = 275; // Ajuste la largeur
                iaCharacterImage.Height = 275; // Ajuste la hauteur

                Canvas.SetLeft(iaCharacterImage, -60); // Position X
                Canvas.SetTop(iaCharacterImage, -20); // Position Y
            }
            else if (iaImagePath == "/Personnage/pierre.png")
            {
                //taille image Ia
                iaCharacterImage.Width = 400; // Ajuste la largeur
                iaCharacterImage.Height = 400; // Ajuste la hauteur
                                               // Positionner le personnage dans la zone de combat
                Canvas.SetLeft(iaCharacterImage, -125); // Position X
                Canvas.SetTop(iaCharacterImage, -15); // Position Y
            }

            //Player image
            if (imagePath == "/Personnage/Bran.png")
            {
                //taille image Player Tank
                characterImage.Width = 250; // Ajuste la largeur
                characterImage.Height = 250; // Ajuste la hauteur

                Canvas.SetLeft(characterImage, -55); // Position X
                Canvas.SetTop(characterImage, -10); // Position Y
            }
            else if (imagePath == "/Personnage/DamagerCharacter.png")
            {
                //taille image Player Damager
                characterImage.Width = 300; // Ajuste la largeur
                characterImage.Height = 300; // Ajuste la hauteur

                Canvas.SetLeft(characterImage, -55); // Position X
                Canvas.SetTop(characterImage, -10); // Position Y
            }
            else if (imagePath == "/Personnage/Elyndra.png")
            {
                //sens image
                characterImage.RenderTransform = flipTransform;
                flipTransform.ScaleX = -1;

                //taille image Player healer
                characterImage.Width = 275; // Ajuste la largeur
                characterImage.Height = 275; // Ajuste la hauteur

                Canvas.SetLeft(characterImage, 140); // Position X
                Canvas.SetTop(characterImage, -25); // Position Y
            }
            else if (imagePath == "/Personnage/pierre.png")
            {
                //sens image
                characterImage.RenderTransform = flipTransform;

                flipTransform.ScaleX = -1;
                //taille image Player pierre
                characterImage.Width = 400; // Ajuste la largeur
                characterImage.Height = 400; // Ajuste la hauteur

                // Positionner le personnage dans la zone de combat
                Canvas.SetLeft(characterImage, 105); // Position X
                Canvas.SetTop(characterImage, -55); // Position Y
            }



            // Ajouter l'image à la zone de combat
            CombatArea.Children.Add(characterImage);
            IaCombatArea.Children.Add(iaCharacterImage);

        }


        int tempPlayerAction = 0;

        async void DamagePlayer(object sender, RoutedEventArgs e)
        {
            tempPlayerAction = 1;
            ApplyDamage();
            await Task.Delay(2900);
        }

        async void DefensePlayer(object sender, RoutedEventArgs e)
        {
            tempPlayerAction = 2;
            ApplyDamage();
            await Task.Delay(2900);
        }

        async void Special(object sender, RoutedEventArgs e)
        {
            tempPlayerAction = 3;
            ApplyDamage();
            await Task.Delay(2900);
        }

        int randomIaAction()
        {
            return new Random().Next(1, 4);
        }

        int playerAction = 0;
        private async void ApplyDamage()
        {
            int tempPlayerDmg = 0;
            int tempIaDmg = 0;
            bool isPlayerUsingSpecial = false;
            bool isIaUsingSpecial = false;
            bool isPlayerDefending = false;
            bool isIaDefending = false;
            playerAction = tempPlayerAction;
            int atkPierre = new Random().Next(1, 3);
            int IaAtkPierre = new Random().Next(1, 3);

            // Gestion des actions du joueur  
            switch (playerAction)
            {
                case 1:
                    tempPlayerDmg = PlayerDommage;
                    UserHealthBar.Maximum = PlayerHealtTot;
                    UserHealthBar.Value = PlayerHealt;
                    UserHealthText.Text = $"Points de Vie : {PlayerHealt}";
                    Infocombat.Text = $"Vous attaquez et vous infligez {tempPlayerDmg} \n a l'ordinateur, il lui reste {IaHealt - tempPlayerDmg} pv";
                    break;
                case 2:
                    isPlayerDefending = true;
                    UserHealthBar.Maximum = PlayerHealtTot;
                    UserHealthBar.Value = PlayerHealt;
                    UserHealthText.Text = $"Points de Vie : {PlayerHealt}";
                    Infocombat.Text = "\nVous vous défendez et réduisez donc les dégâts subis.";
                    break;
                case 3:
                    isPlayerUsingSpecial = true;
                    Infocombat.Text = "Le joueur utilise sa capacité spéciale";
                    if (selectedCharacter == "Damager")
                    {
                        tempPlayerDmg += IaDommage;
                        UserHealthBar.Maximum = PlayerHealtTot;
                        UserHealthBar.Value = PlayerHealt;
                        UserHealthText.Text = $"Points de Vie : {PlayerHealt}";
                        Infocombat.Text = $"Vous faites votre attaque spécial, vous renvoyez \nles dégats mais vous les encaissez également.";
                    }
                    else if (selectedCharacter == "Healer")
                    {
                        PlayerHealt += 2;
                        PlayerHealtTot += 2;
                        UserHealthBar.Maximum = PlayerHealtTot;
                        UserHealthBar.Value = PlayerHealt;
                        UserHealthText.Text = $"Points de vie : {PlayerHealt}";
                        Infocombat.Text = $"Vous faites votre attaque spécial, \nvous gagnez 2 point de vie ce \nqui vous rends a {PlayerHealt + 2} pv";
                    }
                    else if (selectedCharacter == "Tank")
                    {
                        PlayerHealt -= 1;
                        tempPlayerDmg = 2;
                        Infocombat.Text = $"Vous faites votre attaque spécial, vous perdez \n1 point de vie et vous gagnez 1 point \n d'attaque vous avez donc \n{PlayerHealt} pv et infligez 2 de dégats";
                    }
                    else if (selectedCharacter == "Pierre")
                    {
                        switch (atkPierre)
                        {
                            case 1:
                                PlayerHealt += 3;
                                PlayerHealtTot += 3;
                                PlayerDommage += 3;

                                Infocombat.Text = $"Par le pouvoir de CHAISE et THYBAULT que les dieux \n me viennent en aide... \n vos stats ont miraculeusement augmenter vous avez désormé : \n{PlayerHealt} PV et {PlayerDommage} de dégats";
                                UserHealthBar.Maximum = PlayerHealtTot;
                                UserHealthBar.Value = PlayerHealt;
                                UserHealthText.Text = $"Points de Vie : {PlayerHealt}";

                                break;
                            case 2:
                                PlayerHealt -= 3;
                                PlayerHealtTot -= 3;
                                PlayerDommage -= 3;

                                Infocombat.Text = $"Par le pouvoir de CHAISE et THYBAULT que les dieux \n me viennent en aide... \n les dieux vous ont punis et ont fait régrésser vos stats : \n{PlayerHealt} PV et {PlayerDommage} de dégats";
                                UserHealthBar.Maximum = PlayerHealtTot;
                                UserHealthBar.Value = PlayerHealt;
                                UserHealthText.Text = $"Points de Vie : {PlayerHealt}";
                                break;
                        }
                    }
                    break;
                default:
                    Infocombat.Text = "Action invalide. Veuillez choisir une action valide.";
                    return;
            }

            await Task.Delay(1000);

            // Gestion des actions de l'IA  
            switch (randomIaAction())
            {
                case 1:
                    tempIaDmg = IaDommage;
                    EnemyHealthBar.Value = IaHealt;
                    EnemyHealthText.Text = $"Points de vie : {IaHealt}";
                    Infocombat.Text = $"L'Ordinateur vous attaque et vous infliges \n{tempIaDmg} il vous reste {PlayerHealt - tempIaDmg} pv";
                    break;
                case 2:
                    isIaDefending = true;
                    EnemyHealthBar.Value = IaHealt;
                    EnemyHealthText.Text = $"Points de vie : {IaHealt}";
                    Infocombat.Text += "\nL'ordinateur se défend et réduit les dégâts subis.";
                    break;
                case 3:
                    isIaUsingSpecial = true;
                    Infocombat.Text += "\nL'ordinateur utilise sa capacité spéciale";
                    if (IaChoice == 2)
                    {
                        tempIaDmg += PlayerDommage;
                        EnemyHealthBar.Maximum = IaHealtTot;
                        EnemyHealthBar.Value = IaHealt;
                        EnemyHealthText.Text = $"Points de vie : {IaHealt}";
                        Infocombat.Text = $"L'Ordinateur fait son attaque spécial,\n il vous renvoie vos dégats, \n mais les encaisses également.";
                    }
                    else if (IaChoice == 3)
                    {
                        IaHealt += 2;
                        IaHealtTot += 2;
                        EnemyHealthBar.Maximum = IaHealtTot;
                        EnemyHealthBar.Value = IaHealt;
                        EnemyHealthText.Text = $"Points de vie : {IaHealt}";
                        Infocombat.Text = $"L'Ordinateur fait son attaque \nspécial, il gagne 2 point \n de vie ce qui le rend a {IaHealt} pv";
                    }
                    else if (IaChoice == 1)
                    {
                        IaHealt -= 1;
                        tempIaDmg = 2;
                        EnemyHealthBar.Value = IaHealt;
                        EnemyHealthText.Text = $"Points de vie : {IaHealt}";
                        Infocombat.Text = $"L'Ordinateur fais son attaque spécial, \nil perds 1 point de vie et \n gagne 1 point d'attaque il \nest donc a {IaHealt} pv";
                    }
                    else if (IaChoice == 4)
                    {
                        switch (IaAtkPierre)
                        {
                            case 1:
                                IaHealt += 3;
                                IaHealtTot += 3;
                                IaDommage += 3;
                                Infocombat.Text = $"Par le pouvoir de CHAISE et THYBAULT que les dieux \n me viennent en aide... \n les stats de l'ordinateur ont miraculeusement augmenter il a désormé : \n{PlayerHealt} PV et {PlayerDommage} de dégats";
                                EnemyHealthBar.Maximum = IaHealtTot;
                                EnemyHealthBar.Value = IaHealt;
                                EnemyHealthText.Text = $"Points de Vie : {IaHealt}";

                                break;
                            case 2:
                                IaHealt -= 3;
                                IaHealtTot -= 3;
                                IaDommage -= 3;
                                Infocombat.Text = $"Par le pouvoir de CHAISE et THYBAULT que les dieux \n me viennent en aide... \n les dieux ont punis l'ordinateur et ont fait régrésser \n ses stats il a désormé: \n{PlayerHealt} PV et {PlayerDommage} de dégats";
                                EnemyHealthBar.Maximum = IaHealtTot;
                                EnemyHealthBar.Value = IaHealt;
                                EnemyHealthText.Text = $"Points de Vie : {IaHealt}";

                                break;
                        }
                    }
                    break;
            }

            // Application des dégâts  
            if (isPlayerDefending)
            {
                if (IaChoice == 3 && isIaUsingSpecial)
                {
                    PlayerHealt -= 1;
                    UserHealthBar.Value = PlayerHealt;
                    UserHealthText.Text = $"Points de Vie : {PlayerHealt}";
                    Infocombat.Text += "\nLe joueur défend mais subit 1 point de dégât à cause de la capacité spéciale du Tank.";
                    if (PlayerHealt <= 0)
                    {
                        StartCombat.Text = "\nL'ordinateur a gagné!";
                        StartCombat.Visibility = Visibility.Visible;
                        AffichageAttaque.Visibility = Visibility.Collapsed;
                    }

                }
                else
                {
                    Infocombat.Text += "\nLe joueur défend et ne subit aucun dégât.";
                }
            }
            else if (isIaDefending)
            {
                if (selectedCharacter == "Tank" && isPlayerUsingSpecial)
                {
                    IaHealt -= 1;
                    EnemyHealthBar.Value = IaHealt;
                    EnemyHealthText.Text = $"Points de Vie : {IaHealt}";
                    Infocombat.Text += "\nL'IA défend mais subit 1 point de dégât à cause de la capacité spéciale du Tank.";
                    if (IaHealt <= 0)
                    {
                        StartCombat.Text = "\nLe joueur a gagné!";
                        StartCombat.Visibility = Visibility.Visible;
                        AffichageAttaque.Visibility = Visibility.Collapsed;

                    }
                }
                else
                {
                    Infocombat.Text += "\nL'IA défend et ne subit aucun dégât.";
                }
            }
            else
            {
                PlayerHealt -= tempIaDmg;
                IaHealt -= tempPlayerDmg;
                UserHealthBar.Value = PlayerHealt;
                UserHealthText.Text = $"Points de Vie : {PlayerHealt}";
                EnemyHealthBar.Value = IaHealt;
                EnemyHealthText.Text = $"Points de Vie : {IaHealt}";
                Infocombat.Text += $"\nLe joueur subit {tempIaDmg} points de dégâts.";
                Infocombat.Text += $"\nL'adversaire subit {tempPlayerDmg} points de dégâts.";

                if (PlayerHealt <= 0 && IaHealt <= 0) 
                {
                    StartCombat.Text = "\nLes deux combattants sont morts!";
                    StartCombat.Visibility = Visibility.Visible;
                    AffichageAttaque.Visibility = Visibility.Collapsed;
                }
                else if (PlayerHealt <= 0)
                {
                    StartCombat.Text = "\nL'ordinateur a gagné!";
                    StartCombat.Visibility = Visibility.Visible;
                    AffichageAttaque.Visibility = Visibility.Collapsed;
                }
                else if (IaHealt <= 0)
                {
                    StartCombat.Text = "\nLe joueur a gagné!";
                    StartCombat.Visibility = Visibility.Visible;
                    AffichageAttaque.Visibility = Visibility.Collapsed;
                }

            }

        }
    }
}
