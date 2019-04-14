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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ThreadRacer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SelectCar : Page
    {
        private Race race;

        public SelectCar()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            race = (Race)e.Parameter;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (check_async.IsChecked == true)
            {
                race.AddCar(new Threading.AsyncAwait(), 4);
            }

            if (check_linq.IsChecked == true)
            {
                race.AddCar(new Threading.LINQMethod(), 4);
            }

            if (check_tasks.IsChecked == true)
            {
                race.AddCar(new Threading.Task(), 4);
            }

            if (check_threadpool.IsChecked == true)
            {
                race.AddCar(new Threading.ThreadPool(), 4);
            }

            if (check_single.IsChecked == true)
            {
                race.AddCar(new Threading.Single(), 4);
            }

            this.Frame.Navigate(typeof(MainPage), race);
        }
    }
}
