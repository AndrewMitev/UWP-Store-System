namespace Store
{
    using Helpers;
    using Models;
    using System.Text.RegularExpressions;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Details : Page
    {
        public Details()
        {
            this.InitializeComponent();
            this.UserName.Text = Cart.UserChart.FirstName;
            this.Money.Text = Cart.UserChart.Money.ToString() + "$";
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

        private void My_Cart(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MyCart));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(this.selectedQuantity.Text, @"^\d+$"))
            {
                return;
            }

            int selectedQuantityValue = int.Parse(this.selectedQuantity.Text);

            if (this.ViewModel.Quantity < selectedQuantityValue)
            {
                return;
            }

            var storedItem = new ItemViewModel
            {
                Id = this.ViewModel.Id,
                Name = this.ViewModel.Name,
                Price = this.ViewModel.Price,
                Measurement = this.ViewModel.Measurement,
                Quantity = selectedQuantityValue
            };

            Cart.UserChart.Items.Add(storedItem);

            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
