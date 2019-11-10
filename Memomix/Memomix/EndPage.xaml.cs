using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Windows.UI.Xaml.Media.Imaging;
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

            App.client.On("retry", async (data) =>
            {
                Debug.WriteLine("WEB RETRY : ");

                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => {
                    Retry();
                });
            });


            if (App.HasWon)
            {
                TitleText.Text = "BRAVO !";
                this.ImageVictory.Visibility = Visibility.Visible;
                this.ImageFailure.Visibility = Visibility.Collapsed;
            } else
            {
                TitleText.Text = "ZUT !";
                this.ImageVictory.Visibility = Visibility.Collapsed;
                this.ImageFailure.Visibility = Visibility.Visible;

            }
            SetIntruderImage();


        }

        private void SetIntruderImage()
        {
            this.ImageIntruder.Source = new BitmapImage(new Uri("ms-appx:///Assets/Cards/Level" + App.LevelId + "/carte" + App.IntruderId + ".png"));
        }
        int count = 0;
        private void RetryButton_Click(object sender, RoutedEventArgs e)
        {
            if (count < 2) // Wait for 2 seconds before launching action
            {
                count += 1;
            }
            else
            {
                Retry();
            }
        }

        private void Retry()
        {
            Frame.Navigate(typeof(MainPage), null, new SuppressNavigationTransitionInfo());

        }


    }
}
