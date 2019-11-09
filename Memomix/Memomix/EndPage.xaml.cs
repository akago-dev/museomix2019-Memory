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
    public sealed partial class EndPage : Page
    {
        public EndPage()
        {
            this.InitializeComponent();
            if (App.HasWon)
            {
                FirstText.Text = "BIG WINNER";
            } else
            {
                FirstText.Text = "BIG LOOSER";
            }
        }

        int count = 0;
        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            if (count < 2) // Wait for 2 seconds before launching action
            {
                count += 1;
            }
            else
            {
                Frame.Navigate(typeof(MainPage), null, new SuppressNavigationTransitionInfo());
            }
        }
    }
}
