namespace Store
{
    using Helpers;
    using Models.Contracts;
    using System.Collections.Generic;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

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

            decimal change = Cart.UserChart.Money - totalSum;
            Cart.UserChart.Money = change;

            this.TotalBill.Text = totalSum.ToString();
            this.Change.Text = change.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
