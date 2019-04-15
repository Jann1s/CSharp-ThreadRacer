using System;
using System.Collections.Generic;
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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ThreadRacer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RaceWindow : Page
    {
        private Race race;
        DispatcherTimer dispatcherTimer;

        public RaceWindow()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            race = (Race)e.Parameter;

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(2);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Start();

            progressBar.IsIndeterminate = true;
            progressBar.Value = 0;
            progressBar.Maximum = race.AmountCars();
            progressBar.Minimum = 0;

            resultText.Text = "Results - ";

            if (race.track is Tracks.CalcLargeFactorials)
            {
                resultText.Text += " Calculate large factorials";
            }
            else if (race.track is Tracks.Loop)
            {
                resultText.Text += " Loop";
            }
            else if (race.track is Tracks.PrimeNumbers)
            {
                resultText.Text += " Prime Numbers";
            }

            System.Threading.Tasks.Task task = new System.Threading.Tasks.Task(() => race.StartRace());
            task.Start();
        }

        private void DispatcherTimer_Tick(object sender, object e)
        {
            //Checking every 2 seconds if the results are up already
            Dictionary<string, long> result = race.GetResult();

            if (result.Count > 0)
            {
                //Results should be now shown!
                progressBar.Value = progressBar.Maximum;

                resultText.Text += "\r\n";
                resultText.Text += "\r\n";

                foreach (KeyValuePair<string, long> car in result)
                {
                    resultText.Text += car.Key + ": " + car.Value + " ms \r\n";
                }

                dispatcherTimer.Stop();
            }
            else
            {
                int amount = race.AmountFinished();

                if (amount > 0)
                {
                    progressBar.IsIndeterminate = false;
                    progressBar.Value = amount;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
