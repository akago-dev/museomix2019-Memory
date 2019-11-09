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
        private bool isValidator;
        public int CardId = 1;

        public event EventHandler MemoryCardOpened;

        public bool IsValidator
        {
            get
            {
                return this.isValidator;
            }
            set
            {
                this.isValidator = value;
                if (value == true)
                {
                    this.ImageCard.Opacity = 0;
                    this.ImageCover.Opacity = 0.5;
                    this.ImageValidator.Opacity = 0;
                }
            }
        }

        public MemoryCard()
        {
            this.InitializeComponent();
        }

        public void SetImageFromLevelAndCardId(int levelId = 1, int cardId = 1)
        {
            this.CardId = cardId;
            this.ImageCard.Source = new BitmapImage(new Uri("ms-appx:///Assets/Cards/Level"+levelId+"/carte"+ cardId +".png"));
        }

        int count = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RepeatButton butt = sender as RepeatButton;
            
            if (count < 2)
            {
                count += 1;
                Debug.WriteLine(count);
            }
            else
            {
                this.Open();
                butt.IsEnabled = false;
                butt.IsEnabled = true;
            }                                                                                                                                                 
            
        }

        public void Open()
        {
            MemoryCardOpened?.Invoke(this, null);
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
        public void Close()
        {
            if (cardOpen)
            {
                FlipClose.Begin();
                cardOpen = false;
            }
                
        }

        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("test button pressed");
        }

        //DateTime firstPressTimeStamp;
        //private void Button_PointerPressed(object sender, PointerRoutedEventArgs e)
        //{
        //    firstPressTimeStamp = DateTime.Now;
        //    Debug.WriteLine("pressed");
        //}

        //private void Button_PointerReleased(object sender, PointerRoutedEventArgs e)
        //{
        //    TimeSpan diff = DateTime.Now.Subtract(firstPressTimeStamp);
        //    if (diff.TotalSeconds > 2)
        //    {
        //        Button_Click(null, null);
        //    }
        //    Debug.WriteLine("released");
        //}
    }
}
