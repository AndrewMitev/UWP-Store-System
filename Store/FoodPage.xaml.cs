using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.WinRT;
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
    public sealed partial class FoodPage : Page
    {
        public FoodPage()
        {
            this.InitializeComponent();

            this.ViewModel = new FoodViewModel();
            this.GetAllFoods();
        }

        private async void GetAllFoods()
        {
            var connection = this.GetDbConnectionAsync();

            IEnumerable<FoodItem> data =  await connection.Table<FoodItem>().ToListAsync();

            if (data.Count() > 0)
            {
                data.ForEach(i => this.ViewModel.Add(new FoodItemViewModel { Name=i.Name, Price=i.Price, ImageBytes=i.Image}));
            }
        }

        public FoodViewModel ViewModel
        {
            get
            {
                return this.DataContext as FoodViewModel;
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
    }
}
