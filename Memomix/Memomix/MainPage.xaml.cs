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

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Memomix
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        int count = 0;
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (count < 2) // Wait for 2 seconds before launching action
            {
                count += 1;
            }
            else
            {
                var levelsIDS = new List<int>() { 1, 2};

                //Randomization of the levels ids and memory cards children ids
                levelsIDS.Shuffle();                

                App.LevelId = levelsIDS.First();
                Frame.Navigate(typeof(MemoryPage), null, new SuppressNavigationTransitionInfo());
            }
        }

        private void Level1Button_Click(object sender, RoutedEventArgs e)
        {
            App.LevelId = 1;
            Frame.Navigate(typeof(MemoryPage), null, new SuppressNavigationTransitionInfo());
        }

        private void Level2Button_Click(object sender, RoutedEventArgs e)
        {
            App.LevelId = 2;
            Frame.Navigate(typeof(MemoryPage), null, new SuppressNavigationTransitionInfo());
        }

        private void Level3Button_Click(object sender, RoutedEventArgs e)
        {
            App.LevelId = 3;
            Frame.Navigate(typeof(MemoryPage), null, new SuppressNavigationTransitionInfo());
        }
    }
}
