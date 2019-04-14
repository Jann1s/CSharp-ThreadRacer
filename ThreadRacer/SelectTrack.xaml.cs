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
using Windows.UI.Xaml.Navigation;

using ThreadRacer.Tracks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ThreadRacer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SelectTrack : Page
    {
        private Race race;

        public SelectTrack()
        {
            this.InitializeComponent();

            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            race = (Race)e.Parameter;
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        //Back Button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        //Factorials
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ITrack track = new CalcLargeFactorials();
            race.track = track;
            this.Frame.Navigate(typeof(MainPage), race);
        }

        //Loop
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ITrack track = new Loop();
            race.track = track;
            this.Frame.Navigate(typeof(MainPage), race);
        }

        //Prime Numbers
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ITrack track = new PrimeNumbers();
            race.track = track;
            this.Frame.Navigate(typeof(MainPage), race);
        }
    }
}
