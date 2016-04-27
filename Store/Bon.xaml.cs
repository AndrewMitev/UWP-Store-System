using Store.Helpers;
using Store.Models.Contracts;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Store
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Bon : Page
    {
        public Bon()
        {
            this.InitializeComponent();         
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            decimal totalSum = 0;

            base.OnNavigatedTo(e);

            List<ISellable> items = (List<ISellable>)e.Parameter;

            this.listItems.ItemsSource = items;

            foreach (var item in items)
            {
                totalSum += item.Total;
            }

            this.TotalBill.Text = totalSum.ToString();
            this.Change.Text = (Cart.UserChart.Money - totalSum).ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
