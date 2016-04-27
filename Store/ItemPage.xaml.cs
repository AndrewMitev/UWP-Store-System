using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.WinRT;
using Store.Helpers;
using Store.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Store
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ItemPage : Page
    {
        private int categoryId;

        public ItemPage()
        {
            this.InitializeComponent();

            this.ViewModel = new ItemCollectionViewModel();

            this.UserName.Text = Cart.UserChart.FirstName;
            this.Money.Text = Cart.UserChart.Money.ToString() + " $";
        }

        private async void GetAllItems()
        {
            var connection = this.GetDbConnectionAsync();

            IEnumerable<Item> data =  await connection.Table<Item>().Where(i => i.CategoryId == this.categoryId).ToListAsync();

            if (data.Count() > 0)
            {
                data.ForEach(i => this.ViewModel.Add(new ItemViewModel { Id = i.Id, Name=i.Name, Price=i.Price, ImageBytes=i.Image}));
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            this.categoryId = (int)e.Parameter;
            this.GetAllItems();
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
            int id = (int)((Button)sender).Tag;
            ItemViewModel food = (ItemViewModel)this.ViewModel.Items.FirstOrDefault(p => p.Id == id);

            this.Frame.Navigate(typeof(Details), food);
        }
    }
}
