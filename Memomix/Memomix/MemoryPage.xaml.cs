using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace Memomix
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MemoryPage : Page
    {
        public MemoryPage()
        {
            this.InitializeComponent();
            LevelNameText.Text = "Niveau " + App.LevelId;
            SetCardsForLevel(App.LevelId);
        }

        private void SetCardsForLevel(int levelId)
        {
            var cardsId = new List<int>() { 1, 2, 3, 4, 5, 6 };
            var player1Cards = this.Player1Grid.Children;
            var player2Cards = this.Player2Grid.Children;

            //removing validator
            player2Cards.RemoveAt(3);

            /*
            Tirage aléatoire dans la liste d'identifiants
            On affecte une image a deux enfants
            on "retire" les enfants 
            le dernier enfant est l'intrus
            On active un bool intrus
            */


            // foreach (UIElement elem in this.Player1Grid)

        }

        public int GetRandomNumber(int minimum, int maximum)
        {
            Random random = new Random();
            return random.Next() * (maximum - minimum) + minimum;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(MainPage), null, new SuppressNavigationTransitionInfo());
            Frame.GoBack();

        }
    }
}
