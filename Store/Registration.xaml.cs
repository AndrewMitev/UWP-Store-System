namespace Store
{
    using Helpers;
    using System.Text.RegularExpressions;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Registration : Page
    {
        public Registration()
        {
            this.InitializeComponent();
        }

        private void Register_User(object sender, RoutedEventArgs e)
        {
            if (this.UserFirstName.Text == string.Empty || this.UserLastName.Text == string.Empty || this.UserMoney.Text == string.Empty)
            {
                return;
            }

            if (Regex.IsMatch(this.UserMoney.Text, "^\\d+(.\\d+){0,1}$") == false)
            {
                return;
            }

            Cart.UserChart.FirstName = this.UserFirstName.Text;
            Cart.UserChart.LastName = this.UserLastName.Text;
            Cart.UserChart.Money = decimal.Parse(this.UserMoney.Text);

            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
