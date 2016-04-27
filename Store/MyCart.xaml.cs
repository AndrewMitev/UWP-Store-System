namespace Store
{
    using SQLite.Net;
    using SQLite.Net.Async;
    using SQLite.Net.Platform.WinRT;
    using Helpers;
    using Models;
    using Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Windows.Storage;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyCart : Page
    {
        public MyCart()
        {
            this.InitializeComponent();
            this.ViewModel = new ItemCollectionViewModel(Cart.UserChart.Items);

            this.UserName.Text = Cart.UserChart.FirstName;
            this.Money.Text = Cart.UserChart.Money.ToString() + "$";
        }

        public ItemCollectionViewModel ViewModel
        {
            get
            {
                return this.DataContext as ItemCollectionViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        private void Menu_Tapped(object sender, RoutedEventArgs args)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void My_Cart(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MyCart));
        }

        private async void Begin_Transaction(object sender, RoutedEventArgs e)
        {
            if (this.ViewModel.Items.Count() == 0)
            {
                return;
            }

            decimal totalSum = this.ViewModel.Items.Sum(x => (x.Quantity * x.Price));

            if (totalSum > Cart.UserChart.Money)
            {
                return;
            }

            var connection = this.GetDbConnectionAsync();
            var records = await connection.Table<Item>().ToListAsync(); //Where(x => x.Id == item.Id).FirstAsync();

            foreach (var item in this.ViewModel.Items)
            {
                Item databaseItem = records.FirstOrDefault(x => x.Id == item.Id);

                if (databaseItem != null)
                {
                    databaseItem.Quantity -= item.Quantity;
                    await connection.UpdateAsync(databaseItem);
                }
            }

            List<ISellable> transferList = new List<ISellable>();

            this.ViewModel.Items.ForEach(x => transferList.Add(x));

            this.ViewModel.Clear();
            Cart.UserChart.Items.Clear();

            this.Frame.Navigate(typeof(Bon), transferList);
        }

        private SQLiteAsyncConnection GetDbConnectionAsync()
        {
            var dbFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "db.sqlite");

            var connectionFactory =
                new Func<SQLiteConnectionWithLock>(
                    () =>
                    new SQLiteConnectionWithLock(
                        new SQLitePlatformWinRT(),
                        new SQLiteConnectionString(dbFilePath, storeDateTimeAsTicks: false)));

            var asyncConnection = new SQLiteAsyncConnection(connectionFactory);

            return asyncConnection;
        }

        private void Clear_Cart(object sender, RoutedEventArgs e)
        {
            this.ViewModel.Clear();
            Cart.UserChart.Items.Clear();
        }
    }
}
