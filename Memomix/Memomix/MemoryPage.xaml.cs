using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
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
        private int intruderId;
        private int currentPlayer1CardId;
        public MemoryPage()
        {
            this.InitializeComponent();
            LevelNameText.Text = "Niveau " + App.LevelId;
            
            this.ValidatorCard.IsValidator = true;
            this.RegisterMemoryCardsEvents();
            Loaded += MemoryPage_Loaded;
        }

        private void MemoryPage_Loaded(object sender, RoutedEventArgs e)
        {
            SetCardsForLevel(App.LevelId);
        }

         

        private void RegisterMemoryCardsEvents()
        {
            Card1.MemoryCardOpened += Player1Card_MemoryCardOpened;
            Card2.MemoryCardOpened += Player1Card_MemoryCardOpened;
            Card3.MemoryCardOpened += Player1Card_MemoryCardOpened;
            Card4.MemoryCardOpened += Player1Card_MemoryCardOpened;
            Card5.MemoryCardOpened += Player1Card_MemoryCardOpened;
            Card6.MemoryCardOpened += Player1Card_MemoryCardOpened;
            Card7.MemoryCardOpened += Player2Card_MemoryCardOpened;
            Card8.MemoryCardOpened += Player2Card_MemoryCardOpened;
            Card10.MemoryCardOpened += Player2Card_MemoryCardOpened;
            ValidatorCard.MemoryCardOpened += ValidatorCardOpened;
            Card11.MemoryCardOpened += Player2Card_MemoryCardOpened;
            Card12.MemoryCardOpened += Player2Card_MemoryCardOpened;
        }

        /*
         * A card from player one has been opened
         */
        private void Player1Card_MemoryCardOpened(object sender, EventArgs e)
        {
            var memoryCard = sender as MemoryCard;
            this.currentPlayer1CardId = memoryCard.CardId;
            CloseMemoryCards(Player1Grid.Children, memoryCard);
        }

        /*
         * A card from player two has been opened
         */
        private void Player2Card_MemoryCardOpened(object sender, EventArgs e)
        {
            var memoryCard = sender as MemoryCard;
            CloseMemoryCards(Player2Grid.Children, memoryCard);
        }

        /*
         * The validator has been selected
         * We should check if a card is opened in player one grid and if the opened image is the intruder
         * Then show the win or game over next page
         * 
         */
        private void ValidatorCardOpened(object sender, EventArgs e)
        {
            var validator = sender as MemoryCard;
            CloseMemoryCards(Player2Grid.Children, validator);

            if (currentPlayer1CardId == intruderId)
            {
                Debug.WriteLine("BIG WIN");
                App.HasWon = true;
                Frame.Navigate(typeof(EndPage), null, new SuppressNavigationTransitionInfo());
            }
            else
            {
                Debug.WriteLine("BIG LOOSE");
                App.HasWon = false;
                Frame.Navigate(typeof(EndPage), null, new SuppressNavigationTransitionInfo());
            }
        }

        private void CloseMemoryCards(UIElementCollection children, MemoryCard except)
        {
            foreach(UIElement child in children)
            {
                var memCard = child as MemoryCard;
                if (child != except && memCard.IsValidator == false)
                {
                    memCard.Close();
                }
            }
        }
        private void SetCardsForLevel(int levelId)
        {
            var nextCardsImagesIds = new List<int>() { 1, 2, 3, 4, 5, 6 };
            var player1MemoryCardsId = new List<int>() { 0, 1, 2, 3, 4, 5 };
            var player2MemoryCardsId = new List<int>() { 0, 1, 3, 4, 5 }; // the second child is the validator so remove it (doesnt need a card)      

            //Randomization of the cards ids and memory cards children ids
            nextCardsImagesIds.Shuffle();
            player1MemoryCardsId.Shuffle();
            player2MemoryCardsId.Shuffle();

            foreach (int nextCartImageId in nextCardsImagesIds) // We go through all images (ids) of the level
            {
                // We are retrieving a randomized children of player 1 and put it the next images
                var memoryCard1 = (MemoryCard)this.Player1Grid.Children.ElementAt(player1MemoryCardsId.First());
                memoryCard1.SetImageFromLevelAndCardId(levelId, nextCartImageId);
                player1MemoryCardsId.RemoveAt(0); // We remove the used child id

                if (player2MemoryCardsId.Count() > 0) // the player 2 has one card less because of the validator
                {
                    // Same process of player 1 but for only 5 children
                    var memoryCard2 = (MemoryCard)this.Player2Grid.Children.ElementAt(player2MemoryCardsId.First());
                    memoryCard2.SetImageFromLevelAndCardId(levelId, nextCartImageId);
                    player2MemoryCardsId.RemoveAt(0);
                } else
                {
                    // there is still one image but no children left in player 2 grid so this is the intruder.
                    this.intruderId = nextCartImageId;
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(MainPage), null, new SuppressNavigationTransitionInfo());
            Frame.GoBack();

        }       
    }


    public static class ThreadSafeRandom
    {
        [ThreadStatic] private static Random Local;

        public static Random ThisThreadsRandom
        {
            get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
        }
    }
    static class MyExtensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
