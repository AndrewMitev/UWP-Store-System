using Store.Helpers;
using Store.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Store
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Details : Page
    {
        public Details()
        {
            this.InitializeComponent();
        }

        public ItemViewModel ViewModel
        {
            get
            {
                return this.DataContext as ItemViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            ItemViewModel food = (ItemViewModel)e.Parameter;

            this.ViewModel = food;
        }

        private void Menu_Tapped(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(this.selectedQuantity.Text, @"^\d+$"))
            {
                return;
            }

            var storedItem = new ItemViewModel
            {
                Name = this.ViewModel.Name,
                Price = this.ViewModel.Price,
                Measurement = this.ViewModel.Measurement,
                Quantity = int.Parse(this.selectedQuantity.Text)
            };

            Cart.UserChart.Items.Add(storedItem);



            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
