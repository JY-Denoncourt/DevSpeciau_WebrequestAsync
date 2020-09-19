using System;
using System.Collections.Generic;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ApiConsumerDemo
{
    /// <summary>
    /// Interaction logic for DogInfo.xaml
    /// </summary>
    public partial class DogInfo : Window
    {
        public DogInfo()
        {
            InitializeComponent();
            init();
        }

        private async void init()
        { 
            await LoadImage(); 
        }

        private async Task LoadImage()
        {
            var dogImgs = await DogProcessor.LoadDog();

            var uriSource1 = new Uri(dogImgs.Dog1.message, UriKind.Absolute);
            comicImage1.Source = new BitmapImage(uriSource1, new RequestCachePolicy(RequestCacheLevel.CacheIfAvailable));

            var uriSource2 = new Uri(dogImgs.Dog2.message, UriKind.Absolute);
            comicImage2.Source = new BitmapImage(uriSource2, new RequestCachePolicy(RequestCacheLevel.CacheIfAvailable));
        }

        private async void Next_LoadImage(object sender, RoutedEventArgs e)
        {
            await LoadImage();
        }
    }
}
