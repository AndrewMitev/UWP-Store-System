using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.WinRT;
using Store.Helpers;
using Store.Models;
using Store.Models.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
            var connection = this.GetDbConnectionAsync();

            foreach (var item in this.ViewModel.Items)
            {
                Item databaseItem = await connection.Table<Item>().Where(x => x.Id == item.Id).FirstOrDefaultAsync();

                if (databaseItem != null)
                {
                    databaseItem.Quantity -= item.Quantity;
                    await connection.UpdateAsync(databaseItem);
                }
            }

            List<ISellable> transferList = new List<ISellable>();

            this.ViewModel.Items.ForEach(x => transferList.Add(x));

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
    }
}
