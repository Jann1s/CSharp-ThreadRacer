using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ThreadRacer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Race race;
        public MainPage()
        {
            this.InitializeComponent();
            race = new Race();

            ApplicationView.PreferredLaunchViewSize = new Size(1000, 600);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(1000, 600));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Race)
            {
                Race tmpRace = (Race)e.Parameter;

                race = tmpRace;
                
                if (tmpRace.track != null)
                {
                    race.track = tmpRace.track;

                    if (race.track is Tracks.CalcLargeFactorials)
                    {
                        trackSelection.Text = "= Calculate large factorials";
                    }
                    else if (race.track is Tracks.Loop)
                    {
                        trackSelection.Text = "= Loop";
                    }
                    else if (race.track is Tracks.PrimeNumbers)
                    {
                        trackSelection.Text = "= Prime Numbers";
                    }
                    else if (race.track is Tracks.CaclPI)
                    {
                        trackSelection.Text = "= Calculate Pi";
                    }
                }

                string[] cars = race.GetCars().ToArray();

                if (cars.Length > 0)
                {
                    carSelection.Text = "= " + String.Join(", ", cars);
                }
                else
                {
                    carSelection.Text = "= No Cars selected";
                }
            }
        }

        public void SetTrackText(String text)
        {
            trackSelection.Text = text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SelectTrack), race);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SelectCar), race);
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RaceWindow), race);
        }
    }
}
