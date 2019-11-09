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

        private void Level1Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MemoryPage), 1, new SuppressNavigationTransitionInfo());

        }

        private void Level2Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MemoryPage), 2, new SuppressNavigationTransitionInfo());

        }

        private void Level3Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MemoryPage), 3, new SuppressNavigationTransitionInfo());

        }
    }
}
