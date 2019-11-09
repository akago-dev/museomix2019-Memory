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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Pour en savoir plus sur le modèle d'élément Contrôle utilisateur, consultez la page https://go.microsoft.com/fwlink/?LinkId=234236

namespace Memomix
{
    public sealed partial class MemoryCard : UserControl
    {
        private bool cardOpen;
        public static readonly DependencyProperty IsValidatorProperty =
           DependencyProperty.Register(
               "IsValidator", typeof(Boolean),
               typeof(MemoryCard), null
           );
        // The property wrapper, so that callers can use this property through a simple ExampleClassInstance.IsSpinning usage rather than requiring property system APIs
        public bool IsValidator
        {
            get { return (bool)GetValue(IsValidatorProperty); }
            set { SetValue(IsValidatorProperty, value); }
        }

        public MemoryCard()
        {
            this.InitializeComponent();
        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (cardOpen == false)
            {
                FlipOpen.Begin();
                cardOpen = true;
            }
            else
            {
                FlipClose.Begin();
                cardOpen = false;
            }
        }

       /* private void SetImageFromLevel(int levelId)
        {
            int cardId = GetRandomNumber(1, 5);
            Image img = new Image();
            img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Cards/"+levelId+"/carte"+ cardId +".png"));
        }*/

  
    }
}
